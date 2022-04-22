using AutoUpdaterDotNET;
using HtmlAgilityPack;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;

namespace Retro_Achievement_Tracker
{
    public partial class MainPage : Form
    {
        private UserSummary UserSummary { get; set; }
        private GameInfoAndProgress GameInfoAndProgress { get; set; }
        private Achievement CurrentlyViewingAchievement;
        private int CurrentlyViewingIndex;
        private bool UpdatingVisibility;

        private List<Achievement> LockedAchievements
        {
            get
            {
                if (GameInfoAndProgress != null)
                {
                    return GameInfoAndProgress.Achievements.FindAll(x => !x.HardcoreAchieved);
                }
                return new List<Achievement>();
            }
        }

        private List<Achievement> UnlockedAchievements
        {
            get
            {
                if (GameInfoAndProgress != null)
                {
                    return GameInfoAndProgress.Achievements.FindAll(x => x.HardcoreAchieved);
                }
                return new List<Achievement>();
            }
        }

        private List<Achievement> OldUnlockedAchievements;

        private Timer UserAndGameUpdateTimer;
        private int UserAndGameTimerCounter;

        private bool ShouldRun;

        private CustomMenuState MenuState = CustomMenuState.CLOSED;

        private RetroAchievementAPIClient retroAchievementsAPIClient;

        public MainPage()
        {
            InitializeComponent();
            AutoUpdate();

            retroAchievementsAPIClient = new RetroAchievementAPIClient(Settings.Default.ra_username, Settings.Default.ra_key);

            LoadProperties();
            SetupInterface();
        }
        private void AutoUpdate()
        {
            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
            AutoUpdater.ReportErrors = false;
            AutoUpdater.Synchronous = true;
            AutoUpdater.Start("https://github.com/Colossus-Gaming/retroachievements-layout-manager/releases/download/release-management/ra-layout-manager-release.xml");
        }

        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args != null)
            {
                if (args.IsUpdateAvailable)
                {
                    try
                    {
                        if (AutoUpdater.DownloadUpdate(args))
                        {
                            Close();
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(
                        @"There is a problem reaching update server please check your internet connection and try again later.",
                        @"Update check failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetupInterface()
        {
            UserAndGameUpdateTimer = new Timer
            {
                Enabled = false
            };
            UserAndGameUpdateTimer.Tick += new EventHandler(UpdateFromSite);
            UserAndGameUpdateTimer.Interval = 1000;

            UpdateGroupBoxVisibility();

            if (StatsController.Instance.AutoLaunch)
            {
                StatsController.Instance.Show();
            }
            if (FocusController.Instance.AutoLaunch)
            {
                FocusController.Instance.Show();
            }
            if (GameInfoController.Instance.AutoLaunch)
            {
                GameInfoController.Instance.Show();
            }
            if (LastFiveController.Instance.AutoLaunch)
            {
                LastFiveController.Instance.Show();
            }
            if (AlertsController.Instance.AutoLaunch)
            {
                AlertsController.Instance.Show();
            }
            if (AchievementListController.Instance.AutoLaunch)
            {
                AchievementListController.Instance.Show();
            }
        }

        private void UpdateGameProgress(bool sameGame)
        {
            try
            {
                SortAchievements();

                UpdateStats();
                UpdateLastFive();

                if (sameGame)
                {
                    List<Achievement> achievementNotificationList = UnlockedAchievements
                    .FindAll(unlockedAchievement => !OldUnlockedAchievements.Contains(unlockedAchievement))
                    .ToList();

                    if (achievementNotificationList.Count > 0)
                    {
                        UpdateTimerLabel("CHEEVOS POP!");

                        achievementNotificationList.Sort();

                        AlertsController.Instance.EnqueueAchievementNotifications(achievementNotificationList);

                        if (!achievementNotificationList.Contains(CurrentlyViewingAchievement))
                        {
                            CurrentlyViewingIndex = LockedAchievements.IndexOf(CurrentlyViewingAchievement);
                        } 

                        UpdateCurrentlyViewingAchievement();

                        if (UnlockedAchievements.Count == GameInfoAndProgress.Achievements.Count && OldUnlockedAchievements.Count < GameInfoAndProgress.Achievements.Count)
                        {
                            ClearFocusAchievementRenders();
                            AlertsController.Instance.EnqueueMasteryNotification(UserSummary, GameInfoAndProgress);
                        }
                        AlertsController.Instance.RunNotifications();
                    }
                }
                else
                {
                    UpdateTimerLabel("Changing game to [" + GameInfoAndProgress.Title + "]");

                    if (LockedAchievements.Count > 0)
                    {
                        CurrentlyViewingIndex = 0;

                        UpdateCurrentlyViewingAchievement();
                        SetFocus();
                    }
                    else
                    {
                        ClearFocusAchievementRenders();
                    }
                }

                UpdateAchievementList(!sameGame);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        private void SetFocus()
        {
            if (CurrentlyViewingAchievement != null)
            {
                FocusController.Instance.SetFocus(CurrentlyViewingAchievement);
                StreamLabelManager.Instance.WriteFocusStreamLabels(CurrentlyViewingAchievement);
            }
            else
            {
                ClearFocusAchievementRenders();
            }
        }

        private async void UpdateFromSite(object sender, EventArgs e)
        {
            if (!ShouldRun)
            {
                UserAndGameUpdateTimer.Stop();

                return;
            }
            UserAndGameTimerCounter--;

            UpdateTimerLabel("Updating in " + UserAndGameTimerCounter + "...");

            if (UserAndGameTimerCounter < 0)
            {
                UserAndGameUpdateTimer.Stop();

                UpdateTimerLabel("Calling for user info.");

                try
                {
                    long previousId = -1;

                    if (UserSummary != null && UserSummary.LastGameID > 0)
                    {
                        previousId = UserSummary.LastGameID;
                    }

                    if (UnlockedAchievements != null)
                    {
                        OldUnlockedAchievements = UnlockedAchievements.ToList();
                    }

                    await retroAchievementsAPIClient.GetUserSummary().ContinueWith(async userSummaryTemp =>
                    {
                        UserSummary = userSummaryTemp.Result;
                        this.raConnectionStatusPictureBox.Image = Resources.green_button;
                        userProfilePictureBox.ImageLocation = "https://retroachievements.org/UserPic/" + usernameTextBox.Text + ".png";

                        UpdateTimerLabel("Calling for user game progress.");

                        await retroAchievementsAPIClient.GetUserProgress(UserSummary.LastGameID).ContinueWith(async userProgress =>
                        {
                            GameInfoAndProgress = userProgress.Result;

                            UpdateGameInfo();

                            int newId = UserSummary.LastGameID;

                            await retroAchievementsAPIClient.GetCompletedGames().ContinueWith(completed =>
                            {
                                UserSummary.Awards = completed.Result.FindAll(x => x.HardcoreMode && x.AchievementsEarned == x.AchievementsPossible).Count;

                                UpdateGameProgress(newId == previousId);

                                Invoke((MethodInvoker)delegate
                                {
                                    StartTimer();
                                });
                            });
                        });
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
        protected override void OnShown(EventArgs e)
        {
            CreateFolders();

            if (CanStart())
            {
                if (autoStartCheckbox.Checked)
                {
                    StartButton_Click(null, null);
                }
            }
            else
            {
                StopButton_Click(null, null);
            }
        }
        private void CreateFolders()
        {
            if (!Directory.Exists(@"stream-labels"))
            {
                Directory.CreateDirectory(@"stream-labels");
            }
            if (!Directory.Exists(@"stream-labels\stats"))
            {
                Directory.CreateDirectory(@"stream-labels\stats");
            }
            if (!Directory.Exists(@"stream-labels\game-info"))
            {
                Directory.CreateDirectory(@"stream-labels\game-info");
            }
            if (!Directory.Exists(@"stream-labels\last-five"))
            {
                Directory.CreateDirectory(@"stream-labels\last-five");
            }
            if (!Directory.Exists(@"stream-labels\focus"))
            {
                Directory.CreateDirectory(@"stream-labels\focus");
            }
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            stopButton.Enabled = true;

            ShouldRun = true;

            usernameTextBox.Enabled = false;
            apiKeyTextBox.Enabled = false;

            openFocusWindowButton.Enabled = true;
            openNotificationWindowButton.Enabled = true;
            openStatsWindowButton.Enabled = true;
            openGameInfoWindowButton.Enabled = true;

            UpdateFromSite(null, null);

            Settings.Default.ra_username = usernameTextBox.Text;
            Settings.Default.ra_key = apiKeyTextBox.Text;
            Settings.Default.Save();
        }
        private void StopButton_Click(object sender, EventArgs e)
        {
            ShouldRun = false;

            UserAndGameUpdateTimer.Stop();

            raConnectionStatusPictureBox.Image = Resources.red_button;

            UpdateTimerLabel("Stopped Updating.");

            stopButton.Enabled = false;
            openFocusWindowButton.Enabled = CanStart();
            openNotificationWindowButton.Enabled = CanStart();
            openStatsWindowButton.Enabled = CanStart();
            openGameInfoWindowButton.Enabled = CanStart();
            openLastFiveWindowButton.Enabled = CanStart();
            openAchievementListWindowButton.Enabled = CanStart();

            apiKeyTextBox.Enabled = true;
            usernameTextBox.Enabled = true;

            startButton.Enabled = CanStart();
        }

        public void SetLockedAchievements()
        {
            Invoke((MethodInvoker)delegate
            {
                if (GameInfoAndProgress.Achievements != null && GameInfoAndProgress.Achievements.Count > 0)
                {
                    int gameId = GameInfoAndProgress.Achievements[0].GameId;

                    if (LockedAchievements == null || (LockedAchievements.Count > 0 && gameId != LockedAchievements[0].GameId))
                    {
                        CurrentlyViewingIndex = 0;
                        CurrentlyViewingAchievement = null;
                    }
                }
                else
                {
                    CurrentlyViewingAchievement = null;
                }

                UpdateCurrentlyViewingAchievement();
            });
        }

        public void UpdateCurrentlyViewingAchievement()
        {
            if (Visible)
            {
                Invoke((MethodInvoker)delegate
                {
                    if (LockedAchievements.Count > 0)
                    {
                        if (CurrentlyViewingIndex >= LockedAchievements.Count)
                        {
                            CurrentlyViewingIndex = LockedAchievements.Count - 1;
                        }
                        else if (CurrentlyViewingIndex < 0)
                        {
                            CurrentlyViewingIndex = 0;
                        }

                        CurrentlyViewingAchievement = LockedAchievements[CurrentlyViewingIndex];

                        focusAchievementPictureBox.ImageLocation = "https://retroachievements.org/Badge/" + CurrentlyViewingAchievement.BadgeNumber + ".png";
                        focusAchievementTitleLabel.Text = CurrentlyViewingAchievement.Title;
                        focusAchievementDescriptionLabel.Text = CurrentlyViewingAchievement.Description;
                    }
                    else
                    {
                        CurrentlyViewingIndex = 0;

                        focusAchievementPictureBox.ImageLocation = string.Empty;
                        focusAchievementTitleLabel.Text = string.Empty;
                        focusAchievementDescriptionLabel.Text = string.Empty;
                    }

                    UpdateFocusButtons();
                });
            }
        }
        private List<Achievement> GetLastFiveAchievements()
        {
            List<Achievement> achievements = GameInfoAndProgress.Achievements.FindAll(x => x.HardcoreAchieved);
            achievements.Sort();
            achievements.Reverse();

            List<Achievement> newAchievements = achievements.GetRange(0, achievements.Count > 5 ? 5 : achievements.Count);
            newAchievements.Reverse();

            return newAchievements;
        }
        private void UpdateLastFive()
        {
            Invoke((MethodInvoker)delegate
            {
                Task.Run(() => LastFiveController.Instance.SetAchievements(GetLastFiveAchievements()));

                StreamLabelManager.Instance.WriteLastFiveStreamLabels(GameInfoAndProgress);
            });
        }
        private void UpdateStats()
        {
            Invoke((MethodInvoker)delegate
            {
                StatsController.Instance.SetRank(UserSummary.Rank.ToString());
                StatsController.Instance.SetRatio(UserSummary.RetroRatio);
                StatsController.Instance.SetAwards(UserSummary.Awards.ToString());
                StatsController.Instance.SetPoints(UserSummary.TotalPoints.ToString());
                StatsController.Instance.SetTruePoints(UserSummary.TotalTruePoints.ToString());
                StatsController.Instance.SetGamePoints(GameInfoAndProgress.GamePointsEarned.ToString(), GameInfoAndProgress.GamePointsPossible.ToString());
                StatsController.Instance.SetGameAchievements(GameInfoAndProgress.AchievementsEarned.ToString(), GameInfoAndProgress.Achievements.Count.ToString());
                StatsController.Instance.SetGameTruePoints(GameInfoAndProgress.GameTruePointsEarned.ToString(), GameInfoAndProgress.GameTruePointsPossible.ToString());
                StatsController.Instance.SetGameRatio();
                StatsController.Instance.SetCompleted(GameInfoAndProgress.AchievementsEarned / (float)GameInfoAndProgress.Achievements.Count * 100f);

                StreamLabelManager.Instance.WriteStatsStreamLabels(UserSummary, GameInfoAndProgress);
            });
        }
        private void UpdateGameInfo()
        {
            Invoke((MethodInvoker)delegate
            {
                GameInfoController.Instance.SetTitleValue(GameInfoAndProgress.Title);
                GameInfoController.Instance.SetGenreValue(GameInfoAndProgress.Genre);
                GameInfoController.Instance.SetConsoleValue(GameInfoAndProgress.ConsoleName);
                GameInfoController.Instance.SetDeveloperValue(GameInfoAndProgress.Developer);
                GameInfoController.Instance.SetPublisherValue(GameInfoAndProgress.Publisher);
                GameInfoController.Instance.SetReleaseDateValue(GameInfoAndProgress.Released);

                StreamLabelManager.Instance.WriteGameInfoStreamLabels(GameInfoAndProgress);
            });
        }
        private void ClearFocusAchievementRenders()
        {
            Invoke((MethodInvoker)delegate
            {
                FocusController.Instance.HideFocus();

                StreamLabelManager.Instance.ClearFocusStreamLabels();
            });
        }

        private void UpdateAchievementList(bool newGame)
        {
            Invoke((MethodInvoker)delegate
            {
                AchievementListController.Instance.UpdateAchievementList(UnlockedAchievements, LockedAchievements, newGame);
            });
        }
        private bool CanStart()
        {
            return !(string.IsNullOrEmpty(usernameTextBox.Text)
                || string.IsNullOrEmpty(apiKeyTextBox.Text));
        }
        private void UpdateTimerLabel(string s)
        {
            Invoke((MethodInvoker)delegate
            {
                timerStatusLabel.Text = s;
            });
        }

        private void StartTimer()
        {
            UserAndGameTimerCounter = 6;

            if (ShouldRun)
            {
                UserAndGameUpdateTimer.Start();
            }
        }
        private void SortAchievements()
        {
            GameInfoAndProgress.Achievements.ForEach(achievement =>
            {
                Achievement otherAchievement = UserSummary.Achievements.Find(achievement1 => achievement.Id == achievement1.Id);

                if (otherAchievement != null)
                {
                    achievement.GameId = otherAchievement.GameId;
                    achievement.GameTitle = otherAchievement.GameTitle;
                }
            });

            if (OldUnlockedAchievements.Count < UnlockedAchievements.Count)
            {
                if (LockedAchievements.Count == 0)
                {
                    CurrentlyViewingIndex = 0;
                    FocusController.Instance.HideFocus();
                    return;
                }
                else if (LockedAchievements.IndexOf(FocusController.Instance.CurrentlyFocusedAchievement) > -1)
                {
                    CurrentlyViewingIndex = LockedAchievements.IndexOf(FocusController.Instance.CurrentlyFocusedAchievement);
                }
                else
                {
                    CurrentlyViewingIndex = LockedAchievements.IndexOf(CurrentlyViewingAchievement) == -1 ? 0 : LockedAchievements.IndexOf(CurrentlyViewingAchievement);
                }
                UpdateCurrentlyViewingAchievement();
                SetFocus();
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            StreamLabelManager.Instance.ClearAllStreamLabels();

            FocusController.Instance.Close();
            StatsController.Instance.Close();
            AlertsController.Instance.Close();
            GameInfoController.Instance.Close();
            LastFiveController.Instance.Close();
            AchievementListController.Instance.Close();
        }

        private void RequiredField_TextChange(object sender, EventArgs e)
        {
            startButton.Enabled = CanStart();
        }

        private void AutoLaunchCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            switch (checkBox.Name)
            {
                case "autoLaunchLastFiveWindowCheckbox":
                    LastFiveController.Instance.AutoLaunch = checkBox.Checked;
                    break;
                case "autoLaunchGameInfoWindowCheckbox":
                    GameInfoController.Instance.AutoLaunch = checkBox.Checked;
                    break;
                case "autoStartCheckbox":
                    Settings.Default.auto_start_checked = checkBox.Checked;
                    break;
                case "autoLaunchAlertsWindowCheckbox":
                    AlertsController.Instance.AutoLaunch = checkBox.Checked;
                    break;
                case "autoLaunchFocusWindowCheckBox":
                    FocusController.Instance.AutoLaunch = checkBox.Checked;
                    break;
                case "autoLaunchStatsWindowCheckbox":
                    StatsController.Instance.AutoLaunch = checkBox.Checked;
                    break;
                case "autoLaunchAchievementListWindowCheckbox":
                    AchievementListController.Instance.AutoLaunch = checkBox.Checked;
                    break;
            }
        }
        private void CustomAchievementEnableCheckbox_CheckedChanged(object sender, EventArgs eventArgs)
        {
            AlertsController.Instance.CustomAchievementEnabled = ((CheckBox)sender).Checked;

            customAchievementEnableCheckbox.Checked = AlertsController.Instance.CustomAchievementEnabled;
            selectCustomAchievementButton.Enabled = AlertsController.Instance.CustomAchievementEnabled;
            acheivementEditOutlineCheckbox.Enabled = AlertsController.Instance.CustomAchievementEnabled;

            AlertsController.Instance.Reset();
        }
        private void CustomMasteryEnableCheckbox_CheckedChanged(object sender, EventArgs eventArgs)
        {
            AlertsController.Instance.CustomMasteryEnabled = ((CheckBox)sender).Checked;

            customMasteryEnableCheckbox.Checked = AlertsController.Instance.CustomMasteryEnabled;
            selectCustomMasteryNotificationButton.Enabled = AlertsController.Instance.CustomMasteryEnabled;
            masteryEditOultineCheckbox.Enabled = AlertsController.Instance.CustomMasteryEnabled;

            AlertsController.Instance.Reset();
        }
        private void AcheivementEditOutlineCheckbox_CheckedChanged(object sender, EventArgs eventArgs)
        {
            if (((CheckBox)sender).Checked)
            {
                AlertsController.Instance.EnableAchievementEdit();
                AlertsController.Instance.SendAchievementNotification(new Achievement()
                {
                    Title = "Thrilling!!!!",
                    Description = "Color every bit of Dinosaur 2. [Must color white if leaving white]",
                    BadgeNumber = "49987",
                    Points = 1
                });
            }
            else
            {
                AlertsController.Instance.DisableAchievementEdit();
            }
        }
        private void MasteryEditOultineCheckbox_CheckedChanged(object sender, EventArgs eventArgs)
        {
            if (((CheckBox)sender).Checked)
            {
                AlertsController.Instance.EnableMasteryEdit();
            }
            else
            {
                AlertsController.Instance.DisableMasteryEdit();
            }
        }

        private void CustomNumericUpDown_ValueChanged(object sender, EventArgs eventArgs)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;

            switch (numericUpDown.Name)
            {
                case "customAchievementXNumericUpDown":
                    AlertsController.Instance.CustomAchievementX = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "customAchievementYNumericUpDown":
                    AlertsController.Instance.CustomAchievementY = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "customMasteryXNumericUpDown":
                    AlertsController.Instance.CustomMasteryX = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "customMasteryYNumericUpDown":
                    AlertsController.Instance.CustomMasteryY = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "scaleAchievementNumericUpDown":
                    AlertsController.Instance.CustomAchievementScale = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "scaleMasteryNumericUpDown":
                    AlertsController.Instance.CustomMasteryScale = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationAchievementInNumericUpDown":
                    AlertsController.Instance.CustomAchievementIn = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationAchievementOutNumericUpDown":
                    AlertsController.Instance.CustomAchievementOut = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationMasteryInNumericUpDown":
                    AlertsController.Instance.CustomMasteryIn = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationMasteryOutNumericUpDown":
                    AlertsController.Instance.CustomMasteryOut = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "titleFontOutlineNumericUpDown":
                    switch (MenuState)
                    {
                        case CustomMenuState.STATS:
                            if (StatsController.Instance.AdvancedSettingsEnabled)
                            {
                                StatsController.Instance.NameOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            }
                            else
                            {
                                StatsController.Instance.SimpleFontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            }
                            break;
                        case CustomMenuState.ALERTS:
                            if (AlertsController.Instance.AdvancedSettingsEnabled)
                            {
                                AlertsController.Instance.TitleOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            }
                            else
                            {
                                AlertsController.Instance.SimpleFontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            }
                            break;
                        case CustomMenuState.GAME_INFO:
                            if (GameInfoController.Instance.AdvancedSettingsEnabled)
                            {
                                GameInfoController.Instance.NameOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            }
                            else
                            {
                                GameInfoController.Instance.SimpleFontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            }
                            break;
                        case CustomMenuState.LAST_FIVE:
                            if (LastFiveController.Instance.AdvancedSettingsEnabled)
                            {
                                LastFiveController.Instance.TitleOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            }
                            else
                            {
                                LastFiveController.Instance.SimpleFontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            }
                            break;
                        case CustomMenuState.FOCUS:
                            if (FocusController.Instance.AdvancedSettingsEnabled)
                            {
                                FocusController.Instance.TitleOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            }
                            else
                            {
                                FocusController.Instance.SimpleFontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            }
                            break;
                    }
                    break;
                case "descriptionFontOutlineNumericUpDown":
                    switch (MenuState)
                    {
                        case CustomMenuState.STATS:
                            StatsController.Instance.ValueOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            break;
                        case CustomMenuState.ALERTS:
                            AlertsController.Instance.DescriptionOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            break;
                        case CustomMenuState.GAME_INFO:
                            GameInfoController.Instance.ValueOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            break;
                        case CustomMenuState.LAST_FIVE:
                            LastFiveController.Instance.DateOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            break;
                        case CustomMenuState.FOCUS:
                            FocusController.Instance.DescriptionOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            break;
                    }
                    break;
                case "pointsFontOutlineNumericUpDown":
                    switch (MenuState)
                    {
                        case CustomMenuState.ALERTS:
                            AlertsController.Instance.PointsOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            break;
                        case CustomMenuState.LAST_FIVE:
                            LastFiveController.Instance.PointsOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            break;
                        case CustomMenuState.FOCUS:
                            FocusController.Instance.PointsOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            break;
                    }
                    break;
                case "lineOutlineNumericUpDown":
                    switch (MenuState)
                    {
                        case CustomMenuState.ALERTS:
                            AlertsController.Instance.LineOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            break;
                        case CustomMenuState.LAST_FIVE:
                            LastFiveController.Instance.LineOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            break;
                        case CustomMenuState.FOCUS:
                            FocusController.Instance.LineOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            break;
                    }
                    break;
                case "achievementListCountNumericUpDown":
                    AchievementListController.Instance.ContainerCount = Convert.ToInt32(numericUpDown.Value);
                    break;
            }
        }
        private void SelectCustomAchievementButton_Click(object sender, EventArgs eventArgs)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                AlertsController.Instance.CustomAchievementFile = openFileDialog1.FileName;
            }
            else
            {
                if (customAchievementEnableCheckbox.Checked && string.IsNullOrEmpty(AlertsController.Instance.CustomAchievementFile))
                {
                    customAchievementEnableCheckbox.Checked = false;
                }
            }
        }
        private void SelectCustomMasteryNotificationButton_Click(object sender, EventArgs eventArgs)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                AlertsController.Instance.CustomMasteryFile = openFileDialog1.FileName;
            }
            else
            {
                if (customMasteryEnableCheckbox.Checked && string.IsNullOrEmpty(AlertsController.Instance.CustomMasteryFile))
                {
                    customMasteryEnableCheckbox.Checked = false;
                }
            }
        }

        private void CustomeAnimationSpeedUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;

            switch (numericUpDown.Name)
            {
                case "customAchievementInSpeedUpDown":
                    AlertsController.Instance.CustomAchievementInSpeed = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "customAchievementOutSpeedUpDown":
                    AlertsController.Instance.CustomAchievementOutSpeed = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "customMasteryInSpeedUpDown":
                    AlertsController.Instance.CustomMasteryInSpeed = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "customMasteryOutSpeedUpDown":
                    AlertsController.Instance.CustomMasteryOutSpeed = Convert.ToInt32(numericUpDown.Value);
                    break;
            }
        }
        private void ShowAchievementButton_Click(object sender, EventArgs eventArgs)
        {
            if (GameInfoAndProgress.Achievements != null
                && GameInfoAndProgress.Achievements.Count > 0
                && GameInfoAndProgress.Achievements[0] != null)
            {
                AlertsController.Instance.EnqueueAchievementNotifications(new List<Achievement>() { GameInfoAndProgress.Achievements[0] });
                AlertsController.Instance.RunNotifications();
            }
            else
            {
                AlertsController.Instance.EnqueueAchievementNotifications(new List<Achievement>() {
                     new Achievement()
                     {
                         Title = "Thrilling!!!!",
                         Description = "Color every bit of Dinosaur 2. [Must color white if leaving white]",
                         BadgeNumber = "49987",
                         Points = 1
                     }
                });
                AlertsController.Instance.RunNotifications();
            }
        }
        private void ShowGameMasteryButton_Click(object sender, EventArgs eventArgs)
        {
            AlertsController.Instance.EnqueueMasteryNotification(UserSummary, GameInfoAndProgress);
            AlertsController.Instance.RunNotifications();
        }
        private void SetFocusButton_Click(object sender, EventArgs e)
        {
            SetFocus();
        }
        private void MoveFocusIndexLeft(object sender, EventArgs e)
        {
            CurrentlyViewingIndex--;

            if (CurrentlyViewingIndex < 0)
            {
                CurrentlyViewingIndex = 0;
            }

            UpdateCurrentlyViewingAchievement();
        }
        private void MoveFocusIndexRight(object sender, EventArgs e)
        {
            CurrentlyViewingIndex++;

            if (CurrentlyViewingIndex >= LockedAchievements.Count)
            {
                CurrentlyViewingIndex = LockedAchievements.Count - 1;
            }

            UpdateCurrentlyViewingAchievement();
        }
        private void UpdateFocusButtons()
        {
            if (LockedAchievements.Count == 0)
            {
                focusAchievementButtonLeft.Enabled = false;
                focusAchievementButtonRight.Enabled = false;
                setFocusButton.Enabled = false;
            }
            else
            {
                setFocusButton.Enabled = true;

                if (CurrentlyViewingIndex == 0)
                {
                    focusAchievementButtonLeft.Enabled = false;
                    focusAchievementButtonRight.Enabled = LockedAchievements.Count > 1;
                }
                else if (CurrentlyViewingIndex == LockedAchievements.Count - 1)
                {
                    focusAchievementButtonLeft.Enabled = true;
                    focusAchievementButtonRight.Enabled = false;
                }
                else
                {
                    focusAchievementButtonLeft.Enabled = true;
                    focusAchievementButtonRight.Enabled = true;
                }
            }
        }
        private void ShowWindowButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            switch (button.Name)
            {
                case "openFocusWindowButton":
                    FocusController.Instance.Show();
                    break;
                case "openStatsWindowButton":
                    StatsController.Instance.Show();
                    break;
                case "openNotificationWindowButton":
                    AlertsController.Instance.Show();
                    break;
                case "openGameInfoWindowButton":
                    GameInfoController.Instance.Show();
                    break;
                case "openLastFiveWindowButton":
                    LastFiveController.Instance.Show();
                    break;
                case "openAchievementListWindowButton":
                    AchievementListController.Instance.Show();
                    break;
            }
        }
        private void CustomizeButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            switch (button.Name)
            {
                case "customizeFocusButton":
                    MenuState = MenuState.Equals(CustomMenuState.FOCUS) ? CustomMenuState.CLOSED : CustomMenuState.FOCUS;
                    break;
                case "customizeAlertsButton":
                    MenuState = MenuState.Equals(CustomMenuState.ALERTS) ? CustomMenuState.CLOSED : CustomMenuState.ALERTS;
                    break;
                case "customizeLastFiveButton":
                    MenuState = MenuState.Equals(CustomMenuState.LAST_FIVE) ? CustomMenuState.CLOSED : CustomMenuState.LAST_FIVE;
                    break;
                case "customizeGameInfoButton":
                    MenuState = MenuState.Equals(CustomMenuState.GAME_INFO) ? CustomMenuState.CLOSED : CustomMenuState.GAME_INFO;
                    break;
                case "customizeStatsButton":
                    MenuState = MenuState.Equals(CustomMenuState.STATS) ? CustomMenuState.CLOSED : CustomMenuState.STATS;
                    break;
                case "customizeAchievementListButton":
                    MenuState = MenuState.Equals(CustomMenuState.ACHIEVEMENT_LIST) ? CustomMenuState.CLOSED : CustomMenuState.ACHIEVEMENT_LIST;
                    break;
            }

            UpdateGroupBoxVisibility();
        }
        private void UpdateGroupBoxVisibility()
        {
            UpdatingVisibility = true;

            fontSettingsGroupBox.Show();

            switch (MenuState)
            {
                case CustomMenuState.CLOSED:
                    gameInfoCustomizationGroupBox.Hide();
                    customAchievementCustomizationGroupBox.Hide();
                    customMasterySettingsGroupBox.Hide();
                    statsCustomizationGroupBox.Hide();
                    fontSettingsGroupBox.Hide();

                    ClientSize = new Size(390, 473);
                    break;
                case CustomMenuState.FOCUS:
                    fontBorderEnableCheckBox.Show();
                    fontSimpleCheckbox.Show();
                    titleFontGroupBox.Show();
                    label9.Show();
                    label2.Show();

                    fontBorderEnableCheckBox.Checked = FocusController.Instance.BorderEnabled;

                    borderBackgroundGroupBox.Show();
                    borderBackgroudColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.BorderBackgroundColor);
                    windowBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.WindowBackgroundColor);
                    borderBackgroundColorButton.Enabled = true;

                    if (FocusController.Instance.AdvancedSettingsEnabled)
                    {
                        fontSimpleCheckbox.Checked = false;

                        titleFontGroupBox.Text = "Title";
                        descriptionFontGroupBox.Text = "Description";
                        lineFontGroupBox.Text = "Line";
                        pointsFontGroupBox.Text = "Points";

                        SetFontFamilyBox(titleFontFamilyComboBox, FocusController.Instance.TitleFontFamily);
                        SetFontFamilyBox(descriptionFontFamilyComboBox, FocusController.Instance.DescriptionFontFamily);
                        SetFontFamilyBox(pointsFontFamilyComboBox, FocusController.Instance.PointsFontFamily);

                        titleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.TitleColor);
                        descriptionFontColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.DescriptionColor);
                        pointsFontColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.PointsColor);
                        lineColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.LineColor);

                        titleFontOutlineColorButton.Enabled = FocusController.Instance.TitleOutlineEnabled;
                        titleFontOutlineColorPictureBox.Enabled = FocusController.Instance.TitleOutlineEnabled;
                        titleFontOutlineNumericUpDown.Enabled = FocusController.Instance.TitleOutlineEnabled;
                        titleFontOutlineCheckbox.Checked = FocusController.Instance.TitleOutlineEnabled;

                        titleFontOutlineColorPictureBox.BackColor = FocusController.Instance.TitleOutlineEnabled ? ColorTranslator.FromHtml(FocusController.Instance.TitleOutlineColor) : Color.DarkGray;
                        titleFontOutlineNumericUpDown.Value = FocusController.Instance.TitleOutlineSize;

                        descriptionFontOutlineColorButton.Enabled = FocusController.Instance.DescriptionOutlineEnabled;
                        descriptionFontOutlineColorPictureBox.Enabled = FocusController.Instance.DescriptionOutlineEnabled;
                        descriptionFontOutlineNumericUpDown.Enabled = FocusController.Instance.DescriptionOutlineEnabled;
                        descriptionFontOutlineCheckbox.Checked = FocusController.Instance.DescriptionOutlineEnabled;

                        descriptionFontOutlineColorPictureBox.BackColor = FocusController.Instance.DescriptionOutlineEnabled ? ColorTranslator.FromHtml(FocusController.Instance.DescriptionOutlineColor) : Color.DarkGray;
                        descriptionFontOutlineNumericUpDown.Value = FocusController.Instance.DescriptionOutlineSize;

                        pointsFontOutlineColorButton.Enabled = FocusController.Instance.PointsOutlineEnabled;
                        pointsFontOutlineColorPictureBox.Enabled = FocusController.Instance.PointsOutlineEnabled;
                        pointsFontOutlineNumericUpDown.Enabled = FocusController.Instance.PointsOutlineEnabled;
                        pointsFontOutlineCheckbox.Checked = FocusController.Instance.PointsOutlineEnabled;

                        pointsFontOutlineColorPictureBox.BackColor = FocusController.Instance.PointsOutlineEnabled ? ColorTranslator.FromHtml(FocusController.Instance.PointsOutlineColor) : Color.DarkGray;
                        pointsFontOutlineNumericUpDown.Value = FocusController.Instance.PointsOutlineSize;

                        lineOutlineColorButton.Enabled = FocusController.Instance.LineOutlineEnabled;
                        lineOutlineColorPictureBox.Enabled = FocusController.Instance.LineOutlineEnabled;
                        lineOutlineNumericUpDown.Enabled = FocusController.Instance.LineOutlineEnabled;
                        lineOutlineCheckbox.Checked = FocusController.Instance.LineOutlineEnabled;

                        lineOutlineColorPictureBox.BackColor = FocusController.Instance.LineOutlineEnabled ? ColorTranslator.FromHtml(FocusController.Instance.LineOutlineColor) : Color.DarkGray;
                        lineOutlineNumericUpDown.Value = FocusController.Instance.LineOutlineSize;

                        descriptionFontGroupBox.Show();
                        lineFontGroupBox.Show();
                        pointsFontGroupBox.Show();
                    }
                    else
                    {
                        fontSimpleCheckbox.Checked = true;

                        titleFontGroupBox.Text = "All";

                        SetFontFamilyBox(titleFontFamilyComboBox, FocusController.Instance.SimpleFontFamily);

                        titleFontOutlineCheckbox.Checked = FocusController.Instance.SimpleFontOutlineEnabled;
                        titleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.SimpleFontColor);

                        descriptionFontGroupBox.Hide();
                        lineFontGroupBox.Hide();
                        pointsFontGroupBox.Hide();

                        titleFontOutlineNumericUpDown.Enabled = FocusController.Instance.SimpleFontOutlineEnabled;
                        titleFontOutlineColorPictureBox.Enabled = FocusController.Instance.SimpleFontOutlineEnabled;
                        titleFontOutlineColorButton.Enabled = FocusController.Instance.SimpleFontOutlineEnabled;

                        titleFontOutlineNumericUpDown.Value = FocusController.Instance.SimpleFontOutlineSize;
                        titleFontOutlineColorPictureBox.BackColor = FocusController.Instance.SimpleFontOutlineEnabled ? ColorTranslator.FromHtml(FocusController.Instance.SimpleFontOutlineColor) : Color.DarkGray;
                    }

                    gameInfoCustomizationGroupBox.Hide();
                    customAchievementCustomizationGroupBox.Hide();
                    customMasterySettingsGroupBox.Hide();
                    statsCustomizationGroupBox.Hide();

                    ClientSize = new Size(640, 473);
                    break;
                case CustomMenuState.LAST_FIVE:
                    fontBorderEnableCheckBox.Show();
                    fontSimpleCheckbox.Show();
                    titleFontGroupBox.Show();
                    label9.Show();
                    label2.Show();

                    fontBorderEnableCheckBox.Checked = LastFiveController.Instance.BorderEnabled;

                    borderBackgroundGroupBox.Show();
                    borderBackgroudColorPictureBox.BackColor = ColorTranslator.FromHtml(LastFiveController.Instance.BorderBackgroundColor);
                    windowBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(LastFiveController.Instance.WindowBackgroundColor);
                    borderBackgroundColorButton.Enabled = true;

                    if (LastFiveController.Instance.AdvancedSettingsEnabled)
                    {
                        fontSimpleCheckbox.Checked = false;

                        titleFontGroupBox.Text = "Title";
                        descriptionFontGroupBox.Text = "Date";
                        lineFontGroupBox.Text = "Line";
                        pointsFontGroupBox.Text = "Points";

                        SetFontFamilyBox(titleFontFamilyComboBox, LastFiveController.Instance.TitleFontFamily);
                        SetFontFamilyBox(descriptionFontFamilyComboBox, LastFiveController.Instance.DateFontFamily);
                        SetFontFamilyBox(pointsFontFamilyComboBox, LastFiveController.Instance.PointsFontFamily);

                        titleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(LastFiveController.Instance.TitleColor);
                        descriptionFontColorPictureBox.BackColor = ColorTranslator.FromHtml(LastFiveController.Instance.DateColor);
                        pointsFontColorPictureBox.BackColor = ColorTranslator.FromHtml(LastFiveController.Instance.PointsColor);
                        lineColorPictureBox.BackColor = ColorTranslator.FromHtml(LastFiveController.Instance.LineColor);

                        titleFontOutlineColorButton.Enabled = LastFiveController.Instance.TitleOutlineEnabled;
                        titleFontOutlineColorPictureBox.Enabled = LastFiveController.Instance.TitleOutlineEnabled;
                        titleFontOutlineNumericUpDown.Enabled = LastFiveController.Instance.TitleOutlineEnabled;
                        titleFontOutlineCheckbox.Checked = LastFiveController.Instance.TitleOutlineEnabled;

                        titleFontOutlineColorPictureBox.BackColor = LastFiveController.Instance.TitleOutlineEnabled ? ColorTranslator.FromHtml(LastFiveController.Instance.TitleOutlineColor) : Color.DarkGray;
                        titleFontOutlineNumericUpDown.Value = LastFiveController.Instance.TitleOutlineSize;

                        descriptionFontOutlineColorButton.Enabled = LastFiveController.Instance.DateOutlineEnabled;
                        descriptionFontOutlineColorPictureBox.Enabled = LastFiveController.Instance.DateOutlineEnabled;
                        descriptionFontOutlineNumericUpDown.Enabled = LastFiveController.Instance.DateOutlineEnabled;
                        descriptionFontOutlineCheckbox.Checked = LastFiveController.Instance.DateOutlineEnabled;

                        descriptionFontOutlineColorPictureBox.BackColor = LastFiveController.Instance.DateOutlineEnabled ? ColorTranslator.FromHtml(LastFiveController.Instance.DateOutlineColor) : Color.DarkGray;
                        descriptionFontOutlineNumericUpDown.Value = LastFiveController.Instance.DateOutlineSize;

                        pointsFontOutlineColorButton.Enabled = LastFiveController.Instance.PointsOutlineEnabled;
                        pointsFontOutlineColorPictureBox.Enabled = LastFiveController.Instance.PointsOutlineEnabled;
                        pointsFontOutlineNumericUpDown.Enabled = LastFiveController.Instance.PointsOutlineEnabled;
                        pointsFontOutlineCheckbox.Checked = LastFiveController.Instance.PointsOutlineEnabled;

                        pointsFontOutlineColorPictureBox.BackColor = LastFiveController.Instance.PointsOutlineEnabled ? ColorTranslator.FromHtml(LastFiveController.Instance.PointsOutlineColor) : Color.DarkGray;
                        pointsFontOutlineNumericUpDown.Value = LastFiveController.Instance.PointsOutlineSize;

                        lineOutlineColorButton.Enabled = LastFiveController.Instance.LineOutlineEnabled;
                        lineOutlineColorPictureBox.Enabled = LastFiveController.Instance.LineOutlineEnabled;
                        lineOutlineNumericUpDown.Enabled = LastFiveController.Instance.LineOutlineEnabled;
                        lineOutlineCheckbox.Checked = LastFiveController.Instance.LineOutlineEnabled;

                        lineOutlineColorPictureBox.BackColor = LastFiveController.Instance.LineOutlineEnabled ? ColorTranslator.FromHtml(LastFiveController.Instance.LineOutlineColor) : Color.DarkGray;
                        lineOutlineNumericUpDown.Value = LastFiveController.Instance.LineOutlineSize;

                        descriptionFontGroupBox.Show();
                        lineFontGroupBox.Show();
                        pointsFontGroupBox.Show();
                    }
                    else
                    {
                        fontSimpleCheckbox.Checked = true;

                        titleFontGroupBox.Text = "All";

                        SetFontFamilyBox(titleFontFamilyComboBox, LastFiveController.Instance.SimpleFontFamily);

                        titleFontOutlineCheckbox.Checked = LastFiveController.Instance.SimpleFontOutlineEnabled;
                        titleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(LastFiveController.Instance.SimpleFontColor);

                        descriptionFontGroupBox.Hide();
                        lineFontGroupBox.Hide();
                        pointsFontGroupBox.Hide();

                        titleFontOutlineNumericUpDown.Enabled = LastFiveController.Instance.SimpleFontOutlineEnabled;
                        titleFontOutlineColorPictureBox.Enabled = LastFiveController.Instance.SimpleFontOutlineEnabled;
                        titleFontOutlineColorButton.Enabled = LastFiveController.Instance.SimpleFontOutlineEnabled;

                        titleFontOutlineNumericUpDown.Value = LastFiveController.Instance.SimpleFontOutlineSize;
                        titleFontOutlineColorPictureBox.BackColor = LastFiveController.Instance.SimpleFontOutlineEnabled ? ColorTranslator.FromHtml(LastFiveController.Instance.SimpleFontOutlineColor) : Color.DarkGray;
                    }

                    statsCustomizationGroupBox.Hide();
                    gameInfoCustomizationGroupBox.Hide();
                    customAchievementCustomizationGroupBox.Hide();
                    customMasterySettingsGroupBox.Hide();

                    ClientSize = new Size(641, 473);
                    break;
                case CustomMenuState.GAME_INFO:
                    fontBorderEnableCheckBox.Hide();
                    fontSimpleCheckbox.Show();
                    titleFontGroupBox.Show();
                    label9.Hide();
                    label2.Show();

                    borderBackgroundGroupBox.Hide();
                    windowBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoController.Instance.WindowBackgroundColor);

                    if (GameInfoController.Instance.AdvancedSettingsEnabled)
                    {
                        fontSimpleCheckbox.Checked = false;

                        titleFontGroupBox.Text = "Name";
                        descriptionFontGroupBox.Text = "Value";

                        SetFontFamilyBox(titleFontFamilyComboBox, GameInfoController.Instance.NameFontFamily);
                        SetFontFamilyBox(descriptionFontFamilyComboBox, GameInfoController.Instance.ValueFontFamily);

                        titleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoController.Instance.NameColor);
                        descriptionFontColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoController.Instance.ValueColor);

                        titleFontOutlineColorButton.Enabled = GameInfoController.Instance.NameOutlineEnabled;
                        titleFontOutlineColorPictureBox.Enabled = GameInfoController.Instance.NameOutlineEnabled;
                        titleFontOutlineNumericUpDown.Enabled = GameInfoController.Instance.NameOutlineEnabled;
                        titleFontOutlineCheckbox.Checked = GameInfoController.Instance.NameOutlineEnabled;

                        titleFontOutlineColorPictureBox.BackColor = GameInfoController.Instance.NameOutlineEnabled ? ColorTranslator.FromHtml(GameInfoController.Instance.NameOutlineColor) : Color.DarkGray;
                        titleFontOutlineNumericUpDown.Value = GameInfoController.Instance.NameOutlineSize;

                        descriptionFontOutlineColorButton.Enabled = GameInfoController.Instance.ValueOutlineEnabled;
                        descriptionFontOutlineColorPictureBox.Enabled = GameInfoController.Instance.ValueOutlineEnabled;
                        descriptionFontOutlineNumericUpDown.Enabled = GameInfoController.Instance.ValueOutlineEnabled;
                        descriptionFontOutlineCheckbox.Checked = GameInfoController.Instance.ValueOutlineEnabled;

                        descriptionFontOutlineColorPictureBox.BackColor = GameInfoController.Instance.ValueOutlineEnabled ? ColorTranslator.FromHtml(GameInfoController.Instance.ValueOutlineColor) : Color.DarkGray;
                        descriptionFontOutlineNumericUpDown.Value = GameInfoController.Instance.ValueOutlineSize;

                        descriptionFontGroupBox.Show();
                        lineFontGroupBox.Hide();
                        pointsFontGroupBox.Hide();
                    }
                    else
                    {
                        fontSimpleCheckbox.Checked = true;

                        titleFontGroupBox.Text = "All";

                        SetFontFamilyBox(titleFontFamilyComboBox, GameInfoController.Instance.SimpleFontFamily);

                        titleFontOutlineCheckbox.Checked = GameInfoController.Instance.SimpleFontOutlineEnabled;
                        titleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoController.Instance.SimpleFontColor);

                        descriptionFontGroupBox.Hide();
                        lineFontGroupBox.Hide();
                        pointsFontGroupBox.Hide();

                        titleFontOutlineNumericUpDown.Enabled = GameInfoController.Instance.SimpleFontOutlineEnabled;
                        titleFontOutlineColorPictureBox.Enabled = GameInfoController.Instance.SimpleFontOutlineEnabled;
                        titleFontOutlineColorButton.Enabled = GameInfoController.Instance.SimpleFontOutlineEnabled;

                        titleFontOutlineNumericUpDown.Value = GameInfoController.Instance.SimpleFontOutlineSize;
                        titleFontOutlineColorPictureBox.BackColor = GameInfoController.Instance.SimpleFontOutlineEnabled ? ColorTranslator.FromHtml(GameInfoController.Instance.SimpleFontOutlineColor) : Color.DarkGray;
                    }

                    titleEnableCheckBox.Checked = GameInfoController.Instance.TitleEnabled;
                    developerEnableCheckBox.Checked = GameInfoController.Instance.DeveloperEnabled;
                    publisherEnableCheckBox.Checked = GameInfoController.Instance.PublisherEnabled;
                    genreEnableCheckBox.Checked = GameInfoController.Instance.GenreEnabled;
                    consoleEnableCheckBox.Checked = GameInfoController.Instance.ConsoleEnabled;
                    releasedDateEnableCheckBox.Checked = GameInfoController.Instance.ReleasedDateEnabled;

                    gameInfoTitleOverrideTextBox.Text = GameInfoController.Instance.TitleName;
                    gameInfoDeveloperOverrideTextBox.Text = GameInfoController.Instance.DeveloperName;
                    gameInfoPublisherOverrideTextBox.Text = GameInfoController.Instance.PublisherName;
                    gameInfoGenreOverrideTextBox.Text = GameInfoController.Instance.GenreName;
                    gameInfoConsoleOverrideTextBox.Text = GameInfoController.Instance.ConsoleName;
                    gameInfoReleaseDateOverrideTextBox.Text = GameInfoController.Instance.ReleasedDateName;

                    gameInfoCustomizationGroupBox.Show();
                    gameInfoCustomizationGroupBox.Location = new Point(641, 12);

                    customAchievementCustomizationGroupBox.Hide();
                    customMasterySettingsGroupBox.Hide();
                    statsCustomizationGroupBox.Hide();

                    ClientSize = new Size(1043, 473);
                    break;
                case CustomMenuState.STATS:
                    fontBorderEnableCheckBox.Hide();
                    fontSimpleCheckbox.Show();
                    titleFontGroupBox.Show();
                    label9.Hide();
                    label2.Show();

                    borderBackgroundGroupBox.Hide();
                    windowBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(StatsController.Instance.WindowBackgroundColor);

                    if (StatsController.Instance.AdvancedSettingsEnabled)
                    {
                        fontSimpleCheckbox.Checked = false;

                        titleFontGroupBox.Text = "Name";
                        descriptionFontGroupBox.Text = "Value";

                        SetFontFamilyBox(titleFontFamilyComboBox, StatsController.Instance.NameFontFamily);
                        SetFontFamilyBox(descriptionFontFamilyComboBox, StatsController.Instance.ValueFontFamily);

                        titleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(StatsController.Instance.NameColor);
                        descriptionFontColorPictureBox.BackColor = ColorTranslator.FromHtml(StatsController.Instance.ValueColor);

                        titleFontOutlineColorButton.Enabled = StatsController.Instance.NameOutlineEnabled;
                        titleFontOutlineColorPictureBox.Enabled = StatsController.Instance.NameOutlineEnabled;
                        titleFontOutlineNumericUpDown.Enabled = StatsController.Instance.NameOutlineEnabled;
                        titleFontOutlineCheckbox.Checked = StatsController.Instance.NameOutlineEnabled;

                        titleFontOutlineColorPictureBox.BackColor = StatsController.Instance.NameOutlineEnabled ? ColorTranslator.FromHtml(StatsController.Instance.NameOutlineColor) : Color.DarkGray;
                        titleFontOutlineNumericUpDown.Value = StatsController.Instance.NameOutlineSize;

                        descriptionFontOutlineColorButton.Enabled = StatsController.Instance.ValueOutlineEnabled;
                        descriptionFontOutlineColorPictureBox.Enabled = StatsController.Instance.ValueOutlineEnabled;
                        descriptionFontOutlineNumericUpDown.Enabled = StatsController.Instance.ValueOutlineEnabled;
                        descriptionFontOutlineCheckbox.Checked = StatsController.Instance.ValueOutlineEnabled;

                        descriptionFontOutlineColorPictureBox.BackColor = StatsController.Instance.ValueOutlineEnabled ? ColorTranslator.FromHtml(StatsController.Instance.ValueOutlineColor) : Color.DarkGray;
                        descriptionFontOutlineNumericUpDown.Value = StatsController.Instance.ValueOutlineSize;

                        switch (StatsController.Instance.DividerCharacter)
                        {
                            case "/":
                                statsRadioButtonDot.Checked = false;
                                statsRadioButtonSemicolon.Checked = false;
                                statsRadioButtonBackslash.Checked = true;
                                break;
                            case ":":
                                statsRadioButtonDot.Checked = false;
                                statsRadioButtonBackslash.Checked = false;
                                statsRadioButtonSemicolon.Checked = true;
                                break;
                            case ".":
                                statsRadioButtonSemicolon.Checked = false;
                                statsRadioButtonBackslash.Checked = false;
                                statsRadioButtonDot.Checked = true;
                                break;
                        }

                        descriptionFontGroupBox.Show();
                        lineFontGroupBox.Hide();
                        pointsFontGroupBox.Hide();
                    }
                    else
                    {
                        fontSimpleCheckbox.Checked = true;

                        titleFontGroupBox.Text = "All";

                        SetFontFamilyBox(titleFontFamilyComboBox, StatsController.Instance.SimpleFontFamily);

                        titleFontOutlineCheckbox.Checked = StatsController.Instance.SimpleFontOutlineEnabled;
                        titleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(StatsController.Instance.SimpleFontColor);

                        descriptionFontGroupBox.Hide();
                        lineFontGroupBox.Hide();
                        pointsFontGroupBox.Hide();

                        titleFontOutlineNumericUpDown.Enabled = StatsController.Instance.SimpleFontOutlineEnabled;
                        titleFontOutlineColorPictureBox.Enabled = StatsController.Instance.SimpleFontOutlineEnabled;
                        titleFontOutlineColorButton.Enabled = StatsController.Instance.SimpleFontOutlineEnabled;

                        titleFontOutlineNumericUpDown.Value = StatsController.Instance.SimpleFontOutlineSize;
                        titleFontOutlineColorPictureBox.BackColor = StatsController.Instance.SimpleFontOutlineEnabled ? ColorTranslator.FromHtml(StatsController.Instance.SimpleFontOutlineColor) : Color.DarkGray;
                    }

                    rankEnableCheckBox.Checked = StatsController.Instance.RankEnabled;
                    awardsEnableCheckBox.Checked = StatsController.Instance.AwardsEnabled;
                    pointsEnableCheckBox.Checked = StatsController.Instance.PointsEnabled;
                    truePointsEnableCheckBox.Checked = StatsController.Instance.TruePointsEnabled;
                    ratioEnableCheckBox.Checked = StatsController.Instance.RatioEnabled;
                    truePointsEnableCheckBox.Checked = StatsController.Instance.TruePointsEnabled;
                    gameAchievementsEnableCheckBox.Checked = StatsController.Instance.GameAchievementsEnabled;
                    gamePointsEnableCheckBox.Checked = StatsController.Instance.GamePointsEnabled;
                    gameTruePointsEnableCheckBox.Checked = StatsController.Instance.GameTruePointsEnabled;
                    completedEnableCheckBox.Checked = StatsController.Instance.CompletedEnabled;
                    gameRatioEnableCheckBox.Checked = StatsController.Instance.GameRatioEnabled;

                    statsRankOverrideTextBox.Text = StatsController.Instance.RankName;
                    statsAwardsOverrideTextBox.Text = StatsController.Instance.AwardsName;
                    statsPointsOverrideTextBox.Text = StatsController.Instance.PointsName;
                    statsTruePointsOverrideTextBox.Text = StatsController.Instance.TruePointsName;
                    statsRatioOverrideTextBox.Text = StatsController.Instance.RatioName;
                    statsGameAchievementsOverrideTextBox.Text = StatsController.Instance.GameAchievementsName;
                    statsGamePointsOverrideTextBox.Text = StatsController.Instance.GamePointsName;
                    statsGameTruePointsOverrideTextBox.Text = StatsController.Instance.GameTruePointsName;
                    statsCompletedOverrideTextBox.Text = StatsController.Instance.CompletedName;
                    statsGameRatioOverrideTextBox.Text = StatsController.Instance.GameRatioName;

                    gameInfoCustomizationGroupBox.Hide();
                    customAchievementCustomizationGroupBox.Hide();
                    customMasterySettingsGroupBox.Hide();

                    statsCustomizationGroupBox.Show();
                    statsCustomizationGroupBox.Location = new Point(641, 12);

                    ClientSize = new Size(1043, 473);
                    break;
                case CustomMenuState.ALERTS:
                    fontBorderEnableCheckBox.Show();
                    fontSimpleCheckbox.Show();
                    titleFontGroupBox.Show();
                    label9.Show();
                    label2.Show();

                    fontBorderEnableCheckBox.Checked = AlertsController.Instance.BorderEnabled;

                    borderBackgroundGroupBox.Show();
                    borderBackgroudColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.BorderBackgroundColor);
                    windowBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.WindowBackgroundColor);

                    if (AlertsController.Instance.AdvancedSettingsEnabled)
                    {
                        fontSimpleCheckbox.Checked = false;

                        titleFontGroupBox.Text = "Title";
                        descriptionFontGroupBox.Text = "Description";
                        lineFontGroupBox.Text = "Line";
                        pointsFontGroupBox.Text = "Points";

                        SetFontFamilyBox(titleFontFamilyComboBox, AlertsController.Instance.TitleFontFamily);
                        SetFontFamilyBox(descriptionFontFamilyComboBox, AlertsController.Instance.DescriptionFontFamily);
                        SetFontFamilyBox(pointsFontFamilyComboBox, AlertsController.Instance.PointsFontFamily);

                        titleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.TitleColor);
                        descriptionFontColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.DescriptionColor);
                        pointsFontColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.PointsColor);
                        lineColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.LineColor);

                        titleFontOutlineColorButton.Enabled = AlertsController.Instance.TitleOutlineEnabled;
                        titleFontOutlineColorPictureBox.Enabled = AlertsController.Instance.TitleOutlineEnabled;
                        titleFontOutlineNumericUpDown.Enabled = AlertsController.Instance.TitleOutlineEnabled;
                        titleFontOutlineCheckbox.Checked = AlertsController.Instance.TitleOutlineEnabled;

                        titleFontOutlineColorPictureBox.BackColor = AlertsController.Instance.TitleOutlineEnabled ? ColorTranslator.FromHtml(AlertsController.Instance.TitleOutlineColor) : Color.DarkGray;
                        titleFontOutlineNumericUpDown.Value = AlertsController.Instance.TitleOutlineSize;

                        descriptionFontOutlineColorButton.Enabled = AlertsController.Instance.DescriptionOutlineEnabled;
                        descriptionFontOutlineColorPictureBox.Enabled = AlertsController.Instance.DescriptionOutlineEnabled;
                        descriptionFontOutlineNumericUpDown.Enabled = AlertsController.Instance.DescriptionOutlineEnabled;
                        descriptionFontOutlineCheckbox.Checked = AlertsController.Instance.DescriptionOutlineEnabled;

                        descriptionFontOutlineColorPictureBox.BackColor = AlertsController.Instance.DescriptionOutlineEnabled ? ColorTranslator.FromHtml(AlertsController.Instance.DescriptionOutlineColor) : Color.DarkGray;
                        descriptionFontOutlineNumericUpDown.Value = AlertsController.Instance.DescriptionOutlineSize;

                        pointsFontOutlineColorButton.Enabled = AlertsController.Instance.PointsOutlineEnabled;
                        pointsFontOutlineColorPictureBox.Enabled = AlertsController.Instance.PointsOutlineEnabled;
                        pointsFontOutlineNumericUpDown.Enabled = AlertsController.Instance.PointsOutlineEnabled;
                        pointsFontOutlineCheckbox.Checked = AlertsController.Instance.PointsOutlineEnabled;

                        pointsFontOutlineColorPictureBox.BackColor = AlertsController.Instance.PointsOutlineEnabled ? ColorTranslator.FromHtml(AlertsController.Instance.PointsOutlineColor) : Color.DarkGray;
                        pointsFontOutlineNumericUpDown.Value = AlertsController.Instance.PointsOutlineSize;

                        lineOutlineColorButton.Enabled = AlertsController.Instance.LineOutlineEnabled;
                        lineOutlineColorPictureBox.Enabled = AlertsController.Instance.LineOutlineEnabled;
                        lineOutlineNumericUpDown.Enabled = AlertsController.Instance.LineOutlineEnabled;
                        lineOutlineCheckbox.Checked = AlertsController.Instance.LineOutlineEnabled;

                        lineOutlineColorPictureBox.BackColor = AlertsController.Instance.LineOutlineEnabled ? ColorTranslator.FromHtml(AlertsController.Instance.LineOutlineColor) : Color.DarkGray;
                        lineOutlineNumericUpDown.Value = AlertsController.Instance.LineOutlineSize;

                        descriptionFontGroupBox.Show();
                        lineFontGroupBox.Show();
                        pointsFontGroupBox.Show();
                    }
                    else
                    {
                        fontSimpleCheckbox.Checked = true;

                        titleFontGroupBox.Text = "All";

                        SetFontFamilyBox(titleFontFamilyComboBox, AlertsController.Instance.SimpleFontFamily);

                        titleFontOutlineCheckbox.Checked = AlertsController.Instance.SimpleFontOutlineEnabled;
                        titleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.SimpleFontColor);

                        descriptionFontGroupBox.Hide();
                        lineFontGroupBox.Hide();
                        pointsFontGroupBox.Hide();

                        titleFontOutlineNumericUpDown.Enabled = AlertsController.Instance.SimpleFontOutlineEnabled;
                        titleFontOutlineColorPictureBox.Enabled = AlertsController.Instance.SimpleFontOutlineEnabled;
                        titleFontOutlineColorButton.Enabled = AlertsController.Instance.SimpleFontOutlineEnabled;

                        titleFontOutlineNumericUpDown.Value = AlertsController.Instance.SimpleFontOutlineSize;
                        titleFontOutlineColorPictureBox.BackColor = AlertsController.Instance.SimpleFontOutlineEnabled ? ColorTranslator.FromHtml(AlertsController.Instance.SimpleFontOutlineColor) : Color.DarkGray;
                    }

                    gameInfoCustomizationGroupBox.Hide();
                    customAchievementCustomizationGroupBox.Hide();
                    customMasterySettingsGroupBox.Hide();
                    statsCustomizationGroupBox.Hide();

                    customAchievementCustomizationGroupBox.Show();
                    customMasterySettingsGroupBox.Show();

                    customAchievementCustomizationGroupBox.Location = new Point(641, 12);
                    customMasterySettingsGroupBox.Location = new Point(842, 12);

                    ClientSize = new Size(1043, 473);
                    break;
                case CustomMenuState.ACHIEVEMENT_LIST:
                    fontBorderEnableCheckBox.Hide();
                    fontSimpleCheckbox.Hide();
                    label9.Hide();
                    label2.Hide();

                    windowBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(AchievementListController.Instance.WindowBackgroundColor);
                    borderBackgroundGroupBox.Hide();
                    borderBackgroudColorPictureBox.BackColor = ColorTranslator.FromHtml(AchievementListController.Instance.BorderBackgroundColor);

                    titleFontGroupBox.Hide();
                    descriptionFontGroupBox.Hide();
                    lineFontGroupBox.Hide();
                    pointsFontGroupBox.Hide();

                    gameInfoCustomizationGroupBox.Hide();
                    customAchievementCustomizationGroupBox.Hide();
                    customMasterySettingsGroupBox.Hide();
                    statsCustomizationGroupBox.Hide();
                    customAchievementCustomizationGroupBox.Hide();
                    customMasterySettingsGroupBox.Hide();

                    ClientSize = new Size(641, 473);
                    break;
            }

            UpdatingVisibility = false;
        }
        private void SetFontFamilyBox(ComboBox comboBox, FontFamily fontFamily)
        {
            comboBox.Items.Clear();

            FontFamily[] familyArray = FontFamily.Families.ToArray();

            foreach (FontFamily fontFamilyEntity in familyArray)
            {
                comboBox.Items.Add(fontFamilyEntity.Name);
            }
            comboBox.SelectedIndex = Array.FindIndex(familyArray, row => row.Name == fontFamily.Name);
        }
        private void FontColorButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                titleFontColorPictureBox.BackColor = colorDialog1.Color;

                switch (button.Name)
                {
                    case "titleFontColorButton":
                        switch (MenuState)
                        {
                            case CustomMenuState.STATS:
                                if (StatsController.Instance.AdvancedSettingsEnabled)
                                {
                                    StatsController.Instance.NameColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                else
                                {
                                    StatsController.Instance.SimpleFontColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                break;
                            case CustomMenuState.ALERTS:
                                if (AlertsController.Instance.AdvancedSettingsEnabled)
                                {
                                    AlertsController.Instance.TitleColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                else
                                {
                                    AlertsController.Instance.SimpleFontColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                break;
                            case CustomMenuState.GAME_INFO:
                                if (GameInfoController.Instance.AdvancedSettingsEnabled)
                                {
                                    GameInfoController.Instance.NameColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                else
                                {
                                    GameInfoController.Instance.SimpleFontColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                break;
                            case CustomMenuState.LAST_FIVE:
                                if (LastFiveController.Instance.AdvancedSettingsEnabled)
                                {
                                    LastFiveController.Instance.TitleColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                else
                                {
                                    LastFiveController.Instance.SimpleFontColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                break;
                            case CustomMenuState.FOCUS:
                                if (FocusController.Instance.AdvancedSettingsEnabled)
                                {
                                    FocusController.Instance.TitleColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                else
                                {
                                    FocusController.Instance.SimpleFontColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                break;
                        }
                        break;
                    case "titleFontOutlineColorButton":
                        switch (MenuState)
                        {
                            case CustomMenuState.STATS:
                                if (StatsController.Instance.AdvancedSettingsEnabled)
                                {
                                    StatsController.Instance.NameOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                else
                                {
                                    StatsController.Instance.SimpleFontOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                break;
                            case CustomMenuState.ALERTS:
                                if (AlertsController.Instance.AdvancedSettingsEnabled)
                                {
                                    AlertsController.Instance.TitleOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                else
                                {
                                    AlertsController.Instance.SimpleFontOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                break;
                            case CustomMenuState.GAME_INFO:
                                if (GameInfoController.Instance.AdvancedSettingsEnabled)
                                {
                                    GameInfoController.Instance.NameOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                else
                                {
                                    GameInfoController.Instance.SimpleFontOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                break;
                            case CustomMenuState.LAST_FIVE:
                                if (LastFiveController.Instance.AdvancedSettingsEnabled)
                                {
                                    LastFiveController.Instance.TitleOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                else
                                {
                                    LastFiveController.Instance.SimpleFontColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                break;
                            case CustomMenuState.FOCUS:
                                if (FocusController.Instance.AdvancedSettingsEnabled)
                                {
                                    FocusController.Instance.TitleOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                else
                                {
                                    FocusController.Instance.SimpleFontOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                break;
                        }
                        break;
                    case "descriptionFontColorButton":
                        switch (MenuState)
                        {
                            case CustomMenuState.STATS:
                                StatsController.Instance.ValueColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.ALERTS:
                                AlertsController.Instance.DescriptionColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.GAME_INFO:
                                GameInfoController.Instance.ValueColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.LAST_FIVE:
                                LastFiveController.Instance.DateColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.FOCUS:
                                FocusController.Instance.DescriptionColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                        }
                        break;
                    case "descriptionFontOutlineColorButton":
                        switch (MenuState)
                        {
                            case CustomMenuState.STATS:
                                StatsController.Instance.ValueOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.ALERTS:
                                AlertsController.Instance.DescriptionOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.GAME_INFO:
                                GameInfoController.Instance.ValueOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.LAST_FIVE:
                                LastFiveController.Instance.DateOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.FOCUS:
                                FocusController.Instance.DescriptionOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                        }
                        break;
                    case "pointsFontColorButton":
                        switch (MenuState)
                        {
                            case CustomMenuState.ALERTS:
                                AlertsController.Instance.PointsColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.LAST_FIVE:
                                LastFiveController.Instance.PointsColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.FOCUS:
                                FocusController.Instance.PointsColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                        }
                        break;
                    case "pointsFontOutlineColorButton":
                        switch (MenuState)
                        {
                            case CustomMenuState.ALERTS:
                                AlertsController.Instance.PointsOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.LAST_FIVE:
                                LastFiveController.Instance.PointsOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.FOCUS:
                                FocusController.Instance.PointsOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                        }
                        break;
                    case "lineColorButton":
                        switch (MenuState)
                        {
                            case CustomMenuState.ALERTS:
                                AlertsController.Instance.LineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.LAST_FIVE:
                                LastFiveController.Instance.LineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.FOCUS:
                                FocusController.Instance.LineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                        }
                        break;
                    case "lineOutlineColorButton":
                        switch (MenuState)
                        {
                            case CustomMenuState.ALERTS:
                                AlertsController.Instance.LineOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.LAST_FIVE:
                                LastFiveController.Instance.LineOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.FOCUS:
                                FocusController.Instance.LineOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                        }
                        break;
                }
                UpdateGroupBoxVisibility();
            }
        }
        private void FontFamilyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FontFamily[] familyArray = FontFamily.Families.ToArray();
            ComboBox comboBox = sender as ComboBox;

            switch (comboBox.Name)
            {
                case "titleFontFamilyComboBox":
                    switch (MenuState)
                    {
                        case CustomMenuState.STATS:
                            if (StatsController.Instance.AdvancedSettingsEnabled)
                            {
                                StatsController.Instance.NameFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            }
                            else
                            {
                                StatsController.Instance.SimpleFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            }
                            break;
                        case CustomMenuState.ALERTS:
                            if (AlertsController.Instance.AdvancedSettingsEnabled)
                            {
                                AlertsController.Instance.TitleFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            }
                            else
                            {
                                AlertsController.Instance.SimpleFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            }
                            break;
                        case CustomMenuState.GAME_INFO:
                            if (GameInfoController.Instance.AdvancedSettingsEnabled)
                            {
                                GameInfoController.Instance.NameFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            }
                            else
                            {
                                GameInfoController.Instance.SimpleFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            }
                            break;
                        case CustomMenuState.LAST_FIVE:
                            if (LastFiveController.Instance.AdvancedSettingsEnabled)
                            {
                                LastFiveController.Instance.TitleFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            }
                            else
                            {
                                LastFiveController.Instance.SimpleFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            }
                            break;
                        case CustomMenuState.FOCUS:
                            if (FocusController.Instance.AdvancedSettingsEnabled)
                            {
                                FocusController.Instance.TitleFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            }
                            else
                            {
                                FocusController.Instance.SimpleFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            }
                            break;
                    }
                    break;
                case "descriptionFontFamilyComboBox":
                    switch (MenuState)
                    {
                        case CustomMenuState.STATS:
                            StatsController.Instance.ValueFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            break;
                        case CustomMenuState.ALERTS:
                            AlertsController.Instance.DescriptionFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            break;
                        case CustomMenuState.GAME_INFO:
                            GameInfoController.Instance.ValueFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            break;
                        case CustomMenuState.LAST_FIVE:
                            LastFiveController.Instance.DateFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            break;
                        case CustomMenuState.FOCUS:
                            FocusController.Instance.DescriptionFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            break;
                    }
                    break;
                case "pointsFontFamilyComboBox":
                    switch (MenuState)
                    {
                        case CustomMenuState.ALERTS:
                            AlertsController.Instance.PointsFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            break;
                        case CustomMenuState.LAST_FIVE:
                            LastFiveController.Instance.PointsFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            break;
                        case CustomMenuState.FOCUS:
                            FocusController.Instance.PointsFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            break;
                    }
                    break;
            }
        }
        private void NotificationAnimationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            switch (comboBox.Name)
            {
                case "notificationsAchievementAnimationInComboBox":
                    switch ((string)(sender as ComboBox).SelectedItem)
                    {
                        case "DOWN":
                            AlertsController.Instance.AchievementAnimationIn = AnimationDirection.DOWN;
                            break;
                        case "LEFT":
                            AlertsController.Instance.AchievementAnimationIn = AnimationDirection.LEFT;
                            break;
                        case "RIGHT":
                            AlertsController.Instance.AchievementAnimationIn = AnimationDirection.RIGHT;
                            break;
                        case "UP":
                            AlertsController.Instance.AchievementAnimationIn = AnimationDirection.UP;
                            break;
                        default:
                            AlertsController.Instance.AchievementAnimationIn = AnimationDirection.STATIC;
                            break;
                    }
                    break;
                case "notificationsAchievementAnimationOutComboBox":
                    switch ((string)notificationsAchievementAnimationOutComboBox.SelectedItem)
                    {
                        case "DOWN":
                            AlertsController.Instance.AchievementAnimationOut = AnimationDirection.DOWN;
                            break;
                        case "LEFT":
                            AlertsController.Instance.AchievementAnimationOut = AnimationDirection.LEFT;
                            break;
                        case "RIGHT":
                            AlertsController.Instance.AchievementAnimationOut = AnimationDirection.RIGHT;
                            break;
                        case "UP":
                            AlertsController.Instance.AchievementAnimationOut = AnimationDirection.UP;
                            break;
                        default:
                            AlertsController.Instance.AchievementAnimationOut = AnimationDirection.STATIC;
                            break;
                    }
                    break;
                case "notificationsMasteryAnimationInComboBox":
                    switch ((string)notificationsMasteryAnimationInComboBox.SelectedItem)
                    {
                        case "DOWN":
                            AlertsController.Instance.MasteryAnimationIn = AnimationDirection.DOWN;
                            break;
                        case "LEFT":
                            AlertsController.Instance.MasteryAnimationIn = AnimationDirection.LEFT;
                            break;
                        case "RIGHT":
                            AlertsController.Instance.MasteryAnimationIn = AnimationDirection.RIGHT;
                            break;
                        case "UP":
                            AlertsController.Instance.MasteryAnimationIn = AnimationDirection.UP;
                            break;
                        default:
                            AlertsController.Instance.MasteryAnimationIn = AnimationDirection.STATIC;
                            break;
                    }
                    break;
                case "notificationsMasteryAnimationOutComboBox":
                    switch ((string)notificationsMasteryAnimationOutComboBox.SelectedItem)
                    {
                        case "DOWN":
                            AlertsController.Instance.MasteryAnimationOut = AnimationDirection.DOWN;
                            break;
                        case "LEFT":
                            AlertsController.Instance.MasteryAnimationOut = AnimationDirection.LEFT;
                            break;
                        case "RIGHT":
                            AlertsController.Instance.MasteryAnimationOut = AnimationDirection.RIGHT;
                            break;
                        case "UP":
                            AlertsController.Instance.MasteryAnimationOut = AnimationDirection.UP;
                            break;
                        default:
                            AlertsController.Instance.MasteryAnimationOut = AnimationDirection.STATIC;
                            break;
                    }
                    break;
            }
        }
        private void FontOutlineCheckBoxheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            bool isEnabled = checkBox.Checked;

            switch (MenuState)
            {
                case CustomMenuState.STATS:
                    if (StatsController.Instance.AdvancedSettingsEnabled)
                    {
                        switch (checkBox.Name)
                        {
                            case "titleFontOutlineCheckbox":
                                StatsController.Instance.NameOutlineEnabled = isEnabled;
                                break;
                            case "descriptionFontOutlineCheckbox":
                                StatsController.Instance.ValueOutlineEnabled = isEnabled;
                                break;
                        }
                    }
                    else
                    {
                        StatsController.Instance.SimpleFontOutlineEnabled = isEnabled;
                    }
                    break;
                case CustomMenuState.ALERTS:
                    if (AlertsController.Instance.AdvancedSettingsEnabled)
                    {
                        switch (checkBox.Name)
                        {
                            case "titleFontOutlineCheckbox":
                                AlertsController.Instance.TitleOutlineEnabled = isEnabled;
                                break;
                            case "descriptionFontOutlineCheckbox":
                                AlertsController.Instance.DescriptionOutlineEnabled = isEnabled;
                                break;
                            case "pointsFontOutlineCheckbox":
                                AlertsController.Instance.PointsOutlineEnabled = isEnabled;
                                break;
                            case "lineOutlineCheckbox":
                                AlertsController.Instance.LineOutlineEnabled = isEnabled;
                                break;
                        }
                    }
                    else
                    {
                        AlertsController.Instance.SimpleFontOutlineEnabled = isEnabled;
                    }
                    break;
                case CustomMenuState.GAME_INFO:
                    if (GameInfoController.Instance.AdvancedSettingsEnabled)
                    {
                        switch (checkBox.Name)
                        {
                            case "titleFontOutlineCheckbox":
                                GameInfoController.Instance.NameOutlineEnabled = isEnabled;
                                break;
                            case "descriptionFontOutlineCheckbox":
                                GameInfoController.Instance.ValueOutlineEnabled = isEnabled;
                                break;
                        }
                    }
                    else
                    {
                        GameInfoController.Instance.SimpleFontOutlineEnabled = isEnabled;
                    }
                    break;
                case CustomMenuState.LAST_FIVE:
                    if (LastFiveController.Instance.AdvancedSettingsEnabled)
                    {
                        switch (checkBox.Name)
                        {
                            case "titleFontOutlineCheckbox":
                                LastFiveController.Instance.TitleOutlineEnabled = isEnabled;
                                break;
                            case "descriptionFontOutlineCheckbox":
                                LastFiveController.Instance.DateOutlineEnabled = isEnabled;
                                break;
                            case "pointsFontOutlineCheckbox":
                                LastFiveController.Instance.PointsOutlineEnabled = isEnabled;
                                break;
                            case "lineOutlineCheckbox":
                                LastFiveController.Instance.LineOutlineEnabled = isEnabled;
                                break;
                        }
                    }
                    else
                    {
                        LastFiveController.Instance.SimpleFontOutlineEnabled = isEnabled;
                    }
                    break;
                case CustomMenuState.FOCUS:
                    if (FocusController.Instance.AdvancedSettingsEnabled)
                    {
                        switch (checkBox.Name)
                        {
                            case "titleFontOutlineCheckbox":
                                FocusController.Instance.TitleOutlineEnabled = isEnabled;
                                break;
                            case "descriptionFontOutlineCheckbox":
                                FocusController.Instance.DescriptionOutlineEnabled = isEnabled;
                                break;
                            case "pointsFontOutlineCheckbox":
                                FocusController.Instance.PointsOutlineEnabled = isEnabled;
                                break;
                            case "lineOutlineCheckbox":
                                FocusController.Instance.LineOutlineEnabled = isEnabled;
                                break;
                        }
                    }
                    else
                    {
                        FocusController.Instance.SimpleFontOutlineEnabled = isEnabled;
                    }
                    break;
            }

            UpdateGroupBoxVisibility();
        }
        private void BackgroundColorButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                switch (MenuState)
                {
                    case CustomMenuState.ALERTS:
                        if (button.Name == "windowBackgroundColorButton")
                        {
                            AlertsController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                            windowBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        }
                        else
                        {
                            AlertsController.Instance.BorderBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                            borderBackgroudColorPictureBox.BackColor = colorDialog1.Color;
                        }
                        break;
                    case CustomMenuState.LAST_FIVE:
                        if (button.Name == "windowBackgroundColorButton")
                        {
                            LastFiveController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                            windowBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        }
                        else
                        {
                            LastFiveController.Instance.BorderBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                            borderBackgroudColorPictureBox.BackColor = colorDialog1.Color;
                        }
                        break;
                    case CustomMenuState.FOCUS:
                        if (button.Name == "windowBackgroundColorButton")
                        {
                            FocusController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                            windowBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        }
                        else
                        {
                            FocusController.Instance.BorderBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                            borderBackgroudColorPictureBox.BackColor = colorDialog1.Color;
                        }
                        break;
                    case CustomMenuState.GAME_INFO:
                        GameInfoController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        windowBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case CustomMenuState.STATS:
                        StatsController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        windowBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case CustomMenuState.ACHIEVEMENT_LIST:
                        AchievementListController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        windowBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                }
            }
        }
        private void GameInfoDefaultButton_Click(object sender, EventArgs e)
        {
            gameInfoConsoleOverrideTextBox.Text = "Console";
            gameInfoDeveloperOverrideTextBox.Text = "Developer";
            gameInfoPublisherOverrideTextBox.Text = "Publisher";
            gameInfoGenreOverrideTextBox.Text = "Genre";
            gameInfoReleaseDateOverrideTextBox.Text = "Released";
            gameInfoTitleOverrideTextBox.Text = "Title";
        }
        private void StatsDefaultButton_Click(object sender, EventArgs e)
        {
            statsRankOverrideTextBox.Text = "Rank";
            statsAwardsOverrideTextBox.Text = "Awards";
            statsPointsOverrideTextBox.Text = "Points";
            statsTruePointsOverrideTextBox.Text = "True Points";
            statsRatioOverrideTextBox.Text = "Ratio";
            statsGameRatioOverrideTextBox.Text = "Ratio";
            statsGamePointsOverrideTextBox.Text = "Points";
            statsGameTruePointsOverrideTextBox.Text = "True Points";
            statsGameAchievementsOverrideTextBox.Text = "Cheevos";
            statsCompletedOverrideTextBox.Text = "Compeleted";
        }
        private void SimpleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            switch (checkBox.Name)
            {
                case "achievementListOptimizeCheckBox":
                    AchievementListController.Instance.OptimizeEnabled = checkBox.Checked;
                    break;
                case "fontSimpleCheckbox":
                    switch (MenuState)
                    {
                        case CustomMenuState.ALERTS:
                            AlertsController.Instance.AdvancedSettingsEnabled = !checkBox.Checked;
                            break;
                        case CustomMenuState.LAST_FIVE:
                            LastFiveController.Instance.AdvancedSettingsEnabled = !checkBox.Checked;
                            break;
                        case CustomMenuState.FOCUS:
                            FocusController.Instance.AdvancedSettingsEnabled = !checkBox.Checked;
                            break;
                        case CustomMenuState.GAME_INFO:
                            GameInfoController.Instance.AdvancedSettingsEnabled = !checkBox.Checked;
                            break;
                        case CustomMenuState.STATS:
                            StatsController.Instance.AdvancedSettingsEnabled = !checkBox.Checked;
                            break;
                    }
                    UpdateGroupBoxVisibility();
                    break;
            }
        }
        private void OverrideEnableCheckBox_Clicked(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            switch (MenuState)
            {
                case CustomMenuState.FOCUS:
                    FocusController.Instance.BorderEnabled = checkBox.Checked;
                    break;
                case CustomMenuState.ALERTS:
                    AlertsController.Instance.BorderEnabled = checkBox.Checked;
                    break;
                case CustomMenuState.LAST_FIVE:
                    LastFiveController.Instance.BorderEnabled = checkBox.Checked;
                    break;
                case CustomMenuState.STATS:
                    switch (checkBox.Name)
                    {
                        case "rankEnableCheckBox":
                            StatsController.Instance.RankEnabled = checkBox.Checked;
                            break;
                        case "awardsEnableCheckBox":
                            StatsController.Instance.AwardsEnabled = checkBox.Checked;
                            break;
                        case "pointsEnableCheckBox":
                            StatsController.Instance.PointsEnabled = checkBox.Checked;
                            break;
                        case "truePointsEnableCheckBox":
                            StatsController.Instance.TruePointsEnabled = checkBox.Checked;
                            break;
                        case "ratioEnableCheckBox":
                            StatsController.Instance.RatioEnabled = checkBox.Checked;
                            break;
                        case "gameAchievementsEnableCheckBox":
                            StatsController.Instance.GameAchievementsEnabled = checkBox.Checked;
                            break;
                        case "gamePointsEnableCheckBox":
                            StatsController.Instance.GamePointsEnabled = checkBox.Checked;
                            break;
                        case "gameTruePointsEnableCheckBox":
                            StatsController.Instance.GameTruePointsEnabled = checkBox.Checked;
                            break;
                        case "gameRatioEnableCheckBox":
                            StatsController.Instance.GameRatioEnabled = checkBox.Checked;
                            break;
                        case "completedEnableCheckBox":
                            StatsController.Instance.CompletedEnabled = checkBox.Checked;
                            break;
                    }
                    break;
                case CustomMenuState.GAME_INFO:
                    switch (checkBox.Name)
                    {
                        case "titleEnableCheckBox":
                            GameInfoController.Instance.TitleEnabled = checkBox.Checked;
                            break;
                        case "developerEnableCheckBox":
                            GameInfoController.Instance.DeveloperEnabled = checkBox.Checked;
                            break;
                        case "genreEnableCheckBox":
                            GameInfoController.Instance.GenreEnabled = checkBox.Checked;
                            break;
                        case "publisherEnableCheckBox":
                            GameInfoController.Instance.PublisherEnabled = checkBox.Checked;
                            break;
                        case "consoleEnableCheckBox":
                            GameInfoController.Instance.ConsoleEnabled = checkBox.Checked;
                            break;
                        case "releasedDateEnableCheckBox":
                            GameInfoController.Instance.ReleasedDateEnabled = checkBox.Checked;
                            break;
                    }
                    break;
            }
        }
        private void OverrideTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            switch (textBox.Name)
            {
                case "statsRankOverrideTextBox":
                    StatsController.Instance.RankName = textBox.Text;
                    break;
                case "statsCompletedOverrideTextBox":
                    StatsController.Instance.CompletedName = textBox.Text;
                    break;
                case "statsPointsOverrideTextBox":
                    StatsController.Instance.PointsName = textBox.Text;
                    break;
                case "statsAwardsOverrideTextBox":
                    StatsController.Instance.AwardsName = textBox.Text;
                    break;
                case "statsTruePointsOverrideTextBox":
                    StatsController.Instance.TruePointsName = textBox.Text;
                    break;
                case "statsRatioOverrideTextBox":
                    StatsController.Instance.RatioName = textBox.Text;
                    break;
                case "statsGameRatioOverrideTextBox":
                    StatsController.Instance.GameRatioName = textBox.Text;
                    break;
                case "statsGamePointsOverrideTextBox":
                    StatsController.Instance.GamePointsName = textBox.Text;
                    break;
                case "statsGameTruePointsOverrideTextBox":
                    StatsController.Instance.GameTruePointsName = textBox.Text;
                    break;
                case "statsGameAchievementsOverrideTextBox":
                    StatsController.Instance.GameAchievementsName = textBox.Text;
                    break;
                case "gameInfoConsoleOverrideTextBox":
                    GameInfoController.Instance.ConsoleName = textBox.Text;
                    break;
                case "gameInfoDeveloperOverrideTextBox":
                    GameInfoController.Instance.DeveloperName = textBox.Text;
                    break;
                case "gameInfoPublisherOverrideTextBox":
                    GameInfoController.Instance.PublisherName = textBox.Text;
                    break;
                case "gameInfoGenreOverrideTextBox":
                    GameInfoController.Instance.GenreName = textBox.Text;
                    break;
                case "gameInfoReleaseDateOverrideTextBox":
                    GameInfoController.Instance.ReleasedDateName = textBox.Text;
                    break;
                case "gameInfoTitleOverrideTextBox":
                    GameInfoController.Instance.TitleName = textBox.Text;
                    break;
            }
        }
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton.Checked && !UpdatingVisibility)
            {
                switch (radioButton.Name)
                {
                    case "statsRadioButtonBackslash":
                        statsRadioButtonDot.Checked = false;
                        statsRadioButtonSemicolon.Checked = false;
                        StatsController.Instance.DividerCharacter = "/";
                        break;
                    case "statsRadioButtonSemicolon":
                        statsRadioButtonDot.Checked = false;
                        statsRadioButtonBackslash.Checked = false;
                        StatsController.Instance.DividerCharacter = ":";
                        break;
                    case "statsRadioButtonDot":
                        statsRadioButtonSemicolon.Checked = false;
                        statsRadioButtonBackslash.Checked = false;
                        StatsController.Instance.DividerCharacter = ".";
                        break;
                }
            }
        }
        private void LoadProperties()
        {
            if (Settings.Default.UpdateSettings)
            {
                Settings.Default.Upgrade();

                Settings.Default.UpdateSettings = false;

                Settings.Default.Save();
            }

            usernameTextBox.Text = Settings.Default.ra_username;
            apiKeyTextBox.Text = Settings.Default.ra_key;
            autoStartCheckbox.Checked = Settings.Default.auto_start_checked;
            autoLaunchFocusWindowCheckBox.Checked = FocusController.Instance.AutoLaunch;
            autoLaunchStatsWindowCheckbox.Checked = StatsController.Instance.AutoLaunch;
            autoLaunchAlertsWindowCheckbox.Checked = AlertsController.Instance.AutoLaunch;
            autoLaunchGameInfoWindowCheckbox.Checked = GameInfoController.Instance.AutoLaunch;
            autoLaunchLastFiveWindowCheckbox.Checked = LastFiveController.Instance.AutoLaunch;
            autoLaunchAchievementListWindowCheckbox.Checked = AchievementListController.Instance.AutoLaunch;

            fontBorderEnableCheckBox.Checked = Settings.Default.notifications_border_enable;

            List<AnimationDirection> animationDirections = new List<AnimationDirection>
            {
                AnimationDirection.DOWN,
                AnimationDirection.LEFT,
                AnimationDirection.RIGHT,
                AnimationDirection.STATIC,
                AnimationDirection.UP
            };

            animationDirections.ForEach(animationDirection =>
            {
                notificationsAchievementAnimationInComboBox.Items.Add(animationDirection.ToString());
                notificationsAchievementAnimationOutComboBox.Items.Add(animationDirection.ToString());
                notificationsMasteryAnimationInComboBox.Items.Add(animationDirection.ToString());
                notificationsMasteryAnimationOutComboBox.Items.Add(animationDirection.ToString());
            });

            notificationsAchievementAnimationInComboBox.SelectedIndex = notificationsAchievementAnimationInComboBox.Items.IndexOf(Settings.Default.notifications_achievement_in_animation);
            notificationsAchievementAnimationOutComboBox.SelectedIndex = notificationsAchievementAnimationOutComboBox.Items.IndexOf(Settings.Default.notifications_achievement_out_animation);
            notificationsMasteryAnimationInComboBox.SelectedIndex = notificationsMasteryAnimationInComboBox.Items.IndexOf(Settings.Default.notifications_mastery_in_animation);
            notificationsMasteryAnimationOutComboBox.SelectedIndex = notificationsMasteryAnimationOutComboBox.Items.IndexOf(Settings.Default.notifications_mastery_out_animation);

            customAchievementEnableCheckbox.Checked = AlertsController.Instance.CustomAchievementEnabled;
            selectCustomAchievementButton.Enabled = AlertsController.Instance.CustomAchievementEnabled;
            acheivementEditOutlineCheckbox.Enabled = AlertsController.Instance.CustomAchievementEnabled;

            customMasteryEnableCheckbox.Checked = AlertsController.Instance.CustomMasteryEnabled;
            selectCustomMasteryNotificationButton.Enabled = AlertsController.Instance.CustomMasteryEnabled;
            masteryEditOultineCheckbox.Enabled = AlertsController.Instance.CustomMasteryEnabled;

            customAchievementXNumericUpDown.Value = AlertsController.Instance.CustomAchievementX;
            customAchievementYNumericUpDown.Value = AlertsController.Instance.CustomAchievementY;

            customMasteryXNumericUpDown.Value = AlertsController.Instance.CustomMasteryX;
            customMasteryYNumericUpDown.Value = AlertsController.Instance.CustomMasteryY;

            if (AlertsController.Instance.CustomAchievementScale > scaleAchievementNumericUpDown.Maximum)
            {
                AlertsController.Instance.CustomAchievementScale = scaleAchievementNumericUpDown.Maximum;
            }

            if (AlertsController.Instance.CustomMasteryScale > scaleMasteryNumericUpDown.Maximum)
            {
                AlertsController.Instance.CustomMasteryScale = scaleMasteryNumericUpDown.Maximum;
            }

            scaleAchievementNumericUpDown.Value = AlertsController.Instance.CustomAchievementScale;
            scaleMasteryNumericUpDown.Value = AlertsController.Instance.CustomMasteryScale;

            notificationAchievementInNumericUpDown.Value = AlertsController.Instance.CustomAchievementIn;
            notificationAchievementOutNumericUpDown.Value = AlertsController.Instance.CustomAchievementOut;

            notificationMasteryInNumericUpDown.Value = AlertsController.Instance.CustomMasteryIn;
            notificationMasteryOutNumericUpDown.Value = AlertsController.Instance.CustomMasteryOut;

            customAchievementInSpeedUpDown.Value = AlertsController.Instance.CustomAchievementInSpeed;
            customAchievementOutSpeedUpDown.Value = AlertsController.Instance.CustomAchievementOutSpeed;

            customMasteryInSpeedUpDown.Value = AlertsController.Instance.CustomMasteryInSpeed;
            customMasteryOutSpeedUpDown.Value = AlertsController.Instance.CustomMasteryOutSpeed;

            usernameTextBox.TextChanged += RequiredField_TextChange;
            apiKeyTextBox.TextChanged += RequiredField_TextChange;

            statsGameAchievementsOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            statsGamePointsOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            statsGameTruePointsOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            statsCompletedOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            statsGameRatioOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            statsTruePointsOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            statsPointsOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            statsRatioOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            statsAwardsOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            statsRankOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;

            gameInfoGenreOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            gameInfoConsoleOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            gameInfoDeveloperOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            gameInfoReleaseDateOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            gameInfoPublisherOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            gameInfoTitleOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;

            statsDefaultButton.Click += StatsDefaultButton_Click;

            titleFontOutlineCheckbox.Click += FontOutlineCheckBoxheckbox_CheckedChanged;
            descriptionFontOutlineCheckbox.Click += FontOutlineCheckBoxheckbox_CheckedChanged;
            pointsFontOutlineCheckbox.Click += FontOutlineCheckBoxheckbox_CheckedChanged;
            lineOutlineCheckbox.Click += FontOutlineCheckBoxheckbox_CheckedChanged;

            titleFontColorButton.Click += FontColorButton_Click;
            descriptionFontColorButton.Click += FontColorButton_Click;
            pointsFontColorButton.Click += FontColorButton_Click;
            lineColorButton.Click += FontColorButton_Click;
            titleFontOutlineColorButton.Click += FontColorButton_Click;
            descriptionFontOutlineColorButton.Click += FontColorButton_Click;
            pointsFontOutlineColorButton.Click += FontColorButton_Click;
            lineOutlineColorButton.Click += FontColorButton_Click;

            titleFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            descriptionFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            pointsFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            lineOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;

            borderBackgroundColorButton.Click += BackgroundColorButton_Click;
            windowBackgroundColorButton.Click += BackgroundColorButton_Click;

            autoStartCheckbox.Click += AutoLaunchCheckbox_CheckedChanged;
            autoLaunchLastFiveWindowCheckbox.Click += AutoLaunchCheckbox_CheckedChanged;
            autoLaunchGameInfoWindowCheckbox.Click += AutoLaunchCheckbox_CheckedChanged;
            autoLaunchAlertsWindowCheckbox.Click += AutoLaunchCheckbox_CheckedChanged;
            autoLaunchFocusWindowCheckBox.Click += AutoLaunchCheckbox_CheckedChanged;
            autoLaunchStatsWindowCheckbox.Click += AutoLaunchCheckbox_CheckedChanged;
            autoLaunchAchievementListWindowCheckbox.Click += AutoLaunchCheckbox_CheckedChanged;

            customAchievementEnableCheckbox.Click += CustomAchievementEnableCheckbox_CheckedChanged;
            customMasteryEnableCheckbox.Click += CustomMasteryEnableCheckbox_CheckedChanged;
            acheivementEditOutlineCheckbox.Click += AcheivementEditOutlineCheckbox_CheckedChanged;
            masteryEditOultineCheckbox.Click += MasteryEditOultineCheckbox_CheckedChanged;

            fontBorderEnableCheckBox.Click += OverrideEnableCheckBox_Clicked;
            rankEnableCheckBox.Click += OverrideEnableCheckBox_Clicked;
            awardsEnableCheckBox.Click += OverrideEnableCheckBox_Clicked;
            pointsEnableCheckBox.Click += OverrideEnableCheckBox_Clicked;
            ratioEnableCheckBox.Click += OverrideEnableCheckBox_Clicked;
            truePointsEnableCheckBox.Click += OverrideEnableCheckBox_Clicked;
            gameAchievementsEnableCheckBox.Click += OverrideEnableCheckBox_Clicked;
            gamePointsEnableCheckBox.Click += OverrideEnableCheckBox_Clicked;
            gameTruePointsEnableCheckBox.Click += OverrideEnableCheckBox_Clicked;
            completedEnableCheckBox.Click += OverrideEnableCheckBox_Clicked;
            gameRatioEnableCheckBox.Click += OverrideEnableCheckBox_Clicked;

            titleEnableCheckBox.Click += OverrideEnableCheckBox_Clicked;
            developerEnableCheckBox.Click += OverrideEnableCheckBox_Clicked;
            genreEnableCheckBox.Click += OverrideEnableCheckBox_Clicked;
            publisherEnableCheckBox.Click += OverrideEnableCheckBox_Clicked;
            consoleEnableCheckBox.Click += OverrideEnableCheckBox_Clicked;
            releasedDateEnableCheckBox.Click += OverrideEnableCheckBox_Clicked;

            fontSimpleCheckbox.Click += SimpleCheckBox_CheckedChanged;

            titleFontFamilyComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;
            descriptionFontFamilyComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;
            pointsFontFamilyComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;

            statsRadioButtonBackslash.Click += RadioButton_CheckedChanged;
            statsRadioButtonSemicolon.Click += RadioButton_CheckedChanged;
            statsRadioButtonDot.Click += RadioButton_CheckedChanged;

            notificationsAchievementAnimationInComboBox.SelectedIndexChanged += NotificationAnimationComboBox_SelectedIndexChanged;
            notificationsAchievementAnimationOutComboBox.SelectedIndexChanged += NotificationAnimationComboBox_SelectedIndexChanged;
            notificationsMasteryAnimationInComboBox.SelectedIndexChanged += NotificationAnimationComboBox_SelectedIndexChanged;
            notificationsMasteryAnimationOutComboBox.SelectedIndexChanged += NotificationAnimationComboBox_SelectedIndexChanged;

            openLastFiveWindowButton.Click += ShowWindowButton_Click;
            openGameInfoWindowButton.Click += ShowWindowButton_Click;
            openNotificationWindowButton.Click += ShowWindowButton_Click;
            openFocusWindowButton.Click += ShowWindowButton_Click;
            openStatsWindowButton.Click += ShowWindowButton_Click;
            openAchievementListWindowButton.Click += ShowWindowButton_Click;

            startButton.Click += StartButton_Click;
            stopButton.Click += StopButton_Click;

            setFocusButton.Click += SetFocusButton_Click;
            focusAchievementButtonLeft.Click += MoveFocusIndexLeft;
            focusAchievementButtonRight.Click += MoveFocusIndexRight;

            customizeLastFiveButton.Click += CustomizeButton_Click;
            customizeGameInfoButton.Click += CustomizeButton_Click;
            customizeAlertsButton.Click += CustomizeButton_Click;
            customizeFocusButton.Click += CustomizeButton_Click;
            customizeStatsButton.Click += CustomizeButton_Click;
            customizeAchievementListButton.Click += CustomizeButton_Click;

            playAchievementButton.Click += ShowAchievementButton_Click;
            playMasteryButton.Click += ShowGameMasteryButton_Click;
            selectCustomAchievementButton.Click += SelectCustomAchievementButton_Click;
            selectCustomMasteryNotificationButton.Click += SelectCustomMasteryNotificationButton_Click;

            scaleAchievementNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            scaleMasteryNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            customAchievementXNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            customAchievementYNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            customAchievementInSpeedUpDown.ValueChanged += CustomeAnimationSpeedUpDown_ValueChanged;
            customAchievementOutSpeedUpDown.ValueChanged += CustomeAnimationSpeedUpDown_ValueChanged;
            customMasteryXNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            customMasteryYNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            customMasteryInSpeedUpDown.ValueChanged += CustomeAnimationSpeedUpDown_ValueChanged;
            customMasteryOutSpeedUpDown.ValueChanged += CustomeAnimationSpeedUpDown_ValueChanged;
            notificationAchievementOutNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            notificationAchievementInNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            notificationMasteryOutNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            notificationMasteryInNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
        }
    }
    public enum CustomMenuState
    {
        CLOSED,
        FOCUS,
        STATS,
        ALERTS,
        GAME_INFO,
        LAST_FIVE,
        ACHIEVEMENT_LIST
    }
    public enum AnimationDirection
    {
        STATIC,
        LEFT,
        RIGHT,
        UP,
        DOWN
    }
}