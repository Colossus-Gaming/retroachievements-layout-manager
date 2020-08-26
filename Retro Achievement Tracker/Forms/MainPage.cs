using AutoUpdaterDotNET;
using CefSharp;
using HtmlAgilityPack;
using Retro_Achievement_Tracker.Forms;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Xml.XPath;

namespace Retro_Achievement_Tracker
{
    public partial class MainPage : Form, INotifyPropertyChanged
    {
        private static readonly string CALLER_ID = "ControlWindow";
        private static UserSummary _userSummary;
        private GameProgress _gameProgress;

        private int _rank = -1;
        private int _points = -1;
        private int _awards = -1;

        private int _gameAchievmentsEarned;
        private int _gamePointsEarned;

        private string _gameTitle;
        private string _gameImage;
        private string _gameConsole;
        private string _gameDeveloper;
        private string _gamePublisher;

        public UserSummary UserSummary
        {
            get
            {
                return _userSummary;
            }
            set
            {
                if (value == null)
                {
                    DegradeConnectivity("Got null response getting user summary info.");

                    return;
                }

                RAErrors = 0;

                _userSummary = value;
            }
        }
        private GameProgress CurrentGame
        {
            get
            {
                return _gameProgress;
            }
            set
            {
                if (value == null || value.Id == 0)
                {
                    DegradeConnectivity("Got null response getting game progress info.");

                    return;
                }

                RAErrors = 0;

                bool gameChange = _gameProgress == null || (_gameProgress != null && value.Id != _gameProgress.Id);

                _gameProgress = value;

                OldUnlockedAchievements = UnlockedAchievements.ToList();

                Rank = _userSummary.Rank;
                Points = _userSummary.TotalPoints;

                GameTotalPoints = _userSummary.GameAchievementSummaries[0].PossibleScore;
                GameTotalAchievements = _userSummary.GameAchievementSummaries[0].NumPossibleAchievements;

                GameEarnedPoints = _userSummary.GameAchievementSummaries[0].ScoreAchieved;
                GameEarnedAchievements = _userSummary.GameAchievementSummaries[0].NumAchievedHardcore;

                if (_userSummary.RecentAchievements != null && _userSummary.RecentAchievements.Count > 0)
                {
                    NotificationLayoutWindow.MostRecentAchievement = _userSummary.RecentAchievements[0];
                }

                GameTitle = _gameProgress.Title;
                GameImage = _gameProgress.ImageIcon;
                ConsoleName = _gameProgress.ConsoleName;
                GameDeveloper = _gameProgress.Developer;
                GamePublisher = _gameProgress.Publisher;

                SortAchievements();

                if (gameChange)
                {
                    FocusLayoutWindow.SetFocus();
                }
                else if (UnlockedAchievements.Count > 0)
                {
                    List<Achievement> achievementNotificationList = UnlockedAchievements
                    .FindAll(unlockedAchievement => !OldUnlockedAchievements.Contains(unlockedAchievement))
                    .ToList();

                    achievementNotificationList.Sort();

                    foreach (Achievement achievement in achievementNotificationList)
                    {
                        NotificationLayoutWindow.EnqueueAchievementNotification(achievement);
                    }

                    if (achievementNotificationList.Contains(FocusLayoutWindow.CurrentlyFocusedAchievement))
                    {
                        FocusLayoutWindow.SetFocus();
                    }

                    if (UnlockedAchievements.Count == CurrentGame.Achievements.Count && OldUnlockedAchievements.Count < CurrentGame.Achievements.Count)
                    {
                        FocusLayoutWindow.HideFocus();
                        NotificationLayoutWindow.EnqueueMasteryNotification(UserSummary.GameSummaries[0], UserSummary.GameAchievementSummaries[0]);
                    }
                }

                UserAndGameTimerCounter = 6;
                UserAndGameUpdateTimer.Start();
            }
        }

        private void DegradeConnectivity(string s)
        {
            this.raConnectionStatusPictureBox.Image = Resources.yellow_button;

            RAErrors++;

            Log(CALLER_ID + "[" + s + "]");

            if (RAErrors > 5)
            {
                this.StopButton_Click(null, null);

                this.raConnectionStatusPictureBox.Image = Resources.red_button;

                Log(CALLER_ID + "[Stopping service after too many connectivity problems.]");
            }
        }

        public int Rank
        {
            get
            {
                return _rank;
            }
            set
            {
                if (_rank != value)
                {
                    StatsLayoutWindow.SetRank(value);
                }
                _rank = value;

                OnPropertyChanged("Rank");
            }
        }
        public int Points
        {
            get
            {
                return _points;
            }
            set
            {
                if (_points != value)
                {
                    StatsLayoutWindow.SetPoints(value);
                }
                _points = value;

                OnPropertyChanged("Points");
            }
        }
        public int Awards
        {
            get
            {
                return _awards;
            }
            set
            {
                if (_awards != value)
                {
                    StatsLayoutWindow.SetAwards(value);
                }
                _awards = value;

                OnPropertyChanged("Awards");
            }
        }
        public string GameTitle
        {
            get
            {
                return _gameTitle;
            }
            set
            {
                _gameTitle = value;

                OnPropertyChanged("GameTitle");
            }
        }
        public string GameImage
        {
            get
            {
                return _gameImage;
            }
            set
            {
                _gameImage = value;

                OnPropertyChanged("GameImage");
            }
        }
        public string ConsoleName
        {
            get
            {
                return _gameConsole;
            }
            set
            {
                _gameConsole = value;

                OnPropertyChanged("ConsoleName");
            }
        }
        public string GameDeveloper
        {
            get
            {
                return _gameDeveloper;
            }
            set
            {
                _gameDeveloper = value;

                OnPropertyChanged("GameDeveloper");
            }
        }
        public string GamePublisher
        {
            get
            {
                return _gamePublisher;
            }
            set
            {
                _gamePublisher = value;

                OnPropertyChanged("GamePublisher");
            }
        }

        public int GameEarnedAchievements
        {
            get
            {
                return _gameAchievmentsEarned;
            }
            set
            {
                if (_gameAchievmentsEarned != value)
                {
                    StatsLayoutWindow.SetGameAchievements(value, GameTotalAchievements);
                }
                _gameAchievmentsEarned = value;

                OnPropertyChanged("GameEarnedAchievements");
            }
        }
        public int GameEarnedPoints
        {
            get
            {
                return _gamePointsEarned;
            }
            set
            {
                if (_gamePointsEarned != value)
                {
                    StatsLayoutWindow.SetGamePoints(value, GameTotalPoints);
                }
                _gamePointsEarned = value;

                OnPropertyChanged("GameEarnedPoints");
            }
        }

        private int GameTotalAchievements { get; set; }
        private int GameTotalPoints { get; set; }

        private static List<Achievement> LockedAchievements;
        private static List<Achievement> UnlockedAchievements;
        private static List<Achievement> OldUnlockedAchievements;

        private static SupportPage supportPage;

        private static Timer UserAndGameUpdateTimer;
        private static Timer AwardAndConnectivityTimer;
        private static int UserAndGameTimerCounter;
        private static int AwardAndConnectivityCounter;

        private static StatsLayoutWindow StatsLayoutWindow;
        private static FocusLayoutWindow FocusLayoutWindow;
        private static NotificationLayoutWindow NotificationLayoutWindow;

        private readonly BindingList<string> ConsoleLogs = new BindingList<string>();

        private bool ShouldRun;

        private int RAErrors;
        private HFC_EssentialsClient hFC_EssentialsClient;

        public event PropertyChangedEventHandler PropertyChanged;
        public MainPage()
        {
            InitializeComponent();
            LoadProperties();
            AutoUpdate();
            SetupInterface();
        }

        private static void AutoUpdate()
        {
            AutoUpdater.ReportErrors = true;
            AutoUpdater.Synchronous = true;
            AutoUpdater.Start("https://github.com/Colossus-Gaming/retroachievements-layout-manager/releases/download/release-management/ra-layout-manager-release.xml");
        }

        private void SetupInterface()
        {
            this.consoleLogs.DataSource = ConsoleLogs;

            UserAndGameUpdateTimer = new Timer();
            UserAndGameUpdateTimer.Tick += new EventHandler(CheckAchievements);
            UserAndGameUpdateTimer.Interval = 1000;

            AwardAndConnectivityTimer = new Timer();
            AwardAndConnectivityTimer.Tick += new EventHandler(SetAwardCount);
            AwardAndConnectivityTimer.Interval = 1000;

            UnlockedAchievements = new List<Achievement>();
            LockedAchievements = new List<Achievement>();

            CreateStatsWindow();
            CreateFocusWindow();
            CreateNotificationsWindow();
        }

        protected override void OnLoad(EventArgs e)
        {
            CreateDataBindings();

            if (this.CanStart() && this.autoStartCheckbox.Checked)
            {
                this.StartButton_Click(null, null);
            }
            else
            {
                this.StopButton_Click(null, null);
            }
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            this.startButton.Enabled = false;
            this.stopButton.Enabled = true;

            ShouldRun = true;

            this.usernameTextBox.Enabled = false;
            this.apiKeyTextBox.Enabled = false;

            hFC_EssentialsClient = new HFC_EssentialsClient(this.usernameTextBox.Text, this.apiKeyTextBox.Text);

            UserSummary = await hFC_EssentialsClient.GetUserSummary();

            Log(CALLER_ID + "[User Stats {" + this.usernameTextBox.Text + "} loaded.]");

            CurrentGame = await hFC_EssentialsClient.GetGameProgress(UserSummary.GameSummaries[0].GameID.ToString());

            this.userProfilePictureBox.ImageLocation = "https://retroachievements.org/UserPic/" + this.usernameTextBox.Text + ".png";

            Log(CALLER_ID + "[Game Info {" + CurrentGame.Title + "} loaded.]");

            if (this.autoLaunchFocusWindowCheckBox.Checked)
            {
                FocusLayoutWindow.Show();
            }

            if (this.autoLaunchStatsWindowCheckbox.Checked)
            {
                StatsLayoutWindow.Show();
            }

            if (this.autoLaunchNotificationsWindowCheckbox.Checked)
            {
                NotificationLayoutWindow.Show();
            }

            this.showFocusWindowButton.Enabled = true;
            this.showNotificationsWindowButton.Enabled = true;
            this.showStatsWindowButton.Enabled = true;

            StartTimer();

            Settings.Default.ra_username = this.usernameTextBox.Text;
            Settings.Default.ra_key = this.apiKeyTextBox.Text;
            Settings.Default.Save();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            ShouldRun = false;

            UserAndGameUpdateTimer.Stop();
            AwardAndConnectivityTimer.Stop();

            this.raConnectionStatusPictureBox.Image = Resources.red_button;

            Log(CALLER_ID + "[Stopped timer.]");
            UpdateTimerLabel("Stopped Updating.");
            UpdateRAConnectivityLabel("Stopped checking retroachievements.org");

            this.stopButton.Enabled = false;
            this.showFocusWindowButton.Enabled = false;
            this.showNotificationsWindowButton.Enabled = false;
            this.showStatsWindowButton.Enabled = false;

            this.apiKeyTextBox.Enabled = true;
            this.usernameTextBox.Enabled = true;

            this.startButton.Enabled = CanStart();

            SaveProperties();
        }

        private void CreateStatsWindow()
        {
            StatsLayoutWindow = new StatsLayoutWindow
            {
                LogCallback = Log
            };

            StatsLayoutWindow.chromiumWebBrowser.RequestHandler = new CustomRequestHandler();
            StatsLayoutWindow.chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                StatsLayoutWindow.SetRank(UserSummary.Rank);
                StatsLayoutWindow.SetPoints(UserSummary.TotalPoints);
                StatsLayoutWindow.SetAwards(_awards);
                StatsLayoutWindow.SetGameAchievements(GameEarnedAchievements, GameTotalAchievements);
                StatsLayoutWindow.SetGamePoints(GameEarnedPoints, GameTotalPoints);
            });
        }

        private void CreateFocusWindow()
        {
            FocusLayoutWindow = new FocusLayoutWindow
            {
                LogCallback = Log
            };

            FocusLayoutWindow.chromiumWebBrowser.RequestHandler = new CustomRequestHandler();
            FocusLayoutWindow.chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                FocusLayoutWindow.SetLockedAchievements(LockedAchievements);
                FocusLayoutWindow.SetFocus();
            });
        }

        private void CreateNotificationsWindow()
        {
            NotificationLayoutWindow = new NotificationLayoutWindow
            {
                LogCallback = Log
            };

            NotificationLayoutWindow.chromiumWebBrowser.RequestHandler = new CustomRequestHandler();
        }

        private bool CanStart()
        {
            return !(string.IsNullOrWhiteSpace(this.usernameTextBox.Text)
                || string.IsNullOrWhiteSpace(this.apiKeyTextBox.Text));
        }

        private void UpdateTimerLabel(string s)
        {
            this.timerStatusLabel.Text = s;
        }

        private void UpdateRAConnectivityLabel(string v)
        {
            this.raConnectivityLabel.Text = v;
        }

        private async void CheckAchievements(object sender, EventArgs e)
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

                this.startButton.Enabled = false;

                UpdateTimerLabel("Calling for user summary...");

                UserSummary = await hFC_EssentialsClient.GetUserSummary();

                UpdateTimerLabel("Calling for game progress...");

                CurrentGame = await hFC_EssentialsClient.GetGameProgress(UserSummary.GameSummaries[0].GameID.ToString());
            }
        }

        private void StartTimer()
        {
            UserAndGameTimerCounter = 6;
            AwardAndConnectivityCounter = 0;

            if (ShouldRun)
            {
                UserAndGameUpdateTimer.Start();
                AwardAndConnectivityTimer.Start();
            }
        }

        private void Log(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                Invoke((MethodInvoker)delegate
                {
                    ConsoleLogs.Insert(0, "[" + DateTime.Now.ToString("HH:mm:ss:fff") + "] " + s);

                    while (ConsoleLogs.Count > 10)
                    {
                        ConsoleLogs.RemoveAt(ConsoleLogs.Count - 1);
                    }

                    this.consoleLogs.TopIndex = 0;
                });
            }
        }

        private void SortAchievements()
        {
            if (CurrentGame.Achievements != null)
            {
                List<Achievement> tempLockedAchievements = CurrentGame.Achievements.FindAll(x => { return !x.DateEarned.HasValue; });
                List<Achievement> tempUnlockedAchievements = CurrentGame.Achievements.FindAll(x => { return x.DateEarned.HasValue; });

                LockedAchievements = tempLockedAchievements;
                UnlockedAchievements = tempUnlockedAchievements;

                LockedAchievements.Sort(delegate (Achievement x, Achievement y) { return x.Id.CompareTo(y.Id); });
                UnlockedAchievements.Sort(delegate (Achievement x, Achievement y) { return y.DateEarned.Value.CompareTo(x.DateEarned.Value); });
            }

            if (FocusLayoutWindow.CurrentlyFocusedIndex > 0 && OldUnlockedAchievements.Count < UnlockedAchievements.Count)
            {
                FocusLayoutWindow.CurrentlyFocusedIndex -= UnlockedAchievements.Count - OldUnlockedAchievements.Count;
            }
            FocusLayoutWindow.SetLockedAchievements(LockedAchievements);
        }

        private void MainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (FocusLayoutWindow != null && !FocusLayoutWindow.IsDisposed)
            {
                FocusLayoutWindow.Dispose();
            }
            if (StatsLayoutWindow != null && !StatsLayoutWindow.IsDisposed)
            {
                StatsLayoutWindow.Dispose();
            }
            if (NotificationLayoutWindow != null && !NotificationLayoutWindow.IsDisposed)
            {
                NotificationLayoutWindow.Dispose();
            }
            SaveProperties();
        }

        private void SaveProperties()
        {
            Settings.Default.ra_username = this.usernameTextBox.Text;
            Settings.Default.ra_key = this.apiKeyTextBox.Text;
            Settings.Default.auto_start_checked = this.autoStartCheckbox.Checked;
            Settings.Default.auto_focus = this.autoLaunchFocusWindowCheckBox.Checked;
            Settings.Default.auto_stats = this.autoLaunchStatsWindowCheckbox.Checked;
            Settings.Default.auto_notifications = this.autoLaunchNotificationsWindowCheckbox.Checked;

            Settings.Default.Save();
        }

        private void LoadProperties()
        {
            this.usernameTextBox.Text = Settings.Default.ra_username;
            this.apiKeyTextBox.Text = Settings.Default.ra_key;
            this.autoStartCheckbox.Checked = Settings.Default.auto_start_checked;
            this.autoLaunchFocusWindowCheckBox.Checked = Settings.Default.auto_focus;
            this.autoLaunchStatsWindowCheckbox.Checked = Settings.Default.auto_stats;
            this.autoLaunchNotificationsWindowCheckbox.Checked = Settings.Default.auto_notifications;
        }

        private async void SetAwardCount(object sender, EventArgs eventArgs)
        {
            if (!ShouldRun)
            {
                AwardAndConnectivityTimer.Stop();

                return;
            }

            AwardAndConnectivityCounter--;

            UpdateRAConnectivityLabel("Calling retroachievements.org in " + AwardAndConnectivityCounter + "...");

            if (AwardAndConnectivityCounter <= 0)
            {
                AwardAndConnectivityTimer.Stop();

                AwardAndConnectivityCounter = 11;

                UpdateRAConnectivityLabel("Calling retroachievements.org for award count...");

                try
                {
                    string url = "http://retroachievements.org/user/" + usernameTextBox.Text;

                    HtmlWeb web = new HtmlWeb();

                    HtmlAgilityPack.HtmlDocument doc = await web.LoadFromWebAsync(url);

                    HtmlNode siteAwardsNode = doc.GetElementbyId("siteawards");

                    if (siteAwardsNode == null)
                    {
                        DegradeConnectivity("Encountered problems checking retroarchievements.org.");
                        UpdateRAConnectivityLabel("Encountered problems checking retroarchievements.org.");

                        return;
                    }
                    this.raConnectionStatusPictureBox.Image = Resources.green_button;

                    RAErrors = 0;

                    Awards = siteAwardsNode.SelectNodes(XPathExpression.Compile("//div[contains(@class,'trophyimage')]")).Count;

                    AwardAndConnectivityTimer.Start();
                }
                catch (Exception ex)
                {
                    DegradeConnectivity("Encountered problems checking retroarchievements.org for award count: " + ex.Message);
                }
            }
        }

        private void SupportButton_Click(object sender, EventArgs e)
        {
            supportPage = new SupportPage
            {
                FormBorderStyle = FormBorderStyle.FixedSingle
            };
            supportPage.FormClosed += new FormClosedEventHandler(SupportPage_FormClosed);

            this.supportButton.Enabled = false;

            supportPage.Show();
        }

        private void RequiredField_TextChange(object sender, EventArgs e)
        {
            this.startButton.Enabled = CanStart();
        }

        private void SupportPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.supportButton.Enabled = true;
        }

        private void ShowFocusLayoutWindowButton_Click(object sender, EventArgs e)
        {
            if (!FocusLayoutWindow.Visible)
            {
                CreateFocusWindow();
                FocusLayoutWindow.Show();
            }
        }

        private void ShowStatsWindowButton_Click(object sender, EventArgs e)
        {
            if (!StatsLayoutWindow.Visible)
            {
                CreateStatsWindow();
                StatsLayoutWindow.Show();
            }
        }

        private void ShowNotificationsWindowButton_Click(object sender, EventArgs e)
        {
            if (!NotificationLayoutWindow.Visible)
            {
                CreateNotificationsWindow();
                NotificationLayoutWindow.Show();
            }
        }

        private void AutoLaunchStatsWindowCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.auto_stats = this.autoLaunchStatsWindowCheckbox.Checked;
            Settings.Default.Save();
        }

        private void AutoLaunchFocusWindowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.auto_focus = this.autoLaunchFocusWindowCheckBox.Checked;
            Settings.Default.Save();
        }

        private void AutoLaunchNotificationsWindow_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.auto_notifications = this.autoLaunchNotificationsWindowCheckbox.Checked;
            Settings.Default.Save();
        }


        private void AutoStart_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.auto_start_checked = this.autoStartCheckbox.Checked;
            Settings.Default.Save();
        }

        private void CreateDataBindings()
        {
            Binding rankBinding = new Binding("Text", this, "Rank");
            rankBinding.Format += new ConvertEventHandler((sender, convertEventArgs) =>
            {
                convertEventArgs.Value = "Rank: " + convertEventArgs.Value;
            });

            this.siteRankLabel.DataBindings.Add(rankBinding);

            Binding scoreBinding = new Binding("Text", this, "Points");
            scoreBinding.Format += new ConvertEventHandler((sender, convertEventArgs) =>
            {
                convertEventArgs.Value = "Points: " + convertEventArgs.Value;
            });

            this.pointsLabel.DataBindings.Add(scoreBinding);

            Binding gameImageBinding = new Binding("ImageLocation", this, "GameImage");
            gameImageBinding.Format += new ConvertEventHandler((sender, convertEventArgs) =>
            {
                convertEventArgs.Value = "https://retroachievements.org" + convertEventArgs.Value;
            });

            this.gameInformationImage.DataBindings.Add(gameImageBinding);

            Binding gameTitleBinding = new Binding("Text", this, "GameTitle");
            this.gameInformationTitleLabel.DataBindings.Add(gameTitleBinding);

            Binding gameCheevosCountBinding = new Binding("Text", this, "GameEarnedAchievements");
            gameCheevosCountBinding.Format += new ConvertEventHandler((sender, convertEventArgs) =>
            {
                convertEventArgs.Value = convertEventArgs.Value + "  |  " + GameTotalAchievements;
            });
            this.gameInformationCheevosCountLabel.DataBindings.Add(gameCheevosCountBinding);

            Binding gamePointsCountBinding = new Binding("Text", this, "GameEarnedPoints");
            gamePointsCountBinding.Format += new ConvertEventHandler((sender, convertEventArgs) =>
            {
                convertEventArgs.Value = convertEventArgs.Value + "  |  " + GameTotalPoints;
            });
            this.gameInformationPointsLabel.DataBindings.Add(gamePointsCountBinding);

            Binding gamePublisherBinding = new Binding("Text", this, "GamePublisher");
            gamePublisherBinding.Format += new ConvertEventHandler((sender, convertEventArgs) =>
            {
                convertEventArgs.Value = convertEventArgs.Value;
            });
            this.gameInformationPublisherLabel.DataBindings.Add(gamePublisherBinding);

            Binding gameDeveloperBinding = new Binding("Text", this, "GameDeveloper");
            gameDeveloperBinding.Format += new ConvertEventHandler((sender, convertEventArgs) =>
            {
                convertEventArgs.Value = convertEventArgs.Value;
            });
            this.gameInformationDeveloperLabel.DataBindings.Add(gameDeveloperBinding);

            Binding gameConsoleBinding = new Binding("Text", this, "ConsoleName");
            gameConsoleBinding.Format += new ConvertEventHandler((sender, convertEventArgs) =>
            {
                convertEventArgs.Value = convertEventArgs.Value;
            });
            this.gameInformationConsoleLabel.DataBindings.Add(gameConsoleBinding);

            Binding awardsBinding = new Binding("Text", this, "Awards");
            awardsBinding.Format += new ConvertEventHandler((sender, convertEventArgs) =>
            {
                convertEventArgs.Value = "Awards: " + convertEventArgs.Value;
            });

            this.awardsLabel.DataBindings.Add(awardsBinding);
        }

        protected virtual void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
