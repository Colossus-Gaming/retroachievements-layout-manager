using Retro_Achievement_Tracker.Properties;
using System.Drawing;
using System.Linq;

namespace Retro_Achievement_Tracker.Controllers
{
    public sealed class UserInfoController
    {
        private static UserInfoController instance = new UserInfoController();
        private static UserStatsWindow UserStatsWindow;
        public static bool IsOpen;

        private string rank;
        private string ratio;
        private string points;
        private string truePoints;

        private UserInfoController()
        {
            UserStatsWindow = new UserStatsWindow();
            IsOpen = false;
        }
        public static UserInfoController Instance
        {
            get
            {
                return instance;
            }
        }
        public void Close()
        {
            UserStatsWindow.Close();
        }
        public void Show()
        {
            if (!IsOpen)
            {
                UserStatsWindow = new UserStatsWindow();
                UserStatsWindow.Show();
            }
        }
        public void SetAllSettings()
        {

            if (IsOpen)
            {
                UserStatsWindow.AssignJavaScriptVariables();

                if (AdvancedSettingsEnabled)
                {
                    SetAdvancedSettings();
                }
                else
                {
                    SetSimpleSettings();
                }

                UserStatsWindow.SetWindowBackgroundColor(WindowBackgroundColor);
                UserStatsWindow.SetRankName(RankName);
                UserStatsWindow.SetPointsName(PointsName);
                UserStatsWindow.SetTruePointsName(TruePointsName);
                UserStatsWindow.SetRatioName(RatioName);

                if (!string.IsNullOrEmpty(rank))
                {
                    UserStatsWindow.SetRankValue(rank);
                    UserStatsWindow.SetPointsValue(points);
                    UserStatsWindow.SetTruePointsValue(truePoints);
                    UserStatsWindow.SetRatioValue(ratio);
                }

                UserStatsWindow.SetRankVisibility(RankEnabled);
                UserStatsWindow.SetPointsVisibility(PointsEnabled);
                UserStatsWindow.SetTruePointsVisibility(TruePointsEnabled);
                UserStatsWindow.SetRatioVisibility(RatioEnabled);
            }
        }
        public void SetSimpleSettings()
        {
            UserStatsWindow.SetSimpleFontFamily(SimpleFontFamily);
            UserStatsWindow.SetSimpleFontColor(SimpleFontColor);
            UserStatsWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px");
        }
        public void SetAdvancedSettings()
        {
            UserStatsWindow.SetNameFontFamily(NameFontFamily);
            UserStatsWindow.SetNameColor(NameColor);
            UserStatsWindow.SetNameOutline(NameOutlineEnabled ? NameOutlineColor + " " + NameOutlineSize + "px" : "0px");

            UserStatsWindow.SetValueFontFamily(ValueFontFamily);
            UserStatsWindow.SetValueColor(ValueColor);
            UserStatsWindow.SetValueOutline(ValueOutlineEnabled ? ValueOutlineColor + " " + ValueOutlineSize + "px" : "0px");
        }

        internal void SetRank(string value)
        {
            rank = value;

            if (IsOpen)
            {
                UserStatsWindow.SetRankValue(value);
            }
        }

        internal void SetRatio(string value)
        {
            ratio = value;

            if (IsOpen)
            {
                UserStatsWindow.SetRatioValue(value);
            }
        }

        internal void SetPoints(string value)
        {
            points = value;

            if (IsOpen)
            {
                UserStatsWindow.SetPointsValue(value);
            }
        }

        internal void SetTruePoints(string value)
        {
            truePoints = value;

            if (IsOpen)
            {
                UserStatsWindow.SetTruePointsValue(value);
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
                    UserStatsWindow.SetWindowBackgroundColor(value);
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
                    UserStatsWindow.AssignJavaScriptVariables();
                    UserStatsWindow.SetSimpleFontFamily(SimpleFontFamily);
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
                    UserStatsWindow.AssignJavaScriptVariables();
                    UserStatsWindow.SetSimpleFontColor(value);
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
                    UserStatsWindow.AssignJavaScriptVariables();
                    UserStatsWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px");
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
                    UserStatsWindow.AssignJavaScriptVariables();
                    UserStatsWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px");
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
                    UserStatsWindow.AssignJavaScriptVariables();
                    UserStatsWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px");
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
                    UserStatsWindow.AssignJavaScriptVariables();
                    UserStatsWindow.SetNameFontFamily(NameFontFamily);
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
                    UserStatsWindow.AssignJavaScriptVariables();
                    UserStatsWindow.SetValueFontFamily(ValueFontFamily);
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
                    UserStatsWindow.AssignJavaScriptVariables();
                    UserStatsWindow.SetNameColor(value);
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
                    UserStatsWindow.AssignJavaScriptVariables();
                    UserStatsWindow.SetValueColor(value);
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
                    UserStatsWindow.AssignJavaScriptVariables();
                    UserStatsWindow.SetNameOutline(value ? NameOutlineColor + " " + NameOutlineSize + "px" : "0px");
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
                    UserStatsWindow.AssignJavaScriptVariables();
                    UserStatsWindow.SetValueOutline(value ? ValueOutlineColor + " " + ValueOutlineSize + "px" : "0px");
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
                    UserStatsWindow.AssignJavaScriptVariables();
                    UserStatsWindow.SetNameOutline(NameOutlineEnabled ? NameOutlineColor + " " + NameOutlineSize + "px" : "0px");
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
                    UserStatsWindow.AssignJavaScriptVariables();
                    UserStatsWindow.SetValueOutline(ValueOutlineEnabled ? ValueOutlineColor + " " + ValueOutlineSize + "px" : "0px");
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
                    UserStatsWindow.AssignJavaScriptVariables();
                    UserStatsWindow.SetNameOutline(NameOutlineColor + " " + NameOutlineSize + "px");
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
                    UserStatsWindow.AssignJavaScriptVariables();
                    UserStatsWindow.SetValueOutline(ValueOutlineColor + " " + ValueOutlineSize + "px");
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
                    UserStatsWindow.SetRankName(value);
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
                    UserStatsWindow.SetPointsName(value);
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
                    UserStatsWindow.SetTruePointsName(value);
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
                    UserStatsWindow.SetRatioName(value);
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
                    UserStatsWindow.SetRankVisibility(value);
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
                    UserStatsWindow.SetPointsVisibility(value);
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
                    UserStatsWindow.SetTruePointsVisibility(value);
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
                    UserStatsWindow.SetRatioVisibility(value);
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
                return Settings.Default.game_stats_divider_character_selection;
            }
            set
            {
                Settings.Default.game_stats_divider_character_selection = value;
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
