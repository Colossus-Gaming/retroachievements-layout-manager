using AutoUpdaterDotNET;
using HtmlAgilityPack;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Forms;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;

namespace Retro_Achievement_Tracker
{
    public partial class MainPage : Form, INotifyPropertyChanged
    {
        private StreamLabelManager StreamLabelManager = new StreamLabelManager();

        private bool NotBooting;
        public UserSummary UserSummary { get; set; }
        private GameProgress GameProgress { get; set; }

        private Achievement CurrentlyViewingAchievement;
        private int CurrentlyViewingIndex;

        private static List<Achievement> LockedAchievements;
        private static List<Achievement> UnlockedAchievements;
        private static List<Achievement> OldUnlockedAchievements;

        private static Timer UserAndGameUpdateTimer;
        private static int UserAndGameTimerCounter;

        private static StatsLayoutWindow statsLayoutWindow;
        private static FocusLayoutWindow focusLayoutWindow;
        private static GameInfoLayoutWindow gameInfoLayoutWindow;

        private bool ShouldRun;

        private CustomMenuState MenuState = CustomMenuState.CLOSED;

        private HFC_EssentialsClient hFC_EssentialsClient;

        public event PropertyChangedEventHandler PropertyChanged;
        private List<Achievement> MostRecentAchievements;

        public MainPage()
        {
            InitializeComponent();
            AutoUpdate();

            statsLayoutWindow = new StatsLayoutWindow();
            focusLayoutWindow = new FocusLayoutWindow();
            gameInfoLayoutWindow = new GameInfoLayoutWindow();

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
                            this.Close();
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {

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

            UnlockedAchievements = new List<Achievement>();
            LockedAchievements = new List<Achievement>();

            HideAllMenuItems();

            if (statsLayoutWindow.AutoLaunch)
            {
                statsLayoutWindow.Show();
                focusLayoutWindow.Location = new Point(0, 0);
            }
            if (focusLayoutWindow.AutoLaunch)
            {
                focusLayoutWindow.Show();
                focusLayoutWindow.Location = new Point(0, 0);
            }
            if (gameInfoLayoutWindow.AutoLaunch)
            {
                gameInfoLayoutWindow.Show();
                gameInfoLayoutWindow.Location = new Point(0, 0);
            }
            if (LastFiveController.Instance.AutoLaunch)
            {
                LastFiveController.Instance.Show();
            }
            if (AlertController.Instance.AutoLaunch)
            {
                AlertController.Instance.Show();
            }

            this.Location = new Point(0, 0);
        }

        private bool UpdateGameProgress(bool sameGame)
        {
            bool UpdateAwards = false;

            OldUnlockedAchievements = UnlockedAchievements.ToList();

            SortAchievements();

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

                    AlertController.Instance.EnqueueAchievementNotifications(achievementNotificationList);

                    if (achievementNotificationList.Contains(CurrentlyViewingAchievement))
                    {
                        UpdateCurrentlyViewingAchievement();
                    }
                    if (UnlockedAchievements.Count == GameProgress.Achievements.Count && OldUnlockedAchievements.Count < GameProgress.Achievements.Count)
                    {
                        ClearFocusAchievementRenders();
                        AlertController.Instance.EnqueueMasteryNotification(UserSummary.GameSummaries[0], UserSummary.GameAchievementSummaries[0]);
                    }

                    UpdateAwards = true;
                }
            }
            else
            {
                UpdateTimerLabel("Changing game to [" + GameProgress.Id + "] " + GameProgress.Title);
                UpdateGameInfo();

                if (LockedAchievements.Count > 0)
                {
                    CurrentlyViewingIndex = 0;
                    UpdateCurrentlyViewingAchievement();
                }

                SetFocus();
            }

            return UpdateAwards;
        }

        private void SetFocus()
        {
            Invoke((MethodInvoker)delegate
            {
                if (CurrentlyViewingAchievement != null)
                {
                    focusLayoutWindow.SetFocus(CurrentlyViewingAchievement);
                    StreamLabelManager.WriteFocusStreamLabels(CurrentlyViewingAchievement);
                }
                else
                {
                    StreamLabelManager.ClearFocusStreamLabels();
                }
            });
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
                UpdateTimerLabel("Starting Update.");

                UserAndGameUpdateTimer.Stop();

                UpdateTimerLabel("Calling for user summary.");

                try
                {
                    await hFC_EssentialsClient.GetUserSummary().ContinueWith(async userSummaryTemp =>
                    {
                        UserSummary = userSummaryTemp.Result;

                        UpdateTimerLabel("Calling for game progress.");

                        await hFC_EssentialsClient.GetGameProgress(UserSummary.GameSummaries[0].GameID.ToString()).ContinueWith(async gameProgressTemp =>
                        {
                            long previousId = GameProgress != null ? GameProgress.Id : -1;

                            GameProgress = gameProgressTemp.Result;

                            if (UpdateGameProgress(previousId == GameProgress.Id))
                            {
                                await GetAwardCount().ContinueWith(awards =>
                                {
                                    UserSummary.Awards = awards.Result;
                                    Invoke((MethodInvoker)delegate
                                    {
                                        UpdateStats();
                                        StartTimer();
                                    });
                                });
                            }
                            else
                            {
                                await Task.Run(() =>
                                {
                                    Invoke((MethodInvoker)delegate
                                    {
                                        StartTimer();
                                    });
                                });
                            }
                        });
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private async Task InitializePlayerData()
        {
            hFC_EssentialsClient = new HFC_EssentialsClient(this.usernameTextBox.Text, this.apiKeyTextBox.Text);

            await hFC_EssentialsClient.GetUserSummary().ContinueWith(async userSummaryTemp =>
            {
                UserSummary = userSummaryTemp.Result;

                await hFC_EssentialsClient.GetGameProgress(UserSummary.GameSummaries[0].GameID.ToString()).ContinueWith(async gameProgressTemp =>
                {
                    GameProgress = gameProgressTemp.Result;

                    UpdateGameProgress(false);

                    SetFocus();

                    this.userProfilePictureBox.ImageLocation = "https://retroachievements.org/UserPic/" + this.usernameTextBox.Text + ".png";

                    await GetAwardCount().ContinueWith(awards =>
                    {
                        UserSummary.Awards = awards.Result;

                        Invoke((MethodInvoker)delegate
                        {
                            UpdateStats();
                            StartTimer();
                        });
                    });
                });
            });
        }
        protected override void OnShown(EventArgs e)
        {
            CreateFolders();

            if (CanStart())
            {
                if (this.autoStartCheckbox.Checked)
                {
                    this.StartButton_Click(null, null);
                }
            }
            else
            {
                this.StopButton_Click(null, null);
            }

            NotBooting = true;
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
        private async void StartButton_Click(object sender, EventArgs e)
        {
            NotBooting = false;

            this.startButton.Enabled = false;
            this.stopButton.Enabled = true;

            ShouldRun = true;

            this.usernameTextBox.Enabled = false;
            this.apiKeyTextBox.Enabled = false;

            this.showFocusWindowButton.Enabled = true;
            this.showNotificationWindowButton.Enabled = true;
            this.showStatsWindowButton.Enabled = true;
            this.showGameInfoWindowButton.Enabled = true;

            this.statsStreamLabelsCheckBox.Enabled = true;
            this.lastFiveStreamLabelsCheckBox.Enabled = true;
            this.focusStreamLabelsCheckBox.Enabled = true;
            this.gameInfoStreamLabelsCheckBox.Enabled = true;

            await InitializePlayerData();

            Settings.Default.ra_username = this.usernameTextBox.Text;
            Settings.Default.ra_key = this.apiKeyTextBox.Text;
            Settings.Default.Save();
        }
        private void StopButton_Click(object sender, EventArgs e)
        {
            ShouldRun = false;

            UserAndGameUpdateTimer.Stop();

            this.raConnectionStatusPictureBox.Image = Resources.red_button;

            UpdateTimerLabel("Stopped Updating.");

            this.stopButton.Enabled = false;
            this.showFocusWindowButton.Enabled = CanStart();
            this.showNotificationWindowButton.Enabled = CanStart();
            this.showStatsWindowButton.Enabled = CanStart();

            this.apiKeyTextBox.Enabled = true;
            this.usernameTextBox.Enabled = true;

            this.startButton.Enabled = CanStart();
        }

        public void SetLockedAchievements(List<Achievement> achievements)
        {
            Invoke((MethodInvoker)delegate
            {
                if (achievements != null && achievements.Count > 0)
                {
                    int gameId = achievements[0].GameId;
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
                LockedAchievements = achievements.ToList();

                UpdateCurrentlyViewingAchievement();
            });
        }

        public void UpdateCurrentlyViewingAchievement()
        {
            if (this.Visible)
            {
                Invoke((MethodInvoker)delegate
                {
                    UpdateFocusButtons();

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

                        this.focusAchievementPictureBox.ImageLocation = "https://retroachievements.org/Badge/" + CurrentlyViewingAchievement.BadgeNumber + ".png";
                        this.focusAchievementTitleLabel.Text = CurrentlyViewingAchievement.Title;
                        this.focusAchievementDescriptionLabel.Text = CurrentlyViewingAchievement.Description;
                    }
                    else
                    {
                        CurrentlyViewingIndex = 0;

                        this.focusAchievementPictureBox.ImageLocation = string.Empty;
                        this.focusAchievementTitleLabel.Text = string.Empty;
                        this.focusAchievementDescriptionLabel.Text = string.Empty;
                    }
                });
            }
        }
        private void UpdateLastFive()
        {
            Invoke((MethodInvoker)delegate
            {
                LastFiveController.Instance.SetAchievement(MostRecentAchievements);
                StreamLabelManager.WriteLastFiveStreamLabels(UserSummary);
            });
        }
        private void UpdateStats()
        {
            Invoke((MethodInvoker)delegate
            {
                UpdateStatLabels();

                statsLayoutWindow.SetRank(UserSummary.Rank.ToString());
                statsLayoutWindow.SetRatio(UserSummary.RetroRatio);
                statsLayoutWindow.SetAwards(UserSummary.Awards.ToString());
                statsLayoutWindow.SetPoints(UserSummary.TotalPoints.ToString());
                statsLayoutWindow.SetTruePoints(UserSummary.TotalTruePoints.ToString());
                statsLayoutWindow.SetGamePoints(GameProgress.PointsEarned, GameProgress.PointsPossible);
                statsLayoutWindow.SetGameAchievements(GameProgress.NumAwardedToUserHardcore.ToString(), GameProgress.NumAchievements.ToString());
                statsLayoutWindow.SetGameTruePoints(GameProgress.TruePointsEarned, GameProgress.TruePointsPossible);
                statsLayoutWindow.SetGameRatio();
                statsLayoutWindow.SetCompleted(GameProgress.UserCompletionHardcore);

                StreamLabelManager.WriteStatsStreamLabels(UserSummary, GameProgress);
            });
        }
        private void UpdateGameInfo()
        {
            Invoke((MethodInvoker)delegate
            {
                gameInfoLayoutWindow.SetTitleValue(GameProgress.Title);
                gameInfoLayoutWindow.SetGenreValue(GameProgress.Genre);
                gameInfoLayoutWindow.SetConsoleValue(GameProgress.ConsoleName);
                gameInfoLayoutWindow.SetDeveloperValue(GameProgress.Developer);
                gameInfoLayoutWindow.SetPublisherValue(GameProgress.Publisher);
                gameInfoLayoutWindow.SetReleaseDateValue(GameProgress.Released);

                StreamLabelManager.WriteGameInfoStreamLabels(GameProgress);
            });
        }
        private void ClearFocusAchievementRenders()
        {
            Invoke((MethodInvoker)delegate
            {
                focusLayoutWindow.HideFocus();
                StreamLabelManager.ClearFocusStreamLabels();
            });
        }
        private bool CanStart()
        {
            return !(string.IsNullOrEmpty(this.usernameTextBox.Text)
                || string.IsNullOrEmpty(this.apiKeyTextBox.Text));
        }
        private void UpdateTimerLabel(string s)
        {
            Invoke((MethodInvoker)delegate
            {
                this.timerStatusLabel.Text = s;
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
            if (GameProgress.Achievements != null)
            {
                List<Achievement> tempLockedAchievements = GameProgress.Achievements.FindAll(x => !x.DateEarned.HasValue);
                List<Achievement> tempUnlockedAchievements = GameProgress.Achievements.FindAll(x => x.DateEarned.HasValue);

                tempUnlockedAchievements.Sort(delegate (Achievement x, Achievement y) { return y.DateEarned.Value.CompareTo(x.DateEarned.Value); });
                tempLockedAchievements.Sort();

                SetLockedAchievements(new List<Achievement>(tempLockedAchievements));
                UnlockedAchievements = new List<Achievement>(tempUnlockedAchievements);

                MostRecentAchievements = new List<Achievement>(tempUnlockedAchievements.GetRange(0, tempUnlockedAchievements.Count > 5 ? 5 : tempUnlockedAchievements.Count));
            }
            if (OldUnlockedAchievements.Count < UnlockedAchievements.Count)
            {
                if (LockedAchievements.Count == 0)
                {
                    CurrentlyViewingIndex = 0;
                    HideFocusButton_Click(null, null);
                }
                else if (LockedAchievements.IndexOf(focusLayoutWindow.CurrentlyFocusedAchievement) > -1)
                {
                    CurrentlyViewingIndex = LockedAchievements.IndexOf(focusLayoutWindow.CurrentlyFocusedAchievement);
                }
                else
                {
                    CurrentlyViewingIndex = LockedAchievements.IndexOf(CurrentlyViewingAchievement) == -1 ? 0 : LockedAchievements.IndexOf(CurrentlyViewingAchievement);
                    SetFocusButton_Click(null, null);
                }
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            StreamLabelManager.ClearAllStreamLabels();

            focusLayoutWindow.Close();
            statsLayoutWindow.Close();
            AlertController.Instance.Close();
            gameInfoLayoutWindow.Close();
            LastFiveController.Instance.Close();
        }
        private void LoadProperties()
        {
            if (Settings.Default.UpdateSettings)
            {
                Settings.Default.Upgrade();

                Settings.Default.UpdateSettings = false;

                Settings.Default.Save();
            }

            this.usernameTextBox.Text = Settings.Default.ra_username;
            this.apiKeyTextBox.Text = Settings.Default.ra_key;
            this.autoStartCheckbox.Checked = Settings.Default.auto_start_checked;
            this.autoLaunchFocusWindowCheckBox.Checked = Settings.Default.auto_focus;
            this.autoLaunchStatsWindowCheckbox.Checked = Settings.Default.auto_stats;
            this.autoLaunchNotificationsWindowCheckbox.Checked = Settings.Default.auto_notifications;
            this.autoLaunchGameInfoWindowCheckbox.Checked = Settings.Default.auto_game_info;
            this.autoLaunchLastFiveWindowCheckbox.Checked = Settings.Default.auto_last_five;

            this.focusStreamLabelsCheckBox.Checked = Settings.Default.stream_labels_focus;
            this.gameInfoStreamLabelsCheckBox.Checked = Settings.Default.stream_labels_game_info;
            this.lastFiveStreamLabelsCheckBox.Checked = Settings.Default.stream_labels_last_five;
            this.statsStreamLabelsCheckBox.Checked = Settings.Default.stream_labels_stats;

            this.statsRankOverrideTextBox.Text = Settings.Default.stats_rank_name;
            this.statsAwardsOverrideTextBox.Text = Settings.Default.stats_awards_name;
            this.statsPointsOverrideTextBox.Text = Settings.Default.stats_points_name;
            this.statsTruePointsOverrideTextBox.Text = Settings.Default.stats_true_points_name;
            this.statsRatioOverrideTextBox.Text = Settings.Default.stats_ratio_name;
            this.statsCompletedOverrideTextBox.Text = Settings.Default.stats_completed_name;
            this.statsGameRatioOverrideTextBox.Text = Settings.Default.stats_game_ratio_name;
            this.statsGamePointsOverrideTextBox.Text = Settings.Default.stats_game_points_name;
            this.statsGameTruePointsOverrideTextBox.Text = Settings.Default.stats_game_true_points_name;
            this.statsGameAchievementsOverrideTextBox.Text = Settings.Default.stats_game_achievements_name;

            this.gameInfoTitleOverrideTextBox.Text = Settings.Default.game_info_title_name;
            this.gameInfoConsoleOverrideTextBox.Text = Settings.Default.game_info_console_name;
            this.gameInfoDeveloperOverrideTextBox.Text = Settings.Default.game_info_developer_name;
            this.gameInfoPublisherOverrideTextBox.Text = Settings.Default.game_info_publisher_name;
            this.gameInfoGenreOverrideTextBox.Text = Settings.Default.game_info_genre_name;
            this.gameInfoReleaseDateOverrideTextBox.Text = Settings.Default.game_info_release_date_name;

            this.statsRankCheckBox.Checked = Settings.Default.stats_rank_enable;
            this.statsAwardsCheckBox.Checked = Settings.Default.stats_awards_enable;
            this.statsPointsCheckBox.Checked = Settings.Default.stats_points_enable;
            this.statsTruePointsCheckBox.Checked = Settings.Default.stats_true_points_enable;
            this.statsRatioCheckBox.Checked = Settings.Default.stats_ratio_enable;
            this.statsCompletedCheckBox.Checked = Settings.Default.stats_completed_enable;
            this.statsGameRatioCheckBox.Checked = Settings.Default.stats_game_ratio_enable;
            this.statsGamePointsCheckBox.Checked = Settings.Default.stats_game_points_enable;
            this.statsGameTruePointsCheckBox.Checked = Settings.Default.stats_game_true_points_enable;
            this.statsGameAchievementsCheckBox.Checked = Settings.Default.stats_game_achievements_enable;

            this.gameInfoTitleCheckBox.Checked = Settings.Default.game_info_title_enable;
            this.gameInfoConsoleCheckBox.Checked = Settings.Default.game_info_console_enable;
            this.gameInfoDeveloperCheckBox.Checked = Settings.Default.game_info_developer_enable;
            this.gameInfoPublisherCheckBox.Checked = Settings.Default.game_info_publisher_enable;
            this.gameInfoGenreCheckBox.Checked = Settings.Default.game_info_genre_enable;
            this.gameInfoReleaseDateCheckBox.Checked = Settings.Default.game_info_release_date_enable;

            this.focusPointsEnableCheckbox.Checked = Settings.Default.focus_points_enable;
            this.focusBorderEnableCheckbox.Checked = Settings.Default.focus_border_enable;

            this.notificationPointsEnableCheckBox.Checked = Settings.Default.notifications_points_enable;
            this.notificationBorderEnableCheckBox.Checked = Settings.Default.notifications_border_enable;

            this.lastFivePointsEnableCheckbox.Checked = Settings.Default.last_five_points_enable;
            this.lastFiveBorderEnableCheckbox.Checked = Settings.Default.last_five_border_enable;

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
                this.notificationsAchievementAnimationInComboBox.Items.Add(animationDirection.ToString());
                this.notificationsAchievementAnimationOutComboBox.Items.Add(animationDirection.ToString());
                this.notificationsMasteryAnimationInComboBox.Items.Add(animationDirection.ToString());
                this.notificationsMasteryAnimationOutComboBox.Items.Add(animationDirection.ToString());
            });

            this.notificationsAchievementAnimationInComboBox.SelectedIndex = this.notificationsAchievementAnimationInComboBox.Items.IndexOf(Settings.Default.notifications_achievement_in_animation);
            this.notificationsAchievementAnimationOutComboBox.SelectedIndex = this.notificationsAchievementAnimationOutComboBox.Items.IndexOf(Settings.Default.notifications_achievement_out_animation);
            this.notificationsMasteryAnimationInComboBox.SelectedIndex = this.notificationsMasteryAnimationInComboBox.Items.IndexOf(Settings.Default.notifications_mastery_in_animation);
            this.notificationsMasteryAnimationOutComboBox.SelectedIndex = this.notificationsMasteryAnimationOutComboBox.Items.IndexOf(Settings.Default.notifications_mastery_out_animation);

            this.customAchievementEnableCheckbox.Checked = AlertController.Instance.CustomAchievementEnabled;
            this.selectCustomAchievementButton.Enabled = AlertController.Instance.CustomAchievementEnabled;
            this.acheivementEditOutlineCheckbox.Enabled = AlertController.Instance.CustomAchievementEnabled;

            this.useCustomMasteryCheckbox.Checked = AlertController.Instance.CustomMasteryEnabled;
            this.selectCustomMasteryNotificationButton.Enabled = AlertController.Instance.CustomMasteryEnabled;
            this.masteryEditOultineCheckbox.Enabled = AlertController.Instance.CustomMasteryEnabled;

            this.customAchievementXNumericUpDown.Value = AlertController.Instance.CustomAchievementX;
            this.customAchievementYNumericUpDown.Value = AlertController.Instance.CustomAchievementY;

            this.customMasteryXNumericUpDown.Value = AlertController.Instance.CustomMasteryX;
            this.customMasteryYNumericUpDown.Value = AlertController.Instance.CustomMasteryY;

            if (AlertController.Instance.CustomAchievementScale > this.scaleAchievementNumericUpDown.Maximum)
            {
                AlertController.Instance.CustomAchievementScale = this.scaleAchievementNumericUpDown.Maximum;
            }
            if (AlertController.Instance.CustomMasteryScale > this.scaleMasteryNumericUpDown.Maximum)
            {
                AlertController.Instance.CustomMasteryScale = this.scaleMasteryNumericUpDown.Maximum;
            }
            this.scaleAchievementNumericUpDown.Value = AlertController.Instance.CustomAchievementScale;
            this.scaleMasteryNumericUpDown.Value = AlertController.Instance.CustomMasteryScale;

            this.notificationAchievementInNumericUpDown.Value = AlertController.Instance.CustomAchievementIn;
            this.notificationAchievementOutNumericUpDown.Value = AlertController.Instance.CustomAchievementOut;
            this.notificationMasteryInNumericUpDown.Value = AlertController.Instance.CustomMasteryIn;
            this.notificationMasteryOutNumericUpDown.Value = AlertController.Instance.CustomMasteryOut;
            this.customAchievementInSpeedUpDown.Value = AlertController.Instance.CustomAchievementInSpeed;
            this.customAchievementOutSpeedUpDown.Value = AlertController.Instance.CustomAchievementOutSpeed;
            this.customMasteryInSpeedUpDown.Value = AlertController.Instance.CustomMasteryInSpeed;
            this.customMasteryOutSpeedUpDown.Value = AlertController.Instance.CustomMasteryOutSpeed;

            this.usernameTextBox.TextChanged += RequiredField_TextChange;
            this.apiKeyTextBox.TextChanged += RequiredField_TextChange;

            this.statsGameAchievementsOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            this.statsGamePointsOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            this.statsGameTruePointsOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            this.statsCompletedOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            this.statsGameRatioOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            this.statsTruePointsOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            this.statsPointsOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            this.statsRatioOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            this.statsAwardsOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            this.statsRankOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;

            this.gameInfoGenreOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            this.gameInfoConsoleOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            this.gameInfoDeveloperOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            this.gameInfoReleaseDateOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            this.gameInfoPublisherOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;
            this.gameInfoTitleOverrideTextBox.TextChanged += OverrideTextBox_TextChanged;

            this.statsDefaultButton.Click += StatsDefaultButton_Click;

            this.fontOutlineCheckBox.CheckedChanged += FontOutlineCheckBox_CheckedChanged;
            this.fontColorButton.Click += FontColorButton_Click;
            this.fontOutlineColorButton.Click += FontOutlineColorButton_Click;
            this.backgroundColorButton.Click += BackgroundColorButton_Click;

            this.autoStartCheckbox.CheckedChanged += AutoLaunchCheckbox_CheckedChanged;
            this.autoLaunchLastFiveWindowCheckbox.CheckedChanged += AutoLaunchCheckbox_CheckedChanged;
            this.autoLaunchGameInfoWindowCheckbox.CheckedChanged += AutoLaunchCheckbox_CheckedChanged;
            this.autoLaunchNotificationsWindowCheckbox.CheckedChanged += AutoLaunchCheckbox_CheckedChanged;
            this.autoLaunchFocusWindowCheckBox.CheckedChanged += AutoLaunchCheckbox_CheckedChanged;
            this.autoLaunchStatsWindowCheckbox.CheckedChanged += AutoLaunchCheckbox_CheckedChanged;

            this.customAchievementEnableCheckbox.CheckedChanged += CustomAchievementEnableCheckbox_CheckedChanged;
            this.useCustomMasteryCheckbox.CheckedChanged += CustomMasteryEnableCheckbox_CheckedChanged;
            this.acheivementEditOutlineCheckbox.CheckedChanged += AcheivementEditOutlineCheckbox_CheckedChanged;
            this.masteryEditOultineCheckbox.CheckedChanged += MasteryEditOultineCheckbox_CheckedChanged;

            this.focusPointsEnableCheckbox.CheckedChanged += OverrideEnableCheckBox_CheckedChanged;
            this.focusBorderEnableCheckbox.CheckedChanged += OverrideEnableCheckBox_CheckedChanged;
            this.lastFivePointsEnableCheckbox.CheckedChanged += OverrideEnableCheckBox_CheckedChanged;
            this.lastFiveBorderEnableCheckbox.CheckedChanged += OverrideEnableCheckBox_CheckedChanged;
            this.notificationPointsEnableCheckBox.CheckedChanged += OverrideEnableCheckBox_CheckedChanged;
            this.notificationBorderEnableCheckBox.CheckedChanged += OverrideEnableCheckBox_CheckedChanged;

            this.statsRankCheckBox.CheckedChanged += OverrideEnableCheckBox_CheckedChanged;
            this.statsAwardsCheckBox.CheckedChanged += OverrideEnableCheckBox_CheckedChanged;
            this.statsCompletedCheckBox.CheckedChanged += OverrideEnableCheckBox_CheckedChanged;
            this.statsPointsCheckBox.CheckedChanged += OverrideEnableCheckBox_CheckedChanged;
            this.statsTruePointsCheckBox.CheckedChanged += OverrideEnableCheckBox_CheckedChanged;
            this.statsRatioCheckBox.CheckedChanged += OverrideEnableCheckBox_CheckedChanged;
            this.statsGameRatioCheckBox.CheckedChanged += OverrideEnableCheckBox_CheckedChanged;
            this.statsGamePointsCheckBox.CheckedChanged += OverrideEnableCheckBox_CheckedChanged;
            this.statsGameTruePointsCheckBox.CheckedChanged += OverrideEnableCheckBox_CheckedChanged;
            this.statsGameAchievementsCheckBox.CheckedChanged += OverrideEnableCheckBox_CheckedChanged;

            this.gameInfoConsoleCheckBox.CheckedChanged += OverrideEnableCheckBox_CheckedChanged;
            this.gameInfoDeveloperCheckBox.CheckedChanged += OverrideEnableCheckBox_CheckedChanged;
            this.gameInfoPublisherCheckBox.CheckedChanged += OverrideEnableCheckBox_CheckedChanged;
            this.gameInfoGenreCheckBox.CheckedChanged += OverrideEnableCheckBox_CheckedChanged;
            this.gameInfoReleaseDateCheckBox.CheckedChanged += OverrideEnableCheckBox_CheckedChanged;
            this.gameInfoTitleCheckBox.CheckedChanged += OverrideEnableCheckBox_CheckedChanged;

            this.focusStreamLabelsCheckBox.CheckedChanged += StreamLabelsCheckBox_CheckedChanged;
            this.lastFiveStreamLabelsCheckBox.CheckedChanged += StreamLabelsCheckBox_CheckedChanged;
            this.statsStreamLabelsCheckBox.CheckedChanged += StreamLabelsCheckBox_CheckedChanged;
            this.gameInfoStreamLabelsCheckBox.CheckedChanged += StreamLabelsCheckBox_CheckedChanged;

            this.fontFamilyComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;

            this.statsRadioButtonBackslash.CheckedChanged += RadioButtonBackslash_CheckedChanged;
            this.statsRadioButtonSemicolon.CheckedChanged += RadioButtonBackslash_CheckedChanged;
            this.statsRadioButtonDot.CheckedChanged += RadioButtonBackslash_CheckedChanged;
            this.statsUsePercentCheckBox.CheckedChanged += StatsUsePercentCheckBox_CheckedChanged;

            this.notificationsAchievementAnimationInComboBox.SelectedIndexChanged += NotificationAnimationComboBox_SelectedIndexChanged;
            this.notificationsAchievementAnimationOutComboBox.SelectedIndexChanged += NotificationAnimationComboBox_SelectedIndexChanged;
            this.notificationsMasteryAnimationInComboBox.SelectedIndexChanged += NotificationAnimationComboBox_SelectedIndexChanged;
            this.notificationsMasteryAnimationOutComboBox.SelectedIndexChanged += NotificationAnimationComboBox_SelectedIndexChanged;

            this.showLastFiveWindowButton.Click += ShowWindowButton_Click;
            this.showGameInfoWindowButton.Click += ShowWindowButton_Click;
            this.showNotificationWindowButton.Click += ShowWindowButton_Click;
            this.showFocusWindowButton.Click += ShowWindowButton_Click;
            this.showStatsWindowButton.Click += ShowWindowButton_Click;

            this.startButton.Click += StartButton_Click;
            this.stopButton.Click += StopButton_Click;
            this.hideButton.Click += HideButton_Click;

            this.setFocusButton.Click += SetFocusButton_Click;
            this.hideFocusButton.Click += HideFocusButton_Click;
            this.focusAchievementButtonLeft.Click += MoveFocusIndexLeft;
            this.focusAchievementButtonRight.Click += MoveFocusIndexRight;

            this.customizeLastFiveButton.Click += CustomizeLastFiveButton_Click;
            this.customizeGameInfoButton.Click += CustomizeGameInfoButton_Click;
            this.customizeAlertsButton.Click += CustomizeAlertsButton_Click;
            this.customizeFocusButton.Click += CustomizeFocusButton_Click;
            this.customizeStatsButton.Click += CustomizeStatsButton_Click;

            this.showAchievementButton.Click += ShowAchievementButton_Click;
            this.showGameMasteryButton.Click += ShowGameMasteryButton_Click;
            this.selectCustomAchievementButton.Click += SelectCustomAchievementButton_Click;
            this.selectCustomMasteryNotificationButton.Click += SelectCustomMasteryNotificationButton_Click;

            this.scaleAchievementNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            this.scaleMasteryNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            this.fontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            this.customAchievementXNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            this.customAchievementYNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            this.customAchievementInSpeedUpDown.ValueChanged += CustomeAnimationSpeedUpDown_ValueChanged;
            this.customAchievementOutSpeedUpDown.ValueChanged += CustomeAnimationSpeedUpDown_ValueChanged;
            this.customMasteryXNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            this.customMasteryYNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            this.customMasteryInSpeedUpDown.ValueChanged += CustomeAnimationSpeedUpDown_ValueChanged;
            this.customMasteryOutSpeedUpDown.ValueChanged += CustomeAnimationSpeedUpDown_ValueChanged;
            this.notificationAchievementOutNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            this.notificationAchievementInNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            this.notificationMasteryOutNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            this.notificationMasteryInNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
        }

        private async Task<int> GetAwardCount()
        {
            UpdateTimerLabel("Getting award count directly from site.");
            try
            {
                string url = "http://retroachievements.org/user/" + usernameTextBox.Text;

                HtmlWeb web = new HtmlWeb();

                HtmlAgilityPack.HtmlDocument doc = await web.LoadFromWebAsync(url);

                HtmlNode siteAwardsNode = doc.GetElementbyId("siteawards");

                if (siteAwardsNode == null)
                {
                    return 0;
                }
                this.raConnectionStatusPictureBox.Image = Resources.green_button;

                HtmlNodeCollection htmlNodeCollections = siteAwardsNode.SelectNodes(XPathExpression.Compile("//div[contains(@class,'trophyimage')]"));

                return htmlNodeCollections == null ? 0 : htmlNodeCollections.Count;
            }
            catch
            {
                return 0;
            }
        }
        private void RequiredField_TextChange(object sender, EventArgs e)
        {
            this.startButton.Enabled = CanStart();
        }

        private void AutoLaunchCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            switch (checkBox.Name)
            {
                case "autoLaunchLastFiveWindowCheckbox":
                    Settings.Default.auto_last_five = checkBox.Checked;
                    break;
                case "autoLaunchGameInfoWindowCheckbox":
                    Settings.Default.auto_game_info = checkBox.Checked;
                    break;
                case "autoStartCheckbox":
                    Settings.Default.auto_start_checked = checkBox.Checked;
                    break;
                case "autoLaunchNotificationsWindowCheckbox":
                    Settings.Default.auto_notifications = checkBox.Checked;
                    break;
                case "autoLaunchFocusWindowCheckBox":
                    Settings.Default.auto_focus = checkBox.Checked;
                    break;
                case "autoLaunchStatsWindowCheckbox":
                    Settings.Default.auto_stats = checkBox.Checked;
                    break;
            }

            Settings.Default.Save();
        }
        private void CustomAchievementEnableCheckbox_CheckedChanged(object sender, EventArgs eventArgs)
        {
            AlertController.Instance.CustomAchievementEnabled = ((CheckBox)sender).Checked;

            this.customAchievementEnableCheckbox.Checked = AlertController.Instance.CustomAchievementEnabled;
            this.selectCustomAchievementButton.Enabled = AlertController.Instance.CustomAchievementEnabled;
            this.acheivementEditOutlineCheckbox.Enabled = AlertController.Instance.CustomAchievementEnabled;

            AlertController.Instance.Reset();


        }
        private void CustomMasteryEnableCheckbox_CheckedChanged(object sender, EventArgs eventArgs)
        {
            AlertController.Instance.CustomMasteryEnabled = ((CheckBox)sender).Checked;

            this.useCustomMasteryCheckbox.Checked = AlertController.Instance.CustomMasteryEnabled;
            this.selectCustomMasteryNotificationButton.Enabled = AlertController.Instance.CustomMasteryEnabled;
            this.masteryEditOultineCheckbox.Enabled = AlertController.Instance.CustomMasteryEnabled;

            AlertController.Instance.Reset();
        }
        private void AcheivementEditOutlineCheckbox_CheckedChanged(object sender, EventArgs eventArgs)
        {
            if (((CheckBox)sender).Checked)
            {
                AlertController.Instance.EnableAchievementEdit();
                AlertController.Instance.SendAchievementNotification(new Achievement()
                {
                    Title = "Thrilling!!!!",
                    Description = "Color every bit of Dinosaur 2. [Must color white if leaving white]",
                    BadgeNumber = "49987",
                    Points = 1
                });
            }
            else
            {
                AlertController.Instance.DisableAchievementEdit();
            }
        }
        private void MasteryEditOultineCheckbox_CheckedChanged(object sender, EventArgs eventArgs)
        {
            if (((CheckBox)sender).Checked)
            {
                AlertController.Instance.EnableMasteryEdit();
            }
            else
            {
                AlertController.Instance.DisableMasteryEdit();
            }
        }

        private void CustomNumericUpDown_ValueChanged(object sender, EventArgs eventArgs)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;

            switch (numericUpDown.Name)
            {
                case "customAchievementXNumericUpDown":
                    AlertController.Instance.CustomAchievementX = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "customAchievementYNumericUpDown":
                    AlertController.Instance.CustomAchievementY = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "customMasteryXNumericUpDown":
                    AlertController.Instance.CustomMasteryX = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "customMasteryYNumericUpDown":
                    AlertController.Instance.CustomMasteryY = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "scaleAchievementNumericUpDown":
                    AlertController.Instance.CustomAchievementScale = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "scaleMasteryNumericUpDown":
                    AlertController.Instance.CustomMasteryScale = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationAchievementInNumericUpDown":
                    AlertController.Instance.CustomAchievementIn = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationAchievementOutNumericUpDown":
                    AlertController.Instance.CustomAchievementOut = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationMasteryInNumericUpDown":
                    AlertController.Instance.CustomMasteryIn = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationMasteryOutNumericUpDown":
                    AlertController.Instance.CustomMasteryOut = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "fontOutlineNumericUpDown":
                    switch (MenuState)
                    {
                        case CustomMenuState.STATS:
                            statsLayoutWindow.FontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            break;
                        case CustomMenuState.ALERTS:
                            AlertController.Instance.FontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            break;
                        case CustomMenuState.GAME_INFO:
                            gameInfoLayoutWindow.FontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            break;
                        case CustomMenuState.LAST_FIVE:
                            LastFiveController.Instance.FontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            break;
                        case CustomMenuState.FOCUS:
                            focusLayoutWindow.FontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            break;
                    }
                    break;
            }
        }
        private void SelectCustomAchievementButton_Click(object sender, EventArgs eventArgs)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                AlertController.Instance.CustomAchievementFile = this.openFileDialog1.FileName;
            }
            else
            {
                if (this.customAchievementEnableCheckbox.Checked && string.IsNullOrEmpty(AlertController.Instance.CustomAchievementFile))
                {
                    this.customAchievementEnableCheckbox.Checked = false;
                }
            }
        }
        private void SelectCustomMasteryNotificationButton_Click(object sender, EventArgs eventArgs)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                AlertController.Instance.CustomMasteryFile = this.openFileDialog1.FileName;
            }
            else
            {
                if (this.useCustomMasteryCheckbox.Checked && string.IsNullOrEmpty(AlertController.Instance.CustomMasteryFile))
                {
                    this.useCustomMasteryCheckbox.Checked = false;
                }
            }
        }

        private void CustomeAnimationSpeedUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;

            switch (numericUpDown.Name)
            {
                case "customAchievementInSpeedUpDown":
                    AlertController.Instance.CustomAchievementInSpeed = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "customAchievementOutSpeedUpDown":
                    AlertController.Instance.CustomAchievementOutSpeed = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "customMasteryInSpeedUpDown":
                    AlertController.Instance.CustomMasteryInSpeed = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "customMasteryOutSpeedUpDown":
                    AlertController.Instance.CustomMasteryOutSpeed = Convert.ToInt32(numericUpDown.Value);
                    break;
            }
        }
        private void ShowAchievementButton_Click(object sender, EventArgs eventArgs)
        {
            if (UserSummary.RecentAchievements != null
                && UserSummary.RecentAchievements.Count > 0
                && UserSummary.RecentAchievements[0] != null)
            {
                AlertController.Instance.EnqueueAchievementNotifications(new List<Achievement>() { UserSummary.RecentAchievements[0] });
            }
            else
            {
                AlertController.Instance.EnqueueAchievementNotifications(new List<Achievement>() {
                     new Achievement()
                     {
                         Title = "Thrilling!!!!",
                         Description = "Color every bit of Dinosaur 2. [Must color white if leaving white]",
                         BadgeNumber = "49987",
                         Points = 1
                     }
                });
            }
        }
        private void ShowGameMasteryButton_Click(object sender, EventArgs eventArgs)
        {
            AlertController.Instance.EnqueueMasteryNotification(UserSummary.GameSummaries[0], UserSummary.GameAchievementSummaries[0]);
        }
        private void SetFocusButton_Click(object sender, EventArgs e)
        {
            focusLayoutWindow.SetFocus(CurrentlyViewingAchievement);
        }
        private void HideFocusButton_Click(object sender, EventArgs e)
        {
            focusLayoutWindow.HideFocus();
            StreamLabelManager.ClearFocusStreamLabels();
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
                this.focusAchievementButtonLeft.Enabled = false;
                this.focusAchievementButtonRight.Enabled = false;
                this.setFocusButton.Enabled = false;
                this.hideFocusButton.Enabled = false;
            }
            else
            {
                this.setFocusButton.Enabled = true;
                this.hideFocusButton.Enabled = true;

                if (CurrentlyViewingIndex == 0)
                {
                    this.focusAchievementButtonLeft.Enabled = false;
                    this.focusAchievementButtonRight.Enabled = LockedAchievements.Count > 1;
                }
                else if (CurrentlyViewingIndex == LockedAchievements.Count - 1)
                {
                    this.focusAchievementButtonLeft.Enabled = true;
                    this.focusAchievementButtonRight.Enabled = false;
                }
                else
                {
                    this.focusAchievementButtonLeft.Enabled = true;
                    this.focusAchievementButtonRight.Enabled = true;
                }
            }
        }

        private void UpdateStatLabels()
        {
            Invoke((MethodInvoker)delegate
            {
                this.rankLabel.Text = "Rank: " + UserSummary.Rank;
                this.pointsLabel.Text = "Points: " + UserSummary.TotalPoints;
                this.awardsLabel.Text = "Awards: " + UserSummary.Awards;
                this.truePointsLabel.Text = "True Points: " + UserSummary.TotalTruePoints;
                this.ratioLabel.Text = "Ratio: " + UserSummary.RetroRatio;
            });
        }
        protected virtual void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        private void ShowWindowButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            switch (button.Name)
            {
                case "showFocusWindowButton":
                    if (focusLayoutWindow.IsDisposed)
                    {
                        focusLayoutWindow = new FocusLayoutWindow();

                        if (CurrentlyViewingAchievement != null)
                        {
                            focusLayoutWindow.SetFocus(CurrentlyViewingAchievement);
                        }
                        else
                        {
                            focusLayoutWindow.HideFocus();
                        }
                    }
                    focusLayoutWindow.Show();
                    break;
                case "showStatsWindowButton":
                    if (statsLayoutWindow.IsDisposed)
                    {
                        statsLayoutWindow = new StatsLayoutWindow();
                        UpdateStats();
                    }
                    statsLayoutWindow.Show();
                    break;
                case "showNotificationWindowButton":
                    AlertController.Instance.Show();
                    break;
                case "showGameInfoWindowButton":
                    if (gameInfoLayoutWindow.IsDisposed)
                    {
                        gameInfoLayoutWindow = new GameInfoLayoutWindow();
                        UpdateGameInfo();
                    }
                    gameInfoLayoutWindow.Show();
                    break;
                case "showLastFiveWindowButton":
                    LastFiveController.Instance.Show();
                    break;
            }
        }
        private void CustomizeStatsButton_Click(object sender, EventArgs e)
        {
            if (!MenuState.Equals(CustomMenuState.STATS))
            {
                this.lastFiveOverridesGroupBox.Hide();
                this.gameInfoOverrideSettingsGroupBox.Hide();
                this.customAchievementSettingsGroupBox.Hide();
                this.customMasterySettingsGroupBox.Hide();
                this.focusOverridesGroupBox.Hide();
                this.notificationOverridesGroupBox.Hide();

                MenuState = CustomMenuState.CLOSED;

                this.fontColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.stats_font_color_hex_code);
                this.fontOutlineCheckBox.Checked = Settings.Default.stats_font_outline_enabled;
                this.backgroundColorPictureBox.BackColor = ColorTranslator.FromHtml("#808080");
                this.backgroundColorButton.Enabled = false;

                if (this.fontOutlineCheckBox.Checked)
                {
                    this.fontOutlineNumericUpDown.Enabled = true;
                    this.fontOutlineColorPictureBox.Enabled = true;
                    this.fontOutlineColorButton.Enabled = true;

                    this.fontOutlineNumericUpDown.Value = Settings.Default.stats_font_outline_size;
                    this.fontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.stats_font_outline_color_hex);
                }
                else
                {
                    this.fontOutlineNumericUpDown.Value = 1;
                    this.fontOutlineColorPictureBox.BackColor = Color.DarkGray;

                    this.fontOutlineNumericUpDown.Enabled = false;
                    this.fontOutlineColorPictureBox.Enabled = false;
                    this.fontOutlineColorButton.Enabled = false;
                }
                this.fontFamilyComboBox.Items.Clear();

                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily fontFamily in familyArray)
                {
                    this.fontFamilyComboBox.Items.Add(fontFamily.Name);
                }
                this.fontFamilyComboBox.SelectedIndex = Array.FindIndex(familyArray, row => row.Name == statsLayoutWindow.FontFamily.Name);

                switch (statsLayoutWindow.DividerCharacter)
                {
                    case "/":
                        this.statsRadioButtonDot.Checked = false;
                        this.statsRadioButtonSemicolon.Checked = false;
                        this.statsRadioButtonBackslash.Checked = true;
                        break;
                    case ":":
                        this.statsRadioButtonDot.Checked = false;
                        this.statsRadioButtonBackslash.Checked = false;
                        this.statsRadioButtonSemicolon.Checked = true;
                        break;
                    case ".":
                        this.statsRadioButtonSemicolon.Checked = false;
                        this.statsRadioButtonBackslash.Checked = false;
                        this.statsRadioButtonDot.Checked = true;
                        break;
                }

                this.statsUsePercentCheckBox.Checked = statsLayoutWindow.UsePercentageSymbol;

                MenuState = CustomMenuState.STATS;

                this.fontSettingsGroupBox.Show();
                this.statsOverrideGroupBox.Show();
                this.ClientSize = new Size(592, 660);
                this.statsOverrideGroupBox.Location = new Point(4, 313);
            }
            else
            {
                HideAllMenuItems();
            }
        }
        private void CustomizeAlertsButton_Click(object sender, EventArgs e)
        {
            if (!MenuState.Equals(CustomMenuState.ALERTS))
            {
                this.lastFiveOverridesGroupBox.Hide();
                this.gameInfoOverrideSettingsGroupBox.Hide();
                this.statsOverrideGroupBox.Hide();
                this.focusOverridesGroupBox.Hide();

                MenuState = CustomMenuState.CLOSED;

                this.fontColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.notification_font_color_hex_code);
                this.fontOutlineCheckBox.Checked = Settings.Default.notification_font_outline_enabled;
                this.backgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.notifications_background_color);
                this.backgroundColorButton.Enabled = true;

                if (this.fontOutlineCheckBox.Checked)
                {
                    this.fontOutlineNumericUpDown.Enabled = true;
                    this.fontOutlineColorPictureBox.Enabled = true;
                    this.fontOutlineColorButton.Enabled = true;

                    this.fontOutlineNumericUpDown.Value = Settings.Default.notification_font_outline_size;
                    this.fontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.notification_font_outline_color_hex);
                }
                else
                {
                    this.fontOutlineNumericUpDown.Value = 1;
                    this.fontOutlineColorPictureBox.BackColor = Color.DarkGray;

                    this.fontOutlineNumericUpDown.Enabled = false;
                    this.fontOutlineColorPictureBox.Enabled = false;
                    this.fontOutlineColorButton.Enabled = false;
                }
                this.fontFamilyComboBox.Items.Clear();

                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily fontFamily in familyArray)
                {
                    this.fontFamilyComboBox.Items.Add(fontFamily.Name);
                }
                this.fontFamilyComboBox.SelectedIndex = Array.FindIndex(familyArray, row => row.Name == AlertController.Instance.FontFamily.Name);

                MenuState = CustomMenuState.ALERTS;

                this.fontSettingsGroupBox.Show();
                this.ClientSize = new Size(592, 660);
                this.customAchievementSettingsGroupBox.Location = new Point(4, 349);
                this.customMasterySettingsGroupBox.Location = new Point(148, 349);
                this.notificationOverridesGroupBox.Location = new Point(4, 313);
                this.customAchievementSettingsGroupBox.Show();
                this.customMasterySettingsGroupBox.Show();
                this.notificationOverridesGroupBox.Show();
            }
            else
            {
                HideAllMenuItems();
            }
        }
        private void CustomizeGameInfoButton_Click(object sender, EventArgs e)
        {
            if (!MenuState.Equals(CustomMenuState.GAME_INFO))
            {
                this.lastFiveOverridesGroupBox.Hide();
                this.customAchievementSettingsGroupBox.Hide();
                this.customMasterySettingsGroupBox.Hide();
                this.statsOverrideGroupBox.Hide();
                this.focusOverridesGroupBox.Hide();
                this.notificationOverridesGroupBox.Hide();

                MenuState = CustomMenuState.CLOSED;

                this.fontColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.game_info_font_color_hex_code);
                this.fontOutlineCheckBox.Checked = Settings.Default.game_info_font_outline_enabled;
                this.backgroundColorPictureBox.BackColor = ColorTranslator.FromHtml("#808080");
                this.backgroundColorButton.Enabled = false;

                if (this.fontOutlineCheckBox.Checked)
                {
                    this.fontOutlineNumericUpDown.Enabled = true;
                    this.fontOutlineColorPictureBox.Enabled = true;
                    this.fontOutlineColorButton.Enabled = true;

                    this.fontOutlineNumericUpDown.Value = Settings.Default.game_info_font_outline_size;
                    this.fontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.game_info_font_outline_color_hex);
                }
                else
                {
                    this.fontOutlineNumericUpDown.Value = 1;
                    this.fontOutlineColorPictureBox.BackColor = Color.DarkGray;

                    this.fontOutlineNumericUpDown.Enabled = false;
                    this.fontOutlineColorPictureBox.Enabled = false;
                    this.fontOutlineColorButton.Enabled = false;
                }
                this.fontFamilyComboBox.Items.Clear();

                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily fontFamily in familyArray)
                {
                    this.fontFamilyComboBox.Items.Add(fontFamily.Name);
                }
                this.fontFamilyComboBox.SelectedIndex = Array.FindIndex(familyArray, row => row.Name == gameInfoLayoutWindow.FontFamily.Name);

                MenuState = CustomMenuState.GAME_INFO;

                this.fontSettingsGroupBox.Show();
                this.ClientSize = new Size(592, 490);
                this.gameInfoOverrideSettingsGroupBox.Location = new Point(4, 313);
                this.gameInfoOverrideSettingsGroupBox.Show();
            }
            else
            {
                HideAllMenuItems();
            }
        }
        private void CustomizeLastFiveButton_Click(object sender, EventArgs e)
        {
            if (!MenuState.Equals(CustomMenuState.LAST_FIVE))
            {
                this.gameInfoOverrideSettingsGroupBox.Hide();
                this.customAchievementSettingsGroupBox.Hide();
                this.customMasterySettingsGroupBox.Hide();
                this.statsOverrideGroupBox.Hide();
                this.focusOverridesGroupBox.Hide();
                this.notificationOverridesGroupBox.Hide();

                MenuState = CustomMenuState.CLOSED;

                this.fontColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.last_five_font_color_hex_code);
                this.fontOutlineCheckBox.Checked = Settings.Default.last_five_font_outline_enabled;
                this.backgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.last_five_background_color);
                this.backgroundColorButton.Enabled = true;

                if (this.fontOutlineCheckBox.Checked)
                {
                    this.fontOutlineNumericUpDown.Enabled = true;
                    this.fontOutlineColorPictureBox.Enabled = true;
                    this.fontOutlineColorButton.Enabled = true;

                    this.fontOutlineNumericUpDown.Value = Settings.Default.last_five_font_outline_size;
                    this.fontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.last_five_font_outline_color_hex);
                }
                else
                {
                    this.fontOutlineNumericUpDown.Value = 1;
                    this.fontOutlineColorPictureBox.BackColor = Color.DarkGray;

                    this.fontOutlineNumericUpDown.Enabled = false;
                    this.fontOutlineColorPictureBox.Enabled = false;
                    this.fontOutlineColorButton.Enabled = false;
                }
                this.fontFamilyComboBox.Items.Clear();

                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily fontFamily in familyArray)
                {
                    this.fontFamilyComboBox.Items.Add(fontFamily.Name);
                }
                this.fontFamilyComboBox.SelectedIndex = Array.FindIndex(familyArray, row => row.Name == LastFiveController.Instance.FontFamily.Name);

                MenuState = CustomMenuState.LAST_FIVE;

                this.fontSettingsGroupBox.Show();
                this.ClientSize = new Size(592, 450);
                this.lastFiveOverridesGroupBox.Location = new Point(4, 313);
                this.lastFiveOverridesGroupBox.Show();
            }
            else
            {
                HideAllMenuItems();
            }
        }
        private void CustomizeFocusButton_Click(object sender, EventArgs e)
        {
            if (!MenuState.Equals(CustomMenuState.FOCUS))
            {
                this.lastFiveOverridesGroupBox.Hide();
                this.gameInfoOverrideSettingsGroupBox.Hide();
                this.customAchievementSettingsGroupBox.Hide();
                this.customMasterySettingsGroupBox.Hide();
                this.statsOverrideGroupBox.Hide();

                MenuState = CustomMenuState.CLOSED;

                this.fontColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.focus_font_color_hex_code);
                this.fontOutlineCheckBox.Checked = Settings.Default.focus_font_outline_enabled;
                this.backgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.focus_background_color);
                this.backgroundColorButton.Enabled = true;

                if (this.fontOutlineCheckBox.Checked)
                {
                    this.fontOutlineNumericUpDown.Enabled = true;
                    this.fontOutlineColorPictureBox.Enabled = true;
                    this.fontOutlineColorButton.Enabled = true;

                    this.fontOutlineNumericUpDown.Value = Settings.Default.focus_font_outline_size;
                    this.fontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.focus_font_outline_color_hex);
                }
                else
                {
                    this.fontOutlineNumericUpDown.Value = 1;
                    this.fontOutlineColorPictureBox.BackColor = Color.DarkGray;

                    this.fontOutlineNumericUpDown.Enabled = false;
                    this.fontOutlineColorPictureBox.Enabled = false;
                    this.fontOutlineColorButton.Enabled = false;
                }
                this.fontFamilyComboBox.Items.Clear();

                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily fontFamily in familyArray)
                {
                    this.fontFamilyComboBox.Items.Add(fontFamily.Name);
                }
                this.fontFamilyComboBox.SelectedIndex = Array.FindIndex(familyArray, row => row.Name == focusLayoutWindow.FontFamily.Name);

                MenuState = CustomMenuState.FOCUS;

                this.fontSettingsGroupBox.Show();
                this.ClientSize = new Size(592, 450);
                this.focusOverridesGroupBox.Location = new Point(4, 313);
                this.focusOverridesGroupBox.Show();
            }
            else
            {
                HideAllMenuItems();
            }
        }
        private void HideAllMenuItems()
        {
            MenuState = CustomMenuState.CLOSED;

            this.lastFiveOverridesGroupBox.Hide();
            this.fontSettingsGroupBox.Hide();
            this.gameInfoOverrideSettingsGroupBox.Hide();
            this.customAchievementSettingsGroupBox.Hide();
            this.customMasterySettingsGroupBox.Hide();
            this.statsOverrideGroupBox.Hide();
            this.notificationOverridesGroupBox.Hide();

            this.ClientSize = new Size(592, 314);
        }
        private void HideButton_Click(object sender, EventArgs e)
        {
            HideAllMenuItems();

            this.BringToFront();
            this.SendToBack();

            AlertController.Instance.Hide();
            LastFiveController.Instance.Hide();


            if (focusLayoutWindow != null && !focusLayoutWindow.IsDisposed)
            {
                focusLayoutWindow.BringToFront();
                focusLayoutWindow.Location = new Point(0, 0);
                focusLayoutWindow.SendToBack();
            }
            if (statsLayoutWindow != null && !statsLayoutWindow.IsDisposed)
            {
                statsLayoutWindow.BringToFront();
                statsLayoutWindow.Location = new Point(0, 0);
                statsLayoutWindow.SendToBack();
            }
            if (gameInfoLayoutWindow != null && !gameInfoLayoutWindow.IsDisposed)
            {
                gameInfoLayoutWindow.BringToFront();
                gameInfoLayoutWindow.Location = new Point(0, 0);
                gameInfoLayoutWindow.SendToBack();
            }
        }
        private void FontColorButton_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.fontColorPictureBox.BackColor = this.colorDialog1.Color;
                switch (MenuState)
                {
                    case CustomMenuState.STATS:
                        MenuState = CustomMenuState.CLOSED;
                        statsLayoutWindow.FontColor = MediaHelper.HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.STATS;
                        break;
                    case CustomMenuState.ALERTS:
                        MenuState = CustomMenuState.CLOSED;
                        AlertController.Instance.FontColor = MediaHelper.HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.ALERTS;
                        break;
                    case CustomMenuState.GAME_INFO:
                        MenuState = CustomMenuState.CLOSED;
                        gameInfoLayoutWindow.FontColor = MediaHelper.HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.GAME_INFO;
                        break;
                    case CustomMenuState.LAST_FIVE:
                        MenuState = CustomMenuState.CLOSED;
                        LastFiveController.Instance.FontColor = MediaHelper.HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.LAST_FIVE;
                        break;
                    case CustomMenuState.FOCUS:
                        MenuState = CustomMenuState.CLOSED;
                        focusLayoutWindow.FontColor = MediaHelper.HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.FOCUS;
                        break;
                }
            }
        }
        private void FontOutlineColorButton_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.fontOutlineColorPictureBox.BackColor = this.colorDialog1.Color;
                switch (MenuState)
                {
                    case CustomMenuState.STATS:
                        MenuState = CustomMenuState.CLOSED;
                        statsLayoutWindow.FontOutlineColor = MediaHelper.HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.STATS;
                        break;
                    case CustomMenuState.ALERTS:
                        MenuState = CustomMenuState.CLOSED;
                        AlertController.Instance.FontOutlineColor = MediaHelper.HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.ALERTS;
                        break;
                    case CustomMenuState.GAME_INFO:
                        MenuState = CustomMenuState.CLOSED;
                        gameInfoLayoutWindow.FontOutlineColor = MediaHelper.HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.GAME_INFO;
                        break;
                    case CustomMenuState.LAST_FIVE:
                        MenuState = CustomMenuState.CLOSED;
                        LastFiveController.Instance.FontOutlineColor = MediaHelper.HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.LAST_FIVE;
                        break;
                    case CustomMenuState.FOCUS:
                        MenuState = CustomMenuState.CLOSED;
                        focusLayoutWindow.FontOutlineColor = MediaHelper.HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.FOCUS;
                        break;
                }
            }
        }
        private void FontFamilyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as Control).Name.Equals("fontFamilyComboBox"))
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();
                switch (MenuState)
                {
                    case CustomMenuState.STATS:
                        MenuState = CustomMenuState.CLOSED;
                        statsLayoutWindow.FontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                        MenuState = CustomMenuState.STATS;
                        break;
                    case CustomMenuState.ALERTS:
                        MenuState = CustomMenuState.CLOSED;
                        AlertController.Instance.FontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                        MenuState = CustomMenuState.ALERTS;
                        break;
                    case CustomMenuState.GAME_INFO:
                        MenuState = CustomMenuState.CLOSED;
                        gameInfoLayoutWindow.FontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                        MenuState = CustomMenuState.GAME_INFO;
                        break;
                    case CustomMenuState.LAST_FIVE:
                        MenuState = CustomMenuState.CLOSED;
                        LastFiveController.Instance.FontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                        MenuState = CustomMenuState.LAST_FIVE;
                        break;
                    case CustomMenuState.FOCUS:
                        MenuState = CustomMenuState.CLOSED;
                        focusLayoutWindow.FontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                        MenuState = CustomMenuState.FOCUS;
                        break;
                }
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
                            AlertController.Instance.AchievementAnimationIn = AnimationDirection.DOWN;
                            break;
                        case "LEFT":
                            AlertController.Instance.AchievementAnimationIn = AnimationDirection.LEFT;
                            break;
                        case "RIGHT":
                            AlertController.Instance.AchievementAnimationIn = AnimationDirection.RIGHT;
                            break;
                        case "UP":
                            AlertController.Instance.AchievementAnimationIn = AnimationDirection.UP;
                            break;
                        default:
                            AlertController.Instance.AchievementAnimationIn = AnimationDirection.STATIC;
                            break;
                    }
                    break;
                case "notificationsAchievementAnimationOutComboBox":
                    switch ((string)this.notificationsAchievementAnimationOutComboBox.SelectedItem)
                    {
                        case "DOWN":
                            AlertController.Instance.AchievementAnimationOut = AnimationDirection.DOWN;
                            break;
                        case "LEFT":
                            AlertController.Instance.AchievementAnimationOut = AnimationDirection.LEFT;
                            break;
                        case "RIGHT":
                            AlertController.Instance.AchievementAnimationOut = AnimationDirection.RIGHT;
                            break;
                        case "UP":
                            AlertController.Instance.AchievementAnimationOut = AnimationDirection.UP;
                            break;
                        default:
                            AlertController.Instance.AchievementAnimationOut = AnimationDirection.STATIC;
                            break;
                    }
                    break;
                case "notificationsMasteryAnimationInComboBox":
                    switch ((string)this.notificationsMasteryAnimationInComboBox.SelectedItem)
                    {
                        case "DOWN":
                            AlertController.Instance.MasteryAnimationIn = AnimationDirection.DOWN;
                            break;
                        case "LEFT":
                            AlertController.Instance.MasteryAnimationIn = AnimationDirection.LEFT;
                            break;
                        case "RIGHT":
                            AlertController.Instance.MasteryAnimationIn = AnimationDirection.RIGHT;
                            break;
                        case "UP":
                            AlertController.Instance.MasteryAnimationIn = AnimationDirection.UP;
                            break;
                        default:
                            AlertController.Instance.MasteryAnimationIn = AnimationDirection.STATIC;
                            break;
                    }
                    break;
                case "notificationsMasteryAnimationOutComboBox":
                    switch ((string)this.notificationsMasteryAnimationOutComboBox.SelectedItem)
                    {
                        case "DOWN":
                            AlertController.Instance.MasteryAnimationOut = AnimationDirection.DOWN;
                            break;
                        case "LEFT":
                            AlertController.Instance.MasteryAnimationOut = AnimationDirection.LEFT;
                            break;
                        case "RIGHT":
                            AlertController.Instance.MasteryAnimationOut = AnimationDirection.RIGHT;
                            break;
                        case "UP":
                            AlertController.Instance.MasteryAnimationOut = AnimationDirection.UP;
                            break;
                        default:
                            AlertController.Instance.MasteryAnimationOut = AnimationDirection.STATIC;
                            break;
                    }
                    break;
            }
        }
        private void FontOutlineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isEnabled = this.fontOutlineCheckBox.Checked;

            this.fontOutlineNumericUpDown.Enabled = isEnabled;
            this.fontOutlineColorPictureBox.Enabled = isEnabled;
            this.fontOutlineColorButton.Enabled = isEnabled;

            switch (MenuState)
            {
                case CustomMenuState.STATS:
                    if (isEnabled)
                    {
                        MenuState = CustomMenuState.CLOSED;
                        this.fontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(statsLayoutWindow.FontOutlineColor);
                        this.fontOutlineNumericUpDown.Value = statsLayoutWindow.FontOutlineSize > this.fontOutlineNumericUpDown.Maximum ? this.fontOutlineNumericUpDown.Value : statsLayoutWindow.FontOutlineSize;
                        MenuState = CustomMenuState.STATS;
                    }
                    statsLayoutWindow.FontOutlineEnable = isEnabled;
                    break;
                case CustomMenuState.ALERTS:
                    if (isEnabled)
                    {
                        MenuState = CustomMenuState.CLOSED;
                        this.fontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertController.Instance.FontOutlineColor);
                        this.fontOutlineNumericUpDown.Value = AlertController.Instance.FontOutlineSize > this.fontOutlineNumericUpDown.Maximum ? this.fontOutlineNumericUpDown.Value : AlertController.Instance.FontOutlineSize;
                        MenuState = CustomMenuState.ALERTS;
                    }
                    AlertController.Instance.FontOutlineEnable = isEnabled;
                    break;
                case CustomMenuState.GAME_INFO:
                    if (isEnabled)
                    {
                        MenuState = CustomMenuState.CLOSED;
                        this.fontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(gameInfoLayoutWindow.FontOutlineColor);
                        this.fontOutlineNumericUpDown.Value = gameInfoLayoutWindow.FontOutlineSize > this.fontOutlineNumericUpDown.Maximum ? this.fontOutlineNumericUpDown.Value : gameInfoLayoutWindow.FontOutlineSize;
                        MenuState = CustomMenuState.GAME_INFO;
                    }
                    gameInfoLayoutWindow.FontOutlineEnable = isEnabled;
                    break;
                case CustomMenuState.LAST_FIVE:
                    if (isEnabled)
                    {
                        MenuState = CustomMenuState.CLOSED;
                        this.fontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(LastFiveController.Instance.FontOutlineColor);
                        this.fontOutlineNumericUpDown.Value = LastFiveController.Instance.FontOutlineSize > this.fontOutlineNumericUpDown.Maximum ? this.fontOutlineNumericUpDown.Value : LastFiveController.Instance.FontOutlineSize;
                        MenuState = CustomMenuState.LAST_FIVE;
                    }
                    LastFiveController.Instance.FontOutlineEnable = isEnabled;
                    break;
                case CustomMenuState.FOCUS:
                    if (isEnabled)
                    {
                        MenuState = CustomMenuState.CLOSED;
                        this.fontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(focusLayoutWindow.FontOutlineColor);
                        this.fontOutlineNumericUpDown.Value = focusLayoutWindow.FontOutlineSize > this.fontOutlineNumericUpDown.Maximum ? this.fontOutlineNumericUpDown.Value : focusLayoutWindow.FontOutlineSize;
                        MenuState = CustomMenuState.FOCUS;
                    }
                    focusLayoutWindow.FontOutlineEnable = isEnabled;
                    break;
            }
            Settings.Default.Save();
        }
        private void BackgroundColorButton_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.backgroundColorPictureBox.BackColor = this.colorDialog1.Color;
                switch (MenuState)
                {
                    case CustomMenuState.ALERTS:
                        MenuState = CustomMenuState.CLOSED;
                        AlertController.Instance.BackgroundColor = MediaHelper.HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.ALERTS;
                        break;
                    case CustomMenuState.LAST_FIVE:
                        MenuState = CustomMenuState.CLOSED;
                        LastFiveController.Instance.BackgroundColor = MediaHelper.HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.LAST_FIVE;
                        break;
                    case CustomMenuState.FOCUS:
                        MenuState = CustomMenuState.CLOSED;
                        focusLayoutWindow.BackgroundColor = MediaHelper.HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.FOCUS;
                        break;
                }
            }
        }
        private void StreamLabelsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                CheckBox checkBox = sender as CheckBox;

                switch (checkBox.Name)
                {
                    case "focusStreamLabelsCheckBox":
                        StreamLabelManager.StreamLabelsFocusEnable = this.focusStreamLabelsCheckBox.Checked;
                        StreamLabelManager.WriteFocusStreamLabels(focusLayoutWindow.CurrentlyFocusedAchievement);
                        break;
                    case "statsStreamLabelsCheckBox":
                        StreamLabelManager.StreamLabelsStatsEnable = this.statsStreamLabelsCheckBox.Checked;
                        StreamLabelManager.WriteStatsStreamLabels(UserSummary, GameProgress);
                        break;
                    case "gameInfoStreamLabelsCheckBox":
                        StreamLabelManager.StreamLabelsGameInfoEnable = this.gameInfoStreamLabelsCheckBox.Checked;
                        StreamLabelManager.WriteGameInfoStreamLabels(GameProgress);
                        break;
                    case "lastFiveStreamLabelsCheckBox":
                        StreamLabelManager.StreamLabelsLastFiveEnable = this.lastFiveStreamLabelsCheckBox.Checked;
                        StreamLabelManager.WriteLastFiveStreamLabels(UserSummary);
                        break;
                }

            }
        }
        private void GameInfoDefaultButton_Click(object sender, EventArgs e)
        {
            this.gameInfoConsoleCheckBox.Checked = true;
            this.gameInfoDeveloperCheckBox.Checked = true;
            this.gameInfoPublisherCheckBox.Checked = true;
            this.gameInfoGenreCheckBox.Checked = true;
            this.gameInfoReleaseDateCheckBox.Checked = true;
            this.gameInfoTitleCheckBox.Checked = true;

            this.gameInfoConsoleOverrideTextBox.Text = "Console";
            this.gameInfoDeveloperOverrideTextBox.Text = "Developer";
            this.gameInfoPublisherOverrideTextBox.Text = "Publisher";
            this.gameInfoGenreOverrideTextBox.Text = "Genre";
            this.gameInfoReleaseDateOverrideTextBox.Text = "Released";
            this.gameInfoTitleOverrideTextBox.Text = "Title";
        }
        private void StatsDefaultButton_Click(object sender, EventArgs e)
        {
            this.statsRankCheckBox.Checked = true;
            this.statsAwardsCheckBox.Checked = true;
            this.statsPointsCheckBox.Checked = true;
            this.statsTruePointsCheckBox.Checked = true;
            this.statsRatioCheckBox.Checked = true;
            this.statsGameRatioCheckBox.Checked = true;
            this.statsGamePointsCheckBox.Checked = true;
            this.statsGameTruePointsCheckBox.Checked = true;
            this.statsGameAchievementsCheckBox.Checked = true;
            this.statsCompletedCheckBox.Checked = true;

            this.statsRankOverrideTextBox.Text = "Rank";
            this.statsAwardsOverrideTextBox.Text = "Awards";
            this.statsPointsOverrideTextBox.Text = "Points";
            this.statsTruePointsOverrideTextBox.Text = "True Points";
            this.statsRatioOverrideTextBox.Text = "Ratio";
            this.statsGameRatioOverrideTextBox.Text = "Ratio";
            this.statsGamePointsOverrideTextBox.Text = "Points";
            this.statsGameTruePointsOverrideTextBox.Text = "True Points";
            this.statsGameAchievementsOverrideTextBox.Text = "Cheevos";
            this.statsCompletedOverrideTextBox.Text = "Compeleted";
        }
        private void OverrideEnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                CheckBox checkBox = sender as CheckBox;

                switch (checkBox.Name)
                {
                    case "statsRankCheckBox":
                        statsLayoutWindow.RankEnable = checkBox.Checked;
                        break;
                    case "statsPointsCheckBox":
                        statsLayoutWindow.PointsEnable = checkBox.Checked;
                        break;
                    case "statsAwardsCheckBox":
                        statsLayoutWindow.AwardsEnable = checkBox.Checked;
                        break;
                    case "statsTruePointsCheckBox":
                        statsLayoutWindow.TruePointsEnable = checkBox.Checked;
                        break;
                    case "statsRatioCheckBox":
                        statsLayoutWindow.RatioEnable = checkBox.Checked;
                        break;
                    case "statsGameRatioCheckBox":
                        statsLayoutWindow.GameRatioEnable = checkBox.Checked;
                        break;
                    case "statsGamePointsCheckBox":
                        statsLayoutWindow.GamePointsEnable = checkBox.Checked;
                        break;
                    case "statsGameTruePointsCheckBox":
                        statsLayoutWindow.GameTruePointsEnable = checkBox.Checked;
                        break;
                    case "statsGameAchievementsCheckBox":
                        statsLayoutWindow.GameAchievementsEnable = checkBox.Checked;
                        break;
                    case "statsCompletedCheckBox":
                        statsLayoutWindow.CompletedEnable = checkBox.Checked;
                        break;
                    case "gameInfoTitleCheckBox":
                        gameInfoLayoutWindow.TitleEnable = checkBox.Checked;
                        break;
                    case "gameInfoConsoleCheckBox":
                        gameInfoLayoutWindow.ConsoleEnable = checkBox.Checked;
                        break;
                    case "gameInfoDeveloperCheckBox":
                        gameInfoLayoutWindow.DeveloperEnable = checkBox.Checked;
                        break;
                    case "gameInfoPublisherCheckBox":
                        gameInfoLayoutWindow.PublisherEnable = checkBox.Checked;
                        break;
                    case "gameInfoGenreCheckBox":
                        gameInfoLayoutWindow.GenreEnable = checkBox.Checked;
                        break;
                    case "gameInfoReleaseDateCheckBox":
                        gameInfoLayoutWindow.ReleaseDateEnable = checkBox.Checked;
                        break;
                    case "focusPointsEnableCheckbox":
                        focusLayoutWindow.PointsEnable = checkBox.Checked;
                        break;
                    case "focusBorderEnableCheckbox":
                        focusLayoutWindow.BorderEnable = checkBox.Checked;
                        break;
                    case "notificationPointsEnableCheckBox":
                        AlertController.Instance.PointsEnable = checkBox.Checked;
                        break;
                    case "notificationBorderEnableCheckBox":
                        AlertController.Instance.BorderEnable = checkBox.Checked;
                        break;
                    case "lastFivePointsEnableCheckbox":
                        LastFiveController.Instance.PointsEnable = checkBox.Checked;
                        break;
                    case "lastFiveBorderEnableCheckbox":
                        LastFiveController.Instance.BorderEnable = checkBox.Checked;
                        break;
                }
            }
        }
        private void OverrideTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                TextBox textBox = sender as TextBox;

                switch (textBox.Name)
                {
                    case "statsRankOverrideTextBox":
                        statsLayoutWindow.RankName = textBox.Text;
                        break;
                    case "statsCompletedOverrideTextBox":
                        statsLayoutWindow.CompletedName = textBox.Text;
                        break;
                    case "statsPointsOverrideTextBox":
                        statsLayoutWindow.PointsName = textBox.Text;
                        break;
                    case "statsAwardsOverrideTextBox":
                        statsLayoutWindow.AwardsName = textBox.Text;
                        break;
                    case "statsTruePointsOverrideTextBox":
                        statsLayoutWindow.TruePointsName = textBox.Text;
                        break;
                    case "statsRatioOverrideTextBox":
                        statsLayoutWindow.RatioName = textBox.Text;
                        break;
                    case "statsGameRatioOverrideTextBox":
                        statsLayoutWindow.GameRatioName = textBox.Text;
                        break;
                    case "statsGamePointsOverrideTextBox":
                        statsLayoutWindow.GamePointsName = textBox.Text;
                        break;
                    case "statsGameTruePointsOverrideTextBox":
                        statsLayoutWindow.GameTruePointsName = textBox.Text;
                        break;
                    case "statsGameAchievementsOverrideTextBox":
                        statsLayoutWindow.GameAchievementsName = textBox.Text;
                        break;
                    case "gameInfoConsoleOverrideTextBox":
                        gameInfoLayoutWindow.ConsoleName = textBox.Text;
                        break;
                    case "gameInfoDeveloperOverrideTextBox":
                        gameInfoLayoutWindow.DeveloperName = textBox.Text;
                        break;
                    case "gameInfoPublisherOverrideTextBox":
                        gameInfoLayoutWindow.PublisherName = textBox.Text;
                        break;
                    case "gameInfoGenreOverrideTextBox":
                        gameInfoLayoutWindow.GenreName = textBox.Text;
                        break;
                    case "gameInfoReleaseDateOverrideTextBox":
                        gameInfoLayoutWindow.ReleaseDateName = textBox.Text;
                        break;
                    case "gameInfoTitleOverrideTextBox":
                        gameInfoLayoutWindow.TitleName = textBox.Text;
                        break;
                }
            }
        }

        private void RadioButtonBackslash_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                RadioButton radioButton = sender as RadioButton;

                if (radioButton.Checked)
                {
                    switch (radioButton.Name)
                    {
                        case "statsRadioButtonBackslash":
                            this.statsRadioButtonDot.Checked = false;
                            this.statsRadioButtonSemicolon.Checked = false;
                            statsLayoutWindow.DividerCharacter = "/";
                            break;
                        case "statsRadioButtonSemicolon":
                            this.statsRadioButtonDot.Checked = false;
                            this.statsRadioButtonBackslash.Checked = false;
                            statsLayoutWindow.DividerCharacter = ":";
                            break;
                        case "statsRadioButtonDot":
                            this.statsRadioButtonSemicolon.Checked = false;
                            this.statsRadioButtonBackslash.Checked = false;
                            statsLayoutWindow.DividerCharacter = ".";
                            break;
                    }
                }
            }
        }
        private void StatsUsePercentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;

            statsLayoutWindow.UsePercentageSymbol = checkbox.Checked;
        }
    }
    public enum CustomMenuState
    {
        CLOSED,
        FOCUS,
        STATS,
        ALERTS,
        GAME_INFO,
        LAST_FIVE
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