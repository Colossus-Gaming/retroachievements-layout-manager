using AutoUpdaterDotNET;
using CefSharp;
using HtmlAgilityPack;
using MediaToolkit;
using MediaToolkit.Model;
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
        private static UserSummary _userSummary;
        private GameProgress _gameProgress;

        private int _rank = 0;
        private int _points = 0;
        private int _awards = 0;

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
                    DegradeConnectivity();

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
                    DegradeConnectivity();

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

                GameTitle = _gameProgress.Title;
                GameImage = _gameProgress.ImageIcon;
                ConsoleName = _gameProgress.ConsoleName;
                GameDeveloper = _gameProgress.Developer;
                GamePublisher = _gameProgress.Publisher;

                SortAchievements();

                if (gameChange)
                {
                    CurrentlyFocusedAchievement = CurrentlyViewingAchievement;
                    FocusWindow.SetFocus(CurrentlyFocusedAchievement);
                }
                else if (UnlockedAchievements.Count > 0)
                {
                    List<Achievement> achievementNotificationList = UnlockedAchievements
                    .FindAll(unlockedAchievement => !OldUnlockedAchievements.Contains(unlockedAchievement))
                    .ToList();

                    achievementNotificationList.Sort();

                    foreach (Achievement achievement in achievementNotificationList)
                    {
                        NotificationsWindow.EnqueueAchievementNotification(achievement,
                            this.useCustomAchievementCheckbox.Checked ? GetVideoDuration(CustomAchievementFile) : 7000,
                            this.useCustomAchievementCheckbox.Checked ? CustomAchievementIn : 0,
                            this.useCustomAchievementCheckbox.Checked ? CustomAchievementOut : 5600);
                    }

                    if (achievementNotificationList.Contains(CurrentlyFocusedAchievement))
                    {
                        FocusWindow.SetFocus(CurrentlyFocusedAchievement);
                    }

                    if (UnlockedAchievements.Count == CurrentGame.Achievements.Count && OldUnlockedAchievements.Count < CurrentGame.Achievements.Count)
                    {
                        FocusWindow.HideFocus();
                        NotificationsWindow.EnqueueMasteryNotification(UserSummary.GameSummaries[0],
                            UserSummary.GameAchievementSummaries[0],
                            this.useCustomMasteryCheckbox.Checked ? GetVideoDuration(CustomMasteryFile) : 11000,
                            this.useCustomMasteryCheckbox.Checked ? CustomMasteryIn : 0,
                            this.useCustomMasteryCheckbox.Checked ? CustomMasteryOut : 5600);
                        SetAwardCount();
                    }

                    NotificationsWindow.FireNotifications();
                }

                UserAndGameTimerCounter = 6;
                UserAndGameUpdateTimer.Start();
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
                    StatsWindow.SetRank(value);
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
                    StatsWindow.SetPoints(value);
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
                    StatsWindow.SetAwards(value);
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
                    StatsWindow.SetGameAchievements(value, GameTotalAchievements);
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
                    StatsWindow.SetGamePoints(value, GameTotalPoints);
                }
                _gamePointsEarned = value;

                OnPropertyChanged("GameEarnedPoints");
            }
        }

        private int GameTotalAchievements { get; set; }
        private int GameTotalPoints { get; set; }

        public FontFamily StatsFontFamily
        {
            get
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily font in familyArray)
                {
                    if (font.Name.Equals(Settings.Default.stats_font_family_name))
                    {
                        return font;
                    }
                }

                Settings.Default.stats_font_family_name = familyArray[0].Name;
                Settings.Default.Save();

                return familyArray[0];
            }
            set
            {
                Settings.Default.stats_font_family_name = value.Name;
                Settings.Default.Save();

                if (!StatsWindow.IsDisposed)
                {
                    StatsWindow.SetFontFamily(value.Name);
                }
            }
        }
        public string StatsFontColor
        {
            get
            {
                return Settings.Default.stats_font_color_hex_code;
            }
            set
            {
                Settings.Default.stats_font_color_hex_code = value;
                Settings.Default.Save();

                if (!StatsWindow.IsDisposed)
                {
                    StatsWindow.SetFontColor(value);
                }
            }
        }
        public string StatsFontOutlineColor
        {
            get
            {
                return Settings.Default.stats_font_outline_color_hex;
            }
            set
            {
                Settings.Default.stats_font_color_hex_code = value;
                Settings.Default.Save();

                if (!StatsWindow.IsDisposed)
                {
                    StatsWindow.SetFontOutline(value, StatsFontOutlineSize);
                }
            }
        }
        public int StatsFontOutlineSize
        {
            get
            {
                return Settings.Default.stats_font_outline_size;
            }
            set
            {
                Settings.Default.stats_font_outline_size = value;
                Settings.Default.Save();

                if (!StatsWindow.IsDisposed)
                {
                    StatsWindow.SetFontOutline(StatsFontOutlineColor, value);
                }
            }
        }

        public FontFamily NotificationsFontFamily
        {
            get
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily font in familyArray)
                {
                    if (font.Name.Equals(Settings.Default.notification_font_family_name))
                    {
                        return font;
                    }
                }

                Settings.Default.notification_font_family_name = familyArray[0].Name;
                Settings.Default.Save();

                return familyArray[0];
            }
            set
            {
                Settings.Default.notification_font_family_name = value.Name;
                Settings.Default.Save();

                if (!NotificationsWindow.IsDisposed)
                {
                    NotificationsWindow.SetFontFamily(value.Name);
                }
            }
        }
        public string NotificationsFontColor
        {
            get
            {
                return Settings.Default.notification_font_color_hex_code;
            }
            set
            {
                Settings.Default.notification_font_color_hex_code = value;
                Settings.Default.Save();

                if (!NotificationsWindow.IsDisposed)
                {
                    NotificationsWindow.SetFontColor(value);
                }
            }
        }
        public string NotificationsFontOutlineColor
        {
            get
            {
                return Settings.Default.notification_font_outline_color_hex;
            }
            set
            {
                Settings.Default.notification_font_outline_color_hex = value;
                Settings.Default.Save();

                if (!NotificationsWindow.IsDisposed)
                {
                    NotificationsWindow.SetFontOutline(value, NotificationsFontOutlineSize);
                }
            }
        }
        public int NotificationsFontOutlineSize
        {
            get
            {
                return Settings.Default.notification_font_outline_size;
            }
            set
            {
                Settings.Default.notification_font_outline_size = value;
                Settings.Default.Save();

                if (!NotificationsWindow.IsDisposed)
                {
                    NotificationsWindow.SetFontOutline(NotificationsFontOutlineColor, value);
                }
            }
        }
        public string NotificationsBackgroundColor
        {
            get
            {
                return Settings.Default.notification_background_color;
            }
            set
            {
                Settings.Default.notification_background_color = value;
                Settings.Default.Save();

                if (!NotificationsWindow.IsDisposed)
                {
                    NotificationsWindow.SetBackgroundColor(value);
                }
            }
        }
        private bool CustomAchievementEnabled
        {
            set
            {
                Settings.Default.notification_custom_achievement_enable = value;
                Settings.Default.Save();
            }
            get
            {
                return Settings.Default.notification_custom_achievement_enable;
            }
        }
        private bool CustomMasteryEnabled
        {
            set
            {
                Settings.Default.notification_custom_mastery_enable = value;
                Settings.Default.Save();
            }
            get
            {
                return Settings.Default.notification_custom_mastery_enable;
            }
        }
        private int CustomAchievementX
        {
            set
            {
                Settings.Default.notification_custom_achievement_x = value;
                Settings.Default.Save();

                if (!NotificationsWindow.IsDisposed)
                {
                    NotificationsWindow.SetAchievementLeft(this.useCustomAchievementCheckbox.Checked ? value : -15);
                }
            }
            get
            {
                return Settings.Default.notification_custom_achievement_x;
            }
        }
        private int CustomAchievementY
        {
            set
            {
                Settings.Default.notification_custom_achievement_y = value;
                Settings.Default.Save();

                if (!NotificationsWindow.IsDisposed)
                {
                    NotificationsWindow.SetAchievementTop(this.useCustomAchievementCheckbox.Checked ? value : 5);
                }
            }
            get
            {
                return Settings.Default.notification_custom_achievement_y;
            }
        }
        private int CustomMasteryX
        {
            set
            {
                Settings.Default.notification_custom_mastery_x = value;
                Settings.Default.Save();

                if (!NotificationsWindow.IsDisposed)
                {
                    NotificationsWindow.SetMasteryLeft(this.useCustomMasteryCheckbox.Checked ? value : -15);
                }
            }
            get
            {
                return Settings.Default.notification_custom_mastery_x;
            }
        }
        private int CustomMasteryY
        {
            set
            {
                Settings.Default.notification_custom_mastery_y = value;
                Settings.Default.Save();

                if (!NotificationsWindow.IsDisposed)
                {
                    NotificationsWindow.SetMasteryTop(this.useCustomMasteryCheckbox.Checked ? value : 5);
                }
            }
            get
            {
                return Settings.Default.notification_custom_mastery_y;
            }
        }
        private decimal CustomAchievementScale
        {
            set
            {
                Settings.Default.notification_custom_achievement_scale = value;
                Settings.Default.Save();
            }
            get
            {
                return Settings.Default.notification_custom_achievement_scale;
            }
        }
        private decimal CustomMasteryScale
        {
            set
            {
                Settings.Default.notification_custom_mastery_scale = value;
                Settings.Default.Save();

                if (!NotificationsWindow.IsDisposed)
                {
                    NotificationsWindow.SetMasteryWidth(this.useCustomMasteryCheckbox.Checked ? Convert.ToInt32(CustomMasteryScale * GetVideoWidth(CustomMasteryFile)) : 1200);
                }
            }
            get
            {
                return Settings.Default.notification_custom_mastery_scale;
            }
        }
        private int CustomAchievementIn
        {
            get
            {
                return Settings.Default.notification_custom_achievement_fade_in;
            }
            set
            {
                Settings.Default.notification_custom_achievement_fade_in = value;
                Settings.Default.Save();
            }
        }
        private int CustomAchievementOut
        {
            get
            {
                return Settings.Default.notification_custom_achievement_fade_out;
            }
            set
            {
                Settings.Default.notification_custom_achievement_fade_out = value;
                Settings.Default.Save();
            }
        }
        private int CustomMasteryIn
        {
            get
            {
                return Settings.Default.notification_custom_mastery_fade_in;
            }
            set
            {
                Settings.Default.notification_custom_mastery_fade_in = value;
                Settings.Default.Save();
            }
        }
        private int CustomMasteryOut
        {
            get
            {
                return Settings.Default.notification_custom_mastery_fade_out;
            }
            set
            {
                Settings.Default.notification_custom_mastery_fade_out = value;
                Settings.Default.Save();
            }
        }
        private string CustomAchievementFile
        {
            set
            {
                Settings.Default.notification_custom_achievement_file = value;
                Settings.Default.Save();
            }
            get
            {
                if (!string.IsNullOrEmpty(Settings.Default.notification_custom_achievement_file) && !File.Exists(Settings.Default.notification_custom_achievement_file))
                {
                    Settings.Default.notification_custom_achievement_file = string.Empty;
                    Settings.Default.Save();
                    Invoke((MethodInvoker)delegate
                    {
                        this.useCustomAchievementCheckbox.Checked = false;
                    });
                }

                return Settings.Default.notification_custom_achievement_file;
            }
        }
        private string CustomMasteryFile
        {
            set
            {
                Settings.Default.notification_custom_mastery_file = value;
                Settings.Default.Save();
            }
            get
            {
                if (!string.IsNullOrEmpty(Settings.Default.notification_custom_mastery_file) && !File.Exists(Settings.Default.notification_custom_mastery_file))
                {
                    Settings.Default.notification_custom_mastery_file = string.Empty;
                    Settings.Default.Save();

                    Invoke((MethodInvoker)delegate
                    {
                        this.useCustomMasteryCheckbox.Checked = false;
                    });
                }

                return Settings.Default.notification_custom_mastery_file;
            }
        }

        private FontFamily FocusFontFamily
        {
            get
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily font in familyArray)
                {
                    if (font.Name.Equals(Settings.Default.focus_font_family_name))
                    {
                        return font;
                    }
                }

                Settings.Default.focus_font_family_name = familyArray[0].Name;
                Settings.Default.Save();

                return familyArray[0];
            }
            set
            {
                Settings.Default.focus_font_family_name = value.Name;
                Settings.Default.Save();

                if (!FocusWindow.IsDisposed)
                {
                    FocusWindow.SetFontFamily(value.Name);
                }
            }
        }
        private string FocusFontColor
        {
            get
            {
                return Settings.Default.focus_font_color_hex_code;
            }
            set
            {
                Settings.Default.focus_font_color_hex_code = value;
                Settings.Default.Save();

                if (!FocusWindow.IsDisposed)
                {
                    FocusWindow.SetFontColor(value);
                }
            }
        }
        private string FocusFontOutlineColor
        {
            get
            {
                return Settings.Default.focus_font_outline_color_hex;
            }
            set
            {
                Settings.Default.focus_font_outline_color_hex = value;
                Settings.Default.Save();

                if (!FocusWindow.IsDisposed)
                {
                    FocusWindow.SetFontOutline(value, FocusFontOutlineSize);
                }
            }
        }
        private int FocusFontOutlineSize
        {
            get
            {
                return Settings.Default.notification_font_outline_size;
            }
            set
            {
                Settings.Default.notification_font_outline_size = value;
                Settings.Default.Save();

                if (!FocusWindow.IsDisposed)
                {
                    FocusWindow.SetFontOutline(FocusFontOutlineColor, value);
                }
            }
        }
        private string FocusBackgroundColor
        {
            get
            {
                return Settings.Default.focus_background_color;
            }
            set
            {
                Settings.Default.focus_background_color = value;
                Settings.Default.Save();

                if (!FocusWindow.IsDisposed)
                {
                    FocusWindow.SetBackgroundColor(value);
                }
            }
        }

        private Achievement CurrentlyViewingAchievement;
        private Achievement CurrentlyFocusedAchievement;
        private int CurrentlyFocusedIndex;

        private static List<Achievement> LockedAchievements;
        private static List<Achievement> UnlockedAchievements;
        private static List<Achievement> OldUnlockedAchievements;

        private static SupportPage supportPage;

        private static Timer UserAndGameUpdateTimer;
        private static int UserAndGameTimerCounter;

        private static StatsLayoutWindow StatsWindow;
        private static FocusLayoutWindow FocusWindow;
        private static NotificationLayoutWindow NotificationsWindow;

        private bool ShouldRun;

        private int RAErrors;
        private HFC_EssentialsClient hFC_EssentialsClient;

        public event PropertyChangedEventHandler PropertyChanged;
        public MainPage()
        {
            InitializeComponent();
            AutoUpdate();
            LoadProperties();
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
            UserAndGameUpdateTimer = new Timer();
            UserAndGameUpdateTimer.Tick += new EventHandler(CheckAchievements);
            UserAndGameUpdateTimer.Interval = 1000;

            UnlockedAchievements = new List<Achievement>();
            LockedAchievements = new List<Achievement>();

            CreateStatsWindow();
            CreateFocusWindow();
            CreateNotificationsWindow();

            List<string> fonts = new List<string>();

            foreach (FontFamily font in FontFamily.Families)
            {
                fonts.Add(font.Name);
            }

            this.statsFontComboBox.Items.AddRange(fonts.ToArray());
            this.focusFontComboBox.Items.AddRange(fonts.ToArray());
            this.notificationsFontComboBox.Items.AddRange(fonts.ToArray());

            this.statsFontComboBox.Text = Settings.Default.stats_font_family_name;
            this.focusFontComboBox.Text = Settings.Default.focus_font_family_name;
            this.notificationsFontComboBox.Text = Settings.Default.notification_font_family_name;
        }

        protected async override void OnLoad(EventArgs e)
        {
            CreateDataBindings();

            if (CanStart())
            {
                await InitializePlayerData();

                if (this.autoStartCheckbox.Checked)
                {
                    this.StartButton_Click(null, null);
                }
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

            SetAwardCount();

            this.usernameTextBox.Enabled = false;
            this.apiKeyTextBox.Enabled = false;

            if (UserSummary == null)
            {
                await InitializePlayerData();
            }

            if (this.autoLaunchFocusWindowCheckBox.Checked)
            {
                FocusWindow.Show();
            }

            if (this.autoLaunchStatsWindowCheckbox.Checked)
            {
                StatsWindow.Show();
            }

            if (this.autoLaunchNotificationsWindowCheckbox.Checked)
            {
                NotificationsWindow.Show();
            }

            this.showFocusWindowButton.Enabled = true;
            this.showNotificationsWindowButton.Enabled = true;
            this.showStatsWindowButton.Enabled = true;

            StartTimer();

            Settings.Default.ra_username = this.usernameTextBox.Text;
            Settings.Default.ra_key = this.apiKeyTextBox.Text;
            Settings.Default.Save();
        }

        private async Task InitializePlayerData()
        {
            hFC_EssentialsClient = new HFC_EssentialsClient(this.usernameTextBox.Text, this.apiKeyTextBox.Text);

            UserSummary = await hFC_EssentialsClient.GetUserSummary();

            CurrentGame = await hFC_EssentialsClient.GetGameProgress(UserSummary.GameSummaries[0].GameID.ToString());

            this.userProfilePictureBox.ImageLocation = "https://retroachievements.org/UserPic/" + this.usernameTextBox.Text + ".png";
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            ShouldRun = false;

            UserAndGameUpdateTimer.Stop();

            this.raConnectionStatusPictureBox.Image = Resources.red_button;

            UpdateTimerLabel("Stopped Updating.");
            UpdateRAConnectivityLabel("Stopped checking retroachievements.org");

            this.stopButton.Enabled = false;
            this.showFocusWindowButton.Enabled = CanStart();
            this.showNotificationsWindowButton.Enabled = CanStart();
            this.showStatsWindowButton.Enabled = CanStart();

            this.apiKeyTextBox.Enabled = true;
            this.usernameTextBox.Enabled = true;

            this.startButton.Enabled = CanStart();
        }

        private void CreateStatsWindow()
        {
            StatsWindow = new StatsLayoutWindow();

            StatsWindow.chromiumWebBrowser.LoadHtml(Resources.StatsWindow);
            StatsWindow.chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                StatsWindow.SetRank(UserSummary.Rank);
                StatsWindow.SetPoints(UserSummary.TotalPoints);
                StatsWindow.SetAwards(_awards);
                StatsWindow.SetGameAchievements(GameEarnedAchievements, GameTotalAchievements);
                StatsWindow.SetGamePoints(GameEarnedPoints, GameTotalPoints);
                StatsWindow.SetFontFamily(StatsFontFamily.Name);
                StatsWindow.SetFontColor(StatsFontColor);
                StatsWindow.SetFontOutline(StatsFontOutlineColor, StatsFontOutlineSize);
            });
        }

        private void CreateFocusWindow()
        {
            FocusWindow = new FocusLayoutWindow();

            FocusWindow.chromiumWebBrowser.LoadHtml(Resources.FocusWindow);
            FocusWindow.chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                FocusWindow.SetFocus(CurrentlyFocusedAchievement);
                FocusWindow.SetFontFamily(FocusFontFamily.Name);
                FocusWindow.SetFontColor(FocusFontColor);
                FocusWindow.SetFontOutline(FocusFontOutlineColor, FocusFontOutlineSize);
                FocusWindow.SetBackgroundColor(FocusBackgroundColor);
            });
        }

        private void CreateNotificationsWindow()
        {
            NotificationsWindow = new NotificationLayoutWindow();

            NotificationsWindow.chromiumWebBrowser.LoadHtml(Resources.NotificationWindow);
            NotificationsWindow.chromiumWebBrowser.RequestHandler = new CustomRequestHandler()
            {
                customAchievementEnabled = CustomAchievementEnabled,
                customMasteryEnabled = CustomMasteryEnabled
            };
            NotificationsWindow.chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                NotificationsWindow.SetFontFamily(NotificationsFontFamily.Name);
                NotificationsWindow.SetFontColor(NotificationsFontColor);
                NotificationsWindow.SetFontOutline(NotificationsFontOutlineColor, NotificationsFontOutlineSize);
                NotificationsWindow.SetBackgroundColor(NotificationsBackgroundColor);
                NotificationsWindow.PromptUserInput();
                NotificationsWindow.SetAchievementWidth(this.useCustomAchievementCheckbox.Checked ? Convert.ToInt32(CustomAchievementScale * GetVideoWidth(CustomAchievementFile)) : 1000);
                NotificationsWindow.SetMasteryWidth(this.useCustomMasteryCheckbox.Checked ? Convert.ToInt32(CustomMasteryScale * GetVideoWidth(CustomMasteryFile)) : 1000);
                NotificationsWindow.SetAchievementTop(this.useCustomAchievementCheckbox.Checked ? CustomAchievementY : 5);
                NotificationsWindow.SetMasteryTop(this.useCustomMasteryCheckbox.Checked ? CustomMasteryY : 5);
                NotificationsWindow.SetAchievementLeft(this.useCustomAchievementCheckbox.Checked ? CustomAchievementX : -15);
                NotificationsWindow.SetMasteryLeft(this.useCustomMasteryCheckbox.Checked ? CustomMasteryX : -15);
            });
        }

        private bool CanStart()
        {
            return !(string.IsNullOrEmpty(this.usernameTextBox.Text)
                || string.IsNullOrEmpty(this.apiKeyTextBox.Text));
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

            if (ShouldRun)
            {
                UserAndGameUpdateTimer.Start();
            }
        }

        private void SortAchievements()
        {
            if (CurrentGame.Achievements != null)
            {
                List<Achievement> tempLockedAchievements = CurrentGame.Achievements.FindAll(x => { return !x.DateEarned.HasValue; });
                List<Achievement> tempUnlockedAchievements = CurrentGame.Achievements.FindAll(x => { return x.DateEarned.HasValue; });

                tempUnlockedAchievements.Sort(delegate (Achievement x, Achievement y) { return y.DateEarned.Value.CompareTo(x.DateEarned.Value); });
                tempLockedAchievements.Sort();

                SetLockedAchievements(tempLockedAchievements.ToList());
                UnlockedAchievements = tempUnlockedAchievements.ToList();
            }

            if (OldUnlockedAchievements.Count < UnlockedAchievements.Count)
            {
                if (LockedAchievements.Count == 0)
                {
                    CurrentlyFocusedIndex = 0;
                    SetFocusButton_Click(null, null);
                }
                else if (LockedAchievements.IndexOf(CurrentlyFocusedAchievement) > 0)
                {
                    CurrentlyFocusedIndex = LockedAchievements.IndexOf(CurrentlyFocusedAchievement);
                }
                else
                {
                    CurrentlyFocusedIndex = LockedAchievements.IndexOf(CurrentlyViewingAchievement);
                    SetFocusButton_Click(null, null);
                }
            }
        }

        private void MainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (FocusWindow != null && !FocusWindow.IsDisposed)
            {
                FocusWindow.Dispose();
            }
            if (StatsWindow != null && !StatsWindow.IsDisposed)
            {
                StatsWindow.Dispose();
            }
            if (NotificationsWindow != null && !NotificationsWindow.IsDisposed)
            {
                NotificationsWindow.Dispose();
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

            this.usernameTextBox.Text = Settings.Default.ra_username;
            this.apiKeyTextBox.Text = Settings.Default.ra_key;
            this.autoStartCheckbox.Checked = Settings.Default.auto_start_checked;
            this.autoLaunchFocusWindowCheckBox.Checked = Settings.Default.auto_focus;
            this.autoLaunchStatsWindowCheckbox.Checked = Settings.Default.auto_stats;
            this.autoLaunchNotificationsWindowCheckbox.Checked = Settings.Default.auto_notifications;

            this.statsFontColorDisplayBox.BackColor = ColorTranslator.FromHtml(StatsFontColor);
            this.statsFontOutlineColorDisplayBox.BackColor = ColorTranslator.FromHtml(StatsFontOutlineColor);
            this.statsFontOutlineCheckbox.Checked = Settings.Default.stats_font_outline_enabled;
            this.statsFontOutlineSizeUpDown.Value = Settings.Default.stats_font_outline_size;

            this.focusBackgroundColorDisplayBox.BackColor = ColorTranslator.FromHtml(FocusBackgroundColor);
            this.focusFontColorDisplayBox.BackColor = ColorTranslator.FromHtml(FocusFontColor);
            this.focusFontOutlineColorDisplayBox.BackColor = ColorTranslator.FromHtml(FocusFontOutlineColor);
            this.focusFontOutlineCheckbox.Checked = Settings.Default.focus_font_outline_enabled;
            this.focusFontOutlineSizeUpDown.Value = Settings.Default.focus_font_outline_size;

            this.notificationsBackgroundColorDisplayBox.BackColor = ColorTranslator.FromHtml(NotificationsBackgroundColor);
            this.notificationsFontColorDisplayBox.BackColor = ColorTranslator.FromHtml(NotificationsFontColor);
            this.notificationsFontOutlineColorDisplayBox.BackColor = ColorTranslator.FromHtml(NotificationsFontOutlineColor);
            this.notificationsFontOutlineCheckbox.Checked = Settings.Default.notification_font_outline_enabled;
            this.notificationsFontOutlineSizeUpDown.Value = Settings.Default.notification_font_outline_size;

            if (CustomAchievementEnabled && string.IsNullOrEmpty(Settings.Default.notification_custom_achievement_file))
            {
                Settings.Default.notification_custom_achievement_enable = false;
            }
            if (CustomMasteryEnabled && string.IsNullOrEmpty(Settings.Default.notification_custom_mastery_file))
            {
                Settings.Default.notification_custom_achievement_enable = false;
            }

            Settings.Default.Save();

            this.useCustomAchievementCheckbox.Checked = CustomAchievementEnabled;
            this.selectCustomAchievementButton.Enabled = CustomAchievementEnabled;
            this.customAchievementXNumericUpDown.Enabled = false;
            this.customAchievementYNumericUpDown.Enabled = false;
            this.scaleAchievementNumericUpDown.Enabled = false;
            this.acheivementEditOutlineCheckbox.Enabled = false;
            this.inAchievementNumericUpDown.Enabled = false;
            this.outAchievementNumericUpDown.Enabled = false;
            this.xPositionLabel1.Enabled = false;
            this.yPositionLabel1.Enabled = false;
            this.scaleLabel1.Enabled = false;
            this.inLabel1.Enabled = false;
            this.outLabel1.Enabled = false;

            this.useCustomMasteryCheckbox.Checked = CustomMasteryEnabled;
            this.selectCustomMasteryNotificationButton.Enabled = CustomMasteryEnabled;
            this.customMasteryXNumericUpDown.Enabled = false;
            this.customMasteryYNumericUpDown.Enabled = false;
            this.scaleMasteryNumericUpDown.Enabled = false;
            this.masteryEditOultineCheckbox.Enabled = false;
            this.inMasteryNumericUpDown.Enabled = false;
            this.outMasteryNumericUpDown.Enabled = false;
            this.xPositionLabel2.Enabled = false;
            this.yPositionLabel2.Enabled = false;
            this.scaleLabel2.Enabled = false;
            this.inLabel2.Enabled = false;
            this.outLabel2.Enabled = false;

            this.customAchievementXNumericUpDown.Value = CustomAchievementX;
            this.customAchievementYNumericUpDown.Value = CustomAchievementY;

            this.customMasteryXNumericUpDown.Value = CustomMasteryX;
            this.customMasteryYNumericUpDown.Value = CustomMasteryY;

            if (CustomAchievementScale > this.scaleAchievementNumericUpDown.Maximum)
            {
                CustomAchievementScale = this.scaleAchievementNumericUpDown.Maximum;
            }

            if (CustomMasteryScale > this.scaleMasteryNumericUpDown.Maximum)
            {
                CustomMasteryScale = this.scaleMasteryNumericUpDown.Maximum;
            }

            this.scaleAchievementNumericUpDown.Value = CustomAchievementScale;
            this.scaleMasteryNumericUpDown.Value = CustomMasteryScale;

            this.inAchievementNumericUpDown.Value = CustomAchievementIn;
            this.outAchievementNumericUpDown.Value = CustomAchievementOut;
            this.inMasteryNumericUpDown.Value = CustomMasteryIn;
            this.outMasteryNumericUpDown.Value = CustomMasteryOut;

            this.notificationsFontOutlineCheckbox.Checked = Settings.Default.notification_font_outline_enabled;

            this.showAchievementButton.Click += ShowAchievementButton_Click;
            this.showGameMasteryButton.Click += ShowGameMasteryButton_Click;

            this.selectCustomAchievementButton.Click += SelectCustomAchievementButton_Click;
            this.selectCustomMasteryNotificationButton.Click += SelectCustomMasteryNotificationButton_Click;
            this.scaleAchievementNumericUpDown.ValueChanged += ScaleAchievementNumericUpDown_ValueChanged;
            this.scaleMasteryNumericUpDown.ValueChanged += ScaleMasteryNumericUpDown_ValueChanged;

            this.useCustomAchievementCheckbox.CheckedChanged += UseCustomAchievementCheckbox_CheckedChanged;
            this.useCustomMasteryCheckbox.CheckedChanged += UseCustomMasteryCheckbox_CheckedChanged;
            this.acheivementEditOutlineCheckbox.CheckedChanged += AcheivementEditOutlineCheckbox_CheckedChanged;
            this.masteryEditOultineCheckbox.CheckedChanged += MasteryEditOultineCheckbox_CheckedChanged;

            this.customAchievementXNumericUpDown.ValueChanged += CustomAchievementXNumericUpDown_ValueChanged;
            this.customAchievementYNumericUpDown.ValueChanged += CustomAchievementYNumericUpDown_ValueChanged;
            this.customMasteryXNumericUpDown.ValueChanged += CustomMasteryXNumericUpDown_ValueChanged;
            this.customMasteryYNumericUpDown.ValueChanged += CustomMasteryYNumericUpDown_ValueChanged;
            this.outAchievementNumericUpDown.ValueChanged += OutAchievementNumericUpDown_ValueChanged;
            this.inAchievementNumericUpDown.ValueChanged += InAchievementNumericUpDown_ValueChanged;
            this.outMasteryNumericUpDown.ValueChanged += OutMasteryNumericUpDown_ValueChanged;
            this.inMasteryNumericUpDown.ValueChanged += InMasteryNumericUpDown_ValueChanged;

            this.setFocusButton.Click += SetFocusButton_Click;
            this.hideFocusButton.Click += HideFocusButton_Click;
            this.focusAchievementButtonLeft.Click += MoveFocusIndexLeft;
            this.focusAchievementButtonRight.Click += MoveFocusIndexRight;

            this.notificationsFontComboBox.SelectedIndexChanged += NotificationsFontSelectionIndex_Changed;
            this.notificationsBackgroundColorPickerButton.Click += NotificationsBackgroundColorPickerButton_Click;
            this.notificationsFontColorPickerButton.Click += NotificationsFontColorPickerButton_Click;
            this.notificationsFontOutlineCheckbox.CheckedChanged += NotificationsFontOutlineCheckbox_CheckedChanged;
            this.notificationsFontOutlineColorPickerButton.Click += NotificationsFontOutlineColorPickerButton_Click;
            this.notificationsFontOutlineSizeUpDown.ValueChanged += NotificationsFontOutlineSizeUpDown_ValueChanged;

            this.focusFontComboBox.SelectedIndexChanged += FocusFontSelectionIndex_Changed;
            this.focusBackgroundColorPickerButton.Click += FocusBackgroundColorPickerButton_Click;
            this.focusFontColorPickerButton.Click += FocusFontColorPickerButton_Click;
            this.focusFontOutlineCheckbox.CheckedChanged += FocusFontOutlineCheckbox_CheckedChanged;
            this.focusFontOutlineColorPickerButton.Click += FocusFontOutlineColorPickerButton_Click;
            this.focusFontOutlineSizeUpDown.ValueChanged += FocusFontOutlineSizeUpDown_ValueChanged;

            this.statsFontComboBox.SelectedIndexChanged += StatsFontSelectionIndex_Changed;
            this.statsFontColorPickerButton.Click += StatsFontColorPickerButton_Click;
            this.statsFontOutlineCheckbox.CheckedChanged += StatsFontOutlineCheckbox_CheckedChanged;
            this.statsFontOutlineColorPickerButton.Click += StatsFontOutlineColorPickerButton_Click;
            this.statsFontOutlineSizeUpDown.ValueChanged += StatsFontOutlineSizeUpDown_ValueChanged;

            this.autoStartCheckbox.CheckedChanged += AutoStart_CheckedChanged;
            this.usernameTextBox.TextChanged += RequiredField_TextChange;
            this.apiKeyTextBox.TextChanged += RequiredField_TextChange;
        }

        private async void SetAwardCount()
        {
            UpdateRAConnectivityLabel("Calling retroachievements.org for award count...");

            string url = "http://retroachievements.org/user/" + usernameTextBox.Text;

            HtmlWeb web = new HtmlWeb();

            HtmlAgilityPack.HtmlDocument doc = await web.LoadFromWebAsync(url);

            HtmlNode siteAwardsNode = doc.GetElementbyId("siteawards");

            if (siteAwardsNode == null)
            {
                UpdateRAConnectivityLabel("Encountered problems checking retroachievements.org.");

                return;
            }
            this.raConnectionStatusPictureBox.Image = Resources.green_button;

            HtmlNodeCollection htmlNodeCollections = siteAwardsNode.SelectNodes(XPathExpression.Compile("//div[contains(@class,'trophyimage')]"));

            Awards = htmlNodeCollections == null ? 0 : htmlNodeCollections.Count;

            UpdateRAConnectivityLabel("");
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
            if (!FocusWindow.Visible)
            {
                CreateFocusWindow();
                FocusWindow.Show();
            }
        }

        private void ShowStatsWindowButton_Click(object sender, EventArgs e)
        {
            if (!StatsWindow.Visible)
            {
                CreateStatsWindow();
                StatsWindow.Show();
            }
        }

        private void ShowNotificationsWindowButton_Click(object sender, EventArgs e)
        {
            if (!NotificationsWindow.Visible)
            {
                CreateNotificationsWindow();
                NotificationsWindow.Show();
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

        private void StatsFontSelectionIndex_Changed(object sender, EventArgs e)
        {
            StatsFontFamily = FontFamily.Families[this.statsFontComboBox.SelectedIndex];
        }

        private void StatsFontColorPickerButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                statsFontColorDisplayBox.BackColor = colorDialog1.Color;

                StatsFontColor = HexConverter(colorDialog1.Color);
            }
        }

        private void StatsFontOutlineColorPickerButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                statsFontOutlineColorDisplayBox.BackColor = colorDialog1.Color;

                StatsFontOutlineColor = HexConverter(colorDialog1.Color);
            }
        }

        private void StatsFontOutlineCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = this.statsFontOutlineCheckbox.Checked;

            this.statsFontOutlineColorDisplayBox.Enabled = isChecked;
            this.statsFontOutlineColorPickerButton.Enabled = isChecked;
            this.statsFontOutlineSizeUpDown.Enabled = isChecked;

            if (isChecked)
            {
                this.statsFontOutlineColorDisplayBox.BackColor = ColorTranslator.FromHtml(StatsFontOutlineColor);
                this.statsFontOutlineSizeUpDown.Value = StatsFontOutlineSize;

                StatsWindow.SetFontOutline(StatsFontOutlineColor, StatsFontOutlineSize);
            }
            else
            {
                StatsWindow.SetFontOutline("", 0);
            }

            Settings.Default.stats_font_outline_enabled = isChecked;
            Settings.Default.Save();
        }

        private void StatsFontOutlineSizeUpDown_ValueChanged(object sender, EventArgs e)
        {
            StatsFontOutlineSize = Convert.ToInt32(((NumericUpDown)sender).Value.ToString());
        }
        private void UseCustomAchievementCheckbox_CheckedChanged(object sender, EventArgs eventArgs)
        {
            CustomAchievementEnabled = ((CheckBox)sender).Checked;

            this.useCustomAchievementCheckbox.Checked = CustomAchievementEnabled;
            this.selectCustomAchievementButton.Enabled = CustomAchievementEnabled;
            this.acheivementEditOutlineCheckbox.Enabled = CustomAchievementEnabled;

            this.customAchievementXNumericUpDown.Enabled = false;
            this.customAchievementYNumericUpDown.Enabled = false;
            this.scaleAchievementNumericUpDown.Enabled = false;
            this.inAchievementNumericUpDown.Enabled = false;
            this.outAchievementNumericUpDown.Enabled = false;

            this.masteryEditOultineCheckbox.Checked = false;

            this.xPositionLabel1.Enabled = false;
            this.yPositionLabel1.Enabled = false;
            this.scaleLabel1.Enabled = false;
            this.inLabel1.Enabled = false;
            this.outLabel1.Enabled = false;

            NotificationsWindow.Dispose();
            CreateNotificationsWindow();
            NotificationsWindow.chromiumWebBrowser.RequestHandler = new CustomRequestHandler() { customAchievementEnabled = CustomAchievementEnabled, customMasteryEnabled = CustomMasteryEnabled };

            if (!CustomAchievementEnabled)
            {
                NotificationsWindow.DisableAchievementEdit();

                this.acheivementEditOutlineCheckbox.Checked = false;
            }
            else if (string.IsNullOrEmpty(CustomAchievementFile))
            {
                SelectCustomAchievementButton_Click(null, null);
            }

            if (!NotificationsWindow.IsDisposed)
            {
                NotificationsWindow.SetAchievementWidth(this.useCustomAchievementCheckbox.Checked ? Convert.ToInt32(CustomAchievementScale * GetVideoWidth(CustomAchievementFile)) : 1200);
            }

            if (this.autoLaunchNotificationsWindowCheckbox.Checked)
            {
                NotificationsWindow.Show();
            }
        }

        private void UseCustomMasteryCheckbox_CheckedChanged(object sender, EventArgs eventArgs)
        {
            CustomMasteryEnabled = ((CheckBox)sender).Checked;

            this.useCustomMasteryCheckbox.Checked = CustomMasteryEnabled;
            this.selectCustomMasteryNotificationButton.Enabled = CustomMasteryEnabled;
            this.masteryEditOultineCheckbox.Enabled = CustomMasteryEnabled;

            this.customMasteryXNumericUpDown.Enabled = false;
            this.customMasteryYNumericUpDown.Enabled = false;
            this.scaleMasteryNumericUpDown.Enabled = false;
            this.inMasteryNumericUpDown.Enabled = false;
            this.outMasteryNumericUpDown.Enabled = false;

            this.masteryEditOultineCheckbox.Checked = false;

            this.xPositionLabel2.Enabled = false;
            this.yPositionLabel2.Enabled = false;
            this.scaleLabel2.Enabled = false;
            this.inLabel2.Enabled = false;
            this.outLabel2.Enabled = false;

            NotificationsWindow.Dispose();
            CreateNotificationsWindow();
            NotificationsWindow.chromiumWebBrowser.RequestHandler = new CustomRequestHandler() { customAchievementEnabled = CustomAchievementEnabled, customMasteryEnabled = CustomMasteryEnabled };

            if (!CustomMasteryEnabled)
            {
                NotificationsWindow.DisableMasteryEdit();

                this.masteryEditOultineCheckbox.Checked = false;
            }
            else if (string.IsNullOrEmpty(CustomMasteryFile))
            {
                SelectCustomMasteryNotificationButton_Click(null, null);
            }

            if (!NotificationsWindow.IsDisposed)
            {
                NotificationsWindow.SetMasteryWidth(this.useCustomMasteryCheckbox.Checked ? Convert.ToInt32(CustomMasteryScale * GetVideoWidth(CustomMasteryFile)) : 1200);
            }

            if (this.autoLaunchNotificationsWindowCheckbox.Checked)
            {
                NotificationsWindow.Show();
            }
        }

        private void AcheivementEditOutlineCheckbox_CheckedChanged(object sender, EventArgs eventArgs)
        {
            if (((CheckBox)sender).Checked)
            {
                NotificationsWindow.EnableAchievementEdit();
                NotificationsWindow.SendAchievementNotification(new Achievement()
                {
                    Title = "Thrilling!!!!",
                    Description = "Color every bit of Dinosaur 2. [Must color white if leaving white]",
                    BadgeNumber = "49987",
                    Points = 1
                });

                this.customAchievementXNumericUpDown.Enabled = true;
                this.customAchievementYNumericUpDown.Enabled = true;
                this.scaleAchievementNumericUpDown.Enabled = true;
                this.inAchievementNumericUpDown.Enabled = true;
                this.outAchievementNumericUpDown.Enabled = true;

                this.xPositionLabel1.Enabled = true;
                this.yPositionLabel1.Enabled = true;
                this.scaleLabel1.Enabled = true;
                this.inLabel1.Enabled = true;
                this.outLabel1.Enabled = true;
            }
            else
            {
                NotificationsWindow.DisableAchievementEdit();

                this.customAchievementXNumericUpDown.Enabled = false;
                this.customAchievementYNumericUpDown.Enabled = false;
                this.scaleAchievementNumericUpDown.Enabled = false;
                this.inAchievementNumericUpDown.Enabled = false;
                this.outAchievementNumericUpDown.Enabled = false;

                this.xPositionLabel1.Enabled = false;
                this.yPositionLabel1.Enabled = false;
                this.scaleLabel1.Enabled = false;
                this.inLabel1.Enabled = false;
                this.outLabel1.Enabled = false;
            }

            NotificationsWindow.SetAchievementLeft(this.useCustomAchievementCheckbox.Checked ? CustomAchievementX : -15);
            NotificationsWindow.SetAchievementTop(this.useCustomAchievementCheckbox.Checked ? CustomAchievementY : 50);

            var width = this.useCustomAchievementCheckbox.Checked ? GetVideoWidth(CustomAchievementFile) : 1200;
            NotificationsWindow.SetAchievementWidth(this.useCustomAchievementCheckbox.Checked ? Convert.ToInt32(width * CustomAchievementScale) : width);
        }

        private void MasteryEditOultineCheckbox_CheckedChanged(object sender, EventArgs eventArgs)
        {
            if (((CheckBox)sender).Checked)
            {
                NotificationsWindow.EnableMasteryEdit();
                NotificationsWindow.SendMasteryNotification(UserSummary.GameSummaries[0], UserSummary.GameAchievementSummaries[0]);

                this.customMasteryXNumericUpDown.Enabled = true;
                this.customMasteryYNumericUpDown.Enabled = true;
                this.scaleMasteryNumericUpDown.Enabled = true;
                this.inMasteryNumericUpDown.Enabled = true;
                this.outMasteryNumericUpDown.Enabled = true;

                this.xPositionLabel2.Enabled = true;
                this.yPositionLabel2.Enabled = true;
                this.scaleLabel2.Enabled = true;
                this.inLabel2.Enabled = true;
                this.outLabel2.Enabled = true;
            }
            else
            {
                NotificationsWindow.DisableMasteryEdit();

                this.customMasteryXNumericUpDown.Enabled = false;
                this.customMasteryYNumericUpDown.Enabled = false;
                this.scaleMasteryNumericUpDown.Enabled = false;
                this.inMasteryNumericUpDown.Enabled = false;
                this.outMasteryNumericUpDown.Enabled = false;

                this.xPositionLabel2.Enabled = false;
                this.yPositionLabel2.Enabled = false;
                this.scaleLabel2.Enabled = false;
                this.inLabel2.Enabled = false;
                this.outLabel2.Enabled = false;
            }

            NotificationsWindow.SetMasteryLeft(this.useCustomMasteryCheckbox.Checked ? CustomMasteryX : -15);
            NotificationsWindow.SetMasteryTop(this.useCustomMasteryCheckbox.Checked ? CustomMasteryY : 50);

            var width = this.useCustomMasteryCheckbox.Checked ? GetVideoWidth(CustomMasteryFile) : 1200;
            NotificationsWindow.SetMasteryWidth(this.useCustomMasteryCheckbox.Checked ? Convert.ToInt32(width * CustomMasteryScale) : width);
        }

        private void CustomAchievementXNumericUpDown_ValueChanged(object sender, EventArgs eventArgs)
        {
            CustomAchievementX = Convert.ToInt32(((NumericUpDown)sender).Value);
        }

        private void CustomAchievementYNumericUpDown_ValueChanged(object sender, EventArgs eventArgs)
        {
            CustomAchievementY = Convert.ToInt32(((NumericUpDown)sender).Value);
        }

        private void CustomMasteryXNumericUpDown_ValueChanged(object sender, EventArgs eventArgs)
        {
            CustomMasteryX = Convert.ToInt32(((NumericUpDown)sender).Value);
        }

        private void CustomMasteryYNumericUpDown_ValueChanged(object sender, EventArgs eventArgs)
        {
            CustomMasteryY = Convert.ToInt32(((NumericUpDown)sender).Value);
        }

        private void ScaleAchievementNumericUpDown_ValueChanged(object sender, EventArgs eventArgs)
        {
            CustomAchievementScale = this.scaleAchievementNumericUpDown.Value;
        }

        private void ScaleMasteryNumericUpDown_ValueChanged(object sender, EventArgs eventArgs)
        {
            CustomMasteryScale = this.scaleMasteryNumericUpDown.Value;
        }

        private void OutAchievementNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CustomAchievementOut = Convert.ToInt32(((NumericUpDown)sender).Value);
        }

        private void InAchievementNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CustomAchievementIn = Convert.ToInt32(((NumericUpDown)sender).Value);
        }

        private void OutMasteryNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CustomMasteryOut = Convert.ToInt32(((NumericUpDown)sender).Value);
        }

        private void InMasteryNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CustomMasteryIn = Convert.ToInt32(((NumericUpDown)sender).Value);
        }
        private void NotificationsFontSelectionIndex_Changed(object sender, EventArgs e)
        {
            NotificationsFontFamily = FontFamily.Families[this.notificationsFontComboBox.SelectedIndex];
        }

        private void NotificationsFontColorPickerButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.notificationsFontColorDisplayBox.BackColor = colorDialog1.Color;

                NotificationsFontColor = HexConverter(colorDialog1.Color);
            }
        }

        private void NotificationsFontOutlineColorPickerButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                NotificationsFontOutlineColor = HexConverter(colorDialog1.Color);
            }
        }

        private void NotificationsBackgroundColorPickerButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                NotificationsBackgroundColor = HexConverter(colorDialog1.Color);
            }
        }

        private void NotificationsFontOutlineCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = this.notificationsFontOutlineCheckbox.Checked;

            this.notificationsFontOutlineColorDisplayBox.Enabled = isChecked;
            this.notificationsFontOutlineColorPickerButton.Enabled = isChecked;
            this.notificationsFontOutlineSizeUpDown.Enabled = isChecked;

            if (isChecked)
            {
                this.notificationsFontOutlineColorDisplayBox.BackColor = ColorTranslator.FromHtml(NotificationsFontOutlineColor);
                this.notificationsFontOutlineSizeUpDown.Value = NotificationsFontOutlineSize;

                NotificationsWindow.SetFontOutline(NotificationsFontOutlineColor, NotificationsFontOutlineSize);
            }
            else
            {
                NotificationsWindow.SetFontOutline("", 0);
            }

            Settings.Default.notification_font_outline_enabled = isChecked;
            Settings.Default.Save();
        }

        private void NotificationsFontOutlineSizeUpDown_ValueChanged(object sender, EventArgs e)
        {
            NotificationsFontOutlineSize = Convert.ToInt32(((NumericUpDown)sender).Value.ToString());
        }

        private void SelectCustomAchievementButton_Click(object sender, EventArgs eventArgs)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CustomAchievementFile = this.openFileDialog1.FileName;
            }
            else
            {
                if (this.useCustomAchievementCheckbox.Checked && string.IsNullOrEmpty(CustomAchievementFile))
                {
                    this.useCustomAchievementCheckbox.Checked = false;
                }
            }
        }

        private void SelectCustomMasteryNotificationButton_Click(object sender, EventArgs eventArgs)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CustomMasteryFile = this.openFileDialog1.FileName;
            }
            else
            {
                if (this.useCustomMasteryCheckbox.Checked && string.IsNullOrEmpty(CustomMasteryFile))
                {
                    this.useCustomMasteryCheckbox.Checked = false;
                }
            }
        }
        private void ShowAchievementButton_Click(object sender, EventArgs eventArgs)
        {
            if (UserSummary.RecentAchievements != null
                && UserSummary.RecentAchievements.Count > 0
                && UserSummary.RecentAchievements[0] != null)
            {
                NotificationsWindow.EnqueueAchievementNotification(UserSummary.RecentAchievements[0],
                    this.useCustomAchievementCheckbox.Checked ? GetVideoDuration(CustomAchievementFile) : 7000,
                            this.useCustomAchievementCheckbox.Checked ? CustomAchievementIn : 0,
                            this.useCustomAchievementCheckbox.Checked ? CustomAchievementOut : 5600);
            }
            else
            {
                NotificationsWindow.EnqueueAchievementNotification(
                     new Achievement()
                     {
                         Title = "Thrilling!!!!",
                         Description = "Color every bit of Dinosaur 2. [Must color white if leaving white]",
                         BadgeNumber = "49987",
                         Points = 1
                     }, this.useCustomAchievementCheckbox.Checked ? GetVideoDuration(CustomAchievementFile) : 7000,
                            this.useCustomAchievementCheckbox.Checked ? CustomAchievementIn : 0,
                            this.useCustomAchievementCheckbox.Checked ? CustomAchievementOut : 5600);
            }

            NotificationsWindow.FireNotifications();
        }

        private void ShowGameMasteryButton_Click(object sender, EventArgs eventArgs)
        {
            NotificationsWindow.EnqueueMasteryNotification(UserSummary.GameSummaries[0],
                UserSummary.GameAchievementSummaries[0],
                this.useCustomMasteryCheckbox.Checked ? GetVideoDuration(CustomMasteryFile) : 11000,
                            this.useCustomMasteryCheckbox.Checked ? CustomMasteryIn : 0,
                            this.useCustomMasteryCheckbox.Checked ? CustomMasteryOut : 5600);

            NotificationsWindow.FireNotifications();
        }

        public void SetLockedAchievements(List<Achievement> achievements)
        {
            if (achievements != null && achievements.Count > 0)
            {
                int gameId = achievements[0].GameId;
                if (LockedAchievements == null || (LockedAchievements.Count > 0 && gameId != LockedAchievements[0].GameId))
                {
                    CurrentlyFocusedIndex = 0;
                    CurrentlyViewingAchievement = null;
                }
            }
            else
            {
                CurrentlyViewingAchievement = null;
            }

            LockedAchievements = achievements.ToList();

            UpdateFocusAchievement();
        }

        public void UpdateFocusAchievement()
        {
            if (this.Visible)
            {
                Invoke((MethodInvoker)delegate
                {
                    UpdateFocusButtons();

                    if (LockedAchievements.Count > 0)
                    {
                        if (CurrentlyFocusedIndex >= LockedAchievements.Count)
                        {
                            CurrentlyFocusedIndex = LockedAchievements.Count - 1;
                        }
                        else if (CurrentlyFocusedIndex < 0)
                        {
                            CurrentlyFocusedIndex = 0;
                        }

                        CurrentlyViewingAchievement = LockedAchievements[CurrentlyFocusedIndex];

                        this.focusAchievementPictureBox.ImageLocation = "https://retroachievements.org/Badge/" + CurrentlyViewingAchievement.BadgeNumber + ".png";
                        this.focusAchievementTitleLabel.Text = CurrentlyViewingAchievement.Title;
                        this.focusAchievementDescriptionLabel.Text = CurrentlyViewingAchievement.Description;
                    }
                    else
                    {
                        CurrentlyFocusedIndex = 0;

                        this.focusAchievementPictureBox.ImageLocation = string.Empty;
                        this.focusAchievementTitleLabel.Text = string.Empty;
                        this.focusAchievementDescriptionLabel.Text = string.Empty;

                        FocusWindow.HideFocus();
                    }
                });
            }
        }

        private void SetFocusButton_Click(object sender, EventArgs e)
        {
            CurrentlyFocusedAchievement = CurrentlyViewingAchievement;
            FocusWindow.SetFocus(CurrentlyFocusedAchievement);
        }

        private void HideFocusButton_Click(object sender, EventArgs e)
        {
            FocusWindow.HideFocus();
        }

        private void FocusFontSelectionIndex_Changed(object sender, EventArgs e)
        {
            FocusFontFamily = FontFamily.Families[this.focusFontComboBox.SelectedIndex];
        }

        private void FocusFontColorPickerButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                FocusFontColor = HexConverter(colorDialog1.Color);
            }
        }

        private void FocusFontOutlineColorPickerButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                focusFontOutlineColorDisplayBox.BackColor = colorDialog1.Color;

                FocusFontOutlineColor = HexConverter(colorDialog1.Color);
            }
        }

        private void FocusBackgroundColorPickerButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                FocusBackgroundColor = HexConverter(colorDialog1.Color);
            }
        }

        private void FocusFontOutlineCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = this.focusFontOutlineCheckbox.Checked;

            this.focusFontOutlineColorDisplayBox.Enabled = isChecked;
            this.focusFontOutlineColorPickerButton.Enabled = isChecked;
            this.focusFontOutlineSizeUpDown.Enabled = isChecked;

            if (isChecked)
            {
                this.focusFontOutlineColorDisplayBox.BackColor = ColorTranslator.FromHtml(FocusFontOutlineColor);
                this.focusFontOutlineSizeUpDown.Value = FocusFontOutlineSize;

                FocusWindow.SetFontOutline(FocusFontOutlineColor, FocusFontOutlineSize);
            }
            else
            {
                FocusWindow.SetFontOutline("", 0);
            }

            Settings.Default.focus_font_outline_enabled = isChecked;
            Settings.Default.Save();
        }

        private void FocusFontOutlineSizeUpDown_ValueChanged(object sender, EventArgs e)
        {
            FocusFontOutlineSize = Convert.ToInt32(((NumericUpDown)sender).Value.ToString());
        }

        private void MoveFocusIndexLeft(object sender, EventArgs e)
        {
            CurrentlyFocusedIndex--;

            if (CurrentlyFocusedIndex < 0)
            {
                CurrentlyFocusedIndex = 0;
            }

            UpdateFocusAchievement();
        }

        private void MoveFocusIndexRight(object sender, EventArgs e)
        {
            CurrentlyFocusedIndex++;

            if (CurrentlyFocusedIndex >= LockedAchievements.Count)
            {
                CurrentlyFocusedIndex = LockedAchievements.Count - 1;
            }

            UpdateFocusAchievement();
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

                if (CurrentlyFocusedIndex == 0)
                {
                    this.focusAchievementButtonLeft.Enabled = false;
                    this.focusAchievementButtonRight.Enabled = LockedAchievements.Count > 1;
                }
                else if (CurrentlyFocusedIndex == LockedAchievements.Count - 1)
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

        private String HexConverter(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        public int GetVideoWidth(string input)
        {
            var inputFile = new MediaFile { Filename = input };
            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
            }

            var frameSize = inputFile.Metadata.VideoData.FrameSize;

            return Convert.ToInt32(frameSize.Substring(0, frameSize.IndexOf("x")));
        }

        private int GetVideoDuration(string input)
        {
            var inputFile = new MediaFile { Filename = input };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
            }

            return Convert.ToInt32(inputFile.Metadata.Duration.TotalMilliseconds);
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

        private void DegradeConnectivity()
        {
            this.raConnectionStatusPictureBox.Image = Resources.yellow_button;

            RAErrors++;

            if (RAErrors > 5)
            {
                this.StopButton_Click(null, null);

                this.raConnectionStatusPictureBox.Image = Resources.red_button;
            }
        }
    }
}
