using Retro_Achievement_Tracker.Properties;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Retro_Achievement_Tracker.Controllers
{
    public sealed class FocusController
    {
        private static FocusController instance = new FocusController();
        private static FocusWindow FocusLayoutWindow;
        public Achievement CurrentlyFocusedAchievement;

        private FocusController()
        {
            FocusLayoutWindow = new FocusWindow();
        }
        public static FocusController Instance
        {
            get
            {
                return instance;
            }
        }
        public void Close()
        {
            FocusLayoutWindow.Close();
        }
        public async void SetAllSettings()
        {
            await FocusLayoutWindow.AssignJavaScriptVariables().ContinueWith(async (result) =>
            {
                await FocusLayoutWindow.SetWindowBackgroundColor(WindowBackgroundColor);
                await FocusLayoutWindow.SetBorderBackgroundColor(BorderBackgroundColor);

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

        private async void SetAdvancedSettings()
        {
            await FocusLayoutWindow.SetTitleFontFamily(TitleFontFamily);
            await FocusLayoutWindow.SetTitleColor(TitleColor);
            await FocusLayoutWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");

            await FocusLayoutWindow.SetDescriptionFontFamily(DescriptionFontFamily);
            await FocusLayoutWindow.SetDescriptionColor(DescriptionColor);
            await FocusLayoutWindow.SetDescriptionOutline(DescriptionOutlineEnabled ? DescriptionOutlineColor + " " + DescriptionOutlineSize + "px" : "0px");

            await FocusLayoutWindow.SetPointsFontFamily(PointsFontFamily);
            await FocusLayoutWindow.SetPointsColor(PointsColor);
            await FocusLayoutWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");

            await FocusLayoutWindow.SetLineColor(LineColor);
            await FocusLayoutWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");
        }

        public async void SetSimpleSettings()
        {
            await FocusLayoutWindow.SetSimpleFontFamily(SimpleFontFamily);
            await FocusLayoutWindow.SetSimpleFontColor(SimpleFontColor);
            await FocusLayoutWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");
        }
        public void Show()
        {
            if (FocusLayoutWindow.IsDisposed)
            {
                FocusLayoutWindow = new FocusWindow();
            }
            if (FocusLayoutWindow.chromiumWebBrowser == null)
            {
                FocusLayoutWindow.SetupBrowser();
            }
            if (!FocusLayoutWindow.Visible)
            {
                FocusLayoutWindow.Show();
            }
        }

        internal void HideFocus()
        {
            FocusLayoutWindow.HideFocus();
        }

        public async void UpdateFocus()
        {
            if (CurrentlyFocusedAchievement != null)
            {
                FocusLayoutWindow.SetFocus(CurrentlyFocusedAchievement);
                if (BorderEnabled)
                {
                    await FocusLayoutWindow.EnableBorder();
                }
                else
                {
                    await FocusLayoutWindow.DisableBorder();
                }
            }
        }
        public void SetFocus(Achievement currentlyViewingAchievement)
        {
            if (CurrentlyFocusedAchievement == null || currentlyViewingAchievement.Id != CurrentlyFocusedAchievement.Id)
            {
                CurrentlyFocusedAchievement = currentlyViewingAchievement;
                UpdateFocus();
            }
        }
        public bool AdvancedSettingsEnabled
        {
            get
            {
                return Settings.Default.focus_advanced_options_enabled;
            }
            set
            {
                Settings.Default.focus_advanced_options_enabled = value;
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
                    if (font.Name.Equals(Settings.Default.focus_font_family_name))
                    {
                        return font;
                    }
                }
                Settings.Default.focus_font_family_name = familyArray[0].Name;

                return familyArray[0];
            }
            set
            {
                Settings.Default.focus_font_family_name = value.Name;
                Settings.Default.Save();

                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetSimpleFontFamily(SimpleFontFamily);
                });
            }
        }
        public string SimpleFontColor
        {
            get
            {
                return Settings.Default.focus_font_color_hex_code;
            }
            set
            {
                Settings.Default.focus_font_color_hex_code = value;
                Settings.Default.Save();

                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetSimpleFontColor(value);
                });
            }
        }
        public string SimpleFontOutlineColor
        {
            get
            {
                return Settings.Default.focus_font_outline_color_hex;
            }
            set
            {
                Settings.Default.focus_font_outline_color_hex = value;
                Settings.Default.Save();
                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");
                });
            }
        }
        public int SimpleFontOutlineSize
        {
            get
            {
                return Settings.Default.focus_font_outline_size;
            }
            set
            {
                Settings.Default.focus_font_outline_size = value;
                Settings.Default.Save();

                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");
                });
            }
        }
        public bool SimpleFontOutlineEnabled
        {
            get
            {
                return Settings.Default.focus_font_outline_enabled;
            }
            set
            {
                Settings.Default.focus_font_outline_enabled = value;
                Settings.Default.Save();
                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");
                });
            }
        }
        public FontFamily TitleFontFamily
        {
            get
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily font in familyArray)
                {
                    if (font.Name.Equals(Settings.Default.focus_title_font_family))
                    {
                        return font;
                    }
                }
                Settings.Default.focus_title_font_family = familyArray[0].Name;

                return familyArray[0];
            }
            set
            {
                Settings.Default.focus_title_font_family = value.Name;
                Settings.Default.Save();
                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetTitleFontFamily(TitleFontFamily);
                });
            }
        }
        public FontFamily DescriptionFontFamily
        {
            get
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily font in familyArray)
                {
                    if (font.Name.Equals(Settings.Default.focus_description_font_family))
                    {
                        return font;
                    }
                }
                Settings.Default.focus_description_font_family = familyArray[0].Name;

                return familyArray[0];
            }
            set
            {
                Settings.Default.focus_description_font_family = value.Name;
                Settings.Default.Save();
                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetDescriptionFontFamily(DescriptionFontFamily);
                });
            }
        }

        public FontFamily PointsFontFamily
        {
            get
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily font in familyArray)
                {
                    if (font.Name.Equals(Settings.Default.focus_points_font_family))
                    {
                        return font;
                    }
                }
                Settings.Default.focus_points_font_family = familyArray[0].Name;

                return familyArray[0];
            }
            set
            {
                Settings.Default.focus_points_font_family = value.Name;
                Settings.Default.Save();

                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetPointsFontFamily(PointsFontFamily);
                });
            }
        }

        public string TitleColor
        {
            get
            {
                return Settings.Default.focus_title_color;
            }
            set
            {
                Settings.Default.focus_title_color = value;
                Settings.Default.Save();

                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetTitleColor(value);
                });
            }
        }
        public string DescriptionColor
        {
            get
            {
                return Settings.Default.focus_description_color;
            }
            set
            {
                Settings.Default.focus_description_color = value;
                Settings.Default.Save();

                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetDescriptionColor(value);
                });
            }
        }
        public string PointsColor
        {
            get
            {
                return Settings.Default.focus_points_color;
            }
            set
            {
                Settings.Default.focus_points_color = value;
                Settings.Default.Save();

                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetPointsColor(value);
                });
            }
        }
        public string LineColor
        {
            get
            {
                return Settings.Default.focus_line_color;
            }
            set
            {
                Settings.Default.focus_line_color = value;
                Settings.Default.Save();

                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetLineColor(value);
                });
            }
        }
        public bool TitleOutlineEnabled
        {
            get
            {
                return Settings.Default.focus_title_outline_enabled;
            }
            set
            {
                Settings.Default.focus_title_outline_enabled = value;
                Settings.Default.Save();

                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");
                });
            }
        }
        public bool DescriptionOutlineEnabled
        {
            get
            {
                return Settings.Default.focus_description_outline_enabled;
            }
            set
            {
                Settings.Default.focus_description_outline_enabled = value;
                Settings.Default.Save();

                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetDescriptionOutline(DescriptionOutlineEnabled ? DescriptionOutlineColor + " " + DescriptionOutlineSize + "px" : "0px");
                });
            }
        }
        public bool PointsOutlineEnabled
        {
            get
            {
                return Settings.Default.focus_points_outline_enabled;
            }
            set
            {
                Settings.Default.focus_points_outline_enabled = value;
                Settings.Default.Save();

                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");
                });
            }
        }
        public bool LineOutlineEnabled
        {
            get
            {
                return Settings.Default.focus_line_outline_enabled;
            }
            set
            {
                Settings.Default.focus_line_outline_enabled = value;
                Settings.Default.Save();

                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");
                });
            }
        }
        public string TitleOutlineColor
        {
            get
            {
                return Settings.Default.focus_title_outline_color;
            }
            set
            {
                Settings.Default.focus_title_outline_color = value;
                Settings.Default.Save();
                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");
                });
            }
        }
        public string DescriptionOutlineColor
        {
            get
            {
                return Settings.Default.focus_description_outline_color;
            }
            set
            {
                Settings.Default.focus_description_outline_color = value;
                Settings.Default.Save();
                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetDescriptionOutline(DescriptionOutlineEnabled ? DescriptionOutlineColor + " " + DescriptionOutlineSize + "px" : "0px");
                });
            }
        }
        public string PointsOutlineColor
        {
            get
            {
                return Settings.Default.focus_points_outline_color;
            }
            set
            {
                Settings.Default.focus_points_outline_color = value;
                Settings.Default.Save();
                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");
                });
            }
        }
        public string LineOutlineColor
        {
            get
            {
                return Settings.Default.focus_line_outline_color;
            }
            set
            {
                Settings.Default.focus_line_outline_color = value;
                Settings.Default.Save();
                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");
                });
            }
        }
        public int TitleOutlineSize
        {
            get
            {
                return Settings.Default.focus_title_outline_size;
            }
            set
            {
                Settings.Default.focus_title_outline_size = value;
                Settings.Default.Save();
                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");
                });
            }
        }
        public int DescriptionOutlineSize
        {
            get
            {
                return Settings.Default.focus_description_outline_size;
            }
            set
            {
                Settings.Default.focus_description_outline_size = value;
                Settings.Default.Save();
                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetDescriptionOutline(DescriptionOutlineEnabled ? DescriptionOutlineColor + " " + DescriptionOutlineSize + "px" : "0px");
                });
            }
        }
        public int PointsOutlineSize
        {
            get
            {
                return Settings.Default.focus_points_outline_size;
            }
            set
            {
                Settings.Default.focus_points_outline_size = value;
                Settings.Default.Save();

                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");
                });
            }
        }
        public int LineOutlineSize
        {
            get
            {
                return Settings.Default.focus_line_outline_size;
            }
            set
            {
                Settings.Default.focus_line_outline_size = value;
                Settings.Default.Save();

                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    await FocusLayoutWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");
                });
            }
        }
        public bool BorderEnabled
        {
            get
            {
                return Settings.Default.focus_border_enable;
            }
            set
            {
                Settings.Default.focus_border_enable = value;
                Settings.Default.Save();
                Task.Run(async () =>
                {
                    await FocusLayoutWindow.AssignJavaScriptVariables();
                    if (value)
                    {
                        await FocusLayoutWindow.EnableBorder();
                    }
                    else
                    {
                        await FocusLayoutWindow.DisableBorder();
                    }
                });
            }
        }
        public string BorderBackgroundColor
        {
            get
            {
                return Settings.Default.focus_background_color;
            }
            set
            {
                Settings.Default.focus_background_color = value;
                Settings.Default.Save();
                Task.Run(async () =>
                {
                    await FocusLayoutWindow.SetBorderBackgroundColor(value);
                });
            }
        }
        public string WindowBackgroundColor
        {
            get
            {
                return Settings.Default.focus_window_background_color;
            }
            set
            {
                Settings.Default.focus_window_background_color = value;
                Settings.Default.Save();
                Task.Run(async () =>
                {
                    await FocusLayoutWindow.SetWindowBackgroundColor(value);
                });
            }
        }

        public bool AutoLaunch
        {
            get
            {
                return Settings.Default.auto_focus;
            }
            set
            {
                Settings.Default.auto_focus = value;
                Settings.Default.Save();
            }
        }
    }
}
