using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System.Drawing;
using System.Linq;

namespace Retro_Achievement_Tracker.Controllers
{
    public sealed class FocusController
    {
        private static FocusController instance = new FocusController();
        private static FocusWindow FocusWindow;

        public bool IsOpen;

        public Achievement CurrentlyFocusedAchievement;

        private FocusController()
        {
            FocusWindow = new FocusWindow();
        }
        public Achievement GetCurrentlyFocusedAchievement()
        {
            return CurrentlyFocusedAchievement;
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
            FocusWindow.Close();
        }
        public void Show()
        {
            if (!IsOpen)
            {
                if (FocusWindow == null || FocusWindow.IsDisposed)
                {
                    FocusWindow = new FocusWindow();
                }
                FocusWindow.Show();
            }
        }
        public void SetAllSettings()
        {
            FocusWindow.SetWindowBackgroundColor(WindowBackgroundColor);
            FocusWindow.SetBorderBackgroundColor(BorderBackgroundColor);

            if (AdvancedSettingsEnabled)
            {
                SetAdvancedSettings();
            }
            else
            {
                SetSimpleSettings();
            }
        }

        private void SetAdvancedSettings()
        {
            FocusWindow.SetTitleFontFamily(TitleFontFamily);
            FocusWindow.SetTitleColor(TitleColor);
            FocusWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");

            FocusWindow.SetDescriptionFontFamily(DescriptionFontFamily);
            FocusWindow.SetDescriptionColor(DescriptionColor);
            FocusWindow.SetDescriptionOutline(DescriptionOutlineEnabled ? DescriptionOutlineColor + " " + DescriptionOutlineSize + "px" : "0px");

            FocusWindow.SetPointsFontFamily(PointsFontFamily);
            FocusWindow.SetPointsColor(PointsColor);
            FocusWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");

            FocusWindow.SetLineColor(LineColor);
            FocusWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");
        }

        private void SetSimpleSettings()
        {
            FocusWindow.SetSimpleFontFamily(SimpleFontFamily);
            FocusWindow.SetSimpleFontColor(SimpleFontColor);
            FocusWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");
        }

        public void UpdateFocus()
        {
            if (IsOpen && CurrentlyFocusedAchievement != null)
            {
                FocusWindow.AssignJavaScriptVariables();
                SetAllSettings();

                FocusWindow.SetFocus(CurrentlyFocusedAchievement);

                if (BorderEnabled)
                {
                    FocusWindow.EnableBorder();
                }
                else
                {
                    FocusWindow.DisableBorder();
                }

                FocusWindow.SetClientSize();
            }
        }
        public void SetFocus(Achievement currentlyViewingAchievement)
        {
            if (currentlyViewingAchievement == null)
            {
                CurrentlyFocusedAchievement = null;
            }
            else if (CurrentlyFocusedAchievement == null || currentlyViewingAchievement.Id != CurrentlyFocusedAchievement.Id)
            {
                CurrentlyFocusedAchievement = currentlyViewingAchievement;
                UpdateFocus();
            }
        }
        public void SetFocus(GameInfo gameInfo)
        {
            if (IsOpen)
            {
                FocusWindow.SetFocus(gameInfo);

                if (BorderEnabled)
                {
                    FocusWindow.EnableBorder();
                }
                else
                {
                    FocusWindow.DisableBorder();
                }
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

                SetAllSettings();
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

        public RefocusBehaviorEnum RefocusBehavior
        {
            get
            {
                switch (Settings.Default.focus_refocus_behavior)
                {
                    case "GO_TO_PREVIOUS":
                        return RefocusBehaviorEnum.GO_TO_PREVIOUS;
                    case "GO_TO_NEXT":
                        return RefocusBehaviorEnum.GO_TO_NEXT;
                    case "GO_TO_LAST":
                        return RefocusBehaviorEnum.GO_TO_LAST;
                }
                return RefocusBehaviorEnum.GO_TO_FIRST;
            }
            set
            {
                Settings.Default.focus_refocus_behavior = value.ToString();
                Settings.Default.Save();
            }
        }
    }
}

public enum RefocusBehaviorEnum
{
    GO_TO_FIRST,
    GO_TO_PREVIOUS,
    GO_TO_NEXT,
    GO_TO_LAST
}