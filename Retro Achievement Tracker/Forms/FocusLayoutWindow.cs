using CefSharp;
using CefSharp.Web;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    public partial class FocusLayoutWindow : Form
    {
        private bool isReady = false;

        public bool FocusDisplayed = false;
        public Achievement CurrentlyFocusedAchievement;
        public FocusLayoutWindow()
        {
            this.ClientSize = new Size(0, 0);

            FontFamily[] familyArray = FontFamily.Families.ToArray();

            FontFamily[] focusFontFamily = familyArray.Where(fontFamily => fontFamily.Name.Equals(Settings.Default.focus_font_family_name)).ToArray();

            FontFamily = focusFontFamily[0];

            SetupBrowser();
            this.Name = "RA Tracker - Focus";
            this.Text = "RA Tracker - Focus";
        }
        public FontFamily FontFamily
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
                Settings.Default.Save();

                return familyArray[0];
            }
            set
            {
                Settings.Default.focus_font_family_name = value.Name;
                Settings.Default.Save();

                SetFontFamily();

            }
        }
        public string FontColor
        {
            get
            {
                return Settings.Default.focus_font_color_hex_code;
            }
            set
            {
                Settings.Default.focus_font_color_hex_code = value;
                Settings.Default.Save();

                SetFontColor();

            }
        }
        public string FontOutlineColor
        {
            get
            {
                return Settings.Default.focus_font_outline_color_hex;
            }
            set
            {
                Settings.Default.focus_font_outline_color_hex = value;
                Settings.Default.Save();

                SetFontOutline();

            }
        }
        public int FontOutlineSize
        {
            get
            {
                return Settings.Default.focus_font_outline_size;
            }
            set
            {
                Settings.Default.focus_font_outline_size = value;
                Settings.Default.Save();

                SetFontOutline();

            }
        }
        public bool FontOutlineEnable
        {
            get
            {
                return Settings.Default.focus_font_outline_enabled;
            }
            set
            {
                Settings.Default.focus_font_outline_enabled = value;
                Settings.Default.Save();

                SetFontOutline();
            }
        }
        public bool PointsEnable
        {
            get
            {
                return Settings.Default.focus_points_enable;
            }
            set
            {
                Settings.Default.focus_points_enable = value;
                Settings.Default.Save();

                if (value)
                {
                    ShowPoints();
                }
                else
                {
                    HidePoints();
                }
            }
        }
        public bool BorderEnable
        {
            get
            {
                return Settings.Default.focus_border_enable;
            }
            set
            {
                Settings.Default.focus_border_enable = value;
                Settings.Default.Save();

                if (value)
                {
                    EnableBorder();
                }
                else
                {
                    DisableBorder();
                }
            }
        }
        public string BackgroundColor
        {
            get
            {
                return Settings.Default.focus_background_color;
            }
            set
            {
                Settings.Default.focus_background_color = value;
                Settings.Default.Save();

                SetBackgroundColor();
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
            }
        }
        public async void SetFocus(Achievement achievement)
        {
            CurrentlyFocusedAchievement = achievement;

            if (isReady)
            {
                if (achievement != null)
                {
                    FocusDisplayed = true;

                    Invoke((MethodInvoker)delegate
                    {
                        this.ClientSize = new Size(700, 165);
                    });

                    await ExecuteScript("setFocus(\"" + achievement.Title.Replace("\"", "\\\"") + "\"," +
                               "\"https://retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\"," +
                               "\"" + achievement.Description.Replace("\"", "\\\"") + "\"," +
                               "\"" + achievement.Points + "\");");
                }
                else
                {
                    Invoke((MethodInvoker)delegate
                    {
                        this.ClientSize = new Size(700, 0);
                    });
                }
            }
        }

        public async void HideFocus()
        {
            FocusDisplayed = false;

            Invoke((MethodInvoker)delegate
            {
                this.ClientSize = new Size(0, 0);
            });

            await ExecuteScript("hideFocus();");
        }
        public async void EnableBorder()
        {
            await ExecuteScript("enableBorder();");
        }
        public async void DisableBorder()
        {
            await ExecuteScript("disableBorder();");
        }
        public async void ShowPoints()
        {
            await ExecuteScript("showPoints();");
        }
        public async void HidePoints()
        {
            await ExecuteScript("hidePoints();");
        }
        public async void SetFontColor()
        {
            await ExecuteScript("setFontColor(\"" + FontColor + "\");");
        }
        public async void SetFontFamily()
        {
            await ExecuteScript(string.Format("setFont(\"{0}\", \"{1}\");", FontFamily.Name.Replace(":", "\\\\:"), FontFamily.GetLineSpacing(FontStyle.Regular) / FontFamily.GetEmHeight(FontStyle.Regular)));
        }
        public async void SetFontOutline()
        {
            if (FontOutlineEnable)
            {
                await ExecuteScript("setFontOutline(\"" + FontOutlineColor + " " + FontOutlineSize + "px\");");
                await ExecuteScript("setBorderOutline(\"" + FontOutlineSize + "px solid " + FontOutlineColor + "\");");
            }
            else
            {
                await ExecuteScript("setFontOutline(\"0px\");");
                await ExecuteScript("setBorderOutline(\"0px\");");
            }
        }
        public async void SetBackgroundColor()
        {
            await ExecuteScript("setBackgroundColor(\"" + BackgroundColor + "\");");
        }
        protected async Task ExecuteScript(string script)
        {
            if (this.Visible && this.isReady)
            {
                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception)
                {
                }
            }
        }

        protected void SetupBrowser()
        {
            this.chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.FocusWindow))
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "chromiumWebBrowser",
                Size = new Size(1366, 768),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };
            chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                Invoke((MethodInvoker)delegate
                {
                    this.ClientSize = new Size(700, 0);
                    this.isReady = true;
                });

                SetFontFamily();
                SetFontColor();
                SetFontOutline();
                SetBackgroundColor();

                if (PointsEnable)
                {
                    ShowPoints();
                }
                else
                {
                    HidePoints();
                }
                if (BorderEnable)
                {
                    EnableBorder();
                }
                else
                {
                    DisableBorder();
                }
                if (CurrentlyFocusedAchievement != null)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        SetFocus(CurrentlyFocusedAchievement); 
                    });
                }                
            });
            chromiumWebBrowser.LoadHtml(Resources.FocusWindow);

            this.Controls.Add(this.chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FocusLayoutWindow));
            this.SuspendLayout();
            // 
            // FocusLayoutWindow
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FocusLayoutWindow";
            this.ResumeLayout(false);

        }
    }
}