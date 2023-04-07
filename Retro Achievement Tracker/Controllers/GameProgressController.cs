using Retro_Achievement_Tracker.Forms;
using Retro_Achievement_Tracker.Properties;
using System.Drawing;
using System.Linq;

namespace Retro_Achievement_Tracker.Controllers
{
    public sealed class GameProgressController
    {
        private static readonly GameProgressController instance = new GameProgressController();
        private static GameProgressWindow GameProgressWindow;
        public bool IsOpen;

        private string completed;
        private string gameAchievementsEarned;
        private string gameAchievementsPossible;
        private string gamePointsEarned;
        private string gamePointsPossible;
        private string gameTruePointsEarned;
        private string gameTruePointsPossible;

        private GameProgressController()
        {
            GameProgressWindow = new GameProgressWindow();
        }
        public static GameProgressController Instance
        {
            get
            {
                return instance;
            }
        }
        public void Close()
        {
            GameProgressWindow.Close();
        }
        public void Show()
        {
            if (!IsOpen)
            {
                if (GameProgressWindow == null || GameProgressWindow.IsDisposed)
                {
                    GameProgressWindow = new GameProgressWindow();
                }
                GameProgressWindow.Show();
            }
        }

        public void UpdateGameProgress()
        {
            if (IsOpen)
            {
                GameProgressWindow.AssignJavaScriptVariables();

                GameProgressWindow.SetGameAchievementsName(AchievementsName);
                GameProgressWindow.SetGamePointsName(PointsName);
                GameProgressWindow.SetGameTruePointsName(TruePointsName);
                GameProgressWindow.SetCompletedName(CompletedName);
                GameProgressWindow.SetGameRatioName(RatioName);

                if (!string.IsNullOrEmpty(gameAchievementsEarned))
                {
                    GameProgressWindow.SetGameAchievementsValue(gameAchievementsEarned + " " + DividerCharacter + " " + gameAchievementsPossible);
                    GameProgressWindow.SetGamePointsValue(gamePointsEarned + " " + DividerCharacter + " " + gamePointsPossible);
                    GameProgressWindow.SetGameTruePointsValue(gameTruePointsEarned + " " + DividerCharacter + " " + gameTruePointsPossible);
                    GameProgressWindow.SetGameRatioValue(GameRatio);
                    GameProgressWindow.SetCompletedValue(completed + " %");
                }

                GameProgressWindow.SetGameAchievementsVisibility(AchievementsEnabled);
                GameProgressWindow.SetGamePointsVisibility(PointsEnabled);
                GameProgressWindow.SetGameTruePointsVisibility(TruePointsEnabled);
                GameProgressWindow.SetGameRatioVisibility(RatioEnabled);
                GameProgressWindow.SetCompletedVisibility(CompletedEnabled);

                SetAllSettings();

                GameProgressWindow.SetClientSize();
            }
        }
        public void SetAllSettings()
        {
            if (IsOpen)
            {
                GameProgressWindow.SetWindowBackgroundColor(WindowBackgroundColor);

                if (AdvancedSettingsEnabled)
                {
                    SetAdvancedSettings();
                }
                else
                {
                    SetSimpleSettings();
                }
            }
        }
        private void SetSimpleSettings()
        {
            GameProgressWindow.SetSimpleFontFamily(SimpleFontFamily);
            GameProgressWindow.SetSimpleFontColor(SimpleFontColor);
            GameProgressWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px");
        }
        private void SetAdvancedSettings()
        {
            GameProgressWindow.SetNameFontFamily(NameFontFamily);
            GameProgressWindow.SetNameColor(NameColor);
            GameProgressWindow.SetNameOutline(NameOutlineEnabled ? NameOutlineColor + " " + NameOutlineSize + "px" : "0px");

            GameProgressWindow.SetValueFontFamily(ValueFontFamily);
            GameProgressWindow.SetValueColor(ValueColor);
            GameProgressWindow.SetValueOutline(ValueOutlineEnabled ? ValueOutlineColor + " " + ValueOutlineSize + "px" : "0px");
        }

        public void SetGamePoints(string pointsEarned, string pointsPossible)
        {
            gamePointsEarned = pointsEarned;
            gamePointsPossible = pointsPossible;


            if (IsOpen)
            {
                GameProgressWindow.SetGamePointsValue(pointsEarned + " " + DividerCharacter + " " + pointsPossible); 
                SetAllSettings();
            }
        }

        public void SetGameAchievements(string achievementsEarned, string achievementsPossible)
        {
            gameAchievementsEarned = achievementsEarned;
            gameAchievementsPossible = achievementsPossible;


            if (IsOpen)
            {
                GameProgressWindow.SetGameAchievementsValue(achievementsEarned + " " + DividerCharacter + " " + achievementsPossible);
                SetAllSettings();
            }
        }

        public void SetGameTruePoints(string truePointsEarned, string truePointsPossible)
        {
            gameTruePointsEarned = truePointsEarned;
            gameTruePointsPossible = truePointsPossible;


            if (IsOpen)
            {
                GameProgressWindow.SetGameTruePointsValue(truePointsEarned + " " + DividerCharacter + " " + truePointsPossible);
                SetAllSettings();
            }
        }

        public void SetGameRatio()
        {

            if (IsOpen)
            {
                GameProgressWindow.SetGameRatioValue(GameRatio);
                SetAllSettings();
            }
        }

        public void SetCompleted(float value)
        {
            completed = value.ToString("0.00");

            if (IsOpen)
            {
                GameProgressWindow.SetCompletedValue(completed + "%");
                SetAllSettings();
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

                UpdateGameProgress();
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

                UpdateGameProgress();
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

                UpdateGameProgress();
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

                UpdateGameProgress();
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

                UpdateGameProgress();
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

                UpdateGameProgress();
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

                UpdateGameProgress();
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

                UpdateGameProgress();
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

                UpdateGameProgress();
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

                UpdateGameProgress();
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

                UpdateGameProgress();
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

                UpdateGameProgress();
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

                UpdateGameProgress();
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

                UpdateGameProgress();
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

                UpdateGameProgress();
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

                UpdateGameProgress();
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

                UpdateGameProgress();
            }
        }
        public string RatioName
        {
            get
            {
                return Settings.Default.stats_game_ratio_name;
            }
            set
            {
                Settings.Default.stats_game_ratio_name = value;
                Settings.Default.Save();

                UpdateGameProgress();
            }
        }
        public string PointsName
        {
            get
            {
                return Settings.Default.stats_game_points_name;
            }
            set
            {
                Settings.Default.stats_game_points_name = value;
                Settings.Default.Save();

                UpdateGameProgress();
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

                UpdateGameProgress();
            }
        }
        public string AchievementsName
        {
            get
            {
                return Settings.Default.stats_game_achievements_name;
            }
            set
            {
                Settings.Default.stats_game_achievements_name = value;
                Settings.Default.Save();

                UpdateGameProgress();
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

                UpdateGameProgress();
            }
        }
        public bool RatioEnabled
        {
            get
            {
                return Settings.Default.stats_game_ratio_enabled;
            }
            set
            {
                Settings.Default.stats_game_ratio_enabled = value;
                Settings.Default.Save();

                UpdateGameProgress();
            }
        }
        public bool PointsEnabled
        {
            get
            {
                return Settings.Default.stats_game_points_enabled;
            }
            set
            {
                Settings.Default.stats_game_points_enabled = value;
                Settings.Default.Save();

                UpdateGameProgress();
            }
        }
        public bool TruePointsEnabled
        {
            get
            {
                return Settings.Default.stats_game_true_points_enabled;
            }
            set
            {
                Settings.Default.stats_game_true_points_enabled = value;
                Settings.Default.Save();

                UpdateGameProgress();
            }
        }
        public bool AchievementsEnabled
        {
            get
            {
                return Settings.Default.stats_game_achievements_enabled;
            }
            set
            {
                Settings.Default.stats_game_achievements_enabled = value;
                Settings.Default.Save();

                UpdateGameProgress();
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

                UpdateGameProgress();
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

                UpdateGameProgress();
            }
        }
    }
}
