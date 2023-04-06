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
using System.Threading.Tasks;
using FontFamily = System.Drawing.FontFamily;
using File = System.IO.File;

namespace Retro_Achievement_Tracker
{
    public partial class MainWindow : Form
    {
        private bool ShouldRun;
        private bool IsLoading;
        private bool IsLaunching;

        private int CurrentlyViewingIndex;
        private int UserAndGameTimerCounter;
        private int CurrentErrorCount = 0;
        private int MaxCheevoCount = 0;

        private UserSummary UserSummary;
        private GameInfo GameInfo;
        private Achievement CurrentlyViewingAchievement;

        private List<Achievement> OldUnlockedAchievements;
        private readonly List<ListViewItem> RSSFeedListViewItems = new List<ListViewItem>();

        private Timer UserAndGameUpdateTimer;

        private RetroAchievementAPIClient RetroAchievementsAPIClient;

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

        public MainWindow()
        {
            MaximizeBox = false;

            IsLaunching = true;
            IsLoading = true;
            CurrentlyViewingIndex = -1;

            AutoUpdate();
            InitializeComponent();
        }

        private void CheckForUpdatesButton_Click(object sender, EventArgs e)
        {
            Settings.Default.check_for_update_on_version = true;

            AutoUpdate();
        }

        private void TabControlExtra1_TabIndexChanged(object sender, EventArgs e)
        {
            foreach (TabPage tab in mainTabControl.TabPages)
            {
                if (mainTabControl.SelectedTab.Equals(tab))
                {
                    tab.Show();
                }
                else
                {
                    tab.Hide();
                }
            }
        }

        private void AutoUpdate()
        {
            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;

            AutoUpdater.ReportErrors = false;
            AutoUpdater.Synchronous = true;

            AutoUpdater.Start(Constants.GITHUB_AUTO_UPDATE_URL);
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            rssFeedListView.ListViewItemSorter = Comparer<ListViewItem>.Create((item1, item2) => DateTime.Parse(item2.SubItems[1].Text).CompareTo(DateTime.Parse(item1.SubItems[1].Text)));

            UserAndGameUpdateTimer = new Timer
            {
                Enabled = false
            };

            UserAndGameUpdateTimer.Tick += new EventHandler(UpdateFromSite);
            UserAndGameUpdateTimer.Interval = 500;

            mainTabControl.TabIndexChanged += TabControlExtra1_TabIndexChanged;

            checkForUpdatesButton.Click += CheckForUpdatesButton_Click;

            LoadProperties();

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

            IsLoading = false;
        }
        protected override void OnClosed(EventArgs e)
        {
            Settings.Default.ra_username = usernameTextBox.Text;
            Settings.Default.ra_key = apiKeyTextBox.Text;

            Settings.Default.Save();

            StreamLabelManager.Instance.ClearAllStreamLabels();

            FocusController.Instance.Close();
            UserInfoController.Instance.Close();
            AlertsController.Instance.Close();
            GameInfoController.Instance.Close();
            RecentAchievementsController.Instance.Close();
            AchievementListController.Instance.Close();
            RelatedMediaController.Instance.Close();
        }

        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args != null)
            {
                if (args.IsUpdateAvailable && (Settings.Default.check_for_update_on_version || (!Settings.Default.check_for_update_version.Equals(args.CurrentVersion) && Settings.Default.check_for_update_on_version)))
                {
                    Settings.Default.check_for_update_version = args.CurrentVersion;

                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("Old version: " + args.InstalledVersion + "\nNew version: " + args.CurrentVersion, "New Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (dialogResult.Equals(DialogResult.Yes))
                        {
                            if (AutoUpdater.DownloadUpdate(args))
                            {
                                Close();
                            }
                        }
                        else
                        {
                            Settings.Default.check_for_update_on_version = false;
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    Settings.Default.Save();
                }
            }
            else
            {
                MessageBox.Show(@"There is a problem reaching update server please check your internet connection and try again later.", @"Update check failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateGameProgress(bool sameGame)
        {
            try
            {
                bool needsUpdate = !sameGame;

                if (GameInfo.Achievements != null)
                {
                    GameInfo.Achievements.ForEach(achievement =>
                    {
                        achievement.GameId = (int)GameInfo.Id;
                        achievement.GameTitle = GameInfo.Title;
                    });
                }

                if (sameGame)
                {
                    List<Achievement> achievementNotificationList = UnlockedAchievements
                    .FindAll(unlockedAchievement => !OldUnlockedAchievements.Contains(unlockedAchievement))
                    .ToList();

                    achievementNotificationList.ForEach((achievement) => StreamLabelManager.Instance.EnqueueAlert(achievement));

                    if (achievementNotificationList.Count > 0 && UnlockedAchievements.Count > MaxCheevoCount)
                    {
                        MaxCheevoCount = UnlockedAchievements.Count;

                        UpdateLogLabel(Constants.RETRO_ACHIEVEMENTS_LABEL_MSG_CHEEVO_POP);

                        achievementNotificationList.Sort();

                        if (AlertsController.Instance.AchievementAlertEnable)
                        {
                            AlertsController.Instance.EnqueueAchievementNotifications(achievementNotificationList);
                        }

                        if (achievementNotificationList.Contains(FocusController.Instance.CurrentlyFocusedAchievement))
                        {
                            if (LockedAchievements.Count > 0)
                            {
                                int currentIndex = GameInfo.Achievements.IndexOf(FocusController.Instance.CurrentlyFocusedAchievement);

                                switch (FocusController.Instance.RefocusBehavior)
                                {
                                    case RefocusBehaviorEnum.GO_TO_FIRST:
                                        currentIndex = -1;
                                        break;
                                    case RefocusBehaviorEnum.GO_TO_PREVIOUS:
                                        while (currentIndex > 0 && !LockedAchievements.Contains(GameInfo.Achievements[currentIndex]))
                                        {
                                            currentIndex--;
                                        }
                                        if (currentIndex == 0)
                                        {
                                            while (currentIndex < GameInfo.Achievements.Count - 1 && !LockedAchievements.Contains(GameInfo.Achievements[currentIndex]))
                                            {
                                                currentIndex++;
                                            }
                                        }
                                        break;
                                    case RefocusBehaviorEnum.GO_TO_NEXT:
                                        while (currentIndex < GameInfo.Achievements.Count - 1 && !LockedAchievements.Contains(GameInfo.Achievements[currentIndex]))
                                        {
                                            currentIndex++;
                                        }
                                        if (currentIndex == GameInfo.Achievements.Count - 1)
                                        {
                                            while (currentIndex > 0 && !LockedAchievements.Contains(GameInfo.Achievements[currentIndex]))
                                            {
                                                currentIndex--;
                                            }
                                        }
                                        break;
                                    case RefocusBehaviorEnum.GO_TO_LAST:
                                        currentIndex = GameInfo.Achievements.Count;
                                        break;
                                }

                                CurrentlyViewingIndex = currentIndex;
                            }
                        }

                        if (AlertsController.Instance.MasteryAlertEnable && UnlockedAchievements.Count == GameInfo.Achievements.Count && OldUnlockedAchievements.Count < GameInfo.Achievements.Count)
                        {
                            AlertsController.Instance.EnqueueMasteryNotification(GameInfo);
                            StreamLabelManager.Instance.EnqueueAlert(GameInfo);
                        }

                        AlertsController.Instance.RunNotifications();

                        needsUpdate = true;
                    }
                }
                else
                {
                    UpdateLogLabel(string.Format(Constants.RETRO_ACHIEVEMENTS_LABEL_MSG_CHANGING_TITLE, GameInfo.Title));

                    MaxCheevoCount = UnlockedAchievements.Count;

                    CurrentlyViewingAchievement = null;
                    CurrentlyViewingIndex = -1;

                    UpdateMediaReferences();
                }

                if (GameInfo.Achievements != null && GameInfo.Achievements.Count > 0 && needsUpdate)
                {
                    AchievementListController.Instance.UpdateAchievementList(UnlockedAchievements.ToList(), LockedAchievements.ToList(), !sameGame);

                    RecentAchievementsController.Instance.SetAchievements(UnlockedAchievements.ToList());

                    StreamLabelManager.Instance.EnqueueRecentUnlocks(GameInfo);

                    UpdateGameInfo();
                    UpdateCurrentlyViewingAchievement();

                    SetFocus();

                    StreamLabelManager.Instance.RunNotifications();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private async void UpdateFromSite(object sender, EventArgs e)
        {
            if (!ShouldRun)
            {
                UserAndGameUpdateTimer.Stop();

                return;
            }

            if (UserSummary != null)
            {
                if (IsLaunching)
                {
                    if (FocusController.Instance.AutoLaunch && !FocusController.Instance.IsOpen)
                    {
                        FocusController.Instance.Show();
                    }
                    else if (AlertsController.Instance.AutoLaunch && !AlertsController.Instance.IsOpen)
                    {
                        AlertsController.Instance.Show();
                    }
                    else if (UserInfoController.Instance.AutoLaunch && !UserInfoController.Instance.IsOpen)
                    {
                        UserInfoController.Instance.Show();
                    }
                    else if (GameInfoController.Instance.AutoLaunch && !GameInfoController.Instance.IsOpen)
                    {
                        GameInfoController.Instance.Show();
                    }
                    else if (GameProgressController.Instance.AutoLaunch && !GameProgressController.Instance.IsOpen)
                    {
                        GameProgressController.Instance.Show();
                    }
                    else if (RecentAchievementsController.Instance.AutoLaunch && !RecentAchievementsController.Instance.IsOpen)
                    {
                        RecentAchievementsController.Instance.Show();
                    }
                    else if (AchievementListController.Instance.AutoLaunch && !AchievementListController.Instance.IsOpen)
                    {
                        AchievementListController.Instance.Show();
                    }
                    else if (RelatedMediaController.Instance.AutoLaunch && !RelatedMediaController.Instance.IsOpen)
                    {
                        RelatedMediaController.Instance.Show();
                    }
                    else if (AlertsController.Instance.AutoLaunch && !AlertsController.Instance.IsOpen)
                    {
                        AlertsController.Instance.Show();
                    }
                    else
                    {
                        IsLaunching = false;
                    }
                }
            }

            UserAndGameTimerCounter--;

            UpdateLogLabel(string.Format(Constants.RETRO_ACHIEVEMENTS_LABEL_MSG_COUNTDOWN, UserAndGameTimerCounter / 2));

            try
            {
                if (UserAndGameTimerCounter <= 0)
                {
                    UserAndGameUpdateTimer.Stop();

                    int previousId = -1;

                    if (UserSummary != null && UserSummary.LastGameID > 0)
                    {
                        previousId = UserSummary.LastGameID;
                    }

                    OldUnlockedAchievements = UnlockedAchievements.ToList();

                    UpdateLogLabel(Constants.RETRO_ACHIEVEMENTS_LABEL_MSG_UPDATING_USER_INFO);
                    UserSummary userSummary = null;

                    if (UserSummary != null)
                    {
                        userSummary = (UserSummary)UserSummary.Clone();
                    }

                    UserSummary = await RetroAchievementsAPIClient.GetUserSummary();

                    if (UserSummary != null)
                    {
                        if (UserSummary.LastGameID > 0)
                        {
                            if (!UserSummary.Equals(userSummary))
                            {
                                UpdateUserInfo();

                                raConnectionStatusPictureBox.Image = Resources.green_button;
                                userProfilePictureBox.ImageLocation = string.Format(Constants.RETRO_ACHIEVEMENTS_PROFILE_PIC_URL, UserSummary.UserName);
                            }

                            UpdateLogLabel(Constants.RETRO_ACHIEVEMENTS_LABEL_MSG_UPDATING_GAME_INFO);

                            GameInfo = await RetroAchievementsAPIClient.GetGameInfo(UserSummary.LastGameID);

                            UpdateGameProgress(previousId == UserSummary.LastGameID);

                            if (Settings.Default.rss_forum_feed || Settings.Default.rss_friend_feed || Settings.Default.rss_news_feed || Settings.Default.rss_new_achievements_feed)
                            {
                                await CheckRSSFeeds();

                                UpdateLogLabel(Constants.RETRO_ACHIEVEMENTS_LABEL_MSG_UPDATING_RSS_FEED);
                            }

                            if (ShouldRun)
                            {
                                StartTimer();
                            }
                            else
                            {
                                StopButton_Click(null, null);
                            }
                        }
                        else
                        {
                            HandleNetworkError();
                        }
                    }
                    else
                    {
                        HandleNetworkError();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);

                if (ShouldRun)
                {
                    StartTimer();
                }
                else
                {
                    StopButton_Click(null, null);
                }
            }
        }
        private async void HandleNetworkError()
        {
            CurrentErrorCount++;

            if (CurrentErrorCount > 2)
            {
                UpdateLogLabel("Too many failures trying to connect. Stopping for now.");

                ShouldRun = false;

                StopButton_Click(null, null);
            }
            else
            {
                UpdateLogLabel("Not able to communicate with RetroAchievements API. Trying to restart gracefully...");

                await Task.Delay(5000);

                StartTimer();
            }
        }
        public void UpdateCurrentlyViewingAchievement()
        {
            if (Visible)
            {
                if (LockedAchievements.Count > 0)
                {
                    if (CurrentlyViewingIndex >= GameInfo.Achievements.Count)
                    {
                        CurrentlyViewingIndex = GameInfo.Achievements.Count - 1;

                        while (CurrentlyViewingIndex > 0 && !LockedAchievements.Contains(GameInfo.Achievements[CurrentlyViewingIndex]))
                        {
                            CurrentlyViewingIndex--;
                        }

                    }
                    else if (CurrentlyViewingIndex < 0)
                    {
                        CurrentlyViewingIndex = 0;

                        while (CurrentlyViewingIndex < GameInfo.Achievements.Count - 1 && !LockedAchievements.Contains(GameInfo.Achievements[CurrentlyViewingIndex]))
                        {
                            CurrentlyViewingIndex++;
                        }
                    }

                    CurrentlyViewingAchievement = GameInfo.Achievements[CurrentlyViewingIndex];

                    focusAchievementPictureBox.ImageLocation = CurrentlyViewingAchievement.BadgeUri;
                    focusAchievementTitleLabel.Text = "[" + CurrentlyViewingAchievement.Points + "] - " + CurrentlyViewingAchievement.Title;
                    focusAchievementDescriptionLabel.Text = CurrentlyViewingAchievement.Description;
                }
                else
                {
                    CurrentlyViewingIndex = -1;
                    CurrentlyViewingAchievement = null;

                    focusAchievementPictureBox.ImageLocation = string.Empty;
                    focusAchievementTitleLabel.Text = string.Empty;
                    focusAchievementDescriptionLabel.Text = string.Empty;
                }

                UpdateFocusButtons();
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
        private void RefreshRSSFeed()
        {
            foreach (ListViewItem item in RSSFeedListViewItems)
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
                try
                {
                    await RetroAchievementsAPIClient.GetNewsFeed().ContinueWith(result =>
                    {
                        newsReader = XmlReader.Create(new StringReader(result.Result));
                        feed = SyndicationFeed.Load(newsReader);

                        newsReader.Close();

                        foreach (SyndicationItem item in feed.Items)
                        {
                            if (RSSFeedListViewItems.Find(potentialItem => potentialItem.Text.Contains("[NEWS] " + item.Title.Text)) == null)
                            {
                                syndicationItems.Add("[NEWS] " + item.Title.Text, item);
                            }
                        }
                    });
                }
                catch { }
            }

            if (Settings.Default.rss_new_achievements_feed)
            {
                try
                {
                    await RetroAchievementsAPIClient.GetNewAchievementsFeed().ContinueWith(result =>
                    {
                        newsReader = XmlReader.Create(new StringReader(result.Result));
                        feed = SyndicationFeed.Load(newsReader);

                        newsReader.Close();

                        foreach (SyndicationItem item in feed.Items)
                        {
                            if (RSSFeedListViewItems.Find(potentialItem => potentialItem.Text.Equals("[CHEEVO] " + item.Title.Text + " " + item.PublishDate.ToString())) == null
                            && !syndicationItems.ContainsKey("[CHEEVO] " + item.Title.Text + " " + item.PublishDate.ToString()))
                            {
                                syndicationItems.Add("[CHEEVO] " + item.Title.Text + " " + item.PublishDate.ToString(), item);
                            }
                        }
                    });
                }
                catch
                {
                }
            }

            if (Settings.Default.rss_forum_feed)
            {
                try
                {
                    await RetroAchievementsAPIClient.GetForumActivityFeed().ContinueWith(result =>
                    {
                        newsReader = XmlReader.Create(new StringReader(result.Result));
                        feed = SyndicationFeed.Load(newsReader);

                        newsReader.Close();

                        foreach (SyndicationItem item in feed.Items)
                        {
                            if (RSSFeedListViewItems.Find(potentialItem => potentialItem.Text.Equals("[FORUM] " + item.Title.Text + " " + item.PublishDate.ToString())) == null
                                && !syndicationItems.ContainsKey("[FORUM] " + item.Title.Text + " " + item.PublishDate.ToString()))
                            {
                                syndicationItems.Add("[FORUM] " + item.Title.Text + " " + item.PublishDate.ToString(), item);
                            }
                        }
                    });
                }
                catch
                {
                }
            }

            if (Settings.Default.rss_friend_feed)
            {
                try
                {
                    await RetroAchievementsAPIClient.GetFriendActivityFeed().ContinueWith(result =>
                    {
                        newsReader = XmlReader.Create(new StringReader(result.Result));
                        feed = SyndicationFeed.Load(newsReader);

                        newsReader.Close();

                        foreach (SyndicationItem item in feed.Items)
                        {
                            if (RSSFeedListViewItems.Find(potentialItem => potentialItem.Text.Equals("[FRIEND] " + item.Title.Text + " " + item.PublishDate.ToString())) == null
                            && !syndicationItems.ContainsKey("[FRIEND] " + item.Title.Text + " " + item.PublishDate.ToString()))
                            {
                                syndicationItems.Add("[FRIEND] " + item.Title.Text + " " + item.PublishDate.ToString(), item);
                            }
                        }
                    });
                }
                catch { }
            }

            foreach (KeyValuePair<string, SyndicationItem> pair in syndicationItems)
            {
                ListViewItem listViewItem = new ListViewItem(pair.Key);
                listViewItem.SubItems.Add(pair.Value.PublishDate.ToString());
                listViewItem.SubItems.Add(pair.Value.Summary.Text);
                listViewItem.SubItems.Add(pair.Value.Links[0].Uri.AbsoluteUri);

                newListViewItems.Add(listViewItem);
            }

            RSSFeedListViewItems.AddRange(newListViewItems);

            RefreshRSSFeed();
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
        private bool CanStart()
        {
            return !(string.IsNullOrEmpty(usernameTextBox.Text)
                || string.IsNullOrEmpty(apiKeyTextBox.Text));
        }
        private void UpdateLogLabel(string s)
        {
            timerStatusLabel.Text = IsLaunching ? "Booting. Please stand by..." : s;
        }
        private void StartTimer()
        {
            UserAndGameTimerCounter = (IsLaunching || UserSummary == null) ? 0 : 12;

            UserAndGameUpdateTimer = new Timer
            {
                Enabled = false
            };

            UserAndGameUpdateTimer.Tick += new EventHandler(UpdateFromSite);
            UserAndGameUpdateTimer.Interval = 500;

            if (ShouldRun)
            {
                UserAndGameUpdateTimer.Start();
            }
        }
        private void UpdateUserInfo()
        {
            userInfoUsernameLabel.Text = UserSummary.UserName;
            userInfoMottoLabel.Text = UserSummary.Motto;
            userInfoRankLabel.Text = "Site Rank: " + (UserSummary.Rank == 0 ? "No Rank" : UserSummary.Rank.ToString());
            userInfoPointsLabel.Text = "Hardcore Points: " + UserSummary.TotalPoints.ToString() + " points";
            userInfoTruePointsLabel.Text = "(" + UserSummary.TotalTruePoints.ToString() + ")";
            userInfoRatioLabel.Text = UserSummary.RetroRatio;

            UserInfoController.Instance.SetRank(UserSummary.Rank == 0 ? "No Rank" : UserSummary.Rank.ToString());
            UserInfoController.Instance.SetPoints(UserSummary.TotalPoints.ToString());
            UserInfoController.Instance.SetTruePoints(UserSummary.TotalTruePoints.ToString());
            UserInfoController.Instance.SetRatio(UserSummary.RetroRatio);

            StreamLabelManager.Instance.EnqueueUserInfo(UserSummary);
        }
        private void UpdateGameInfo()
        {
            gameInfoPictureBox.ImageLocation = GameInfo.BadgeUri;
            gameInfoTitleLabel.Text = GameInfo.Title + " (" + GameInfo.ConsoleName + ")";
            gameInfoDeveloperLabel.Text = GameInfo.Developer;
            gameInfoPublisherLabel.Text = GameInfo.Publisher;
            gameInfoGenreLabel.Text = GameInfo.Genre;
            gameInfoReleasedLabel.Text = GameInfo.Released;

            int percentageCompleted = (int)float.Parse(GameInfo.PercentComplete);

            gameProgressAchievements1Label.Text = GameInfo.AchievementsPossible.ToString();
            gameProgressPoints1Label.Text = GameInfo.GamePointsPossible.ToString();
            gameProgressTruePoints1Label.Text = "(" + GameInfo.GameTruePointsPossible.ToString() + ")";

            gameProgressPercentCompletePictureBox.Size = new Size((int)(1.82 * percentageCompleted), 2);

            gameProgressCompletedLabel.Text = percentageCompleted + "% complete";

            if (0 == percentageCompleted)
            {
                gameProgressMasteryPictureBox.Hide();

                gameProgressHaveEarnedLabel.Text = "You have not earned any achievements for this game.";

                gameProgressAchievements2Label.Hide();
                gameProgressHardcoreWorthLabel.Hide();
                gameProgressPoints2Label.Hide();
                gameProgressTruePoints2Label.Hide();
                gameProgressPointsTextLabel.Hide();
            }
            else
            {
                if (percentageCompleted == 100)
                {
                    gameProgressMasteryPictureBox.Show();
                    gameProgressCompletedLabel.Text = "Mastered";
                }

                gameProgressHaveEarnedLabel.Text = "You have earned";

                gameProgressAchievements2Label.Show();
                gameProgressHardcoreWorthLabel.Show();
                gameProgressPoints2Label.Show();
                gameProgressTruePoints2Label.Show();
                gameProgressPointsTextLabel.Show();

                gameProgressAchievements2Label.Text = GameInfo.AchievementsEarned.ToString();
                gameProgressPoints2Label.Text = GameInfo.GamePointsEarned.ToString();
                gameProgressTruePoints2Label.Text = "(" + GameInfo.GameTruePointsEarned.ToString() + ")";
            }

            GameInfoController.Instance.SetTitleValue(GameInfo.Title);
            GameInfoController.Instance.SetDeveloperValue(GameInfo.Developer);
            GameInfoController.Instance.SetPublisherValue(GameInfo.Publisher);
            GameInfoController.Instance.SetGenreValue(GameInfo.Genre);
            GameInfoController.Instance.SetConsoleValue(GameInfo.ConsoleName);
            GameInfoController.Instance.SetReleaseDateValue(GameInfo.Released);

            GameProgressController.Instance.SetGameAchievements(GameInfo.AchievementsEarned.ToString(), GameInfo.Achievements == null ? "0" : GameInfo.Achievements.Count.ToString());
            GameProgressController.Instance.SetGamePoints(GameInfo.GamePointsEarned.ToString(), GameInfo.GamePointsPossible.ToString());
            GameProgressController.Instance.SetGameTruePoints(GameInfo.GameTruePointsEarned.ToString(), GameInfo.GameTruePointsPossible.ToString());
            GameProgressController.Instance.SetCompleted(GameInfo.Achievements == null ? 0.00f : GameInfo.AchievementsEarned / (float)GameInfo.Achievements.Count * 100f);
            GameProgressController.Instance.SetGameRatio();

            StreamLabelManager.Instance.EnqueueGameInfo(GameInfo);

            RelatedMediaController.Instance.RABadgeIconURI = GameInfo.BadgeUri;
            RelatedMediaController.Instance.RATitleScreenURI = GameInfo.ImageTitle;
            RelatedMediaController.Instance.RAScreenshotURI = GameInfo.ImageIngame;
            RelatedMediaController.Instance.RABoxArtURI = GameInfo.ImageBoxArt;
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

                if (LockedAchievements.IndexOf(CurrentlyViewingAchievement) == 0)
                {
                    focusAchievementButtonPrevious.Enabled = false;
                    focusAchievementButtonNext.Enabled = LockedAchievements.Count > 1;
                }
                else if (LockedAchievements.IndexOf(CurrentlyViewingAchievement) == LockedAchievements.Count - 1)
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
        private void StartButton_Click(object sender, EventArgs e)
        {
            RetroAchievementsAPIClient = new RetroAchievementAPIClient(usernameTextBox.Text, apiKeyTextBox.Text);

            ShouldRun = true;

            startButton.Enabled = false;
            stopButton.Enabled = true;

            usernameTextBox.Enabled = false;
            apiKeyTextBox.Enabled = false;

            focusOpenWindowButton.Enabled = true;
            alertsOpenWindowButton.Enabled = true;
            userInfoOpenWindowButton.Enabled = true;
            gameInfoOpenWindowButton.Enabled = true;

            StartTimer();

            CurrentErrorCount = 0;
        }
        private void StopButton_Click(object sender, EventArgs e)
        {
            ShouldRun = false;

            UserAndGameUpdateTimer.Stop();

            raConnectionStatusPictureBox.Image = Resources.red_button;

            UpdateLogLabel("Stopped.");

            stopButton.Enabled = false;

            bool canStart = CanStart();

            focusOpenWindowButton.Enabled = canStart;
            alertsOpenWindowButton.Enabled = canStart;
            userInfoOpenWindowButton.Enabled = canStart;
            gameInfoOpenWindowButton.Enabled = canStart;
            recentAchievementsOpenWindowButton.Enabled = canStart;
            achievementListOpenWindowButton.Enabled = canStart;

            apiKeyTextBox.Enabled = true;
            usernameTextBox.Enabled = true;

            startButton.Enabled = canStart;

            IsLaunching = false;
            IsLoading = false;
        }
        private void RequiredField_TextChanged(object sender, EventArgs e)
        {
            startButton.Enabled = CanStart();
        }
        private void RSSFeedCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!IsLoading)
            {
                IsLoading = true;
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

                IsLoading = false;

                Settings.Default.Save();

                rssFeedListView.Items.Clear();

                RefreshRSSFeed();
            }
        }
        private void CustomAlertsCheckBox_CheckedChanged(object sender, EventArgs eventArgs)
        {
            if (!IsLoading)
            {
                IsLoading = true;

                CheckBox checkBox = sender as CheckBox;
                bool isChecked = checkBox.Checked;

                switch (checkBox.Name)
                {
                    case "alertsAchievementEnableCheckbox":
                        AlertsController.Instance.AchievementAlertEnable = isChecked;
                        break;
                    case "alertsMasteryEnableCheckbox":
                        AlertsController.Instance.MasteryAlertEnable = isChecked;
                        break;
                    case "alertsCustomAchievementEnableCheckbox":
                        AlertsController.Instance.CustomAchievementEnabled = isChecked;

                        if (isChecked)
                        {
                            if (!File.Exists(AlertsController.Instance.CustomAchievementFile))
                            {
                                SelectCustomAchievementFile();
                            }
                        }
                        break;
                    case "alertsCustomMasteryEnableCheckbox":
                        AlertsController.Instance.CustomMasteryEnabled = isChecked;

                        if (isChecked)
                        {
                            if (!File.Exists(AlertsController.Instance.CustomMasteryFile))
                            {
                                SelectCustomMasteryFile();
                            }
                        }
                        break;
                    case "alertsAchievementEditOutlineCheckbox":
                        if (checkBox.Checked)
                        {
                            AlertsController.Instance.EnableAchievementEdit();
                            AlertsController.Instance.SendAchievementNotification(new Achievement()
                            {
                                Title = "Thrilling!!!!",
                                Description = "Color every bit of Dinosaur 2. [Must color white if leaving white]",
                                BadgeUri = "https://retroachievements.org/Badge/49987.png",
                                Points = 1
                            });
                        }
                        else
                        {
                            AlertsController.Instance.DisableAchievementEdit();
                        }
                        break;
                    case "alertsMasteryEditOutlineCheckbox":
                        if (checkBox.Checked)
                        {
                            AlertsController.Instance.EnableMasteryEdit();
                            AlertsController.Instance.SendMasteryNotification(GameInfo);
                        }
                        else
                        {
                            AlertsController.Instance.DisableMasteryEdit();
                        }
                        break;
                }

                UpdateAlertsEnabledControls();

                IsLoading = false;
            }
        }
        private void UpdateAlertsEnabledControls()
        {
            alertsAchievementEnableCheckbox.Checked = AlertsController.Instance.AchievementAlertEnable;
            alertsMasteryEnableCheckbox.Checked = AlertsController.Instance.MasteryAlertEnable;

            if (AlertsController.Instance.AchievementAlertEnable)
            {
                alertsPlayAchievementButton.Enabled = true;
                alertsCustomAchievementEnableCheckbox.Enabled = true;

                if (AlertsController.Instance.CustomAchievementEnabled)
                {
                    alertsCustomAchievementPanel.Enabled = true;

                    alertsSelectCustomAchievementFileButton.Enabled = true;
                    alertsAchievementEditOutlineCheckbox.Enabled = true;
                }
                else
                {
                    alertsCustomAchievementPanel.Enabled = false;

                    alertsSelectCustomAchievementFileButton.Enabled = false;
                    alertsAchievementEditOutlineCheckbox.Enabled = false;
                }
            }
            else
            {
                alertsCustomAchievementPanel.Enabled = false;
                alertsSelectCustomAchievementFileButton.Enabled = false;
                alertsPlayAchievementButton.Enabled = false;

                alertsCustomAchievementEnableCheckbox.Enabled = false;
                alertsAchievementEditOutlineCheckbox.Enabled = false;
            }

            if (AlertsController.Instance.MasteryAlertEnable)
            {
                alertsPlayMasteryButton.Enabled = true;
                alertsCustomMasteryEnableCheckbox.Enabled = true;

                if (AlertsController.Instance.CustomMasteryEnabled)
                {
                    alertsCustomMasteryPanel.Enabled = true;

                    alertsSelectCustomMasteryFileButton.Enabled = true;
                    alertsMasteryEditOutlineCheckbox.Enabled = true;
                }
                else
                {
                    alertsCustomMasteryPanel.Enabled = false;

                    alertsSelectCustomMasteryFileButton.Enabled = false;
                    alertsMasteryEditOutlineCheckbox.Enabled = false;
                }
            }
            else
            {
                alertsCustomMasteryPanel.Enabled = false;
                alertsSelectCustomMasteryFileButton.Enabled = false;
                alertsPlayMasteryButton.Enabled = false;

                alertsCustomMasteryEnableCheckbox.Enabled = false;
                alertsMasteryEditOutlineCheckbox.Enabled = false;
            }
        }
        private void CustomNumericUpDown_ValueChanged(object sender, EventArgs eventArgs)
        {
            if (!IsLoading)
            {
                IsLoading = true;
                NumericUpDown numericUpDown = sender as NumericUpDown;

                switch (numericUpDown.Name)
                {
                    case "focusTitleFontOutlineNumericUpDown":
                        if (FocusController.Instance.AdvancedSettingsEnabled)
                        {
                            FocusController.Instance.TitleOutlineSize = Convert.ToInt32(numericUpDown.Value);
                        }
                        else
                        {
                            FocusController.Instance.SimpleFontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                        }
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
                    case "alertsTitleFontOutlineNumericUpDown":
                        if (AlertsController.Instance.AdvancedSettingsEnabled)
                        {
                            AlertsController.Instance.TitleOutlineSize = Convert.ToInt32(numericUpDown.Value);
                        }
                        else
                        {
                            AlertsController.Instance.SimpleFontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                        }
                        break;
                    case "alertsDescriptionFontOutlineNumericUpDown":
                        AlertsController.Instance.DescriptionOutlineSize = Convert.ToInt32(numericUpDown.Value);
                        break;
                    case "alertsPointsFontOutlineNumericUpDown":
                        AlertsController.Instance.PointsOutlineSize = Convert.ToInt32(numericUpDown.Value);
                        break;
                    case "alertsLineOutlineNumericUpDown":
                        AlertsController.Instance.LineOutlineSize = Convert.ToInt32(numericUpDown.Value);
                        break;
                    case "alertsCustomAchievementXNumericUpDown":
                        AlertsController.Instance.CustomAchievementX = Convert.ToInt32(numericUpDown.Value);
                        break;
                    case "alertsCustomAchievementYNumericUpDown":
                        AlertsController.Instance.CustomAchievementY = Convert.ToInt32(numericUpDown.Value);
                        break;
                    case "alertsCustomAchievementScaleNumericUpDown":
                        AlertsController.Instance.CustomAchievementScale = Convert.ToInt32(numericUpDown.Value);
                        break;
                    case "alertsCustomAchievementInNumericUpDown":
                        AlertsController.Instance.CustomAchievementIn = Convert.ToInt32(numericUpDown.Value);
                        break;
                    case "alertsCustomAchievementInSpeedUpDown":
                        AlertsController.Instance.CustomAchievementInSpeed = Convert.ToInt32(numericUpDown.Value);
                        break;
                    case "alertsCustomAchievementOutNumericUpDown":
                        AlertsController.Instance.CustomAchievementOut = Convert.ToInt32(numericUpDown.Value);
                        break;
                    case "alertsCustomAchievementOutSpeedUpDown":
                        AlertsController.Instance.CustomAchievementOutSpeed = Convert.ToInt32(numericUpDown.Value);
                        break;
                    case "alertsCustomMasteryXNumericUpDown":
                        AlertsController.Instance.CustomMasteryX = Convert.ToInt32(numericUpDown.Value);
                        break;
                    case "alertsCustomMasteryYNumericUpDown":
                        AlertsController.Instance.CustomMasteryY = Convert.ToInt32(numericUpDown.Value);
                        break;
                    case "alertsCustomMasteryScaleNumericUpDown":
                        AlertsController.Instance.CustomMasteryScale = Convert.ToInt32(numericUpDown.Value);
                        break;
                    case "alertsCustomMasteryInNumericUpDown":
                        AlertsController.Instance.CustomMasteryIn = Convert.ToInt32(numericUpDown.Value);
                        break;
                    case "alertsCustomMasteryInSpeedUpDown":
                        AlertsController.Instance.CustomMasteryInSpeed = Convert.ToInt32(numericUpDown.Value);
                        break;
                    case "alertsCustomMasteryOutNumericUpDown":
                        AlertsController.Instance.CustomMasteryOut = Convert.ToInt32(numericUpDown.Value);
                        break;
                    case "alertsCustomMasteryOutSpeedUpDown":
                        AlertsController.Instance.CustomMasteryOutSpeed = Convert.ToInt32(numericUpDown.Value);
                        break;
                    case "userInfoNamesFontOutlineNumericUpDown":
                        if (UserInfoController.Instance.AdvancedSettingsEnabled)
                        {
                            UserInfoController.Instance.NameOutlineSize = Convert.ToInt32(numericUpDown.Value);
                        }
                        else
                        {
                            UserInfoController.Instance.SimpleFontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                        }
                        break;
                    case "userInfoValuesFontOutlineNumericUpDown":
                        UserInfoController.Instance.ValueOutlineSize = Convert.ToInt32(numericUpDown.Value);
                        break;
                    case "gameInfoNamesFontOutlineNumericUpDown":
                        if (GameInfoController.Instance.AdvancedSettingsEnabled)
                        {
                            GameInfoController.Instance.NameOutlineSize = Convert.ToInt32(numericUpDown.Value);
                        }
                        else
                        {
                            GameInfoController.Instance.SimpleFontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                        }
                        break;
                    case "gameInfoValuesFontOutlineNumericUpDown":
                        GameInfoController.Instance.ValueOutlineSize = Convert.ToInt32(numericUpDown.Value);
                        break;
                    case "gameProgressNamesFontOutlineNumericUpDown":
                        if (GameProgressController.Instance.AdvancedSettingsEnabled)
                        {
                            GameProgressController.Instance.NameOutlineSize = Convert.ToInt32(numericUpDown.Value);
                        }
                        else
                        {
                            GameProgressController.Instance.SimpleFontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                        }
                        break;
                    case "gameProgressValuesFontOutlineNumericUpDown":
                        GameProgressController.Instance.ValueOutlineSize = Convert.ToInt32(numericUpDown.Value);
                        break;
                    case "recentAchievementsTitleFontOutlineNumericUpDown":
                        if (RecentAchievementsController.Instance.AdvancedSettingsEnabled)
                        {
                            RecentAchievementsController.Instance.TitleOutlineSize = Convert.ToInt32(numericUpDown.Value);
                        }
                        else
                        {
                            RecentAchievementsController.Instance.SimpleFontOutlineSize = Convert.ToInt32(numericUpDown.Value);
                        }
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
                        RecentAchievementsController.Instance.SetAchievements(UnlockedAchievements.ToList());
                        break;
                }

                IsLoading = false;
            }
        }
        private void SelectCustomAlertButton_Click(object sender, EventArgs eventArgs)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "alertsSelectCustomAchievementFileButton":
                    SelectCustomAchievementFile();
                    break;
                case "alertsSelectCustomMasteryFileButton":
                    SelectCustomMasteryFile();
                    break;
            }
        }
        private void SelectCustomAchievementFile()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                AlertsController.Instance.CustomAchievementFile = openFileDialog1.FileName;
            }
            else if (AlertsController.Instance.CustomAchievementEnabled && (string.IsNullOrEmpty(AlertsController.Instance.CustomAchievementFile) || !File.Exists(AlertsController.Instance.CustomAchievementFile)))
            {
                AlertsController.Instance.CustomAchievementEnabled = false;
                alertsCustomAchievementEnableCheckbox.Checked = false;
            }
        }
        private void SelectCustomMasteryFile()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                AlertsController.Instance.CustomMasteryFile = openFileDialog1.FileName;
            }
            else if (AlertsController.Instance.CustomMasteryEnabled && (string.IsNullOrEmpty(AlertsController.Instance.CustomMasteryFile) || !File.Exists(AlertsController.Instance.CustomMasteryFile)))
            {
                AlertsController.Instance.CustomMasteryEnabled = false;
                alertsCustomMasteryEnableCheckbox.Checked = false;
            }
        }
        private void ShowAlertButton_Click(object sender, EventArgs eventArgs)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "alertsPlayAchievementButton":
                    List<Achievement> unlockedAchievements = UnlockedAchievements.ToList();

                    if (unlockedAchievements.Count > 0)
                    {
                        unlockedAchievements.Sort();
                        Achievement achievement = (Achievement)unlockedAchievements[unlockedAchievements.Count - 1].Clone();

                        AlertsController.Instance.EnqueueAchievementNotifications(new List<Achievement>() { achievement });
                        StreamLabelManager.Instance.EnqueueAlert(achievement);
                    }
                    else
                    {
                        Achievement achievement = new Achievement()
                        {
                            Title = "Thrilling!!!!",
                            Description = "Color every bit of Dinosaur 2. [Must color white if leaving white]",
                            BadgeUri = "https://retroachievements.org/Badge/49987.png",
                            Points = 1
                        };

                        AlertsController.Instance.EnqueueAchievementNotifications(new List<Achievement>() { achievement });
                        StreamLabelManager.Instance.EnqueueAlert(achievement);
                    }
                    break;
                case "alertsPlayMasteryButton":
                    AlertsController.Instance.EnqueueMasteryNotification(GameInfo);
                    StreamLabelManager.Instance.EnqueueAlert(GameInfo);
                    break;
            }

            AlertsController.Instance.RunNotifications();
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

            while (CurrentlyViewingIndex > -1 && !LockedAchievements.Contains(GameInfo.Achievements[CurrentlyViewingIndex]))
            {
                CurrentlyViewingIndex--;
            }

            UpdateCurrentlyViewingAchievement();
        }
        private void MoveFocusIndexNext_Click(object sender, EventArgs e)
        {
            CurrentlyViewingIndex++;

            while (CurrentlyViewingIndex < GameInfo.Achievements.Count - 1 && !LockedAchievements.Contains(GameInfo.Achievements[CurrentlyViewingIndex]))
            {
                CurrentlyViewingIndex++;
            }

            UpdateCurrentlyViewingAchievement();
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
                case "alertsOpenWindowButton":
                    AlertsController.Instance.Show();
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
                case "relatedMediaOpenWindowButton":
                    RelatedMediaController.Instance.Show();
                    break;
            }
        }
        private void SetRelatedMediaPathButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                RelatedMediaController.Instance.LaunchBoxFilePath = folderBrowserDialog1.SelectedPath;

                UpdateRelatedMediaRadioButtons();
                UpdateMediaReferences();
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
        private void FontColorPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                switch (pictureBox.Name)
                {
                    case "focusBackgroundColorPictureBox":
                        FocusController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        focusBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "focusBorderColorPictureBox":
                        FocusController.Instance.BorderBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        focusBorderColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "focusTitleFontColorPictureBox":
                        if (FocusController.Instance.AdvancedSettingsEnabled)
                        {
                            FocusController.Instance.TitleColor = MediaHelper.HexConverter(colorDialog1.Color); ;
                        }
                        else
                        {
                            FocusController.Instance.SimpleFontColor = MediaHelper.HexConverter(colorDialog1.Color); ;
                        }
                        focusTitleFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "focusDescriptionFontColorPictureBox":
                        FocusController.Instance.DescriptionColor = MediaHelper.HexConverter(colorDialog1.Color);
                        focusDescriptionFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "focusPointsFontColorPictureBox":
                        FocusController.Instance.PointsColor = MediaHelper.HexConverter(colorDialog1.Color);
                        focusPointsFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "focusLineColorPictureBox":
                        FocusController.Instance.LineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        focusLineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "focusTitleFontOutlineColorPictureBox":
                        if (FocusController.Instance.AdvancedSettingsEnabled)
                        {
                            FocusController.Instance.TitleOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        }
                        else
                        {
                            FocusController.Instance.SimpleFontOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        }
                        focusTitleFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "focusDescriptionFontOutlineColorPictureBox":
                        FocusController.Instance.DescriptionOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        focusDescriptionFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "focusPointsFontOutlineColorPictureBox":
                        FocusController.Instance.PointsOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        focusPointsFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "focusLineOutlineColorPictureBox":
                        FocusController.Instance.LineOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        focusLineOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "alertsBackgroundColorPictureBox":
                        AlertsController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        alertsBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "alertsBorderColorPictureBox":
                        AlertsController.Instance.BorderBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        alertsBorderColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "alertsTitleFontColorPictureBox":
                        if (AlertsController.Instance.AdvancedSettingsEnabled)
                        {
                            AlertsController.Instance.TitleColor = MediaHelper.HexConverter(colorDialog1.Color);
                        }
                        else
                        {
                            AlertsController.Instance.SimpleFontColor = MediaHelper.HexConverter(colorDialog1.Color);
                        }
                        alertsTitleFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "alertsDescriptionFontColorPictureBox":
                        AlertsController.Instance.DescriptionColor = MediaHelper.HexConverter(colorDialog1.Color);
                        alertsDescriptionFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "alertsPointsFontColorPictureBox":
                        AlertsController.Instance.PointsColor = MediaHelper.HexConverter(colorDialog1.Color);
                        alertsPointsFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "alertsLineColorPictureBox":
                        AlertsController.Instance.LineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        alertsLineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "alertsTitleFontOutlineColorPictureBox":
                        if (AlertsController.Instance.AdvancedSettingsEnabled)
                        {
                            AlertsController.Instance.TitleOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        }
                        else
                        {
                            AlertsController.Instance.SimpleFontOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        }
                        alertsTitleFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "alertsDescriptionFontOutlineColorPictureBox":
                        AlertsController.Instance.DescriptionOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        alertsDescriptionFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "alertsPointsFontOutlineColorPictureBox":
                        AlertsController.Instance.PointsOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        alertsPointsFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "alertsLineOutlineColorPictureBox":
                        AlertsController.Instance.LineOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        alertsLineOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "userInfoBackgroundColorPictureBox":
                        UserInfoController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        userInfoBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "userInfoNamesFontColorPictureBox":
                        if (UserInfoController.Instance.AdvancedSettingsEnabled)
                        {
                            UserInfoController.Instance.NameColor = MediaHelper.HexConverter(colorDialog1.Color);
                        }
                        else
                        {
                            UserInfoController.Instance.SimpleFontColor = MediaHelper.HexConverter(colorDialog1.Color);
                        }
                        userInfoNamesFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "userInfoValuesFontColorPictureBox":
                        UserInfoController.Instance.ValueColor = MediaHelper.HexConverter(colorDialog1.Color);
                        userInfoValuesFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "userInfoNamesFontOutlineColorPictureBox":
                        if (UserInfoController.Instance.AdvancedSettingsEnabled)
                        {
                            UserInfoController.Instance.NameOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        }
                        else
                        {
                            UserInfoController.Instance.SimpleFontOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        }
                        userInfoNamesFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "userInfoValuesFontOutlineColorPictureBox":
                        UserInfoController.Instance.ValueOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        userInfoValuesFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameInfoBackgroundColorPictureBox":
                        GameInfoController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        gameInfoBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameInfoNamesFontColorPictureBox":
                        if (GameInfoController.Instance.AdvancedSettingsEnabled)
                        {
                            GameInfoController.Instance.NameColor = MediaHelper.HexConverter(colorDialog1.Color);
                        }
                        else
                        {
                            GameInfoController.Instance.SimpleFontColor = MediaHelper.HexConverter(colorDialog1.Color);
                        }
                        gameInfoNamesFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameInfoValuesFontColorPictureBox":
                        GameInfoController.Instance.ValueColor = MediaHelper.HexConverter(colorDialog1.Color);
                        gameInfoValuesFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameInfoNamesFontOutlineColorPictureBox":
                        if (GameInfoController.Instance.AdvancedSettingsEnabled)
                        {
                            GameInfoController.Instance.NameOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        }
                        else
                        {
                            GameInfoController.Instance.SimpleFontOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        }
                        gameInfoNamesFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameInfoValuesFontOutlineColorPictureBox":
                        GameInfoController.Instance.ValueOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        gameInfoValuesFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameProgressBackgroundColorPictureBox":
                        GameProgressController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        gameProgressBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameProgressNamesFontColorPictureBox":
                        if (GameProgressController.Instance.AdvancedSettingsEnabled)
                        {
                            GameProgressController.Instance.NameColor = MediaHelper.HexConverter(colorDialog1.Color);
                        }
                        else
                        {
                            GameProgressController.Instance.SimpleFontColor = MediaHelper.HexConverter(colorDialog1.Color);
                        }
                        gameProgressNamesFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameProgressValuesFontColorPictureBox":
                        GameProgressController.Instance.ValueColor = MediaHelper.HexConverter(colorDialog1.Color);
                        gameProgressValuesFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameProgressNamesFontOutlineColorPictureBox":
                        if (GameProgressController.Instance.AdvancedSettingsEnabled)
                        {
                            GameProgressController.Instance.NameOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        }
                        else
                        {
                            GameProgressController.Instance.SimpleFontOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        }
                        gameProgressNamesFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "gameProgressValuesFontOutlineColorPictureBox":
                        GameProgressController.Instance.ValueOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        gameProgressValuesFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "recentAchievementsBackgroundColorPictureBox":
                        RecentAchievementsController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        recentAchievementsBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "recentAchievementsBorderColorPictureBox":
                        RecentAchievementsController.Instance.BorderBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        recentAchievementsBorderColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "recentAchievementsTitleFontColorPictureBox":
                        if (RecentAchievementsController.Instance.AdvancedSettingsEnabled)
                        {
                            RecentAchievementsController.Instance.TitleColor = MediaHelper.HexConverter(colorDialog1.Color);
                        }
                        else
                        {
                            RecentAchievementsController.Instance.SimpleFontColor = MediaHelper.HexConverter(colorDialog1.Color);
                        }
                        recentAchievementsTitleFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "recentAchievementsDateFontColorPictureBox":
                        RecentAchievementsController.Instance.DateColor = MediaHelper.HexConverter(colorDialog1.Color);
                        recentAchievementsDateFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "recentAchievementsPointsFontColorPictureBox":
                        RecentAchievementsController.Instance.PointsColor = MediaHelper.HexConverter(colorDialog1.Color);
                        recentAchievementsPointsFontColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "recentAchievementsLineColorPictureBox":
                        RecentAchievementsController.Instance.LineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        recentAchievementsLineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "recentAchievementsTitleFontOutlineColorPictureBox":
                        if (RecentAchievementsController.Instance.AdvancedSettingsEnabled)
                        {
                            RecentAchievementsController.Instance.TitleOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        }
                        else
                        {
                            RecentAchievementsController.Instance.SimpleFontOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        }
                        recentAchievementsTitleFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "recentAchievementsDateFontOutlineColorPictureBox":
                        RecentAchievementsController.Instance.DateOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        recentAchievementsDateFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "recentAchievementsPointsFontOutlineColorPictureBox":
                        RecentAchievementsController.Instance.PointsOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        recentAchievementsPointsFontOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "recentAchievementsLineOutlineColorPictureBox":
                        RecentAchievementsController.Instance.LineOutlineColor = MediaHelper.HexConverter(colorDialog1.Color);
                        recentAchievementsLineOutlineColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "achievementListBackgroundColorPictureBox":
                        AchievementListController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        achievementListBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                    case "relatedMediaBackgroundColorPictureBox":
                        RelatedMediaController.Instance.WindowBackgroundColor = MediaHelper.HexConverter(colorDialog1.Color);
                        relatedMediaBackgroundColorPictureBox.BackColor = colorDialog1.Color;
                        break;
                }
            }
        }
        private void FontFamilyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsLoading)
            {
                IsLoading = true;

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
                        case "focusTitleFontComboBox":
                            if (FocusController.Instance.AdvancedSettingsEnabled)
                            {
                                FocusController.Instance.TitleFontFamily = fontFamily;
                            }
                            else
                            {
                                FocusController.Instance.SimpleFontFamily = fontFamily;
                            }
                            break;
                        case "focusDescriptionFontComboBox":
                            FocusController.Instance.DescriptionFontFamily = fontFamily;
                            break;
                        case "focusPointsFontComboBox":
                            FocusController.Instance.PointsFontFamily = fontFamily;
                            break;
                        case "alertsTitleFontComboBox":
                            if (AlertsController.Instance.AdvancedSettingsEnabled)
                            {
                                AlertsController.Instance.TitleFontFamily = fontFamily;
                            }
                            else
                            {
                                AlertsController.Instance.SimpleFontFamily = fontFamily;
                            }
                            break;
                        case "alertsDescriptionFontComboBox":
                            AlertsController.Instance.DescriptionFontFamily = fontFamily;
                            break;
                        case "alertsPointsFontComboBox":
                            AlertsController.Instance.PointsFontFamily = fontFamily;
                            break;
                        case "userInfoNamesFontComboBox":
                            if (UserInfoController.Instance.AdvancedSettingsEnabled)
                            {
                                UserInfoController.Instance.NameFontFamily = fontFamily;
                            }
                            else
                            {
                                UserInfoController.Instance.SimpleFontFamily = fontFamily;
                            }
                            break;
                        case "userInfoValuesFontComboBox":
                            UserInfoController.Instance.ValueFontFamily = fontFamily;
                            break;
                        case "gameInfoNamesFontComboBox":
                            if (GameInfoController.Instance.AdvancedSettingsEnabled)
                            {
                                GameInfoController.Instance.NameFontFamily = fontFamily;
                            }
                            else
                            {
                                GameInfoController.Instance.SimpleFontFamily = fontFamily;
                            }
                            break;
                        case "gameInfoValuesFontComboBox":
                            GameInfoController.Instance.ValueFontFamily = fontFamily;
                            break;
                        case "gameProgressNamesFontComboBox":
                            if (GameProgressController.Instance.AdvancedSettingsEnabled)
                            {
                                GameProgressController.Instance.NameFontFamily = fontFamily;
                            }
                            else
                            {
                                GameProgressController.Instance.SimpleFontFamily = fontFamily;
                            }
                            break;
                        case "gameProgressValuesFontComboBox":
                            GameProgressController.Instance.ValueFontFamily = fontFamily;
                            break;
                        case "recentAchievementsTitleFontComboBox":
                            if (RecentAchievementsController.Instance.AdvancedSettingsEnabled)
                            {
                                RecentAchievementsController.Instance.TitleFontFamily = fontFamily;
                            }
                            else
                            {
                                RecentAchievementsController.Instance.SimpleFontFamily = fontFamily;
                            }

                            RecentAchievementsController.Instance.PopulateRecentAchievementsWindow();
                            break;
                        case "recentAchievementsDescriptionFontComboBox":
                            RecentAchievementsController.Instance.DateFontFamily = fontFamily;
                            RecentAchievementsController.Instance.PopulateRecentAchievementsWindow();
                            break;
                        case "recentAchievementsPointsFontComboBox":
                            RecentAchievementsController.Instance.PointsFontFamily = fontFamily;
                            RecentAchievementsController.Instance.PopulateRecentAchievementsWindow();
                            break;
                    }
                }

                IsLoading = false;
            }
        }
        private void NotificationAnimationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsLoading)
            {
                IsLoading = true;
                ComboBox comboBox = sender as ComboBox;

                switch (comboBox.Name)
                {
                    case "alertsCustomAchievementAnimationInComboBox":
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
                    case "alertsCustomAchievementAnimationOutComboBox":
                        switch ((string)alertsCustomAchievementAnimationOutComboBox.SelectedItem)
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
                    case "alertsCustomMasteryAnimationInComboBox":
                        switch ((string)alertsCustomMasteryAnimationInComboBox.SelectedItem)
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
                    case "alertsCustomMasteryAnimationOutComboBox":
                        switch ((string)alertsCustomMasteryAnimationOutComboBox.SelectedItem)
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

                IsLoading = false;
            }
        }
        private void FeatureEnablementCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!IsLoading)
            {
                IsLoading = true;

                CheckBox checkBox = sender as CheckBox;

                switch (checkBox.Name)
                {
                    case "recentAchievementsAutoOpenWindowCheckbox":
                        RecentAchievementsController.Instance.AutoLaunch = checkBox.Checked;
                        break;
                    case "gameInfoAutoOpenWindowCheckbox":
                        GameInfoController.Instance.AutoLaunch = checkBox.Checked;
                        break;
                    case "alertsAutoOpenWindowCheckbox":
                        AlertsController.Instance.AutoLaunch = checkBox.Checked;
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
                    case "relatedMediaAutoOpenWindowCheckbox":
                        RelatedMediaController.Instance.AutoLaunch = checkBox.Checked;
                        break;
                    case "autoStartCheckbox":
                        Settings.Default.auto_start_checked = checkBox.Checked;
                        Settings.Default.Save();
                        break;
                    case "achievementListAutoScrollCheckBox":
                        AchievementListController.Instance.AutoScroll = checkBox.Checked;
                        break;
                    case "recentAchievementsAutoScrollCheckBox":
                        RecentAchievementsController.Instance.AutoScroll = checkBox.Checked;
                        break;
                    case "focusBorderCheckBox":
                        FocusController.Instance.BorderEnabled = checkBox.Checked;
                        break;
                    case "alertsBorderCheckBox":
                        AlertsController.Instance.BorderEnabled = checkBox.Checked;
                        break;
                    case "recentAchievementsBorderCheckBox":
                        RecentAchievementsController.Instance.BorderEnabled = checkBox.Checked;
                        break;
                    case "focusTitleOutlineCheckBox":
                        if (FocusController.Instance.AdvancedSettingsEnabled)
                        {
                            FocusController.Instance.TitleOutlineEnabled = checkBox.Checked;
                        }
                        else
                        {
                            FocusController.Instance.SimpleFontOutlineEnabled = checkBox.Checked;
                        }
                        break;
                    case "focusDescriptionOutlineCheckBox":
                        FocusController.Instance.DescriptionOutlineEnabled = checkBox.Checked;
                        break;
                    case "focusPointsOutlineCheckBox":
                        FocusController.Instance.PointsOutlineEnabled = checkBox.Checked;
                        break;
                    case "focusLineOutlineCheckBox":
                        FocusController.Instance.LineOutlineEnabled = checkBox.Checked;
                        break;
                    case "alertsTitleOutlineCheckBox":
                        if (AlertsController.Instance.AdvancedSettingsEnabled)
                        {
                            AlertsController.Instance.TitleOutlineEnabled = checkBox.Checked;
                        }
                        else
                        {
                            AlertsController.Instance.SimpleFontOutlineEnabled = checkBox.Checked;
                        }
                        break;
                    case "alertsDescriptionOutlineCheckBox":
                        AlertsController.Instance.DescriptionOutlineEnabled = checkBox.Checked;
                        break;
                    case "alertsPointsOutlineCheckBox":
                        AlertsController.Instance.PointsOutlineEnabled = checkBox.Checked;
                        break;
                    case "alertsLineOutlineCheckBox":
                        AlertsController.Instance.LineOutlineEnabled = checkBox.Checked;
                        break;
                    case "userInfoNamesOutlineCheckBox":
                        if (UserInfoController.Instance.AdvancedSettingsEnabled)
                        {
                            UserInfoController.Instance.NameOutlineEnabled = checkBox.Checked;
                        }
                        else
                        {
                            UserInfoController.Instance.SimpleFontOutlineEnabled = checkBox.Checked;
                        }
                        break;
                    case "userInfoValuesOutlineCheckBox":
                        UserInfoController.Instance.ValueOutlineEnabled = checkBox.Checked;
                        break;
                    case "gameProgressNamesOutlineCheckBox":
                        if (GameProgressController.Instance.AdvancedSettingsEnabled)
                        {
                            GameProgressController.Instance.NameOutlineEnabled = checkBox.Checked;
                        }
                        else
                        {
                            GameProgressController.Instance.SimpleFontOutlineEnabled = checkBox.Checked;
                        }
                        break;
                    case "gameProgressValuesOutlineCheckBox":
                        GameProgressController.Instance.ValueOutlineEnabled = checkBox.Checked;
                        break;
                    case "gameInfoNamesOutlineCheckBox":
                        if (GameInfoController.Instance.AdvancedSettingsEnabled)
                        {
                            GameInfoController.Instance.NameOutlineEnabled = checkBox.Checked;
                        }
                        else
                        {
                            GameInfoController.Instance.SimpleFontOutlineEnabled = checkBox.Checked;
                        }
                        break;
                    case "gameInfoValuesOutlineCheckBox":
                        GameInfoController.Instance.ValueOutlineEnabled = checkBox.Checked;
                        break;
                    case "recentAchievementsTitleFontOutlineCheckBox":
                        if (RecentAchievementsController.Instance.AdvancedSettingsEnabled)
                        {
                            RecentAchievementsController.Instance.TitleOutlineEnabled = checkBox.Checked;
                        }
                        else
                        {
                            RecentAchievementsController.Instance.SimpleFontOutlineEnabled = checkBox.Checked;
                        }
                        break;
                    case "recentAchievementsDateFontOutlineCheckBox":
                        RecentAchievementsController.Instance.DescriptionOutlineEnabled = checkBox.Checked;
                        break;
                    case "recentAchievementsPointsFontOutlineCheckBox":
                        RecentAchievementsController.Instance.PointsOutlineEnabled = checkBox.Checked;
                        break;
                    case "recentAchievementsLineOutlineCheckBox":
                        RecentAchievementsController.Instance.LineOutlineEnabled = checkBox.Checked;
                        break;
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
                        GameProgressController.Instance.AchievementsEnabled = checkBox.Checked;
                        break;
                    case "gameProgressPointsCheckBox":
                        GameProgressController.Instance.PointsEnabled = checkBox.Checked;
                        break;
                    case "gameProgressTruePointsCheckBox":
                        GameProgressController.Instance.TruePointsEnabled = checkBox.Checked;
                        break;
                    case "gameProgressCompletedCheckBox":
                        GameProgressController.Instance.CompletedEnabled = checkBox.Checked;
                        break;
                    case "gameProgressRatioCheckBox":
                        GameProgressController.Instance.RatioEnabled = checkBox.Checked;
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

                IsLoading = false;
            }
        }
        private void DividerCharacter_RadioButtonClicked(object sender, EventArgs e)
        {
            if (!IsLoading)
            {
                IsLoading = true;
                RadioButton radioButton = sender as RadioButton;

                if (radioButton.Checked)
                {
                    switch (radioButton.Name)
                    {
                        case "gameProgressCheckBoxBackslash":
                            GameProgressController.Instance.DividerCharacter = "/";
                            break;
                        case "gameProgressCheckBoxColon":
                            GameProgressController.Instance.DividerCharacter = ":";
                            break;
                        case "gameProgressCheckBoxPeriod":
                            GameProgressController.Instance.DividerCharacter = ".";
                            break;
                    }
                }

                UpdateDividerCharacterRadioButtons();
                IsLoading = false;
            }
        }
        private void UpdateDividerCharacterRadioButtons()
        {
            switch (GameProgressController.Instance.DividerCharacter)
            {
                case "/":
                    gameProgressRadioButtonBackslash.Checked = true;
                    gameProgressRadioButtonColon.Checked = false;
                    gameProgressRadioButtonPeriod.Checked = false;
                    break;
                case ":":
                    gameProgressRadioButtonBackslash.Checked = false;
                    gameProgressRadioButtonColon.Checked = true;
                    gameProgressRadioButtonPeriod.Checked = false;
                    break;
                case ".":
                    gameProgressRadioButtonBackslash.Checked = false;
                    gameProgressRadioButtonColon.Checked = false;
                    gameProgressRadioButtonPeriod.Checked = true;
                    break;
            }
        }
        private void RefocusBehavior_RadioButtonCheckChanged(object sender, EventArgs e)
        {
            if (!IsLoading)
            {
                IsLoading = true;
                RadioButton radioButton = sender as RadioButton;

                if (radioButton.Checked)
                {
                    switch (radioButton.Name)
                    {
                        case "focusBehaviorGoToFirstRadioButton":
                            FocusController.Instance.RefocusBehavior = RefocusBehaviorEnum.GO_TO_FIRST;
                            break;
                        case "focusBehaviorGoToPreviousRadioButton":
                            FocusController.Instance.RefocusBehavior = RefocusBehaviorEnum.GO_TO_PREVIOUS;
                            break;
                        case "focusBehaviorGoToNextRadioButton":
                            FocusController.Instance.RefocusBehavior = RefocusBehaviorEnum.GO_TO_NEXT;
                            break;
                        case "focusBehaviorGoToLastRadioButton":
                            FocusController.Instance.RefocusBehavior = RefocusBehaviorEnum.GO_TO_LAST;
                            break;
                    }

                    UpdateRefocusBehaviorRadioButtons();
                }

                IsLoading = false;
            }
        }
        private void UpdateRefocusBehaviorRadioButtons()
        {
            switch (FocusController.Instance.RefocusBehavior)
            {
                case RefocusBehaviorEnum.GO_TO_FIRST:
                    focusBehaviorGoToFirstRadioButton.Checked = true;
                    focusBehaviorGoToPreviousRadioButton.Checked = false;
                    focusBehaviorGoToNextRadioButton.Checked = false;
                    focusBehaviorGoToLastRadioButton.Checked = false;
                    break;
                case RefocusBehaviorEnum.GO_TO_PREVIOUS:
                    focusBehaviorGoToFirstRadioButton.Checked = false;
                    focusBehaviorGoToPreviousRadioButton.Checked = true;
                    focusBehaviorGoToNextRadioButton.Checked = false;
                    focusBehaviorGoToLastRadioButton.Checked = false;
                    break;
                case RefocusBehaviorEnum.GO_TO_NEXT:
                    focusBehaviorGoToFirstRadioButton.Checked = false;
                    focusBehaviorGoToPreviousRadioButton.Checked = false;
                    focusBehaviorGoToNextRadioButton.Checked = true;
                    focusBehaviorGoToLastRadioButton.Checked = false;
                    break;
                case RefocusBehaviorEnum.GO_TO_LAST:
                    focusBehaviorGoToFirstRadioButton.Checked = false;
                    focusBehaviorGoToPreviousRadioButton.Checked = false;
                    focusBehaviorGoToNextRadioButton.Checked = false;
                    focusBehaviorGoToLastRadioButton.Checked = true;
                    break;
            }
        }
        private void RelatedMedia_RadioButtonCheckChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (!IsLoading)
            {
                IsLoading = true;

                switch (radioButton.Name)
                {
                    case "relatedMediaRABadgeIconRadioButton":
                        if (RelatedMediaController.Instance.RelatedMediaSelection == RelatedMediaSelection.RABadgeIcon)
                        {
                            IsLoading = false;
                            return;
                        }
                        RelatedMediaController.Instance.RelatedMediaSelection = RelatedMediaSelection.RABadgeIcon;
                        break;
                    case "relatedMediaRABoxArtRadioButton":
                        if (RelatedMediaController.Instance.RelatedMediaSelection == RelatedMediaSelection.RABoxArt)
                        {
                            IsLoading = false;
                            return;
                        }
                        RelatedMediaController.Instance.RelatedMediaSelection = RelatedMediaSelection.RABoxArt;
                        break;
                    case "relatedMediaRATitleScreenRadioButton":
                        if (RelatedMediaController.Instance.RelatedMediaSelection == RelatedMediaSelection.RATitleScreen)
                        {
                            IsLoading = false;
                            return;
                        }
                        RelatedMediaController.Instance.RelatedMediaSelection = RelatedMediaSelection.RATitleScreen;
                        break;
                    case "relatedMediaRAScreenshotRadioButton":
                        if (RelatedMediaController.Instance.RelatedMediaSelection == RelatedMediaSelection.RAIngameScreen)
                        {
                            IsLoading = false;
                            return;
                        }
                        RelatedMediaController.Instance.RelatedMediaSelection = RelatedMediaSelection.RAIngameScreen;
                        break;
                    case "relatedMediaLBBoxFrontRadioButton":
                        if (RelatedMediaController.Instance.RelatedMediaSelection == RelatedMediaSelection.LBBoxArtFront)
                        {
                            IsLoading = false;
                            return;
                        }
                        RelatedMediaController.Instance.RelatedMediaSelection = RelatedMediaSelection.LBBoxArtFront;
                        break;
                    case "relatedMediaLBBoxBackRadioButton":
                        if (RelatedMediaController.Instance.RelatedMediaSelection == RelatedMediaSelection.LBBoxArtBack)
                        {
                            IsLoading = false;
                            return;
                        }
                        RelatedMediaController.Instance.RelatedMediaSelection = RelatedMediaSelection.LBBoxArtBack;
                        break;
                    case "relatedMediaLBBox3DRadioButton":
                        if (RelatedMediaController.Instance.RelatedMediaSelection == RelatedMediaSelection.LBBoxArt3D)
                        {
                            IsLoading = false;
                            return;
                        }
                        RelatedMediaController.Instance.RelatedMediaSelection = RelatedMediaSelection.LBBoxArt3D;
                        break;
                    case "relatedMediaLBBoxFrontReconRadioButton":
                        if (RelatedMediaController.Instance.RelatedMediaSelection == RelatedMediaSelection.LBBoxArtFrontRecon)
                        {
                            IsLoading = false;
                            return;
                        }
                        RelatedMediaController.Instance.RelatedMediaSelection = RelatedMediaSelection.LBBoxArtFrontRecon;
                        break;
                    case "relatedMediaLBBoxBackReconRadioButton":
                        if (RelatedMediaController.Instance.RelatedMediaSelection == RelatedMediaSelection.LBBoxArtBackRecon)
                        {
                            IsLoading = false;
                            return;
                        }
                        RelatedMediaController.Instance.RelatedMediaSelection = RelatedMediaSelection.LBBoxArtBackRecon;
                        break;
                    case "relatedMediaLBBoxFullRadioButton":
                        if (RelatedMediaController.Instance.RelatedMediaSelection == RelatedMediaSelection.LBBoxArtFull)
                        {
                            IsLoading = false;
                            return;
                        }
                        RelatedMediaController.Instance.RelatedMediaSelection = RelatedMediaSelection.LBBoxArtFull;
                        break;
                    case "relatedMediaLBBoxSpineRadioButton":
                        if (RelatedMediaController.Instance.RelatedMediaSelection == RelatedMediaSelection.LBBoxArtSpine)
                        {
                            IsLoading = false;
                            return;
                        }
                        RelatedMediaController.Instance.RelatedMediaSelection = RelatedMediaSelection.LBBoxArtSpine;
                        break;
                    case "relatedMediaLBBannerRadioButton":
                        if (RelatedMediaController.Instance.RelatedMediaSelection == RelatedMediaSelection.LBBanner)
                        {
                            IsLoading = false;
                            return;
                        }
                        RelatedMediaController.Instance.RelatedMediaSelection = RelatedMediaSelection.LBBanner;
                        break;
                    case "relatedMediaLBTitleScreenRadioButton":
                        if (RelatedMediaController.Instance.RelatedMediaSelection == RelatedMediaSelection.LBTitleScreen)
                        {
                            IsLoading = false;
                            return;
                        }
                        RelatedMediaController.Instance.RelatedMediaSelection = RelatedMediaSelection.LBTitleScreen;
                        break;
                    case "relatedMediaLBClearLogoRadioButton":
                        if (RelatedMediaController.Instance.RelatedMediaSelection == RelatedMediaSelection.LBClearLogo)
                        {
                            IsLoading = false;
                            return;
                        }
                        RelatedMediaController.Instance.RelatedMediaSelection = RelatedMediaSelection.LBClearLogo;
                        break;
                    case "relatedMediaLBCartFrontRadioButton":
                        if (RelatedMediaController.Instance.RelatedMediaSelection == RelatedMediaSelection.LBCartFront)
                        {
                            IsLoading = false;
                            return;
                        }
                        RelatedMediaController.Instance.RelatedMediaSelection = RelatedMediaSelection.LBCartFront;
                        break;
                    case "relatedMediaLBCartBackRadioButton":
                        if (RelatedMediaController.Instance.RelatedMediaSelection == RelatedMediaSelection.LBCartBack)
                        {
                            IsLoading = false;
                            return;
                        }
                        RelatedMediaController.Instance.RelatedMediaSelection = RelatedMediaSelection.LBCartBack;
                        break;
                }

                UpdateRelatedMediaRadioButtons();

                IsLoading = false;
            }
        }
        private void UpdateRelatedMediaRadioButtons()
        {
            UpdateLaunchBoxIntegrationState();

            switch (RelatedMediaController.Instance.RelatedMediaSelection)
            {
                case RelatedMediaSelection.RABadgeIcon:
                    relatedMediaRABadgeIconRadioButton.Checked = true;
                    relatedMediaRABoxArtRadioButton.Checked = false;
                    relatedMediaRATitleScreenRadioButton.Checked = false;
                    relatedMediaRAScreenshotRadioButton.Checked = false;

                    relatedMediaLBBoxFrontRadioButton.Checked = false;
                    relatedMediaLBBoxBackRadioButton.Checked = false;
                    relatedMediaLBBox3DRadioButton.Checked = false;
                    relatedMediaLBBoxFrontReconRadioButton.Checked = false;
                    relatedMediaLBBoxBackReconRadioButton.Checked = false;
                    relatedMediaLBBoxFullRadioButton.Checked = false;
                    relatedMediaLBBoxSpineRadioButton.Checked = false;
                    relatedMediaLBBannerRadioButton.Checked = false;
                    relatedMediaLBTitleScreenRadioButton.Checked = false;
                    relatedMediaLBClearLogoRadioButton.Checked = false;
                    relatedMediaLBCartFrontRadioButton.Checked = false;
                    relatedMediaLBCartBackRadioButton.Checked = false;
                    break;
                case RelatedMediaSelection.RABoxArt:
                    relatedMediaRABadgeIconRadioButton.Checked = false;
                    relatedMediaRABoxArtRadioButton.Checked = true;
                    relatedMediaRATitleScreenRadioButton.Checked = false;
                    relatedMediaRAScreenshotRadioButton.Checked = false;

                    relatedMediaLBBoxFrontRadioButton.Checked = false;
                    relatedMediaLBBoxBackRadioButton.Checked = false;
                    relatedMediaLBBox3DRadioButton.Checked = false;
                    relatedMediaLBBoxFrontReconRadioButton.Checked = false;
                    relatedMediaLBBoxBackReconRadioButton.Checked = false;
                    relatedMediaLBBoxFullRadioButton.Checked = false;
                    relatedMediaLBBoxSpineRadioButton.Checked = false;
                    relatedMediaLBBannerRadioButton.Checked = false;
                    relatedMediaLBTitleScreenRadioButton.Checked = false;
                    relatedMediaLBClearLogoRadioButton.Checked = false;
                    relatedMediaLBCartFrontRadioButton.Checked = false;
                    relatedMediaLBCartBackRadioButton.Checked = false;
                    break;
                case RelatedMediaSelection.RATitleScreen:
                    relatedMediaRABadgeIconRadioButton.Checked = false;
                    relatedMediaRABoxArtRadioButton.Checked = false;
                    relatedMediaRATitleScreenRadioButton.Checked = true;
                    relatedMediaRAScreenshotRadioButton.Checked = false;

                    relatedMediaLBBoxFrontRadioButton.Checked = false;
                    relatedMediaLBBoxBackRadioButton.Checked = false;
                    relatedMediaLBBox3DRadioButton.Checked = false;
                    relatedMediaLBBoxFrontReconRadioButton.Checked = false;
                    relatedMediaLBBoxBackReconRadioButton.Checked = false;
                    relatedMediaLBBoxFullRadioButton.Checked = false;
                    relatedMediaLBBoxSpineRadioButton.Checked = false;
                    relatedMediaLBBannerRadioButton.Checked = false;
                    relatedMediaLBTitleScreenRadioButton.Checked = false;
                    relatedMediaLBClearLogoRadioButton.Checked = false;
                    relatedMediaLBCartFrontRadioButton.Checked = false;
                    relatedMediaLBCartBackRadioButton.Checked = false;
                    break;
                case RelatedMediaSelection.RAIngameScreen:
                    relatedMediaRABadgeIconRadioButton.Checked = false;
                    relatedMediaRABoxArtRadioButton.Checked = false;
                    relatedMediaRATitleScreenRadioButton.Checked = false;
                    relatedMediaRAScreenshotRadioButton.Checked = true;

                    relatedMediaLBBoxFrontRadioButton.Checked = false;
                    relatedMediaLBBoxBackRadioButton.Checked = false;
                    relatedMediaLBBox3DRadioButton.Checked = false;
                    relatedMediaLBBoxFrontReconRadioButton.Checked = false;
                    relatedMediaLBBoxBackReconRadioButton.Checked = false;
                    relatedMediaLBBoxFullRadioButton.Checked = false;
                    relatedMediaLBBoxSpineRadioButton.Checked = false;
                    relatedMediaLBBannerRadioButton.Checked = false;
                    relatedMediaLBTitleScreenRadioButton.Checked = false;
                    relatedMediaLBClearLogoRadioButton.Checked = false;
                    relatedMediaLBCartFrontRadioButton.Checked = false;
                    relatedMediaLBCartBackRadioButton.Checked = false;
                    break;
                case RelatedMediaSelection.LBBoxArtFront:
                    relatedMediaRABadgeIconRadioButton.Checked = false;
                    relatedMediaRABoxArtRadioButton.Checked = false;
                    relatedMediaRATitleScreenRadioButton.Checked = false;
                    relatedMediaRAScreenshotRadioButton.Checked = false;

                    relatedMediaLBBoxFrontRadioButton.Checked = true;
                    relatedMediaLBBoxBackRadioButton.Checked = false;
                    relatedMediaLBBox3DRadioButton.Checked = false;
                    relatedMediaLBBoxFrontReconRadioButton.Checked = false;
                    relatedMediaLBBoxBackReconRadioButton.Checked = false;
                    relatedMediaLBBoxFullRadioButton.Checked = false;
                    relatedMediaLBBoxSpineRadioButton.Checked = false;
                    relatedMediaLBBannerRadioButton.Checked = false;
                    relatedMediaLBTitleScreenRadioButton.Checked = false;
                    relatedMediaLBClearLogoRadioButton.Checked = false;
                    relatedMediaLBCartFrontRadioButton.Checked = false;
                    relatedMediaLBCartBackRadioButton.Checked = false;
                    break;
                case RelatedMediaSelection.LBBoxArtBack:
                    relatedMediaRABadgeIconRadioButton.Checked = false;
                    relatedMediaRABoxArtRadioButton.Checked = false;
                    relatedMediaRATitleScreenRadioButton.Checked = false;
                    relatedMediaRAScreenshotRadioButton.Checked = false;

                    relatedMediaLBBoxFrontRadioButton.Checked = false;
                    relatedMediaLBBoxBackRadioButton.Checked = true;
                    relatedMediaLBBox3DRadioButton.Checked = false;
                    relatedMediaLBBoxFrontReconRadioButton.Checked = false;
                    relatedMediaLBBoxBackReconRadioButton.Checked = false;
                    relatedMediaLBBoxFullRadioButton.Checked = false;
                    relatedMediaLBBoxSpineRadioButton.Checked = false;
                    relatedMediaLBBannerRadioButton.Checked = false;
                    relatedMediaLBTitleScreenRadioButton.Checked = false;
                    relatedMediaLBClearLogoRadioButton.Checked = false;
                    relatedMediaLBCartFrontRadioButton.Checked = false;
                    relatedMediaLBCartBackRadioButton.Checked = false;
                    break;
                case RelatedMediaSelection.LBBoxArt3D:
                    relatedMediaRABadgeIconRadioButton.Checked = false;
                    relatedMediaRABoxArtRadioButton.Checked = false;
                    relatedMediaRATitleScreenRadioButton.Checked = false;
                    relatedMediaRAScreenshotRadioButton.Checked = false;

                    relatedMediaLBBoxFrontRadioButton.Checked = false;
                    relatedMediaLBBoxBackRadioButton.Checked = false;
                    relatedMediaLBBox3DRadioButton.Checked = true;
                    relatedMediaLBBoxFrontReconRadioButton.Checked = false;
                    relatedMediaLBBoxBackReconRadioButton.Checked = false;
                    relatedMediaLBBoxFullRadioButton.Checked = false;
                    relatedMediaLBBoxSpineRadioButton.Checked = false;
                    relatedMediaLBBannerRadioButton.Checked = false;
                    relatedMediaLBTitleScreenRadioButton.Checked = false;
                    relatedMediaLBClearLogoRadioButton.Checked = false;
                    relatedMediaLBCartFrontRadioButton.Checked = false;
                    relatedMediaLBCartBackRadioButton.Checked = false;
                    break;
                case RelatedMediaSelection.LBBoxArtFrontRecon:
                    relatedMediaRABadgeIconRadioButton.Checked = false;
                    relatedMediaRABoxArtRadioButton.Checked = false;
                    relatedMediaRATitleScreenRadioButton.Checked = false;
                    relatedMediaRAScreenshotRadioButton.Checked = false;

                    relatedMediaLBBoxFrontRadioButton.Checked = false;
                    relatedMediaLBBoxBackRadioButton.Checked = false;
                    relatedMediaLBBox3DRadioButton.Checked = false;
                    relatedMediaLBBoxFrontReconRadioButton.Checked = true;
                    relatedMediaLBBoxBackReconRadioButton.Checked = false;
                    relatedMediaLBBoxFullRadioButton.Checked = false;
                    relatedMediaLBBoxSpineRadioButton.Checked = false;
                    relatedMediaLBBannerRadioButton.Checked = false;
                    relatedMediaLBTitleScreenRadioButton.Checked = false;
                    relatedMediaLBClearLogoRadioButton.Checked = false;
                    relatedMediaLBCartFrontRadioButton.Checked = false;
                    relatedMediaLBCartBackRadioButton.Checked = false;
                    break;
                case RelatedMediaSelection.LBBoxArtBackRecon:
                    relatedMediaRABadgeIconRadioButton.Checked = false;
                    relatedMediaRABoxArtRadioButton.Checked = false;
                    relatedMediaRATitleScreenRadioButton.Checked = false;
                    relatedMediaRAScreenshotRadioButton.Checked = false;

                    relatedMediaLBBoxFrontRadioButton.Checked = false;
                    relatedMediaLBBoxBackRadioButton.Checked = false;
                    relatedMediaLBBox3DRadioButton.Checked = false;
                    relatedMediaLBBoxFrontReconRadioButton.Checked = false;
                    relatedMediaLBBoxBackReconRadioButton.Checked = true;
                    relatedMediaLBBoxFullRadioButton.Checked = false;
                    relatedMediaLBBoxSpineRadioButton.Checked = false;
                    relatedMediaLBBannerRadioButton.Checked = false;
                    relatedMediaLBTitleScreenRadioButton.Checked = false;
                    relatedMediaLBClearLogoRadioButton.Checked = false;
                    relatedMediaLBCartFrontRadioButton.Checked = false;
                    relatedMediaLBCartBackRadioButton.Checked = false;
                    break;
                case RelatedMediaSelection.LBBoxArtFull:
                    relatedMediaRABadgeIconRadioButton.Checked = false;
                    relatedMediaRABoxArtRadioButton.Checked = false;
                    relatedMediaRATitleScreenRadioButton.Checked = false;
                    relatedMediaRAScreenshotRadioButton.Checked = false;

                    relatedMediaLBBoxFrontRadioButton.Checked = false;
                    relatedMediaLBBoxBackRadioButton.Checked = false;
                    relatedMediaLBBox3DRadioButton.Checked = false;
                    relatedMediaLBBoxFrontReconRadioButton.Checked = false;
                    relatedMediaLBBoxBackReconRadioButton.Checked = false;
                    relatedMediaLBBoxFullRadioButton.Checked = true;
                    relatedMediaLBBoxSpineRadioButton.Checked = false;
                    relatedMediaLBBannerRadioButton.Checked = false;
                    relatedMediaLBTitleScreenRadioButton.Checked = false;
                    relatedMediaLBClearLogoRadioButton.Checked = false;
                    relatedMediaLBCartFrontRadioButton.Checked = false;
                    relatedMediaLBCartBackRadioButton.Checked = false;
                    break;
                case RelatedMediaSelection.LBBoxArtSpine:
                    relatedMediaRABadgeIconRadioButton.Checked = false;
                    relatedMediaRABoxArtRadioButton.Checked = false;
                    relatedMediaRATitleScreenRadioButton.Checked = false;
                    relatedMediaRAScreenshotRadioButton.Checked = false;

                    relatedMediaLBBoxFrontRadioButton.Checked = false;
                    relatedMediaLBBoxBackRadioButton.Checked = false;
                    relatedMediaLBBox3DRadioButton.Checked = false;
                    relatedMediaLBBoxFrontReconRadioButton.Checked = false;
                    relatedMediaLBBoxBackReconRadioButton.Checked = false;
                    relatedMediaLBBoxFullRadioButton.Checked = false;
                    relatedMediaLBBoxSpineRadioButton.Checked = true;
                    relatedMediaLBBannerRadioButton.Checked = false;
                    relatedMediaLBTitleScreenRadioButton.Checked = false;
                    relatedMediaLBClearLogoRadioButton.Checked = false;
                    relatedMediaLBCartFrontRadioButton.Checked = false;
                    relatedMediaLBCartBackRadioButton.Checked = false;
                    break;
                case RelatedMediaSelection.LBBanner:
                    relatedMediaRABadgeIconRadioButton.Checked = false;
                    relatedMediaRABoxArtRadioButton.Checked = false;
                    relatedMediaRATitleScreenRadioButton.Checked = false;
                    relatedMediaRAScreenshotRadioButton.Checked = false;

                    relatedMediaLBBoxFrontRadioButton.Checked = false;
                    relatedMediaLBBoxBackRadioButton.Checked = false;
                    relatedMediaLBBox3DRadioButton.Checked = false;
                    relatedMediaLBBoxFrontReconRadioButton.Checked = false;
                    relatedMediaLBBoxBackReconRadioButton.Checked = false;
                    relatedMediaLBBoxFullRadioButton.Checked = false;
                    relatedMediaLBBoxSpineRadioButton.Checked = false;
                    relatedMediaLBBannerRadioButton.Checked = true;
                    relatedMediaLBTitleScreenRadioButton.Checked = false;
                    relatedMediaLBClearLogoRadioButton.Checked = false;
                    relatedMediaLBCartFrontRadioButton.Checked = false;
                    relatedMediaLBCartBackRadioButton.Checked = false;
                    break;
                case RelatedMediaSelection.LBTitleScreen:
                    relatedMediaRABadgeIconRadioButton.Checked = false;
                    relatedMediaRABoxArtRadioButton.Checked = false;
                    relatedMediaRATitleScreenRadioButton.Checked = false;
                    relatedMediaRAScreenshotRadioButton.Checked = false;

                    relatedMediaLBBoxFrontRadioButton.Checked = false;
                    relatedMediaLBBoxBackRadioButton.Checked = false;
                    relatedMediaLBBox3DRadioButton.Checked = false;
                    relatedMediaLBBoxFrontReconRadioButton.Checked = false;
                    relatedMediaLBBoxBackReconRadioButton.Checked = false;
                    relatedMediaLBBoxFullRadioButton.Checked = false;
                    relatedMediaLBBoxSpineRadioButton.Checked = false;
                    relatedMediaLBBannerRadioButton.Checked = false;
                    relatedMediaLBTitleScreenRadioButton.Checked = true;
                    relatedMediaLBClearLogoRadioButton.Checked = false;
                    relatedMediaLBCartFrontRadioButton.Checked = false;
                    relatedMediaLBCartBackRadioButton.Checked = false;
                    break;
                case RelatedMediaSelection.LBClearLogo:
                    relatedMediaRABadgeIconRadioButton.Checked = false;
                    relatedMediaRABoxArtRadioButton.Checked = false;
                    relatedMediaRATitleScreenRadioButton.Checked = false;
                    relatedMediaRAScreenshotRadioButton.Checked = false;

                    relatedMediaLBBoxFrontRadioButton.Checked = false;
                    relatedMediaLBBoxBackRadioButton.Checked = false;
                    relatedMediaLBBox3DRadioButton.Checked = false;
                    relatedMediaLBBoxFrontReconRadioButton.Checked = false;
                    relatedMediaLBBoxBackReconRadioButton.Checked = false;
                    relatedMediaLBBoxFullRadioButton.Checked = false;
                    relatedMediaLBBoxSpineRadioButton.Checked = false;
                    relatedMediaLBBannerRadioButton.Checked = false;
                    relatedMediaLBTitleScreenRadioButton.Checked = false;
                    relatedMediaLBClearLogoRadioButton.Checked = true;
                    relatedMediaLBCartFrontRadioButton.Checked = false;
                    relatedMediaLBCartBackRadioButton.Checked = false;
                    break;
                case RelatedMediaSelection.LBCartFront:
                    relatedMediaRABadgeIconRadioButton.Checked = false;
                    relatedMediaRABoxArtRadioButton.Checked = false;
                    relatedMediaRATitleScreenRadioButton.Checked = false;
                    relatedMediaRAScreenshotRadioButton.Checked = false;

                    relatedMediaLBBoxFrontRadioButton.Checked = false;
                    relatedMediaLBBoxBackRadioButton.Checked = false;
                    relatedMediaLBBox3DRadioButton.Checked = false;
                    relatedMediaLBBoxFrontReconRadioButton.Checked = false;
                    relatedMediaLBBoxBackReconRadioButton.Checked = false;
                    relatedMediaLBBoxFullRadioButton.Checked = false;
                    relatedMediaLBBoxSpineRadioButton.Checked = false;
                    relatedMediaLBBannerRadioButton.Checked = false;
                    relatedMediaLBTitleScreenRadioButton.Checked = false;
                    relatedMediaLBClearLogoRadioButton.Checked = false;
                    relatedMediaLBCartFrontRadioButton.Checked = true;
                    relatedMediaLBCartBackRadioButton.Checked = false;
                    break;
                case RelatedMediaSelection.LBCartBack:
                    relatedMediaRABadgeIconRadioButton.Checked = false;
                    relatedMediaRABoxArtRadioButton.Checked = false;
                    relatedMediaRATitleScreenRadioButton.Checked = false;
                    relatedMediaRAScreenshotRadioButton.Checked = false;

                    relatedMediaLBBoxFrontRadioButton.Checked = false;
                    relatedMediaLBBoxBackRadioButton.Checked = false;
                    relatedMediaLBBox3DRadioButton.Checked = false;
                    relatedMediaLBBoxFrontReconRadioButton.Checked = false;
                    relatedMediaLBBoxBackReconRadioButton.Checked = false;
                    relatedMediaLBBoxFullRadioButton.Checked = false;
                    relatedMediaLBBoxSpineRadioButton.Checked = false;
                    relatedMediaLBBannerRadioButton.Checked = false;
                    relatedMediaLBTitleScreenRadioButton.Checked = false;
                    relatedMediaLBClearLogoRadioButton.Checked = false;
                    relatedMediaLBCartFrontRadioButton.Checked = false;
                    relatedMediaLBCartBackRadioButton.Checked = true;
                    break;
            }

            RelatedMediaController.Instance.SetAllSettings();
        }
        private void UpdateLaunchBoxIntegrationState()
        {
            if (!Directory.Exists(RelatedMediaController.Instance.LaunchBoxFilePath) || (Directory.Exists(RelatedMediaController.Instance.LaunchBoxFilePath) && !File.Exists(RelatedMediaController.Instance.LaunchBoxFilePath + "\\LaunchBox.exe")))
            {
                relatedMediaLBLabel.Enabled = false;
                relatedMediaLBLinePictureBox.Enabled = false;
                relatedMediaLBBoxFrontRadioButton.Enabled = false;
                relatedMediaLBBoxBackRadioButton.Enabled = false;
                relatedMediaLBBox3DRadioButton.Enabled = false;
                relatedMediaLBBoxFrontReconRadioButton.Enabled = false;
                relatedMediaLBBoxBackReconRadioButton.Enabled = false;
                relatedMediaLBBoxFullRadioButton.Enabled = false;
                relatedMediaLBBoxSpineRadioButton.Enabled = false;
                relatedMediaLBBannerRadioButton.Enabled = false;
                relatedMediaLBTitleScreenRadioButton.Enabled = false;
                relatedMediaLBClearLogoRadioButton.Enabled = false;
                relatedMediaLBCartFrontRadioButton.Enabled = false;
                relatedMediaLBCartBackRadioButton.Enabled = false;

                switch (RelatedMediaController.Instance.RelatedMediaSelection)
                {
                    case RelatedMediaSelection.LBBoxArtFront:
                    case RelatedMediaSelection.LBBoxArtBack:
                    case RelatedMediaSelection.LBBoxArt3D:
                    case RelatedMediaSelection.LBBoxArtFrontRecon:
                    case RelatedMediaSelection.LBBoxArtBackRecon:
                    case RelatedMediaSelection.LBBoxArtFull:
                    case RelatedMediaSelection.LBBoxArtSpine:
                    case RelatedMediaSelection.LBBanner:
                    case RelatedMediaSelection.LBTitleScreen:
                    case RelatedMediaSelection.LBClearLogo:
                    case RelatedMediaSelection.LBCartFront:
                    case RelatedMediaSelection.LBCartBack:
                        relatedMediaRABadgeIconRadioButton.Checked = true;

                        RelatedMediaController.Instance.RelatedMediaSelection = RelatedMediaSelection.RABadgeIcon;
                        break;
                }
            }
            else
            {
                relatedMediaLBLabel.Enabled = true;
                relatedMediaLBLinePictureBox.Enabled = true;
                relatedMediaLBBoxFrontRadioButton.Enabled = true;
                relatedMediaLBBoxBackRadioButton.Enabled = true;
                relatedMediaLBBox3DRadioButton.Enabled = true;
                relatedMediaLBBoxFrontReconRadioButton.Enabled = true;
                relatedMediaLBBoxBackReconRadioButton.Enabled = true;
                relatedMediaLBBoxFullRadioButton.Enabled = true;
                relatedMediaLBBoxSpineRadioButton.Enabled = true;
                relatedMediaLBBannerRadioButton.Enabled = true;
                relatedMediaLBTitleScreenRadioButton.Enabled = true;
                relatedMediaLBClearLogoRadioButton.Enabled = true;
                relatedMediaLBCartFrontRadioButton.Enabled = true;
                relatedMediaLBCartBackRadioButton.Enabled = true;
            }
        }
        private void UpdateMediaReferences()
        {
            if (GameInfo != null)
            {
                if (Directory.Exists(Settings.Default.related_media_launchbox_filepath))
                {
                    try
                    {
                        Dictionary<string, DateTime> gameNames = new Dictionary<string, DateTime>();

                        using (XmlReader reader = XmlReader.Create(Settings.Default.related_media_launchbox_filepath + "\\Data\\Platforms\\" + GameInfo.ConsoleName + ".xml"))
                        {
                            string currentGameName = string.Empty;

                            bool inGame = false;
                            bool inName = false;
                            bool inLastPlayed = false;

                            DateTime lastPlayed = DateTime.MinValue;

                            while (reader.Read())
                            {
                                switch (reader.NodeType)
                                {
                                    case XmlNodeType.Element:
                                        if ("Game".Equals(reader.Name))
                                        {
                                            inGame = true;
                                        }
                                        else if ("Title".Equals(reader.Name))
                                        {
                                            inName = true;
                                        }
                                        else if ("LastPlayedDate".Equals(reader.Name))
                                        {
                                            inLastPlayed = true;
                                        }
                                        break;
                                    case XmlNodeType.Text:
                                        if (inGame)
                                        {
                                            if (inName)
                                            {
                                                inName = false;
                                                currentGameName = reader.Value;
                                            }
                                            else if (inLastPlayed)
                                            {
                                                inLastPlayed = false;
                                                lastPlayed = DateTime.Parse(reader.Value);
                                            }
                                        }
                                        break;
                                    case XmlNodeType.EndElement:
                                        if ("Game".Equals(reader.Name))
                                        {
                                            if (!lastPlayed.Equals(DateTime.MinValue))
                                            {
                                                gameNames.Add(currentGameName, lastPlayed);
                                            }

                                            inGame = false;
                                            inName = false;
                                            inLastPlayed = false;

                                            lastPlayed = DateTime.MinValue;
                                        }
                                        break;
                                }
                            }
                        }

                        string highestConfidenceGame = string.Empty;
                        DateTime dateTime = DateTime.MinValue;

                        foreach (string name in gameNames.Keys)
                        {
                            gameNames.TryGetValue(name, out DateTime value);

                            if (value.CompareTo(dateTime) > 0)
                            {
                                highestConfidenceGame = name;
                                dateTime = value;
                            }
                        }

                        if (!string.IsNullOrEmpty(highestConfidenceGame))
                        {
                            highestConfidenceGame = highestConfidenceGame.Replace('\'', '_').Replace(':', '_');

                            string[] boxFrontSubFolders = Directory.Exists(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Box - Front") ? Directory.GetDirectories(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Box - Front") : Array.Empty<string>();
                            string[] boxBackSubFolders = Directory.Exists(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Box - Back") ? Directory.GetDirectories(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Box - Back") : Array.Empty<string>();
                            string[] box3DSubFolders = Directory.Exists(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Box - 3D") ? Directory.GetDirectories(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Box - 3D") : Array.Empty<string>();
                            string[] boxFrontReconSubFolders = Directory.Exists(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Box - Front - Reconstructed") ? Directory.GetDirectories(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Box - Front - Reconstructed") : Array.Empty<string>();
                            string[] boxBackReconSubFolders = Directory.Exists(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Box - Back - Reconstructed") ? Directory.GetDirectories(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Box - Back - Reconstructed") : Array.Empty<string>();
                            string[] boxFullSubFolders = Directory.Exists(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Box - Full") ? Directory.GetDirectories(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Box - Full") : Array.Empty<string>();
                            string[] boxSpineSubFolders = Directory.Exists(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Box - Spine") ? Directory.GetDirectories(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Box - Spine") : Array.Empty<string>();
                            string[] clearLogoSubFolders = Directory.Exists(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Clear Logo") ? Directory.GetDirectories(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Clear Logo") : Array.Empty<string>();
                            string[] screenshotGameTitleSubFolders = Directory.Exists(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Screenshot - Game Title") ? Directory.GetDirectories(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Screenshot - Game Title") : Array.Empty<string>();
                            string[] bannerSubFolders = Directory.Exists(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Banner") ? Directory.GetDirectories(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Banner") : Array.Empty<string>();
                            string[] cartFrontSubFolders = Directory.Exists(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Cart - Front") ? Directory.GetDirectories(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Cart - Front") : Array.Empty<string>();
                            string[] cartBackSubFolders = Directory.Exists(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Cart - Back") ? Directory.GetDirectories(RelatedMediaController.Instance.LaunchBoxFilePath + "\\Images\\" + GameInfo.ConsoleName + "\\Cart - Back") : Array.Empty<string>();

                            string resourceFilePath = RelatedMediaController.Instance.LaunchBoxFilePath.Replace("\\", "/");

                            if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Front/" + highestConfidenceGame + "-01.jpg"))
                            {
                                RelatedMediaController.Instance.LBBoxFrontURI = "Images/" + GameInfo.ConsoleName + "/Box - Front/" + highestConfidenceGame + "-01.jpg";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Front/" + highestConfidenceGame + "-02.jpg"))
                            {
                                RelatedMediaController.Instance.LBBoxFrontURI = "Images/" + GameInfo.ConsoleName + "/Box - Front/" + highestConfidenceGame + "-02.jpg";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Front/" + highestConfidenceGame + "-01.png"))
                            {
                                RelatedMediaController.Instance.LBBoxFrontURI = "Images/" + GameInfo.ConsoleName + "/Box - Front/" + highestConfidenceGame + "-01.png";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Front/" + highestConfidenceGame + "-02.png"))
                            {
                                RelatedMediaController.Instance.LBBoxFrontURI = "Images/" + GameInfo.ConsoleName + "/Box - Front/" + highestConfidenceGame + "-02.png";
                            }
                            else
                            {
                                foreach (string folder in boxFrontSubFolders)
                                {
                                    if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.jpg"))
                                    {
                                        RelatedMediaController.Instance.LBBoxFrontURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.jpg";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.jpg"))
                                    {
                                        RelatedMediaController.Instance.LBBoxFrontURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.jpg";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png"))
                                    {
                                        RelatedMediaController.Instance.LBBoxFrontURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png"))
                                    {
                                        RelatedMediaController.Instance.LBBoxFrontURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png";
                                        break;
                                    }
                                    else
                                    {
                                        RelatedMediaController.Instance.LBBoxFrontURI = "";
                                    }
                                }
                            }

                            if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Back/" + highestConfidenceGame + "-01.jpg"))
                            {
                                RelatedMediaController.Instance.LBBoxBackURI = "Images/" + GameInfo.ConsoleName + "/Box - Back/" + highestConfidenceGame + "-01.jpg";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Back/" + highestConfidenceGame + "-02.jpg"))
                            {
                                RelatedMediaController.Instance.LBBoxBackURI = "Images/" + GameInfo.ConsoleName + "/Box - Back/" + highestConfidenceGame + "-02.jpg";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Back/" + highestConfidenceGame + "-01.png"))
                            {
                                RelatedMediaController.Instance.LBBoxBackURI = "Images/" + GameInfo.ConsoleName + "/Box - Back/" + highestConfidenceGame + "-01.png";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Back/" + highestConfidenceGame + "-02.png"))
                            {
                                RelatedMediaController.Instance.LBBoxBackURI = "Images/" + GameInfo.ConsoleName + "/Box - Back/" + highestConfidenceGame + "-02.png";
                            }
                            else
                            {
                                foreach (string folder in boxBackSubFolders)
                                {
                                    if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.jpg"))
                                    {
                                        RelatedMediaController.Instance.LBBoxBackURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.jpg";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.jpg"))
                                    {
                                        RelatedMediaController.Instance.LBBoxBackURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.jpg";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png"))
                                    {
                                        RelatedMediaController.Instance.LBBoxBackURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png"))
                                    {
                                        RelatedMediaController.Instance.LBBoxBackURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png";
                                        break;
                                    }
                                    else
                                    {
                                        RelatedMediaController.Instance.LBBoxBackURI = "";
                                    }
                                }
                            }

                            if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - 3D/" + highestConfidenceGame + "-01.jpg"))
                            {
                                RelatedMediaController.Instance.LBBox3DURI = "Images/" + GameInfo.ConsoleName + "/Box - 3D/" + highestConfidenceGame + "-01.jpg";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - 3D/" + highestConfidenceGame + "-02.jpg"))
                            {
                                RelatedMediaController.Instance.LBBox3DURI = "Images/" + GameInfo.ConsoleName + "/Box - 3D/" + highestConfidenceGame + "-02.jpg";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - 3D/" + highestConfidenceGame + "-01.png"))
                            {
                                RelatedMediaController.Instance.LBBox3DURI = "Images/" + GameInfo.ConsoleName + "/Box - 3D/" + highestConfidenceGame + "-01.png";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - 3D/" + highestConfidenceGame + "-02.png"))
                            {
                                RelatedMediaController.Instance.LBBox3DURI = "Images/" + GameInfo.ConsoleName + "/Box - 3D/" + highestConfidenceGame + "-02.png";
                            }
                            else
                            {
                                foreach (string folder in box3DSubFolders)
                                {
                                    if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.jpg"))
                                    {
                                        RelatedMediaController.Instance.LBBox3DURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.jpg";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.jpg"))
                                    {
                                        RelatedMediaController.Instance.LBBox3DURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.jpg";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png"))
                                    {
                                        RelatedMediaController.Instance.LBBox3DURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png"))
                                    {
                                        RelatedMediaController.Instance.LBBox3DURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png";
                                        break;
                                    }
                                    else
                                    {
                                        RelatedMediaController.Instance.LBBox3DURI = "";
                                    }
                                }
                            }

                            if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Front - Reconstructed/" + highestConfidenceGame + "-01.jpg"))
                            {
                                RelatedMediaController.Instance.LBBoxFrontReconURI = "Images/" + GameInfo.ConsoleName + "/Box - Front - Reconstructed/" + highestConfidenceGame + "-01.jpg";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Front - Reconstructed/" + highestConfidenceGame + "-02.jpg"))
                            {
                                RelatedMediaController.Instance.LBBoxFrontReconURI = "Images/" + GameInfo.ConsoleName + "/Box - Front - Reconstructed/" + highestConfidenceGame + "-02.jpg";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Front - Reconstructed/" + highestConfidenceGame + "-01.png"))
                            {
                                RelatedMediaController.Instance.LBBoxFrontReconURI = "Images/" + GameInfo.ConsoleName + "/Box - Front - Reconstructed/" + highestConfidenceGame + "-01.png";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Front - Reconstructed/" + highestConfidenceGame + "-02.png"))
                            {
                                RelatedMediaController.Instance.LBBoxFrontReconURI = "Images/" + GameInfo.ConsoleName + "/Box - Front - Reconstructed/" + highestConfidenceGame + "-02.png";
                            }
                            else
                            {
                                foreach (string folder in boxFrontReconSubFolders)
                                {
                                    if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.jpg"))
                                    {
                                        RelatedMediaController.Instance.LBBoxFrontReconURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.jpg";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.jpg"))
                                    {
                                        RelatedMediaController.Instance.LBBoxFrontReconURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.jpg";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png"))
                                    {
                                        RelatedMediaController.Instance.LBBoxFrontReconURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png"))
                                    {
                                        RelatedMediaController.Instance.LBBoxFrontReconURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png";
                                        break;
                                    }
                                    else
                                    {
                                        RelatedMediaController.Instance.LBBoxFrontReconURI = "";
                                    }
                                }
                            }

                            if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Back - Reconstructed/" + highestConfidenceGame + "-01.jpg"))
                            {
                                RelatedMediaController.Instance.LBBoxBackReconURI = "Images/" + GameInfo.ConsoleName + "/Box - Back - Reconstructed/" + highestConfidenceGame + "-01.jpg";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Back - Reconstructed/" + highestConfidenceGame + "-02.jpg"))
                            {
                                RelatedMediaController.Instance.LBBoxBackReconURI = "Images/" + GameInfo.ConsoleName + "/Box - Back - Reconstructed/" + highestConfidenceGame + "-02.jpg";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Back - Reconstructed/" + highestConfidenceGame + "-01.png"))
                            {
                                RelatedMediaController.Instance.LBBoxBackReconURI = "Images/" + GameInfo.ConsoleName + "/Box - Back - Reconstructed/" + highestConfidenceGame + "-01.png";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Back - Reconstructed/" + highestConfidenceGame + "-02.png"))
                            {
                                RelatedMediaController.Instance.LBBoxBackReconURI = "Images/" + GameInfo.ConsoleName + "/Box - Back - Reconstructed/" + highestConfidenceGame + "-02.png";
                            }
                            else
                            {
                                foreach (string folder in boxBackReconSubFolders)
                                {
                                    if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.jpg"))
                                    {
                                        RelatedMediaController.Instance.LBBoxBackReconURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.jpg";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.jpg"))
                                    {
                                        RelatedMediaController.Instance.LBBoxBackReconURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.jpg";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png"))
                                    {
                                        RelatedMediaController.Instance.LBBoxBackReconURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png"))
                                    {
                                        RelatedMediaController.Instance.LBBoxBackReconURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png";
                                        break;
                                    }
                                    else
                                    {
                                        RelatedMediaController.Instance.LBBoxBackReconURI = "";
                                    }
                                }
                            }

                            if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Full/" + highestConfidenceGame + "-01.jpg"))
                            {
                                RelatedMediaController.Instance.LBBoxFullURI = "Images/" + GameInfo.ConsoleName + "/Box - Full/" + highestConfidenceGame + "-01.jpg";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Full/" + highestConfidenceGame + "-02.jpg"))
                            {
                                RelatedMediaController.Instance.LBBoxFullURI = "Images/" + GameInfo.ConsoleName + "/Box - Full/" + highestConfidenceGame + "-02.jpg";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Full/" + highestConfidenceGame + "-01.png"))
                            {
                                RelatedMediaController.Instance.LBBoxFullURI = "Images/" + GameInfo.ConsoleName + "/Box - Full/" + highestConfidenceGame + "-01.png";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Full/" + highestConfidenceGame + "-02.png"))
                            {
                                RelatedMediaController.Instance.LBBoxFullURI = "Images/" + GameInfo.ConsoleName + "/Box - Full/" + highestConfidenceGame + "-02.png";
                            }
                            else
                            {
                                foreach (string folder in boxFullSubFolders)
                                {
                                    if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.jpg"))
                                    {
                                        RelatedMediaController.Instance.LBBoxFrontReconURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.jpg";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.jpg"))
                                    {
                                        RelatedMediaController.Instance.LBBoxFrontReconURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.jpg";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png"))
                                    {
                                        RelatedMediaController.Instance.LBBoxFrontReconURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png"))
                                    {
                                        RelatedMediaController.Instance.LBBoxFrontReconURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png";
                                        break;
                                    }
                                    else
                                    {
                                        RelatedMediaController.Instance.LBBoxFrontReconURI = "";
                                    }
                                }
                            }

                            if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Spine/" + highestConfidenceGame + "-01.jpg"))
                            {
                                RelatedMediaController.Instance.LBBoxSpineURI = "Images/" + GameInfo.ConsoleName + "/Box - Spine/" + highestConfidenceGame + "-01.jpg";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Spine/" + highestConfidenceGame + "-02.jpg"))
                            {
                                RelatedMediaController.Instance.LBBoxSpineURI = "Images/" + GameInfo.ConsoleName + "/Box - Spine/" + highestConfidenceGame + "-02.jpg";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Spine/" + highestConfidenceGame + "-01.png"))
                            {
                                RelatedMediaController.Instance.LBBoxSpineURI = "Images/" + GameInfo.ConsoleName + "/Box - Spine/" + highestConfidenceGame + "-01.png";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Box - Spine/" + highestConfidenceGame + "-02.png"))
                            {
                                RelatedMediaController.Instance.LBBoxSpineURI = "Images/" + GameInfo.ConsoleName + "/Box - Spine/" + highestConfidenceGame + "-02.png";
                            }
                            else
                            {
                                foreach (string folder in boxSpineSubFolders)
                                {
                                    if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.jpg"))
                                    {
                                        RelatedMediaController.Instance.LBBoxSpineURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.jpg";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.jpg"))
                                    {
                                        RelatedMediaController.Instance.LBBoxSpineURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.jpg";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png"))
                                    {
                                        RelatedMediaController.Instance.LBBoxSpineURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png"))
                                    {
                                        RelatedMediaController.Instance.LBBoxSpineURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png";
                                        break;
                                    }
                                    else
                                    {
                                        RelatedMediaController.Instance.LBBoxSpineURI = "";
                                    }
                                }
                            }

                            if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Clear Logo/" + highestConfidenceGame + "-01.png"))
                            {
                                RelatedMediaController.Instance.LBClearLogoURI = "Images/" + GameInfo.ConsoleName + "/Clear Logo/" + highestConfidenceGame + "-01.png";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Clear Logo/" + highestConfidenceGame + "-02.png"))
                            {
                                RelatedMediaController.Instance.LBClearLogoURI = "Images/" + GameInfo.ConsoleName + "/Clear Logo/" + highestConfidenceGame + "-02.png";
                            }
                            else
                            {
                                foreach (string folder in clearLogoSubFolders)
                                {
                                    if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png"))
                                    {
                                        RelatedMediaController.Instance.LBClearLogoURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png"))
                                    {
                                        RelatedMediaController.Instance.LBClearLogoURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png";
                                        break;
                                    }
                                    else
                                    {
                                        RelatedMediaController.Instance.LBClearLogoURI = "";
                                    }
                                }
                            }

                            if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Screenshot - Game Title/" + highestConfidenceGame + "-01.jpg"))
                            {
                                RelatedMediaController.Instance.LBTitleSceenURI = "Images/" + GameInfo.ConsoleName + "/Screenshot - Game Title/" + highestConfidenceGame + "-01.jpg";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Screenshot - Game Title/" + highestConfidenceGame + "-02.jpg"))
                            {
                                RelatedMediaController.Instance.LBTitleSceenURI = "Images/" + GameInfo.ConsoleName + "/Screenshot - Game Title/" + highestConfidenceGame + "-02.jpg";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Screenshot - Game Title/" + highestConfidenceGame + "-01.png"))
                            {
                                RelatedMediaController.Instance.LBTitleSceenURI = "Images/" + GameInfo.ConsoleName + "/Screenshot - Game Title/" + highestConfidenceGame + "-01.png";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Screenshot - Game Title/" + highestConfidenceGame + "-02.png"))
                            {
                                RelatedMediaController.Instance.LBTitleSceenURI = "Images/" + GameInfo.ConsoleName + "/Screenshot - Game Title/" + highestConfidenceGame + "-02.png";
                            }
                            else
                            {
                                foreach (string folder in screenshotGameTitleSubFolders)
                                {
                                    if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.jpg"))
                                    {
                                        RelatedMediaController.Instance.LBTitleSceenURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.jpg";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.jpg"))
                                    {
                                        RelatedMediaController.Instance.LBTitleSceenURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.jpg";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png"))
                                    {
                                        RelatedMediaController.Instance.LBTitleSceenURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png"))
                                    {
                                        RelatedMediaController.Instance.LBTitleSceenURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png";
                                        break;
                                    }
                                    else
                                    {
                                        RelatedMediaController.Instance.LBTitleSceenURI = "";
                                    }
                                }
                            }

                            if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Banner/" + highestConfidenceGame + "-01.jpg"))
                            {
                                RelatedMediaController.Instance.LBBannerURI = "Images/" + GameInfo.ConsoleName + "/Banner/" + highestConfidenceGame + "-01.jpg";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Banner/" + highestConfidenceGame + "-02.jpg"))
                            {
                                RelatedMediaController.Instance.LBBannerURI = "Images/" + GameInfo.ConsoleName + "/Banner/" + highestConfidenceGame + "-02.jpg";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Banner/" + highestConfidenceGame + "-01.png"))
                            {
                                RelatedMediaController.Instance.LBBannerURI = "Images/" + GameInfo.ConsoleName + "/Banner/" + highestConfidenceGame + "-01.png";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Banner/" + highestConfidenceGame + "-02.png"))
                            {
                                RelatedMediaController.Instance.LBBannerURI = "Images/" + GameInfo.ConsoleName + "/Banner/" + highestConfidenceGame + "-02.png";
                            }
                            else
                            {
                                foreach (string folder in bannerSubFolders)
                                {
                                    if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.jpg"))
                                    {
                                        RelatedMediaController.Instance.LBBannerURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.jpg";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.jpg"))
                                    {
                                        RelatedMediaController.Instance.LBBannerURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.jpg";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png"))
                                    {
                                        RelatedMediaController.Instance.LBTitleSceenURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png"))
                                    {
                                        RelatedMediaController.Instance.LBBannerURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png";
                                        break;
                                    }
                                    else
                                    {
                                        RelatedMediaController.Instance.LBBannerURI = "";
                                    }
                                }
                            }

                            if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Cart - Front/" + highestConfidenceGame + "-01.jpg"))
                            {
                                RelatedMediaController.Instance.LBCartFrontURI = "Images/" + GameInfo.ConsoleName + "/Cart - Front/" + highestConfidenceGame + "-01.jpg";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Cart - Front/" + highestConfidenceGame + "-02.jpg"))
                            {
                                RelatedMediaController.Instance.LBCartFrontURI = "Images/" + GameInfo.ConsoleName + "/Cart - Front/" + highestConfidenceGame + "-02.jpg";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Cart - Front/" + highestConfidenceGame + "-01.png"))
                            {
                                RelatedMediaController.Instance.LBCartFrontURI = "Images/" + GameInfo.ConsoleName + "/Cart - Front/" + highestConfidenceGame + "-01.png";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Cart - Front/" + highestConfidenceGame + "-02.png"))
                            {
                                RelatedMediaController.Instance.LBCartFrontURI = "Images/" + GameInfo.ConsoleName + "/Cart - Front/" + highestConfidenceGame + "-02.png";
                            }
                            else
                            {
                                foreach (string folder in cartFrontSubFolders)
                                {
                                    if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.jpg"))
                                    {
                                        RelatedMediaController.Instance.LBCartFrontURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.jpg";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.jpg"))
                                    {
                                        RelatedMediaController.Instance.LBCartFrontURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.jpg";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png"))
                                    {
                                        RelatedMediaController.Instance.LBCartFrontURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png"))
                                    {
                                        RelatedMediaController.Instance.LBCartFrontURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png";
                                        break;
                                    }
                                    else
                                    {
                                        RelatedMediaController.Instance.LBCartFrontURI = "";
                                    }
                                }
                            }

                            if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Cart - Back/" + highestConfidenceGame + "-01.jpg"))
                            {
                                RelatedMediaController.Instance.LBCartBackURI = "Images/" + GameInfo.ConsoleName + "/Cart - Back/" + highestConfidenceGame + "-01.jpg";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Cart - Back/" + highestConfidenceGame + "-02.jpg"))
                            {
                                RelatedMediaController.Instance.LBCartBackURI = "Images/" + GameInfo.ConsoleName + "/Cart - Back/" + highestConfidenceGame + "-02.jpg";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Cart - Back/" + highestConfidenceGame + "-01.png"))
                            {
                                RelatedMediaController.Instance.LBCartBackURI = "Images/" + GameInfo.ConsoleName + "/Cart - Back/" + highestConfidenceGame + "-01.png";
                            }
                            else if (File.Exists(resourceFilePath + "/Images/" + GameInfo.ConsoleName + "/Cart - Back/" + highestConfidenceGame + "-02.png"))
                            {
                                RelatedMediaController.Instance.LBCartBackURI = "Images/" + GameInfo.ConsoleName + "/Cart - Back/" + highestConfidenceGame + "-02.png";
                            }
                            else
                            {
                                foreach (string folder in cartBackSubFolders)
                                {
                                    if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.jpg"))
                                    {
                                        RelatedMediaController.Instance.LBCartBackURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.jpg";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.jpg"))
                                    {
                                        RelatedMediaController.Instance.LBCartBackURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.jpg";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png"))
                                    {
                                        RelatedMediaController.Instance.LBCartBackURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-01.png";
                                        break;
                                    }
                                    else if (File.Exists(folder.Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png"))
                                    {
                                        RelatedMediaController.Instance.LBCartBackURI = folder.Substring(RelatedMediaController.Instance.LaunchBoxFilePath.Length).Replace("\\", "/") + "/" + highestConfidenceGame + "-02.png";
                                        break;
                                    }
                                    else
                                    {
                                        RelatedMediaController.Instance.LBCartBackURI = "";
                                    }
                                }
                            }
                        }
                        else
                        {
                            RelatedMediaController.Instance.LBBoxFrontURI = string.Empty;
                            RelatedMediaController.Instance.LBBoxBackURI = string.Empty;
                            RelatedMediaController.Instance.LBBox3DURI = string.Empty;
                            RelatedMediaController.Instance.LBBoxFrontReconURI = string.Empty;
                            RelatedMediaController.Instance.LBBoxBackReconURI = string.Empty;
                            RelatedMediaController.Instance.LBBoxFullURI = string.Empty;
                            RelatedMediaController.Instance.LBBoxSpineURI = string.Empty;
                            RelatedMediaController.Instance.LBBannerURI = string.Empty;
                            RelatedMediaController.Instance.LBTitleSceenURI = string.Empty;
                            RelatedMediaController.Instance.LBClearLogoURI = string.Empty;
                            RelatedMediaController.Instance.LBCartFrontURI = string.Empty;
                            RelatedMediaController.Instance.LBCartBackURI = string.Empty;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }
            RelatedMediaController.Instance.SetAllSettings();
        }
        private void AdvancedCheckBox_Click(object sender, EventArgs e)
        {
            if (!IsLoading)
            {
                IsLoading = true;
                CheckBox checkBox = (CheckBox)sender;

                switch (checkBox.Name)
                {
                    case "focusAdvancedCheckBox":
                        FocusController.Instance.AdvancedSettingsEnabled = checkBox.Checked;
                        break;
                    case "alertsAdvancedCheckBox":
                        AlertsController.Instance.AdvancedSettingsEnabled = checkBox.Checked;
                        break;
                    case "userInfoAdvancedCheckBox":
                        UserInfoController.Instance.AdvancedSettingsEnabled = checkBox.Checked;
                        break;
                    case "gameInfoAdvancedCheckBox":
                        GameInfoController.Instance.AdvancedSettingsEnabled = checkBox.Checked;
                        break;
                    case "gameProgressAdvancedCheckBox":
                        GameProgressController.Instance.AdvancedSettingsEnabled = checkBox.Checked;
                        break;
                    case "recentAchievementsAdvancedCheckBox":
                        RecentAchievementsController.Instance.AdvancedSettingsEnabled = checkBox.Checked;
                        break;
                }

                UpdateAdvancedSettings();

                IsLoading = false;
            }
        }
        private void UpdateAdvancedSettings()
        {
            if (FocusController.Instance.AdvancedSettingsEnabled)
            {
                focusTitleLabel.Text = "Title";
                focusTitleOutlineLabel.Text = "Title OutlineColor";

                SetFontFamilyBox(focusTitleFontComboBox, FocusController.Instance.TitleFontFamily);

                focusTitleOutlineCheckBox.Checked = FocusController.Instance.TitleOutlineEnabled;

                focusTitleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.TitleColor);
                focusTitleFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.TitleOutlineColor);

                focusDescriptionPanel.Enabled = true;
                focusPointsPanel.Enabled = true;
                focusLinePanel.Enabled = true;
                focusDescriptionOutlinePanel.Enabled = true;
                focusPointsOutlinePanel.Enabled = true;
                focusLineOutlinePanel.Enabled = true;
            }
            else
            {
                focusTitleLabel.Text = "Font";
                focusTitleOutlineLabel.Text = "Font OutlineColor";

                SetFontFamilyBox(focusTitleFontComboBox, FocusController.Instance.SimpleFontFamily);

                focusTitleOutlineCheckBox.Checked = FocusController.Instance.SimpleFontOutlineEnabled;

                focusTitleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.SimpleFontColor);
                focusTitleFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.SimpleFontOutlineColor);

                focusDescriptionPanel.Enabled = false;
                focusPointsPanel.Enabled = false;
                focusLinePanel.Enabled = false;
                focusDescriptionOutlinePanel.Enabled = false;
                focusPointsOutlinePanel.Enabled = false;
                focusLineOutlinePanel.Enabled = false;
            }

            if (AlertsController.Instance.AdvancedSettingsEnabled)
            {
                alertsTitleLabel.Text = "Title";
                alertsTitleOutlineLabel.Text = "Title OutlineColor";

                SetFontFamilyBox(alertsTitleFontComboBox, AlertsController.Instance.TitleFontFamily);

                alertsTitleOutlineCheckBox.Checked = AlertsController.Instance.TitleOutlineEnabled;

                alertsTitleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.TitleColor);
                alertsTitleFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.TitleOutlineColor);

                alertsDescriptionPanel.Enabled = true;
                alertsPointsPanel.Enabled = true;
                alertsLinePanel.Enabled = true;
                alertsDescriptionOutlinePanel.Enabled = true;
                alertsPointsOutlinePanel.Enabled = true;
                alertsLineOutlinePanel.Enabled = true;
            }
            else
            {
                alertsTitleLabel.Text = "Font";
                alertsTitleOutlineLabel.Text = "Font OutlineColor";

                SetFontFamilyBox(alertsTitleFontComboBox, AlertsController.Instance.SimpleFontFamily);

                alertsTitleOutlineCheckBox.Checked = AlertsController.Instance.SimpleFontOutlineEnabled;

                alertsTitleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.SimpleFontColor);
                alertsTitleFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.SimpleFontOutlineColor);

                alertsDescriptionPanel.Enabled = false;
                alertsPointsPanel.Enabled = false;
                alertsLinePanel.Enabled = false;
                alertsDescriptionOutlinePanel.Enabled = false;
                alertsPointsOutlinePanel.Enabled = false;
                alertsLineOutlinePanel.Enabled = false;
            }

            if (UserInfoController.Instance.AdvancedSettingsEnabled)
            {
                userInfoNamesLabel.Text = "Names";
                userInfoNamesOutlineLabel.Text = "Names OutlineColor";

                SetFontFamilyBox(userInfoNamesFontComboBox, UserInfoController.Instance.NameFontFamily);

                userInfoNamesOutlineCheckBox.Checked = UserInfoController.Instance.NameOutlineEnabled;

                userInfoNamesFontColorPictureBox.BackColor = ColorTranslator.FromHtml(UserInfoController.Instance.NameColor);
                userInfoNamesFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(UserInfoController.Instance.NameOutlineColor);

                userInfoValuesPanel.Enabled = true;
                userInfoValuesOutlinePanel.Enabled = true;
            }
            else
            {
                userInfoNamesLabel.Text = "Font";
                userInfoNamesOutlineLabel.Text = "Font OutlineColor";

                SetFontFamilyBox(userInfoNamesFontComboBox, UserInfoController.Instance.SimpleFontFamily);

                userInfoNamesOutlineCheckBox.Checked = UserInfoController.Instance.SimpleFontOutlineEnabled;

                userInfoNamesFontColorPictureBox.BackColor = ColorTranslator.FromHtml(UserInfoController.Instance.SimpleFontColor);
                userInfoNamesFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(UserInfoController.Instance.SimpleFontOutlineColor);

                userInfoValuesPanel.Enabled = false;
                userInfoValuesOutlinePanel.Enabled = false;
            }

            if (GameInfoController.Instance.AdvancedSettingsEnabled)
            {
                gameInfoNamesLabel.Text = "Names";
                gameInfoNamesOutlineLabel.Text = "Names OutlineColor";

                SetFontFamilyBox(gameInfoNamesFontComboBox, GameInfoController.Instance.NameFontFamily);

                gameInfoNamesOutlineCheckBox.Checked = GameInfoController.Instance.NameOutlineEnabled;

                gameInfoNamesFontColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoController.Instance.NameColor);
                gameInfoNamesFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoController.Instance.NameOutlineColor);

                gameInfoValuesPanel.Enabled = true;
                gameInfoValuesOutlinePanel.Enabled = true;
            }
            else
            {
                gameInfoNamesLabel.Text = "Font";
                gameInfoNamesOutlineLabel.Text = "Font OutlineColor";

                SetFontFamilyBox(gameInfoNamesFontComboBox, GameInfoController.Instance.SimpleFontFamily);

                gameInfoNamesOutlineCheckBox.Checked = GameInfoController.Instance.SimpleFontOutlineEnabled;

                gameInfoNamesFontColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoController.Instance.SimpleFontColor);
                gameInfoNamesFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoController.Instance.SimpleFontOutlineColor);

                gameInfoValuesPanel.Enabled = false;
                gameInfoValuesOutlinePanel.Enabled = false;
            }

            if (GameProgressController.Instance.AdvancedSettingsEnabled)
            {
                gameProgressNamesLabel.Text = "Names";
                gameProgressNamesOutlineLabel.Text = "Names OutlineColor";

                SetFontFamilyBox(gameProgressNamesFontComboBox, GameProgressController.Instance.NameFontFamily);

                gameProgressNamesOutlineCheckBox.Checked = GameProgressController.Instance.NameOutlineEnabled;

                gameProgressNamesFontColorPictureBox.BackColor = ColorTranslator.FromHtml(GameProgressController.Instance.NameColor);
                gameProgressNamesFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(GameProgressController.Instance.NameOutlineColor);

                gameProgressValuesPanel.Enabled = true;
                gameProgressValuesOutlinePanel.Enabled = true;
            }
            else
            {
                gameProgressNamesLabel.Text = "Font";
                gameProgressNamesOutlineLabel.Text = "Font OutlineColor";

                SetFontFamilyBox(gameProgressNamesFontComboBox, GameProgressController.Instance.SimpleFontFamily);

                gameProgressNamesOutlineCheckBox.Checked = GameProgressController.Instance.SimpleFontOutlineEnabled;

                gameProgressNamesFontColorPictureBox.BackColor = ColorTranslator.FromHtml(GameProgressController.Instance.SimpleFontColor);
                gameProgressNamesFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(GameProgressController.Instance.SimpleFontOutlineColor);

                gameProgressValuesPanel.Enabled = false;
                gameProgressValuesOutlinePanel.Enabled = false;
            }

            if (RecentAchievementsController.Instance.AdvancedSettingsEnabled)
            {
                recentAchievementsTitleLabel.Text = "Title";
                recentAchievementsTitleOutlineLabel.Text = "Title OutlineColor";

                SetFontFamilyBox(recentAchievementsTitleFontComboBox, RecentAchievementsController.Instance.TitleFontFamily);

                recentAchievementsTitleFontOutlineCheckBox.Checked = RecentAchievementsController.Instance.TitleOutlineEnabled;

                recentAchievementsTitleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.TitleColor);
                recentAchievementsTitleFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.TitleOutlineColor);

                recentAchievementsDescriptionPanel.Enabled = true;
                recentAchievementsPointsPanel.Enabled = true;
                recentAchievementsLinePanel.Enabled = true;
                recentAchievementsDescriptionOutlinePanel.Enabled = true;
                recentAchievementsPointsOutlinePanel.Enabled = true;
                recentAchievementsLineOutlinePanel.Enabled = true;
            }
            else
            {
                recentAchievementsTitleLabel.Text = "Font";
                recentAchievementsTitleOutlineLabel.Text = "Font OutlineColor";

                SetFontFamilyBox(recentAchievementsTitleFontComboBox, RecentAchievementsController.Instance.SimpleFontFamily);

                recentAchievementsTitleFontOutlineCheckBox.Checked = RecentAchievementsController.Instance.SimpleFontOutlineEnabled;

                recentAchievementsTitleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.SimpleFontColor);
                recentAchievementsTitleFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.SimpleFontOutlineColor);

                recentAchievementsDescriptionPanel.Enabled = false;
                recentAchievementsPointsPanel.Enabled = false;
                recentAchievementsLinePanel.Enabled = false;
                recentAchievementsDescriptionOutlinePanel.Enabled = false;
                recentAchievementsPointsOutlinePanel.Enabled = false;
                recentAchievementsLineOutlinePanel.Enabled = false;
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
                    userInfoRatioTextBox.Text = "Retro Ratio";
                    break;
                case "gameProgressDefaultButton":
                    gameProgressRatioTextBox.Text = "Retro Ratio";
                    gameProgressPointsTextBox.Text = "Points";
                    gameProgressTruePointsTextBox.Text = "True Points";
                    gameProgressAchievementsTextBox.Text = "Achievements";
                    gameProgressCompletedTextBox.Text = "Completed";
                    break;
            }
        }
        private void OverrideTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!IsLoading)
            {
                IsLoading = true;
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
                        GameProgressController.Instance.AchievementsName = textBox.Text;
                        break;
                    case "gameProgressPointsTextBox":
                        GameProgressController.Instance.PointsName = textBox.Text;
                        break;
                    case "gameProgressTruePointsTextBox":
                        GameProgressController.Instance.TruePointsName = textBox.Text;
                        break;
                    case "gameProgressCompletedTextBox":
                        GameProgressController.Instance.CompletedName = textBox.Text;
                        break;
                    case "gameProgressRatioTextBox":
                        GameProgressController.Instance.RatioName = textBox.Text;
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

                IsLoading = false;
            }
        }
        private void BrowserSensitiveControl_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            switch (control.Name)
            {
                case "userProfilePictureBox":
                    System.Diagnostics.Process.Start("https://retroachievements.org/User/" + UserSummary.UserName);
                    break;
                case "gameInfoPictureBox":
                    System.Diagnostics.Process.Start("https://retroachievements.org/game/" + GameInfo.Id);
                    break;
                case "focusAchievementPictureBox":
                case "focusAchievementTitleLabel":
                    if (CurrentlyViewingAchievement != null)
                    {
                        System.Diagnostics.Process.Start("https://retroachievements.org/achievement/" + CurrentlyViewingAchievement.Id);
                    }
                    break;
                case "rssFeedListView":
                    ListView listView = (ListView)sender;

                    if (listView.SelectedItems.Count > 0)
                    {
                        if (listView.SelectedItems[0].SubItems[0].Text.Contains("[FORUM] ") || listView.SelectedItems[0].SubItems[0].Text.Contains("[CHEEVO] "))
                        {
                            System.Diagnostics.Process.Start(listView.SelectedItems[0].SubItems[3].Text);
                        }
                        else
                        {
                            webBrowser1.DocumentText = string.Format(Constants.RETRO_ACHIEVEMENTS_RSS_NEWS_HTML, listView.SelectedItems[0].SubItems[2].Text);
                        }
                    }
                    break;
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

            webBrowser1.DocumentText = string.Format(Constants.RETRO_ACHIEVEMENTS_RSS_NEWS_HTML, "");

            usernameTextBox.Text = Settings.Default.ra_username;
            apiKeyTextBox.Text = Settings.Default.ra_key;

            userInfoRankTextBox.Text = UserInfoController.Instance.RankName;
            userInfoPointsTextBox.Text = UserInfoController.Instance.PointsName;
            userInfoTruePointsTextBox.Text = UserInfoController.Instance.TruePointsName;
            userInfoRatioTextBox.Text = UserInfoController.Instance.RatioName;

            gameInfoTitleTextBox.Text = GameInfoController.Instance.TitleName;
            gameInfoDeveloperTextBox.Text = GameInfoController.Instance.DeveloperName;
            gameInfoPublisherTextBox.Text = GameInfoController.Instance.PublisherName;
            gameInfoConsoleTextBox.Text = GameInfoController.Instance.ConsoleName;
            gameInfoGenreTextBox.Text = GameInfoController.Instance.GenreName;
            gameInfoReleaseDateTextBox.Text = GameInfoController.Instance.ReleasedDateName;

            gameProgressAchievementsTextBox.Text = GameProgressController.Instance.AchievementsName;
            gameProgressPointsTextBox.Text = GameProgressController.Instance.PointsName;
            gameProgressTruePointsTextBox.Text = GameProgressController.Instance.TruePointsName;
            gameProgressRatioTextBox.Text = GameProgressController.Instance.RatioName;
            gameProgressCompletedTextBox.Text = GameProgressController.Instance.CompletedName;

            /*
             * Auto-Launch/Starting
             */
            autoStartCheckbox.Checked = Settings.Default.auto_start_checked;

            focusAutoOpenWindowCheckBox.Checked = FocusController.Instance.AutoLaunch;
            alertsAutoOpenWindowCheckbox.Checked = AlertsController.Instance.AutoLaunch;
            userInfoAutoOpenWindowCheckbox.Checked = UserInfoController.Instance.AutoLaunch;
            gameInfoAutoOpenWindowCheckbox.Checked = GameInfoController.Instance.AutoLaunch;
            gameProgressAutoOpenWindowCheckbox.Checked = GameProgressController.Instance.AutoLaunch;
            recentAchievementsAutoOpenWindowCheckbox.Checked = RecentAchievementsController.Instance.AutoLaunch;
            achievementListAutoOpenWindowCheckbox.Checked = AchievementListController.Instance.AutoLaunch;
            relatedMediaAutoOpenWindowCheckbox.Checked = RelatedMediaController.Instance.AutoLaunch;

            /*
             * Window Background Color
             */
            focusBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.WindowBackgroundColor);
            alertsBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.WindowBackgroundColor);
            userInfoBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(UserInfoController.Instance.WindowBackgroundColor);
            gameInfoBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoController.Instance.WindowBackgroundColor);
            gameProgressBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(GameProgressController.Instance.WindowBackgroundColor);
            recentAchievementsBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.WindowBackgroundColor);
            achievementListBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(AchievementListController.Instance.WindowBackgroundColor);
            relatedMediaBackgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(RelatedMediaController.Instance.WindowBackgroundColor);

            /*
             * Border Background Color
             */
            focusBorderColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.BorderBackgroundColor);
            alertsBorderColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.BorderBackgroundColor);
            recentAchievementsBorderColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.BorderBackgroundColor);

            /*
             * Border Enabled
             */
            focusBorderCheckBox.Checked = FocusController.Instance.BorderEnabled;
            alertsBorderCheckBox.Checked = AlertsController.Instance.BorderEnabled;
            recentAchievementsBorderCheckBox.Checked = RecentAchievementsController.Instance.BorderEnabled;

            /*
             * Advanced Settings
             */
            focusAdvancedCheckBox.Checked = FocusController.Instance.AdvancedSettingsEnabled;
            alertsAdvancedCheckBox.Checked = AlertsController.Instance.AdvancedSettingsEnabled;
            userInfoAdvancedCheckBox.Checked = UserInfoController.Instance.AdvancedSettingsEnabled;
            gameInfoAdvancedCheckBox.Checked = GameInfoController.Instance.AdvancedSettingsEnabled;
            gameProgressAdvancedCheckBox.Checked = GameProgressController.Instance.AdvancedSettingsEnabled;
            recentAchievementsAdvancedCheckBox.Checked = RecentAchievementsController.Instance.AdvancedSettingsEnabled;

            userInfoRankCheckBox.Checked = UserInfoController.Instance.RankEnabled;
            userInfoPointsCheckBox.Checked = UserInfoController.Instance.PointsEnabled;
            userInfoTruePointsCheckBox.Checked = UserInfoController.Instance.TruePointsEnabled;
            userInfoRatioCheckBox.Checked = UserInfoController.Instance.RatioEnabled;

            gameInfoTitleCheckBox.Checked = GameInfoController.Instance.TitleEnabled;
            gameInfoDeveloperCheckBox.Checked = GameInfoController.Instance.DeveloperEnabled;
            gameInfoPublisherCheckBox.Checked = GameInfoController.Instance.PublisherEnabled;
            gameInfoConsoleCheckBox.Checked = GameInfoController.Instance.ConsoleEnabled;
            gameInfoGenreCheckBox.Checked = GameInfoController.Instance.GenreEnabled;
            gameInfoReleasedCheckBox.Checked = GameInfoController.Instance.ReleasedDateEnabled;

            gameProgressAchievementsCheckBox.Checked = GameProgressController.Instance.AchievementsEnabled;
            gameProgressPointsCheckBox.Checked = GameProgressController.Instance.PointsEnabled;
            gameProgressTruePointsCheckBox.Checked = GameProgressController.Instance.TruePointsEnabled;
            gameProgressCompletedCheckBox.Checked = GameProgressController.Instance.CompletedEnabled;
            gameProgressRatioCheckBox.Checked = GameProgressController.Instance.RatioEnabled;

            /*
             * Set Font Family ComboBoxes
             */
            SetFontFamilyBox(focusTitleFontComboBox, FocusController.Instance.AdvancedSettingsEnabled ? FocusController.Instance.TitleFontFamily : FocusController.Instance.SimpleFontFamily);
            SetFontFamilyBox(focusDescriptionFontComboBox, FocusController.Instance.DescriptionFontFamily);
            SetFontFamilyBox(focusPointsFontComboBox, FocusController.Instance.PointsFontFamily);

            SetFontFamilyBox(alertsTitleFontComboBox, AlertsController.Instance.AdvancedSettingsEnabled ? AlertsController.Instance.TitleFontFamily : AlertsController.Instance.SimpleFontFamily);
            SetFontFamilyBox(alertsDescriptionFontComboBox, AlertsController.Instance.DescriptionFontFamily);
            SetFontFamilyBox(alertsPointsFontComboBox, AlertsController.Instance.PointsFontFamily);

            SetFontFamilyBox(userInfoNamesFontComboBox, UserInfoController.Instance.AdvancedSettingsEnabled ? UserInfoController.Instance.NameFontFamily : UserInfoController.Instance.SimpleFontFamily);
            SetFontFamilyBox(userInfoValuesFontComboBox, UserInfoController.Instance.ValueFontFamily);

            SetFontFamilyBox(gameInfoNamesFontComboBox, GameInfoController.Instance.AdvancedSettingsEnabled ? GameInfoController.Instance.NameFontFamily : GameInfoController.Instance.SimpleFontFamily);
            SetFontFamilyBox(gameInfoValuesFontComboBox, GameInfoController.Instance.ValueFontFamily);

            SetFontFamilyBox(gameProgressNamesFontComboBox, GameProgressController.Instance.AdvancedSettingsEnabled ? GameProgressController.Instance.NameFontFamily : GameProgressController.Instance.SimpleFontFamily);
            SetFontFamilyBox(gameProgressValuesFontComboBox, GameProgressController.Instance.ValueFontFamily);

            SetFontFamilyBox(recentAchievementsTitleFontComboBox, RecentAchievementsController.Instance.AdvancedSettingsEnabled ? RecentAchievementsController.Instance.TitleFontFamily : RecentAchievementsController.Instance.SimpleFontFamily);
            SetFontFamilyBox(recentAchievementsDescriptionFontComboBox, RecentAchievementsController.Instance.DateFontFamily);
            SetFontFamilyBox(recentAchievementsPointsFontComboBox, RecentAchievementsController.Instance.PointsFontFamily);

            /*
             * Font & Outline Enablement
             */
            focusTitleOutlineCheckBox.Checked = FocusController.Instance.AdvancedSettingsEnabled ? FocusController.Instance.TitleOutlineEnabled : FocusController.Instance.SimpleFontOutlineEnabled;
            focusDescriptionOutlineCheckBox.Checked = FocusController.Instance.DescriptionOutlineEnabled;
            focusPointsOutlineCheckBox.Checked = FocusController.Instance.PointsOutlineEnabled;
            focusLineOutlineCheckBox.Checked = FocusController.Instance.LineOutlineEnabled;

            alertsTitleOutlineCheckBox.Checked = AlertsController.Instance.AdvancedSettingsEnabled ? AlertsController.Instance.TitleOutlineEnabled : AlertsController.Instance.SimpleFontOutlineEnabled;
            alertsDescriptionOutlineCheckBox.Checked = AlertsController.Instance.DescriptionOutlineEnabled;
            alertsPointsOutlineCheckBox.Checked = AlertsController.Instance.PointsOutlineEnabled;
            alertsLineOutlineCheckBox.Checked = AlertsController.Instance.LineOutlineEnabled;

            gameInfoNamesOutlineCheckBox.Checked = GameInfoController.Instance.AdvancedSettingsEnabled ? GameInfoController.Instance.NameOutlineEnabled : GameInfoController.Instance.SimpleFontOutlineEnabled;
            gameInfoValuesOutlineCheckBox.Checked = GameInfoController.Instance.ValueOutlineEnabled;

            gameProgressNamesOutlineCheckBox.Checked = GameProgressController.Instance.AdvancedSettingsEnabled ? GameProgressController.Instance.NameOutlineEnabled : GameProgressController.Instance.SimpleFontOutlineEnabled;
            gameProgressValuesOutlineCheckBox.Checked = GameProgressController.Instance.ValueOutlineEnabled;

            userInfoNamesOutlineCheckBox.Checked = UserInfoController.Instance.AdvancedSettingsEnabled ? UserInfoController.Instance.NameOutlineEnabled : UserInfoController.Instance.SimpleFontOutlineEnabled;
            userInfoValuesOutlineCheckBox.Checked = UserInfoController.Instance.ValueOutlineEnabled;

            recentAchievementsTitleFontOutlineCheckBox.Checked = RecentAchievementsController.Instance.AdvancedSettingsEnabled ? RecentAchievementsController.Instance.TitleOutlineEnabled : RecentAchievementsController.Instance.SimpleFontOutlineEnabled;
            recentAchievementsDateFontOutlineCheckBox.Checked = RecentAchievementsController.Instance.DescriptionOutlineEnabled;
            recentAchievementsPointsFontOutlineCheckBox.Checked = RecentAchievementsController.Instance.PointsOutlineEnabled;
            recentAchievementsLineOutlineCheckBox.Checked = RecentAchievementsController.Instance.LineOutlineEnabled;

            /*
             * Font Color PictureBox Assignment
             */
            focusTitleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.AdvancedSettingsEnabled ? FocusController.Instance.TitleColor : FocusController.Instance.SimpleFontColor);
            focusDescriptionFontColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.DescriptionColor);
            focusPointsFontColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.PointsColor);
            focusLineColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.LineColor);

            focusTitleFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.AdvancedSettingsEnabled ? FocusController.Instance.TitleOutlineColor : FocusController.Instance.SimpleFontOutlineColor);
            focusDescriptionFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.DescriptionOutlineColor);
            focusPointsFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.PointsOutlineColor);
            focusLineOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusController.Instance.LineOutlineColor);

            alertsTitleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.AdvancedSettingsEnabled ? AlertsController.Instance.TitleColor : AlertsController.Instance.SimpleFontColor);
            alertsDescriptionFontColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.DescriptionColor);
            alertsPointsFontColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.PointsColor);
            alertsLineColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.LineColor);

            alertsTitleFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.AdvancedSettingsEnabled ? AlertsController.Instance.TitleOutlineColor : AlertsController.Instance.SimpleFontOutlineColor);
            alertsDescriptionFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.DescriptionOutlineColor);
            alertsPointsFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.PointsOutlineColor);
            alertsLineOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(AlertsController.Instance.LineColor);

            userInfoNamesFontColorPictureBox.BackColor = ColorTranslator.FromHtml(UserInfoController.Instance.AdvancedSettingsEnabled ? UserInfoController.Instance.NameColor : UserInfoController.Instance.SimpleFontColor);
            userInfoValuesFontColorPictureBox.BackColor = ColorTranslator.FromHtml(UserInfoController.Instance.ValueColor);

            userInfoNamesFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(UserInfoController.Instance.AdvancedSettingsEnabled ? UserInfoController.Instance.NameOutlineColor : UserInfoController.Instance.SimpleFontOutlineColor);
            userInfoValuesFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(UserInfoController.Instance.ValueOutlineColor);

            gameInfoNamesFontColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoController.Instance.AdvancedSettingsEnabled ? GameInfoController.Instance.NameColor : GameInfoController.Instance.SimpleFontColor);
            gameInfoValuesFontColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoController.Instance.ValueColor);

            gameInfoNamesFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoController.Instance.AdvancedSettingsEnabled ? GameInfoController.Instance.NameOutlineColor : GameInfoController.Instance.SimpleFontOutlineColor);
            gameInfoValuesFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoController.Instance.ValueOutlineColor);

            gameProgressNamesFontColorPictureBox.BackColor = ColorTranslator.FromHtml(GameProgressController.Instance.AdvancedSettingsEnabled ? GameProgressController.Instance.NameColor : GameProgressController.Instance.SimpleFontColor);
            gameProgressValuesFontColorPictureBox.BackColor = ColorTranslator.FromHtml(GameProgressController.Instance.ValueColor);

            gameProgressNamesFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(GameProgressController.Instance.AdvancedSettingsEnabled ? GameProgressController.Instance.NameOutlineColor : GameProgressController.Instance.SimpleFontOutlineColor);
            gameProgressValuesFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(GameProgressController.Instance.ValueOutlineColor);

            recentAchievementsTitleFontColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.AdvancedSettingsEnabled ? RecentAchievementsController.Instance.TitleColor : RecentAchievementsController.Instance.SimpleFontColor);
            recentAchievementsDateFontColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.DateColor);
            recentAchievementsPointsFontColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.PointsColor);
            recentAchievementsLineColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.LineColor);

            recentAchievementsTitleFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.AdvancedSettingsEnabled ? RecentAchievementsController.Instance.TitleOutlineColor : RecentAchievementsController.Instance.SimpleFontOutlineColor);
            recentAchievementsDateFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.DateOutlineColor);
            recentAchievementsPointsFontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.PointsOutlineColor);
            recentAchievementsLineOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(RecentAchievementsController.Instance.LineOutlineColor);

            /*
             * Font Outline Size NumericUpDown Assignment
             */
            focusTitleFontOutlineNumericUpDown.Value = FocusController.Instance.AdvancedSettingsEnabled ? FocusController.Instance.TitleOutlineSize : FocusController.Instance.SimpleFontOutlineSize;
            focusDescriptionFontOutlineNumericUpDown.Value = FocusController.Instance.DescriptionOutlineSize;
            focusPointsFontOutlineNumericUpDown.Value = FocusController.Instance.PointsOutlineSize;
            focusLineOutlineNumericUpDown.Value = FocusController.Instance.LineOutlineSize;

            alertsTitleFontOutlineNumericUpDown.Value = AlertsController.Instance.AdvancedSettingsEnabled ? AlertsController.Instance.TitleOutlineSize : AlertsController.Instance.SimpleFontOutlineSize;
            alertsDescriptionFontOutlineNumericUpDown.Value = AlertsController.Instance.DescriptionOutlineSize;
            alertsPointsFontOutlineNumericUpDown.Value = AlertsController.Instance.PointsOutlineSize;
            alertsLineOutlineNumericUpDown.Value = AlertsController.Instance.LineOutlineSize;

            userInfoNamesFontOutlineNumericUpDown.Value = UserInfoController.Instance.AdvancedSettingsEnabled ? UserInfoController.Instance.NameOutlineSize : UserInfoController.Instance.SimpleFontOutlineSize;
            userInfoValuesFontOutlineNumericUpDown.Value = UserInfoController.Instance.ValueOutlineSize;

            gameInfoNamesFontOutlineNumericUpDown.Value = GameInfoController.Instance.AdvancedSettingsEnabled ? GameInfoController.Instance.NameOutlineSize : GameInfoController.Instance.SimpleFontOutlineSize;
            gameInfoValuesFontOutlineNumericUpDown.Value = GameInfoController.Instance.ValueOutlineSize;

            gameProgressNamesFontOutlineNumericUpDown.Value = GameProgressController.Instance.AdvancedSettingsEnabled ? GameProgressController.Instance.NameOutlineSize : GameProgressController.Instance.SimpleFontOutlineSize;
            gameProgressValuesFontOutlineNumericUpDown.Value = GameProgressController.Instance.ValueOutlineSize;

            recentAchievementsTitleFontOutlineNumericUpDown.Value = RecentAchievementsController.Instance.AdvancedSettingsEnabled ? RecentAchievementsController.Instance.TitleOutlineSize : RecentAchievementsController.Instance.SimpleFontOutlineSize;
            recentAchievementsDescriptionFontOutlineNumericUpDown.Value = RecentAchievementsController.Instance.DescriptionOutlineSize;
            recentAchievementsPointsFontOutlineNumericUpDown.Value = RecentAchievementsController.Instance.PointsOutlineSize;
            recentAchievementsLineOutlineNumericUpDown.Value = RecentAchievementsController.Instance.LineOutlineSize;

            recentAchievementsMaxListNumericUpDown.Value = RecentAchievementsController.Instance.MaxListSize;

            /*
             * RSS Feed CheckBoxes
             */
            rssFeedCheevoCheckBox.Checked = Settings.Default.rss_new_achievements_feed;
            rssFeedForumCheckBox.Checked = Settings.Default.rss_forum_feed;
            rssFeedFriendCheckBox.Checked = Settings.Default.rss_friend_feed;
            rssFeedNewsCheckBox.Checked = Settings.Default.rss_news_feed;

            if (AlertsController.Instance.CustomAchievementScale > alertsCustomAchievementScaleNumericUpDown.Maximum)
            {
                AlertsController.Instance.CustomAchievementScale = alertsCustomAchievementScaleNumericUpDown.Maximum;
            }
            else if (AlertsController.Instance.CustomAchievementScale < alertsCustomAchievementScaleNumericUpDown.Minimum)
            {
                AlertsController.Instance.CustomAchievementScale = alertsCustomAchievementScaleNumericUpDown.Minimum;
            }

            if (AlertsController.Instance.CustomAchievementX > alertsCustomAchievementXNumericUpDown.Maximum)
            {
                AlertsController.Instance.CustomAchievementX = (int)alertsCustomAchievementXNumericUpDown.Maximum;
            }
            else if (AlertsController.Instance.CustomAchievementX < alertsCustomAchievementXNumericUpDown.Minimum)
            {
                AlertsController.Instance.CustomAchievementX = (int)alertsCustomAchievementXNumericUpDown.Minimum;
            }

            if (AlertsController.Instance.CustomAchievementY > alertsCustomAchievementYNumericUpDown.Maximum)
            {
                AlertsController.Instance.CustomAchievementY = (int)alertsCustomAchievementYNumericUpDown.Maximum;
            }
            else if (AlertsController.Instance.CustomAchievementY < alertsCustomAchievementYNumericUpDown.Minimum)
            {
                AlertsController.Instance.CustomAchievementY = (int)alertsCustomAchievementYNumericUpDown.Minimum;
            }

            if (AlertsController.Instance.CustomAchievementIn > alertsCustomAchievementInNumericUpDown.Maximum)
            {
                AlertsController.Instance.CustomAchievementIn = (int)alertsCustomAchievementInNumericUpDown.Maximum;
            }
            else if (AlertsController.Instance.CustomAchievementIn < alertsCustomAchievementInNumericUpDown.Minimum)
            {
                AlertsController.Instance.CustomAchievementIn = (int)alertsCustomAchievementInNumericUpDown.Minimum;
            }

            if (AlertsController.Instance.CustomAchievementOut > alertsCustomAchievementOutNumericUpDown.Maximum)
            {
                AlertsController.Instance.CustomAchievementOut = (int)alertsCustomAchievementOutNumericUpDown.Maximum;
            }
            else if (AlertsController.Instance.CustomAchievementOut < alertsCustomAchievementOutNumericUpDown.Minimum)
            {
                AlertsController.Instance.CustomAchievementOut = (int)alertsCustomAchievementOutNumericUpDown.Minimum;
            }

            if (AlertsController.Instance.CustomAchievementInSpeed > alertsCustomAchievementInSpeedUpDown.Maximum)
            {
                AlertsController.Instance.CustomAchievementInSpeed = (int)alertsCustomAchievementInSpeedUpDown.Maximum;
            }
            else if (AlertsController.Instance.CustomAchievementInSpeed < alertsCustomAchievementInSpeedUpDown.Minimum)
            {
                AlertsController.Instance.CustomAchievementInSpeed = (int)alertsCustomAchievementInSpeedUpDown.Minimum;
            }

            if (AlertsController.Instance.CustomAchievementOutSpeed > alertsCustomAchievementOutSpeedUpDown.Maximum)
            {
                AlertsController.Instance.CustomAchievementOutSpeed = (int)alertsCustomAchievementOutSpeedUpDown.Maximum;
            }
            else if (AlertsController.Instance.CustomAchievementOutSpeed < alertsCustomAchievementOutSpeedUpDown.Minimum)
            {
                AlertsController.Instance.CustomAchievementOutSpeed = (int)alertsCustomAchievementOutSpeedUpDown.Minimum;
            }

            if (AlertsController.Instance.CustomMasteryScale > alertsCustomMasteryScaleNumericUpDown.Maximum)
            {
                AlertsController.Instance.CustomMasteryScale = alertsCustomMasteryScaleNumericUpDown.Maximum;
            }
            else if (AlertsController.Instance.CustomMasteryScale < alertsCustomMasteryScaleNumericUpDown.Minimum)
            {
                AlertsController.Instance.CustomMasteryScale = alertsCustomMasteryScaleNumericUpDown.Minimum;
            }

            if (AlertsController.Instance.CustomMasteryX > alertsCustomMasteryXNumericUpDown.Maximum)
            {
                AlertsController.Instance.CustomMasteryX = (int)alertsCustomMasteryXNumericUpDown.Maximum;
            }
            else if (AlertsController.Instance.CustomMasteryX < alertsCustomMasteryXNumericUpDown.Minimum)
            {
                AlertsController.Instance.CustomMasteryX = (int)alertsCustomMasteryXNumericUpDown.Minimum;
            }

            if (AlertsController.Instance.CustomMasteryY > alertsCustomMasteryYNumericUpDown.Maximum)
            {
                AlertsController.Instance.CustomMasteryY = (int)alertsCustomMasteryYNumericUpDown.Maximum;
            }
            else if (AlertsController.Instance.CustomMasteryY < alertsCustomMasteryYNumericUpDown.Minimum)
            {
                AlertsController.Instance.CustomMasteryY = (int)alertsCustomMasteryYNumericUpDown.Minimum;
            }

            if (AlertsController.Instance.CustomMasteryIn > alertsCustomMasteryInNumericUpDown.Maximum)
            {
                AlertsController.Instance.CustomMasteryIn = (int)alertsCustomMasteryInNumericUpDown.Maximum;
            }
            else if (AlertsController.Instance.CustomMasteryIn < alertsCustomMasteryInNumericUpDown.Minimum)
            {
                AlertsController.Instance.CustomMasteryIn = (int)alertsCustomMasteryInNumericUpDown.Minimum;
            }

            if (AlertsController.Instance.CustomMasteryOut > alertsCustomMasteryOutNumericUpDown.Maximum)
            {
                AlertsController.Instance.CustomMasteryOut = (int)alertsCustomMasteryOutNumericUpDown.Maximum;
            }
            else if (AlertsController.Instance.CustomMasteryOut < alertsCustomMasteryOutNumericUpDown.Minimum)
            {
                AlertsController.Instance.CustomMasteryOut = (int)alertsCustomMasteryOutNumericUpDown.Minimum;
            }

            if (AlertsController.Instance.CustomMasteryInSpeed > alertsCustomMasteryInSpeedUpDown.Maximum)
            {
                AlertsController.Instance.CustomMasteryInSpeed = (int)alertsCustomMasteryInSpeedUpDown.Maximum;
            }
            else if (AlertsController.Instance.CustomMasteryInSpeed < alertsCustomMasteryInSpeedUpDown.Minimum)
            {
                AlertsController.Instance.CustomMasteryInSpeed = (int)alertsCustomMasteryInSpeedUpDown.Minimum;
            }

            if (AlertsController.Instance.CustomMasteryOutSpeed > alertsCustomMasteryOutSpeedUpDown.Maximum)
            {
                AlertsController.Instance.CustomMasteryOutSpeed = (int)alertsCustomMasteryOutSpeedUpDown.Maximum;
            }
            else if (AlertsController.Instance.CustomMasteryOutSpeed < alertsCustomMasteryOutSpeedUpDown.Minimum)
            {
                AlertsController.Instance.CustomMasteryOutSpeed = (int)alertsCustomMasteryOutSpeedUpDown.Minimum;
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
                alertsCustomAchievementAnimationInComboBox.Items.Add(animationDirection.ToString());
                alertsCustomAchievementAnimationOutComboBox.Items.Add(animationDirection.ToString());
                alertsCustomMasteryAnimationInComboBox.Items.Add(animationDirection.ToString());
                alertsCustomMasteryAnimationOutComboBox.Items.Add(animationDirection.ToString());
            });

            alertsCustomAchievementAnimationInComboBox.SelectedIndex = alertsCustomAchievementAnimationInComboBox.Items.IndexOf(AlertsController.Instance.AchievementAnimationIn.ToString());
            alertsCustomAchievementAnimationOutComboBox.SelectedIndex = alertsCustomAchievementAnimationOutComboBox.Items.IndexOf(AlertsController.Instance.AchievementAnimationOut.ToString());
            alertsCustomMasteryAnimationInComboBox.SelectedIndex = alertsCustomMasteryAnimationInComboBox.Items.IndexOf(AlertsController.Instance.MasteryAnimationIn.ToString());
            alertsCustomMasteryAnimationOutComboBox.SelectedIndex = alertsCustomMasteryAnimationOutComboBox.Items.IndexOf(AlertsController.Instance.MasteryAnimationOut.ToString());

            alertsCustomAchievementScaleNumericUpDown.Value = AlertsController.Instance.CustomAchievementScale;
            alertsCustomMasteryScaleNumericUpDown.Value = AlertsController.Instance.CustomMasteryScale;

            alertsCustomAchievementInNumericUpDown.Value = AlertsController.Instance.CustomAchievementIn;
            alertsCustomAchievementOutNumericUpDown.Value = AlertsController.Instance.CustomAchievementOut;

            alertsCustomMasteryInNumericUpDown.Value = AlertsController.Instance.CustomMasteryIn;
            alertsCustomMasteryOutNumericUpDown.Value = AlertsController.Instance.CustomMasteryOut;

            alertsCustomAchievementInSpeedUpDown.Value = AlertsController.Instance.CustomAchievementInSpeed;
            alertsCustomAchievementOutSpeedUpDown.Value = AlertsController.Instance.CustomAchievementOutSpeed;

            alertsCustomMasteryInSpeedUpDown.Value = AlertsController.Instance.CustomMasteryInSpeed;
            alertsCustomMasteryOutSpeedUpDown.Value = AlertsController.Instance.CustomMasteryOutSpeed;

            alertsCustomAchievementXNumericUpDown.Value = AlertsController.Instance.CustomAchievementX;
            alertsCustomAchievementYNumericUpDown.Value = AlertsController.Instance.CustomAchievementY;

            alertsCustomMasteryXNumericUpDown.Value = AlertsController.Instance.CustomMasteryX;
            alertsCustomMasteryYNumericUpDown.Value = AlertsController.Instance.CustomMasteryY;

            /*
             * Auto-Scrolling
             */
            recentAchievementsAutoScrollCheckBox.Checked = RecentAchievementsController.Instance.AutoScroll;
            achievementListAutoScrollCheckBox.Checked = AchievementListController.Instance.AutoScroll;

            UpdateAdvancedSettings();
            UpdateAlertsEnabledControls();

            UpdateRelatedMediaRadioButtons();
            UpdateRefocusBehaviorRadioButtons();
            UpdateDividerCharacterRadioButtons();
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