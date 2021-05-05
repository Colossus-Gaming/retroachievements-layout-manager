using CefSharp;
using CefSharp.Web;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    public partial class LastFiveLayoutWindow : Form
    {
        private bool isReady = false;

        private ConcurrentQueue<Achievement> CurrentAchievements;
        private Stopwatch longActionStopwatch;
        private System.Timers.Timer timer;
        private Queue<Action> actions;

        public LastFiveLayoutWindow()
        {
            this.ClientSize = new Size(0, 0);

            FontFamily[] familyArray = FontFamily.Families.ToArray();
            FontFamily[] lastFiveFontFamily = familyArray.Where(fontFamily => fontFamily.Name.Equals(Settings.Default.last_five_font_family_name)).ToArray();

            FontFamily = lastFiveFontFamily[0];

            this.Name = "RA Tracker - Last Five Achievements";
            this.Text = "RA Tracker - Last Five Achievements";
            SetupBrowser();

            CurrentAchievements = new ConcurrentQueue<Achievement>();
            actions = new Queue<Action>();

            this.timer = new System.Timers.Timer(200);
            this.timer.Elapsed += new ElapsedEventHandler(ExecuteActions);
            this.timer.AutoReset = true;
            this.timer.Enabled = true;

            this.longActionStopwatch = new Stopwatch();
            this.longActionStopwatch.Start();
        }
        public FontFamily FontFamily
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

                SetFontFamily();
            }
        }
        public string FontColor
        {
            get
            {
                return Settings.Default.last_five_font_color_hex_code;
            }
            set
            {
                Settings.Default.last_five_font_color_hex_code = value;
                Settings.Default.Save();

                SetFontColor();
            }
        }
        public string FontOutlineColor
        {
            get
            {
                return Settings.Default.last_five_font_outline_color_hex;
            }
            set
            {
                Settings.Default.last_five_font_outline_color_hex = value;
                Settings.Default.Save();

                SetFontOutline();
            }
        }
        public int FontOutlineSize
        {
            get
            {
                return Settings.Default.last_five_font_outline_size;
            }
            set
            {
                Settings.Default.last_five_font_outline_size = value;
                Settings.Default.Save();

                SetFontOutline();
            }
        }
        public bool FontOutlineEnable
        {
            get
            {
                return Settings.Default.last_five_font_outline_enabled;
            }
            set
            {
                Settings.Default.last_five_font_outline_enabled = value;
                Settings.Default.Save();

                SetFontOutline();
            }
        }
        public bool PointsEnable
        {
            get
            {
                return Settings.Default.last_five_points_enable;
            }
            set
            {
                Settings.Default.last_five_points_enable = value;
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
                return Settings.Default.last_five_border_enable;
            }
            set
            {
                Settings.Default.last_five_border_enable = value;
                Settings.Default.Save();

                if (value)
                {
                    DisplayBorder();
                }
                else
                {
                    RemoveBorder();
                }
            }
        }
        public string BackgroundColor
        {
            get
            {
                return Settings.Default.last_five_background_color;
            }
            set
            {
                Settings.Default.last_five_background_color = value;
                Settings.Default.Save();

                SetBackgroundColor();
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
        
        public async void SetFontColor()
        {
            await ExecuteScript("setFontColor(\"" + FontColor + "\");");
        }

        public async void SetFontFamily()
        {
            await ExecuteScript(string.Format("setFont(\"{0}\", \"{1}\");", FontFamily.Name.Replace(":", "\\\\:"), 
                FontFamily.GetLineSpacing(FontStyle.Regular) / FontFamily.GetEmHeight(FontStyle.Regular)));
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
        public async void PromptUserInput()
        {
            await ExecuteScript("promptUser();");
        }
        public async void DisplayBorder()
        {
            if (BorderEnable)
            {
                await ExecuteScript("enableBorder();");
            }
        }
        public async void RemoveBorder()
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
        private async void ClearList()
        {
            longActionStopwatch.Restart();

            CurrentAchievements = new ConcurrentQueue<Achievement>();

            await ExecuteScript("clearList();");
        }

        private async void AddAchievement(Achievement achievement)
        {
            await ExecuteScript("addToList(\"" + achievement.Title.Replace("\"", "\\\"") + "\"," +
                                       "\"https://retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\",\"" +
                                       achievement.Description.Replace("\"", "\\\"") + "\",\"" + achievement.Points + "\",\"" +
                                       achievement.DateEarned.ToString() + "\", \"" + achievement.Id + "\");");
        }

        public async void ShowList(int count)
        {
            if (count > 0)
            {
                longActionStopwatch.Restart();

                await ExecuteScript("showList(\"" + count + "\");");
            }
        }

        public void QueueShowList()
        {
            int count = CurrentAchievements.Count;

            actions.Enqueue(() =>
            {
                ShowList(count);
            });
        }

        public void QueueClearList()
        {
            actions.Enqueue(() =>
            {
                ClearList();
            });
        }

        public void EnqueueAchievement(Achievement achievement)
        {
            if (!CurrentAchievements.Contains(achievement))
            {
                CurrentAchievements.Enqueue(achievement);

                actions.Enqueue(() =>
                {
                    AddAchievement(achievement);
                });
            }

            while(CurrentAchievements.Count > 5)
            {
                CurrentAchievements.TryDequeue(out Achievement result);
            }
        }

        private void ExecuteActions(object sender, EventArgs e)
        {
            if (longActionStopwatch.ElapsedMilliseconds > 1500 && isReady)
            {
                longActionStopwatch.Stop();

                if (actions.Count > 0)
                {
                    actions.Dequeue().Invoke();
                }
            }
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
            this.chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.LastFive))
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "chromiumWebBrowser",
                Size = new Size(1366, 768),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };

            this.Controls.Add(this.chromiumWebBrowser);

            chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                Invoke((MethodInvoker)delegate
                {
                    this.isReady = true;
                    this.ClientSize = new Size(615, 720);
                });

                SetFontOutline();
                SetFontFamily();
                SetFontColor();
                SetBackgroundColor();

                if (BorderEnable)
                {
                    DisplayBorder();
                }
                else
                {
                    RemoveBorder();
                }
                if (PointsEnable)
                {
                    ShowPoints();
                }
                else
                {
                    HidePoints();
                }
            });
            chromiumWebBrowser.LoadHtml(Resources.LastFive);

            this.Controls.Add(this.chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LastFiveLayoutWindow));
            this.SuspendLayout();
            // 
            // LastFiveLayoutWindow
            // 
            this.ClientSize = new Size(284, 261);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LastFiveLayoutWindow";
            this.ResumeLayout(false);

        }
    }
}