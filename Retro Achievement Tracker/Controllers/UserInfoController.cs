using Retro_Achievement_Tracker.Properties;
using System.Drawing;
using System.Linq;

namespace Retro_Achievement_Tracker.Controllers
{
    public sealed class UserInfoController
    {
        private static readonly UserInfoController instance = new UserInfoController();
        private static UserInfoWindow UserInfoWindow;

        public bool IsOpen;
        private string rank;
        private string ratio;
        private string points;
        private string truePoints;

        private UserInfoController()
        {
            UserInfoWindow = new UserInfoWindow();
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
            UserInfoWindow.Close();
        }
        public void Show()
        {
            if (!IsOpen)
            {
                if (UserInfoWindow == null || UserInfoWindow.IsDisposed)
                {
                    UserInfoWindow = new UserInfoWindow();
                }
                UserInfoWindow.Show();
            }
        }
        public void UpdateUserInfo()
        {
            if (IsOpen)
            {
                UserInfoWindow.AssignJavaScriptVariables();

                SetAllSettings();

                UserInfoWindow.SetRankVisibility(RankEnabled);
                UserInfoWindow.SetPointsVisibility(PointsEnabled);
                UserInfoWindow.SetTruePointsVisibility(TruePointsEnabled);
                UserInfoWindow.SetRatioVisibility(RatioEnabled);

                UserInfoWindow.SetRankName(RankName);
                UserInfoWindow.SetPointsName(PointsName);
                UserInfoWindow.SetTruePointsName(TruePointsName);
                UserInfoWindow.SetRatioName(RatioName);

                if (!string.IsNullOrEmpty(rank))
                {
                    UserInfoWindow.SetRankValue(rank);
                    UserInfoWindow.SetPointsValue(points);
                    UserInfoWindow.SetTruePointsValue(truePoints);
                    UserInfoWindow.SetRatioValue(ratio);
                }

                SetAllSettings();

                UserInfoWindow.SetClientSize();
            }
        }
        public void SetAllSettings()
        {
            UserInfoWindow.SetWindowBackgroundColor(WindowBackgroundColor);

            if (AdvancedSettingsEnabled)
            {
                SetAdvancedSettings();
            }
            else
            {
                SetSimpleSettings();
            }
        }
        private void SetSimpleSettings()
        {
            UserInfoWindow.SetSimpleFontFamily(SimpleFontFamily);
            UserInfoWindow.SetSimpleFontColor(SimpleFontColor);
            UserInfoWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px");
        }
        private void SetAdvancedSettings()
        {
            UserInfoWindow.SetNameFontFamily(NameFontFamily);
            UserInfoWindow.SetNameColor(NameColor);
            UserInfoWindow.SetNameOutline(NameOutlineEnabled ? NameOutlineColor + " " + NameOutlineSize + "px" : "0px");

            UserInfoWindow.SetValueFontFamily(ValueFontFamily);
            UserInfoWindow.SetValueColor(ValueColor);
            UserInfoWindow.SetValueOutline(ValueOutlineEnabled ? ValueOutlineColor + " " + ValueOutlineSize + "px" : "0px");
        }

        internal void SetRank(string value)
        {
            rank = value;

            if (IsOpen)
            {
                UserInfoWindow.SetRankValue(value);
            }
        }

        internal void SetRatio(string value)
        {
            ratio = value;

            if (IsOpen)
            {
                UserInfoWindow.SetRatioValue(value);
            }
        }

        internal void SetPoints(string value)
        {
            points = value;

            if (IsOpen)
            {
                UserInfoWindow.SetPointsValue(value);
            }
        }

        internal void SetTruePoints(string value)
        {
            truePoints = value;

            if (IsOpen)
            {
                UserInfoWindow.SetTruePointsValue(value);
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
                    UserInfoWindow.SetWindowBackgroundColor(value);
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
                    UserInfoWindow.AssignJavaScriptVariables();
                    UserInfoWindow.SetSimpleFontFamily(SimpleFontFamily);
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
                    UserInfoWindow.AssignJavaScriptVariables();
                    UserInfoWindow.SetSimpleFontColor(value);
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

                UpdateUserInfo();
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

                UpdateUserInfo();
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

                UpdateUserInfo();
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

                UpdateUserInfo();
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

                UpdateUserInfo();
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

                UpdateUserInfo();
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

                UpdateUserInfo();
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

                UpdateUserInfo();
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

                UpdateUserInfo();
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


                UpdateUserInfo();
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
               
                UpdateUserInfo();
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

                UpdateUserInfo();
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

                UpdateUserInfo();
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

                UpdateUserInfo();
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

                UpdateUserInfo();
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

                UpdateUserInfo();
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

                UpdateUserInfo();
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

                UpdateUserInfo();
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

                UpdateUserInfo();
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

                UpdateUserInfo();
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

                UpdateUserInfo();
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
