﻿using Retro_Achievement_Tracker.Properties;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Retro_Achievement_Tracker.Controllers
{
    public sealed class LastFiveController
    {
        private static LastFiveController instance = new LastFiveController();
        private static LastFiveWindow LastFiveWindow;
        public static bool IsOpen;
        private List<Achievement> CurrentAchievements;

        private LastFiveController()
        {
            LastFiveWindow = new LastFiveWindow();
            CurrentAchievements = new List<Achievement>();
            IsOpen = false;
        }
        public static LastFiveController Instance
        {
            get
            {
                return instance;
            }
        }
        public void Close()
        {
            LastFiveWindow.Close();
        }
        public void Show()
        {
            if (!IsOpen)
            {
                LastFiveWindow = new LastFiveWindow();
                LastFiveWindow.Show();
            }
        }
        public void SetAllSettings()
        {
            if (IsOpen)
            {
                LastFiveWindow.AssignJavaScriptVariables();
                LastFiveWindow.SetBackgroundColor(BorderBackgroundColor);
                LastFiveWindow.SetWindowBackgroundColor(WindowBackgroundColor);

                if (BorderEnabled)
                {
                    LastFiveWindow.EnableBorder();
                }
                else
                {
                    LastFiveWindow.DisableBorder();
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
            LastFiveWindow.SetTitleFontFamily(TitleFontFamily);
            LastFiveWindow.SetTitleColor(TitleColor);
            LastFiveWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");

            LastFiveWindow.SetDateFontFamily(DateFontFamily);
            LastFiveWindow.SetDateColor(DateColor);
            LastFiveWindow.SetDateOutline(DateOutlineEnabled ? DateOutlineColor + " " + DateOutlineSize + "px" : "0px");

            LastFiveWindow.SetPointsFontFamily(PointsFontFamily);
            LastFiveWindow.SetPointsColor(PointsColor);
            LastFiveWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");

            LastFiveWindow.SetLineColor(LineColor);
            LastFiveWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");
        }

        public void SetSimpleSettings()
        {
            LastFiveWindow.SetSimpleFontFamily(SimpleFontFamily);
            LastFiveWindow.SetSimpleFontColor(SimpleFontColor);
            LastFiveWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");
        }

        public async Task SetAchievements(List<Achievement> achievements)
        {
            if (IsOpen)
            {
                if (achievements.Count == 0)
                {
                    await ClearList();
                }
                else if (CurrentAchievements.Count == 0)
                {
                    AddAchievementsToWindow(achievements);
                    SetAchievementPositions();
                }
                else if (achievements[0].GameId != CurrentAchievements[0].GameId)
                {
                    await ClearList();
                    AddAchievementsToWindow(achievements);
                    SetAchievementPositions();
                }
                else
                {
                    bool needsUpdate = false;

                    for (int i = 0; i < achievements.Count; i++)
                    {
                        if (!CurrentAchievements.Exists(y => y.Id == achievements[i].Id))
                        {
                            needsUpdate = true;

                            if (LastFiveWindow.Visible)
                            {
                                LastFiveWindow.AddAchievement(achievements[i]);
                            }
                            CurrentAchievements.Insert(0, achievements[i]);
                        }
                    }

                    if (needsUpdate)
                    {
                        SetAllSettings();

                        SetAchievementPositions();

                        while (CurrentAchievements.Count > 5)
                        {
                            CurrentAchievements.RemoveAt(CurrentAchievements.Count - 1);
                        }
                        if (!LastFiveWindow.IsDisposed)
                        {
                            LastFiveWindow.CleanupList();
                        }
                    }
                }
            }
        }

        private void AddAchievementsToWindow(List<Achievement> achievements)
        {
            for (int i = 0; i < achievements.Count; i++)
            {
                if (LastFiveWindow.Visible)
                {
                    LastFiveWindow.AddAchievement(achievements[i]);
                }
                CurrentAchievements.Insert(0, achievements[i]);
            }

            SetAllSettings();
        }

        private async void SetAchievementPositions()
        {
            if (LastFiveWindow.Visible)
            {
                for (int i = CurrentAchievements.Count - 1; i >= 0; i--)
                {
                    LastFiveWindow.SetAchievementPosition(CurrentAchievements[i].Id, i);
                    await Task.Delay(200);
                }
            }
        }

        private async Task ClearList()
        {
            if (CurrentAchievements.Count > 0)
            {
                if (!LastFiveWindow.IsDisposed)
                {
                    for (int i = CurrentAchievements.Count - 1; i >= 0; i--)
                    {
                        LastFiveWindow.SetAchievementPosition(CurrentAchievements[i].Id, 5);
                        await Task.Delay(200);
                    }
                    LastFiveWindow.ClearList();
                }
                CurrentAchievements = new List<Achievement>();
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
                    LastFiveWindow.SetWindowBackgroundColor(value);
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetSimpleFontFamily(SimpleFontFamily);
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetTitleFontFamily(SimpleFontFamily);
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetDateFontFamily(SimpleFontFamily);
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetPointsFontFamily(SimpleFontFamily);
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetSimpleFontColor(value);
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetTitleColor(value);
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetDateColor(value);
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
                Settings.Default.last_five_date_color = value;
                Settings.Default.Save();
                if (IsOpen)
                {
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetDateColor(value);
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetPointsColor(value);
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetDateOutline(DateOutlineEnabled ? DateOutlineColor + " " + DateOutlineSize + "px" : "0px");
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");
                }
            }
        }
        public int DateOutlineSize
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetDateOutline(DateOutlineEnabled ? DateOutlineColor + " " + DateOutlineSize + "px" : "0px");
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");

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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");
                }
            }
        }
        public bool DateOutlineEnabled
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetDateOutline(DateOutlineEnabled ? DateOutlineColor + " " + DateOutlineSize + "px" : "0px");
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");
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
                    LastFiveWindow.AssignJavaScriptVariables();

                    if (value)
                    {
                        LastFiveWindow.EnableBorder();
                    }
                    else
                    {
                        LastFiveWindow.DisableBorder();
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
                    LastFiveWindow.AssignJavaScriptVariables();
                    LastFiveWindow.SetBackgroundColor(value);
                }
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
}
