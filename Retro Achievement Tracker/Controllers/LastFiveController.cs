using Retro_Achievement_Tracker.Properties;
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
        public async void SetAllSettings()
        {
            if (IsOpen)
            {
                await LastFiveWindow.AssignJavaScriptVariables().ContinueWith(async (result) =>
                {
                    await LastFiveWindow.SetBackgroundColor(BorderBackgroundColor);
                    await LastFiveWindow.SetWindowBackgroundColor(WindowBackgroundColor);

                    if (BorderEnabled)
                    {
                        await LastFiveWindow.EnableBorder();
                    }
                    else
                    {
                        await LastFiveWindow.DisableBorder();
                    }
                    if (AdvancedSettingsEnabled)
                    {
                        SetAdvancedSettings();
                    }
                    else
                    {
                        SetSimpleSettings();
                    }
                });
            }
        }

        private async void SetAdvancedSettings()
        {
            await LastFiveWindow.SetTitleFontFamily(TitleFontFamily);
            await LastFiveWindow.SetTitleColor(TitleColor);
            await LastFiveWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");

            await LastFiveWindow.SetDateFontFamily(DateFontFamily);
            await LastFiveWindow.SetDateColor(DateColor);
            await LastFiveWindow.SetDateOutline(DateOutlineEnabled ? DateOutlineColor + " " + DateOutlineSize + "px" : "0px");

            await LastFiveWindow.SetPointsFontFamily(PointsFontFamily);
            await LastFiveWindow.SetPointsColor(PointsColor);
            await LastFiveWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");

            await LastFiveWindow.SetLineColor(LineColor);
            await LastFiveWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");
        }

        public async void SetSimpleSettings()
        {
            await LastFiveWindow.SetSimpleFontFamily(SimpleFontFamily);
            await LastFiveWindow.SetSimpleFontColor(SimpleFontColor);
            await LastFiveWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");
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
                    await AddAchievementsToWindow(achievements);
                    await SetAchievementPositions();
                }
                else if (achievements[0].GameId != CurrentAchievements[0].GameId)
                {
                    await ClearList();
                    await AddAchievementsToWindow(achievements);
                    await SetAchievementPositions();
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
                                await LastFiveWindow.AddAchievement(achievements[i]);
                            }
                            CurrentAchievements.Insert(0, achievements[i]);
                        }
                    }

                    if (needsUpdate)
                    {
                        SetAllSettings();

                        await SetAchievementPositions();

                        while (CurrentAchievements.Count > 5)
                        {
                            CurrentAchievements.RemoveAt(CurrentAchievements.Count - 1);
                        }
                        if (!LastFiveWindow.IsDisposed)
                        {
                            await LastFiveWindow.CleanupList();
                        }
                    }
                }
            }
        }

        private async Task AddAchievementsToWindow(List<Achievement> achievements)
        {
            for (int i = 0; i < achievements.Count; i++)
            {
                if (LastFiveWindow.Visible)
                {
                    await LastFiveWindow.AddAchievement(achievements[i]);
                }
                CurrentAchievements.Insert(0, achievements[i]);
            }

            SetAllSettings();
        }

        private async Task SetAchievementPositions()
        {
            if (LastFiveWindow.Visible)
            {
                for (int i = CurrentAchievements.Count - 1; i >= 0; i--)
                {
                    await LastFiveWindow.SetAchievementPosition(CurrentAchievements[i].Id, i);
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
                        await LastFiveWindow.SetAchievementPosition(CurrentAchievements[i].Id, 5);
                        await Task.Delay(200);
                    }
                    await LastFiveWindow.ClearList();
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.SetWindowBackgroundColor(value);
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetSimpleFontFamily(SimpleFontFamily);
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetTitleFontFamily(SimpleFontFamily);
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetDateFontFamily(SimpleFontFamily);
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetPointsFontFamily(SimpleFontFamily);
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetSimpleFontColor(value);
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetTitleColor(value);
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetDateColor(value);
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetDateColor(value);
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetPointsColor(value);
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetDateOutline(DateOutlineEnabled ? DateOutlineColor + " " + DateOutlineSize + "px" : "0px");
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetDateOutline(DateOutlineEnabled ? DateOutlineColor + " " + DateOutlineSize + "px" : "0px");
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetDateOutline(DateOutlineEnabled ? DateOutlineColor + " " + DateOutlineSize + "px" : "0px");
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        if (value)
                        {
                            await LastFiveWindow.EnableBorder();
                        }
                        else
                        {
                            await LastFiveWindow.DisableBorder();
                        }
                    });
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
                    Task.Run(async () =>
                    {
                        await LastFiveWindow.AssignJavaScriptVariables();
                        await LastFiveWindow.SetBackgroundColor(value);
                    });
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
