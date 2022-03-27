using Retro_Achievement_Tracker.Properties;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Retro_Achievement_Tracker.Controllers
{
    public sealed class StatsController
    {
        private static StatsController instance = new StatsController();
        private static StatsWindow StatsWindow;
        public static bool IsOpen;

        private string rank;
        private string awards;
        private string ratio;
        private string points;
        private string truePoints;

        private string completed;
        private string gameAchievementsEarned;
        private string gameAchievementsPossible;
        private string gamePointsEarned;
        private string gamePointsPossible;
        private string gameTruePointsEarned;
        private string gameTruePointsPossible;

        private StatsController()
        {
            StatsWindow = new StatsWindow();
            IsOpen = false;
        }
        public static StatsController Instance
        {
            get
            {
                return instance;
            }
        }
        public void Close()
        {
            StatsWindow.Close();
        }
        public void Show()
        {
            if (!IsOpen)
            {
                StatsWindow = new StatsWindow();
                StatsWindow.Show();
            }
        }
        public void SetAllSettings()
        {

            if (IsOpen)
            {
                StatsWindow.AssignJavaScriptVariables();
                if (AdvancedSettingsEnabled)
                {
                    SetAdvancedSettings();
                }
                else
                {
                    SetSimpleSettings();
                }

                StatsWindow.SetWindowBackgroundColor(WindowBackgroundColor);
                StatsWindow.SetAwardsName(AwardsName);
                StatsWindow.SetRankName(RankName);
                StatsWindow.SetPointsName(PointsName);
                StatsWindow.SetRatioName(RatioName);
                StatsWindow.SetTruePointsName(TruePointsName);

                StatsWindow.SetGameAchievementsName(GameAchievementsName);
                StatsWindow.SetGamePointsName(GamePointsName);
                StatsWindow.SetGameTruePointsName(GameTruePointsName);
                StatsWindow.SetGameRatioName(GameRatioName);
                StatsWindow.SetCompletedName(CompletedName);

                if (!string.IsNullOrEmpty(rank))
                {
                    StatsWindow.SetRankValue(rank);
                    StatsWindow.SetAwardsValue(awards);
                    StatsWindow.SetPointsValue(points);
                    StatsWindow.SetRatioValue(ratio);
                    StatsWindow.SetTruePointsValue(truePoints);

                    StatsWindow.SetGameAchievementsValue(gameAchievementsEarned + " " + DividerCharacter + " " + gameAchievementsPossible);
                    StatsWindow.SetGamePointsValue(gamePointsEarned + " " + DividerCharacter + " " + gamePointsPossible);
                    StatsWindow.SetGameTruePointsValue(gameTruePointsEarned + " " + DividerCharacter + " " + gameTruePointsPossible);
                    StatsWindow.SetGameRatioValue(GameRatio);
                    StatsWindow.SetCompletedValue(completed);
                }

                StatsWindow.SetRankVisibility(RankEnabled);
                StatsWindow.SetAwardsVisibility(AwardsEnabled);
                StatsWindow.SetPointsVisibility(PointsEnabled);
                StatsWindow.SetRatioVisibility(RatioEnabled);
                StatsWindow.SetTruePointsVisibility(TruePointsEnabled);
                StatsWindow.SetGameAchievementsVisibility(GameAchievementsEnabled);
                StatsWindow.SetGamePointsVisibility(GamePointsEnabled);
                StatsWindow.SetGameTruePointsVisibility(GameTruePointsEnabled);
                StatsWindow.SetGameRatioVisibility(GameRatioEnabled);
                StatsWindow.SetCompletedVisibility(CompletedEnabled);
            }
        }
        public void SetSimpleSettings()
        {
            StatsWindow.SetSimpleFontFamily(SimpleFontFamily);
            StatsWindow.SetSimpleFontColor(SimpleFontColor);
            StatsWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px");
        }
        public void SetAdvancedSettings()
        {
            StatsWindow.SetNameFontFamily(NameFontFamily);
            StatsWindow.SetNameColor(NameColor);
            StatsWindow.SetNameOutline(NameOutlineEnabled ? NameOutlineColor + " " + NameOutlineSize + "px" : "0px");

            StatsWindow.SetValueFontFamily(ValueFontFamily);
            StatsWindow.SetValueColor(ValueColor);
            StatsWindow.SetValueOutline(ValueOutlineEnabled ? ValueOutlineColor + " " + ValueOutlineSize + "px" : "0px");
        }

        internal void SetRank(string value)
        {
            rank = value;

            if (IsOpen)
            {
                StatsWindow.SetRankValue(value);
            }
        }

        internal void SetRatio(string value)
        {
            ratio = value + (UsePercentageSymbol ? " %" : "");

            if (IsOpen)
            {
                StatsWindow.SetRatioValue(value);
            }
        }

        internal void SetAwards(string value)
        {
            awards = value;

            if (IsOpen)
            {
                StatsWindow.SetAwardsValue(value);
            }
        }

        internal void SetPoints(string value)
        {
            points = value;

            if (IsOpen)
            {
                StatsWindow.SetPointsValue(value);
            }
        }

        internal void SetTruePoints(string value)
        {
            truePoints = value;

            if (IsOpen)
            {
                StatsWindow.SetTruePointsValue(value);
            }
        }

        internal void SetGamePoints(string pointsEarned, string pointsPossible)
        {
            gamePointsEarned = pointsEarned;
            gamePointsPossible = pointsPossible;


            if (IsOpen)
            {
                StatsWindow.SetGamePointsValue(pointsEarned + " " + DividerCharacter + " " + pointsPossible);
            }
        }

        internal void SetGameAchievements(string achievementsEarned, string achievementsPossible)
        {
            gameAchievementsEarned = achievementsEarned;
            gameAchievementsPossible = achievementsPossible;


            if (IsOpen)
            {
                StatsWindow.SetGameAchievementsValue(achievementsEarned + " " + DividerCharacter + " " + achievementsPossible);
            }
        }

        internal void SetGameTruePoints(string truePointsEarned, string truePointsPossible)
        {
            gameTruePointsEarned = truePointsEarned;
            gameTruePointsPossible = truePointsPossible;


            if (IsOpen)
            {
                StatsWindow.SetGameTruePointsValue(truePointsEarned + " " + DividerCharacter + " " + truePointsPossible);
            }
        }

        internal void SetGameRatio()
        {

            if (IsOpen)
            {
                StatsWindow.SetGameRatioValue(GameRatio);
            }
        }

        internal void SetCompleted(float value)
        {
            completed = value.ToString("0.00") + (UsePercentageSymbol ? " %" : "");

            if (IsOpen)
            {
                StatsWindow.SetCompletedValue(completed);
            }
        }
        /**
         * Variables
         */
        public string GameRatio
        {
            get
            {
                if (gamePointsPossible == "0")
                {
                    return UsePercentageSymbol ? "0 %" : "0";
                }
                return (float.Parse(gameTruePointsPossible) / float.Parse(gamePointsPossible)).ToString("0.00") + (UsePercentageSymbol ? " %" : "");
            }
        }
        public string WindowBackgroundColor
        {
            get
            {
                return Settings.Default.stats_window_background_color;
            }
            set
            {
                Settings.Default.stats_window_background_color = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.SetWindowBackgroundColor(value);
                }
            }
        }
        public bool AdvancedSettingsEnabled
        {
            get
            {
                return Settings.Default.stats_advanced_options_enabled;
            }
            set
            {
                Settings.Default.stats_advanced_options_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    SetAllSettings();
                }
            }
        }
        public FontFamily SimpleFontFamily
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

                return familyArray[0];
            }
            set
            {
                Settings.Default.stats_font_family_name = value.Name;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.AssignJavaScriptVariables();
                    StatsWindow.SetSimpleFontFamily(SimpleFontFamily);
                }
            }
        }
        public string SimpleFontColor
        {
            get
            {
                return Settings.Default.stats_font_color_hex_code;
            }
            set
            {
                Settings.Default.stats_font_color_hex_code = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.AssignJavaScriptVariables();
                    StatsWindow.SetSimpleFontColor(value);
                }
            }
        }
        public string SimpleFontOutlineColor
        {
            get
            {
                return Settings.Default.stats_font_outline_color_hex;
            }
            set
            {
                Settings.Default.stats_font_outline_color_hex = value;
                Settings.Default.Save();


                if (IsOpen)
                {
                    StatsWindow.AssignJavaScriptVariables();
                    StatsWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px");
                }
            }
        }
        public int SimpleFontOutlineSize
        {
            get
            {
                return Settings.Default.stats_font_outline_size;
            }
            set
            {
                Settings.Default.stats_font_outline_size = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.AssignJavaScriptVariables();
                    StatsWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px");
                }
            }
        }
        public bool SimpleFontOutlineEnabled
        {
            get
            {
                return Settings.Default.stats_font_outline_enabled;
            }
            set
            {
                Settings.Default.stats_font_outline_enabled = value;
                Settings.Default.Save();


                if (IsOpen)
                {
                    StatsWindow.AssignJavaScriptVariables();
                    StatsWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px");
                }
            }
        }
        public FontFamily NameFontFamily
        {
            get
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily font in familyArray)
                {
                    if (font.Name.Equals(Settings.Default.stats_name_font_family))
                    {
                        return font;
                    }
                }
                Settings.Default.stats_name_font_family = familyArray[0].Name;

                return familyArray[0];
            }
            set
            {
                Settings.Default.stats_name_font_family = value.Name;
                Settings.Default.Save();
                if (IsOpen)
                {
                    StatsWindow.AssignJavaScriptVariables();
                    StatsWindow.SetNameFontFamily(NameFontFamily);
                }
            }
        }
        public FontFamily ValueFontFamily
        {
            get
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily font in familyArray)
                {
                    if (font.Name.Equals(Settings.Default.stats_value_font_family))
                    {
                        return font;
                    }
                }
                Settings.Default.stats_value_font_family = familyArray[0].Name;

                return familyArray[0];
            }
            set
            {
                Settings.Default.stats_value_font_family = value.Name;
                Settings.Default.Save();
                if (IsOpen)
                {
                    StatsWindow.AssignJavaScriptVariables();
                    StatsWindow.SetValueFontFamily(ValueFontFamily);
                }
            }
        }

        public string NameColor
        {
            get
            {
                return Settings.Default.stats_name_color;
            }
            set
            {
                Settings.Default.stats_name_color = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.AssignJavaScriptVariables();
                    StatsWindow.SetNameColor(value);
                }
            }
        }
        public string ValueColor
        {
            get
            {
                return Settings.Default.stats_value_color;
            }
            set
            {
                Settings.Default.stats_value_color = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.AssignJavaScriptVariables();
                    StatsWindow.SetValueColor(value);
                }
            }
        }
        public bool NameOutlineEnabled
        {
            get
            {
                return Settings.Default.stats_name_outline_enabled;
            }
            set
            {
                Settings.Default.stats_name_outline_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.AssignJavaScriptVariables();
                    StatsWindow.SetNameOutline(value ? NameOutlineColor + " " + NameOutlineSize + "px" : "0px");
                }
            }
        }
        public bool ValueOutlineEnabled
        {
            get
            {
                return Settings.Default.stats_value_outline_enabled;
            }
            set
            {
                Settings.Default.stats_value_outline_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.AssignJavaScriptVariables();
                    StatsWindow.SetValueOutline(value ? ValueOutlineColor + " " + ValueOutlineSize + "px" : "0px");
                }
            }
        }
        public string NameOutlineColor
        {
            get
            {
                return Settings.Default.stats_name_outline_color;
            }
            set
            {
                Settings.Default.stats_name_outline_color = value;
                Settings.Default.Save();


                if (IsOpen)
                {
                    StatsWindow.AssignJavaScriptVariables();
                    StatsWindow.SetNameOutline(NameOutlineEnabled ? NameOutlineColor + " " + NameOutlineSize + "px" : "0px");
                }
            }
        }
        public string ValueOutlineColor
        {
            get
            {
                return Settings.Default.stats_value_outline_color;
            }
            set
            {
                Settings.Default.stats_value_outline_color = value;
                Settings.Default.Save();
                if (IsOpen)
                {
                    StatsWindow.AssignJavaScriptVariables();
                    StatsWindow.SetValueOutline(ValueOutlineEnabled ? ValueOutlineColor + " " + ValueOutlineSize + "px" : "0px");
                }
            }
        }
        public int NameOutlineSize
        {
            get
            {
                return Settings.Default.stats_name_outline_size;
            }
            set
            {
                Settings.Default.stats_name_outline_size = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.AssignJavaScriptVariables();
                    StatsWindow.SetNameOutline(NameOutlineColor + " " + NameOutlineSize + "px");
                }
            }
        }
        public int ValueOutlineSize
        {
            get
            {
                return Settings.Default.stats_value_outline_size;
            }
            set
            {
                Settings.Default.stats_value_outline_size = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.AssignJavaScriptVariables();
                    StatsWindow.SetValueOutline(ValueOutlineColor + " " + ValueOutlineSize + "px");
                }
            }
        }
        public string RankName
        {
            get
            {
                return Settings.Default.stats_rank_name;
            }
            set
            {
                Settings.Default.stats_rank_name = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.SetRankName(value);
                }
            }
        }
        public string AwardsName
        {
            get
            {
                return Settings.Default.stats_awards_name;
            }
            set
            {
                Settings.Default.stats_awards_name = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.SetAwardsName(value);
                }
            }
        }
        public string PointsName
        {
            get
            {
                return Settings.Default.stats_points_name;
            }
            set
            {
                Settings.Default.stats_points_name = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.SetPointsName(value);
                }
            }
        }
        public string TruePointsName
        {
            get
            {
                return Settings.Default.stats_game_true_points_name;
            }
            set
            {
                Settings.Default.stats_game_true_points_name = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.SetTruePointsName(value);
                }
            }
        }
        public string RatioName
        {
            get
            {
                return Settings.Default.stats_ratio_name;
            }
            set
            {
                Settings.Default.stats_ratio_name = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.SetRatioName(value);
                }
            }
        }
        public string GameRatioName
        {
            get
            {
                return Settings.Default.stats_game_ratio_name;
            }
            set
            {
                Settings.Default.stats_game_ratio_name = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.SetGameRatioName(value);
                }
            }
        }
        public string GamePointsName
        {
            get
            {
                return Settings.Default.stats_game_points_name;
            }
            set
            {
                Settings.Default.stats_game_points_name = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.SetGamePointsName(value);
                }
            }
        }
        public string GameTruePointsName
        {
            get
            {
                return Settings.Default.stats_game_true_points_name;
            }
            set
            {
                Settings.Default.stats_game_true_points_name = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.SetGameTruePointsName(value);
                }
            }
        }
        public string GameAchievementsName
        {
            get
            {
                return Settings.Default.stats_game_achievements_name;
            }
            set
            {
                Settings.Default.stats_game_achievements_name = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.SetGameAchievementsName(value);
                }
            }
        }
        public string CompletedName
        {
            get
            {
                return Settings.Default.stats_completed_name;
            }
            set
            {
                Settings.Default.stats_completed_name = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.SetCompletedName(value);
                }
            }
        }
        public bool RankEnabled
        {
            get
            {
                return Settings.Default.stats_rank_enabled;
            }
            set
            {
                Settings.Default.stats_rank_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.SetRankVisibility(value);
                }
            }
        }
        public bool AwardsEnabled
        {
            get
            {
                return Settings.Default.stats_awards_enabled;
            }
            set
            {
                Settings.Default.stats_awards_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.SetAwardsVisibility(value);
                }
            }
        }
        public bool PointsEnabled
        {
            get
            {
                return Settings.Default.stats_points_enabled;
            }
            set
            {
                Settings.Default.stats_points_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.SetPointsVisibility(value);
                }
            }
        }
        public bool TruePointsEnabled
        {
            get
            {
                return Settings.Default.stats_true_points_enabled;
            }
            set
            {
                Settings.Default.stats_true_points_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.SetTruePointsVisibility(value);
                }
            }
        }
        public bool RatioEnabled
        {
            get
            {
                return Settings.Default.stats_ratio_enabled;
            }
            set
            {
                Settings.Default.stats_ratio_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.SetRatioVisibility(value);
                }
            }
        }
        public bool GameRatioEnabled
        {
            get
            {
                return Settings.Default.stats_game_ratio_enabled;
            }
            set
            {
                Settings.Default.stats_game_ratio_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.SetGameRatioVisibility(value);
                }
            }
        }
        public bool GamePointsEnabled
        {
            get
            {
                return Settings.Default.stats_game_points_enabled;
            }
            set
            {
                Settings.Default.stats_game_points_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.SetGamePointsVisibility(value);
                }
            }
        }
        public bool GameTruePointsEnabled
        {
            get
            {
                return Settings.Default.stats_game_true_points_enabled;
            }
            set
            {
                Settings.Default.stats_game_true_points_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.SetGameTruePointsVisibility(value);
                }
            }
        }
        public bool GameAchievementsEnabled
        {
            get
            {
                return Settings.Default.stats_game_achievements_enabled;
            }
            set
            {
                Settings.Default.stats_game_achievements_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.SetGameAchievementsVisibility(value);
                }
            }
        }
        public bool CompletedEnabled
        {
            get
            {
                return Settings.Default.stats_completed_enabled;
            }
            set
            {
                Settings.Default.stats_completed_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    StatsWindow.SetCompletedVisibility(value);
                }
            }
        }
        public bool AutoLaunch
        {
            get
            {
                return Settings.Default.auto_stats;
            }
            set
            {
                Settings.Default.auto_stats = value;
                Settings.Default.Save();
            }
        }
        public string DividerCharacter
        {
            get
            {
                return Settings.Default.stats_divider_character_selection;
            }
            set
            {
                Settings.Default.stats_divider_character_selection = value;
                Settings.Default.Save();
            }
        }

        public bool UsePercentageSymbol
        {
            get
            {
                return Settings.Default.stats_percentage_char;
            }
            set
            {
                Settings.Default.stats_percentage_char = value;
                Settings.Default.Save();
            }
        }
    }
}
