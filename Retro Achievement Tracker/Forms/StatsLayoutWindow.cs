using CefSharp;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    public partial class StatsLayoutWindow : Form
    {
        public Action<string> LogCallback { get; internal set; }
        private string FontColorHexCode;
        private string FontOutlineColorHexCode;
        private string FontFamilyName;
        private float FontSize;
        private int FontOutlineSize;

        public StatsLayoutWindow()
        {
            InitializeComponent();

            FontColorHexCode = Settings.Default.font_color_hex_code;
            FontFamilyName = Settings.Default.font_family_name;
            FontSize = Settings.Default.font_size;

            FontOutlineColorHexCode = Settings.Default.font_outline_color_hex;
            FontOutlineSize = Settings.Default.font_outline_size;

            this.fontOutlineCheckbox.Checked = Settings.Default.font_outline_enabled;

            this.fontColorHexCodeLabel.Text = FontColorHexCode;
            this.fontColorDisplayBox.BackColor = ColorTranslator.FromHtml(FontColorHexCode);
            this.fontFamilyNameLabel.Text = "Name: " + FontFamilyName;
            this.fontSizeLabel.Text = "Size: " + FontSize;

            ToggleOutline();
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
            this.chromiumWebBrowser.LoadHtml(Resources.DefaultStatsWindow);
        }

        public async void SetAwards(int awards)
        {
            if (this.Visible)
            {
                string script = "setAwards(" + awards + ");";

                LogCallback("[setAwards] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback("[setAwards]" + ex.Message);
                }
            }
        }

        public async void SetPoints(int score)
        {
            if (this.Visible)
            {
                string script = "setPoints(" + score + ");";

                LogCallback("[setPoints] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback("[setPoints]" + ex.Message);
                }
            }
        }

        public async void SetRank(int rank)
        {
            if (this.Visible)
            {
                string script = "setRank(" + rank + ");";

                LogCallback("[setRank] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback("[setRank]" + ex.Message);
                }
            }
        }

        public async void SetGamePoints(int gameEarnedPoints, int gameTotalPoints)
        {
            if (this.Visible)
            {
                string script = "setGamePoints(" + gameEarnedPoints + ", " + gameTotalPoints + ");";

                LogCallback("[setGamePoints] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback("[setGamePoints]" + ex.Message);
                }
            }
        }

        public async void SetGameAchievements(int gameEarnedAchievements, int gameTotalAchievements)
        {
            if (this.Visible)
            {
                string script = "setGameAchievements(" + gameEarnedAchievements + ", " + gameTotalAchievements + ");";

                LogCallback("[setGameAchievements] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback("[setGameAchievements]" + ex.Message);
                }
            }
        }

        public async void SetFontColor()
        {
            if (this.Visible)
            {
                string script = "setFontColor('" + FontColorHexCode + "');";

                LogCallback("[setFontColor] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback("[setFontColor]" + ex.Message);
                }
            }
        }

        public async void SetFontFamily()
        {
            if (this.Visible)
            {
                string script = "setFontFamily('" + FontFamilyName + "');";

                LogCallback("[setFontFamily] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback("[setFontFamily]" + ex.Message);
                }
            }
        }

        public async void SetFontSize()
        {
            if (this.Visible)
            {
                string script = "setFontSize('" + FontSize + "px');";

                LogCallback("[setFontSize] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback("[setFontSize]" + ex.Message);
                }
            }
        }

        public async void SetFontOutline()
        {
            if (this.Visible)
            {
                string script = "setFontOutline('" + FontOutlineColorHexCode + " " + FontOutlineSize + "px');";

                LogCallback("[setFontOutline] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback("[setFontOutline]" + ex.Message);
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

                Settings.Default.font_family_name = FontFamilyName;
                Settings.Default.font_size = FontSize;
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

                Settings.Default.font_color_hex_code = FontColorHexCode;
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

                Settings.Default.font_outline_color_hex = FontOutlineColorHexCode;
                Settings.Default.Save();

                SetFontOutline();
            }
        }

        private void FontOutlineCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ToggleOutline();

            SetFontOutline();

            Settings.Default.font_outline_enabled = ((CheckBox)sender).Checked;
            Settings.Default.Save();
        }

        private void FontOutlineSizeUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            FontOutlineSize = Convert.ToInt32(((NumericUpDown)sender).Value.ToString());

            Settings.Default.font_outline_size = FontOutlineSize;
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
                FontOutlineColorHexCode = Settings.Default.font_outline_color_hex;
                FontOutlineSize = Settings.Default.font_outline_size;

                this.fontOutlineColorHexCodeLabel.Text = Settings.Default.font_outline_color_hex;
                this.fontOutlineColorDisplayBox.BackColor = ColorTranslator.FromHtml(FontOutlineColorHexCode);
                this.fontOutlineSizeUpDown.Value = Settings.Default.font_outline_size;
            }
        }

        private String HexConverter(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
    }
}