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
        private int CurrentlyViewingIndex;
        private int PreviouslyViewingIndex;
        private List<ListViewItem> ListViewItems;
        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;

        private List<Achievement> LockedAchievements
        {
            get
            {
                if (GameInfo != null && GameInfo.Achievements != null)
                {
                    return GameInfo.Achievements.FindAll(x => !x.DateEarned.HasValue);
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
                    return GameInfo.Achievements.FindAll(x => x.DateEarned.HasValue);
                }
                return new List<Achievement>();
            }
        }

        private List<Achievement> OldUnlockedAchievements;

        private Timer UserAndGameUpdateTimer;
        private int UserAndGameTimerCounter;

        private bool ShouldRun;

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
                tabControl1.SelectedIndex = 7;
            }
        }

        private void UpdateGameProgress(bool sameGame)
        {
            try
            {
                bool needsUpdate = !sameGame;

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

                        NotificationsController.Instance.EnqueueAchievementNotifications(achievementNotificationList);
                        PreviouslyViewingIndex = CurrentlyViewingIndex;

                        if (!achievementNotificationList.Contains(CurrentlyViewingAchievement))
                        {
                            CurrentlyViewingIndex = LockedAchievements.IndexOf(CurrentlyViewingAchievement);
                        }
                        else
                        {
                            switch (FocusController.Instance.RefocusBehavior)
                            {
                                case RefocusBehaviorEnum.GO_TO_FIRST:
                                    CurrentlyViewingIndex = 0;
                                    break;
                                case RefocusBehaviorEnum.GO_TO_PREVIOUS:
                                    CurrentlyViewingIndex = PreviouslyViewingIndex - 1;
                                    break;
                                case RefocusBehaviorEnum.GO_TO_NEXT:
                                    CurrentlyViewingIndex = PreviouslyViewingIndex;
                                    break;
                                case RefocusBehaviorEnum.GO_TO_LAST:
                                    CurrentlyViewingIndex = LockedAchievements.Count - 1;
                                    break;
                            }
                        }

                        if (UnlockedAchievements.Count == GameInfo.Achievements.Count && OldUnlockedAchievements.Count < GameInfo.Achievements.Count)
                        {
                            NotificationsController.Instance.EnqueueMasteryNotification(GameInfo);
                            StreamLabelManager.Instance.EnqueueAlert(GameInfo);
                        }

                        NotificationsController.Instance.RunNotifications();

                        needsUpdate = true;
                    }
                }
                else
                {
                    UpdateTimerLabel("Changing game to [" + GameInfo.Title + "]");

                    CurrentlyViewingAchievement = null;
                    CurrentlyViewingIndex = 0;
                }

                if (needsUpdate)
                {
                    UpdateAchievementList(!sameGame);
                    UpdateRecentAchievements();
                    UpdateGameInfo();
                    UpdateCurrentlyViewingAchievement();

                    SetFocus();
                }

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

                    OldUnlockedAchievements = UnlockedAchievements.ToList();

                    UpdateTimerLabel("Updating user info");
                    UserSummary userSummary = null;

                    if (UserSummary != null)
                    {
                        userSummary = (UserSummary)UserSummary.Clone();
                    }

                    UserSummary = await retroAchievementsAPIClient.GetUserSummary();

                    if (UserSummary == null)
                    {
                        StartTimer();
                        return;
                    }
                    else if (!UserSummary.Equals(userSummary))
                    {
                        UpdateUserInfo();
                    }

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

                    focusAchievementIdLabel.Text = "[ " + CurrentlyViewingAchievement.Id.ToString() + " ]";
                    focusAchievementPictureBox.ImageLocation = "https://retroachievements.org/Badge/" + CurrentlyViewingAchievement.BadgeNumber + ".png";
                    focusAchievementTitleLabel.Text = "[" + CurrentlyViewingAchievement.Points + "]\n\n" + CurrentlyViewingAchievement.Title;
                    focusAchievementDescriptionLabel.Text = CurrentlyViewingAchievement.Description;
                }
                else
                {
                    CurrentlyViewingIndex = 0;
                    CurrentlyViewingAchievement = null;

                    focusAchievementIdLabel.Text = "[ None ]";
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
                        if (ListViewItems.Find(potentialItem => potentialItem.Text.Contains("[NEWS] " + item.Title.Text)) == null)
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
                        if (ListViewItems.Find(potentialItem => potentialItem.Text.Equals("[CHEEVO] " + item.Title.Text + " " + item.PublishDate.ToString())) == null
                        && !syndicationItems.ContainsKey("[CHEEVO] " + item.Title.Text + " " + item.PublishDate.ToString()))
                        {
                            syndicationItems.Add("[CHEEVO] " + item.Title.Text + " " + item.PublishDate.ToString(), item);
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
                        if (ListViewItems.Find(potentialItem => potentialItem.Text.Equals("[FRIEND] " + item.Title.Text + " " + item.PublishDate.ToString())) == null
                        && !syndicationItems.ContainsKey("[FRIEND] " + item.Title.Text + " " + item.PublishDate.ToString()))
                        {
                            syndicationItems.Add("[FRIEND] " + item.Title.Text + " " + item.PublishDate.ToString(), item);
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
            if (GameProgressController.Instance.AutoLaunch)
            {
                GameProgressController.Instance.Show();
            }
            if (UserInfoController.Instance.AutoLaunch)
            {
                UserInfoController.Instance.Show();
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
            if (NotificationsController.Instance.AutoLaunch)
            {
                NotificationsController.Instance.Show();
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
            Settings.Default.ra_username = usernameTextBox.Text;
            Settings.Default.ra_key = apiKeyTextBox.Text;
            Settings.Default.Save();

            startButton.Enabled = false;
            stopButton.Enabled = true;

            ShouldRun = true;

            usernameTextBox.Enabled = false;
            apiKeyTextBox.Enabled = false;

            focusOpenWindowButton.Enabled = true;
            notificationsOpenWindowButton.Enabled = true;
            userInfoOpenWindowButton.Enabled = true;
            gameInfoOpenWindowButton.Enabled = true;

            UpdateFromSite(null, null);
        }
        private void StopButton_Click(object sender, EventArgs e)
        {
            ShouldRun = false;

            UserAndGameUpdateTimer.Stop();

            raConnectionStatusPictureBox.Image = Resources.red_button;

            UpdateTimerLabel("Stopped updating");

            stopButton.Enabled = false;

            bool canStart = CanStart();

            focusOpenWindowButton.Enabled = canStart;
            notificationsOpenWindowButton.Enabled = canStart;
            userInfoOpenWindowButton.Enabled = canStart;
            gameInfoOpenWindowButton.Enabled = canStart;
            recentAchievementsOpenWindowButton.Enabled = canStart;
            achievementListOpenWindowButton.Enabled = canStart;

            apiKeyTextBox.Enabled = true;
            usernameTextBox.Enabled = true;

            startButton.Enabled = canStart;
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
            UserInfoController.Instance.Close();
            NotificationsController.Instance.Close();
            GameInfoController.Instance.Close();
            RecentAchievementsController.Instance.Close();
            AchievementListController.Instance.Close();
        }
        private void UpdateRecentAchievements()
        {
            RecentAchievementsController.Instance.SetAchievements(UnlockedAchievements.ToList());

            StreamLabelManager.Instance.EnqueueLastFive(GameInfo);
        }
        private void UpdateUserInfo()
        {
            userInfoRankLabel.Text = "Rank: " + UserSummary.Rank.ToString();
            userInfoPointsLabel.Text = "Points: " + UserSummary.TotalPoints.ToString();
            userInfoTruePointsLabel.Text = "True Points: " + UserSummary.TotalTruePoints.ToString();
            userInfoRatioLabel.Text = "Ratio: " + UserSummary.RetroRatio;

            UserInfoController.Instance.SetRank(UserSummary.Rank.ToString());
            UserInfoController.Instance.SetRatio(UserSummary.RetroRatio);
            UserInfoController.Instance.SetPoints(UserSummary.TotalPoints.ToString());
            UserInfoController.Instance.SetTruePoints(UserSummary.TotalTruePoints.ToString());

            StreamLabelManager.Instance.EnqueueUserInfo(UserSummary);
        }
        private void UpdateGameInfo()
        {
            gameInfoPictureBox.ImageLocation = "https://s3-eu-west-1.amazonaws.com/i.retroachievements.org" + GameInfo.ImageIcon;
            gameInfoTitleLabel.Text = "Title: " + GameInfo.Title;
            gameInfoDeveloperLabel.Text = "Developer: " + GameInfo.Developer;
            gameInfoConsoleLabel.Text = "Console: " + GameInfo.ConsoleName;
            gameInfoPublisherLabel.Text = "Publisher: " + GameInfo.Publisher;
            gameInfoGenreLabel.Text = "Genre: " + GameInfo.Genre;
            gameInfoReleasedLabel.Text = "Released: " + GameInfo.Released;

            gameProgressAchievementsLabel.Text = "Achievements: " + GameInfo.AchievementsEarned + " / " + GameInfo.AchievementsPossible;
            gameProgressPointsLabel.Text = "Points: " + GameInfo.GamePointsEarned + " / " + GameInfo.GamePointsPossible;
            gameProgressTruePointsLabel.Text = "True Points " + GameInfo.GameTruePointsEarned + " / " + GameInfo.GameTruePointsPossible;
            gameProgressCompletedLabel.Text = "Completed: " + GameInfo.PercentComplete;
            gameProgressRatioLabel.Text = "Ratio: " + ((float)(GameInfo.GameTruePointsPossible) / GameInfo.GamePointsPossible).ToString("0.00") + "%";

            GameInfoController.Instance.SetTitleValue(GameInfo.Title);
            GameInfoController.Instance.SetGenreValue(GameInfo.Genre);
            GameInfoController.Instance.SetConsoleValue(GameInfo.ConsoleName);
            GameInfoController.Instance.SetDeveloperValue(GameInfo.Developer);
            GameInfoController.Instance.SetPublisherValue(GameInfo.Publisher);
            GameInfoController.Instance.SetReleaseDateValue(GameInfo.Released);

            GameProgressController.Instance.SetGameAchievements(GameInfo.AchievementsEarned.ToString(), GameInfo.Achievements == null ? "0" : GameInfo.Achievements.Count.ToString());
            GameProgressController.Instance.SetGamePoints(GameInfo.GamePointsEarned.ToString(), GameInfo.GamePointsPossible.ToString());
            GameProgressController.Instance.SetGameTruePoints(GameInfo.GameTruePointsEarned.ToString(), GameInfo.GameTruePointsPossible.ToString());
            GameProgressController.Instance.SetGameRatio();
            GameProgressController.Instance.SetCompleted(GameInfo.Achievements == null ? 0.00f : GameInfo.AchievementsEarned / (float)GameInfo.Achievements.Count * 100f);

            StreamLabelManager.Instance.EnqueueGameInfo(GameInfo);
        }
        private void UpdateAchievementList(bool newGame)
        {
            AchievementListController.Instance.UpdateAchievementList(UnlockedAchievements.ToList(), LockedAchievements.ToList(), newGame);
        }
        private void RequiredField_TextChanged(object sender, EventArgs e)
        {
            startButton.Enabled = CanStart();
        }
        private void AutoScroll_Click(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            switch (checkBox.Name)
            {
                case "achievementListScrollCheckBox":
                    AchievementListController.Instance.AutoScroll = !AchievementListController.Instance.AutoScroll;
                    checkBox.Checked = AchievementListController.Instance.AutoScroll;
                    break;
                case "recentAchievementsScrollCheckBox":
                    RecentAchievementsController.Instance.AutoScroll = !RecentAchievementsController.Instance.AutoScroll;
                    checkBox.Checked = RecentAchievementsController.Instance.AutoScroll;
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
        private void AutoLaunchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            switch (checkBox.Name)
            {
                case "recentAchievementsAutoOpenWindowCheckbox":
                    RecentAchievementsController.Instance.AutoLaunch = checkBox.Checked;
                    break;
                case "gameInfoAutoOpenWindowCheckbox":
                    GameInfoController.Instance.AutoLaunch = checkBox.Checked;
                    break;
                case "notificationsAutoOpenWindowCheckbox":
                    NotificationsController.Instance.AutoLaunch = checkBox.Checked;
                    break;
                case "focusAutoOpenWindowCheckBox":
                    FocusController.Instance.AutoLaunch = checkBox.Checked;
                    break;
                case "userInfoAutoOpenWindowCheckbox":
                    UserInfoController.Instance.AutoLaunch = checkBox.Checked;
                    break;
                case "gameProgressAutoOpenWindowCheckbox":
                    GameProgressController.Instance.AutoLaunch = checkBox.Checked;
                    break;
                case "achievementListAutoOpenWindowCheckbox":
                    AchievementListController.Instance.AutoLaunch = checkBox.Checked;
                    break;
                case "webBrowserAutoOpenCheckbox":
                    Settings.Default.web_browser_auto_launch = checkBox.Checked;
                    Settings.Default.Save();
                    break;
                case "autoStartCheckbox":
                    Settings.Default.auto_start_checked = checkBox.Checked;
                    Settings.Default.Save();
                    break;
            }
        }
        private void CustomAchievementEnableCheckBox_CheckedChanged(object sender, EventArgs eventArgs)
        {
            NotificationsController.Instance.CustomAchievementEnabled = ((CheckBox)sender).Checked;

            if (!File.Exists(NotificationsController.Instance.CustomAchievementFile))
            {
                SelectCustomAchievementButton_Click(null, null);
            }

            customAchievementEnableCheckbox.Checked = NotificationsController.Instance.CustomAchievementEnabled;
            selectCustomAchievementFileButton.Enabled = NotificationsController.Instance.CustomAchievementEnabled;
            acheivementEditOutlineCheckbox.Enabled = NotificationsController.Instance.CustomAchievementEnabled;

            NotificationsController.Instance.Reset();
        }
        private void CustomMasteryEnableCheckBox_CheckedChanged(object sender, EventArgs eventArgs)
        {
            NotificationsController.Instance.CustomMasteryEnabled = ((CheckBox)sender).Checked;

            if (!File.Exists(NotificationsController.Instance.CustomMasteryFile))
            {
                SelectCustomMasteryNotificationButton_Click(null, null);
            }

            customMasteryEnableCheckbox.Checked = NotificationsController.Instance.CustomMasteryEnabled;
            selectCustomMasteryFileButton.Enabled = NotificationsController.Instance.CustomMasteryEnabled;
            masteryEditOultineCheckbox.Enabled = NotificationsController.Instance.CustomMasteryEnabled;

            NotificationsController.Instance.Reset();
        }
        private void AcheivementEditOutlineCheckBox_CheckedChanged(object sender, EventArgs eventArgs)
        {
            if (((CheckBox)sender).Checked)
            {
                NotificationsController.Instance.EnableAchievementEdit();
                NotificationsController.Instance.SendAchievementNotification(new Achievement()
                {
                    Title = "Thrilling!!!!",
                    Description = "Color every bit of Dinosaur 2. [Must color white if leaving white]",
                    BadgeNumber = "49987",
                    Points = 1
                });
            }
            else
            {
                NotificationsController.Instance.DisableAchievementEdit();
            }
        }
        private void MasteryEditOultineCheckBox_CheckedChanged(object sender, EventArgs eventArgs)
        {
            if (((CheckBox)sender).Checked)
            {
                NotificationsController.Instance.EnableMasteryEdit();
                NotificationsController.Instance.SendMasteryNotification(GameInfo);
            }
            else
            {
                NotificationsController.Instance.DisableMasteryEdit();
            }
        }
        private void CustomNumericUpDown_ValueChanged(object sender, EventArgs eventArgs)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;

            switch (numericUpDown.Name)
            {
                case "userInfoSimpleFontOutlineNumericUpDown":
                    UserInfoController.Instance.SimpleFontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "userInfoNamesFontOutlineNumericUpDown":
                    UserInfoController.Instance.NameOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "userInfoValuesFontOutlineNumericUpDown":
                    UserInfoController.Instance.ValueOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "focusSimpleFontOutlineNumericUpDown":
                    FocusController.Instance.SimpleFontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "focusTitleFontOutlineNumericUpDown":
                    FocusController.Instance.TitleOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "focusDescriptionFontOutlineNumericUpDown":
                    FocusController.Instance.DescriptionOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "focusPointsFontOutlineNumericUpDown":
                    FocusController.Instance.PointsOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "focusLineOutlineNumericUpDown":
                    FocusController.Instance.LineOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationsSimpleFontOutlineNumericUpDown":
                    NotificationsController.Instance.SimpleFontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationsTitleFontOutlineNumericUpDown":
                    NotificationsController.Instance.TitleOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationsDescriptionFontOutlineNumericUpDown":
                    NotificationsController.Instance.DescriptionOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationsPointsFontOutlineNumericUpDown":
                    NotificationsController.Instance.PointsOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationsLineOutlineNumericUpDown":
                    NotificationsController.Instance.LineOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationsCustomAchievementXNumericUpDown":
                    NotificationsController.Instance.CustomAchievementX = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationsCustomAchievementYNumericUpDown":
                    NotificationsController.Instance.CustomAchievementY = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationsCustomAchievementScaleNumericUpDown":
                    NotificationsController.Instance.CustomAchievementScale = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationsCustomAchievementInNumericUpDown":
                    NotificationsController.Instance.CustomAchievementIn = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationsCustomAchievementInSpeedUpDown":
                    NotificationsController.Instance.CustomAchievementInSpeed = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationsCustomAchievementOutNumericUpDown":
                    NotificationsController.Instance.CustomAchievementOut = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationsCustomAchievementOutSpeedUpDown":
                    NotificationsController.Instance.CustomAchievementOutSpeed = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationsCustomMasteryXNumericUpDown":
                    NotificationsController.Instance.CustomMasteryX = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationsCustomMasteryYNumericUpDown":
                    NotificationsController.Instance.CustomMasteryY = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationsCustomMasteryScaleNumericUpDown":
                    NotificationsController.Instance.CustomMasteryScale = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationsCustomMasteryInNumericUpDown":
                    NotificationsController.Instance.CustomMasteryIn = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationsCustomMasteryInSpeedUpDown":
                    NotificationsController.Instance.CustomMasteryInSpeed = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationsCustomMasteryOutNumericUpDown":
                    NotificationsController.Instance.CustomMasteryOut = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "notificationsCustomMasteryOutSpeedUpDown":
                    NotificationsController.Instance.CustomMasteryOutSpeed = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "gameProgressSimpleFontOutlineNumericUpDown":
                    GameProgressController.Instance.SimpleFontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "gameProgressNamesFontOutlineNumericUpDown":
                    GameProgressController.Instance.NameOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "gameProgressValuesFontOutlineNumericUpDown":
                    GameProgressController.Instance.ValueOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "gameInfoSimpleFontOutlineNumericUpDown":
                    GameInfoController.Instance.SimpleFontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "gameInfoNamesFontOutlineNumericUpDown":
                    GameInfoController.Instance.NameOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "gameInfoValuesFontOutlineNumericUpDown":
                    GameInfoController.Instance.ValueOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "recentAchievementsSimpleFontOutlineNumericUpDown":
                    RecentAchievementsController.Instance.SimpleFontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "recentAchievementsTitleFontOutlineNumericUpDown":
                    RecentAchievementsController.Instance.TitleOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "recentAchievementsDescriptionFontOutlineNumericUpDown":
                    RecentAchievementsController.Instance.DescriptionOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "recentAchievementsPointsFontOutlineNumericUpDown":
                    RecentAchievementsController.Instance.PointsOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "recentAchievementsLineOutlineNumericUpDown":
                    RecentAchievementsController.Instance.LineOutlineSize = Convert.ToInt32(numericUpDown.Value);
                    break;
                case "recentAchievementsMaxListNumericUpDown":
                    RecentAchievementsController.Instance.MaxListSize = Convert.ToInt32(numericUpDown.Value);
                    RecentAchievementsController.Instance.SetAchievements(new List<Achievement>());
                    RecentAchievementsController.Instance.SetAchievements(UnlockedAchievements.ToList());
                    break;
            }
        }
        private void SelectCustomAchievementButton_Click(object sender, EventArgs eventArgs)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                NotificationsController.Instance.CustomAchievementFile = openFileDialog1.FileName;
            }
            else
            {
                if (customAchievementEnableCheckbox.Checked && string.IsNullOrEmpty(NotificationsController.Instance.CustomAchievementFile))
                {
                    customAchievementEnableCheckbox.Checked = false;
                }
            }
        }
        private void SelectCustomMasteryNotificationButton_Click(object sender, EventArgs eventArgs)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                NotificationsController.Instance.CustomMasteryFile = openFileDialog1.FileName;
            }
            else
            {
                if (customMasteryEnableCheckbox.Checked && string.IsNullOrEmpty(NotificationsController.Instance.CustomMasteryFile))
                {
                    customMasteryEnableCheckbox.Checked = false;
                }
            }
        }
        private void ShowAchievementButton_Click(object sender, EventArgs eventArgs)
        {
            List<Achievement> unlockedAchievements = UnlockedAchievements.ToList();

            if (unlockedAchievements.Count > 0)
            {
                unlockedAchievements.Sort();
                Achievement achievement = (Achievement)unlockedAchievements[unlockedAchievements.Count - 1].Clone();

                NotificationsController.Instance.EnqueueAchievementNotifications(new List<Achievement>() { achievement });
                StreamLabelManager.Instance.EnqueueAlert(achievement);
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

                NotificationsController.Instance.EnqueueAchievementNotifications(new List<Achievement>() {
                     achievement
                });
                StreamLabelManager.Instance.EnqueueAlert(achievement);
            }
            NotificationsController.Instance.RunNotifications();
            StreamLabelManager.Instance.RunNotifications();
        }
        private void ShowGameMasteryButton_Click(object sender, EventArgs eventArgs)
        {
            NotificationsController.Instance.EnqueueMasteryNotification(GameInfo);
            StreamLabelManager.Instance.EnqueueAlert(GameInfo);

            NotificationsController.Instance.RunNotifications();
            StreamLabelManager.Instance.RunNotifications();
        }
        private void SetFocusButton_Click(object sender, EventArgs e)
        {
            SetFocus();

            StreamLabelManager.Instance.RunNotifications();
        }
        private void MoveFocusIndexPrev_Click(object sender, EventArgs e)
        {
            CurrentlyViewingIndex--;

            if (CurrentlyViewingIndex < 0)
            {
                CurrentlyViewingIndex = 0;
            }

            UpdateCurrentlyViewingAchievement();
        }
        private void MoveFocusIndexNext_Click(object sender, EventArgs e)
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
                focusAchievementButtonPrevious.Enabled = false;
                focusAchievementButtonNext.Enabled = false;
                focusSetButton.Enabled = false;
            }
            else
            {
                focusSetButton.Enabled = true;

                if (CurrentlyViewingIndex == 0)
                {
                    focusAchievementButtonPrevious.Enabled = false;
                    focusAchievementButtonNext.Enabled = LockedAchievements.Count > 1;
                }
                else if (CurrentlyViewingIndex == LockedAchievements.Count - 1)
                {
                    focusAchievementButtonPrevious.Enabled = true;
                    focusAchievementButtonNext.Enabled = false;
                }
                else
                {
                    focusAchievementButtonPrevious.Enabled = true;
                    focusAchievementButtonNext.Enabled = true;
                }
            }
        }
        private void ShowWindowButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            switch (button.Name)
            {
                case "focusOpenWindowButton":
                    FocusController.Instance.Show();
                    SetFocus();

                    break;
                case "userInfoOpenWindowButton":
                    UserInfoController.Instance.Show();
                    break;
                case "gameProgressOpenWindowButton":
                    GameProgressController.Instance.Show();
                    break;
                case "notificationsOpenWindowButton":
                    NotificationsController.Instance.Show();
                    break;
                case "gameInfoOpenWindowButton":
                    GameInfoController.Instance.Show();
                    break;
                case "recentAchievementsOpenWindowButton":
                    RecentAchievementsController.Instance.Show();
                    break;
                case "achievementListOpenWindowButton":
                    AchievementListController.Instance.Show();
                    AchievementListController.Instance.UpdateAchievementList(UnlockedAchievements.ToList(), LockedAchievements.ToList(), true);
                    break;
            }
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
                switch (button.Name)
                {
                    case "userInfoSimpleFontColorBoxButton":
                        UserInfoController.Instance.SimpleFontColor = MediaHelper.HexConverter(colorDialog1.Color);
                        userInfoSimpleFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "userInfoSimpleFontOutlineColorBoxButton":
                        UserInfoController.Instance.SimpleFontOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        userInfoSimpleFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "userInfoNamesFontColorBoxButton":
                        UserInfoController.Instance.NameColor = MediaHelper.HexConverter(colorDialog1.Color);
                        userInfoNamesFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "userInfoNamesFontOutlineColorBoxButton":
                        UserInfoController.Instance.NameOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        userInfoNamesFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "userInfoValuesFontColorBoxButton":
                        UserInfoController.Instance.ValueColor = MediaHelper.HexConverter(colorDialog1.Color);
                        userInfoValuesFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "userInfoValuesFontOutlineColorBoxButton":
                        UserInfoController.Instance.ValueOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        userInfoValuesFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameInfoSimpleFontColorBoxButton":
                        GameInfoController.Instance.SimpleFontColor = MediaHelper.HexConverter(colorDialog1.Color);
                        gameInfoSimpleFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameInfoSimpleFontOutlineColorBoxButton":
                        GameInfoController.Instance.SimpleFontOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        gameInfoSimpleFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameInfoNamesFontColorBoxButton":
                        GameInfoController.Instance.NameColor = MediaHelper.HexConverter(colorDialog1.Color);
                        gameInfoNamesFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameInfoNamesFontOutlineColorBoxButton":
                        GameInfoController.Instance.NameOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        gameInfoNamesFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameInfoValuesFontColorBoxButton":
                        GameInfoController.Instance.ValueColor = MediaHelper.HexConverter(colorDialog1.Color);
                        gameInfoValuesFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameInfoValuesFontOutlineColorBoxButton":
                        GameInfoController.Instance.ValueOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        gameInfoValuesFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameProgressSimpleFontColorBoxButton":
                        GameProgressController.Instance.SimpleFontColor = MediaHelper.HexConverter(colorDialog1.Color);
                        gameProgressSimpleFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameProgressSimpleFontOutlineColorBoxButton":
                        GameProgressController.Instance.SimpleFontOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        gameProgressSimpleFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameProgressNamesFontColorBoxButton":
                        GameProgressController.Instance.NameColor = MediaHelper.HexConverter(colorDialog1.Color);
                        gameProgressNamesFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameProgressNamesFontOutlineColorBoxButton":
                        GameProgressController.Instance.NameOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        gameProgressNamesFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameProgressValuesFontColorBoxButton":
                        GameProgressController.Instance.ValueColor = MediaHelper.HexConverter(colorDialog1.Color);
                        gameProgressValuesFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameProgressValuesFontOutlineColorBoxButton":
                        GameProgressController.Instance.ValueOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        gameProgressValuesFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "focusSimpleFontSetColorButton":
                        FocusController.Instance.SimpleFontColor = MediaHelper.HexConverter(colorDialog1.Color);
                        focusSimpleFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "focusSimpleFontOutlineSetColorButton":
                        FocusController.Instance.SimpleFontOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        focusSimpleFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "focusTitleFontSetColorButton":
                        FocusController.Instance.TitleColor = MediaHelper.HexConverter(colorDialog1.Color);
                        focusTitleFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "focusTitleFontOutlineSetColorButton":
                        FocusController.Instance.TitleOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        focusTitleFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "focusDescriptionFontColorPictureBox":
                        FocusController.Instance.DescriptionColor = MediaHelper.HexConverter(colorDialog1.Color);
                        focusDescriptionFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "focusDescriptionFontOutlineSetColorButton":
                        FocusController.Instance.DescriptionOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        focusDescriptionFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "focusPointsFontSetColorButton":
                        FocusController.Instance.PointsColor = MediaHelper.HexConverter(colorDialog1.Color);
                        focusPointsFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "focusPointsFontOutlineSetColorButton":
                        FocusController.Instance.PointsOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        focusPointsFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "focusLineSetColorButton":
                        FocusController.Instance.LineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        focusLineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "focusLineOutlineSetColorButton":
                        FocusController.Instance.LineOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        focusLineOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "notificationsSimpleFontSetColorButton":
                        NotificationsController.Instance.SimpleFontColor = MediaHelper.HexConverter(colorDialog1.Color);
                        notificationsSimpleFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "notificationsSimpleFontOutlineSetColorButton":
                        NotificationsController.Instance.SimpleFontOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        notificationsSimpleFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "notificationsTitleFontSetColorButton":
                        NotificationsController.Instance.TitleColor = MediaHelper.HexConverter(colorDialog1.Color);
                        notificationsTitleFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "notificationsTitleFontOutlineSetColorButton":
                        NotificationsController.Instance.TitleOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        notificationsTitleFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "notificationsDescriptionFontSetColorButton":
                        NotificationsController.Instance.DescriptionColor = MediaHelper.HexConverter(colorDialog1.Color);
                        notificationsDescriptionFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "notificationsDescriptionFontOutlineSetColorButton":
                        NotificationsController.Instance.DescriptionOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        notificationsDescriptionFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "notificationsPointsFontSetColorButton":
                        NotificationsController.Instance.PointsColor = MediaHelper.HexConverter(colorDialog1.Color);
                        notificationsPointsFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "notificationsPointsFontOutlineSetColorButton":
                        NotificationsController.Instance.PointsOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        notificationsPointsFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "notificationsLineSetColorButton":
                        NotificationsController.Instance.LineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        notificationsLineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "notificationsLineOutlineSetColorButton":
                        NotificationsController.Instance.LineOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        notificationsLineOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "recentAchievementsSimpleFontSetColorButton":
                        RecentAchievementsController.Instance.SimpleFontColor = MediaHelper.HexConverter(colorDialog1.Color);
                        recentAchievementsSimpleFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "recentAchievementsSimpleFontOutlineSetColorButton":
                        RecentAchievementsController.Instance.SimpleFontOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        recentAchievementsSimpleFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "recentAchievementsTitleFontSetColorButton":
                        RecentAchievementsController.Instance.TitleColor = MediaHelper.HexConverter(colorDialog1.Color);
                        recentAchievementsTitleFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "recentAchievementsTitleFontOutlineSetColorButton":
                        RecentAchievementsController.Instance.TitleColor = MediaHelper.HexConverter(colorDialog1.Color);
                        recentAchievementsTitleFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "recentAchievementsDescriptionFontColorPictureBox":
                        RecentAchievementsController.Instance.DateColor = MediaHelper.HexConverter(colorDialog1.Color);
                        recentAchievementsDescriptionFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "recentAchievementsDescriptionFontOutlineSetColorButton":
                        RecentAchievementsController.Instance.DateOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        recentAchievementsDescriptionFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "recentAchievementsPointsFontSetColorButton":
                        RecentAchievementsController.Instance.PointsColor = MediaHelper.HexConverter(colorDialog1.Color);
                        recentAchievementsPointsFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "recentAchievementsPointsFontOutlineSetColorButton":
                        RecentAchievementsController.Instance.PointsOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        recentAchievementsPointsFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "recentAchievementsLineSetColorButton":
                        RecentAchievementsController.Instance.LineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        recentAchievementsLineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "recentAchievementsLineOutlineSetColorButton":
                        RecentAchievementsController.Instance.LineOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        recentAchievementsLineOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                }
            }
        }
        private void FontFamilyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FontFamily[] familyArray = FontFamily.Families.ToArray();
            FontFamily fontFamily = null;
            ComboBox comboBox = sender as ComboBox;

            foreach (FontFamily fontFamilyEntity in familyArray)
            {
                if (fontFamilyEntity.Name.Equals((string)comboBox.SelectedItem))
                {
                    fontFamily = fontFamilyEntity;
                    break;
                }
            }
            if (fontFamily != null)
            {
                switch (comboBox.Name)
                {
                    case "userInfoSimpleFontComboBox":
                        UserInfoController.Instance.SimpleFontFamily = fontFamily;
                        break;
                    case "userInfoNamesFontComboBox":
                        UserInfoController.Instance.NameFontFamily = fontFamily;
                        break;
                    case "userInfoValuesFontComboBox":
                        UserInfoController.Instance.ValueFontFamily = fontFamily;
                        break;
                    case "focusSimpleFontComboBox":
                        FocusController.Instance.SimpleFontFamily = fontFamily;
                        break;
                    case "focusTitleFontComboBox":
                        FocusController.Instance.TitleFontFamily = fontFamily;
                        break;
                    case "focusDescriptionFontComboBox":
                        FocusController.Instance.DescriptionFontFamily = fontFamily;
                        break;
                    case "focusPointsFontComboBox":
                        FocusController.Instance.PointsFontFamily = fontFamily;
                        break;
                    case "notificationsSimpleFontComboBox":
                        NotificationsController.Instance.SimpleFontFamily = fontFamily;
                        break;
                    case "notificationsTitleFontComboBox":
                        NotificationsController.Instance.TitleFontFamily = fontFamily;
                        break;
                    case "notificationsDescriptionFontComboBox":
                        NotificationsController.Instance.DescriptionFontFamily = fontFamily;
                        break;
                    case "notificationsPointsFontComboBox":
                        NotificationsController.Instance.PointsFontFamily = fontFamily;
                        break;
                    case "gameProgressSimpleFontComboBox":
                        GameProgressController.Instance.SimpleFontFamily = fontFamily;
                        break;
                    case "gameProgressNamesFontComboBox":
                        GameProgressController.Instance.NameFontFamily = fontFamily;
                        break;
                    case "gameProgressValuesFontComboBox":
                        GameProgressController.Instance.ValueFontFamily = fontFamily;
                        break;
                    case "gameInfoSimpleFontComboBox":
                        GameInfoController.Instance.SimpleFontFamily = fontFamily;
                        break;
                    case "gameInfoNamesFontComboBox":
                        GameInfoController.Instance.NameFontFamily = fontFamily;
                        break;
                    case "gameInfoValuesFontComboBox":
                        GameInfoController.Instance.ValueFontFamily = fontFamily;
                        break;
                    case "recentAchievementsSimpleFontComboBox":
                        RecentAchievementsController.Instance.SimpleFontFamily = fontFamily;
                        break;
                    case "recentAchievementsTitleFontComboBox":
                        RecentAchievementsController.Instance.TitleFontFamily = fontFamily;
                        break;
                    case "recentAchievementsDescriptionFontComboBox":
                        RecentAchievementsController.Instance.DateFontFamily = fontFamily;
                        break;
                    case "recentAchievementsPointsFontComboBox":
                        RecentAchievementsController.Instance.PointsFontFamily = fontFamily;
                        break;
                }
            }
        }
        private void BorderCheckBox_Click(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            switch(checkBox.Name)
            {
                case "focusBorderCheckBox":
                    FocusController.Instance.BorderEnabled = !FocusController.Instance.BorderEnabled;
                    checkBox.Checked = FocusController.Instance.BorderEnabled;
                    break;
                case "notificationsBorderCheckBox":
                    NotificationsController.Instance.BorderEnabled = !NotificationsController.Instance.BorderEnabled;
                    checkBox.Checked = NotificationsController.Instance.BorderEnabled;
                    break;
                case "recentAchievementsBorderCheckBox":
                    RecentAchievementsController.Instance.BorderEnabled = !RecentAchievementsController.Instance.BorderEnabled;
                    checkBox.Checked = RecentAchievementsController.Instance.BorderEnabled;
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
                            NotificationsController.Instance.AchievementAnimationIn = AnimationDirection.DOWN;
                            break;
                        case "LEFT":
                            NotificationsController.Instance.AchievementAnimationIn = AnimationDirection.LEFT;
                            break;
                        case "RIGHT":
                            NotificationsController.Instance.AchievementAnimationIn = AnimationDirection.RIGHT;
                            break;
                        case "UP":
                            NotificationsController.Instance.AchievementAnimationIn = AnimationDirection.UP;
                            break;
                        default:
                            NotificationsController.Instance.AchievementAnimationIn = AnimationDirection.STATIC;
                            break;
                    }
                    break;
                case "notificationsAchievementAnimationOutComboBox":
                    switch ((string)notificationsCustomAchievementAnimationOutComboBox.SelectedItem)
                    {
                        case "DOWN":
                            NotificationsController.Instance.AchievementAnimationOut = AnimationDirection.DOWN;
                            break;
                        case "LEFT":
                            NotificationsController.Instance.AchievementAnimationOut = AnimationDirection.LEFT;
                            break;
                        case "RIGHT":
                            NotificationsController.Instance.AchievementAnimationOut = AnimationDirection.RIGHT;
                            break;
                        case "UP":
                            NotificationsController.Instance.AchievementAnimationOut = AnimationDirection.UP;
                            break;
                        default:
                            NotificationsController.Instance.AchievementAnimationOut = AnimationDirection.STATIC;
                            break;
                    }
                    break;
                case "notificationsMasteryAnimationInComboBox":
                    switch ((string)notificationsCustomMasteryAnimationInComboBox.SelectedItem)
                    {
                        case "DOWN":
                            NotificationsController.Instance.MasteryAnimationIn = AnimationDirection.DOWN;
                            break;
                        case "LEFT":
                            NotificationsController.Instance.MasteryAnimationIn = AnimationDirection.LEFT;
                            break;
                        case "RIGHT":
                            NotificationsController.Instance.MasteryAnimationIn = AnimationDirection.RIGHT;
                            break;
                        case "UP":
                            NotificationsController.Instance.MasteryAnimationIn = AnimationDirection.UP;
                            break;
                        default:
                            NotificationsController.Instance.MasteryAnimationIn = AnimationDirection.STATIC;
                            break;
                    }
                    break;
                case "notificationsMasteryAnimationOutComboBox":
                    switch ((string)notificationsCustomMasteryAnimationOutComboBox.SelectedItem)
                    {
                        case "DOWN":
                            NotificationsController.Instance.MasteryAnimationOut = AnimationDirection.DOWN;
                            break;
                        case "LEFT":
                            NotificationsController.Instance.MasteryAnimationOut = AnimationDirection.LEFT;
                            break;
                        case "RIGHT":
                            NotificationsController.Instance.MasteryAnimationOut = AnimationDirection.RIGHT;
                            break;
                        case "UP":
                            NotificationsController.Instance.MasteryAnimationOut = AnimationDirection.UP;
                            break;
                        default:
                            NotificationsController.Instance.MasteryAnimationOut = AnimationDirection.STATIC;
                            break;
                    }
                    break;
            }
        }
        private void FontOutlineCheckBox_Click(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            switch (checkBox.Name)
            {
                case "userInfoSimpleOutlineCheckBox":
                    UserInfoController.Instance.SimpleFontOutlineEnabled = !UserInfoController.Instance.SimpleFontOutlineEnabled;
                    checkBox.Checked = UserInfoController.Instance.SimpleFontOutlineEnabled;
                    break;
                case "userInfoNamesOutlineCheckBox":
                    UserInfoController.Instance.NameOutlineEnabled = !UserInfoController.Instance.NameOutlineEnabled;
                    checkBox.Checked = UserInfoController.Instance.NameOutlineEnabled;
                    break;
                case "userInfoValuesOutlineCheckBox":
                    UserInfoController.Instance.ValueOutlineEnabled = !UserInfoController.Instance.ValueOutlineEnabled;
                    checkBox.Checked = UserInfoController.Instance.ValueOutlineEnabled;
                    break;
                case "focusSimpleOutlineCheckBox":
                    FocusController.Instance.SimpleFontOutlineEnabled = !FocusController.Instance.SimpleFontOutlineEnabled;
                    checkBox.Checked = FocusController.Instance.SimpleFontOutlineEnabled;
                    break;
                case "focusTitleOutlineCheckBox":
                    FocusController.Instance.TitleOutlineEnabled = !FocusController.Instance.TitleOutlineEnabled;
                    checkBox.Checked = FocusController.Instance.TitleOutlineEnabled;
                    break;
                case "focusDescriptionOutlineCheckBox":
                    FocusController.Instance.DescriptionOutlineEnabled = !FocusController.Instance.DescriptionOutlineEnabled;
                    checkBox.Checked = FocusController.Instance.DescriptionOutlineEnabled;
                    break;
                case "focusPointsOutlineCheckBox":
                    FocusController.Instance.PointsOutlineEnabled = !FocusController.Instance.PointsOutlineEnabled;
                    checkBox.Checked = FocusController.Instance.PointsOutlineEnabled;
                    break;
                case "focusLineOutlineCheckBox":
                    FocusController.Instance.LineOutlineEnabled = !FocusController.Instance.LineOutlineEnabled;
                    checkBox.Checked = FocusController.Instance.LineOutlineEnabled;
                    break;
                case "notificationsSimpleOutlineCheckBox":
                    NotificationsController.Instance.SimpleFontOutlineEnabled = !NotificationsController.Instance.SimpleFontOutlineEnabled;
                    checkBox.Checked = NotificationsController.Instance.SimpleFontOutlineEnabled;
                    break;
                case "notificationsTitleOutlineCheckBox":
                    NotificationsController.Instance.TitleOutlineEnabled = !NotificationsController.Instance.TitleOutlineEnabled;
                    checkBox.Checked = NotificationsController.Instance.TitleOutlineEnabled;
                    break;
                case "notificationsDescriptionOutlineCheckBox":
                    NotificationsController.Instance.DescriptionOutlineEnabled = !NotificationsController.Instance.DescriptionOutlineEnabled;
                    checkBox.Checked = NotificationsController.Instance.DescriptionOutlineEnabled;
                    break;
                case "notificationsPointsOutlineCheckBox":
                    NotificationsController.Instance.PointsOutlineEnabled = !NotificationsController.Instance.PointsOutlineEnabled;
                    checkBox.Checked = NotificationsController.Instance.PointsOutlineEnabled;
                    break;
                case "notificationsLineOutlineCheckBox":
                    NotificationsController.Instance.LineOutlineEnabled = !NotificationsController.Instance.LineOutlineEnabled;
                    checkBox.Checked = NotificationsController.Instance.LineOutlineEnabled;
                    break;
                case "gameProgressSimpleOutlineCheckBox":
                    GameProgressController.Instance.SimpleFontOutlineEnabled = !GameProgressController.Instance.SimpleFontOutlineEnabled;
                    checkBox.Checked = GameProgressController.Instance.SimpleFontOutlineEnabled;
                    break;
                case "gameProgressNamesOutlineCheckBox":
                    GameProgressController.Instance.NameOutlineEnabled = !GameProgressController.Instance.NameOutlineEnabled;
                    checkBox.Checked = GameProgressController.Instance.NameOutlineEnabled;
                    break;
                case "gameProgressValuesOutlineCheckBox":
                    GameProgressController.Instance.ValueOutlineEnabled = !GameProgressController.Instance.ValueOutlineEnabled;
                    checkBox.Checked = GameProgressController.Instance.ValueOutlineEnabled;
                    break;
                case "gameInfoSimpleOutlineCheckBox":
                    GameInfoController.Instance.SimpleFontOutlineEnabled = !GameInfoController.Instance.SimpleFontOutlineEnabled;
                    checkBox.Checked = GameInfoController.Instance.SimpleFontOutlineEnabled;
                    break;
                case "gameInfoNamesOutlineCheckBox":
                    GameInfoController.Instance.NameOutlineEnabled = !GameInfoController.Instance.NameOutlineEnabled;
                    checkBox.Checked = GameInfoController.Instance.NameOutlineEnabled;
                    break;
                case "gameInfoValuesOutlineCheckBox":
                    GameInfoController.Instance.ValueOutlineEnabled = !GameInfoController.Instance.ValueOutlineEnabled;
                    checkBox.Checked = GameInfoController.Instance.ValueOutlineEnabled;
                    break;
                case "recentAchievementsSimpleFontOutlineCheckBox":
                    RecentAchievementsController.Instance.SimpleFontOutlineEnabled = !RecentAchievementsController.Instance.SimpleFontOutlineEnabled;
                    checkBox.Checked = RecentAchievementsController.Instance.SimpleFontOutlineEnabled;
                    break;
                case "recentAchievementsTitleFontOutlineCheckBox":
                    RecentAchievementsController.Instance.TitleOutlineEnabled = !RecentAchievementsController.Instance.TitleOutlineEnabled;
                    checkBox.Checked = RecentAchievementsController.Instance.TitleOutlineEnabled;
                    break;
                case "recentAchievementsDescriptionFontOutlineCheckBox":
                    RecentAchievementsController.Instance.DescriptionOutlineEnabled = !RecentAchievementsController.Instance.DescriptionOutlineEnabled;
                    checkBox.Checked = RecentAchievementsController.Instance.DescriptionOutlineEnabled;
                    break;
                case "recentAchievementsPointsFontOutlineCheckBox":
                    RecentAchievementsController.Instance.PointsOutlineEnabled = !RecentAchievementsController.Instance.PointsOutlineEnabled;
                    checkBox.Checked = RecentAchievementsController.Instance.PointsOutlineEnabled;
                    break;
                case "recentAchievementsLineOutlineCheckBox":
                    RecentAchievementsController.Instance.LineOutlineEnabled = !RecentAchievementsController.Instance.LineOutlineEnabled;
                    checkBox.Checked = RecentAchievementsController.Instance.LineOutlineEnabled;
                    break;
            }
        }
        private void SimpleCheckBox_Click(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            switch (checkBox.Name)
            {
                case "userInfoSimpleCheckBox":
                    UserInfoController.Instance.AdvancedSettingsEnabled = !UserInfoController.Instance.AdvancedSettingsEnabled;
                    checkBox.Checked = !UserInfoController.Instance.AdvancedSettingsEnabled;

                    if (UserInfoController.Instance.AdvancedSettingsEnabled)
                    {
                        userInfoNamesGroupBox.Show();
                        userInfoValuesGroupBox.Show();
                    }
                    else
                    {
                        userInfoNamesGroupBox.Hide();
                        userInfoValuesGroupBox.Hide();
                    }
                    break;
                case "gameInfoSimpleCheckBox":
                    GameInfoController.Instance.AdvancedSettingsEnabled = !GameInfoController.Instance.AdvancedSettingsEnabled;
                    checkBox.Checked = !GameInfoController.Instance.AdvancedSettingsEnabled;

                    if (GameInfoController.Instance.AdvancedSettingsEnabled)
                    {
                        gameInfoNamesGroupBox.Show();
                        gameInfoValuesGroupBox.Show();
                    }
                    else
                    {
                        gameInfoNamesGroupBox.Hide();
                        gameInfoValuesGroupBox.Hide();
                    }
                    break;
                case "gameProgressSimpleCheckBox":
                    GameProgressController.Instance.AdvancedSettingsEnabled = !GameProgressController.Instance.AdvancedSettingsEnabled;
                    checkBox.Checked = !GameProgressController.Instance.AdvancedSettingsEnabled;

                    if (GameProgressController.Instance.AdvancedSettingsEnabled)
                    {
                        gameProgressNamesGroupBox.Show();
                        gameProgressValuesGroupBox.Show();
                    }
                    else
                    {
                        gameProgressNamesGroupBox.Hide();
                        gameProgressValuesGroupBox.Hide();
                    }
                    break;
                case "focusSimpleCheckBox":
                    FocusController.Instance.AdvancedSettingsEnabled = !FocusController.Instance.AdvancedSettingsEnabled;
                    checkBox.Checked = !FocusController.Instance.AdvancedSettingsEnabled;

                    if (FocusController.Instance.AdvancedSettingsEnabled)
                    {
                        focusTitleGroupBox.Show();
                        focusDescriptionGroupBox.Show();
                        focusPointsGroupBox.Show();
                        focusLineGroupBox.Show();
                    }
                    else
                    {
                        focusTitleGroupBox.Hide();
                        focusDescriptionGroupBox.Hide();
                        focusPointsGroupBox.Hide();
                        focusLineGroupBox.Hide();
                    }
                    break;
                case "notificationsSimpleCheckBox":
                    NotificationsController.Instance.AdvancedSettingsEnabled = !NotificationsController.Instance.AdvancedSettingsEnabled;
                    checkBox.Checked = !NotificationsController.Instance.AdvancedSettingsEnabled;

                    if (NotificationsController.Instance.AdvancedSettingsEnabled)
                    {
                        notificationsTitleGroupBox.Show();
                        notificationsDescriptionGroupBox.Show();
                        notificationsPointsGroupBox.Show();
                        notificationsLineGroupBox.Show();
                    }
                    else
                    {
                        notificationsTitleGroupBox.Hide();
                        notificationsDescriptionGroupBox.Hide();
                        notificationsPointsGroupBox.Hide();
                        notificationsLineGroupBox.Hide();
                    }
                    break;
                case "recentAchievementsSimpleCheckBox":
                    RecentAchievementsController.Instance.AdvancedSettingsEnabled = !RecentAchievementsController.Instance.AdvancedSettingsEnabled;
                    checkBox.Checked = !RecentAchievementsController.Instance.AdvancedSettingsEnabled;

                    if (RecentAchievementsController.Instance.AdvancedSettingsEnabled)
                    {
                        recentAchievementsTitleGroupBox.Show();
                        recentAchievementsDescriptionGroupBox.Show();
                        recentAchievementsPointsGroupBox.Show();
                        recentAchievementsLineGroupBox.Show();
                    }
                    else
                    {
                        recentAchievementsTitleGroupBox.Hide();
                        recentAchievementsDescriptionGroupBox.Hide();
                        recentAchievementsPointsGroupBox.Hide();
                        recentAchievementsLineGroupBox.Hide();
                    }
                    break;
            }
        }
        private void BackgroundColorButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                switch (button.Name)
                {
                    case "userInfoSetBackgroundColorButton":
                        UserInfoController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        userInfoBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameProgressSetBackgroundColorButton":
                        GameProgressController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        gameProgressBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameInfoSetBackgroundColorButton":
                        GameInfoController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        gameInfoBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "focusSetBackgroundColorButton":
                        FocusController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        focusBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "notificationsSetBackgroundColorButton":
                        NotificationsController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        notificationsBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "recentAchievementsSetBackgroundColorButton":
                        RecentAchievementsController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        recentAchievementsBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "achievementListSetBackgroundColorButton":
                        AchievementListController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        achievementListBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "focusSetBorderColorButton":
                        FocusController.Instance.BorderBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        focusBorderColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "notificationsSetBorderColorButton":
                        NotificationsController.Instance.BorderBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        notificationsBorderColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "recentAchievementsSetBorderColorButton":
                        RecentAchievementsController.Instance.BorderBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        recentAchievementsBorderColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                }
            }
        }
        private void DefaultButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            switch (button.Name)
            {
                case "gameInfoDefaultButton":
                    gameInfoTitleTextBox.Text = "Title";
                    gameInfoConsoleTextBox.Text = "Console";
                    gameInfoDeveloperTextBox.Text = "Developer";
                    gameInfoPublisherTextBox.Text = "Publisher";
                    gameInfoGenreTextBox.Text = "Genre";
                    gameInfoReleaseDateTextBox.Text = "Released";
                    break;
                case "userInfoDefaultButton":
                    userInfoRankTextBox.Text = "Rank";
                    userInfoPointsTextBox.Text = "Points";
                    userInfoTruePointsTextBox.Text = "True Points";
                    userInfoRatioTextBox.Text = "Ratio";
                    break;
                case "gameProgressDefaultButton":
                    gameProgressRatioTextBox.Text = "Ratio";
                    gameProgressPointsTextBox.Text = "Points";
                    gameProgressTruePointsTextBox.Text = "True Points";
                    gameProgressAchievementsTextBox.Text = "Cheevos";
                    gameProgressCompletedTextBox.Text = "Compeleted";
                    break;
            }
        }
        private void StreamLabelEnableCheckBox_Clicked(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            switch (checkBox.Name)
            {
                case "userInfoRankCheckBox":
                    UserInfoController.Instance.RankEnabled = checkBox.Checked;
                    break;
                case "userInfoPointsCheckBox":
                    UserInfoController.Instance.PointsEnabled = checkBox.Checked;
                    break;
                case "userInfoTruePointsCheckBox":
                    UserInfoController.Instance.TruePointsEnabled = checkBox.Checked;
                    break;
                case "userInfoRatioCheckBox":
                    UserInfoController.Instance.RatioEnabled = checkBox.Checked;
                    break;
                case "gameProgressAchievementsCheckBox":
                    GameProgressController.Instance.GameAchievementsEnabled = checkBox.Checked;
                    break;
                case "gameProgressPointsCheckBox":
                    GameProgressController.Instance.GamePointsEnabled = checkBox.Checked;
                    break;
                case "gameProgressTruePointsCheckBox":
                    GameProgressController.Instance.GameTruePointsEnabled = checkBox.Checked;
                    break;
                case "gameProgressCompletedCheckBox":
                    GameProgressController.Instance.CompletedEnabled = checkBox.Checked;
                    break;
                case "gameProgressRatioCheckBox":
                    GameProgressController.Instance.GameRatioEnabled = checkBox.Checked;
                    break;
                case "gameInfoTitleCheckBox":
                    GameInfoController.Instance.TitleEnabled = checkBox.Checked;
                    break;
                case "gameInfoDeveloperCheckBox":
                    GameInfoController.Instance.DeveloperEnabled = checkBox.Checked;
                    break;
                case "gameInfoPublisherCheckBox":
                    GameInfoController.Instance.PublisherEnabled = checkBox.Checked;
                    break;
                case "gameInfoConsoleCheckBox":
                    GameInfoController.Instance.ConsoleEnabled = checkBox.Checked;
                    break;
                case "gameInfoGenreCheckBox":
                    GameInfoController.Instance.GenreEnabled = checkBox.Checked;
                    break;
                case "gameInfoReleasedCheckBox":
                    GameInfoController.Instance.ReleasedDateEnabled = checkBox.Checked;
                    break;
            }
        }
        private void OverrideTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            switch (textBox.Name)
            {
                case "userInfoRankTextBox":
                    UserInfoController.Instance.RankName = textBox.Text;
                    break;
                case "userInfoPointsTextBox":
                    UserInfoController.Instance.PointsName = textBox.Text;
                    break;
                case "userInfoTruePointsTextBox":
                    UserInfoController.Instance.TruePointsName = textBox.Text;
                    break;
                case "userInfoRatioTextBox":
                    UserInfoController.Instance.RatioName = textBox.Text;
                    break;
                case "gameProgressAchievementsTextBox":
                    GameProgressController.Instance.GameAchievementsName = textBox.Text;
                    break;
                case "gameProgressPointsTextBox":
                    GameProgressController.Instance.GamePointsName = textBox.Text;
                    break;
                case "gameProgressTruePointsTextBox":
                    GameProgressController.Instance.GameTruePointsName = textBox.Text;
                    break;
                case "gameProgressCompletedTextBox":
                    GameProgressController.Instance.CompletedName = textBox.Text;
                    break;
                case "gameProgressRatioTextBox":
                    GameProgressController.Instance.GameRatioName = textBox.Text;
                    break;
                case "gameInfoConsoleTextBox":
                    GameInfoController.Instance.ConsoleName = textBox.Text;
                    break;
                case "gameInfoDeveloperTextBox":
                    GameInfoController.Instance.DeveloperName = textBox.Text;
                    break;
                case "gameInfoPublisherTextBox":
                    GameInfoController.Instance.PublisherName = textBox.Text;
                    break;
                case "gameInfoGenreTextBox":
                    GameInfoController.Instance.GenreName = textBox.Text;
                    break;
                case "gameInfoReleaseDateTextBox":
                    GameInfoController.Instance.ReleasedDateName = textBox.Text;
                    break;
                case "gameInfoTitleTextBox":
                    GameInfoController.Instance.TitleName = textBox.Text;
                    break;
            }
        }
        private void RadioButton_Clicked(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton.Checked)
            {
                switch (radioButton.Name)
                {
                    case "gameProgressRadioButtonBackslash":
                        gameProgressRadioButtonBackslash.Checked = true;
                        gameProgressRadioButtonSemicolon.Checked = false;
                        gameProgressRadioButtonDot.Checked = false;
                        GameProgressController.Instance.DividerCharacter = "/";
                        break;
                    case "gameProgressRadioButtonSemicolon":
                        gameProgressRadioButtonBackslash.Checked = false;
                        gameProgressRadioButtonSemicolon.Checked = true;
                        gameProgressRadioButtonDot.Checked = false;
                        GameProgressController.Instance.DividerCharacter = ":";
                        break;
                    case "gameProgressRadioButtonDot":
                        gameProgressRadioButtonBackslash.Checked = false;
                        gameProgressRadioButtonSemicolon.Checked = false;
                        gameProgressRadioButtonDot.Checked = true;
                        GameProgressController.Instance.DividerCharacter = ".";
                        break;
                    case "focusBehaviorGoToFirstRadioButton":
                        focusBehaviorGoToFirstRadioButton.Checked = true;
                        focusBehaviorGoToPreviousRadioButton.Checked = false;
                        focusBehaviorGoToNextRadioButton.Checked = false;
                        focusBehaviorGoToLastRadioButton.Checked = false;
                        FocusController.Instance.RefocusBehavior = RefocusBehaviorEnum.GO_TO_FIRST;
                        break;
                    case "focusBehaviorGoToPreviousRadioButton":
                        focusBehaviorGoToFirstRadioButton.Checked = false;
                        focusBehaviorGoToPreviousRadioButton.Checked = true;
                        focusBehaviorGoToNextRadioButton.Checked = false;
                        focusBehaviorGoToLastRadioButton.Checked = false;
                        FocusController.Instance.RefocusBehavior = RefocusBehaviorEnum.GO_TO_PREVIOUS;
                        break;
                    case "focusBehaviorGoToNextRadioButton":
                        focusBehaviorGoToFirstRadioButton.Checked = false;
                        focusBehaviorGoToPreviousRadioButton.Checked = false;
                        focusBehaviorGoToNextRadioButton.Checked = true;
                        focusBehaviorGoToLastRadioButton.Checked = false;
                        FocusController.Instance.RefocusBehavior = RefocusBehaviorEnum.GO_TO_NEXT;
                        break;
                    case "focusBehaviorGoToLastRadioButton":
                        focusBehaviorGoToFirstRadioButton.Checked = false;
                        focusBehaviorGoToPreviousRadioButton.Checked = false;
                        focusBehaviorGoToNextRadioButton.Checked = false;
                        focusBehaviorGoToLastRadioButton.Checked = true;
                        FocusController.Instance.RefocusBehavior = RefocusBehaviorEnum.GO_TO_LAST;
                        break;
                }
            }
        }
        private void BrowserSensitiveControl_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            switch (control.Name)
            {
                case "userProfilePictureBox":
                    tabControl1.SelectedIndex = 7;
                    chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser("https://retroachievements.org/User/" + Settings.Default.ra_username)
                    {
                        Location = new Point(5, 12),
                        ActivateBrowserOnCreation = false,
                        Name = "chromiumWebBrowser",
                        Size = new Size(552, 436),
                        TabIndex = 0,
                        Dock = DockStyle.None
                    };
                    break;
                case "gameInfoPictureBox":
                    tabControl1.SelectedIndex = 7;
                    chromiumWebBrowser.LoadUrl("https://retroachievements.org/game/" + GameInfo.Id);
                    break;
                case "focusAchievementPictureBox":
                    if (CurrentlyViewingAchievement != null)
                    {
                        tabControl1.SelectedIndex = 7;
                        chromiumWebBrowser.LoadUrl("https://retroachievements.org/achievement/" + CurrentlyViewingAchievement.Id);
                    }
                    break;
                case "rssFeedListView":
                    ListView listView = (ListView)sender;

                    if (listView.SelectedItems.Count > 0)
                    {
                        if (listView.SelectedItems[0].SubItems[0].Text.Contains("[FORUM] ") || listView.SelectedItems[0].SubItems[0].Text.Contains("[CHEEVO] "))
                        {
                            chromiumWebBrowser.LoadUrl(listView.SelectedItems[0].SubItems[3].Text);
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
                            this.tabPage10.Controls.Remove(chromiumWebBrowser);
                            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(s))
                            {
                                Location = new Point(334, 3),
                                ActivateBrowserOnCreation = false,
                                Name = "chromiumWebBrowser",
                                Size = new Size(432, 286),
                                TabIndex = 0,
                                Dock = DockStyle.None
                            };
                            this.tabPage10.Controls.Add(chromiumWebBrowser);
                        }
                    }
                    break;
            }
        }
        private void LoadProperties()
        {
            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser("https://retroachievements.org/User/" + Settings.Default.ra_username)
            {
                Location = new Point(334, 3),
                ActivateBrowserOnCreation = false,
                Name = "chromiumWebBrowser",
                Size = new Size(432, 286),
                TabIndex = 0,
                Dock = DockStyle.None
            };
            this.tabPage10.Controls.Add(chromiumWebBrowser);

            if (Settings.Default.UpdateSettings)
            {
                Settings.Default.Upgrade();

                Settings.Default.UpdateSettings = false;

                Settings.Default.Save();
            }

            usernameTextBox.Text = Settings.Default.ra_username;
            usernameTextBox.TextChanged += RequiredField_TextChanged;

            apiKeyTextBox.Text = Settings.Default.ra_key;
            apiKeyTextBox.TextChanged += RequiredField_TextChanged;

            webBrowserAutoOpenCheckbox.Checked = Settings.Default.web_browser_auto_launch;
            webBrowserAutoOpenCheckbox.Click += AutoLaunchCheckBox_CheckedChanged;

            /*
             * Start/Stop
             */
            autoStartCheckbox.Checked = Settings.Default.auto_start_checked;
            autoStartCheckbox.Click += AutoLaunchCheckBox_CheckedChanged;

            startButton.Click += StartButton_Click;
            stopButton.Click += StopButton_Click;

            /*
             * User Info Tab
             */
            userInfoAutoOpenWindowCheckbox.Checked = UserInfoController.Instance.AutoLaunch;
            userInfoAutoOpenWindowCheckbox.Click += AutoLaunchCheckBox_CheckedChanged;

            userInfoBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(UserInfoController.Instance.WindowBackgroundColor);
            userInfoSetBackgroundColorButton.Click += BackgroundColorButton_Click;

            userInfoDefaultButton.Click += DefaultButton_Click;

            SetFontFamilyBox(userInfoSimpleFontComboBox, UserInfoController.Instance.SimpleFontFamily);
            SetFontFamilyBox(userInfoNamesFontComboBox, UserInfoController.Instance.NameFontFamily);
            SetFontFamilyBox(userInfoValuesFontComboBox, UserInfoController.Instance.ValueFontFamily);

            userInfoSimpleOutlineCheckBox.Checked = UserInfoController.Instance.SimpleFontOutlineEnabled;
            userInfoNamesOutlineCheckBox.Checked = UserInfoController.Instance.NameOutlineEnabled;
            userInfoValuesOutlineCheckBox.Checked = UserInfoController.Instance.ValueOutlineEnabled;

            userInfoSimpleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(UserInfoController.Instance.SimpleFontColor);
            userInfoSimpleFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(UserInfoController.Instance.SimpleFontOutlineColor);
            userInfoNamesFontColorPictureBox.BackColor = ColorTranslator.FromHtml(UserInfoController.Instance.NameColor);
            userInfoNamesFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(UserInfoController.Instance.NameOutlineColor);
            userInfoValuesFontColorPictureBox.BackColor = ColorTranslator.FromHtml(UserInfoController.Instance.ValueColor);
            userInfoValuesFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(UserInfoController.Instance.ValueOutlineColor);

            userInfoSimpleCheckBox.Checked = false;

            if (!UserInfoController.Instance.AdvancedSettingsEnabled)
            {
                userInfoNamesGroupBox.Hide();
                userInfoValuesGroupBox.Hide();

                userInfoSimpleCheckBox.Checked = true;
            }

            userInfoSimpleCheckBox.Click += SimpleCheckBox_Click;

            userInfoSimpleOutlineCheckBox.Click += FontOutlineCheckBox_Click;
            userInfoNamesOutlineCheckBox.Click += FontOutlineCheckBox_Click;
            userInfoValuesOutlineCheckBox.Click += FontOutlineCheckBox_Click;

            userInfoSimpleFontComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;
            userInfoNamesFontComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;
            userInfoValuesFontComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;

            userInfoRankCheckBox.Checked = UserInfoController.Instance.RankEnabled;
            userInfoPointsCheckBox.Checked = UserInfoController.Instance.PointsEnabled;
            userInfoTruePointsCheckBox.Checked = UserInfoController.Instance.TruePointsEnabled;
            userInfoRatioCheckBox.Checked = UserInfoController.Instance.RatioEnabled;
            userInfoRankTextBox.TextChanged += OverrideTextBox_TextChanged;
            userInfoPointsTextBox.TextChanged += OverrideTextBox_TextChanged;
            userInfoTruePointsTextBox.TextChanged += OverrideTextBox_TextChanged;
            userInfoRatioTextBox.TextChanged += OverrideTextBox_TextChanged;

            userInfoSimpleFontColorBoxButton.Click += FontColorButton_Click;
            userInfoSimpleFontOutlineColorBoxButton.Click += FontColorButton_Click;
            userInfoNamesFontColorBoxButton.Click += FontColorButton_Click;
            userInfoNamesFontOutlineColorBoxButton.Click += FontColorButton_Click;
            userInfoValuesFontColorBoxButton.Click += FontColorButton_Click;
            userInfoValuesFontOutlineColorBoxButton.Click += FontColorButton_Click;

            userInfoSimpleFontOutlineNumericUpDown.Value = UserInfoController.Instance.SimpleFontOutlineSize;
            userInfoNamesFontOutlineNumericUpDown.Value = UserInfoController.Instance.NameOutlineSize;
            userInfoValuesFontOutlineNumericUpDown.Value = UserInfoController.Instance.ValueOutlineSize;

            userInfoSimpleFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            userInfoNamesFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            userInfoValuesFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;

            userProfilePictureBox.Click += BrowserSensitiveControl_Click;

            /*
             * Game Info Tab
             */
            gameInfoAutoOpenWindowCheckbox.Checked = GameInfoController.Instance.AutoLaunch;
            gameInfoAutoOpenWindowCheckbox.Click += AutoLaunchCheckBox_CheckedChanged;

            gameInfoBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoController.Instance.WindowBackgroundColor);
            gameInfoSetBackgroundColorButton.Click += BackgroundColorButton_Click;

            gameInfoDefaultButton.Click += DefaultButton_Click;

            SetFontFamilyBox(gameInfoSimpleFontComboBox, GameInfoController.Instance.SimpleFontFamily);
            SetFontFamilyBox(gameInfoNamesFontComboBox, GameInfoController.Instance.NameFontFamily);
            SetFontFamilyBox(gameInfoValuesFontComboBox, GameInfoController.Instance.ValueFontFamily);
            gameInfoSimpleOutlineCheckBox.Checked = GameInfoController.Instance.SimpleFontOutlineEnabled;
            gameInfoNamesOutlineCheckBox.Checked = GameInfoController.Instance.NameOutlineEnabled;
            gameInfoValuesOutlineCheckBox.Checked = GameInfoController.Instance.ValueOutlineEnabled;

            gameInfoSimpleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoController.Instance.SimpleFontColor);
            gameInfoSimpleFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoController.Instance.SimpleFontOutlineColor);
            gameInfoNamesFontColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoController.Instance.NameColor);
            gameInfoNamesFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoController.Instance.NameOutlineColor);
            gameInfoValuesFontColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoController.Instance.ValueColor);
            gameInfoValuesFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoController.Instance.ValueOutlineColor);

            gameInfoSimpleFontOutlineNumericUpDown.Value = GameInfoController.Instance.SimpleFontOutlineSize;
            gameInfoNamesFontOutlineNumericUpDown.Value = GameInfoController.Instance.NameOutlineSize;
            gameInfoValuesFontOutlineNumericUpDown.Value = GameInfoController.Instance.ValueOutlineSize;

            gameInfoSimpleFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            gameInfoNamesFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            gameInfoValuesFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;

            if (!GameProgressController.Instance.AdvancedSettingsEnabled)
            {
                gameInfoNamesGroupBox.Hide();
                gameInfoValuesGroupBox.Hide();

                gameInfoSimpleCheckBox.Checked = true;
            }

            gameInfoSimpleCheckBox.Click += SimpleCheckBox_Click;

            gameInfoSimpleOutlineCheckBox.Click += FontOutlineCheckBox_Click;
            gameInfoNamesOutlineCheckBox.Click += FontOutlineCheckBox_Click;
            gameInfoValuesOutlineCheckBox.Click += FontOutlineCheckBox_Click;

            gameInfoSimpleFontComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;
            gameInfoNamesFontComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;
            gameInfoValuesFontComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;

            gameInfoTitleCheckBox.Checked = GameInfoController.Instance.TitleEnabled;
            gameInfoDeveloperCheckBox.Checked = GameInfoController.Instance.DeveloperEnabled;
            gameInfoPublisherCheckBox.Checked = GameInfoController.Instance.PublisherEnabled;
            gameInfoConsoleCheckBox.Checked = GameInfoController.Instance.ConsoleEnabled;
            gameInfoGenreCheckBox.Checked = GameInfoController.Instance.GenreEnabled;
            gameInfoReleasedCheckBox.Checked = GameInfoController.Instance.ReleasedDateEnabled;

            gameInfoTitleTextBox.TextChanged += OverrideTextBox_TextChanged;
            gameInfoDeveloperTextBox.TextChanged += OverrideTextBox_TextChanged;
            gameInfoPublisherTextBox.TextChanged += OverrideTextBox_TextChanged;
            gameInfoConsoleTextBox.TextChanged += OverrideTextBox_TextChanged;
            gameInfoGenreTextBox.TextChanged += OverrideTextBox_TextChanged;
            gameInfoReleaseDateTextBox.TextChanged += OverrideTextBox_TextChanged;

            gameInfoPictureBox.Click += BrowserSensitiveControl_Click;

            gameInfoSimpleFontColorBoxButton.Click += FontColorButton_Click;
            gameInfoSimpleFontOutlineColorBoxButton.Click += FontColorButton_Click;
            gameInfoNamesFontColorBoxButton.Click += FontColorButton_Click;
            gameInfoNamesFontOutlineColorBoxButton.Click += FontColorButton_Click;
            gameInfoValuesFontColorBoxButton.Click += FontColorButton_Click;
            gameInfoValuesFontOutlineColorBoxButton.Click += FontColorButton_Click;

            /*
             * Game Progress Tab
             */
            gameProgressAutoOpenWindowCheckbox.Checked = GameProgressController.Instance.AutoLaunch;
            gameProgressAutoOpenWindowCheckbox.Click += AutoLaunchCheckBox_CheckedChanged;

            gameProgressBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(GameProgressController.Instance.WindowBackgroundColor);
            gameProgressSetBackgroundColorButton.Click += BackgroundColorButton_Click;

            gameProgressDefaultButton.Click += DefaultButton_Click;

            SetFontFamilyBox(gameProgressSimpleFontComboBox, GameProgressController.Instance.SimpleFontFamily);
            SetFontFamilyBox(gameProgressNamesFontComboBox, GameProgressController.Instance.NameFontFamily);
            SetFontFamilyBox(gameProgressValuesFontComboBox, GameProgressController.Instance.ValueFontFamily);
            gameProgressSimpleOutlineCheckBox.Checked = GameProgressController.Instance.SimpleFontOutlineEnabled;
            gameProgressNamesOutlineCheckBox.Checked = GameProgressController.Instance.NameOutlineEnabled;
            gameProgressValuesOutlineCheckBox.Checked = GameProgressController.Instance.ValueOutlineEnabled;

            gameProgressSimpleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(GameProgressController.Instance.SimpleFontColor);
            gameProgressSimpleFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(GameProgressController.Instance.SimpleFontOutlineColor);
            gameProgressNamesFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(GameProgressController.Instance.NameOutlineColor);
            gameProgressNamesFontColorPictureBox.BackColor = ColorTranslator.FromHtml(GameProgressController.Instance.NameColor);
            gameProgressValuesFontColorPictureBox.BackColor = ColorTranslator.FromHtml(GameProgressController.Instance.ValueColor);
            gameProgressValuesFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(GameProgressController.Instance.ValueOutlineColor);

            if (!GameProgressController.Instance.AdvancedSettingsEnabled)
            {
                gameProgressNamesGroupBox.Hide();
                gameProgressValuesGroupBox.Hide();

                gameProgressSimpleCheckBox.Checked = true;
            }

            gameProgressSimpleCheckBox.Click += SimpleCheckBox_Click;

            gameProgressSimpleFontComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;
            gameProgressNamesFontComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;
            gameProgressValuesFontComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;

            gameProgressSimpleOutlineCheckBox.Click += FontOutlineCheckBox_Click;
            gameProgressNamesOutlineCheckBox.Click += FontOutlineCheckBox_Click;
            gameProgressValuesOutlineCheckBox.Click += FontOutlineCheckBox_Click;

            gameProgressAchievementsCheckBox.Checked = GameProgressController.Instance.GameAchievementsEnabled;
            gameProgressPointsCheckBox.Checked = GameProgressController.Instance.GamePointsEnabled;
            gameProgressTruePointsCheckBox.Checked = GameProgressController.Instance.GameTruePointsEnabled;
            gameProgressCompletedCheckBox.Checked = GameProgressController.Instance.CompletedEnabled;
            gameProgressRatioCheckBox.Checked = GameProgressController.Instance.GameRatioEnabled;

            gameProgressAchievementsTextBox.TextChanged += OverrideTextBox_TextChanged;
            gameProgressPointsTextBox.TextChanged += OverrideTextBox_TextChanged;
            gameProgressTruePointsTextBox.TextChanged += OverrideTextBox_TextChanged;
            gameProgressCompletedTextBox.TextChanged += OverrideTextBox_TextChanged;
            gameProgressRatioTextBox.TextChanged += OverrideTextBox_TextChanged;

            gameProgressSimpleFontColorBoxButton.Click += FontColorButton_Click;
            gameProgressSimpleFontOutlineColorBoxButton.Click += FontColorButton_Click;
            gameProgressNamesFontColorBoxButton.Click += FontColorButton_Click;
            gameProgressNamesFontOutlineColorBoxButton.Click += FontColorButton_Click;
            gameProgressValuesFontColorBoxButton.Click += FontColorButton_Click;
            gameProgressValuesFontOutlineColorBoxButton.Click += FontColorButton_Click;

            gameProgressSimpleFontOutlineNumericUpDown.Value = GameProgressController.Instance.SimpleFontOutlineSize;
            gameProgressNamesFontOutlineNumericUpDown.Value = GameProgressController.Instance.NameOutlineSize;
            gameProgressValuesFontOutlineNumericUpDown.Value = GameProgressController.Instance.ValueOutlineSize;

            gameProgressSimpleFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            gameProgressNamesFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            gameProgressValuesFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;

            gameProgressRadioButtonBackslash.Click += RadioButton_Clicked;
            gameProgressRadioButtonSemicolon.Click += RadioButton_Clicked;
            gameProgressRadioButtonDot.Click += RadioButton_Clicked;

            switch (GameProgressController.Instance.DividerCharacter)
            {
                case "/":
                    gameProgressRadioButtonBackslash.Checked = true;
                    gameProgressRadioButtonSemicolon.Checked = false;
                    gameProgressRadioButtonDot.Checked = false;
                    break;
                case ":":
                    gameProgressRadioButtonBackslash.Checked = false;
                    gameProgressRadioButtonSemicolon.Checked = true;
                    gameProgressRadioButtonDot.Checked = false;
                    break;
                case ".":
                    gameProgressRadioButtonBackslash.Checked = false;
                    gameProgressRadioButtonSemicolon.Checked = false;
                    gameProgressRadioButtonDot.Checked = true;
                    break;
            }

            /*
             * Focus Achievement Tab
             */
            focusAutoOpenWindowCheckBox.Checked = FocusController.Instance.AutoLaunch;
            focusAutoOpenWindowCheckBox.Click += AutoLaunchCheckBox_CheckedChanged;

            focusBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.WindowBackgroundColor);
            focusSetBackgroundColorButton.Click += BackgroundColorButton_Click;

            focusBorderColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.BorderBackgroundColor);
            focusSetBorderColorButton.Click += BackgroundColorButton_Click;

            focusBorderCheckBox.Checked = FocusController.Instance.BorderEnabled;
            focusBorderCheckBox.Click += BorderCheckBox_Click;

            SetFontFamilyBox(focusSimpleFontComboBox, FocusController.Instance.SimpleFontFamily);
            SetFontFamilyBox(focusTitleFontComboBox, FocusController.Instance.TitleFontFamily);
            SetFontFamilyBox(focusDescriptionFontComboBox, FocusController.Instance.DescriptionFontFamily);
            SetFontFamilyBox(focusPointsFontComboBox, FocusController.Instance.PointsFontFamily);
            focusSimpleOutlineCheckBox.Checked = FocusController.Instance.SimpleFontOutlineEnabled;
            focusTitleOutlineCheckBox.Checked = FocusController.Instance.TitleOutlineEnabled;
            focusDescriptionOutlineCheckBox.Checked = FocusController.Instance.DescriptionOutlineEnabled;
            focusPointsOutlineCheckBox.Checked = FocusController.Instance.PointsOutlineEnabled;
            focusLineOutlineCheckBox.Checked = FocusController.Instance.LineOutlineEnabled;

            focusSimpleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.SimpleFontColor);
            focusSimpleFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.SimpleFontOutlineColor);
            focusTitleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.TitleColor);
            focusTitleFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.TitleOutlineColor);
            focusDescriptionFontColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.DescriptionColor);
            focusDescriptionFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.DescriptionOutlineColor);
            focusPointsFontColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.PointsColor);
            focusPointsFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.PointsOutlineColor);
            focusLineColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.LineColor);
            focusLineOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.LineOutlineColor);

            if (!FocusController.Instance.AdvancedSettingsEnabled)
            {
                focusTitleGroupBox.Hide();
                focusDescriptionGroupBox.Hide();
                focusPointsGroupBox.Hide();
                focusLineGroupBox.Hide();

                focusSimpleCheckBox.Checked = true;
            }

            focusSimpleCheckBox.Click += SimpleCheckBox_Click;

            focusSimpleFontComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;
            focusTitleFontComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;
            focusDescriptionFontComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;
            focusPointsFontComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;

            focusSimpleOutlineCheckBox.Click += FontOutlineCheckBox_Click;
            focusTitleOutlineCheckBox.Click += FontOutlineCheckBox_Click;
            focusDescriptionOutlineCheckBox.Click += FontOutlineCheckBox_Click;
            focusPointsOutlineCheckBox.Click += FontOutlineCheckBox_Click;
            focusLineOutlineCheckBox.Click += FontOutlineCheckBox_Click;

            focusAchievementPictureBox.Click += BrowserSensitiveControl_Click;

            focusSimpleFontSetColorButton.Click += FontColorButton_Click;
            focusSimpleFontOutlineSetColorButton.Click += FontColorButton_Click;
            focusTitleFontSetColorButton.Click += FontColorButton_Click;
            focusTitleFontOutlineSetColorButton.Click += FontColorButton_Click;
            focusDescriptionFontSetColorButton.Click += FontColorButton_Click;
            focusDescriptionFontOutlineSetColorButton.Click += FontColorButton_Click;
            focusPointsFontSetColorButton.Click += FontColorButton_Click;
            focusPointsFontOutlineSetColorButton.Click += FontColorButton_Click;
            focusLineSetColorButton.Click += FontColorButton_Click;
            focusLineOutlineSetColorButton.Click += FontColorButton_Click;

            focusSimpleFontOutlineNumericUpDown.Value = FocusController.Instance.SimpleFontOutlineSize;
            focusTitleFontOutlineNumericUpDown.Value = FocusController.Instance.TitleOutlineSize;
            focusDescriptionFontOutlineNumericUpDown.Value = FocusController.Instance.DescriptionOutlineSize;
            focusPointsFontOutlineNumericUpDown.Value = FocusController.Instance.PointsOutlineSize;
            focusLineOutlineNumericUpDown.Value = FocusController.Instance.LineOutlineSize;

            focusSimpleFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            focusTitleFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            focusDescriptionFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            focusPointsFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            focusLineOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;

            /*
             * Notifications Tab
             */
            notificationsAutoOpenWindowCheckbox.Checked = NotificationsController.Instance.AutoLaunch;
            notificationsAutoOpenWindowCheckbox.Click += AutoLaunchCheckBox_CheckedChanged;

            notificationsBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(NotificationsController.Instance.WindowBackgroundColor);
            notificationsSetBackgroundColorButton.Click += BackgroundColorButton_Click;

            notificationsBorderColorPictureBox.BackColor = ColorTranslator.FromHtml(NotificationsController.Instance.BorderBackgroundColor);
            notificationsSetBorderColorButton.Click += BackgroundColorButton_Click;

            notificationsBorderCheckBox.Checked = NotificationsController.Instance.BorderEnabled;
            notificationsBorderCheckBox.Click += BorderCheckBox_Click;

            SetFontFamilyBox(notificationsSimpleFontComboBox, NotificationsController.Instance.SimpleFontFamily);
            SetFontFamilyBox(notificationsTitleFontComboBox, NotificationsController.Instance.TitleFontFamily);
            SetFontFamilyBox(notificationsDescriptionFontComboBox, NotificationsController.Instance.DescriptionFontFamily);
            SetFontFamilyBox(notificationsPointsFontComboBox, NotificationsController.Instance.PointsFontFamily);
            notificationsSimpleOutlineCheckBox.Checked = NotificationsController.Instance.SimpleFontOutlineEnabled;
            notificationsTitleOutlineCheckBox.Checked = NotificationsController.Instance.TitleOutlineEnabled;
            notificationsDescriptionOutlineCheckBox.Checked = NotificationsController.Instance.DescriptionOutlineEnabled;
            notificationsPointsOutlineCheckBox.Checked = NotificationsController.Instance.PointsOutlineEnabled;
            notificationsLineOutlineCheckBox.Checked = NotificationsController.Instance.LineOutlineEnabled;

            notificationsSimpleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(NotificationsController.Instance.SimpleFontColor);
            notificationsSimpleFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(NotificationsController.Instance.SimpleFontOutlineColor);
            notificationsTitleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(NotificationsController.Instance.TitleColor);
            notificationsTitleFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(NotificationsController.Instance.TitleOutlineColor);
            notificationsDescriptionFontColorPictureBox.BackColor = ColorTranslator.FromHtml(NotificationsController.Instance.DescriptionColor);
            notificationsDescriptionFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(NotificationsController.Instance.DescriptionOutlineColor);
            notificationsPointsFontColorPictureBox.BackColor = ColorTranslator.FromHtml(NotificationsController.Instance.PointsColor);
            notificationsPointsFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(NotificationsController.Instance.PointsOutlineColor);
            notificationsLineColorPictureBox.BackColor = ColorTranslator.FromHtml(NotificationsController.Instance.LineColor);
            notificationsLineOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(NotificationsController.Instance.LineColor);

            if (!NotificationsController.Instance.AdvancedSettingsEnabled)
            {
                notificationsTitleGroupBox.Hide();
                notificationsDescriptionGroupBox.Hide();
                notificationsPointsGroupBox.Hide();
                notificationsLineGroupBox.Hide();

                notificationsSimpleCheckBox.Checked = true;
            }

            notificationsSimpleCheckBox.Click += SimpleCheckBox_Click;

            notificationsSimpleFontComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;
            notificationsTitleFontComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;
            notificationsDescriptionFontComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;
            notificationsPointsFontComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;

            notificationsSimpleOutlineCheckBox.Click += FontOutlineCheckBox_Click;
            notificationsTitleOutlineCheckBox.Click += FontOutlineCheckBox_Click;
            notificationsDescriptionOutlineCheckBox.Click += FontOutlineCheckBox_Click;
            notificationsPointsOutlineCheckBox.Click += FontOutlineCheckBox_Click;
            notificationsLineOutlineCheckBox.Click += FontOutlineCheckBox_Click;

            notificationsSimpleFontSetColorButton.Click += FontColorButton_Click;
            notificationsSimpleFontOutlineSetColorButton.Click += FontColorButton_Click;
            notificationsTitleFontSetColorButton.Click += FontColorButton_Click;
            notificationsTitleFontOutlineSetColorButton.Click += FontColorButton_Click;
            notificationsDescriptionFontSetColorButton.Click += FontColorButton_Click;
            notificationsDescriptionFontOutlineSetColorButton.Click += FontColorButton_Click;
            notificationsPointsFontSetColorButton.Click += FontColorButton_Click;
            notificationsPointsFontOutlineSetColorButton.Click += FontColorButton_Click;
            notificationsLineSetColorButton.Click += FontColorButton_Click;
            notificationsLineOutlineSetColorButton.Click += FontColorButton_Click;

            notificationsSimpleFontOutlineNumericUpDown.Value = NotificationsController.Instance.SimpleFontOutlineSize;
            notificationsTitleFontOutlineNumericUpDown.Value = NotificationsController.Instance.TitleOutlineSize;
            notificationsDescriptionFontOutlineNumericUpDown.Value = NotificationsController.Instance.DescriptionOutlineSize;
            notificationsPointsFontOutlineNumericUpDown.Value = NotificationsController.Instance.PointsOutlineSize;
            notificationsLineOutlineNumericUpDown.Value = NotificationsController.Instance.LineOutlineSize;

            notificationsSimpleFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            notificationsTitleFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            notificationsDescriptionFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            notificationsPointsFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            notificationsLineOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;

            /*
             * Recent Achievements Tab
             */
            recentAchievementsAutoOpenWindowCheckbox.Checked = RecentAchievementsController.Instance.AutoLaunch;
            recentAchievementsAutoOpenWindowCheckbox.Click += AutoLaunchCheckBox_CheckedChanged;

            recentAchievementsBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.WindowBackgroundColor);
            recentAchievementsSetBackgroundColorButton.Click += BackgroundColorButton_Click;

            recentAchievementsBorderColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.BorderBackgroundColor);
            recentAchievementsSetBorderColorButton.Click += BackgroundColorButton_Click;

            recentAchievementsBorderCheckBox.Checked = RecentAchievementsController.Instance.BorderEnabled;
            recentAchievementsBorderCheckBox.Click += BorderCheckBox_Click;

            SetFontFamilyBox(recentAchievementsSimpleFontComboBox, RecentAchievementsController.Instance.SimpleFontFamily);
            SetFontFamilyBox(recentAchievementsTitleFontComboBox, RecentAchievementsController.Instance.TitleFontFamily);
            SetFontFamilyBox(recentAchievementsDescriptionFontComboBox, RecentAchievementsController.Instance.DateFontFamily);
            SetFontFamilyBox(recentAchievementsPointsFontComboBox, RecentAchievementsController.Instance.PointsFontFamily);
            recentAchievementsSimpleFontOutlineCheckBox.Checked = RecentAchievementsController.Instance.SimpleFontOutlineEnabled;
            recentAchievementsTitleFontOutlineCheckBox.Checked = RecentAchievementsController.Instance.TitleOutlineEnabled;
            recentAchievementsDescriptionFontOutlineCheckBox.Checked = RecentAchievementsController.Instance.DescriptionOutlineEnabled;
            recentAchievementsPointsFontOutlineCheckBox.Checked = RecentAchievementsController.Instance.PointsOutlineEnabled;
            recentAchievementsLineOutlineCheckBox.Checked = RecentAchievementsController.Instance.LineOutlineEnabled;

            recentAchievementsSimpleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.SimpleFontColor);
            recentAchievementsSimpleFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.SimpleFontOutlineColor);
            recentAchievementsTitleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.TitleColor);
            recentAchievementsTitleFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.TitleOutlineColor);
            recentAchievementsDescriptionFontColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.DateColor);
            recentAchievementsDescriptionFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.DateOutlineColor);
            recentAchievementsPointsFontColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.PointsColor);
            recentAchievementsPointsFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.PointsOutlineColor);
            recentAchievementsLineColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.LineColor);
            recentAchievementsLineOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.LineColor);

            if (!RecentAchievementsController.Instance.AdvancedSettingsEnabled)
            {
                recentAchievementsTitleGroupBox.Hide();
                recentAchievementsDescriptionGroupBox.Hide();
                recentAchievementsPointsGroupBox.Hide();
                recentAchievementsLineGroupBox.Hide();

                recentAchievementsSimpleCheckBox.Checked = true;
            }

            recentAchievementsSimpleCheckBox.Click += SimpleCheckBox_Click;

            recentAchievementsSimpleFontComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;
            recentAchievementsTitleFontComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;
            recentAchievementsDescriptionFontComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;
            recentAchievementsPointsFontComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;

            recentAchievementsSimpleFontOutlineCheckBox.Click += FontOutlineCheckBox_Click;
            recentAchievementsTitleFontOutlineCheckBox.Click += FontOutlineCheckBox_Click;
            recentAchievementsDescriptionFontOutlineCheckBox.Click += FontOutlineCheckBox_Click;
            recentAchievementsPointsFontOutlineCheckBox.Click += FontOutlineCheckBox_Click;
            recentAchievementsLineOutlineCheckBox.Click += FontOutlineCheckBox_Click;

            recentAchievementsMaxListNumericUpDown.Value = RecentAchievementsController.Instance.MaxListSize;
            recentAchievementsMaxListNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;

            recentAchievementsSimpleFontSetColorButton.Click += FontColorButton_Click;
            recentAchievementsSimpleFontOutlineSetColorButton.Click += FontColorButton_Click;
            recentAchievementsTitleFontSetColorButton.Click += FontColorButton_Click;
            recentAchievementsTitleFontOutlineSetColorButton.Click += FontColorButton_Click;
            recentAchievementsDescriptionFontSetColorButton.Click += FontColorButton_Click;
            recentAchievementsDescriptionFontOutlineSetColorButton.Click += FontColorButton_Click;
            recentAchievementsPointsFontSetColorButton.Click += FontColorButton_Click;
            recentAchievementsPointsFontOutlineSetColorButton.Click += FontColorButton_Click;
            recentAchievementsLineSetColorButton.Click += FontColorButton_Click;
            recentAchievementsLineOutlineSetColorButton.Click += FontColorButton_Click;

            recentAchievementsSimpleFontOutlineNumericUpDown.Value = RecentAchievementsController.Instance.SimpleFontOutlineSize;
            recentAchievementsTitleFontOutlineNumericUpDown.Value = RecentAchievementsController.Instance.TitleOutlineSize;
            recentAchievementsDescriptionFontOutlineNumericUpDown.Value = RecentAchievementsController.Instance.DescriptionOutlineSize;
            recentAchievementsPointsFontOutlineNumericUpDown.Value = RecentAchievementsController.Instance.PointsOutlineSize;
            recentAchievementsLineOutlineNumericUpDown.Value = RecentAchievementsController.Instance.LineOutlineSize;

            recentAchievementsSimpleFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            recentAchievementsTitleFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            recentAchievementsDescriptionFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            recentAchievementsPointsFontOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            recentAchievementsLineOutlineNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;

            /*
             * Achievement List Tab
             */
            achievementListAutoOpenWindowCheckbox.Checked = AchievementListController.Instance.AutoLaunch;
            achievementListAutoOpenWindowCheckbox.Click += AutoLaunchCheckBox_CheckedChanged;

            achievementListBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(AchievementListController.Instance.WindowBackgroundColor);
            achievementListSetBackgroundColorButton.Click += BackgroundColorButton_Click;

            /*
             * RSS Feed CheckBoxes
             */
            rssFeedCheevoCheckBox.Checked = Settings.Default.rss_new_achievements_feed;
            rssFeedForumCheckBox.Checked = Settings.Default.rss_forum_feed;
            rssFeedFriendCheckBox.Checked = Settings.Default.rss_friend_feed;
            rssFeedNewsCheckBox.Checked = Settings.Default.rss_news_feed;

            rssFeedCheevoCheckBox.CheckedChanged += RSSFeedCheckbox_CheckedChanged;
            rssFeedForumCheckBox.CheckedChanged += RSSFeedCheckbox_CheckedChanged;
            rssFeedFriendCheckBox.CheckedChanged += RSSFeedCheckbox_CheckedChanged;
            rssFeedNewsCheckBox.CheckedChanged += RSSFeedCheckbox_CheckedChanged;

            rssFeedListView.SelectedIndexChanged += BrowserSensitiveControl_Click;

            selectCustomAchievementFileButton.Enabled = NotificationsController.Instance.CustomAchievementEnabled;
            customAchievementEnableCheckbox.Checked = NotificationsController.Instance.CustomAchievementEnabled;
            acheivementEditOutlineCheckbox.Enabled = NotificationsController.Instance.CustomAchievementEnabled;
            customAchievementEnableCheckbox.Click += CustomAchievementEnableCheckBox_CheckedChanged;
            acheivementEditOutlineCheckbox.Click += AcheivementEditOutlineCheckBox_CheckedChanged;

            selectCustomMasteryFileButton.Enabled = NotificationsController.Instance.CustomMasteryEnabled;
            customMasteryEnableCheckbox.Checked = NotificationsController.Instance.CustomMasteryEnabled;
            masteryEditOultineCheckbox.Enabled = NotificationsController.Instance.CustomMasteryEnabled;
            customMasteryEnableCheckbox.Click += CustomMasteryEnableCheckBox_CheckedChanged;
            masteryEditOultineCheckbox.Click += MasteryEditOultineCheckBox_CheckedChanged;

            if (NotificationsController.Instance.CustomAchievementScale > notificationsCustomAchievementScaleNumericUpDown.Maximum)
            {
                NotificationsController.Instance.CustomAchievementScale = notificationsCustomAchievementScaleNumericUpDown.Maximum;
            }

            if (NotificationsController.Instance.CustomMasteryScale > notificationsCustomMasteryScaleNumericUpDown.Maximum)
            {
                NotificationsController.Instance.CustomMasteryScale = notificationsCustomMasteryScaleNumericUpDown.Maximum;
            }

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
                notificationsCustomAchievementAnimationInComboBox.Items.Add(animationDirection.ToString());
                notificationsCustomAchievementAnimationOutComboBox.Items.Add(animationDirection.ToString());
                notificationsCustomMasteryAnimationInComboBox.Items.Add(animationDirection.ToString());
                notificationsCustomMasteryAnimationOutComboBox.Items.Add(animationDirection.ToString());
            });

            notificationsCustomAchievementAnimationInComboBox.SelectedIndex = notificationsCustomAchievementAnimationInComboBox.Items.IndexOf(Settings.Default.notifications_achievement_in_animation);
            notificationsCustomAchievementAnimationOutComboBox.SelectedIndex = notificationsCustomAchievementAnimationOutComboBox.Items.IndexOf(Settings.Default.notifications_achievement_out_animation);
            notificationsCustomMasteryAnimationInComboBox.SelectedIndex = notificationsCustomMasteryAnimationInComboBox.Items.IndexOf(Settings.Default.notifications_mastery_in_animation);
            notificationsCustomMasteryAnimationOutComboBox.SelectedIndex = notificationsCustomMasteryAnimationOutComboBox.Items.IndexOf(Settings.Default.notifications_mastery_out_animation);
            notificationsCustomAchievementAnimationInComboBox.SelectedIndexChanged += NotificationAnimationComboBox_SelectedIndexChanged;
            notificationsCustomAchievementAnimationOutComboBox.SelectedIndexChanged += NotificationAnimationComboBox_SelectedIndexChanged;
            notificationsCustomMasteryAnimationInComboBox.SelectedIndexChanged += NotificationAnimationComboBox_SelectedIndexChanged;
            notificationsCustomMasteryAnimationOutComboBox.SelectedIndexChanged += NotificationAnimationComboBox_SelectedIndexChanged;

            notificationsCustomAchievementScaleNumericUpDown.Value = NotificationsController.Instance.CustomAchievementScale;
            notificationsCustomMasteryScaleNumericUpDown.Value = NotificationsController.Instance.CustomMasteryScale;
            notificationsCustomAchievementScaleNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            notificationsCustomMasteryScaleNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;

            notificationsCustomAchievementInNumericUpDown.Value = NotificationsController.Instance.CustomAchievementIn;
            notificationsCustomAchievementOutNumericUpDown.Value = NotificationsController.Instance.CustomAchievementOut;
            notificationsCustomAchievementInNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            notificationsCustomAchievementOutNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;

            notificationsCustomMasteryInNumericUpDown.Value = NotificationsController.Instance.CustomMasteryIn;
            notificationsCustomMasteryOutNumericUpDown.Value = NotificationsController.Instance.CustomMasteryOut;
            notificationsCustomMasteryOutNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            notificationsCustomMasteryInNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;

            notificationsCustomAchievementInSpeedUpDown.Value = NotificationsController.Instance.CustomAchievementInSpeed;
            notificationsCustomAchievementOutSpeedUpDown.Value = NotificationsController.Instance.CustomAchievementOutSpeed;
            notificationsCustomAchievementInSpeedUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            notificationsCustomAchievementOutSpeedUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;

            notificationsCustomMasteryInSpeedUpDown.Value = NotificationsController.Instance.CustomMasteryInSpeed;
            notificationsCustomMasteryOutSpeedUpDown.Value = NotificationsController.Instance.CustomMasteryOutSpeed;
            notificationsCustomMasteryInSpeedUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            notificationsCustomMasteryOutSpeedUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;

            notificationsCustomAchievementXNumericUpDown.Value = NotificationsController.Instance.CustomAchievementX;
            notificationsCustomAchievementYNumericUpDown.Value = NotificationsController.Instance.CustomAchievementY;
            notificationsCustomAchievementXNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            notificationsCustomAchievementYNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;

            notificationsCustomMasteryXNumericUpDown.Value = NotificationsController.Instance.CustomMasteryX;
            notificationsCustomMasteryYNumericUpDown.Value = NotificationsController.Instance.CustomMasteryY;
            notificationsCustomMasteryXNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;
            notificationsCustomMasteryYNumericUpDown.ValueChanged += CustomNumericUpDown_ValueChanged;

            playAchievementButton.Click += ShowAchievementButton_Click;
            playMasteryButton.Click += ShowGameMasteryButton_Click;
            selectCustomAchievementFileButton.Click += SelectCustomAchievementButton_Click;
            selectCustomMasteryFileButton.Click += SelectCustomMasteryNotificationButton_Click;

            recentAchievementsScrollCheckBox.Checked = RecentAchievementsController.Instance.AutoScroll;
            achievementListScrollCheckBox.Checked = AchievementListController.Instance.AutoScroll;
            recentAchievementsScrollCheckBox.Click += AutoScroll_Click;
            achievementListScrollCheckBox.Click += AutoScroll_Click;

            /*
             * Stream Label Enablement CheckBox
             */
            gameInfoTitleCheckBox.Click += StreamLabelEnableCheckBox_Clicked;
            gameInfoDeveloperCheckBox.Click += StreamLabelEnableCheckBox_Clicked;
            gameInfoGenreCheckBox.Click += StreamLabelEnableCheckBox_Clicked;
            gameInfoPublisherCheckBox.Click += StreamLabelEnableCheckBox_Clicked;
            gameInfoConsoleCheckBox.Click += StreamLabelEnableCheckBox_Clicked;
            gameInfoReleasedCheckBox.Click += StreamLabelEnableCheckBox_Clicked;

            gameProgressAchievementsCheckBox.Click += StreamLabelEnableCheckBox_Clicked;
            gameProgressPointsCheckBox.Click += StreamLabelEnableCheckBox_Clicked;
            gameProgressTruePointsCheckBox.Click += StreamLabelEnableCheckBox_Clicked;
            gameProgressCompletedCheckBox.Click += StreamLabelEnableCheckBox_Clicked;
            gameProgressRatioCheckBox.Click += StreamLabelEnableCheckBox_Clicked;

            userInfoRankCheckBox.Click += StreamLabelEnableCheckBox_Clicked;
            userInfoPointsCheckBox.Click += StreamLabelEnableCheckBox_Clicked;
            userInfoRatioCheckBox.Click += StreamLabelEnableCheckBox_Clicked;
            userInfoTruePointsCheckBox.Click += StreamLabelEnableCheckBox_Clicked;

            /*
             * Radio Button Clicked
             */
            focusBehaviorGoToFirstRadioButton.Click += RadioButton_Clicked;
            focusBehaviorGoToPreviousRadioButton.Click += RadioButton_Clicked;
            focusBehaviorGoToNextRadioButton.Click += RadioButton_Clicked;
            focusBehaviorGoToLastRadioButton.Click += RadioButton_Clicked;

            focusSetButton.Click += SetFocusButton_Click;
            focusAchievementButtonPrevious.Click += MoveFocusIndexPrev_Click;
            focusAchievementButtonNext.Click += MoveFocusIndexNext_Click;

            /*
             * Render Window Show Button Click
             */
            recentAchievementsOpenWindowButton.Click += ShowWindowButton_Click;
            gameInfoOpenWindowButton.Click += ShowWindowButton_Click;
            notificationsOpenWindowButton.Click += ShowWindowButton_Click;
            focusOpenWindowButton.Click += ShowWindowButton_Click;
            userInfoOpenWindowButton.Click += ShowWindowButton_Click;
            gameProgressOpenWindowButton.Click += ShowWindowButton_Click;
            achievementListOpenWindowButton.Click += ShowWindowButton_Click;
        }
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