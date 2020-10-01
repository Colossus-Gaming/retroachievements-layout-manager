using CefSharp;
using Retro_Achievement_Tracker.Models;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    public partial class StatsLayoutWindow : Form
    {
        public StatsLayoutWindow()
        {
            this.ClientSize = new System.Drawing.Size(1000, 300);
            SetupBrowser();
            this.Name = "RA Tracker - Stats";
            this.Text = "RA Tracker - Stats";
        }

        public async void SetAwards(int awards)
        {
            await ExecuteScript("setAwards(" + awards + ");");
        }

        public async void SetPoints(int score)
        {
            await ExecuteScript("setPoints(" + score + ");");
        }

        public async void SetRank(int rank)
        {
            await ExecuteScript("setRank(" + rank + ");");
        }

        public async void SetGamePoints(int gameEarnedPoints, int gameTotalPoints)
        {
            await ExecuteScript("setGamePoints(" + gameEarnedPoints + ", " + gameTotalPoints + ");");
        }

        public async void SetGameAchievements(int gameEarnedAchievements, int gameTotalAchievements)
        {
            await ExecuteScript("setGameAchievements(" + gameEarnedAchievements + ", " + gameTotalAchievements + ");");
        }
        public async void SetFontColor(string hexCode)
        {
            await ExecuteScript("setFontColor(\"" + hexCode + "\");");
        }

        public async void SetFontFamily(string fontName)
        {
            Console.WriteLine(fontName);
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
            this.chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser()
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
            this.SuspendLayout();
            // 
            // StatsLayoutWindow
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "StatsLayoutWindow";
            this.ResumeLayout(false);

        }
    }
}