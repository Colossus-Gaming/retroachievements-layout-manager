using CefSharp;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    public partial class FocusLayoutWindow : Form
    {
        private static readonly string CALLER_ID = "FocusWindow";
        private List<Achievement> LockedAchievements;
        public Achievement FocusedAchievement;
        public int CurrentlyFocusedIndex;
        public Action<string> LogCallback { get; internal set; }

        private string FontColorHexCode;
        private string FontOutlineColorHexCode;
        private string FontFamilyName;
        private bool FontBolded;
        private int FontOutlineSize;

        private string BackgroundColorHexCode;

        public FocusLayoutWindow()
        {
            InitializeComponent();
            SetCustomFont();
            LoadProperties();
            SetLabels();
            ToggleOutline();
        }
        private void SetLabels()
        {
            this.fontColorHexCodeLabel.Text = FontColorHexCode;
            this.fontColorDisplayBox.BackColor = ColorTranslator.FromHtml(FontColorHexCode);

            this.backgroundColorHexCodeLabel.Text = BackgroundColorHexCode;
            this.backgroundColorDisplayBox.BackColor = ColorTranslator.FromHtml(BackgroundColorHexCode);

            this.fontFamilyNameLabel.Text = "Name: " + FontFamilyName;
        }

        private void LoadProperties()
        {
            FontColorHexCode = Settings.Default.focus_font_color_hex_code;
            FontFamilyName = Settings.Default.focus_font_family_name;

            FontOutlineColorHexCode = Settings.Default.focus_font_outline_color_hex;
            FontOutlineSize = Settings.Default.focus_font_outline_size;

            BackgroundColorHexCode = Settings.Default.focus_background_color;

            this.fontOutlineCheckbox.Checked = Settings.Default.focus_font_outline_enabled;
        }

        private void SetCustomFont()
        {
            this.focusAchievementTitleLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementDescriptionLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementButtonLeft.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementButtonRight.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.setFocusButton.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.hideFocusButton.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            this.customizationGroupBox.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 13.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontOutlineCheckbox.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontOutlineColorPickerButton.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
           
            this.fontOutlineColorHexCodeLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.backgroundColorHexCodeLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontColorHexCodeLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            this.fontFamilyNameLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontColorPicker.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontColorLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontSelectionButton.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontFamilyLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.backgroundColorLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontOutlineSizeUpDown.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.chromiumWebBrowser.FrameLoadEnd += ChromiumWebBrowser_FrameLoadEnd;
            this.chromiumWebBrowser.LoadHtml(Resources.DefaultFocusWindow);
        }

        private void ChromiumWebBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            SetFontColor();
            SetFontFamily();
            SetFontOutline();
            SetBackgroundColor();
        }


        public void SetLockedAchievements(List<Achievement> achievements)
        {
            if (achievements != null && achievements.Count > 0)
            {
                int gameId = achievements[0].GameId;
                if (LockedAchievements == null || (LockedAchievements.Count > 0 && gameId != LockedAchievements[0].GameId))
                {
                    CurrentlyFocusedIndex = 0;
                    FocusedAchievement = null;
                }
            }
            else
            {
                CurrentlyFocusedIndex = 0;
                FocusedAchievement = null;
            }

            LockedAchievements = achievements;
            UpdateFocusAchievement();
        }

        public void UpdateFocusAchievement()
        {
            if (this.Visible)
            {
                Invoke((MethodInvoker)delegate
                {
                    UpdateFocusButtons();

                    if (LockedAchievements.Count > 0)
                    {
                        if (CurrentlyFocusedIndex >= LockedAchievements.Count)
                        {
                            CurrentlyFocusedIndex = LockedAchievements.Count - 1;
                        }
                        else if (CurrentlyFocusedIndex < 0)
                        {
                            CurrentlyFocusedIndex = 0;
                        }


                        FocusedAchievement = LockedAchievements[CurrentlyFocusedIndex];

                        this.focusAchievementPictureBox.ImageLocation = "https://retroachievements.org/Badge/" + FocusedAchievement.BadgeNumber + ".png";
                        this.focusAchievementTitleLabel.Text = FocusedAchievement.Title;
                        this.focusAchievementDescriptionLabel.Text = FocusedAchievement.Description;
                    }
                    else
                    {
                        CurrentlyFocusedIndex = 0;

                        this.focusAchievementPictureBox.ImageLocation = string.Empty;
                        this.focusAchievementTitleLabel.Text = string.Empty;
                        this.focusAchievementDescriptionLabel.Text = string.Empty;

                        HideFocus();
                    }
                });
            }
        }

        private void SetFocusButton_Click(object sender, EventArgs e)
        {
            SetFocus();
        }

        private void HideFocusButton_Click(object sender, EventArgs e)
        {
            HideFocus();
        }

        public async void SetFocus()
        {
            if (this.Visible && LockedAchievements != null && FocusedAchievement != null)
            {
                string script = "setFocus(\"" + FocusedAchievement.Title + "\"," +
                           "\"https://retroachievements.org/Badge/" + FocusedAchievement.BadgeNumber + ".png\"," +
                           "\"" + FocusedAchievement.Description + "\"," +
                           "\"" + FocusedAchievement.Points + "\");";

                LogCallback(CALLER_ID + "[setFocus] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(2));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[setFocus]" + ex.Message);
                }
            }

            SetFontColor();
            SetFontFamily();
            SetFontOutline();
        }

        public async void HideFocus()
        {
            if (this.Visible)
            {
                string script = "hideFocus();";

                LogCallback(CALLER_ID + "[hideFocus] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(2));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[hideFocus]" + ex.Message);
                }
            }
        }


        private async void SetBackgroundColor()
        {
            if (this.Visible)
            {
                string script = "setBackgroundColor('" + BackgroundColorHexCode + "');";

                LogCallback(CALLER_ID + "[setBackgroundColor] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(2));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[setBackgroundColor]" + ex.Message);
                }
            }
        }

        public async void SetFontColor()
        {
            if (this.Visible)
            {
                string script = "setFontColor('" + FontColorHexCode + "');";

                LogCallback(CALLER_ID + "[setFontColor] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[setFontColor]" + ex.Message);
                }
            }
        }

        public async void SetFontFamily()
        {
            if (this.Visible)
            {
                string script = "setFontFamily(\"" + FontFamilyName + "\", \"" + FontBolded + "\");";

                LogCallback(CALLER_ID + "[setFontFamily] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[setFontFamily]" + ex.Message);
                }
            }
        }

        public async void SetFontOutline()
        {
            if (this.Visible)
            {
                string script = "setFontOutline('" + FontOutlineColorHexCode + " " + FontOutlineSize + "px');";

                LogCallback(CALLER_ID + "[setFontOutline] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[setFontOutline]" + ex.Message);
                }
            }
        }

        private void fontSelectionButton_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = false;
            fontDialog1.ShowApply = false;
            fontDialog1.ShowEffects = false;
            fontDialog1.ShowHelp = false;

            fontDialog1.Font = new Font(FontFamilyName, 72f);

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Font font = fontDialog1.Font;

                FontFamilyName = font.FontFamily.Name;
                FontBolded = font.Bold;

                this.fontFamilyNameLabel.Text = "Name: " + FontFamilyName;

                Settings.Default.focus_font_family_name = FontFamilyName;
                Settings.Default.Save();

                SetFontFamily();
            }
        }

        private void colorPickerButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                fontColorDisplayBox.BackColor = colorDialog1.Color;

                FontColorHexCode = HexConverter(colorDialog1.Color);
                fontColorHexCodeLabel.Text = FontColorHexCode;

                Settings.Default.focus_font_color_hex_code = FontColorHexCode;
                Settings.Default.Save();

                SetFontColor();
            }
        }

        private void fontOutlineColorPickerButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                fontOutlineColorDisplayBox.BackColor = colorDialog1.Color;

                FontOutlineColorHexCode = HexConverter(colorDialog1.Color);
                fontOutlineColorHexCodeLabel.Text = FontOutlineColorHexCode;

                Settings.Default.focus_font_outline_color_hex = FontOutlineColorHexCode;
                Settings.Default.Save();

                SetFontOutline();
            }
        }


        private void backgroundColorPickerButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                backgroundColorDisplayBox.BackColor = colorDialog1.Color;

                BackgroundColorHexCode = HexConverter(colorDialog1.Color);
                backgroundColorHexCodeLabel.Text = BackgroundColorHexCode;

                Settings.Default.focus_background_color = BackgroundColorHexCode;
                Settings.Default.Save();

                SetBackgroundColor();
            }
        }

        private void FontOutlineCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ToggleOutline();

            SetFontOutline();

            Settings.Default.focus_font_outline_enabled = ((CheckBox)sender).Checked;
            Settings.Default.Save();
        }

        private void FontOutlineSizeUpDown_ValueChanged(object sender, EventArgs e)
        {
            FontOutlineSize = Convert.ToInt32(((NumericUpDown)sender).Value.ToString());

            Settings.Default.focus_font_outline_size = FontOutlineSize;
            Settings.Default.Save();

            SetFontOutline();
        }

        private void ToggleOutline()
        {
            bool isChecked = this.fontOutlineCheckbox.Checked;

            this.fontOutlineColorDisplayBox.Enabled = isChecked;
            this.fontOutlineColorHexCodeLabel.Enabled = isChecked;
            this.fontOutlineColorPickerButton.Enabled = isChecked;
            this.fontOutlineSizeUpDown.Enabled = isChecked;

            if (!isChecked)
            {
                FontOutlineColorHexCode = "";
                FontOutlineSize = 0;
            }
            else
            {
                FontOutlineColorHexCode = Settings.Default.focus_font_outline_color_hex;
                FontOutlineSize = Settings.Default.focus_font_outline_size;

                this.fontOutlineColorHexCodeLabel.Text = Settings.Default.focus_font_outline_color_hex;
                this.fontOutlineColorDisplayBox.BackColor = ColorTranslator.FromHtml(FontOutlineColorHexCode);
                this.fontOutlineSizeUpDown.Value = Settings.Default.focus_font_outline_size;
            }
        }

        private String HexConverter(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        private void MoveHuntIndexLeft(object sender, EventArgs e)
        {
            CurrentlyFocusedIndex--;

            if (CurrentlyFocusedIndex < 0)
            {
                CurrentlyFocusedIndex = 0;
            }

            UpdateFocusAchievement();
        }

        private void MoveHuntIndexRight(object sender, EventArgs e)
        {
            CurrentlyFocusedIndex++;

            if (CurrentlyFocusedIndex >= LockedAchievements.Count)
            {
                CurrentlyFocusedIndex = LockedAchievements.Count - 1;
            }

            UpdateFocusAchievement();
        }

        private void UpdateFocusButtons()
        {
            if (LockedAchievements.Count == 0)
            {
                this.focusAchievementButtonLeft.Enabled = false;
                this.focusAchievementButtonRight.Enabled = false;
                this.setFocusButton.Enabled = false;
                this.hideFocusButton.Enabled = false;
            }
            else
            {
                this.setFocusButton.Enabled = true;
                this.hideFocusButton.Enabled = true;

                if (CurrentlyFocusedIndex == 0)
                {
                    this.focusAchievementButtonLeft.Enabled = false;
                    this.focusAchievementButtonRight.Enabled = true;
                }
                else if (CurrentlyFocusedIndex == LockedAchievements.Count - 1)
                {
                    this.focusAchievementButtonLeft.Enabled = true;
                    this.focusAchievementButtonRight.Enabled = false;
                }
                else
                {
                    this.focusAchievementButtonLeft.Enabled = true;
                    this.focusAchievementButtonRight.Enabled = true;
                }
            }
        }
    }
}