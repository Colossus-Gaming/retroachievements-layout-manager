using AutoUpdaterDotNET;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.ServiceModel;
using System.Xml;
using System.ServiceModel.Syndication;
using CefSharp.Web;
using System.Threading.Tasks;

namespace Retro_Achievement_Tracker
{
    public partial class MainPage : Form
    {
        private UserSummary UserSummary { get; set; }
        private GameInfo GameInfo { get; set; }
        private Achievement CurrentlyViewingAchievement;
        private List<ListViewItem> ListViewItems;
        private int CurrentlyViewingIndex;
        private bool UpdatingVisibility;
        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;

        private List<Achievement> LockedAchievements
        {
            get
            {
                if (GameInfo != null && GameInfo.Achievements != null)
                {
                    return GameInfo.Achievements.FindAll(x => !x.HardcoreAchieved);
                }
                return new List<Achievement>();
            }
        }

        private List<Achievement> UnlockedAchievements
        {
            get
            {
                if (GameInfo != null && GameInfo.Achievements != null)
                {
                    return GameInfo.Achievements.FindAll(x => x.HardcoreAchieved);
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
            AutoUpdate();
            InitializeComponent();

            ListViewItems = new List<ListViewItem>();

            rssFeedListView.ListViewItemSorter = Comparer<ListViewItem>.Create((item1, item2) => DateTime.Parse(item2.SubItems[1].Text).CompareTo(DateTime.Parse(item1.SubItems[1].Text)));            
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

            if (Settings.Default.web_browser_auto_launch)
            {
                MenuState = CustomMenuState.WEB_BROWSER;
            }

            UpdateGroupBoxVisibility();
        }

        private void UpdateGameProgress(bool sameGame)
        {
            try
            {
                SortAchievements(sameGame);

                if (sameGame)
                {
                    List<Achievement> achievementNotificationList = UnlockedAchievements
                    .FindAll(unlockedAchievement => !OldUnlockedAchievements.Contains(unlockedAchievement))
                    .ToList();

                    achievementNotificationList.ForEach((achievement) => StreamLabelManager.Instance.EnqueueAlert(achievement));

                    if (achievementNotificationList.Count > 0)
                    {
                        UpdateTimerLabel("CHEEVOS POP!");


                        achievementNotificationList.Sort();

                        AlertsController.Instance.EnqueueAchievementNotifications(achievementNotificationList);

                        if (!achievementNotificationList.Contains(CurrentlyViewingAchievement))
                        {
                            CurrentlyViewingIndex = LockedAchievements.IndexOf(CurrentlyViewingAchievement);
                        }

                        if (UnlockedAchievements.Count == GameInfo.Achievements.Count && OldUnlockedAchievements.Count < GameInfo.Achievements.Count)
                        {
                            AlertsController.Instance.EnqueueMasteryNotification(GameInfo);
                            StreamLabelManager.Instance.EnqueueAlert(GameInfo);
                        }

                        AlertsController.Instance.RunNotifications();

                        UpdateCurrentlyViewingAchievement();
                        SetFocus();
                    }
                }
                else
                {
                    UpdateTimerLabel("Changing game to [" + GameInfo.Title + "]");

                    CurrentlyViewingAchievement = null;
                    CurrentlyViewingIndex = 0;

                    UpdateCurrentlyViewingAchievement();
                    UpdateGameInfo();

                    SetFocus();
                }

                UpdateAchievementList(!sameGame);
                UpdateRecentAchievements();
                UpdateGameInfo();
                UpdateUserInfo();

                StreamLabelManager.Instance.RunNotifications();
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

                if (FocusController.Instance.GetCurrentlyFocusedAchievement() == null || FocusController.Instance.GetCurrentlyFocusedAchievement().Id != CurrentlyViewingAchievement.Id)
                {
                    FocusController.Instance.SetFocus(CurrentlyViewingAchievement);
                    StreamLabelManager.Instance.EnqueueFocus(CurrentlyViewingAchievement);
                }
            }
            else if (LockedAchievements.Count == 0 && UnlockedAchievements.Count > 0)
            {
                FocusController.Instance.SetFocus((Achievement)null);
                FocusController.Instance.SetFocus(GameInfo);

                StreamLabelManager.Instance.ClearFocus();
            }
            else
            {
                StreamLabelManager.Instance.ClearFocus();
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

                try
                {
                    int previousId = -1;

                    if (UserSummary != null && UserSummary.LastGameID > 0)
                    {
                        previousId = UserSummary.LastGameID;
                    }

                    if (UnlockedAchievements != null)
                    {
                        OldUnlockedAchievements = UnlockedAchievements.ToList();
                    }

                    UpdateTimerLabel("Updating user info");
                    UserSummary = await retroAchievementsAPIClient.GetUserSummary();

                    if (UserSummary == null)
                    {
                        StartTimer();
                        return;
                    }

                    List<GameCompleted> gamesCompleted = await retroAchievementsAPIClient.GetCompletedGames();
                    UserSummary.Awards = gamesCompleted.FindAll(x => x.HardcoreMode && x.AchievementsEarned == x.AchievementsPossible).Count;

                    UpdateTimerLabel("Updating game info");
                    GameInfo = await retroAchievementsAPIClient.GetGameInfo(UserSummary.LastGameID);

                    UpdateTimerLabel("Updating tracker");
                    UpdateGameProgress(previousId == UserSummary.LastGameID);

                    this.raConnectionStatusPictureBox.Image = Resources.green_button;
                    userProfilePictureBox.ImageLocation = "https://retroachievements.org/UserPic/" + usernameTextBox.Text + ".png";

                    if (Settings.Default.rss_forum_feed || Settings.Default.rss_friend_feed || Settings.Default.rss_news_feed || Settings.Default.rss_new_achievements_feed)
                    {
                        UpdateTimerLabel("Updating RSS feed");

                        await CheckRSSFeeds();
                    }
                    StartTimer();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
        private void SortAchievements(bool sameGame)
        {
            if (GameInfo.Achievements != null)
            {
                GameInfo.Achievements.ForEach(achievement =>
                {
                    Achievement otherAchievement = UserSummary.Achievements.Find(achievement1 => achievement.Id == achievement1.Id);

                    if (otherAchievement != null)
                    {
                        achievement.GameId = otherAchievement.GameId;
                        achievement.GameTitle = otherAchievement.GameTitle;
                    }
                });

                if (sameGame && OldUnlockedAchievements.Count < UnlockedAchievements.Count)
                {
                    if (LockedAchievements.IndexOf(FocusController.Instance.CurrentlyFocusedAchievement) > -1)
                    {
                        CurrentlyViewingIndex = LockedAchievements.IndexOf(FocusController.Instance.CurrentlyFocusedAchievement);
                    }
                    else
                    {
                        CurrentlyViewingIndex = LockedAchievements.IndexOf(CurrentlyViewingAchievement) == -1 ? 0 : LockedAchievements.IndexOf(CurrentlyViewingAchievement);
                    }
                }
            }
        }
        public void UpdateCurrentlyViewingAchievement()
        {
            if (Visible)
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
                    focusAchievementTitleLabel.Text = "[" + CurrentlyViewingAchievement.Points + "]\n\n" + CurrentlyViewingAchievement.Title;
                    focusAchievementDescriptionLabel.Text = CurrentlyViewingAchievement.Description;
                }
                else
                {
                    CurrentlyViewingIndex = 0;
                    CurrentlyViewingAchievement = null;

                    focusAchievementPictureBox.ImageLocation = string.Empty;
                    focusAchievementTitleLabel.Text = string.Empty;
                    focusAchievementDescriptionLabel.Text = string.Empty;
                }

                UpdateFocusButtons();
            }
        }

        private void RefreshRSSFeed()
        {
            foreach (ListViewItem item in ListViewItems)
            {
                if (((item.Text.Contains("[FORUM] ") && Settings.Default.rss_forum_feed)
                    || (item.Text.Contains("[NEWS] ") && Settings.Default.rss_news_feed)
                    || (item.Text.Contains("[FRIEND] ") && Settings.Default.rss_friend_feed)
                    || (item.Text.Contains("[CHEEVO] ") && Settings.Default.rss_new_achievements_feed)) && rssFeedListView.FindItemWithText(item.Text) == null)
                {
                    rssFeedListView.Items.Add(item);
                }
            }

            rssFeedListView.Sort();
        }
        private async Task CheckRSSFeeds()
        {
            Dictionary<string, SyndicationItem> syndicationItems = new Dictionary<string, SyndicationItem>();

            List<ListViewItem> newListViewItems = new List<ListViewItem>();

            XmlReader newsReader;
            SyndicationFeed feed;

            if (Settings.Default.rss_news_feed)
            {
                await retroAchievementsAPIClient.GetNewsFeed().ContinueWith(result =>
                {
                    newsReader = XmlReader.Create(new StringReader(result.Result));
                    feed = SyndicationFeed.Load(newsReader);

                    newsReader.Close();

                    foreach (SyndicationItem item in feed.Items)
                    {
                        if (ListViewItems.Find(potentialItem => potentialItem.Text.Equals("[NEWS] " + item.Title.Text)) == null)
                        {
                            syndicationItems.Add("[NEWS] " + item.Title.Text, item);
                        }
                    }
                });
            }

            if (Settings.Default.rss_new_achievements_feed)
            {
                await retroAchievementsAPIClient.GetNewAchievementsFeed().ContinueWith(result =>
                {
                    newsReader = XmlReader.Create(new StringReader(result.Result));
                    feed = SyndicationFeed.Load(newsReader);

                    newsReader.Close();

                    foreach (SyndicationItem item in feed.Items)
                    {
                        if (ListViewItems.Find(potentialItem => potentialItem.Text.Equals("[CHEEVO] " + item.Title.Text)) == null)
                        {
                            syndicationItems.Add("[CHEEVO] " + item.Title.Text, item);
                        }
                    }
                });
            }

            if (Settings.Default.rss_forum_feed)
            {
                await retroAchievementsAPIClient.GetForumActivityFeed().ContinueWith(result =>
                {
                    newsReader = XmlReader.Create(new StringReader(result.Result));
                    feed = SyndicationFeed.Load(newsReader);

                    newsReader.Close();

                    foreach (SyndicationItem item in feed.Items)
                    {
                        if (ListViewItems.Find(potentialItem => potentialItem.Text.Equals("[FORUM] " + item.Title.Text + " " + item.PublishDate.ToString())) == null
                            && !syndicationItems.ContainsKey("[FORUM] " + item.Title.Text + " " + item.PublishDate.ToString()))
                        {
                            try
                            {
                                syndicationItems.Add("[FORUM] " + item.Title.Text + " " + item.PublishDate.ToString(), item);
                            }
                            catch
                            {
                            }
                        }
                    }
                });
            }

            if (Settings.Default.rss_friend_feed)
            {
                await retroAchievementsAPIClient.GetFriendActivityFeed().ContinueWith(result =>
                {
                    newsReader = XmlReader.Create(new StringReader(result.Result));
                    feed = SyndicationFeed.Load(newsReader);

                    newsReader.Close();

                    foreach (SyndicationItem item in feed.Items)
                    {
                        if (ListViewItems.Find(potentialItem => potentialItem.Text.Equals("[FRIEND] " + item.Title.Text + " " + item.PublishDate.ToString())) == null)
                        {
                            syndicationItems.Add("[FRIEND] " + item.Title.Text, item);
                        }
                    }
                });
            }

            foreach (KeyValuePair<string, SyndicationItem> pair in syndicationItems)
            {
                ListViewItem listViewItem = new ListViewItem(pair.Key);
                listViewItem.SubItems.Add(pair.Value.PublishDate.ToString());
                listViewItem.SubItems.Add(pair.Value.Summary.Text);
                listViewItem.SubItems.Add(pair.Value.Links[0].Uri.AbsoluteUri);

                newListViewItems.Add(listViewItem);
            }

            ListViewItems.AddRange(newListViewItems);

            RefreshRSSFeed();
        }
        protected override void OnShown(EventArgs e)
        {
            LoadProperties();

            retroAchievementsAPIClient = new RetroAchievementAPIClient(Settings.Default.ra_username, Settings.Default.ra_key);

            SetupInterface();
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

            if (GameInfoController.Instance.AutoLaunch)
            {
                GameInfoController.Instance.Show();
            }
            if (GameStatsController.Instance.AutoLaunch)
            {
                GameStatsController.Instance.Show();
            }
            if (UserStatsController.Instance.AutoLaunch)
            {
                UserStatsController.Instance.Show();
            }
            if (FocusController.Instance.AutoLaunch)
            {
                FocusController.Instance.Show();
            }
            if (RecentAchievementsController.Instance.AutoLaunch)
            {
                RecentAchievementsController.Instance.Show();
            }
            if (AchievementListController.Instance.AutoLaunch)
            {
                AchievementListController.Instance.Show();
            }
            if (AlertsController.Instance.AutoLaunch)
            {
                AlertsController.Instance.Show();
            }
        }
        private void CreateFolders()
        {
            Directory.CreateDirectory(@"stream-labels");
            Directory.CreateDirectory(@"stream-labels\user-info");
            Directory.CreateDirectory(@"stream-labels\game-info");
            Directory.CreateDirectory(@"stream-labels\last-five");
            Directory.CreateDirectory(@"stream-labels\focus");
            Directory.CreateDirectory(@"stream-labels\alerts");
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
            openUserStatsWindowButton.Enabled = true;
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

            UpdateTimerLabel("Stopped updating");

            stopButton.Enabled = false;
            openFocusWindowButton.Enabled = CanStart();
            openNotificationWindowButton.Enabled = CanStart();
            openUserStatsWindowButton.Enabled = CanStart();
            openGameInfoWindowButton.Enabled = CanStart();
            openLastFiveWindowButton.Enabled = CanStart();
            openAchievementListWindowButton.Enabled = CanStart();

            apiKeyTextBox.Enabled = true;
            usernameTextBox.Enabled = true;

            startButton.Enabled = CanStart();
        }
        private bool CanStart()
        {
            return !(string.IsNullOrEmpty(usernameTextBox.Text)
                || string.IsNullOrEmpty(apiKeyTextBox.Text));
        }
        private void UpdateTimerLabel(string s)
        {
            timerStatusLabel.Text = s;
        }

        private void StartTimer()
        {
            UserAndGameTimerCounter = 6;

            if (ShouldRun)
            {
                UserAndGameUpdateTimer.Start();
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            StreamLabelManager.Instance.ClearAllStreamLabels();

            FocusController.Instance.Close();
            UserStatsController.Instance.Close();
            AlertsController.Instance.Close();
            GameInfoController.Instance.Close();
            RecentAchievementsController.Instance.Close();
            AchievementListController.Instance.Close();
        }
        private void UpdateRecentAchievements()
        {
            RecentAchievementsController.Instance.SetAchievements(UnlockedAchievements);

            StreamLabelManager.Instance.EnqueueLastFive(GameInfo);
        }
        private void UpdateUserInfo()
        {
            UserStatsController.Instance.SetRank(UserSummary.Rank.ToString());
            UserStatsController.Instance.SetRatio(UserSummary.RetroRatio);
            UserStatsController.Instance.SetAwards(UserSummary.Awards.ToString());
            UserStatsController.Instance.SetPoints(UserSummary.TotalPoints.ToString());
            UserStatsController.Instance.SetTruePoints(UserSummary.TotalTruePoints.ToString());

            StreamLabelManager.Instance.EnqueueUserInfo(UserSummary);
        }
        private void UpdateGameInfo()
        {
            gameInfoPictureBox.ImageLocation = "https://s3-eu-west-1.amazonaws.com/i.retroachievements.org" + GameInfo.ImageIcon;
            gameInfoTitleLabel.Text = GameInfo.Title;
            gameInfoProgressLabel.Text = GameInfo.AchievementsEarned + " / " + GameInfo.AchievementsPossible;

            GameInfoController.Instance.SetTitleValue(GameInfo.Title);
            GameInfoController.Instance.SetGenreValue(GameInfo.Genre);
            GameInfoController.Instance.SetConsoleValue(GameInfo.ConsoleName);
            GameInfoController.Instance.SetDeveloperValue(GameInfo.Developer);
            GameInfoController.Instance.SetPublisherValue(GameInfo.Publisher);
            GameInfoController.Instance.SetReleaseDateValue(GameInfo.Released);

            GameStatsController.Instance.SetGamePoints(GameInfo.GamePointsEarned.ToString(), GameInfo.GamePointsPossible.ToString());
            GameStatsController.Instance.SetGameAchievements(GameInfo.AchievementsEarned.ToString(), GameInfo.Achievements == null ? "0" : GameInfo.Achievements.Count.ToString());
            GameStatsController.Instance.SetGameTruePoints(GameInfo.GameTruePointsEarned.ToString(), GameInfo.GameTruePointsPossible.ToString());
            GameStatsController.Instance.SetGameRatio();
            GameStatsController.Instance.SetCompleted(GameInfo.Achievements == null ? 0.00f : GameInfo.AchievementsEarned / (float)GameInfo.Achievements.Count * 100f);

            StreamLabelManager.Instance.EnqueueGameInfo(GameInfo);
        }

        private void UpdateAchievementList(bool newGame)
        {
            AchievementListController.Instance.UpdateAchievementList(UnlockedAchievements, LockedAchievements, newGame);
        }

        private void RequiredField_TextChange(object sender, EventArgs e)
        {
            startButton.Enabled = CanStart();
        }
        private void AutoScroll_CheckChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            switch (MenuState)
            {
                case CustomMenuState.ACHIEVEMENT_LIST:
                    AchievementListController.Instance.AutoScroll = checkBox.Checked;
                    break;
                case CustomMenuState.RECENT_ACHIEVEMENTS:
                    RecentAchievementsController.Instance.AutoScroll = checkBox.Checked;
                    break;
            }
        }
        private void RSSFeedCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            switch (checkBox.Name)
            {
                case "rssFeedCheevoCheckBox":
                    Settings.Default.rss_new_achievements_feed = checkBox.Checked;
                    break;
                case "rssFeedForumCheckBox":
                    Settings.Default.rss_forum_feed = checkBox.Checked;
                    break;
                case "rssFeedFriendCheckBox":
                    Settings.Default.rss_friend_feed = checkBox.Checked;
                    break;
                case "rssFeedNewsCheckBox":
                    Settings.Default.rss_news_feed = checkBox.Checked;
                    break;
            }

            Settings.Default.Save();

            rssFeedListView.Items.Clear();

            RefreshRSSFeed();
        }

        private void AutoLaunchCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            switch (checkBox.Name)
            {
                case "autoOpenLastFiveWindowCheckbox":
                    RecentAchievementsController.Instance.AutoLaunch = checkBox.Checked;
                    break;
                case "autoOpenGameInfoWindowCheckbox":
                    GameInfoController.Instance.AutoLaunch = checkBox.Checked;
                    break;
                case "autoStartCheckbox":
                    Settings.Default.auto_start_checked = checkBox.Checked;
                    break;
                case "autoOpenAlertsWindowCheckbox":
                    AlertsController.Instance.AutoLaunch = checkBox.Checked;
                    break;
                case "autoOpenFocusWindowCheckBox":
                    FocusController.Instance.AutoLaunch = checkBox.Checked;
                    break;
                case "autoOpenUserStatsWindowCheckbox":
                    UserStatsController.Instance.AutoLaunch = checkBox.Checked;
                    break;
                case "autoOpenGameStatsWindowCheckbox":
                    GameStatsController.Instance.AutoLaunch = checkBox.Checked;
                    break;
                case "autoOpenAchievementListWindowCheckbox":
                    AchievementListController.Instance.AutoLaunch = checkBox.Checked;
                    break;
                case "autoOpenWebBrowserCheckbox":
                    Settings.Default.web_browser_auto_launch = checkBox.Checked;
                    Settings.Default.Save();
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
                AlertsController.Instance.SendMasteryNotification(GameInfo);
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
                case "recentAchievementsMaxListNumericUpDown":
                    RecentAchievementsController.Instance.MaxListSize = Convert.ToInt32(numericUpDown.Value);
                    break;
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
                        case CustomMenuState.USER_STATS:
                            if (UserStatsController.Instance.AdvancedSettingsEnabled)
                            {
                                UserStatsController.Instance.NameOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            }
                            else
                            {
                                UserStatsController.Instance.SimpleFontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            }
                            break;
                        case CustomMenuState.GAME_STATS:
                            if (GameStatsController.Instance.AdvancedSettingsEnabled)
                            {
                                GameStatsController.Instance.NameOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            }
                            else
                            {
                                GameStatsController.Instance.SimpleFontOutlineSize = Convert.ToInt32(numericUpDown.Value);
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
                        case CustomMenuState.RECENT_ACHIEVEMENTS:
                            if (RecentAchievementsController.Instance.AdvancedSettingsEnabled)
                            {
                                RecentAchievementsController.Instance.TitleOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            }
                            else
                            {
                                RecentAchievementsController.Instance.SimpleFontOutlineSize = Convert.ToInt32(numericUpDown.Value);
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
                        case CustomMenuState.USER_STATS:
                            UserStatsController.Instance.ValueOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            break;
                        case CustomMenuState.GAME_STATS:
                            GameStatsController.Instance.ValueOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            break;
                        case CustomMenuState.ALERTS:
                            AlertsController.Instance.DescriptionOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            break;
                        case CustomMenuState.GAME_INFO:
                            GameInfoController.Instance.ValueOutlineSize = Convert.ToInt32(numericUpDown.Value);
                            break;
                        case CustomMenuState.RECENT_ACHIEVEMENTS:
                            RecentAchievementsController.Instance.DateOutlineSize = Convert.ToInt32(numericUpDown.Value);
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
                        case CustomMenuState.RECENT_ACHIEVEMENTS:
                            RecentAchievementsController.Instance.PointsOutlineSize = Convert.ToInt32(numericUpDown.Value);
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
                        case CustomMenuState.RECENT_ACHIEVEMENTS:
                            RecentAchievementsController.Instance.LineOutlineSize = Convert.ToInt32(numericUpDown.Value);
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
            if (GameInfo.Achievements != null
                && GameInfo.Achievements.Count > 0
                && GameInfo.Achievements[0] != null)
            {
                AlertsController.Instance.EnqueueAchievementNotifications(new List<Achievement>() { GameInfo.Achievements[0] });
                StreamLabelManager.Instance.EnqueueAlert(GameInfo.Achievements[0]);

                AlertsController.Instance.RunNotifications();
                StreamLabelManager.Instance.RunNotifications();
            }
            else
            {
                Achievement achievement = new Achievement()
                {
                    Title = "Thrilling!!!!",
                    Description = "Color every bit of Dinosaur 2. [Must color white if leaving white]",
                    BadgeNumber = "49987",
                    Points = 1
                };

                AlertsController.Instance.EnqueueAchievementNotifications(new List<Achievement>() {
                     achievement
                });
                StreamLabelManager.Instance.EnqueueAlert(achievement);

                AlertsController.Instance.RunNotifications();
                StreamLabelManager.Instance.RunNotifications();
            }
        }
        private void ShowGameMasteryButton_Click(object sender, EventArgs eventArgs)
        {
            AlertsController.Instance.EnqueueMasteryNotification(GameInfo);
            StreamLabelManager.Instance.EnqueueAlert(GameInfo);

            AlertsController.Instance.RunNotifications();
            StreamLabelManager.Instance.RunNotifications();
        }
        private void SetFocusButton_Click(object sender, EventArgs e)
        {
            SetFocus();
            StreamLabelManager.Instance.RunNotifications();
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
                case "openUserStatsWindowButton":
                    UserStatsController.Instance.Show();
                    break;
                case "openGameStatsWindowButton":
                    GameStatsController.Instance.Show();
                    break;
                case "openNotificationWindowButton":
                    AlertsController.Instance.Show();
                    break;
                case "openGameInfoWindowButton":
                    GameInfoController.Instance.Show();
                    break;
                case "openLastFiveWindowButton":
                    RecentAchievementsController.Instance.Show();
                    break;
                case "openAchievementListWindowButton":
                    AchievementListController.Instance.Show();
                    break;
                case "toggleUserBrowserButton":
                    if (MenuState.Equals(CustomMenuState.WEB_BROWSER))
                    {
                        MenuState = CustomMenuState.CLOSED;
                    }
                    else
                    {
                        MenuState = CustomMenuState.WEB_BROWSER;
                    }

                    UpdateGroupBoxVisibility();
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
                    MenuState = MenuState.Equals(CustomMenuState.RECENT_ACHIEVEMENTS) ? CustomMenuState.CLOSED : CustomMenuState.RECENT_ACHIEVEMENTS;
                    break;
                case "customizeGameInfoButton":
                    MenuState = MenuState.Equals(CustomMenuState.GAME_INFO) ? CustomMenuState.CLOSED : CustomMenuState.GAME_INFO;
                    break;
                case "customizeUserStatsButton":
                    MenuState = MenuState.Equals(CustomMenuState.USER_STATS) ? CustomMenuState.CLOSED : CustomMenuState.USER_STATS;
                    break;
                case "customizeGameStatsButton":
                    MenuState = MenuState.Equals(CustomMenuState.GAME_STATS) ? CustomMenuState.CLOSED : CustomMenuState.GAME_STATS;
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

            customAchievementCustomizationGroupBox.Hide();
            customMasterySettingsGroupBox.Hide();

            userStatsCustomizationGroupBox.Hide();
            gameStatsCustomizationGroupBox.Hide();
            gameInfoCustomizationGroupBox.Hide();

            simpleFontCheckBox.Hide();
            simpleFontLabel.Hide();

            fontBorderCheckBox.Hide();
            fontBorderLabel.Hide();
            autoSrollLabel.Hide();

            borderBackgroundGroupBox.Hide();
            windowBackgroundGroupBox.Hide();

            titleFontGroupBox.Hide();
            descriptionFontGroupBox.Hide();
            lineFontGroupBox.Hide();
            pointsFontGroupBox.Hide();

            recentAchievementsMaxListLabel.Hide();
            recentAchievementsMaxListNumericUpDown.Hide();

            autoScrollCheckBox.Hide();

            chromiumWebBrowser.Hide();

            focusGroupBox.BackgroundImage = Resources.chrono_trigger_block;
            notificationsGroupBox.BackgroundImage = Resources.chrono_trigger_block;
            recentAchievementsGroupBox.BackgroundImage = Resources.chrono_trigger_block;
            achievementListGroupBox.BackgroundImage = Resources.chrono_trigger_block;
            userStatsGroupBox.BackgroundImage = Resources.chrono_trigger_block;
            gameInfoGroupBox.BackgroundImage = Resources.chrono_trigger_block;
            gameStatsGroupBox.BackgroundImage = Resources.chrono_trigger_block;
            userBrowserGroupBox.BackgroundImage = Resources.chrono_trigger_block;

            toggleUserBrowserButton.Text = "Open";

            switch (MenuState)
            {
                case CustomMenuState.CLOSED:
                    ClientSize = new Size(672, 462);
                    break;
                case CustomMenuState.WEB_BROWSER:
                    userBrowserGroupBox.BackgroundImage = Resources.chrono_trigger_block5;

                    toggleUserBrowserButton.Text = "Close";
                    chromiumWebBrowser.Show();

                    ClientSize = new Size(1240, 462);
                    break;
                case CustomMenuState.FOCUS:
                    focusGroupBox.BackgroundImage = Resources.chrono_trigger_block5;

                    fontBorderCheckBox.Show();
                    simpleFontCheckBox.Show();
                    titleFontGroupBox.Show();
                    fontBorderLabel.Show();
                    simpleFontLabel.Show();

                    fontBorderCheckBox.Checked = FocusController.Instance.BorderEnabled;

                    borderBackgroundGroupBox.Show();
                    windowBackgroundGroupBox.Show();

                    borderBackgroudColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.BorderBackgroundColor);
                    windowBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.WindowBackgroundColor);

                    if (FocusController.Instance.AdvancedSettingsEnabled)
                    {
                        simpleFontCheckBox.Checked = false;

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
                        simpleFontCheckBox.Checked = true;

                        titleFontGroupBox.Text = "All";

                        SetFontFamilyBox(titleFontFamilyComboBox, FocusController.Instance.SimpleFontFamily);

                        titleFontOutlineCheckbox.Checked = FocusController.Instance.SimpleFontOutlineEnabled;
                        titleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.SimpleFontColor);

                        titleFontOutlineNumericUpDown.Enabled = FocusController.Instance.SimpleFontOutlineEnabled;
                        titleFontOutlineColorPictureBox.Enabled = FocusController.Instance.SimpleFontOutlineEnabled;
                        titleFontOutlineColorButton.Enabled = FocusController.Instance.SimpleFontOutlineEnabled;

                        titleFontOutlineNumericUpDown.Value = FocusController.Instance.SimpleFontOutlineSize;
                        titleFontOutlineColorPictureBox.BackColor = FocusController.Instance.SimpleFontOutlineEnabled ? ColorTranslator.FromHtml(FocusController.Instance.SimpleFontOutlineColor) : Color.DarkGray;
                    }

                    ClientSize = new Size(1240, 462);
                    break;
                case CustomMenuState.RECENT_ACHIEVEMENTS:
                    recentAchievementsGroupBox.BackgroundImage = Resources.chrono_trigger_block5;

                    fontBorderCheckBox.Show();
                    simpleFontCheckBox.Show();
                    titleFontGroupBox.Show();
                    fontBorderLabel.Show();
                    simpleFontLabel.Show();

                    fontBorderCheckBox.Checked = RecentAchievementsController.Instance.BorderEnabled;

                    borderBackgroundGroupBox.Show();
                    windowBackgroundGroupBox.Show();

                    borderBackgroudColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.BorderBackgroundColor);
                    windowBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.WindowBackgroundColor);

                    recentAchievementsMaxListLabel.Show();
                    recentAchievementsMaxListNumericUpDown.Show();

                    recentAchievementsMaxListNumericUpDown.Value = RecentAchievementsController.Instance.MaxListSize;

                    if (RecentAchievementsController.Instance.AdvancedSettingsEnabled)
                    {
                        simpleFontCheckBox.Checked = false;

                        titleFontGroupBox.Text = "Title";
                        descriptionFontGroupBox.Text = "Date";
                        lineFontGroupBox.Text = "Line";
                        pointsFontGroupBox.Text = "Points";

                        SetFontFamilyBox(titleFontFamilyComboBox, RecentAchievementsController.Instance.TitleFontFamily);
                        SetFontFamilyBox(descriptionFontFamilyComboBox, RecentAchievementsController.Instance.DateFontFamily);
                        SetFontFamilyBox(pointsFontFamilyComboBox, RecentAchievementsController.Instance.PointsFontFamily);

                        titleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.TitleColor);
                        descriptionFontColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.DateColor);
                        pointsFontColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.PointsColor);
                        lineColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.LineColor);

                        titleFontOutlineColorButton.Enabled = RecentAchievementsController.Instance.TitleOutlineEnabled;
                        titleFontOutlineColorPictureBox.Enabled = RecentAchievementsController.Instance.TitleOutlineEnabled;
                        titleFontOutlineNumericUpDown.Enabled = RecentAchievementsController.Instance.TitleOutlineEnabled;
                        titleFontOutlineCheckbox.Checked = RecentAchievementsController.Instance.TitleOutlineEnabled;

                        titleFontOutlineColorPictureBox.BackColor = RecentAchievementsController.Instance.TitleOutlineEnabled ? ColorTranslator.FromHtml(RecentAchievementsController.Instance.TitleOutlineColor) : Color.DarkGray;
                        titleFontOutlineNumericUpDown.Value = RecentAchievementsController.Instance.TitleOutlineSize;

                        descriptionFontOutlineColorButton.Enabled = RecentAchievementsController.Instance.DateOutlineEnabled;
                        descriptionFontOutlineColorPictureBox.Enabled = RecentAchievementsController.Instance.DateOutlineEnabled;
                        descriptionFontOutlineNumericUpDown.Enabled = RecentAchievementsController.Instance.DateOutlineEnabled;
                        descriptionFontOutlineCheckbox.Checked = RecentAchievementsController.Instance.DateOutlineEnabled;

                        descriptionFontOutlineColorPictureBox.BackColor = RecentAchievementsController.Instance.DateOutlineEnabled ? ColorTranslator.FromHtml(RecentAchievementsController.Instance.DateOutlineColor) : Color.DarkGray;
                        descriptionFontOutlineNumericUpDown.Value = RecentAchievementsController.Instance.DateOutlineSize;

                        pointsFontOutlineColorButton.Enabled = RecentAchievementsController.Instance.PointsOutlineEnabled;
                        pointsFontOutlineColorPictureBox.Enabled = RecentAchievementsController.Instance.PointsOutlineEnabled;
                        pointsFontOutlineNumericUpDown.Enabled = RecentAchievementsController.Instance.PointsOutlineEnabled;
                        pointsFontOutlineCheckbox.Checked = RecentAchievementsController.Instance.PointsOutlineEnabled;

                        pointsFontOutlineColorPictureBox.BackColor = RecentAchievementsController.Instance.PointsOutlineEnabled ? ColorTranslator.FromHtml(RecentAchievementsController.Instance.PointsOutlineColor) : Color.DarkGray;
                        pointsFontOutlineNumericUpDown.Value = RecentAchievementsController.Instance.PointsOutlineSize;

                        lineOutlineColorButton.Enabled = RecentAchievementsController.Instance.LineOutlineEnabled;
                        lineOutlineColorPictureBox.Enabled = RecentAchievementsController.Instance.LineOutlineEnabled;
                        lineOutlineNumericUpDown.Enabled = RecentAchievementsController.Instance.LineOutlineEnabled;
                        lineOutlineCheckbox.Checked = RecentAchievementsController.Instance.LineOutlineEnabled;

                        lineOutlineColorPictureBox.BackColor = RecentAchievementsController.Instance.LineOutlineEnabled ? ColorTranslator.FromHtml(RecentAchievementsController.Instance.LineOutlineColor) : Color.DarkGray;
                        lineOutlineNumericUpDown.Value = RecentAchievementsController.Instance.LineOutlineSize;

                        descriptionFontGroupBox.Show();
                        lineFontGroupBox.Show();
                        pointsFontGroupBox.Show();
                    }
                    else
                    {
                        simpleFontCheckBox.Checked = true;

                        titleFontGroupBox.Text = "All";

                        SetFontFamilyBox(titleFontFamilyComboBox, RecentAchievementsController.Instance.SimpleFontFamily);

                        titleFontOutlineCheckbox.Checked = RecentAchievementsController.Instance.SimpleFontOutlineEnabled;
                        titleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.SimpleFontColor);

                        titleFontOutlineNumericUpDown.Enabled = RecentAchievementsController.Instance.SimpleFontOutlineEnabled;
                        titleFontOutlineColorPictureBox.Enabled = RecentAchievementsController.Instance.SimpleFontOutlineEnabled;
                        titleFontOutlineColorButton.Enabled = RecentAchievementsController.Instance.SimpleFontOutlineEnabled;

                        titleFontOutlineNumericUpDown.Value = RecentAchievementsController.Instance.SimpleFontOutlineSize;
                        titleFontOutlineColorPictureBox.BackColor = RecentAchievementsController.Instance.SimpleFontOutlineEnabled ? ColorTranslator.FromHtml(RecentAchievementsController.Instance.SimpleFontOutlineColor) : Color.DarkGray;
                    }
                    autoSrollLabel.Show();
                    autoScrollCheckBox.Show();
                    autoScrollCheckBox.Checked = RecentAchievementsController.Instance.AutoScroll;

                    ClientSize = new Size(1240, 462);
                    break;
                case CustomMenuState.GAME_INFO:
                    gameInfoGroupBox.BackgroundImage = Resources.chrono_trigger_block5;

                    simpleFontCheckBox.Show();
                    titleFontGroupBox.Show();
                    simpleFontLabel.Show();

                    windowBackgroundGroupBox.Show();
                    windowBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoController.Instance.WindowBackgroundColor);

                    if (GameInfoController.Instance.AdvancedSettingsEnabled)
                    {
                        simpleFontCheckBox.Checked = false;

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
                    }
                    else
                    {
                        simpleFontCheckBox.Checked = true;

                        titleFontGroupBox.Text = "All";

                        SetFontFamilyBox(titleFontFamilyComboBox, GameInfoController.Instance.SimpleFontFamily);

                        titleFontOutlineCheckbox.Checked = GameInfoController.Instance.SimpleFontOutlineEnabled;
                        titleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoController.Instance.SimpleFontColor);

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
                    gameInfoCustomizationGroupBox.Location = new Point(165, 11);

                    ClientSize = new Size(1240, 462);
                    break;
                case CustomMenuState.USER_STATS:
                    userStatsGroupBox.BackgroundImage = Resources.chrono_trigger_block5;

                    simpleFontCheckBox.Show();
                    titleFontGroupBox.Show();
                    simpleFontLabel.Show();

                    windowBackgroundGroupBox.Show();
                    windowBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(UserStatsController.Instance.WindowBackgroundColor);

                    if (UserStatsController.Instance.AdvancedSettingsEnabled)
                    {
                        simpleFontCheckBox.Checked = false;

                        titleFontGroupBox.Text = "Name";
                        descriptionFontGroupBox.Text = "Value";

                        SetFontFamilyBox(titleFontFamilyComboBox, UserStatsController.Instance.NameFontFamily);
                        SetFontFamilyBox(descriptionFontFamilyComboBox, UserStatsController.Instance.ValueFontFamily);

                        titleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(UserStatsController.Instance.NameColor);
                        descriptionFontColorPictureBox.BackColor = ColorTranslator.FromHtml(UserStatsController.Instance.ValueColor);

                        titleFontOutlineColorButton.Enabled = UserStatsController.Instance.NameOutlineEnabled;
                        titleFontOutlineColorPictureBox.Enabled = UserStatsController.Instance.NameOutlineEnabled;
                        titleFontOutlineNumericUpDown.Enabled = UserStatsController.Instance.NameOutlineEnabled;
                        titleFontOutlineCheckbox.Checked = UserStatsController.Instance.NameOutlineEnabled;

                        titleFontOutlineColorPictureBox.BackColor = UserStatsController.Instance.NameOutlineEnabled ? ColorTranslator.FromHtml(UserStatsController.Instance.NameOutlineColor) : Color.DarkGray;
                        titleFontOutlineNumericUpDown.Value = UserStatsController.Instance.NameOutlineSize;

                        descriptionFontOutlineColorButton.Enabled = UserStatsController.Instance.ValueOutlineEnabled;
                        descriptionFontOutlineColorPictureBox.Enabled = UserStatsController.Instance.ValueOutlineEnabled;
                        descriptionFontOutlineNumericUpDown.Enabled = UserStatsController.Instance.ValueOutlineEnabled;
                        descriptionFontOutlineCheckbox.Checked = UserStatsController.Instance.ValueOutlineEnabled;

                        descriptionFontOutlineColorPictureBox.BackColor = UserStatsController.Instance.ValueOutlineEnabled ? ColorTranslator.FromHtml(UserStatsController.Instance.ValueOutlineColor) : Color.DarkGray;
                        descriptionFontOutlineNumericUpDown.Value = UserStatsController.Instance.ValueOutlineSize;

                        descriptionFontGroupBox.Show();
                    }
                    else
                    {
                        simpleFontCheckBox.Checked = true;

                        titleFontGroupBox.Text = "All";

                        SetFontFamilyBox(titleFontFamilyComboBox, UserStatsController.Instance.SimpleFontFamily);

                        titleFontOutlineCheckbox.Checked = UserStatsController.Instance.SimpleFontOutlineEnabled;
                        titleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(UserStatsController.Instance.SimpleFontColor);

                        titleFontOutlineNumericUpDown.Enabled = UserStatsController.Instance.SimpleFontOutlineEnabled;
                        titleFontOutlineColorPictureBox.Enabled = UserStatsController.Instance.SimpleFontOutlineEnabled;
                        titleFontOutlineColorButton.Enabled = UserStatsController.Instance.SimpleFontOutlineEnabled;

                        titleFontOutlineNumericUpDown.Value = UserStatsController.Instance.SimpleFontOutlineSize;
                        titleFontOutlineColorPictureBox.BackColor = UserStatsController.Instance.SimpleFontOutlineEnabled ? ColorTranslator.FromHtml(UserStatsController.Instance.SimpleFontOutlineColor) : Color.DarkGray;
                    }

                    rankEnableCheckBox.Checked = UserStatsController.Instance.RankEnabled;
                    awardsEnableCheckBox.Checked = UserStatsController.Instance.AwardsEnabled;
                    pointsEnableCheckBox.Checked = UserStatsController.Instance.PointsEnabled;
                    truePointsEnableCheckBox.Checked = UserStatsController.Instance.TruePointsEnabled;
                    ratioEnableCheckBox.Checked = UserStatsController.Instance.RatioEnabled;
                    truePointsEnableCheckBox.Checked = UserStatsController.Instance.TruePointsEnabled;

                    statsRankOverrideTextBox.Text = UserStatsController.Instance.RankName;
                    statsAwardsOverrideTextBox.Text = UserStatsController.Instance.AwardsName;
                    statsPointsOverrideTextBox.Text = UserStatsController.Instance.PointsName;
                    statsTruePointsOverrideTextBox.Text = UserStatsController.Instance.TruePointsName;
                    statsRatioOverrideTextBox.Text = UserStatsController.Instance.RatioName;

                    userStatsCustomizationGroupBox.Show();
                    userStatsCustomizationGroupBox.Location = new Point(165, 11);

                    ClientSize = new Size(1240, 462);
                    break;
                case CustomMenuState.GAME_STATS:
                    gameStatsGroupBox.BackgroundImage = Resources.chrono_trigger_block5;

                    fontBorderCheckBox.Hide();
                    simpleFontCheckBox.Show();
                    titleFontGroupBox.Show();
                    fontBorderLabel.Hide();
                    simpleFontLabel.Show();

                    windowBackgroundGroupBox.Show();
                    windowBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(GameStatsController.Instance.WindowBackgroundColor);

                    if (GameStatsController.Instance.AdvancedSettingsEnabled)
                    {
                        simpleFontCheckBox.Checked = false;

                        titleFontGroupBox.Text = "Name";
                        descriptionFontGroupBox.Text = "Value";

                        SetFontFamilyBox(titleFontFamilyComboBox, GameStatsController.Instance.NameFontFamily);
                        SetFontFamilyBox(descriptionFontFamilyComboBox, GameStatsController.Instance.ValueFontFamily);

                        titleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(GameStatsController.Instance.NameColor);
                        descriptionFontColorPictureBox.BackColor = ColorTranslator.FromHtml(GameStatsController.Instance.ValueColor);

                        titleFontOutlineColorButton.Enabled = GameStatsController.Instance.NameOutlineEnabled;
                        titleFontOutlineColorPictureBox.Enabled = GameStatsController.Instance.NameOutlineEnabled;
                        titleFontOutlineNumericUpDown.Enabled = GameStatsController.Instance.NameOutlineEnabled;
                        titleFontOutlineCheckbox.Checked = GameStatsController.Instance.NameOutlineEnabled;

                        titleFontOutlineColorPictureBox.BackColor = GameStatsController.Instance.NameOutlineEnabled ? ColorTranslator.FromHtml(GameStatsController.Instance.NameOutlineColor) : Color.DarkGray;
                        titleFontOutlineNumericUpDown.Value = GameStatsController.Instance.NameOutlineSize;

                        descriptionFontOutlineColorButton.Enabled = GameStatsController.Instance.ValueOutlineEnabled;
                        descriptionFontOutlineColorPictureBox.Enabled = GameStatsController.Instance.ValueOutlineEnabled;
                        descriptionFontOutlineNumericUpDown.Enabled = GameStatsController.Instance.ValueOutlineEnabled;
                        descriptionFontOutlineCheckbox.Checked = GameStatsController.Instance.ValueOutlineEnabled;

                        descriptionFontOutlineColorPictureBox.BackColor = GameStatsController.Instance.ValueOutlineEnabled ? ColorTranslator.FromHtml(GameStatsController.Instance.ValueOutlineColor) : Color.DarkGray;
                        descriptionFontOutlineNumericUpDown.Value = GameStatsController.Instance.ValueOutlineSize;


                        descriptionFontGroupBox.Show();
                    }
                    else
                    {
                        simpleFontCheckBox.Checked = true;

                        titleFontGroupBox.Text = "All";

                        SetFontFamilyBox(titleFontFamilyComboBox, GameStatsController.Instance.SimpleFontFamily);

                        titleFontOutlineCheckbox.Checked = GameStatsController.Instance.SimpleFontOutlineEnabled;
                        titleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(GameStatsController.Instance.SimpleFontColor);

                        titleFontOutlineNumericUpDown.Enabled = GameStatsController.Instance.SimpleFontOutlineEnabled;
                        titleFontOutlineColorPictureBox.Enabled = GameStatsController.Instance.SimpleFontOutlineEnabled;
                        titleFontOutlineColorButton.Enabled = GameStatsController.Instance.SimpleFontOutlineEnabled;

                        titleFontOutlineNumericUpDown.Value = GameStatsController.Instance.SimpleFontOutlineSize;
                        titleFontOutlineColorPictureBox.BackColor = GameStatsController.Instance.SimpleFontOutlineEnabled ? ColorTranslator.FromHtml(GameStatsController.Instance.SimpleFontOutlineColor) : Color.DarkGray;
                    }

                    switch (GameStatsController.Instance.DividerCharacter)
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

                    gameAchievementsEnableCheckBox.Checked = GameStatsController.Instance.GameAchievementsEnabled;
                    gamePointsEnableCheckBox.Checked = GameStatsController.Instance.GamePointsEnabled;
                    gameTruePointsEnableCheckBox.Checked = GameStatsController.Instance.GameTruePointsEnabled;
                    completedEnableCheckBox.Checked = GameStatsController.Instance.CompletedEnabled;
                    gameRatioEnableCheckBox.Checked = GameStatsController.Instance.GameRatioEnabled;

                    statsGameAchievementsOverrideTextBox.Text = GameStatsController.Instance.GameAchievementsName;
                    statsGamePointsOverrideTextBox.Text = GameStatsController.Instance.GamePointsName;
                    statsGameTruePointsOverrideTextBox.Text = GameStatsController.Instance.GameTruePointsName;
                    statsCompletedOverrideTextBox.Text = GameStatsController.Instance.CompletedName;
                    statsGameRatioOverrideTextBox.Text = GameStatsController.Instance.GameRatioName;

                    gameStatsCustomizationGroupBox.Show();
                    gameStatsCustomizationGroupBox.Location = new Point(165, 11);

                    ClientSize = new Size(1240, 462);
                    break;
                case CustomMenuState.ALERTS:
                    notificationsGroupBox.BackgroundImage = Resources.chrono_trigger_block5;

                    fontBorderCheckBox.Show();
                    simpleFontCheckBox.Show();
                    titleFontGroupBox.Show();
                    fontBorderLabel.Show();
                    simpleFontLabel.Show();

                    fontBorderCheckBox.Checked = AlertsController.Instance.BorderEnabled;

                    borderBackgroundGroupBox.Show();
                    windowBackgroundGroupBox.Show();

                    borderBackgroudColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.BorderBackgroundColor);
                    windowBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.WindowBackgroundColor);

                    if (AlertsController.Instance.AdvancedSettingsEnabled)
                    {
                        simpleFontCheckBox.Checked = false;

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
                        simpleFontCheckBox.Checked = true;

                        titleFontGroupBox.Text = "All";

                        SetFontFamilyBox(titleFontFamilyComboBox, AlertsController.Instance.SimpleFontFamily);

                        titleFontOutlineCheckbox.Checked = AlertsController.Instance.SimpleFontOutlineEnabled;
                        titleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.SimpleFontColor);

                        titleFontOutlineNumericUpDown.Enabled = AlertsController.Instance.SimpleFontOutlineEnabled;
                        titleFontOutlineColorPictureBox.Enabled = AlertsController.Instance.SimpleFontOutlineEnabled;
                        titleFontOutlineColorButton.Enabled = AlertsController.Instance.SimpleFontOutlineEnabled;

                        titleFontOutlineNumericUpDown.Value = AlertsController.Instance.SimpleFontOutlineSize;
                        titleFontOutlineColorPictureBox.BackColor = AlertsController.Instance.SimpleFontOutlineEnabled ? ColorTranslator.FromHtml(AlertsController.Instance.SimpleFontOutlineColor) : Color.DarkGray;
                    }
                    customAchievementCustomizationGroupBox.Show();
                    customMasterySettingsGroupBox.Show();

                    customAchievementCustomizationGroupBox.Location = new Point(165, 11);
                    customMasterySettingsGroupBox.Location = new Point(344, 11);

                    ClientSize = new Size(1240, 462);
                    break;
                case CustomMenuState.ACHIEVEMENT_LIST:
                    achievementListGroupBox.BackgroundImage = Resources.chrono_trigger_block5;

                    autoSrollLabel.Show();
                    autoScrollCheckBox.Show();
                    autoScrollCheckBox.Checked = RecentAchievementsController.Instance.AutoScroll;

                    windowBackgroundGroupBox.Show();
                    windowBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(AchievementListController.Instance.WindowBackgroundColor);

                    ClientSize = new Size(1240, 462);
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
                            case CustomMenuState.USER_STATS:
                                if (UserStatsController.Instance.AdvancedSettingsEnabled)
                                {
                                    UserStatsController.Instance.NameColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                else
                                {
                                    UserStatsController.Instance.SimpleFontColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                break;
                            case CustomMenuState.GAME_STATS:
                                if (GameStatsController.Instance.AdvancedSettingsEnabled)
                                {
                                    GameStatsController.Instance.NameColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                else
                                {
                                    GameStatsController.Instance.SimpleFontColor = MediaHelper.HexConverter(colorDialog1.Color);
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
                            case CustomMenuState.RECENT_ACHIEVEMENTS:
                                if (RecentAchievementsController.Instance.AdvancedSettingsEnabled)
                                {
                                    RecentAchievementsController.Instance.TitleColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                else
                                {
                                    RecentAchievementsController.Instance.SimpleFontColor = MediaHelper.HexConverter(colorDialog1.Color);
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
                            case CustomMenuState.USER_STATS:
                                if (UserStatsController.Instance.AdvancedSettingsEnabled)
                                {
                                    UserStatsController.Instance.NameOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                else
                                {
                                    UserStatsController.Instance.SimpleFontOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                break;
                            case CustomMenuState.GAME_STATS:
                                if (GameStatsController.Instance.AdvancedSettingsEnabled)
                                {
                                    GameStatsController.Instance.NameOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                else
                                {
                                    GameStatsController.Instance.SimpleFontOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
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
                            case CustomMenuState.RECENT_ACHIEVEMENTS:
                                if (RecentAchievementsController.Instance.AdvancedSettingsEnabled)
                                {
                                    RecentAchievementsController.Instance.TitleOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                }
                                else
                                {
                                    RecentAchievementsController.Instance.SimpleFontOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
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
                            case CustomMenuState.USER_STATS:
                                UserStatsController.Instance.ValueColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.GAME_STATS:
                                GameStatsController.Instance.ValueColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.ALERTS:
                                AlertsController.Instance.DescriptionColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.GAME_INFO:
                                GameInfoController.Instance.ValueColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.RECENT_ACHIEVEMENTS:
                                RecentAchievementsController.Instance.DateColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.FOCUS:
                                FocusController.Instance.DescriptionColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                        }
                        break;
                    case "descriptionFontOutlineColorButton":
                        switch (MenuState)
                        {
                            case CustomMenuState.USER_STATS:
                                UserStatsController.Instance.ValueOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.GAME_STATS:
                                GameStatsController.Instance.ValueOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.ALERTS:
                                AlertsController.Instance.DescriptionOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.GAME_INFO:
                                GameInfoController.Instance.ValueOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                                break;
                            case CustomMenuState.RECENT_ACHIEVEMENTS:
                                RecentAchievementsController.Instance.DateOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
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
                            case CustomMenuState.RECENT_ACHIEVEMENTS:
                                RecentAchievementsController.Instance.PointsColor = MediaHelper.HexConverter(colorDialog1.Color);
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
                            case CustomMenuState.RECENT_ACHIEVEMENTS:
                                RecentAchievementsController.Instance.PointsOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
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
                            case CustomMenuState.RECENT_ACHIEVEMENTS:
                                RecentAchievementsController.Instance.LineColor = MediaHelper.HexConverter(colorDialog1.Color);
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
                            case CustomMenuState.RECENT_ACHIEVEMENTS:
                                RecentAchievementsController.Instance.LineOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
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
                        case CustomMenuState.USER_STATS:
                            if (UserStatsController.Instance.AdvancedSettingsEnabled)
                            {
                                UserStatsController.Instance.NameFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            }
                            else
                            {
                                UserStatsController.Instance.SimpleFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            }
                            break;
                        case CustomMenuState.GAME_STATS:
                            if (GameStatsController.Instance.AdvancedSettingsEnabled)
                            {
                                GameStatsController.Instance.NameFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            }
                            else
                            {
                                GameStatsController.Instance.SimpleFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
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
                        case CustomMenuState.RECENT_ACHIEVEMENTS:
                            if (RecentAchievementsController.Instance.AdvancedSettingsEnabled)
                            {
                                RecentAchievementsController.Instance.TitleFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            }
                            else
                            {
                                RecentAchievementsController.Instance.SimpleFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
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
                        case CustomMenuState.USER_STATS:
                            UserStatsController.Instance.ValueFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            break;
                        case CustomMenuState.ALERTS:
                            AlertsController.Instance.DescriptionFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            break;
                        case CustomMenuState.GAME_INFO:
                            GameInfoController.Instance.ValueFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
                            break;
                        case CustomMenuState.RECENT_ACHIEVEMENTS:
                            RecentAchievementsController.Instance.DateFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
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
                        case CustomMenuState.RECENT_ACHIEVEMENTS:
                            RecentAchievementsController.Instance.PointsFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)(sender as ComboBox).SelectedItem)];
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
                case CustomMenuState.USER_STATS:
                    if (UserStatsController.Instance.AdvancedSettingsEnabled)
                    {
                        switch (checkBox.Name)
                        {
                            case "titleFontOutlineCheckbox":
                                UserStatsController.Instance.NameOutlineEnabled = isEnabled;
                                break;
                            case "descriptionFontOutlineCheckbox":
                                UserStatsController.Instance.ValueOutlineEnabled = isEnabled;
                                break;
                        }
                    }
                    else
                    {
                        UserStatsController.Instance.SimpleFontOutlineEnabled = isEnabled;
                    }
                    break;
                case CustomMenuState.GAME_STATS:
                    if (GameStatsController.Instance.AdvancedSettingsEnabled)
                    {
                        switch (checkBox.Name)
                        {
                            case "titleFontOutlineCheckbox":
                                GameStatsController.Instance.NameOutlineEnabled = isEnabled;
                                break;
                            case "descriptionFontOutlineCheckbox":
                                GameStatsController.Instance.ValueOutlineEnabled = isEnabled;
                                break;
                        }
                    }
                    else
                    {
                        GameStatsController.Instance.SimpleFontOutlineEnabled = isEnabled;
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
                case CustomMenuState.RECENT_ACHIEVEMENTS:
                    if (RecentAchievementsController.Instance.AdvancedSettingsEnabled)
                    {
                        switch (checkBox.Name)
                        {
                            case "titleFontOutlineCheckbox":
                                RecentAchievementsController.Instance.TitleOutlineEnabled = isEnabled;
                                break;
                            case "descriptionFontOutlineCheckbox":
                                RecentAchievementsController.Instance.DateOutlineEnabled = isEnabled;
                                break;
                            case "pointsFontOutlineCheckbox":
                                RecentAchievementsController.Instance.PointsOutlineEnabled = isEnabled;
                                break;
                            case "lineOutlineCheckbox":
                                RecentAchievementsController.Instance.LineOutlineEnabled = isEnabled;
                                break;
                        }
                    }
                    else
                    {
                        RecentAchievementsController.Instance.SimpleFontOutlineEnabled = isEnabled;
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
                    case CustomMenuState.RECENT_ACHIEVEMENTS:
                        if (button.Name == "windowBackgroundColorButton")
                        {
                            RecentAchievementsController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                            windowBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        }
                        else
                        {
                            RecentAchievementsController.Instance.BorderBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
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
                    case CustomMenuState.USER_STATS:
                        UserStatsController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        windowBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case CustomMenuState.GAME_STATS:
                        GameStatsController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        windowBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case CustomMenuState.ACHIEVEMENT_LIST:
                        AchievementListController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        windowBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                }
            }
        }
        private void DefaultButton_Click(object sender, EventArgs e)
        {
            switch (MenuState)
            {
                case CustomMenuState.GAME_INFO:
                    gameInfoConsoleOverrideTextBox.Text = "Console";
                    gameInfoDeveloperOverrideTextBox.Text = "Developer";
                    gameInfoPublisherOverrideTextBox.Text = "Publisher";
                    gameInfoGenreOverrideTextBox.Text = "Genre";
                    gameInfoReleaseDateOverrideTextBox.Text = "Released";
                    gameInfoTitleOverrideTextBox.Text = "Title";
                    break;
                case CustomMenuState.USER_STATS:
                    statsRankOverrideTextBox.Text = "Rank";
                    statsAwardsOverrideTextBox.Text = "Awards";
                    statsPointsOverrideTextBox.Text = "Points";
                    statsTruePointsOverrideTextBox.Text = "True Points";
                    statsRatioOverrideTextBox.Text = "Ratio";
                    break;
                case CustomMenuState.GAME_STATS:
                    statsGameRatioOverrideTextBox.Text = "Ratio";
                    statsGamePointsOverrideTextBox.Text = "Points";
                    statsGameTruePointsOverrideTextBox.Text = "True Points";
                    statsGameAchievementsOverrideTextBox.Text = "Cheevos";
                    statsCompletedOverrideTextBox.Text = "Compeleted";
                    break;
            }
        }
        private void SimpleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            switch (checkBox.Name)
            {
                case "simpleFontCheckBox":
                    switch (MenuState)
                    {
                        case CustomMenuState.ALERTS:
                            AlertsController.Instance.AdvancedSettingsEnabled = !checkBox.Checked;
                            break;
                        case CustomMenuState.RECENT_ACHIEVEMENTS:
                            RecentAchievementsController.Instance.AdvancedSettingsEnabled = !checkBox.Checked;
                            break;
                        case CustomMenuState.FOCUS:
                            FocusController.Instance.AdvancedSettingsEnabled = !checkBox.Checked;
                            break;
                        case CustomMenuState.GAME_INFO:
                            GameInfoController.Instance.AdvancedSettingsEnabled = !checkBox.Checked;
                            break;
                        case CustomMenuState.USER_STATS:
                            UserStatsController.Instance.AdvancedSettingsEnabled = !checkBox.Checked;
                            break;
                        case CustomMenuState.GAME_STATS:
                            GameStatsController.Instance.AdvancedSettingsEnabled = !checkBox.Checked;
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
                case CustomMenuState.RECENT_ACHIEVEMENTS:
                    RecentAchievementsController.Instance.BorderEnabled = checkBox.Checked;
                    break;
                case CustomMenuState.USER_STATS:
                    switch (checkBox.Name)
                    {
                        case "rankEnableCheckBox":
                            UserStatsController.Instance.RankEnabled = checkBox.Checked;
                            break;
                        case "awardsEnableCheckBox":
                            UserStatsController.Instance.AwardsEnabled = checkBox.Checked;
                            break;
                        case "pointsEnableCheckBox":
                            UserStatsController.Instance.PointsEnabled = checkBox.Checked;
                            break;
                        case "truePointsEnableCheckBox":
                            UserStatsController.Instance.TruePointsEnabled = checkBox.Checked;
                            break;
                        case "ratioEnableCheckBox":
                            UserStatsController.Instance.RatioEnabled = checkBox.Checked;
                            break;
                    }
                    break;
                case CustomMenuState.GAME_STATS:
                    switch (checkBox.Name)
                    {
                        case "gameAchievementsEnableCheckBox":
                            GameStatsController.Instance.GameAchievementsEnabled = checkBox.Checked;
                            break;
                        case "gamePointsEnableCheckBox":
                            GameStatsController.Instance.GamePointsEnabled = checkBox.Checked;
                            break;
                        case "gameTruePointsEnableCheckBox":
                            GameStatsController.Instance.GameTruePointsEnabled = checkBox.Checked;
                            break;
                        case "gameRatioEnableCheckBox":
                            GameStatsController.Instance.GameRatioEnabled = checkBox.Checked;
                            break;
                        case "completedEnableCheckBox":
                            GameStatsController.Instance.CompletedEnabled = checkBox.Checked;
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
                    UserStatsController.Instance.RankName = textBox.Text;
                    break;
                case "statsPointsOverrideTextBox":
                    UserStatsController.Instance.PointsName = textBox.Text;
                    break;
                case "statsAwardsOverrideTextBox":
                    UserStatsController.Instance.AwardsName = textBox.Text;
                    break;
                case "statsTruePointsOverrideTextBox":
                    UserStatsController.Instance.TruePointsName = textBox.Text;
                    break;
                case "statsRatioOverrideTextBox":
                    UserStatsController.Instance.RatioName = textBox.Text;
                    break;
                case "statsGameRatioOverrideTextBox":
                    GameStatsController.Instance.GameRatioName = textBox.Text;
                    break;
                case "statsGamePointsOverrideTextBox":
                    GameStatsController.Instance.GamePointsName = textBox.Text;
                    break;
                case "statsGameTruePointsOverrideTextBox":
                    GameStatsController.Instance.GameTruePointsName = textBox.Text;
                    break;
                case "statsGameAchievementsOverrideTextBox":
                    GameStatsController.Instance.GameAchievementsName = textBox.Text;
                    break;
                case "statsCompletedOverrideTextBox":
                    GameStatsController.Instance.CompletedName = textBox.Text;
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
                        GameStatsController.Instance.DividerCharacter = "/";
                        break;
                    case "statsRadioButtonSemicolon":
                        statsRadioButtonDot.Checked = false;
                        statsRadioButtonBackslash.Checked = false;
                        GameStatsController.Instance.DividerCharacter = ":";
                        break;
                    case "statsRadioButtonDot":
                        statsRadioButtonSemicolon.Checked = false;
                        statsRadioButtonBackslash.Checked = false;
                        GameStatsController.Instance.DividerCharacter = ".";
                        break;
                }
            }
        }

        private void BrowserSensitiveControl_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            this.settingsAndBrowserGroupBox.Controls.Remove(chromiumWebBrowser);

            switch (control.Name)
            {
                case "userProfilePictureBox":
                    chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser("https://retroachievements.org/User/" + Settings.Default.ra_username)
                    {
                        Location = new Point(5, 12),
                        ActivateBrowserOnCreation = false,
                        Name = "chromiumWebBrowser",
                        Size = new Size(552, 436),
                        TabIndex = 0,
                        Dock = DockStyle.None,
                        RequestHandler = new CustomRequestHandler()
                    };
                    break;
                case "gameInfoPictureBox":
                    chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser("https://retroachievements.org/game/" + GameInfo.Id)
                    {
                        Location = new Point(5, 12),
                        ActivateBrowserOnCreation = false,
                        Name = "chromiumWebBrowser",
                        Size = new Size(552, 436),
                        TabIndex = 0,
                        Dock = DockStyle.None,
                        RequestHandler = new CustomRequestHandler()
                    };
                    break;
                case "focusAchievementPictureBox":
                    chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser("https://retroachievements.org/achievement/" + CurrentlyViewingAchievement.Id)
                    {
                        Location = new Point(5, 12),
                        ActivateBrowserOnCreation = false,
                        Name = "chromiumWebBrowser",
                        Size = new Size(552, 436),
                        TabIndex = 0,
                        Dock = DockStyle.None,
                        RequestHandler = new CustomRequestHandler()
                    };
                    break;
                case "rssFeedListView":
                    ListView listView = (ListView)sender;

                    if (listView.SelectedItems.Count > 0)
                    {
                        this.settingsAndBrowserGroupBox.Controls.Remove(chromiumWebBrowser);

                        if (listView.SelectedItems[0].SubItems[0].Text.Contains("[FORUM] ") || listView.SelectedItems[0].SubItems[0].Text.Contains("[CHEEVO] "))
                        {
                            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(listView.SelectedItems[0].SubItems[3].Text)
                            {
                                Location = new Point(5, 12),
                                ActivateBrowserOnCreation = false,
                                Name = "chromiumWebBrowser",
                                Size = new Size(552, 436),
                                TabIndex = 0,
                                Dock = DockStyle.None,
                                RequestHandler = new CustomRequestHandler()
                            };
                        }
                        else
                        {
                            string s = "<!DOCTYPE html>" +
                            "<html>" +
                            "<style>" +
                            "html { " +
                            "  color: #ffffff;" +
                            "  font-family: \"Lucida Console Bold\", \"Courier New\", monospace;" +
                            "  font-size: 14px;" +
                            "  background-color: #272727;" +
                            "}" +
                            "a:link {" +
                            " color: #ffa200;" +
                            "}" +
                            "</style>" +
                            "<body>" +
                            listView.SelectedItems[0].SubItems[2].Text +
                            "</body>" +
                            "</html>";

                            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(s))
                            {
                                Location = new Point(5, 12),
                                ActivateBrowserOnCreation = false,
                                Name = "chromiumWebBrowser",
                                Size = new Size(552, 436),
                                TabIndex = 0,
                                Dock = DockStyle.None,
                                RequestHandler = new CustomRequestHandler()
                            };
                        }
                    }
                    break;
            }

            this.settingsAndBrowserGroupBox.Controls.Add(chromiumWebBrowser);

            MenuState = CustomMenuState.WEB_BROWSER;
            UpdateGroupBoxVisibility();
        }
        private void LoadProperties()
        {
            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser("https://retroachievements.org/User/" + Settings.Default.ra_username)
            {
                Location = new Point(5, 12),
                ActivateBrowserOnCreation = false,
                Name = "chromiumWebBrowser",
                Size = new Size(552, 436),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };
            this.settingsAndBrowserGroupBox.Controls.Add(chromiumWebBrowser);

            if (Settings.Default.UpdateSettings)
            {
                Settings.Default.Upgrade();

                Settings.Default.UpdateSettings = false;

                Settings.Default.Save();
            }

            usernameTextBox.Text = Settings.Default.ra_username;
            apiKeyTextBox.Text = Settings.Default.ra_key;

            autoStartCheckbox.Checked = Settings.Default.auto_start_checked;
            autoOpenFocusWindowCheckBox.Checked = FocusController.Instance.AutoLaunch;
            autoOpenUserStatsWindowCheckbox.Checked = UserStatsController.Instance.AutoLaunch;
            autoOpenGameStatsWindowCheckbox.Checked = GameStatsController.Instance.AutoLaunch;
            autoOpenAlertsWindowCheckbox.Checked = AlertsController.Instance.AutoLaunch;
            autoOpenGameInfoWindowCheckbox.Checked = GameInfoController.Instance.AutoLaunch;
            autoOpenLastFiveWindowCheckbox.Checked = RecentAchievementsController.Instance.AutoLaunch;
            autoOpenAchievementListWindowCheckbox.Checked = AchievementListController.Instance.AutoLaunch;
            autoOpenWebBrowserCheckbox.Checked = Settings.Default.web_browser_auto_launch;

            rssFeedCheevoCheckBox.Checked = Settings.Default.rss_new_achievements_feed;
            rssFeedForumCheckBox.Checked = Settings.Default.rss_forum_feed;
            rssFeedFriendCheckBox.Checked = Settings.Default.rss_friend_feed;
            rssFeedNewsCheckBox.Checked = Settings.Default.rss_news_feed;

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

            userProfilePictureBox.Click += BrowserSensitiveControl_Click;
            gameInfoPictureBox.Click += BrowserSensitiveControl_Click;
            focusAchievementPictureBox.Click += BrowserSensitiveControl_Click;
            rssFeedListView.SelectedIndexChanged += BrowserSensitiveControl_Click;

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

            userStatsDefaultButton.Click += DefaultButton_Click;
            gameStatsDefaultButton.Click += DefaultButton_Click;
            gameInfoDefaultButton.Click += DefaultButton_Click;

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
            recentAchievementsMaxListNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;

            borderBackgroundColorButton.Click += BackgroundColorButton_Click;
            windowBackgroundColorButton.Click += BackgroundColorButton_Click;

            autoStartCheckbox.Click += AutoLaunchCheckbox_CheckedChanged;
            autoOpenLastFiveWindowCheckbox.Click += AutoLaunchCheckbox_CheckedChanged;
            autoOpenGameInfoWindowCheckbox.Click += AutoLaunchCheckbox_CheckedChanged;
            autoOpenAlertsWindowCheckbox.Click += AutoLaunchCheckbox_CheckedChanged;
            autoOpenFocusWindowCheckBox.Click += AutoLaunchCheckbox_CheckedChanged;
            autoOpenUserStatsWindowCheckbox.Click += AutoLaunchCheckbox_CheckedChanged;
            autoOpenGameStatsWindowCheckbox.Click += AutoLaunchCheckbox_CheckedChanged;
            autoOpenAchievementListWindowCheckbox.Click += AutoLaunchCheckbox_CheckedChanged;
            autoOpenWebBrowserCheckbox.Click += AutoLaunchCheckbox_CheckedChanged;

            rssFeedCheevoCheckBox.CheckedChanged += RSSFeedCheckbox_CheckedChanged;
            rssFeedForumCheckBox.CheckedChanged += RSSFeedCheckbox_CheckedChanged;
            rssFeedFriendCheckBox.CheckedChanged += RSSFeedCheckbox_CheckedChanged;
            rssFeedNewsCheckBox.CheckedChanged += RSSFeedCheckbox_CheckedChanged;

            autoScrollCheckBox.CheckedChanged += AutoScroll_CheckChanged;

            customAchievementEnableCheckbox.Click += CustomAchievementEnableCheckbox_CheckedChanged;
            customMasteryEnableCheckbox.Click += CustomMasteryEnableCheckbox_CheckedChanged;
            acheivementEditOutlineCheckbox.Click += AcheivementEditOutlineCheckbox_CheckedChanged;
            masteryEditOultineCheckbox.Click += MasteryEditOultineCheckbox_CheckedChanged;

            fontBorderCheckBox.Click += OverrideEnableCheckBox_Clicked;
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

            simpleFontCheckBox.Click += SimpleCheckBox_CheckedChanged;

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
            openUserStatsWindowButton.Click += ShowWindowButton_Click;
            openGameStatsWindowButton.Click += ShowWindowButton_Click;
            openAchievementListWindowButton.Click += ShowWindowButton_Click;
            toggleUserBrowserButton.Click += ShowWindowButton_Click;

            startButton.Click += StartButton_Click;
            stopButton.Click += StopButton_Click;

            setFocusButton.Click += SetFocusButton_Click;
            focusAchievementButtonLeft.Click += MoveFocusIndexLeft;
            focusAchievementButtonRight.Click += MoveFocusIndexRight;

            customizeLastFiveButton.Click += CustomizeButton_Click;
            customizeGameInfoButton.Click += CustomizeButton_Click;
            customizeAlertsButton.Click += CustomizeButton_Click;
            customizeFocusButton.Click += CustomizeButton_Click;
            customizeUserStatsButton.Click += CustomizeButton_Click;
            customizeGameStatsButton.Click += CustomizeButton_Click;
            customizeAchievementListButton.Click += CustomizeButton_Click;

            replayAchievementButton.Click += ShowAchievementButton_Click;
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
        USER_STATS,
        GAME_STATS,
        ALERTS,
        GAME_INFO,
        RECENT_ACHIEVEMENTS,
        ACHIEVEMENT_LIST,
        WEB_BROWSER
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