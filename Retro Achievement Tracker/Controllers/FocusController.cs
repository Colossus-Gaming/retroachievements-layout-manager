using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System.Drawing;
using System.Linq;

namespace Retro_Achievement_Tracker.Controllers
{
    public sealed class FocusController
    {
        private static FocusController instance = new FocusController();
        private static FocusWindow FocusLayoutWindow;
        public bool IsOpen;
        public Achievement CurrentlyFocusedAchievement;

        private FocusController()
        {
            FocusLayoutWindow = new FocusWindow();
            IsOpen = false;
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
            FocusLayoutWindow.Close();
        }
        public void Show()
        {
            if (!IsOpen)
            {
                FocusLayoutWindow = new FocusWindow();
                FocusLayoutWindow.Show();
            }
        }
        public void SetAllSettings()
        {
            FocusLayoutWindow.AssignJavaScriptVariables();
            FocusLayoutWindow.SetWindowBackgroundColor(WindowBackgroundColor);
            FocusLayoutWindow.SetBorderBackgroundColor(BorderBackgroundColor);

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
            FocusLayoutWindow.SetTitleFontFamily(TitleFontFamily);
            FocusLayoutWindow.SetTitleColor(TitleColor);
            FocusLayoutWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");

            FocusLayoutWindow.SetDescriptionFontFamily(DescriptionFontFamily);
            FocusLayoutWindow.SetDescriptionColor(DescriptionColor);
            FocusLayoutWindow.SetDescriptionOutline(DescriptionOutlineEnabled ? DescriptionOutlineColor + " " + DescriptionOutlineSize + "px" : "0px");

            FocusLayoutWindow.SetPointsFontFamily(PointsFontFamily);
            FocusLayoutWindow.SetPointsColor(PointsColor);
            FocusLayoutWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");

            FocusLayoutWindow.SetLineColor(LineColor);
            FocusLayoutWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");
        }

        public void SetSimpleSettings()
        {
            FocusLayoutWindow.SetSimpleFontFamily(SimpleFontFamily);
            FocusLayoutWindow.SetSimpleFontColor(SimpleFontColor);
            FocusLayoutWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");
        }

        internal void HideFocus()
        {
            FocusLayoutWindow.HideFocus();
        }

        public void UpdateFocus()
        {
            if (IsOpen && CurrentlyFocusedAchievement != null)
            {
                FocusLayoutWindow.SetFocus(CurrentlyFocusedAchievement);

                if (BorderEnabled)
                {
                    FocusLayoutWindow.EnableBorder();
                }
                else
                {
                    FocusLayoutWindow.DisableBorder();
                }
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
                FocusLayoutWindow.SetFocus(gameInfo);

                if (BorderEnabled)
                {
                    FocusLayoutWindow.EnableBorder();
                }
                else
                {
                    FocusLayoutWindow.DisableBorder();
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

                if (IsOpen)
                {
                    FocusLayoutWindow.SetSimpleFontFamily(SimpleFontFamily);
                }
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

                if (IsOpen)
                {
                    FocusLayoutWindow.SetSimpleFontColor(value);
                }
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
                if (IsOpen)
                {
                    FocusLayoutWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");

                }
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

                if (IsOpen)
                {
                    FocusLayoutWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");

                }
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
                if (IsOpen)
                {
                    FocusLayoutWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");

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
                if (IsOpen)
                {
                    FocusLayoutWindow.SetTitleFontFamily(TitleFontFamily);

                }
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
                if (IsOpen)
                {
                    FocusLayoutWindow.SetDescriptionFontFamily(DescriptionFontFamily);

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

                if (IsOpen)
                {
                    FocusLayoutWindow.SetPointsFontFamily(PointsFontFamily);

                }
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

                if (IsOpen)
                {
                    FocusLayoutWindow.SetTitleColor(value);

                }
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

                if (IsOpen)
                {
                    FocusLayoutWindow.SetDescriptionColor(value);

                }
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

                if (IsOpen)
                {
                    FocusLayoutWindow.SetPointsColor(value);

                }
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

                if (IsOpen)
                {
                    FocusLayoutWindow.SetLineColor(value);

                }
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

                if (IsOpen)
                {
                    FocusLayoutWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");

                }
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

                if (IsOpen)
                {
                    FocusLayoutWindow.SetDescriptionOutline(DescriptionOutlineEnabled ? DescriptionOutlineColor + " " + DescriptionOutlineSize + "px" : "0px");

                }
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

                if (IsOpen)
                {
                    FocusLayoutWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");

                }
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

                if (IsOpen)
                {
                    FocusLayoutWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");

                }
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
                if (IsOpen)
                {
                    FocusLayoutWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");

                }
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
                if (IsOpen)
                {
                    FocusLayoutWindow.SetDescriptionOutline(DescriptionOutlineEnabled ? DescriptionOutlineColor + " " + DescriptionOutlineSize + "px" : "0px");

                }
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
                if (IsOpen)
                {
                    FocusLayoutWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");

                }
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
                if (IsOpen)
                {
                    FocusLayoutWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");

                }
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
                if (IsOpen)
                {
                    FocusLayoutWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");
                }
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
                if (IsOpen)
                {
                    FocusLayoutWindow.SetDescriptionOutline(DescriptionOutlineEnabled ? DescriptionOutlineColor + " " + DescriptionOutlineSize + "px" : "0px");
                }
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

                if (IsOpen)
                {
                    FocusLayoutWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");
                }
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

                if (IsOpen)
                {
                    FocusLayoutWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");
                }
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
                if (IsOpen)
                {
                    if (value)
                    {
                        FocusLayoutWindow.EnableBorder();
                    }
                    else
                    {
                        FocusLayoutWindow.DisableBorder();
                    }
                }
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
                if (IsOpen)
                {
                    FocusLayoutWindow.SetBorderBackgroundColor(value);
                }
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
                if (IsOpen)
                {
                    FocusLayoutWindow.SetWindowBackgroundColor(value);
                }
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