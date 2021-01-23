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

        private bool NotBooting;

        private int _rank = 0;
        private int _points = 0;
        private int _awards = 0;
        private int _truePoints = 0;
        private float _ratio = 0.0f;

        private int _gameAchievmentsEarned;
        private int _gamePointsEarned;
        private int _gameTruePointsEarned;
        private float _gameRatio = 0.0f;

        private string _gameTitle;
        private string _gameConsole;
        private string _gameDeveloper;
        private string _gamePublisher;
        private string _gameGenre;
        private string _gameReleaseDate;
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
                TruePoints = _userSummary.TotalTruePoints;
                Ratio = (float)TruePoints / (float)Points;

                SetAwardCount();

                GameTotalPoints = _userSummary.GameAchievementSummaries[0].PossibleScore;
                GameTotalTruePoints = _gameProgress.Achievements.Sum(achievement => achievement.TrueRatio);
                GameTotalAchievements = _userSummary.GameAchievementSummaries[0].NumPossibleAchievements;

                GameEarnedPoints = _userSummary.GameAchievementSummaries[0].ScoreAchieved;
                GameEarnedTruePoints = _gameProgress.Achievements.Where(achievement => achievement.DateEarned.HasValue).Sum(achievement => achievement.TrueRatio);
                GameEarnedAchievements = _userSummary.GameAchievementSummaries[0].NumAchievedHardcore;

                GameRatio = (float)GameTotalTruePoints / (float)GameTotalPoints;

                GameInfoTitle = _gameProgress.Title;
                GameInfoConsoleValue = _gameProgress.ConsoleName;
                GameInfoDeveloperValue = _gameProgress.Developer;
                GameInfoPublisherValue = _gameProgress.Publisher;
                GameInfoGenreValue = _gameProgress.Genre;
                GameInfoReleaseDateValue = _gameProgress.Released;

                SortAchievements();

                if (gameChange)
                {
                    CurrentlyFocusedAchievement = CurrentlyViewingAchievement;

                    if (LockedAchievements.Count > 0)
                    {
                        CurrentlyFocusedAchievement = LockedAchievements[0];
                        CurrentlyViewingAchievement = LockedAchievements[0];
                        SetFocusButton_Click(null, null);
                    }

                    if (StreamLabelsGameInfoEnable)
                    {
                        WriteGameInfoStreamLabels();
                    }
                    if (StreamLabelsLastFiveEnable)
                    {
                        WriteLastFiveStreamLabels();
                    }
                    if (StreamLabelsStatsEnable)
                    {
                        WriteStatsStreamLabels();
                    }

                    if (StatsWindow != null && !StatsWindow.IsDisposed)
                    {
                        StatsWindow.SetCompletedValue(GameTotalAchievements == 0 ? 0 : Convert.ToInt32((Convert.ToDecimal(GameEarnedAchievements) / Convert.ToDecimal(GameTotalAchievements)) * 200));
                    }
                }
                else if (UnlockedAchievements.Count > 0)
                {
                    List<Achievement> achievementNotificationList = UnlockedAchievements
                    .FindAll(unlockedAchievement => !OldUnlockedAchievements.Contains(unlockedAchievement))
                    .ToList();

                    if (achievementNotificationList.Count > 0)
                    {
                        achievementNotificationList.Sort();

                        foreach (Achievement achievement in achievementNotificationList)
                        {
                            NotificationsWindow.EnqueueAchievementNotification(achievement,
                                Settings.Default.notification_custom_achievement_enable ? GetVideoDuration(CustomAchievementFile) : 7000,
                                Settings.Default.notification_custom_achievement_enable ? CustomAchievementIn : 0,
                                Settings.Default.notification_custom_achievement_enable ? CustomAchievementOut : 5200);
                        }

                        if (achievementNotificationList.Contains(CurrentlyFocusedAchievement))
                        {
                            FocusWindow.SetFocus(CurrentlyFocusedAchievement);

                            if (StreamLabelsFocusEnable)
                            {
                                WriteFocusStreamLabels();
                            }
                        }

                        if (UnlockedAchievements.Count == CurrentGame.Achievements.Count && OldUnlockedAchievements.Count < CurrentGame.Achievements.Count)
                        {
                            FocusWindow.HideFocus();

                            ClearFocusStreamLabels();

                            NotificationsWindow.EnqueueMasteryNotification(UserSummary.GameSummaries[0],
                                UserSummary.GameAchievementSummaries[0],
                                Settings.Default.notification_custom_mastery_enable ? GetVideoDuration(CustomMasteryFile) : 11000,
                                Settings.Default.notification_custom_mastery_enable ? CustomMasteryIn : 0,
                                Settings.Default.notification_custom_mastery_enable ? CustomMasteryOut : 5200);
                            SetAwardCount();
                        }

                        if (StatsWindow != null && !StatsWindow.IsDisposed)
                        {
                            StatsWindow.SetCompletedValue(GameTotalAchievements == 0 ? 0 : Convert.ToInt32((Convert.ToDecimal(GameEarnedAchievements) / Convert.ToDecimal(GameTotalAchievements)) * 200)); 
                        }
                        if (StreamLabelsStatsEnable)
                        {
                            WriteStatsStreamLabels();
                        }

                        NotificationsWindow.FireNotifications();

                    }

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
                    if (StreamLabelsStatsEnable)
                    {
                        WriteStatsStreamLabels();
                    }
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
                    if (StreamLabelsStatsEnable)
                    {
                        WriteStatsStreamLabels();
                    }
                }
                _points = value;

                OnPropertyChanged("Points");
            }
        }
        public int TruePoints
        {
            get
            {
                return _truePoints;
            }
            set
            {
                if (_truePoints != value)
                {
                    StatsWindow.SetTruePoints(value);
                    if (StreamLabelsStatsEnable)
                    {
                        WriteStatsStreamLabels();
                    }
                }
                _truePoints = value;

                OnPropertyChanged("TruePoints");
            }
        }
        public float Ratio
        {
            get
            {
                return _ratio;
            }
            set
            {
                if (_ratio != value)
                {
                    StatsWindow.SetRatio(value);
                    if (StreamLabelsStatsEnable)
                    {
                        WriteStatsStreamLabels();
                    }
                }
                _ratio = value;

                OnPropertyChanged("Ratio");
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

                    if (StatsWindow != null && !StatsWindow.IsDisposed && !StatsWindow.chromiumWebBrowser.IsLoading)
                    {
                        StatsWindow.SetAwards(value);
                    }
                }
                if (StreamLabelsStatsEnable)
                {
                    WriteStatsStreamLabels();
                }
                _awards = value;

                OnPropertyChanged("Awards");
            }
        }
        public string GameInfoTitle
        {
            get
            {
                return _gameTitle;
            }
            set
            {
                _gameTitle = value;
                if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
                {
                    GameInfoWindow.SetTitleValue(value);
                    if (StreamLabelsGameInfoEnable)
                    {
                        WriteGameInfoStreamLabels();
                    }
                }

                OnPropertyChanged("GameTitle");
            }
        }
        public string GameInfoConsoleValue
        {
            get
            {
                return _gameConsole;
            }
            set
            {
                _gameConsole = value;

                if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
                {
                    GameInfoWindow.SetConsoleValue(value);
                    if (StreamLabelsGameInfoEnable)
                    {
                        WriteGameInfoStreamLabels();
                    }
                }

                OnPropertyChanged("ConsoleName");
            }
        }
        public string GameInfoDeveloperValue
        {
            get
            {
                return _gameDeveloper;
            }
            set
            {
                _gameDeveloper = value;
                if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
                {
                    GameInfoWindow.SetDeveloperValue(value);
                    if (StreamLabelsGameInfoEnable)
                    {
                        WriteGameInfoStreamLabels();
                    }
                }
                OnPropertyChanged("GameDeveloper");
            }
        }
        public string GameInfoPublisherValue
        {
            get
            {
                return _gamePublisher;
            }
            set
            {
                _gamePublisher = value;
                if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
                {
                    GameInfoWindow.SetPublisherValue(value);
                }
                OnPropertyChanged("GamePublisher");
            }
        }
        public string GameInfoGenreValue
        {
            get
            {
                return _gameGenre;
            }
            set
            {
                _gameGenre = value;
                if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
                {
                    GameInfoWindow.SetGenreValue(value);
                    if (StreamLabelsGameInfoEnable)
                    {
                        WriteGameInfoStreamLabels();
                    }
                }
                OnPropertyChanged("GameGenre");
            }
        }
        public string GameInfoReleaseDateValue
        {
            get
            {
                return _gameReleaseDate;
            }
            set
            {
                _gameReleaseDate = value;
                if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
                {
                    GameInfoWindow.SetReleaseDateValue(value);
                }
                OnPropertyChanged("GameReleaseDate");
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
                    if (StreamLabelsStatsEnable)
                    {
                        WriteStatsStreamLabels();
                    }
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
                    if (StreamLabelsStatsEnable)
                    {
                        WriteStatsStreamLabels();
                    }
                }
                _gamePointsEarned = value;

                OnPropertyChanged("GameEarnedPoints");
            }
        }
        private int GameEarnedTruePoints
        {
            get
            {
                return _gameTruePointsEarned;
            }
            set
            {
                if (_gameTruePointsEarned != value)
                {
                    StatsWindow.SetGameTruePoints(value, GameTotalTruePoints);
                    if (StreamLabelsStatsEnable)
                    {
                        WriteStatsStreamLabels();
                    }
                }
                _gameTruePointsEarned = value;

                OnPropertyChanged("GameEarnedPoints");
            }
        }
        private int GameTotalAchievements { get; set; }
        private int GameTotalPoints { get; set; }
        private int GameTotalTruePoints { get; set; }
        public float GameRatio
        {
            get
            {
                return _gameRatio;
            }
            set
            {
                _gameRatio = value;

                if (StatsWindow != null && !StatsWindow.IsDisposed)
                {
                    StatsWindow.SetGameRatio(value);
                }

                OnPropertyChanged("GameRatio");
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
                    NotificationsWindow.SetAchievementTop(this.useCustomAchievementCheckbox.Checked ? value :  35);
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
                    NotificationsWindow.SetMasteryTop(this.useCustomMasteryCheckbox.Checked ? value :  35);
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
                if (!NotificationsWindow.IsDisposed)
                {
                    NotificationsWindow.SetAchievementWidth(this.useCustomAchievementCheckbox.Checked ? Convert.ToInt32(CustomAchievementScale * GetVideoWidth(CustomAchievementFile)) : 1200);
                }

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
                if (!NotificationsWindow.IsDisposed)
                {
                    NotificationsWindow.SetMasteryWidth(this.useCustomMasteryCheckbox.Checked ? Convert.ToInt32(CustomMasteryScale * GetVideoWidth(CustomMasteryFile)) : 1200);
                }

                Settings.Default.notification_custom_mastery_scale = value;
                Settings.Default.Save();
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
        private AnimationDirection NotificationAchievementAnimationIn
        {
            get
            {
                switch (Settings.Default.notifications_achievement_in_animation)
                {
                    case "DOWN":
                        return AnimationDirection.DOWN;
                    case "LEFT":
                        return AnimationDirection.LEFT;
                    case "RIGHT":
                        return AnimationDirection.RIGHT;
                    case "UP":
                        return AnimationDirection.UP;
                }
                return AnimationDirection.STATIC;
            }
            set
            {
                if (NotificationsWindow != null && !NotificationsWindow.IsDisposed)
                {
                    NotificationsWindow.SetAchievementInAnimation(value.ToString());
                }

                Settings.Default.notifications_achievement_in_animation = value.ToString();
                Settings.Default.Save();
            }
        }
        private AnimationDirection NotificationAchievementAnimationOut
        {
            get
            {
                switch (Settings.Default.notifications_achievement_out_animation)
                {
                    case "DOWN":
                        return AnimationDirection.DOWN;
                    case "LEFT":
                        return AnimationDirection.LEFT;
                    case "RIGHT":
                        return AnimationDirection.RIGHT;
                    case "UP":
                        return AnimationDirection.UP;
                }
                return AnimationDirection.STATIC;
            }
            set
            {
                if (NotificationsWindow != null && !NotificationsWindow.IsDisposed)
                {
                    NotificationsWindow.SetAchievementOutAnimation(value.ToString());
                }

                Settings.Default.notifications_achievement_out_animation = value.ToString();
                Settings.Default.Save();
            }
        }
        private AnimationDirection NotificationMasteryAnimationIn
        {
            get
            {
                switch (Settings.Default.notifications_mastery_in_animation)
                {
                    case "DOWN":
                        return AnimationDirection.DOWN;
                    case "LEFT":
                        return AnimationDirection.LEFT;
                    case "RIGHT":
                        return AnimationDirection.RIGHT;
                    case "UP":
                        return AnimationDirection.UP;
                }
                return AnimationDirection.STATIC;
            }
            set
            {
                if (NotificationsWindow != null && !NotificationsWindow.IsDisposed)
                {
                    NotificationsWindow.SetMasteryInAnimation(value.ToString());
                }

                Settings.Default.notifications_mastery_in_animation = value.ToString();
                Settings.Default.Save();
            }
        }
        private AnimationDirection NotificationMasteryAnimationOut
        {
            get
            {
                switch (Settings.Default.notifications_mastery_out_animation)
                {
                    case "DOWN":
                        return AnimationDirection.DOWN;
                    case "LEFT":
                        return AnimationDirection.LEFT;
                    case "RIGHT":
                        return AnimationDirection.RIGHT;
                    case "UP":
                        return AnimationDirection.UP;
                }
                return AnimationDirection.STATIC;
            }
            set
            {
                if (NotificationsWindow != null && !NotificationsWindow.IsDisposed)
                {
                    NotificationsWindow.SetMasteryOutAnimation(value.ToString());
                }

                Settings.Default.notifications_mastery_out_animation = value.ToString();
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

        private string StatsRankName
        {
            get
            {
                return Settings.Default.stats_rank_name;
            }
            set
            {
                if (StatsWindow != null && !StatsWindow.IsDisposed)
                {
                    StatsWindow.SetRankName(value);
                }

                Settings.Default.stats_rank_name = value;
                Settings.Default.Save();
            }
        }
        private string StatsAwardsName
        {
            get
            {
                return Settings.Default.stats_awards_name;
            }
            set
            {
                if (StatsWindow != null && !StatsWindow.IsDisposed)
                {
                    StatsWindow.SetAwardsName(value);
                }

                Settings.Default.stats_awards_name = value;
                Settings.Default.Save();
            }
        }
        private string StatsPointsName
        {
            get
            {
                return Settings.Default.stats_points_name;
            }
            set
            {
                if (StatsWindow != null && !StatsWindow.IsDisposed)
                {
                    StatsWindow.SetPointsName(value);
                }

                Settings.Default.stats_points_name = value;
                Settings.Default.Save();
            }
        }
        private string StatsTruePointsName
        {
            get
            {
                return Settings.Default.stats_true_points_name;
            }
            set
            {
                if (StatsWindow != null && !StatsWindow.IsDisposed)
                {
                    StatsWindow.SetTruePointsName(value);
                }

                Settings.Default.stats_true_points_name = value;
                Settings.Default.Save();
            }
        }
        private string StatsRatioName
        {
            get
            {
                return Settings.Default.stats_ratio_name;
            }
            set
            {
                if (StatsWindow != null && !StatsWindow.IsDisposed)
                {
                    StatsWindow.SetRatioName(value);
                }

                Settings.Default.stats_ratio_name = value;
                Settings.Default.Save();
            }
        }
        private string StatsGameRatioName
        {
            get
            {
                return Settings.Default.stats_game_ratio_name;
            }
            set
            {
                if (StatsWindow != null && !StatsWindow.IsDisposed)
                {
                    StatsWindow.SetGameRatioName(value);
                }

                Settings.Default.stats_game_ratio_name = value;
                Settings.Default.Save();
            }
        }
        private string StatsGamePointsName
        {
            get
            {
                return Settings.Default.stats_game_points_name;
            }
            set
            {
                if (StatsWindow != null && !StatsWindow.IsDisposed)
                {
                    StatsWindow.SetGamePointsName(value);
                }

                Settings.Default.stats_game_points_name = value;
                Settings.Default.Save();
            }
        }
        private string StatsGameTruePointsName
        {
            get
            {
                return Settings.Default.stats_game_true_points_name;
            }
            set
            {
                if (StatsWindow != null && !StatsWindow.IsDisposed)
                {
                    StatsWindow.SetGameTruePointsName(value);
                }

                Settings.Default.stats_game_true_points_name = value;
                Settings.Default.Save();
            }
        }
        private string StatsGameAchievementsName
        {
            get
            {
                return Settings.Default.stats_game_achievements_name;
            }
            set
            {
                if (StatsWindow != null && !StatsWindow.IsDisposed)
                {
                    StatsWindow.SetGameAchievementsName(value);
                }

                Settings.Default.stats_game_achievements_name = value;
                Settings.Default.Save();
            }
        }
        private int StatsFontSize
        {
            get
            {
                return Settings.Default.stats_font_size;
            }
            set
            {
                if (StatsWindow != null && !StatsWindow.IsDisposed)
                {
                    StatsWindow.SetFontSize(value);
                }

                Settings.Default.stats_font_size = value;
                Settings.Default.Save();
            }
        }
        private string StatsBackgroundColor
        {
            get
            {
                return Settings.Default.stats_background_color;
            }
            set
            {
                if (StatsWindow != null && !StatsWindow.IsDisposed)
                {
                    StatsWindow.SetBackgroundColor(value);
                }

                Settings.Default.stats_background_color = value;
                Settings.Default.Save();
            }
        }
        private string GameInfoBackgroundColor
        {
            get
            {
                return Settings.Default.game_info_background_color;
            }
            set
            {
                if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
                {
                    GameInfoWindow.SetBackgroundColor(value);
                }

                Settings.Default.game_info_background_color = value;
                Settings.Default.Save();
            }
        }
        private string NotificationsBackgroundColor
        {
            get
            {
                return Settings.Default.notifications_background_color;
            }
            set
            {
                if (NotificationsWindow != null && !NotificationsWindow.IsDisposed)
                {
                    NotificationsWindow.SetBackgroundColor(value);
                }

                Settings.Default.notifications_background_color = value;
                Settings.Default.Save();
            }
        }
        private string LastFiveBackgroundColor
        {
            get
            {
                return Settings.Default.last_five_background_color;
            }
            set
            {
                if (LastFiveWindow != null && !LastFiveWindow.IsDisposed)
                {
                    LastFiveWindow.SetBackgroundColor(value);
                }

                Settings.Default.last_five_background_color = value;
                Settings.Default.Save();
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
                if (FocusWindow != null && !FocusWindow.IsDisposed)
                {
                    FocusWindow.SetBackgroundColor(value);
                }

                Settings.Default.focus_background_color = value;
                Settings.Default.Save();
            }
        }
        private string GameInfoTitleName
        {
            get
            {
                return Settings.Default.game_info_title_name;
            }
            set
            {
                if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
                {
                    GameInfoWindow.SetTitleName(value);
                }

                Settings.Default.game_info_title_name = value;
                Settings.Default.Save();
            }
        }
        private string GameInfoConsoleName
        {
            get
            {
                return Settings.Default.game_info_console_name;
            }
            set
            {
                if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
                {
                    GameInfoWindow.SetConsoleName(value);
                }

                Settings.Default.game_info_console_name = value;
                Settings.Default.Save();
            }
        }
        private string GameInfoDeveloperName
        {
            get
            {
                return Settings.Default.game_info_developer_name;
            }
            set
            {
                if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
                {
                    GameInfoWindow.SetDeveloperName(value);
                }

                Settings.Default.game_info_developer_name = value;
                Settings.Default.Save();
            }
        }
        private string GameInfoPublisherName
        {
            get
            {
                return Settings.Default.game_info_publisher_name;
            }
            set
            {
                if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
                {
                    GameInfoWindow.SetPublisherName(value);
                }

                Settings.Default.game_info_publisher_name = value;
                Settings.Default.Save();
            }
        }
        private string GameInfoGenreName
        {
            get
            {
                return Settings.Default.game_info_genre_name;
            }
            set
            {
                if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
                {
                    GameInfoWindow.SetGenreName(value);
                }

                Settings.Default.game_info_genre_name = value;
                Settings.Default.Save();
            }
        }
        private string GameInfoReleaseDateName
        {
            get
            {
                return Settings.Default.game_info_release_date_name;
            }
            set
            {
                if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
                {
                    GameInfoWindow.SetReleaseDateName(value);
                }

                Settings.Default.game_info_release_date_name = value;
                Settings.Default.Save();
            }
        }
        private string StatsCompletedName
        {
            get
            {
                return Settings.Default.stats_completed_name;
            }
            set
            {
                if (StatsWindow != null && !StatsWindow.IsDisposed)
                {
                    StatsWindow.SetCompletedName(value);
                }

                Settings.Default.stats_completed_name = value;
                Settings.Default.Save();
            }
        }
        private int GameInfoFontSize
        {
            get
            {
                return Settings.Default.game_info_font_size;
            }
            set
            {
                if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
                {
                    GameInfoWindow.SetFontSize(value);
                }

                Settings.Default.game_info_font_size = value;
                Settings.Default.Save();
            }
        }
        private bool StatsRankEnable
        {
            get
            {
                return Settings.Default.stats_rank_enable;
            }
            set
            {
                if (StatsWindow != null && !StatsWindow.IsDisposed)
                {
                    if (value)
                    {
                        StatsWindow.ShowRank();
                    }
                    else
                    {
                        StatsWindow.HideRank();
                    }
                    Settings.Default.stats_rank_enable = value;
                    Settings.Default.Save();
                }
            }
        }
        private bool StatsAwardsEnable
        {
            get
            {
                return Settings.Default.stats_awards_enable;
            }
            set
            {
                if (StatsWindow != null && !StatsWindow.IsDisposed)
                {
                    if (value)
                    {
                        StatsWindow.ShowAwards();
                    }
                    else
                    {
                        StatsWindow.HideAwards();
                    }
                }
                Settings.Default.stats_awards_enable = value;
                Settings.Default.Save();
            }
        }
        private bool StatsPointsEnable
        {
            get
            {
                return Settings.Default.stats_points_enable;
            }
            set
            {
                if (StatsWindow != null && !StatsWindow.IsDisposed)
                {
                    if (value)
                    {
                        StatsWindow.ShowPoints();
                    }
                    else
                    {
                        StatsWindow.HidePoints();
                    }
                }
                Settings.Default.stats_points_enable = value;
                Settings.Default.Save();
            }
        }
        private bool StatsTruePointsEnable
        {
            get
            {
                return Settings.Default.stats_true_points_enable;
            }
            set
            {
                if (StatsWindow != null && !StatsWindow.IsDisposed)
                {
                    if (value)
                    {
                        StatsWindow.ShowTruePoints();
                    }
                    else
                    {
                        StatsWindow.HideTruePoints();
                    }
                }
                Settings.Default.stats_true_points_enable = value;
                Settings.Default.Save();
            }
        }
        private bool StatsCompletedEnable
        {
            get
            {
                return Settings.Default.stats_completed_enable;
            }
            set
            {
                if (StatsWindow != null && !StatsWindow.IsDisposed)
                {
                    if (value)
                    {
                        StatsWindow.ShowCompleted();
                    }
                    else
                    {
                        StatsWindow.HideCompleted();
                    }
                    Settings.Default.stats_completed_enable = value;
                    Settings.Default.Save();
                }
            }
        }
        private bool StatsRatioEnable
        {
            get
            {
                return Settings.Default.stats_ratio_enable;
            }
            set
            {
                if (StatsWindow != null && !StatsWindow.IsDisposed)
                {
                    if (value)
                    {
                        StatsWindow.ShowRatio();
                    }
                    else
                    {
                        StatsWindow.HideRatio();
                    }
                    Settings.Default.stats_ratio_enable = value;
                    Settings.Default.Save();
                }
            }
        }
        private bool StatsGameRatioEnable
        {
            get
            {
                return Settings.Default.stats_game_ratio_enable;
            }
            set
            {
                if (StatsWindow != null && !StatsWindow.IsDisposed)
                {
                    if (value)
                    {
                        StatsWindow.ShowGameRatio();
                    }
                    else
                    {
                        StatsWindow.HideGameRatio();
                    }
                }
                Settings.Default.stats_game_ratio_enable = value;
                Settings.Default.Save();
            }
        }
        private bool StatsGamePointsEnable
        {
            get
            {
                return Settings.Default.stats_game_points_enable;
            }
            set
            {
                if (StatsWindow != null && !StatsWindow.IsDisposed)
                {
                    if (value)
                    {
                        StatsWindow.ShowGamePoints();
                    }
                    else
                    {
                        StatsWindow.HideGamePoints();
                    }
                }
                Settings.Default.stats_game_points_enable = value;
                Settings.Default.Save();
            }
        }
        private bool StatsGameTruePointsEnable
        {
            get
            {
                return Settings.Default.stats_game_true_points_enable;
            }
            set
            {
                if (value)
                {
                    StatsWindow.ShowGameTruePoints();
                }
                else
                {
                    StatsWindow.HideGameTruePoints();
                }
                Settings.Default.stats_game_true_points_enable = value;
                Settings.Default.Save();
            }
        }
        private bool StatsGameAchievementsEnable
        {
            get
            {
                return Settings.Default.stats_game_achievements_enable;
            }
            set
            {
                if (value)
                {
                    StatsWindow.ShowGameAchievements();
                }
                else
                {
                    StatsWindow.HideGameAchievements();
                }
                Settings.Default.stats_game_achievements_enable = value;
                Settings.Default.Save();
            }
        }
        private bool GameInfoTitleEnable
        {
            get
            {
                return Settings.Default.game_info_title_enable;
            }
            set
            {
                if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
                {
                    if (value)
                    {
                        GameInfoWindow.ShowTitle();
                    }
                    else
                    {
                        GameInfoWindow.HideTitle();
                    }
                }
                Settings.Default.game_info_title_enable = value;
                Settings.Default.Save();
            }
        }
        private bool GameInfoConsoleEnable
        {
            get
            {
                return Settings.Default.game_info_console_enable;
            }
            set
            {
                if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
                {
                    if (value)
                    {
                        GameInfoWindow.ShowConsole();
                    }
                    else
                    {
                        GameInfoWindow.HideConsole();
                    }
                }
                Settings.Default.game_info_console_enable = value;
                Settings.Default.Save();
            }
        }
        private bool GameInfoDeveloperEnable
        {
            get
            {
                return Settings.Default.game_info_developer_enable;
            }
            set
            {
                if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
                {
                    if (value)
                    {
                        GameInfoWindow.ShowDeveloper();
                    }
                    else
                    {
                        GameInfoWindow.HideDeveloper();
                    }
                }
                Settings.Default.game_info_developer_enable = value;
                Settings.Default.Save();
            }
        }
        private bool GameInfoPublisherEnable
        {
            get
            {
                return Settings.Default.game_info_publisher_enable;
            }
            set
            {
                if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
                {
                    if (value)
                    {
                        GameInfoWindow.ShowPublisher();
                    }
                    else
                    {
                        GameInfoWindow.HidePublisher();
                    }
                }
                Settings.Default.game_info_publisher_enable = value;
                Settings.Default.Save();
            }
        }
        private bool GameInfoGenreEnable
        {
            get
            {
                return Settings.Default.game_info_genre_enable;
            }
            set
            {
                if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
                {
                    if (value)
                    {
                        GameInfoWindow.ShowGenre();
                    }
                    else
                    {
                        GameInfoWindow.HideGenre();
                    }
                }
                Settings.Default.game_info_genre_enable = value;
                Settings.Default.Save();
            }
        }
        private bool GameInfoReleaseDateEnable
        {
            get
            {
                return Settings.Default.game_info_release_date_enable;
            }
            set
            {
                if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
                {
                    if (value)
                    {
                        GameInfoWindow.ShowReleaseDate();
                    }
                    else
                    {
                        GameInfoWindow.HideReleaseDate();
                    }
                }
                Settings.Default.game_info_release_date_enable = value;
                Settings.Default.Save();
            }
        }
        private bool StreamLabelsFocusEnable
        {
            get
            {
                return Settings.Default.stream_labels_focus;
            }
            set
            {
                Settings.Default.stream_labels_focus = value;
                Settings.Default.Save();
            }
        }
        private bool StreamLabelsStatsEnable
        {
            get
            {
                return Settings.Default.stream_labels_stats;
            }
            set
            {
                Settings.Default.stream_labels_stats = value;
                Settings.Default.Save();
            }
        }
        private bool StreamLabelsAlertsEnable
        {
            get
            {
                return Settings.Default.stream_labels_notifications;
                ;
            }
            set
            {
                Settings.Default.stream_labels_notifications = value;
                Settings.Default.Save();
            }
        }
        private bool StreamLabelsGameInfoEnable
        {
            get
            {
                return Settings.Default.stream_labels_game_info;
            }
            set
            {
                Settings.Default.stream_labels_game_info = value;
                Settings.Default.Save();
            }
        }
        private bool StreamLabelsLastFiveEnable
        {
            get
            {
                return Settings.Default.stream_labels_last_five;
            }
            set
            {
                Settings.Default.stream_labels_last_five = value;
                Settings.Default.Save();
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

                if (FocusWindow != null && !FocusWindow.IsDisposed)
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
                return Settings.Default.focus_font_outline_size;
            }
            set
            {
                Settings.Default.focus_font_outline_size = value;
                Settings.Default.Save();

                if (!FocusWindow.IsDisposed)
                {
                    FocusWindow.SetFontOutline(FocusFontOutlineColor, value);
                }
            }
        }
        private bool FocusFontOutlineEnable
        {
            get
            {
                return Settings.Default.focus_font_outline_enabled;
            }
            set
            {
                Settings.Default.focus_font_outline_enabled = value;
                Settings.Default.Save();

                if (!FocusWindow.IsDisposed)
                {
                    if (value)
                    {
                        FocusWindow.SetFontOutline(FocusFontOutlineColor, FocusFontOutlineSize);
                    }
                    else
                    {
                        FocusWindow.SetFontOutline("", 0);
                    }
                }
            }
        }
        private bool FocusPointsEnable
        {
            get
            {
                return Settings.Default.focus_points_enable;
            }
            set
            {
                if (FocusWindow != null && !FocusWindow.IsDisposed)
                {
                    if (value)
                    {
                        FocusWindow.ShowPoints();
                    }
                    else
                    {
                        FocusWindow.HidePoints();
                    }
                    Settings.Default.focus_points_enable = value;
                    Settings.Default.Save();
                }
            }
        }

        private FontFamily GameInfoFontFamily
        {
            get
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily font in familyArray)
                {
                    if (font.Name.Equals(Settings.Default.game_info_font_family_name))
                    {
                        return font;
                    }
                }

                Settings.Default.game_info_font_family_name = familyArray[0].Name;
                Settings.Default.Save();

                return familyArray[0];
            }
            set
            {
                Settings.Default.game_info_font_family_name = value.Name;
                Settings.Default.Save();

                if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
                {
                    GameInfoWindow.SetFontFamily(value.Name);
                }
            }
        }
        private string GameInfoFontColor
        {
            get
            {
                return Settings.Default.game_info_font_color_hex_code;
            }
            set
            {
                Settings.Default.game_info_font_color_hex_code = value;
                Settings.Default.Save();

                if (!GameInfoWindow.IsDisposed)
                {
                    GameInfoWindow.SetFontColor(value);
                }
            }
        }
        private string GameInfoFontOutlineColor
        {
            get
            {
                return Settings.Default.game_info_font_outline_color_hex;
            }
            set
            {
                Settings.Default.game_info_font_outline_color_hex = value;
                Settings.Default.Save();

                if (!GameInfoWindow.IsDisposed)
                {
                    GameInfoWindow.SetFontOutline(value, GameInfoFontOutlineSize);
                }
            }
        }
        private int GameInfoFontOutlineSize
        {
            get
            {
                return Settings.Default.game_info_font_outline_size;
            }
            set
            {
                Settings.Default.game_info_font_outline_size = value;
                Settings.Default.Save();

                if (!GameInfoWindow.IsDisposed)
                {
                    GameInfoWindow.SetFontOutline(GameInfoFontOutlineColor, value);
                }
            }
        }
        private bool GameInfoFontOutlineEnable
        {
            get
            {
                return Settings.Default.game_info_font_outline_enabled;
            }
            set
            {
                Settings.Default.game_info_font_outline_enabled = value;
                Settings.Default.Save();

                if (!GameInfoWindow.IsDisposed)
                {
                    if (value)
                    {
                        GameInfoWindow.SetFontOutline(GameInfoFontOutlineColor, GameInfoFontOutlineSize);
                    }
                    else
                    {
                        GameInfoWindow.SetFontOutline("", 0);
                    }
                }
            }
        }

        private FontFamily LastFiveFontFamily
        {
            get
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily font in familyArray)
                {
                    if (font.Name.Equals(Settings.Default.last_five_font_family_name))
                    {
                        return font;
                    }
                }

                Settings.Default.last_five_font_family_name = familyArray[0].Name;
                Settings.Default.Save();

                return familyArray[0];
            }
            set
            {
                Settings.Default.last_five_font_family_name = value.Name;
                Settings.Default.Save();

                if (LastFiveWindow != null && !LastFiveWindow.IsDisposed)
                {
                    LastFiveWindow.SetFontFamily(value.Name);
                }
            }
        }
        private string LastFiveFontColor
        {
            get
            {
                return Settings.Default.last_five_font_color_hex_code;
            }
            set
            {
                Settings.Default.last_five_font_color_hex_code = value;
                Settings.Default.Save();

                if (!LastFiveWindow.IsDisposed)
                {
                    LastFiveWindow.SetFontColor(value);
                }
            }
        }
        private string LastFiveFontOutlineColor
        {
            get
            {
                return Settings.Default.last_five_font_outline_color_hex;
            }
            set
            {
                Settings.Default.last_five_font_outline_color_hex = value;
                Settings.Default.Save();

                if (!LastFiveWindow.IsDisposed)
                {
                    LastFiveWindow.SetFontOutline(value, LastFiveFontOutlineSize);
                }
            }
        }
        private int LastFiveFontOutlineSize
        {
            get
            {
                return Settings.Default.last_five_font_outline_size;
            }
            set
            {
                Settings.Default.last_five_font_outline_size = value;
                Settings.Default.Save();

                if (!LastFiveWindow.IsDisposed)
                {
                    LastFiveWindow.SetFontOutline(LastFiveFontOutlineColor, value);
                }
            }
        }
        private bool LastFiveFontOutlineEnable
        {
            get
            {
                return Settings.Default.last_five_font_outline_enabled;
            }
            set
            {
                Settings.Default.last_five_font_outline_enabled = value;
                Settings.Default.Save();

                if (!LastFiveWindow.IsDisposed)
                {
                    if (value)
                    {
                        LastFiveWindow.SetFontOutline(LastFiveFontOutlineColor, LastFiveFontOutlineSize);
                    }
                    else
                    {
                        LastFiveWindow.SetFontOutline("", 0);
                    }
                }
            }
        }
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

                if (StatsWindow != null && !StatsWindow.IsDisposed)
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
                Settings.Default.stats_font_outline_color_hex = value;
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
        private bool StatsFontOutlineEnable
        {
            get
            {
                return Settings.Default.stats_font_outline_enabled;
            }
            set
            {
                Settings.Default.stats_font_outline_enabled = value;
                Settings.Default.Save();

                if (!StatsWindow.IsDisposed)
                {
                    if (value)
                    {
                        StatsWindow.SetFontOutline(StatsFontOutlineColor, StatsFontOutlineSize);
                    }
                    else
                    {
                        StatsWindow.SetFontOutline("", 0);
                    }
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

                if (NotificationsWindow != null && !NotificationsWindow.IsDisposed)
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
        private bool NotificationsFontOutlineEnable
        {
            get
            {
                return Settings.Default.notification_font_outline_enabled;
            }
            set
            {
                Settings.Default.notification_font_outline_enabled = value;
                Settings.Default.Save();

                if (!NotificationsWindow.IsDisposed)
                {
                    if (value)
                    {
                        NotificationsWindow.SetFontOutline(NotificationsFontOutlineColor, NotificationsFontOutlineSize);
                    }
                    else
                    {
                        NotificationsWindow.SetFontOutline("", 0);
                    }
                }
            }
        }

        private Achievement CurrentlyViewingAchievement;
        private Achievement CurrentlyFocusedAchievement;
        private int CurrentlyFocusedIndex;

        private static List<Achievement> LockedAchievements;
        private static List<Achievement> UnlockedAchievements;
        private static List<Achievement> OldUnlockedAchievements;
        private static List<Achievement> MostRecentAchievements;

        private static Timer UserAndGameUpdateTimer;
        private static int UserAndGameTimerCounter;

        private static StatsLayoutWindow StatsWindow;
        private static FocusLayoutWindow FocusWindow;
        private static NotificationLayoutWindow NotificationsWindow;
        private static GameInfoLayoutWindow GameInfoWindow;
        private static LastFiveLayoutWindow LastFiveWindow;

        private bool ShouldRun;
        private int RAErrors;

        private CustomMenuState MenuState = CustomMenuState.CLOSED;

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
            CreateGameInfoWindow();
            CreateLastFiveWindow();

            HideAllMenuItems();
        }

        protected async override void OnLoad(EventArgs e)
        {
            CreateDataBindings();
            CreateFolders();

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

            NotBooting = true;

            this.Location = new Point(0, 0);

            if (StatsWindow != null && !StatsWindow.IsDisposed)
            {
                StatsWindow.Location = new Point(0, 0);
            }
            if (FocusWindow != null && !FocusWindow.IsDisposed)
            {
                FocusWindow.Location = new Point(0, 0);
            }
            if (NotificationsWindow != null && !NotificationsWindow.IsDisposed)
            {
                NotificationsWindow.Location = new Point(300, 0);
            }
            if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
            {
                GameInfoWindow.Location = new Point(0, 0);
            }
            if (LastFiveWindow != null && !LastFiveWindow.IsDisposed)
            {
                LastFiveWindow.Location = new Point(0, 0);
            }

            if (StreamLabelsStatsEnable)
            {
                WriteStatsStreamLabels();
            }
            if (StreamLabelsLastFiveEnable)
            {
                WriteLastFiveStreamLabels();
            }
            if (StreamLabelsGameInfoEnable)
            {
                WriteGameInfoStreamLabels();
            }
            ClearAlertStreamLabels();

            NotificationsWindow.BringToFront();
            this.BringToFront();
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
            if (!Directory.Exists(@"stream-labels\alerts"))
            {
                Directory.CreateDirectory(@"stream-labels\alerts");
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
                if (FocusWindow.IsDisposed)
                {
                    CreateFocusWindow();
                }
                FocusWindow.Show();
            }

            if (this.autoLaunchStatsWindowCheckbox.Checked)
            {
                if (StatsWindow.IsDisposed)
                {
                    CreateStatsWindow();
                }
                StatsWindow.Show();
            }

            if (this.autoLaunchNotificationsWindowCheckbox.Checked)
            {
                if (NotificationsWindow.IsDisposed)
                {
                    CreateNotificationsWindow();
                }
                NotificationsWindow.Show();
            }

            if (this.autoLaunchGameInfoWindowCheckbox.Checked)
            {
                if (GameInfoWindow.IsDisposed)
                {
                    CreateGameInfoWindow();
                }
                GameInfoWindow.Show();
            }

            if (this.autoLaunchLastFiveWindowCheckbox.Checked)
            {
                if (LastFiveWindow.IsDisposed)
                {
                    CreateLastFiveWindow();
                }
                LastFiveWindow.Show();
            }

            this.showFocusWindowButton.Enabled = true;
            this.openAlertsWindowButton.Enabled = true;
            this.openStatsWindowButton.Enabled = true;
            this.openGameInfoWindowButton.Enabled = true;

            this.alertsStreamLabelsCheckBox.Enabled = true;
            this.statsStreamLabelsCheckBox.Enabled = true;
            this.lastFiveStreamLabelsCheckBox.Enabled = true;
            this.focusStreamLabelsCheckBox.Enabled = true;
            this.gameInfoStreamLabelsCheckBox.Enabled = true;

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

            SetAwardCount();

            this.userProfilePictureBox.ImageLocation = "https://retroachievements.org/UserPic/" + this.usernameTextBox.Text + ".png";
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            ShouldRun = false;

            UserAndGameUpdateTimer.Stop();

            this.raConnectionStatusPictureBox.Image = Resources.red_button;

            UpdateTimerLabel("Stopped Updating.");

            this.stopButton.Enabled = false;
            this.showFocusWindowButton.Enabled = CanStart();
            this.openAlertsWindowButton.Enabled = CanStart();
            this.openStatsWindowButton.Enabled = CanStart();

            this.apiKeyTextBox.Enabled = true;
            this.usernameTextBox.Enabled = true;

            this.startButton.Enabled = CanStart();
        }
        private void ClearAllStreamLabels()
        {
            ClearStatsStreamLabels();
            ClearAlertStreamLabels();
            ClearFocusStreamLabels();
            ClearLastFiveStreamLabels();
            ClearGameInfoStreamLabels();
        }
        private void WriteStatsStreamLabels()
        {
            if (Rank != 0)
            {
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/rank.txt", Rank.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/awards.txt", Awards.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/ratio.txt", Ratio.ToString("0.00") + " %");
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/points.txt", Points.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/true-points.txt", TruePoints.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/game-ratio.txt", GameRatio.ToString("0.00") + " %");
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/game-points.txt", GameEarnedPoints.ToString() + "/" + GameTotalPoints.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/game-true-points.txt", GameEarnedTruePoints.ToString() + "/" + GameTotalTruePoints.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/game-achievements.txt", GameEarnedAchievements.ToString() + "/" + GameTotalAchievements.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/completed.txt", (GameTotalAchievements == 0 ? 0 : Convert.ToInt32(Convert.ToDecimal(GameEarnedAchievements) / Convert.ToDecimal(GameTotalAchievements) * 200)) + " %");
            }
        }
        private void ClearStatsStreamLabels()
        {
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/rank.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/awards.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/ratio.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/points.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/true-points.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/game-ratio.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/game-points.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/game-true-points.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/game-achievements.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/completed.txt", string.Empty);
        }
        private void WriteAlertStreamLabels(string title, string description, int points)
        {
            if (title.Length > 0)
            {
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/alerts/title.txt", title);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/alerts/description.txt", description);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/alerts/points.txt", points.ToString());
            }
        }
        private void ClearAlertStreamLabels()
        {
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/alerts/title.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/alerts/description.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/alerts/points.txt", string.Empty);
        }
        private void WriteGameInfoStreamLabels()
        {
            if (CurrentGame != null)
            {
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/title.txt", CurrentGame.Title);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/console.txt", CurrentGame.ConsoleName);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/developer.txt", CurrentGame.Developer);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/publisher.txt", CurrentGame.Publisher);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/genre.txt", CurrentGame.Genre);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/release-date.txt", CurrentGame.Released);
            }
        }
        private void ClearGameInfoStreamLabels()
        {
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/title.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/console.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/developer.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/publisher.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/genre.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/release-date.txt", string.Empty);
        }
        private void WriteLastFiveStreamLabels()
        {
            if (MostRecentAchievements != null && MostRecentAchievements.Count > 0)
            {
                for (int i = 0; i < MostRecentAchievements.Count; i++)
                {
                    File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + i + "-title.txt", MostRecentAchievements[0].Title);
                    File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + i + "-description.txt", MostRecentAchievements[0].Description);
                    File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + i + "-points.txt", MostRecentAchievements[0].Points.ToString());
                }

                for (int i = 5; i > MostRecentAchievements.Count; i--)
                {
                    File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + i + "-title.txt", MostRecentAchievements[1].Title);
                    File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + i + "-description.txt", MostRecentAchievements[1].Description);
                    File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + i + "-points.txt", MostRecentAchievements[1].Points.ToString());
                }
            }
        }
        private void ClearLastFiveStreamLabels()
        {
            for (int i = 0; i < 5; i++)
            {
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + i + "-title.txt", string.Empty);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + i + "-description.txt", string.Empty);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + i + "-points.txt", string.Empty);
            }
        }
        private void WriteFocusStreamLabels()
        {
            if (CurrentlyFocusedAchievement != null)
            {
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/title.txt", CurrentlyFocusedAchievement.Title);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/description.txt", CurrentlyFocusedAchievement.Description);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/points.txt", CurrentlyFocusedAchievement.Points.ToString());
            }
            else
            {
                ClearFocusStreamLabels();
            }
        }
        private void ClearFocusStreamLabels()
        {
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/title.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/description.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/points.txt", string.Empty);
        }
        private void CreateStatsWindow()
        {
            StatsWindow = new StatsLayoutWindow();

            StatsWindow.chromiumWebBrowser.LoadHtml(Resources.StatsWindow);
            StatsWindow.chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                StatsWindow.SetFontFamily(StatsFontFamily.Name);
                StatsWindow.SetFontColor(StatsFontColor);
                if (StatsFontOutlineEnable)
                {
                    StatsWindow.SetFontOutline(StatsFontOutlineColor, StatsFontOutlineSize);
                }
                else
                {
                    StatsWindow.SetFontOutline("", 0);
                }
                StatsWindow.SetRankName(StatsRankName);
                StatsWindow.SetRank(UserSummary.Rank);
                if (StatsRankEnable)
                {
                    StatsWindow.ShowRank();
                }
                else
                {
                    StatsWindow.HideRank();
                }

                StatsWindow.SetPointsName(StatsPointsName);
                StatsWindow.SetPoints(UserSummary.TotalPoints);
                if (StatsPointsEnable)
                {
                    StatsWindow.ShowPoints();
                }
                else
                {
                    StatsWindow.HidePoints();
                }

                StatsWindow.SetAwardsName(StatsAwardsName);
                StatsWindow.SetAwards(_awards);
                if (StatsAwardsEnable)
                {
                    StatsWindow.ShowAwards();
                }
                else
                {
                    StatsWindow.HideAwards();
                }

                StatsWindow.SetTruePointsName(StatsTruePointsName);
                StatsWindow.SetTruePoints(_truePoints);
                if (StatsTruePointsEnable)
                {
                    StatsWindow.ShowTruePoints();
                }
                else
                {
                    StatsWindow.HideTruePoints();
                }

                StatsWindow.SetRatioName(StatsRatioName);
                StatsWindow.SetRatio(Ratio);
                if (StatsRatioEnable)
                {
                    StatsWindow.ShowRatio();
                }
                else
                {
                    StatsWindow.HideRatio();
                }

                StatsWindow.SetGameRatioName(StatsGameRatioName);
                StatsWindow.SetGameRatio(_gameRatio);
                if (StatsGameRatioEnable)
                {
                    StatsWindow.ShowGameRatio();
                }
                else
                {
                    StatsWindow.HideGameRatio();
                }

                StatsWindow.SetGameAchievementsName(StatsGameAchievementsName);
                StatsWindow.SetGameAchievements(GameEarnedAchievements, GameTotalAchievements);
                if (StatsGameAchievementsEnable)
                {
                    StatsWindow.ShowGameAchievements();
                }
                else
                {
                    StatsWindow.HideGameAchievements();
                }

                StatsWindow.SetGamePointsName(StatsGamePointsName);
                StatsWindow.SetGamePoints(GameEarnedPoints, GameTotalPoints);
                if (StatsGamePointsEnable)
                {
                    StatsWindow.ShowGamePoints();
                }
                else
                {
                    StatsWindow.HideGamePoints();
                }

                StatsWindow.SetGameTruePointsName(StatsGameTruePointsName);
                StatsWindow.SetGameTruePoints(GameEarnedTruePoints, GameTotalTruePoints);
                if (StatsGameTruePointsEnable)
                {
                    StatsWindow.ShowGameTruePoints();
                }
                else
                {
                    StatsWindow.HideGameTruePoints();
                }

                StatsWindow.SetCompletedName(StatsCompletedName);
                StatsWindow.SetCompletedValue(GameTotalAchievements == 0 ? 0 : Convert.ToInt32(Convert.ToDecimal(GameEarnedAchievements) / Convert.ToDecimal(GameTotalAchievements) * 200));
                StatsWindow.SetFontSize(StatsFontSize);
                StatsWindow.SetBackgroundColor(StatsBackgroundColor);
            });
        }

        private void CreateFocusWindow()
        {
            FocusWindow = new FocusLayoutWindow();

            FocusWindow.chromiumWebBrowser.LoadHtml(Resources.FocusWindow);
            FocusWindow.chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                FocusWindow.SetFontFamily(FocusFontFamily.Name);
                FocusWindow.SetFontColor(FocusFontColor);

                if (FocusFontOutlineEnable)
                {
                    FocusWindow.SetFontOutline(FocusFontOutlineColor, FocusFontOutlineSize);
                }
                else
                {
                    FocusWindow.SetFontOutline("", 0);
                }
                if (LockedAchievements.Count > 0)
                {
                    FocusWindow.SetFocus(CurrentlyFocusedAchievement);
                    if (FocusPointsEnable)
                    {
                        FocusWindow.ShowPoints();
                    }
                    else
                    {
                        FocusWindow.HidePoints();
                    }
                    if (StreamLabelsFocusEnable)
                    {
                        WriteFocusStreamLabels();
                    }
                }
                else
                {
                    FocusWindow.HideFocus();
                }
                if (FocusPointsEnable)
                {
                    FocusWindow.ShowPoints();
                }
                else
                {
                    FocusWindow.HidePoints();
                }
                FocusWindow.SetBackgroundColor(FocusBackgroundColor);
            });
        }

        private void CreateNotificationsWindow()
        {
            NotificationsWindow = new NotificationLayoutWindow(WriteAlertStreamLabels);

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

                if (NotificationsFontOutlineEnable)
                {
                    NotificationsWindow.SetFontOutline(NotificationsFontOutlineColor, NotificationsFontOutlineSize);
                }
                else
                {
                    NotificationsWindow.SetFontOutline("", 0);
                }
                NotificationsWindow.PromptUserInput();

                NotificationsWindow.SetAchievementWidth(Settings.Default.notification_custom_achievement_enable ? Convert.ToInt32(CustomAchievementScale * GetVideoWidth(CustomAchievementFile)) : 1000);
                NotificationsWindow.SetMasteryWidth(Settings.Default.notification_custom_mastery_enable ? Convert.ToInt32(CustomMasteryScale * GetVideoWidth(CustomMasteryFile)) : 1000);
                NotificationsWindow.SetAchievementTop(Settings.Default.notification_custom_achievement_enable ? CustomAchievementY :  35);
                NotificationsWindow.SetMasteryTop(Settings.Default.notification_custom_mastery_enable ? CustomMasteryY :  35);
                NotificationsWindow.SetAchievementLeft(Settings.Default.notification_custom_achievement_enable ? CustomAchievementX : -15);
                NotificationsWindow.SetMasteryLeft(Settings.Default.notification_custom_mastery_enable ? CustomMasteryX : -15);

                NotificationsWindow.SetAchievementInAnimation(CustomAchievementEnabled ? NotificationAchievementAnimationIn.ToString() : "STATIC");
                NotificationsWindow.SetAchievementOutAnimation(CustomAchievementEnabled ? NotificationAchievementAnimationOut.ToString() : "UP");

                NotificationsWindow.SetMasteryInAnimation(CustomMasteryEnabled ? NotificationMasteryAnimationIn.ToString() : "STATIC");
                NotificationsWindow.SetMasteryOutAnimation(CustomMasteryEnabled ? NotificationMasteryAnimationOut.ToString() : "UP");
                NotificationsWindow.SetBackgroundColor(NotificationsBackgroundColor);

            });
        }

        private void CreateGameInfoWindow()
        {
            GameInfoWindow = new GameInfoLayoutWindow();

            GameInfoWindow.chromiumWebBrowser.LoadHtml(Resources.GameInfo);
            GameInfoWindow.chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                GameInfoWindow.SetFontFamily(GameInfoFontFamily.Name);
                GameInfoWindow.SetFontColor(GameInfoFontColor);

                if (GameInfoFontOutlineEnable)
                {
                    GameInfoWindow.SetFontOutline(GameInfoFontOutlineColor, GameInfoFontOutlineSize);
                }
                else
                {
                    GameInfoWindow.SetFontOutline("", 0);
                }


                GameInfoWindow.SetTitleName(GameInfoTitleName);
                GameInfoWindow.SetTitleValue(GameInfoTitle);
                if (GameInfoTitleEnable)
                {
                    GameInfoWindow.ShowTitle();
                }
                else
                {
                    GameInfoWindow.HideTitle();
                }

                GameInfoWindow.SetConsoleName(GameInfoConsoleName);
                GameInfoWindow.SetConsoleValue(GameInfoConsoleValue);
                if (GameInfoConsoleEnable)
                {
                    GameInfoWindow.ShowConsole();
                }
                else
                {
                    GameInfoWindow.HideConsole();
                }

                GameInfoWindow.SetDeveloperName(GameInfoDeveloperName);
                GameInfoWindow.SetDeveloperValue(GameInfoDeveloperValue);
                if (GameInfoDeveloperEnable)
                {
                    GameInfoWindow.ShowDeveloper();
                }
                else
                {
                    GameInfoWindow.HideDeveloper();
                }

                GameInfoWindow.SetPublisherName(GameInfoPublisherName);
                GameInfoWindow.SetPublisherValue(GameInfoPublisherValue);
                if (GameInfoPublisherEnable)
                {
                    GameInfoWindow.ShowPublisher();
                }
                else
                {
                    GameInfoWindow.HidePublisher();
                }

                GameInfoWindow.SetGenreName(GameInfoGenreName);
                GameInfoWindow.SetGenreValue(GameInfoGenreValue);
                if (GameInfoGenreEnable)
                {
                    GameInfoWindow.ShowGenre();
                }
                else
                {
                    GameInfoWindow.HideGenre();
                }

                GameInfoWindow.SetReleaseDateName(GameInfoReleaseDateName);
                GameInfoWindow.SetReleaseDateValue(GameInfoReleaseDateValue);
                if (GameInfoReleaseDateEnable)
                {
                    GameInfoWindow.ShowReleaseDate();
                }
                else
                {
                    GameInfoWindow.HideReleaseDate();
                }
                GameInfoWindow.SetFontSize(GameInfoFontSize);
                GameInfoWindow.SetBackgroundColor(GameInfoBackgroundColor);
            });
        }

        private void CreateLastFiveWindow()
        {
            LastFiveWindow = new LastFiveLayoutWindow();

            LastFiveWindow.chromiumWebBrowser.LoadHtml(Resources.LastFive);
            LastFiveWindow.chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                LastFiveWindow.SetFontFamily(LastFiveFontFamily.Name);
                LastFiveWindow.SetFontColor(LastFiveFontColor);
                LastFiveWindow.SetBackgroundColor(LastFiveBackgroundColor);
                if (LastFiveFontOutlineEnable)
                {
                    LastFiveWindow.SetFontOutline(LastFiveFontOutlineColor, LastFiveFontOutlineSize);
                }
                else
                {
                    LastFiveWindow.SetFontOutline("", 0);
                }
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

                try
                {
                    UserSummary = await hFC_EssentialsClient.GetUserSummary();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                UpdateTimerLabel("Calling for game progress...");
                try
                {
                    CurrentGame = await hFC_EssentialsClient.GetGameProgress(UserSummary.GameSummaries[0].GameID.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
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
                List<Achievement> tempLockedAchievements = CurrentGame.Achievements.FindAll(x => !x.DateEarned.HasValue);
                List<Achievement> tempUnlockedAchievements = CurrentGame.Achievements.FindAll(x => x.DateEarned.HasValue);
                MostRecentAchievements = UserSummary.RecentAchievements.FindAll(x => x.DateEarned.HasValue);

                tempUnlockedAchievements.Sort(delegate (Achievement x, Achievement y) { return y.DateEarned.Value.CompareTo(x.DateEarned.Value); });
                tempLockedAchievements.Sort();

                SetLockedAchievements(tempLockedAchievements.ToList());
                UnlockedAchievements = tempUnlockedAchievements.ToList();
            }

            if (UserSummary.RecentAchievements != null && UserSummary.RecentAchievements.Count > 0)
            {
                UserSummary.RecentAchievements = UserSummary.RecentAchievements.Where(achievement => achievement.IsAwarded).ToList();
            }

            if (OldUnlockedAchievements.Count < UnlockedAchievements.Count)
            {
                if (LockedAchievements.Count == 0)
                {
                    CurrentlyFocusedIndex = 0;
                    HideFocusButton_Click(null, null);
                }
                else if (LockedAchievements.IndexOf(CurrentlyFocusedAchievement) > -1)
                {
                    CurrentlyFocusedIndex = LockedAchievements.IndexOf(CurrentlyFocusedAchievement);
                }
                else
                {
                    CurrentlyFocusedIndex = LockedAchievements.IndexOf(CurrentlyViewingAchievement) == -1 ? 0 : LockedAchievements.IndexOf(CurrentlyViewingAchievement);
                    SetFocusButton_Click(null, null);
                }
            }
        }

        protected override void OnClosed(EventArgs e)
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
            if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
            {
                GameInfoWindow.Dispose();
            }
            if (LastFiveWindow != null && !LastFiveWindow.IsDisposed)
            {
                LastFiveWindow.Dispose();
            }
            ClearAllStreamLabels();
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

            this.alertsStreamLabelsCheckBox.Checked = Settings.Default.stream_labels_notifications;
            this.focusStreamLabelsCheckBox.Checked = Settings.Default.stream_labels_focus;
            this.gameInfoStreamLabelsCheckBox.Checked = Settings.Default.stream_labels_game_info;
            this.lastFiveStreamLabelsCheckBox.Checked = Settings.Default.stream_labels_last_five;
            this.statsStreamLabelsCheckBox.Checked = Settings.Default.stream_labels_stats;

            this.statsRankOverrideTextBox.Text = Settings.Default.stats_rank_name;
            this.statsAwardsOverrideTextBox.Text = Settings.Default.stats_awards_name;
            this.statsPointsOverrideTextBox.Text = Settings.Default.stats_game_points_name;
            this.statsTruePointsOverrideTextBox.Text = Settings.Default.stats_true_points_name;
            this.statsRatioOverrideTextBox.Text = Settings.Default.stats_ratio_name;
            this.statsGameRatioOverrideTextBox.Text = Settings.Default.stats_game_ratio_name;
            this.statsGamePointsOverrideTextBox.Text = Settings.Default.stats_game_points_name;
            this.statsGameTruePointsOverrideTextBox.Text = Settings.Default.stats_game_true_points_name;
            this.statsGameAchievementsOverrideTextBox.Text = Settings.Default.stats_game_achievements_name;

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

            this.focusPointsEnable.Checked = Settings.Default.focus_points_enable;

            if (CustomAchievementEnabled && string.IsNullOrEmpty(Settings.Default.notification_custom_achievement_file))
            {
                Settings.Default.notification_custom_achievement_enable = false;
                Settings.Default.Save();
            }
            if (CustomMasteryEnabled && string.IsNullOrEmpty(Settings.Default.notification_custom_mastery_file))
            {
                Settings.Default.notification_custom_achievement_enable = false;
                Settings.Default.Save();
            }


            List<AnimationDirection> animationDirections = new List<AnimationDirection>();
            animationDirections.Add(AnimationDirection.DOWN);
            animationDirections.Add(AnimationDirection.LEFT);
            animationDirections.Add(AnimationDirection.RIGHT);
            animationDirections.Add(AnimationDirection.STATIC);
            animationDirections.Add(AnimationDirection.UP);

            animationDirections.ForEach(animationDirection => {
                this.notificationsAchievementAnimationInComboBox.Items.Add(animationDirection.ToString());
                this.notificationsAchievementAnimationOutComboBox.Items.Add(animationDirection.ToString());
                this.notificationsMasteryAnimationInComboBox.Items.Add(animationDirection.ToString());
                this.notificationsMasteryAnimationOutComboBox.Items.Add(animationDirection.ToString());
            });

            this.notificationsAchievementAnimationInComboBox.SelectedIndex = this.notificationsAchievementAnimationInComboBox.Items.IndexOf(Settings.Default.notifications_achievement_in_animation);
            this.notificationsAchievementAnimationOutComboBox.SelectedIndex = this.notificationsAchievementAnimationOutComboBox.Items.IndexOf(Settings.Default.notifications_achievement_out_animation);
            this.notificationsMasteryAnimationInComboBox.SelectedIndex = this.notificationsMasteryAnimationInComboBox.Items.IndexOf(Settings.Default.notifications_mastery_in_animation);
            this.notificationsMasteryAnimationOutComboBox.SelectedIndex = this.notificationsMasteryAnimationOutComboBox.Items.IndexOf(Settings.Default.notifications_mastery_out_animation);

            this.useCustomAchievementCheckbox.Checked = CustomAchievementEnabled;
            this.selectCustomAchievementButton.Enabled = CustomAchievementEnabled;
            this.acheivementEditOutlineCheckbox.Enabled = CustomAchievementEnabled;
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

            this.useCustomMasteryCheckbox.Checked = CustomMasteryEnabled;
            this.selectCustomMasteryNotificationButton.Enabled = CustomMasteryEnabled;
            this.masteryEditOultineCheckbox.Enabled = CustomMasteryEnabled;
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

            this.setFontColorButton.Click += SetFontColorButton_Click;
            this.fontOutlineColorButton.Click += FontOutlineColorButton_Click;
            this.fontOutlineCheckBox.CheckedChanged += FontOutlineCheckBox_CheckedChanged;
            this.fontOutlineNumericUpDown.ValueChanged += FontOutlineNumericUpDown_ValueChanged;
            this.fontSizeNumericUpDown.ValueChanged += FontSizeNumericUpDown_ValueChanged;
            this.fontFamilyComboBox.SelectedIndexChanged += FontFamilyComboBox_SelectedIndexChanged;
            this.setBackgroundColorButton.Click += SetBackgroundColorButton_Click;
            this.alertsStreamLabelsCheckBox.CheckedChanged += AlertsStreamLabelsCheckBox_CheckedChanged;
            this.focusStreamLabelsCheckBox.CheckedChanged += FocusStreamLabelsCheckBox_CheckedChanged;
            this.openLastFiveWindowButton.Click += OpenLastFiveWindowButton_Click;
            this.autoLaunchLastFiveWindowCheckbox.CheckedChanged += AutoLaunchLastFiveWindowCheckbox_CheckedChanged;
            this.customizeLastFiveButton.Click += CustomizeLastFiveButton_Click;
            this.openGameInfoWindowButton.Click += OpenGameInfoWindowButton_Click;
            this.autoLaunchGameInfoWindowCheckbox.CheckedChanged += AutoLaunchGameInfoWindowCheckbox_CheckedChanged;
            this.customizeGameButton.Click += CustomizeGameButton_Click;
            this.startButton.Click += StartButton_Click;
            this.hideButton.Click += HideButton_Click;
            this.openAlertsWindowButton.Click += ShowNotificationsWindowButton_Click;
            this.autoLaunchNotificationsWindowCheckbox.CheckedChanged += AutoLaunchNotificationsWindow_CheckedChanged;
            this.customizeAlertsButton.Click += CustomizeAlertsButton_Click;
            this.showFocusWindowButton.Click += ShowFocusLayoutWindowButton_Click;
            this.autoLaunchFocusWindowCheckBox.CheckedChanged += AutoLaunchFocusWindowCheckBox_CheckedChanged;
            this.customizeFocusButton.Click += CustomizeFocusButton_Click;
            this.openStatsWindowButton.Click += ShowStatsWindowButton_Click;
            this.customizeStatsButton.Click += CustomizeStatsButton_Click;
            this.autoLaunchStatsWindowCheckbox.CheckedChanged += AutoLaunchStatsWindowCheckbox_CheckedChanged;
            this.stopButton.Click += StopButton_Click;

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

            this.notificationsAchievementAnimationInComboBox.SelectedIndexChanged += AchievementAnimationInComboBox_SelectedIndexChanged;
            this.notificationsAchievementAnimationOutComboBox.SelectedIndexChanged += AchievementAnimationOutComboBox_SelectedIndexChanged;
            this.notificationsMasteryAnimationInComboBox.SelectedIndexChanged += MasteryAnimationInComboBox_SelectedIndexChanged;
            this.notificationsMasteryAnimationOutComboBox.SelectedIndexChanged += MasteryAnimationOutComboBox_SelectedIndexChanged;
            this.focusPointsEnable.CheckedChanged += focusPointsEnableCheckBox_CheckedChanged;

            this.setFocusButton.Click += SetFocusButton_Click;
            this.hideFocusButton.Click += HideFocusButton_Click;
            this.focusAchievementButtonLeft.Click += MoveFocusIndexLeft;
            this.focusAchievementButtonRight.Click += MoveFocusIndexRight;

            this.autoStartCheckbox.CheckedChanged += AutoStart_CheckedChanged;
            this.usernameTextBox.TextChanged += RequiredField_TextChange;
            this.apiKeyTextBox.TextChanged += RequiredField_TextChange;

            FontFamily[] familyArray = FontFamily.Families.ToArray();

            FontFamily[] focusFontFamily = familyArray.Where(fontFamily => fontFamily.Name.Equals(Settings.Default.focus_font_family_name)).ToArray();
            FontFamily[] statsFontFamily = familyArray.Where(fontFamily => fontFamily.Name.Equals(Settings.Default.stats_font_family_name)).ToArray();
            FontFamily[] notificationsFontFamily = familyArray.Where(fontFamily => fontFamily.Name.Equals(Settings.Default.notification_font_family_name)).ToArray();
            FontFamily[] gameInfoFontFamily = familyArray.Where(fontFamily => fontFamily.Name.Equals(Settings.Default.game_info_font_family_name)).ToArray();
            FontFamily[] lastFiveFontFamily = familyArray.Where(fontFamily => fontFamily.Name.Equals(Settings.Default.last_five_font_family_name)).ToArray();

            if (focusFontFamily.Length > 0)
            {
                FocusFontFamily = focusFontFamily[0];
            }
            if (statsFontFamily.Length > 0)
            {
                StatsFontFamily = statsFontFamily[0];
            }
            if (notificationsFontFamily.Length > 0)
            {
                NotificationsFontFamily = notificationsFontFamily[0];
            }
            if (gameInfoFontFamily.Length > 0)
            {
                GameInfoFontFamily = gameInfoFontFamily[0];
            }
            if (lastFiveFontFamily.Length > 0)
            {
                LastFiveFontFamily = lastFiveFontFamily[0];
            }                        
        }

        private async void SetAwardCount()
        {
            try
            {
                string url = "http://retroachievements.org/user/" + usernameTextBox.Text;

                HtmlWeb web = new HtmlWeb();

                HtmlAgilityPack.HtmlDocument doc = await web.LoadFromWebAsync(url);

                HtmlNode siteAwardsNode = doc.GetElementbyId("siteawards");

                if (siteAwardsNode == null)
                {
                    return;
                }
                this.raConnectionStatusPictureBox.Image = Resources.green_button;

                HtmlNodeCollection htmlNodeCollections = siteAwardsNode.SelectNodes(XPathExpression.Compile("//div[contains(@class,'trophyimage')]"));

                Awards = htmlNodeCollections == null ? 0 : htmlNodeCollections.Count;
            }
            catch
            {

            }
        }

        private void RequiredField_TextChange(object sender, EventArgs e)
        {
            this.startButton.Enabled = CanStart();
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
        private void AutoLaunchGameInfoWindowCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.auto_game_info = this.autoLaunchGameInfoWindowCheckbox.Checked;
            Settings.Default.Save();
        }

        private void AutoLaunchLastFiveWindowCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.auto_last_five = this.autoLaunchLastFiveWindowCheckbox.Checked;
            Settings.Default.Save();
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
            this.notificationsAchievementAnimationInComboBox.Enabled = false;
            this.notificationsAchievementAnimationOutComboBox.Enabled = false;

            NotificationsWindow.Dispose();

            CreateNotificationsWindow();

            NotificationsWindow.chromiumWebBrowser.RequestHandler = new CustomRequestHandler() { customAchievementEnabled = CustomAchievementEnabled, customMasteryEnabled = CustomMasteryEnabled };

            if (!CustomAchievementEnabled)
            {
                NotificationsWindow.DisableAchievementEdit();

                this.acheivementEditOutlineCheckbox.Checked = false;

                NotificationsWindow.SetAchievementInAnimation(AnimationDirection.STATIC.ToString());
                NotificationsWindow.SetAchievementOutAnimation(AnimationDirection.UP.ToString());


            }
            else if (string.IsNullOrEmpty(CustomAchievementFile))
            {
                SelectCustomAchievementButton_Click(null, null);
            }

            if (!NotificationsWindow.IsDisposed)
            {
                NotificationsWindow.SetAchievementWidth(CustomAchievementEnabled ? Convert.ToInt32(CustomAchievementScale * GetVideoWidth(CustomAchievementFile)) : 1200); 
                NotificationsWindow.SetAchievementInAnimation(NotificationAchievementAnimationIn.ToString());
                NotificationsWindow.SetAchievementOutAnimation(NotificationAchievementAnimationOut.ToString());
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

                NotificationsWindow.SetMasteryInAnimation(AnimationDirection.STATIC.ToString());
                NotificationsWindow.SetMasteryOutAnimation(AnimationDirection.UP.ToString());
            }
            else if (string.IsNullOrEmpty(CustomMasteryFile))
            {
                SelectCustomMasteryNotificationButton_Click(null, null);
            }

            if (!NotificationsWindow.IsDisposed)
            {
                NotificationsWindow.SetMasteryWidth(this.useCustomMasteryCheckbox.Checked ? Convert.ToInt32(CustomMasteryScale * GetVideoWidth(CustomMasteryFile)) : 1200);
                NotificationsWindow.SetMasteryInAnimation(NotificationMasteryAnimationIn.ToString());
                NotificationsWindow.SetMasteryOutAnimation(NotificationMasteryAnimationOut.ToString());
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

                this.notificationsAchievementAnimationInComboBox.Enabled = true;
                this.notificationsAchievementAnimationOutComboBox.Enabled = true;
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

                this.notificationsAchievementAnimationInComboBox.Enabled = false;
                this.notificationsAchievementAnimationOutComboBox.Enabled = false;
            }

            NotificationsWindow.SetAchievementLeft(this.useCustomAchievementCheckbox.Checked ? CustomAchievementX : -15);
            NotificationsWindow.SetAchievementTop(this.useCustomAchievementCheckbox.Checked ? CustomAchievementY :  35);

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

                this.notificationsMasteryAnimationInComboBox.Enabled = true;
                this.notificationsMasteryAnimationOutComboBox.Enabled = true;
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

                this.notificationsMasteryAnimationInComboBox.Enabled = false;
                this.notificationsMasteryAnimationOutComboBox.Enabled = false;
            }

            NotificationsWindow.SetMasteryLeft(this.useCustomMasteryCheckbox.Checked ? CustomMasteryX : -15);
            NotificationsWindow.SetMasteryTop(this.useCustomMasteryCheckbox.Checked ? CustomMasteryY :  35);

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
                            this.useCustomAchievementCheckbox.Checked ? CustomAchievementOut : 5400);
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
                            this.useCustomAchievementCheckbox.Checked ? CustomAchievementOut : 5200);
            }

            NotificationsWindow.FireNotifications();
        }

        private void ShowGameMasteryButton_Click(object sender, EventArgs eventArgs)
        {
            NotificationsWindow.EnqueueMasteryNotification(UserSummary.GameSummaries[0],
                UserSummary.GameAchievementSummaries[0],
                this.useCustomMasteryCheckbox.Checked ? GetVideoDuration(CustomMasteryFile) : 11000,
                            this.useCustomMasteryCheckbox.Checked ? CustomMasteryIn : 0,
                            this.useCustomMasteryCheckbox.Checked ? CustomMasteryOut : 5200);

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
            if (StreamLabelsFocusEnable)
            {
                WriteFocusStreamLabels();
            }
        }

        private void HideFocusButton_Click(object sender, EventArgs e)
        {
            FocusWindow.HideFocus();
            ClearFocusStreamLabels();
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

            Binding awardsBinding = new Binding("Text", this, "Awards");
            awardsBinding.Format += new ConvertEventHandler((sender, convertEventArgs) =>
            {
                convertEventArgs.Value = "Awards: " + convertEventArgs.Value;
            });
            this.awardsLabel.DataBindings.Add(awardsBinding);

            Binding truePointsBinding = new Binding("Text", this, "TruePoints");
            truePointsBinding.Format += new ConvertEventHandler((sender, convertEventArgs) =>
            {
                convertEventArgs.Value = "True Points: " + convertEventArgs.Value;
            });
            this.truePointsLabel.DataBindings.Add(truePointsBinding);

            Binding ratioBinding = new Binding("Text", this, "Ratio");
            ratioBinding.Format += new ConvertEventHandler((sender, convertEventArgs) =>
            {
                convertEventArgs.Value = "Ratio: " + Ratio.ToString("0.00") + " %";
            });
            this.ratioLabel.DataBindings.Add(ratioBinding);
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

        private void OpenGameInfoWindowButton_Click(object sender, EventArgs e)
        {
            if (!GameInfoWindow.Visible)
            {
                CreateGameInfoWindow();
                GameInfoWindow.Show();
            }
        }

        private void OpenLastFiveWindowButton_Click(object sender, EventArgs e)
        {
            if (!LastFiveWindow.Visible)
            {
                CreateLastFiveWindow();
                LastFiveWindow.Show();
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

                MenuState = CustomMenuState.CLOSED;

                this.fontSizeNumericUpDown.Enabled = true;
                this.fontSizeNumericUpDown.Value = Convert.ToDecimal(StatsFontSize);

                this.fontColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.stats_font_color_hex_code);
                this.fontOutlineCheckBox.Checked = Settings.Default.stats_font_outline_enabled;
                this.backgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.stats_background_color);

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

                this.fontFamilyComboBox.SelectedIndex = Array.FindIndex(familyArray, row => row.Name == StatsFontFamily.Name);

                MenuState = CustomMenuState.STATS;

                this.fontSettingsGroupBox.Show();
                this.statsOverrideGroupBox.Show();
                this.ClientSize = new Size(592, 610);
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

                this.fontSizeNumericUpDown.Enabled = false;
                this.fontSizeNumericUpDown.Value = Convert.ToDecimal(1);

                this.fontColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.notification_font_color_hex_code);
                this.fontOutlineCheckBox.Checked = Settings.Default.notification_font_outline_enabled;
                this.backgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.notifications_background_color);

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

                this.fontFamilyComboBox.SelectedIndex = Array.FindIndex(familyArray, row => row.Name == NotificationsFontFamily.Name);

                MenuState = CustomMenuState.ALERTS;

                this.fontSettingsGroupBox.Show();
                this.ClientSize = new Size(592, 620);
                this.customAchievementSettingsGroupBox.Location = new Point(4, 313);
                this.customMasterySettingsGroupBox.Location = new Point(148, 313);
                this.customAchievementSettingsGroupBox.Show();
                this.customMasterySettingsGroupBox.Show();
            }
            else
            {
                HideAllMenuItems();
            }
        }

        private void CustomizeGameButton_Click(object sender, EventArgs e)
        {
            if (!MenuState.Equals(CustomMenuState.GAME_INFO))
            {
                this.lastFiveOverridesGroupBox.Hide();
                this.customAchievementSettingsGroupBox.Hide();
                this.customMasterySettingsGroupBox.Hide();
                this.statsOverrideGroupBox.Hide();
                this.focusOverridesGroupBox.Hide();

                MenuState = CustomMenuState.CLOSED;

                this.fontSizeNumericUpDown.Enabled = true;
                this.fontSizeNumericUpDown.Value = Convert.ToDecimal(GameInfoFontSize);

                this.fontColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.game_info_font_color_hex_code);
                this.fontOutlineCheckBox.Checked = Settings.Default.game_info_font_outline_enabled;
                this.backgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.game_info_background_color);

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

                this.fontFamilyComboBox.SelectedIndex = Array.FindIndex(familyArray, row => row.Name == GameInfoFontFamily.Name);

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

                MenuState = CustomMenuState.CLOSED;

                this.fontSizeNumericUpDown.Enabled = false;
                this.fontSizeNumericUpDown.Value = Convert.ToDecimal(1);

                this.fontColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.last_five_font_color_hex_code);
                this.fontOutlineCheckBox.Checked = Settings.Default.last_five_font_outline_enabled;
                this.backgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.last_five_background_color);

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

                this.fontFamilyComboBox.SelectedIndex = Array.FindIndex(familyArray, row => row.Name == LastFiveFontFamily.Name);

                MenuState = CustomMenuState.LAST_FIVE;

                this.fontSettingsGroupBox.Show();
                this.ClientSize = new Size(592, 449);
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
                this.focusOverridesGroupBox.Hide();

                MenuState = CustomMenuState.CLOSED;

                this.fontSizeNumericUpDown.Enabled = false;
                this.fontSizeNumericUpDown.Value = Convert.ToDecimal(1);

                this.fontColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.focus_font_color_hex_code);
                this.fontOutlineCheckBox.Checked = Settings.Default.focus_font_outline_enabled;
                this.backgroundColorPictureBox.BackColor = ColorTranslator.FromHtml(Settings.Default.focus_background_color);

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

                this.fontFamilyComboBox.SelectedIndex = Array.FindIndex(familyArray, row => row.Name == FocusFontFamily.Name);

                MenuState = CustomMenuState.FOCUS;

                this.fontSettingsGroupBox.Show();
                this.ClientSize = new Size(592, 475);
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

            this.ClientSize = new Size(592, 314);
        }

        private void HideButton_Click(object sender, EventArgs e)
        {
            HideAllMenuItems();

            this.BringToFront();
            this.Location = new Point(0, 0);
            this.SendToBack();

            if (NotificationsWindow != null && !NotificationsWindow.IsDisposed)
            {
                NotificationsWindow.BringToFront();
                NotificationsWindow.Location = new Point(0, 0);
                NotificationsWindow.SendToBack();
            }
            if (FocusWindow != null && !FocusWindow.IsDisposed)
            {
                FocusWindow.BringToFront();
                FocusWindow.Location = new Point(0, 0);
                FocusWindow.SendToBack();
            }
            if (StatsWindow != null && !StatsWindow.IsDisposed)
            {
                StatsWindow.BringToFront();
                StatsWindow.Location = new Point(0, 0);
                StatsWindow.SendToBack();
            }
            if (GameInfoWindow != null && !GameInfoWindow.IsDisposed)
            {
                GameInfoWindow.BringToFront();
                GameInfoWindow.Location = new Point(0, 0);
                GameInfoWindow.SendToBack();
            }
            if (LastFiveWindow != null && !LastFiveWindow.IsDisposed)
            {
                LastFiveWindow.BringToFront();
                LastFiveWindow.Location = new Point(0, 0);
                LastFiveWindow.SendToBack();
            }
        }

        private void SetFontColorButton_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.fontColorPictureBox.BackColor = this.colorDialog1.Color;
                switch (MenuState)
                {
                    case CustomMenuState.STATS:
                        MenuState = CustomMenuState.CLOSED;
                        StatsFontColor = HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.STATS;
                        break;
                    case CustomMenuState.ALERTS:
                        MenuState = CustomMenuState.CLOSED;
                        NotificationsFontColor = HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.ALERTS;
                        break;
                    case CustomMenuState.GAME_INFO:
                        MenuState = CustomMenuState.CLOSED;
                        GameInfoFontColor = HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.GAME_INFO;
                        break;
                    case CustomMenuState.LAST_FIVE:
                        MenuState = CustomMenuState.CLOSED;
                        LastFiveFontColor = HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.LAST_FIVE;
                        break;
                    case CustomMenuState.FOCUS:
                        MenuState = CustomMenuState.CLOSED;
                        FocusFontColor = HexConverter(this.colorDialog1.Color);
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
                        StatsFontOutlineColor = HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.STATS;
                        break;
                    case CustomMenuState.ALERTS:
                        MenuState = CustomMenuState.CLOSED;
                        NotificationsFontOutlineColor = HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.ALERTS;
                        break;
                    case CustomMenuState.GAME_INFO:
                        MenuState = CustomMenuState.CLOSED;
                        GameInfoFontOutlineColor = HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.GAME_INFO;
                        break;
                    case CustomMenuState.LAST_FIVE:
                        MenuState = CustomMenuState.CLOSED;
                        LastFiveFontOutlineColor = HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.LAST_FIVE;
                        break;
                    case CustomMenuState.FOCUS:
                        MenuState = CustomMenuState.CLOSED;
                        FocusFontOutlineColor = HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.FOCUS;
                        break;
                }
            }
        }

        private void FontFamilyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FontFamily[] familyArray = FontFamily.Families.ToArray();

            switch (MenuState)
            {
                case CustomMenuState.STATS:
                    MenuState = CustomMenuState.CLOSED;
                    StatsFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)this.fontFamilyComboBox.SelectedItem)];
                    MenuState = CustomMenuState.STATS;
                    break;
                case CustomMenuState.ALERTS:
                    MenuState = CustomMenuState.CLOSED;
                    NotificationsFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)this.fontFamilyComboBox.SelectedItem)];
                    MenuState = CustomMenuState.ALERTS;
                    break;
                case CustomMenuState.GAME_INFO:
                    MenuState = CustomMenuState.CLOSED;
                    GameInfoFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)this.fontFamilyComboBox.SelectedItem)];
                    MenuState = CustomMenuState.GAME_INFO;
                    break;
                case CustomMenuState.LAST_FIVE:
                    MenuState = CustomMenuState.CLOSED;
                    LastFiveFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)this.fontFamilyComboBox.SelectedItem)];
                    MenuState = CustomMenuState.LAST_FIVE;
                    break;
                case CustomMenuState.FOCUS:
                    MenuState = CustomMenuState.CLOSED;
                    FocusFontFamily = familyArray[Array.FindIndex(familyArray, row => row.Name == (string)this.fontFamilyComboBox.SelectedItem)];
                    MenuState = CustomMenuState.FOCUS;
                    break;
            }
        }
        private void AchievementAnimationInComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((string) this.notificationsAchievementAnimationInComboBox.SelectedItem)
            {
                case "DOWN":
                    NotificationAchievementAnimationIn = AnimationDirection.DOWN;
                    break;
                case "LEFT":
                    NotificationAchievementAnimationIn = AnimationDirection.LEFT;
                    break;
                case "RIGHT":
                    NotificationAchievementAnimationIn = AnimationDirection.RIGHT;
                    break;
                case "UP":
                    NotificationAchievementAnimationIn = AnimationDirection.UP;
                    break;
                default:
                    NotificationAchievementAnimationIn = AnimationDirection.STATIC;
                    break;
            }
        }
        private void AchievementAnimationOutComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((string)this.notificationsAchievementAnimationOutComboBox.SelectedItem)
            {
                case "DOWN":
                    NotificationAchievementAnimationOut = AnimationDirection.DOWN;
                    break;
                case "LEFT":
                    NotificationAchievementAnimationOut = AnimationDirection.LEFT;
                    break;
                case "RIGHT":
                    NotificationAchievementAnimationOut = AnimationDirection.RIGHT;
                    break;
                case "UP":
                    NotificationAchievementAnimationOut = AnimationDirection.UP;
                    break;
                default:
                    NotificationAchievementAnimationOut = AnimationDirection.STATIC;
                    break;
            }
        }
        private void MasteryAnimationInComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((string)this.notificationsMasteryAnimationInComboBox.SelectedItem)
            {
                case "DOWN":
                    NotificationMasteryAnimationIn = AnimationDirection.DOWN;
                    break;
                case "LEFT":
                    NotificationMasteryAnimationIn = AnimationDirection.LEFT;
                    break;
                case "RIGHT":
                    NotificationMasteryAnimationIn = AnimationDirection.RIGHT;
                    break;
                case "UP":
                    NotificationMasteryAnimationIn = AnimationDirection.UP;
                    break;
                default:
                    NotificationMasteryAnimationIn = AnimationDirection.STATIC;
                    break;
            }
        }
        private void MasteryAnimationOutComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((string)this.notificationsMasteryAnimationOutComboBox.SelectedItem)
            {
                case "DOWN":
                    NotificationMasteryAnimationOut = AnimationDirection.DOWN;
                    break;
                case "LEFT":
                    NotificationMasteryAnimationOut = AnimationDirection.LEFT;
                    break;
                case "RIGHT":
                    NotificationMasteryAnimationOut = AnimationDirection.RIGHT;
                    break;
                case "UP":
                    NotificationMasteryAnimationOut = AnimationDirection.UP;
                    break;
                default:
                    NotificationMasteryAnimationOut = AnimationDirection.STATIC;
                    break;
            }
        }
        private void FontOutlineNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            switch (MenuState)
            {
                case CustomMenuState.STATS:
                    StatsFontOutlineSize = (int)this.fontOutlineNumericUpDown.Value;
                    break;
                case CustomMenuState.ALERTS:
                    NotificationsFontOutlineSize = (int)this.fontOutlineNumericUpDown.Value;
                    break;
                case CustomMenuState.GAME_INFO:
                    GameInfoFontOutlineSize = (int)this.fontOutlineNumericUpDown.Value;
                    break;
                case CustomMenuState.LAST_FIVE:
                    LastFiveFontOutlineSize = (int)this.fontOutlineNumericUpDown.Value;
                    break;
                case CustomMenuState.FOCUS:
                    FocusFontOutlineSize = (int)this.fontOutlineNumericUpDown.Value;
                    break;
            }
        }
        private void FontSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            switch (MenuState)
            {
                case CustomMenuState.STATS:
                    StatsFontSize = (int)this.fontSizeNumericUpDown.Value;
                    break;
                case CustomMenuState.GAME_INFO:
                    GameInfoFontSize = (int)this.fontSizeNumericUpDown.Value;
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
                        this.fontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(StatsFontOutlineColor);
                        this.fontOutlineNumericUpDown.Value = StatsFontOutlineSize;
                        MenuState = CustomMenuState.STATS;
                    }

                    StatsFontOutlineEnable = isEnabled;
                    break;
                case CustomMenuState.ALERTS:
                    if (isEnabled)
                    {
                        MenuState = CustomMenuState.CLOSED;
                        this.fontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(NotificationsFontOutlineColor);
                        this.fontOutlineNumericUpDown.Value = NotificationsFontOutlineSize;
                        MenuState = CustomMenuState.ALERTS;
                    }

                    NotificationsFontOutlineEnable = isEnabled;
                    break;
                case CustomMenuState.GAME_INFO:
                    if (isEnabled)
                    {
                        MenuState = CustomMenuState.CLOSED;
                        this.fontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(GameInfoFontOutlineColor);
                        this.fontOutlineNumericUpDown.Value = GameInfoFontOutlineSize;
                        MenuState = CustomMenuState.GAME_INFO;
                    }

                    GameInfoFontOutlineEnable = isEnabled;
                    break;
                case CustomMenuState.LAST_FIVE:
                    if (isEnabled)
                    {
                        MenuState = CustomMenuState.CLOSED;
                        this.fontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(LastFiveFontOutlineColor);
                        this.fontOutlineNumericUpDown.Value = LastFiveFontOutlineSize;
                        MenuState = CustomMenuState.LAST_FIVE;
                    }

                    LastFiveFontOutlineEnable = isEnabled;
                    break;
                case CustomMenuState.FOCUS:
                    if (isEnabled)
                    {
                        MenuState = CustomMenuState.CLOSED;
                        this.fontOutlineColorPictureBox.BackColor = ColorTranslator.FromHtml(FocusFontOutlineColor);
                        this.fontOutlineNumericUpDown.Value = FocusFontOutlineSize;
                        MenuState = CustomMenuState.FOCUS;
                    }

                    FocusFontOutlineEnable = isEnabled;
                    break;
            }

            Settings.Default.Save();
        }
        private void SetBackgroundColorButton_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.backgroundColorPictureBox.BackColor = this.colorDialog1.Color;
                switch (MenuState)
                {
                    case CustomMenuState.STATS:
                        MenuState = CustomMenuState.CLOSED;
                        StatsBackgroundColor = HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.STATS;
                        break;
                    case CustomMenuState.ALERTS:
                        MenuState = CustomMenuState.CLOSED;
                        NotificationsBackgroundColor = HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.ALERTS;
                        break;
                    case CustomMenuState.GAME_INFO:
                        MenuState = CustomMenuState.CLOSED;
                        GameInfoBackgroundColor = HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.GAME_INFO;
                        break;
                    case CustomMenuState.LAST_FIVE:
                        MenuState = CustomMenuState.CLOSED;
                        LastFiveBackgroundColor = HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.LAST_FIVE;
                        break;
                    case CustomMenuState.FOCUS:
                        MenuState = CustomMenuState.CLOSED;
                        FocusBackgroundColor = HexConverter(this.colorDialog1.Color);
                        MenuState = CustomMenuState.FOCUS;
                        break;
                }
            }
        }
        private void AlertsStreamLabelsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StreamLabelsAlertsEnable = this.alertsStreamLabelsCheckBox.Checked;
            }
        }
        private void FocusStreamLabelsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StreamLabelsFocusEnable = this.focusStreamLabelsCheckBox.Checked;

                if (StreamLabelsFocusEnable)
                {
                    WriteFocusStreamLabels();
                }
            }
        }
        private void statsStreamLabelsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StreamLabelsStatsEnable = this.statsStreamLabelsCheckBox.Checked;

                if (StreamLabelsStatsEnable)
                {
                    WriteStatsStreamLabels();
                }
            }
        }
        private void gameInfoStreamLabelsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StreamLabelsGameInfoEnable = this.gameInfoStreamLabelsCheckBox.Checked;

                if (StreamLabelsGameInfoEnable)
                {
                    WriteGameInfoStreamLabels();
                }
            }
        }
        private void lastFiveStreamLabelsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StreamLabelsLastFiveEnable = this.lastFiveStreamLabelsCheckBox.Checked;

                if (StreamLabelsLastFiveEnable)
                {
                    WriteLastFiveStreamLabels();
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

        private void StatsRankCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StatsRankEnable = this.statsRankCheckBox.Checked;
            }
        }

        private void statsPointsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StatsPointsEnable = this.statsPointsCheckBox.Checked;
            }
        }

        private void statsAwardsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StatsAwardsEnable = this.statsAwardsCheckBox.Checked;
            }
        }

        private void statsTruePointsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StatsTruePointsEnable = this.statsTruePointsCheckBox.Checked;
            }
        }

        private void statsRatioCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StatsRatioEnable = this.statsRatioCheckBox.Checked;
            }
        }

        private void statsGameRatioCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StatsGameRatioEnable = this.statsGameRatioCheckBox.Checked;
            }
        }

        private void statsGamePointsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StatsGamePointsEnable = this.statsGamePointsCheckBox.Checked;
            }
        }

        private void statsGameTruePointsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StatsGameTruePointsEnable = this.statsGameTruePointsCheckBox.Checked;
            }
        }

        private void statsGameAchievementsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StatsGameAchievementsEnable = this.statsGameAchievementsCheckBox.Checked;
            }
        }

        private void statsCompletedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StatsCompletedEnable = this.statsCompletedCheckBox.Checked;
            }
        }

        private void statsRankOverrideTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StatsRankName = this.statsRankOverrideTextBox.Text;
            }
        }
        private void statsCompletedTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StatsCompletedName = this.statsCompletedOverrideTextBox.Text;
            }
        }

        private void statsPointsOverrideTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StatsPointsName = this.statsPointsOverrideTextBox.Text;
            }
        }

        private void statsAwardsOverrideTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StatsAwardsName = this.statsAwardsOverrideTextBox.Text;
            }
        }

        private void statsTruePointsOverrideTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StatsTruePointsName = this.statsTruePointsOverrideTextBox.Text;
            }
        }

        private void statsRatioOverrideTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StatsRatioName = this.statsRatioOverrideTextBox.Text;
            }
        }

        private void statsGameRatioOverrideTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StatsGameRatioName = this.statsGameRatioOverrideTextBox.Text;
            }
        }

        private void statsGamePointsOverrideTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StatsGamePointsName = this.statsGamePointsOverrideTextBox.Text;
            }
        }

        private void statsGameTruePointsOverrideTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StatsGameTruePointsName = this.statsGameTruePointsOverrideTextBox.Text;
            }

        }
        private void statsGameAchievementsOverrideTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                StatsGameAchievementsName = this.statsGameAchievementsOverrideTextBox.Text;
            }
        }
        private void gameInfoTitleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                GameInfoTitleEnable = this.gameInfoTitleCheckBox.Checked;
            }
        }
        private void gameInfoConsoleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                GameInfoConsoleEnable = this.gameInfoConsoleCheckBox.Checked;
            }
        }

        private void gameInfoDeveloperCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                GameInfoDeveloperEnable = this.gameInfoDeveloperCheckBox.Checked;
            }
        }

        private void gameInfoPublisherCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                GameInfoPublisherEnable = this.gameInfoPublisherCheckBox.Checked;
            }
        }

        private void gameInfoGenreCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                GameInfoGenreEnable = this.gameInfoGenreCheckBox.Checked;
            }
        }

        private void gameInfoReleaseDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                GameInfoReleaseDateEnable = this.gameInfoReleaseDateCheckBox.Checked;
            }
        }
        private void focusPointsEnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                FocusPointsEnable = this.focusPointsEnable.Checked;
            }
        }

        private void gameInfoConsoleOverrideTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                GameInfoConsoleName = this.gameInfoConsoleOverrideTextBox.Text;
            }
        }

        private void gameInfoDeveloperOverrideTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                GameInfoDeveloperName = this.gameInfoDeveloperOverrideTextBox.Text;
            }
        }

        private void gameInfoPublisherOverrideTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                GameInfoPublisherName = this.gameInfoPublisherOverrideTextBox.Text;
            }
        }

        private void gameInfoGenreOverrideTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                GameInfoGenreName = this.gameInfoGenreOverrideTextBox.Text;
            }
        }

        private void gameInfoReleaseDateOverrideTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                GameInfoReleaseDateName = this.gameInfoReleaseDateOverrideTextBox.Text;
            }
        }

        private void gameInfoTitleOverrideTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NotBooting)
            {
                GameInfoTitleName = this.gameInfoTitleOverrideTextBox.Text;
            }
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
