using CefSharp;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    public partial class StatsLayoutWindow : Form
    {
        private static readonly string CALLER_ID = "StatsWindow";
        public Action<string> LogCallback { get; internal set; }
        private string FontColorHexCode;
        private string FontOutlineColorHexCode;
        private string FontFamilyName;
        private float FontSize;
        private int FontOutlineSize;

        public StatsLayoutWindow()
        {
            InitializeComponent();
            SetupBrowser();
            SetCustomFont();
            LoadProperties();
            SetLabels();
            ToggleOutline();
        }

        private void SetLabels()
        {
            this.fontColorHexCodeLabel.Text = FontColorHexCode;
            this.fontColorDisplayBox.BackColor = ColorTranslator.FromHtml(FontColorHexCode);
            this.fontFamilyNameLabel.Text = "Name: " + FontFamilyName;
            this.fontSizeLabel.Text = "Size: " + FontSize;
        }

        private void LoadProperties()
        {
            FontColorHexCode = Settings.Default.stats_font_color_hex_code;
            FontFamilyName = Settings.Default.stats_font_family_name;
            FontSize = Settings.Default.stats_font_size;

            FontOutlineColorHexCode = Settings.Default.stats_font_outline_color_hex;
            FontOutlineSize = Settings.Default.stats_font_outline_size;

            this.fontOutlineCheckbox.Checked = Settings.Default.stats_font_outline_enabled;
        }

        private void SetCustomFont()
        {
            this.statsGroupBox.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 13.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontOutlineCheckbox.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontOutlineColorPickerButton.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontOutlineColorHexCodeLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontSizeLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontFamilyNameLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontColorPicker.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontColorHexCodeLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontColorLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontSelectionButton.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontFamilyLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontOutlineSizeUpDown.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.label1.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.label2.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        }

        private void ChromiumWebBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            SetFontColor();
            SetFontSize();
            SetFontFamily();
            SetFontOutline();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.chromiumWebBrowser.FrameLoadEnd += ChromiumWebBrowser_FrameLoadEnd;
            this.chromiumWebBrowser.LoadHtml(Resources.StatsWindow);
        }

        public async void SetAwards(int awards)
        {
            if (this.Visible)
            {
                string script = "setAwards(" + awards + ");";

                LogCallback(CALLER_ID +"[setAwards] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID +"[setAwards]" + ex.Message);
                }
            }
        }

        public async void SetPoints(int score)
        {
            if (this.Visible)
            {
                string script = "setPoints(" + score + ");";

                LogCallback(CALLER_ID +"[setPoints] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID +"[setPoints]" + ex.Message);
                }
            }
        }

        public async void SetRank(int rank)
        {
            if (this.Visible)
            {
                string script = "setRank(" + rank + ");";

                LogCallback(CALLER_ID +"[setRank] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID +"[setRank]" + ex.Message);
                }
            }
        }

        public async void SetGamePoints(int gameEarnedPoints, int gameTotalPoints)
        {
            if (this.Visible)
            {
                string script = "setGamePoints(" + gameEarnedPoints + ", " + gameTotalPoints + ");";

                LogCallback(CALLER_ID +"[setGamePoints] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID +"[setGamePoints]" + ex.Message);
                }
            }
        }

        public async void SetGameAchievements(int gameEarnedAchievements, int gameTotalAchievements)
        {
            if (this.Visible)
            {
                string script = "setGameAchievements(" + gameEarnedAchievements + ", " + gameTotalAchievements + ");";

                LogCallback(CALLER_ID +"[setGameAchievements] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID +"[setGameAchievements]" + ex.Message);
                }
            }
        }

        public async void SetFontColor()
        {
            if (this.Visible)
            {
                string script = "setFontColor('" + FontColorHexCode + "');";

                LogCallback(CALLER_ID +"[setFontColor] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID +"[setFontColor]" + ex.Message);
                }
            }
        }

        public async void SetFontFamily()
        {
            if (this.Visible)
            {
                string script = "setFontFamily(\"" + FontFamilyName + "\");";

                LogCallback(CALLER_ID +"[setFontFamily] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID +"[setFontFamily]" + ex.Message);
                }
            }
        }

        public async void SetFontSize()
        {
            if (this.Visible)
            {
                string script = "setFontSize('" + FontSize + "px');";

                LogCallback(CALLER_ID +"[setFontSize] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID +"[setFontSize]" + ex.Message);
                }
            }
        }

        public async void SetFontOutline()
        {
            if (this.Visible)
            {
                string script = "setFontOutline('" + FontOutlineColorHexCode + " " + FontOutlineSize + "px');";

                LogCallback(CALLER_ID +"[setFontOutline] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID +"[setFontOutline]" + ex.Message);
                }
            }
        }

        private void fontSelectionButton_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = false;
            fontDialog1.ShowApply = false;
            fontDialog1.ShowEffects = false;
            fontDialog1.ShowHelp = false;
            fontDialog1.MaxSize = 0;
            fontDialog1.MinSize = 22;

            fontDialog1.Font = new Font(FontFamilyName, FontSize);

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Font font = fontDialog1.Font;

                FontFamilyName = font.FontFamily.Name;
                FontSize = font.Size;

                this.fontFamilyNameLabel.Text = "Name: " + FontFamilyName;
                this.fontSizeLabel.Text = "Size: " + FontSize;

                Settings.Default.stats_font_family_name = FontFamilyName;
                Settings.Default.stats_font_size = FontSize;
                Settings.Default.Save();

                SetFontFamily();
                SetFontSize();
            }
        }

        private void colorPickerButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                fontColorDisplayBox.BackColor = colorDialog1.Color;

                FontColorHexCode = HexConverter(colorDialog1.Color);
                fontColorHexCodeLabel.Text = FontColorHexCode;

                Settings.Default.stats_font_color_hex_code = FontColorHexCode;
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

                Settings.Default.stats_font_outline_color_hex = FontOutlineColorHexCode;
                Settings.Default.Save();

                SetFontOutline();
            }
        }

        private void FontOutlineCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ToggleOutline();

            SetFontOutline();

            Settings.Default.stats_font_outline_enabled = ((CheckBox)sender).Checked;
            Settings.Default.Save();
        }

        private void FontOutlineSizeUpDown_ValueChanged(object sender, EventArgs e)
        {
            FontOutlineSize = Convert.ToInt32(((NumericUpDown)sender).Value.ToString());

            Settings.Default.stats_font_outline_size = FontOutlineSize;
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
                FontOutlineColorHexCode = Settings.Default.stats_font_outline_color_hex;
                FontOutlineSize = Settings.Default.stats_font_outline_size;

                this.fontOutlineColorHexCodeLabel.Text = Settings.Default.stats_font_outline_color_hex;
                this.fontOutlineColorDisplayBox.BackColor = ColorTranslator.FromHtml(FontOutlineColorHexCode);
                this.fontOutlineSizeUpDown.Value = Settings.Default.stats_font_outline_size;
            }
        }

        private String HexConverter(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        private void SetupBrowser()
        {
            this.chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser();

            // 
            // chromiumWebBrowser
            // 
            this.chromiumWebBrowser.ActivateBrowserOnCreation = false;
            this.chromiumWebBrowser.Location = new System.Drawing.Point(240, 0);
            this.chromiumWebBrowser.Name = "chromiumWebBrowser";
            this.chromiumWebBrowser.Size = new System.Drawing.Size(1920, 1080);
            this.chromiumWebBrowser.TabIndex = 0;
            this.chromiumWebBrowser.Dock = System.Windows.Forms.DockStyle.None;

            this.Controls.Add(this.chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;
    }
}