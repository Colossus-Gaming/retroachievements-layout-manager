using CefSharp;
using CefSharp.Web;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    public partial class LastFiveLayoutWindow : Form
    {
        private List<Achievement> achievementsQueue;
        private Stopwatch stopwatch;
        private readonly CancellationTokenSource tokenSource2 = new CancellationTokenSource();
        public LastFiveLayoutWindow()
        {
            this.ClientSize = new Size(1000, 700);
            SetupBrowser();
            this.Name = "RA Tracker - Last Five Achievements";
            this.Text = "RA Tracker - Last Five Achievements";
            achievementsQueue = new List<Achievement>();
            this.stopwatch = new Stopwatch();
        }
        public async void SetFontColor(string hexCode)
        {
            await ExecuteScript("setFontColor(\"" + hexCode + "\");");
        }
        public async void SetFontFamily(string fontName)
        {
            await ExecuteScript("setFontFamily(\"" + fontName.Replace("'", "\\'") + "\");");
        }
        public async void SetFontOutline(string hexCode, int size)
        {
            await ExecuteScript("setFontOutline(\"" + hexCode + " " + size + "px\");");
        }
        public async void SetBackgroundColor(string hexCode)
        {
            await ExecuteScript("setBackgroundColor(\"" + hexCode + "\");");
        }
        public async void ClearAchievements()
        {
            await ExecuteScript("clearAchievements();");
        }
        public async void AddAchievement(Achievement achievement)
        {
            await ExecuteScript("addAchievement(\"" + achievement.Title.Replace("\"", "\\\"") + "\"," +
                                       "\"https://retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\",\"" +
                                       achievement.Description.Replace("\"", "\\\"") + "\",\"" + achievement.Points + "\");");
        }
        public void EnqueueAchievement(Achievement achievement)
        {
            achievementsQueue.Add(achievement);

            if (!stopwatch.IsRunning)
            {
                AppendAchievements();
            }
        }
        private Achievement DequeueAchievement()
        {
            Achievement achievement = achievementsQueue[0];

            achievementsQueue.Remove(achievement);

            return achievement;
        }
        private async void AppendAchievements()
        {
            long delayInMilli = 0;

            stopwatch = Stopwatch.StartNew();

            while (achievementsQueue.Count > 0 || stopwatch.IsRunning)
            {
                if (tokenSource2.Token.IsCancellationRequested)
                {
                    tokenSource2.Token.ThrowIfCancellationRequested();
                }

                if (!stopwatch.IsRunning && achievementsQueue.Count > 0 && !this.IsDisposed)
                {
                    AddAchievement(DequeueAchievement());
                }
                else
                {
                    if (stopwatch.ElapsedMilliseconds > delayInMilli)
                    {
                        stopwatch.Stop();

                        delayInMilli = 0;
                    }
                    else
                    {
                        await Task.Delay(400);
                    }
                }
            }
        }

        protected async Task ExecuteScript(string script)
        {
            if (this.Visible)
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