using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Retro_Achievement_Tracker.Controllers
{
    public sealed class RecentUnlocksController
    {
        private static readonly RecentUnlocksController instance = new RecentUnlocksController();
        private static RecentUnlocksWindow RecentUnlocksWindow;
        public bool IsOpen;

        private List<Achievement> CurrentAchievements;
        private List<Achievement> VisibileAchievements;

        private RecentUnlocksController()
        {
            RecentUnlocksWindow = new RecentUnlocksWindow();

            CurrentAchievements = new List<Achievement>();
            VisibileAchievements = new List<Achievement>();
        }
        public static RecentUnlocksController Instance
        {
            get
            {
                return instance;
            }
        }
        public void Close()
        {
            RecentUnlocksWindow.Close();
        }
        public void Show()
        {
            if (!IsOpen)
            {
                VisibileAchievements = new List<Achievement>();

                if (RecentUnlocksWindow == null || RecentUnlocksWindow.IsDisposed)
                {
                    RecentUnlocksWindow = new RecentUnlocksWindow();
                }
                RecentUnlocksWindow.Show();

                SetAchievements();
            }
        }
        public void SetAllSettings()
        {
            if (IsOpen)
            {
                RecentUnlocksWindow.SetWindowBackgroundColor(WindowBackgroundColor);
                RecentUnlocksWindow.SetBorderBackgroundColor(BorderBackgroundColor);

                if (BorderEnabled)
                {
                    RecentUnlocksWindow.EnableBorder();
                }
                else
                {
                    RecentUnlocksWindow.DisableBorder();
                }

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

        private void SetAdvancedSettings()
        {
            RecentUnlocksWindow.SetTitleFontFamily(TitleFontFamily);
            RecentUnlocksWindow.SetTitleColor(TitleColor);
            RecentUnlocksWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");

            RecentUnlocksWindow.SetDateFontFamily(DateFontFamily);
            RecentUnlocksWindow.SetDateColor(DateColor);
            RecentUnlocksWindow.SetDateOutline(DescriptionOutlineEnabled ? DateOutlineColor + " " + DescriptionOutlineSize + "px" : "0px");

            RecentUnlocksWindow.SetPointsFontFamily(PointsFontFamily);
            RecentUnlocksWindow.SetPointsColor(PointsColor);
            RecentUnlocksWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");

            RecentUnlocksWindow.SetLineColor(LineColor);
            RecentUnlocksWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");
        }

        private void SetSimpleSettings()
        {
            RecentUnlocksWindow.SetSimpleFontFamily(SimpleFontFamily);
            RecentUnlocksWindow.SetSimpleFontColor(SimpleFontColor);
            RecentUnlocksWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");
        }
        public void SetAchievements()
        {
            SetAchievements(CurrentAchievements);
        }
        public void SetAchievements(List<Achievement> achievements)
        {
            CurrentAchievements = new List<Achievement>(achievements);
            CurrentAchievements.Sort();
            CurrentAchievements.Reverse();

            if (IsOpen)
            {
                RecentUnlocksWindow.AssignJavaScriptVariables();

                VisibileAchievements = CurrentAchievements.GetRange(0, Math.Min(CurrentAchievements.Count, MaxListSize));

                PopulateRecentAchievementsWindow();
            }
        }
        public async void PopulateRecentAchievementsWindow()
        {
            if (IsOpen)
            {
                RecentUnlocksWindow.SetClientSize();
                RecentUnlocksWindow.HideRecentAchievements();

                await Task.Delay(500);

                RecentUnlocksWindow.ClearRecentAchievements();
                RecentUnlocksWindow.AddAchievements(VisibileAchievements);
                RecentUnlocksWindow.AssignJavaScriptVariables();

                SetAllSettings();

                RecentUnlocksWindow.ShowRecentAchievements();

                if (AutoScroll)
                {
                    RecentUnlocksWindow.StartScrolling();
                }
            }
            else
            {
                VisibileAchievements = new List<Achievement>();
            }
        }
        public int MaxListSize
        {
            get => Settings.Default.recent_achievements_max_list_size;
            set
            {
                Settings.Default.recent_achievements_max_list_size = value;
                Settings.Default.Save();
            }
        }
        public bool AutoScroll
        {
            get => Settings.Default.recent_achievements_auto_scroll;
            set
            {
                Settings.Default.recent_achievements_auto_scroll = value;
                Settings.Default.Save();

                if (value)
                {
                    RecentUnlocksWindow.StartScrolling();
                }
                else
                {
                    RecentUnlocksWindow.StopScrolling();
                }
            }
        }
        public bool AdvancedSettingsEnabled
        {
            get => Settings.Default.last_five_advanced_options_enabled;
            set
            {
                Settings.Default.last_five_advanced_options_enabled = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string WindowBackgroundColor
        {
            get => Settings.Default.last_five_window_background_color;
            set
            {
                Settings.Default.last_five_window_background_color = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public FontFamily SimpleFontFamily
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

                return familyArray[0];
            }
            set
            {
                Settings.Default.last_five_font_family_name = value.Name;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public FontFamily TitleFontFamily
        {
            get
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily font in familyArray)
                {
                    if (font.Name.Equals(Settings.Default.last_five_title_font_family))
                    {
                        return font;
                    }
                }
                Settings.Default.last_five_title_font_family = familyArray[0].Name;

                return familyArray[0];
            }
            set
            {
                Settings.Default.last_five_title_font_family = value.Name;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public FontFamily DateFontFamily
        {
            get
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily font in familyArray)
                {
                    if (font.Name.Equals(Settings.Default.last_five_date_font_family))
                    {
                        return font;
                    }
                }
                Settings.Default.last_five_date_font_family = familyArray[0].Name;

                return familyArray[0];
            }
            set
            {
                Settings.Default.last_five_date_font_family = value.Name;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public FontFamily PointsFontFamily
        {
            get
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily font in familyArray)
                {
                    if (font.Name.Equals(Settings.Default.last_five_points_font_family))
                    {
                        return font;
                    }
                }
                Settings.Default.last_five_points_font_family = familyArray[0].Name;

                return familyArray[0];
            }
            set
            {
                Settings.Default.last_five_points_font_family = value.Name;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string TitleColor
        {
            get => Settings.Default.last_five_title_color;
            set
            {
                Settings.Default.last_five_title_color = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string DateColor
        {
            get => Settings.Default.last_five_date_color;
            set
            {
                Settings.Default.last_five_date_color = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string LineColor
        {
            get => Settings.Default.last_five_line_color;
            set
            {
                Settings.Default.last_five_line_color = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string PointsColor
        {
            get => Settings.Default.last_five_points_color;
            set
            {
                Settings.Default.last_five_points_color = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string TitleOutlineColor
        {
            get => Settings.Default.last_five_title_outline_color;
            set
            {
                Settings.Default.last_five_title_outline_color = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string DateOutlineColor
        {
            get => Settings.Default.last_five_date_outline_color;
            set
            {
                Settings.Default.last_five_date_outline_color = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string PointsOutlineColor
        {
            get => Settings.Default.last_five_points_outline_color;
            set
            {
                Settings.Default.last_five_points_outline_color = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string LineOutlineColor
        {
            get => Settings.Default.last_five_line_outline_color;
            set
            {
                Settings.Default.last_five_line_outline_color = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public int TitleOutlineSize
        {
            get => Settings.Default.last_five_title_outline_size;
            set
            {
                Settings.Default.last_five_title_outline_size = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public int DescriptionOutlineSize
        {
            get => Settings.Default.last_five_date_outline_size;
            set
            {
                Settings.Default.last_five_date_outline_size = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public int PointsOutlineSize
        {
            get => Settings.Default.last_five_points_outline_size;
            set
            {
                Settings.Default.last_five_points_outline_size = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public int LineOutlineSize
        {
            get => Settings.Default.last_five_line_outline_size;
            set
            {
                Settings.Default.last_five_line_outline_size = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string SimpleFontColor
        {
            get => Settings.Default.last_five_font_color_hex_code;
            set
            {
                Settings.Default.last_five_font_color_hex_code = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string SimpleFontOutlineColor
        {
            get => Settings.Default.last_five_font_outline_color_hex;
            set
            {
                Settings.Default.last_five_font_outline_color_hex = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public int SimpleFontOutlineSize
        {
            get => Settings.Default.last_five_font_outline_size;
            set
            {
                Settings.Default.last_five_font_outline_size = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public bool SimpleFontOutlineEnabled
        {
            get => Settings.Default.last_five_font_outline_enabled;
            set
            {
                Settings.Default.last_five_font_outline_enabled = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public bool TitleOutlineEnabled
        {
            get => Settings.Default.last_five_title_outline_enabled;
            set
            {
                Settings.Default.last_five_title_outline_enabled = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public bool DescriptionOutlineEnabled
        {
            get => Settings.Default.last_five_date_outline_enabled;
            set
            {
                Settings.Default.last_five_date_outline_enabled = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public bool PointsOutlineEnabled
        {
            get => Settings.Default.last_five_points_outline_enabled;
            set
            {
                Settings.Default.last_five_points_outline_enabled = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public bool LineOutlineEnabled
        {
            get => Settings.Default.last_five_line_outline_enabled;
            set
            {
                Settings.Default.last_five_line_outline_enabled = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public bool BorderEnabled
        {
            get => Settings.Default.last_five_border_enable;
            set
            {
                Settings.Default.last_five_border_enable = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string BorderBackgroundColor
        {
            get => Settings.Default.last_five_background_color;
            set
            {
                Settings.Default.last_five_background_color = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public SortBy SortByUnlocked
        {
            get
            {
                return SortBy.DATE_EARNED;
            }
        }
        public SortBy SortByLocked
        {
            get
            {
                return SortBy.DISPLAY_ORDER;
            }
        }
        public bool AutoLaunch
        {
            get => Settings.Default.auto_last_five;
            set
            {
                Settings.Default.auto_last_five = value;
                Settings.Default.Save();
            }
        }
    }
    public enum SortBy
    {
        DATE_EARNED,
        DISPLAY_ORDER,
        ID
    }
}
