using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Retro_Achievement_Tracker.Controllers
{
    public sealed class RecentAchievementsController
    {
        private static RecentAchievementsController instance = new RecentAchievementsController();
        private static RecentAchievementsWindow RecentAchievementsWindow;
        public bool IsOpen;
        private List<Achievement> CurrentAchievements;
        private List<Achievement> VisibileAchievements;
        private int GameId;

        private RecentAchievementsController()
        {
            RecentAchievementsWindow = new RecentAchievementsWindow();

            CurrentAchievements = new List<Achievement>();
            VisibileAchievements = new List<Achievement>();

            IsOpen = false;
        }
        public static RecentAchievementsController Instance
        {
            get
            {
                return instance;
            }
        }
        public void Close()
        {
            RecentAchievementsWindow.Close();
        }
        public void Show()
        {
            if (!IsOpen)
            {
                VisibileAchievements = new List<Achievement>();

                RecentAchievementsWindow = new RecentAchievementsWindow();
                RecentAchievementsWindow.Show();

                SetAchievements(CurrentAchievements);
            }
        }
        public void SetAllSettings()
        {
            if (IsOpen)
            {
                RecentAchievementsWindow.AssignJavaScriptVariables();
                RecentAchievementsWindow.SetBackgroundColor(BorderBackgroundColor);
                RecentAchievementsWindow.SetWindowBackgroundColor(WindowBackgroundColor);

                if (BorderEnabled)
                {
                    RecentAchievementsWindow.EnableBorder();
                }
                else
                {
                    RecentAchievementsWindow.DisableBorder();
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
            RecentAchievementsWindow.SetTitleFontFamily(TitleFontFamily);
            RecentAchievementsWindow.SetTitleColor(TitleColor);
            RecentAchievementsWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");

            RecentAchievementsWindow.SetDateFontFamily(DateFontFamily);
            RecentAchievementsWindow.SetDateColor(DateColor);
            RecentAchievementsWindow.SetDateOutline(DescriptionOutlineEnabled ? DateOutlineColor + " " + DescriptionOutlineSize + "px" : "0px");

            RecentAchievementsWindow.SetPointsFontFamily(PointsFontFamily);
            RecentAchievementsWindow.SetPointsColor(PointsColor);
            RecentAchievementsWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");

            RecentAchievementsWindow.SetLineColor(LineColor);
            RecentAchievementsWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");
        }

        public void SetSimpleSettings()
        {
            RecentAchievementsWindow.SetSimpleFontFamily(SimpleFontFamily);
            RecentAchievementsWindow.SetSimpleFontColor(SimpleFontColor);
            RecentAchievementsWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");
        }

        public async void SetAchievements(List<Achievement> achievements)
        {
            achievements.Sort();
            achievements.Reverse();

            if (achievements.Count == 0)
            {
                RecentAchievementsWindow.HideRecentAchievements();
                RecentAchievementsWindow.ClearRecentAchievements();

                VisibileAchievements = new List<Achievement>();
            }
            else
            {
                if (CurrentAchievements.Count > 0 && GameId != achievements[0].GameId)
                {
                    GameId = achievements[0].GameId;
                    VisibileAchievements = new List<Achievement>();
                }

                bool needsChanges = CurrentAchievements.Count > 0 ? VisibileAchievements.Count == 0 : true;

                int maxAchievementCount = Math.Min(achievements.Count, MaxListSize);

                for (int i = maxAchievementCount - 1; i >= 0; i--)
                {
                    if (!VisibileAchievements.Contains(achievements[i]))
                    {
                        needsChanges = true;
                        VisibileAchievements.Add(achievements[i]);
                    }
                }

                VisibileAchievements = VisibileAchievements.GetRange(0, maxAchievementCount);

                if (needsChanges)
                {
                    RecentAchievementsWindow.HideRecentAchievements();

                    await Task.Delay(500);

                    PopulateRecentAchievementsWindow();
                }
            }

            CurrentAchievements = new List<Achievement>(achievements);
        }
        public void PopulateRecentAchievementsWindow()
        {
            if (IsOpen)
            {

                RecentAchievementsWindow.ClearRecentAchievements();

                RecentAchievementsWindow.AddAchievements(VisibileAchievements);

                SetAllSettings();

                RecentAchievementsWindow.ShowRecentAchievements();

                if (AutoScroll)
                {
                    RecentAchievementsWindow.StartScrolling();
                }
            } else
            {
                VisibileAchievements = new List<Achievement>();
            }
        }
        public int MaxListSize
        {
            get
            {
                return Settings.Default.recent_achievements_max_list_size;
            }
            set
            {
                Settings.Default.recent_achievements_max_list_size = value;
                Settings.Default.Save();
            }
        }
        public bool AutoScroll
        {
            get
            {
                return Settings.Default.recent_achievements_auto_scroll;
            }
            set
            {
                Settings.Default.recent_achievements_auto_scroll = value;
                Settings.Default.Save();

                if (value)
                {
                    RecentAchievementsWindow.StartScrolling();
                } else
                {
                    RecentAchievementsWindow.StopScrolling();
                }
            }
        }
        public bool AdvancedSettingsEnabled
        {
            get
            {
                return Settings.Default.last_five_advanced_options_enabled;
            }
            set
            {
                Settings.Default.last_five_advanced_options_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    SetAllSettings();
                }
            }
        }
        public string WindowBackgroundColor
        {
            get
            {
                return Settings.Default.last_five_window_background_color;
            }
            set
            {
                Settings.Default.last_five_window_background_color = value;
                Settings.Default.Save();
                if (IsOpen)
                {
                    RecentAchievementsWindow.SetWindowBackgroundColor(value);
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
                if (IsOpen)
                {
                    RecentAchievementsWindow.SetSimpleFontFamily(SimpleFontFamily);
                }
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
                if (IsOpen)
                {
                    RecentAchievementsWindow.SetTitleFontFamily(SimpleFontFamily);
                }
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
                if (IsOpen)
                { 
                    RecentAchievementsWindow.SetDateFontFamily(SimpleFontFamily);
                }
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
                if (IsOpen)
                {
                    RecentAchievementsWindow.SetPointsFontFamily(SimpleFontFamily);
                }
            }
        }
        public string TitleColor
        {
            get
            {
                return Settings.Default.last_five_title_color;
            }
            set
            {
                Settings.Default.last_five_title_color = value;
                Settings.Default.Save();
                if (IsOpen)
                {
                    RecentAchievementsWindow.SetTitleColor(value);
                }
            }
        }
        public string DateColor
        {
            get
            {
                return Settings.Default.last_five_date_color;
            }
            set
            {
                Settings.Default.last_five_date_color = value;
                Settings.Default.Save();
                if (IsOpen)
                {
                    RecentAchievementsWindow.SetDateColor(value);
                }
            }
        }
        public string LineColor
        {
            get
            {
                return Settings.Default.last_five_line_color;
            }
            set
            {
                Settings.Default.last_five_line_color = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    RecentAchievementsWindow.SetLineColor(value);
                }
            }
        }
        public string PointsColor
        {
            get
            {
                return Settings.Default.last_five_points_color;
            }
            set
            {
                Settings.Default.last_five_points_color = value;
                Settings.Default.Save();
                if (IsOpen)
                {
                    RecentAchievementsWindow.SetPointsColor(value);
                }
            }
        }
        public string TitleOutlineColor
        {
            get
            {
                return Settings.Default.last_five_title_outline_color;
            }
            set
            {
                Settings.Default.last_five_title_outline_color = value;
                Settings.Default.Save();
                if (IsOpen)
                {
                    RecentAchievementsWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");
                }
            }
        }
        public string DateOutlineColor
        {
            get
            {
                return Settings.Default.last_five_date_outline_color;
            }
            set
            {
                Settings.Default.last_five_date_outline_color = value;
                Settings.Default.Save();
                if (IsOpen)
                {
                    RecentAchievementsWindow.SetDateOutline(DescriptionOutlineEnabled ? DateOutlineColor + " " + DescriptionOutlineSize + "px" : "0px");
                }
            }
        }
        public string PointsOutlineColor
        {
            get
            {
                return Settings.Default.last_five_points_outline_color;
            }
            set
            {
                Settings.Default.last_five_points_outline_color = value;
                Settings.Default.Save();
                if (IsOpen)
                {
                    RecentAchievementsWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");
                }
            }
        }
        public string LineOutlineColor
        {
            get
            {
                return Settings.Default.last_five_line_outline_color;
            }
            set
            {
                Settings.Default.last_five_line_outline_color = value;
                Settings.Default.Save();
                if (IsOpen)
                {
                    RecentAchievementsWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");
                }
            }
        }
        public int TitleOutlineSize
        {
            get
            {
                return Settings.Default.last_five_title_outline_size;
            }
            set
            {
                Settings.Default.last_five_title_outline_size = value;
                Settings.Default.Save();
                if (IsOpen)
                {
                    RecentAchievementsWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");
                }
            }
        }
        public int DescriptionOutlineSize
        {
            get
            {
                return Settings.Default.last_five_date_outline_size;
            }
            set
            {
                Settings.Default.last_five_date_outline_size = value;
                Settings.Default.Save();
                if (IsOpen)
                {
                    RecentAchievementsWindow.SetDateOutline(DescriptionOutlineEnabled ? DateOutlineColor + " " + DescriptionOutlineSize + "px" : "0px");
                }
            }
        }
        public int PointsOutlineSize
        {
            get
            {
                return Settings.Default.last_five_points_outline_size;
            }
            set
            {
                Settings.Default.last_five_points_outline_size = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    RecentAchievementsWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");
                }
            }
        }
        public int LineOutlineSize
        {
            get
            {
                return Settings.Default.last_five_line_outline_size;
            }
            set
            {
                Settings.Default.last_five_line_outline_size = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    RecentAchievementsWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");
                }
            }
        }
        public string SimpleFontColor
        {
            get
            {
                return Settings.Default.last_five_font_color_hex_code;
            }
            set
            {
                Settings.Default.last_five_font_color_hex_code = value;
                Settings.Default.Save();
                if (IsOpen)
                {
                    RecentAchievementsWindow.SetSimpleFontColor(value);
                }
            }
        }
        public string SimpleFontOutlineColor
        {
            get
            {
                return Settings.Default.last_five_font_outline_color_hex;
            }
            set
            {
                Settings.Default.last_five_font_outline_color_hex = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    RecentAchievementsWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");
                }
            }
        }
        public int SimpleFontOutlineSize
        {
            get
            {
                return Settings.Default.last_five_font_outline_size;
            }
            set
            {
                Settings.Default.last_five_font_outline_size = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    RecentAchievementsWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");

                }
            }
        }
        public bool SimpleFontOutlineEnabled
        {
            get
            {
                return Settings.Default.last_five_font_outline_enabled;
            }
            set
            {
                Settings.Default.last_five_font_outline_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    RecentAchievementsWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");
                }
            }
        }
        public bool TitleOutlineEnabled
        {
            get
            {
                return Settings.Default.last_five_title_outline_enabled;
            }
            set
            {
                Settings.Default.last_five_title_outline_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    RecentAchievementsWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");
                }
            }
        }
        public bool DescriptionOutlineEnabled
        {
            get
            {
                return Settings.Default.last_five_date_outline_enabled;
            }
            set
            {
                Settings.Default.last_five_date_outline_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    RecentAchievementsWindow.SetDateOutline(DescriptionOutlineEnabled ? DateOutlineColor + " " + DescriptionOutlineSize + "px" : "0px");
                }
            }
        }
        public bool PointsOutlineEnabled
        {
            get
            {
                return Settings.Default.last_five_points_outline_enabled;
            }
            set
            {
                Settings.Default.last_five_points_outline_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    RecentAchievementsWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");
                }
            }
        }
        public bool LineOutlineEnabled
        {
            get
            {
                return Settings.Default.last_five_line_outline_enabled;
            }
            set
            {
                Settings.Default.last_five_line_outline_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    RecentAchievementsWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");
                }
            }
        }
        public bool BorderEnabled
        {
            get
            {
                return Settings.Default.last_five_border_enable;
            }
            set
            {
                Settings.Default.last_five_border_enable = value;
                Settings.Default.Save();

                if (IsOpen)
                {


                    if (value)
                    {
                        RecentAchievementsWindow.EnableBorder();
                    }
                    else
                    {
                        RecentAchievementsWindow.DisableBorder();
                    }
                }
            }
        }
        public string BorderBackgroundColor
        {
            get
            {
                return Settings.Default.last_five_background_color;
            }
            set
            {
                Settings.Default.last_five_background_color = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    RecentAchievementsWindow.SetBackgroundColor(value);
                }
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
            get
            {
                return Settings.Default.auto_last_five;
            }
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
