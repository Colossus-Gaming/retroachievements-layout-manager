using Retro_Achievement_Tracker.Forms;
using Retro_Achievement_Tracker.Properties;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Retro_Achievement_Tracker.Controllers
{
    public sealed class GameStatsController
    {
        private static GameStatsController instance = new GameStatsController();
        private static GameStatsWindow GameStatsWindow;
        public static bool IsOpen;

        private string completed;
        private string gameAchievementsEarned;
        private string gameAchievementsPossible;
        private string gamePointsEarned;
        private string gamePointsPossible;
        private string gameTruePointsEarned;
        private string gameTruePointsPossible;

        private GameStatsController()
        {
            GameStatsWindow = new GameStatsWindow();
            IsOpen = false;
        }
        public static GameStatsController Instance
        {
            get
            {
                return instance;
            }
        }
        public void Close()
        {
            GameStatsWindow.Close();
        }
        public void Show()
        {
            if (!IsOpen)
            {
                GameStatsWindow = new GameStatsWindow();
                GameStatsWindow.Show();
            }
        }
        public void SetAllSettings()
        {

            if (IsOpen)
            {
                GameStatsWindow.AssignJavaScriptVariables();
                GameStatsWindow.SetWindowBackgroundColor(WindowBackgroundColor);

                if (AdvancedSettingsEnabled)
                {
                    SetAdvancedSettings();
                }
                else
                {
                    SetSimpleSettings();
                }

                GameStatsWindow.SetGameAchievementsName(GameAchievementsName);
                GameStatsWindow.SetGamePointsName(GamePointsName);
                GameStatsWindow.SetGameTruePointsName(GameTruePointsName);
                GameStatsWindow.SetCompletedName(CompletedName);
                GameStatsWindow.SetGameRatioName(GameRatioName);

                if (!string.IsNullOrEmpty(gameAchievementsEarned))
                {  
                    GameStatsWindow.SetGameAchievementsValue(gameAchievementsEarned + " " + DividerCharacter + " " + gameAchievementsPossible);
                    GameStatsWindow.SetGamePointsValue(gamePointsEarned + " " + DividerCharacter + " " + gamePointsPossible);
                    GameStatsWindow.SetGameTruePointsValue(gameTruePointsEarned + " " + DividerCharacter + " " + gameTruePointsPossible);
                    GameStatsWindow.SetCompletedValue(completed);
                    GameStatsWindow.SetGameRatioValue(GameRatio);
                }

                GameStatsWindow.SetGameAchievementsVisibility(GameAchievementsEnabled);
                GameStatsWindow.SetGamePointsVisibility(GamePointsEnabled);
                GameStatsWindow.SetGameTruePointsVisibility(GameTruePointsEnabled);
                GameStatsWindow.SetCompletedVisibility(CompletedEnabled);
                GameStatsWindow.SetGameRatioVisibility(GameRatioEnabled);
            }
        }
        public void SetSimpleSettings()
        {
            GameStatsWindow.SetSimpleFontFamily(SimpleFontFamily);
            GameStatsWindow.SetSimpleFontColor(SimpleFontColor);
            GameStatsWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px");
        }
        public void SetAdvancedSettings()
        {
            GameStatsWindow.SetNameFontFamily(NameFontFamily);
            GameStatsWindow.SetNameColor(NameColor);
            GameStatsWindow.SetNameOutline(NameOutlineEnabled ? NameOutlineColor + " " + NameOutlineSize + "px" : "0px");

            GameStatsWindow.SetValueFontFamily(ValueFontFamily);
            GameStatsWindow.SetValueColor(ValueColor);
            GameStatsWindow.SetValueOutline(ValueOutlineEnabled ? ValueOutlineColor + " " + ValueOutlineSize + "px" : "0px");
        }


        internal void SetGamePoints(string pointsEarned, string pointsPossible)
        {
            gamePointsEarned = pointsEarned;
            gamePointsPossible = pointsPossible;


            if (IsOpen)
            {
                GameStatsWindow.SetGamePointsValue(pointsEarned + " " + DividerCharacter + " " + pointsPossible);
            }
        }

        internal void SetGameAchievements(string achievementsEarned, string achievementsPossible)
        {
            gameAchievementsEarned = achievementsEarned;
            gameAchievementsPossible = achievementsPossible;


            if (IsOpen)
            {
                GameStatsWindow.SetGameAchievementsValue(achievementsEarned + " " + DividerCharacter + " " + achievementsPossible);
            }
        }

        internal void SetGameTruePoints(string truePointsEarned, string truePointsPossible)
        {
            gameTruePointsEarned = truePointsEarned;
            gameTruePointsPossible = truePointsPossible;


            if (IsOpen)
            {
                GameStatsWindow.SetGameTruePointsValue(truePointsEarned + " " + DividerCharacter + " " + truePointsPossible);
            }
        }

        internal void SetGameRatio()
        {

            if (IsOpen)
            {
                GameStatsWindow.SetGameRatioValue(GameRatio);
            }
        }

        internal void SetCompleted(float value)
        {
            completed = value.ToString("0.00");

            if (IsOpen)
            {
                GameStatsWindow.SetCompletedValue(completed + "%");
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
                    return "0.00%";
                }
                return (float.Parse(gameTruePointsPossible) / float.Parse(gamePointsPossible)).ToString("0.00") + "%";
            }
        }
        public string WindowBackgroundColor
        {
            get
            {
                return Settings.Default.game_stats_window_background_color;
            }
            set
            {
                Settings.Default.game_stats_window_background_color = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameStatsWindow.SetWindowBackgroundColor(value);
                }
            }
        }
        public bool AdvancedSettingsEnabled
        {
            get
            {
                return Settings.Default.game_stats_advanced_options_enabled;
            }
            set
            {
                Settings.Default.game_stats_advanced_options_enabled = value;
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
                    if (font.Name.Equals(Settings.Default.game_stats_font_family_name))
                    {
                        return font;
                    }
                }
                Settings.Default.game_stats_font_family_name = familyArray[0].Name;

                return familyArray[0];
            }
            set
            {
                Settings.Default.game_stats_font_family_name = value.Name;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameStatsWindow.SetSimpleFontFamily(SimpleFontFamily);
                }
            }
        }
        public string SimpleFontColor
        {
            get
            {
                return Settings.Default.game_stats_font_color_hex_code;
            }
            set
            {
                Settings.Default.game_stats_font_color_hex_code = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameStatsWindow.SetSimpleFontColor(value);
                }
            }
        }
        public string SimpleFontOutlineColor
        {
            get
            {
                return Settings.Default.game_stats_font_outline_color_hex;
            }
            set
            {
                Settings.Default.game_stats_font_outline_color_hex = value;
                Settings.Default.Save();


                if (IsOpen)
                {
                    GameStatsWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px");
                }
            }
        }
        public int SimpleFontOutlineSize
        {
            get
            {
                return Settings.Default.game_stats_font_outline_size;
            }
            set
            {
                Settings.Default.game_stats_font_outline_size = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameStatsWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px");
                }
            }
        }
        public bool SimpleFontOutlineEnabled
        {
            get
            {
                return Settings.Default.game_stats_font_outline_enabled;
            }
            set
            {
                Settings.Default.game_stats_font_outline_enabled = value;
                Settings.Default.Save();


                if (IsOpen)
                {
                    GameStatsWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px");
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
                    if (font.Name.Equals(Settings.Default.game_stats_name_font_family))
                    {
                        return font;
                    }
                }
                Settings.Default.game_stats_name_font_family = familyArray[0].Name;

                return familyArray[0];
            }
            set
            {
                Settings.Default.game_stats_name_font_family = value.Name;
                Settings.Default.Save();
                if (IsOpen)
                {
                    GameStatsWindow.SetNameFontFamily(NameFontFamily);
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
                    if (font.Name.Equals(Settings.Default.game_stats_value_font_family))
                    {
                        return font;
                    }
                }

                Settings.Default.game_stats_value_font_family = familyArray[0].Name;

                return familyArray[0];
            }
            set
            {
                Settings.Default.game_stats_value_font_family = value.Name;
                Settings.Default.Save();
                if (IsOpen)
                {
                    GameStatsWindow.SetValueFontFamily(ValueFontFamily);
                }
            }
        }

        public string NameColor
        {
            get
            {
                return Settings.Default.game_stats_name_color;
            }
            set
            {
                Settings.Default.game_stats_name_color = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameStatsWindow.SetNameColor(value);
                }
            }
        }
        public string ValueColor
        {
            get
            {
                return Settings.Default.game_stats_value_color;
            }
            set
            {
                Settings.Default.game_stats_value_color = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameStatsWindow.SetValueColor(value);
                }
            }
        }
        public bool NameOutlineEnabled
        {
            get
            {
                return Settings.Default.game_stats_name_outline_enabled;
            }
            set
            {
                Settings.Default.game_stats_name_outline_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameStatsWindow.SetNameOutline(value ? NameOutlineColor + " " + NameOutlineSize + "px" : "0px");
                }
            }
        }
        public bool ValueOutlineEnabled
        {
            get
            {
                return Settings.Default.game_stats_value_outline_enabled;
            }
            set
            {
                Settings.Default.game_stats_value_outline_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameStatsWindow.SetValueOutline(value ? ValueOutlineColor + " " + ValueOutlineSize + "px" : "0px");
                }
            }
        }
        public string NameOutlineColor
        {
            get
            {
                return Settings.Default.game_stats_name_outline_color;
            }
            set
            {
                Settings.Default.game_stats_name_outline_color = value;
                Settings.Default.Save();


                if (IsOpen)
                {
                    GameStatsWindow.SetNameOutline(NameOutlineEnabled ? NameOutlineColor + " " + NameOutlineSize + "px" : "0px");
                }
            }
        }
        public string ValueOutlineColor
        {
            get
            {
                return Settings.Default.game_stats_value_outline_color;
            }
            set
            {
                Settings.Default.game_stats_value_outline_color = value;
                Settings.Default.Save();
                if (IsOpen)
                {
                    GameStatsWindow.SetValueOutline(ValueOutlineEnabled ? ValueOutlineColor + " " + ValueOutlineSize + "px" : "0px");
                }
            }
        }
        public int NameOutlineSize
        {
            get
            {
                return Settings.Default.game_stats_name_outline_size;
            }
            set
            {
                Settings.Default.game_stats_name_outline_size = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameStatsWindow.SetNameOutline(NameOutlineColor + " " + NameOutlineSize + "px");
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
                    GameStatsWindow.SetValueOutline(ValueOutlineColor + " " + ValueOutlineSize + "px");
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
                    GameStatsWindow.SetGameRatioName(value);
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
                    GameStatsWindow.SetGamePointsName(value);
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
                    GameStatsWindow.SetGameTruePointsName(value);
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
                    GameStatsWindow.SetGameAchievementsName(value);
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
                    GameStatsWindow.SetCompletedName(value);
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
                    GameStatsWindow.SetGameRatioVisibility(value);
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
                    GameStatsWindow.SetGamePointsVisibility(value);
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
                    GameStatsWindow.SetGameTruePointsVisibility(value);
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
                    GameStatsWindow.SetGameAchievementsVisibility(value);
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
                    GameStatsWindow.SetCompletedVisibility(value);
                }
            }
        }
        public bool AutoLaunch
        {
            get
            {
                return Settings.Default.auto_game_stats;
            }
            set
            {
                Settings.Default.auto_game_stats = value;
                Settings.Default.Save();
            }
        }
        public string DividerCharacter
        {
            get
            {
                return Settings.Default.game_stats_divider_character_selection;
            }
            set
            {
                Settings.Default.game_stats_divider_character_selection = value;
                Settings.Default.Save();

                SetGameAchievements(gameAchievementsEarned, gameAchievementsPossible);
                SetGamePoints(gamePointsEarned, gamePointsPossible);
                SetGameTruePoints(gameTruePointsEarned, gameTruePointsPossible);
            }
        }
    }
}
