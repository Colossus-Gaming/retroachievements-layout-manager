using CefSharp;
using CefSharp.Web;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
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
            this.ClientSize = new Size(1000, 700);
            SetupBrowser();
            this.Name = "RA Tracker - Stats";
            this.Text = "RA Tracker - Stats";
        }
        //Rank
        public async void SetRank(int rank)
        {
            await ExecuteScript("setRank(" + rank + ");");
        }
        public async void SetRankName(string rankName)
        {
            await ExecuteScript("setRankName('" + rankName.Replace("'", "\\'") + ":');");
        }
        public async void HideRank()
        {
            await ExecuteScript("hideRank();");
        }
        public async void ShowRank()
        {
            await ExecuteScript("showRank();");
        }
        //Awards
        public async void SetAwards(int awards)
        {
            await ExecuteScript("setAwards(" + awards + ");");
        }
        public async void SetAwardsName(string awardsName)
        {
            await ExecuteScript("setAwardsName('" + awardsName.Replace("'", "\\'") + ":');");
        }
        public async void HideAwards()
        {
            await ExecuteScript("hideAwards();");
        }
        public async void ShowAwards()
        {
            await ExecuteScript("showAwards();");
        }
        //Points
        public async void SetPoints(int points)
        {
            await ExecuteScript("setPoints(" + points + ");");
        }
        public async void SetPointsName(string pointsName)
        {
            await ExecuteScript("setPointsName('" + pointsName.Replace("'", "\\'") + ":');");
        }
        public async void HidePoints()
        {
            await ExecuteScript("hidePoints();");
        }
        public async void ShowPoints()
        {
            await ExecuteScript("showPoints();");
        }
        //True Points
        public async void SetTruePoints(int truePoints)
        {
            await ExecuteScript("setTruePoints(" + truePoints + ");");
        }
        public async void SetTruePointsName(string truePointsName)
        {
            await ExecuteScript("setTruePointsName('" + truePointsName.Replace("'", "\\'") + ":');");
        }
        public async void HideTruePoints()
        {
            await ExecuteScript("hideTruePoints();");
        }
        public async void ShowTruePoints()
        {
            await ExecuteScript("showTruePoints();");
        }
        //Ratio
        public async void SetRatio(float ratio)
        {
            await ExecuteScript("setRatio('" + ratio.ToString("0.00") + "');");
        }
        public async void SetRatioName(string ratioName)
        {
            await ExecuteScript("setRatioName('" + ratioName.Replace("'", "\\'") + ":');");
        }
        public async void HideRatio()
        {
            await ExecuteScript("hideRatio();");
        }
        public async void ShowRatio()
        {
            await ExecuteScript("showRatio();");
        }
        //Game Ratio
        public async void SetGameRatio(float gameRatio)
        {
            await ExecuteScript("setGameRatio('" + gameRatio.ToString("0.00") + "');");
        }
        public async void SetGameRatioName(string gameRatioName)
        {
            await ExecuteScript("setGameRatioName('" + gameRatioName.Replace("'", "\\'") + ":');");
        }
        public async void HideGameRatio()
        {
            await ExecuteScript("hideGameRatio();");
        }
        public async void ShowGameRatio()
        {
            await ExecuteScript("showGameRatio();");
        }
        //Game Points
        public async void SetGamePoints(int gameEarnedPoints, int gameTotalPoints)
        {
            await ExecuteScript("setGamePoints(" + gameEarnedPoints + ", " + gameTotalPoints + ");");
        }
        public async void SetGamePointsName(string gamePointsName)
        {
            await ExecuteScript("setGamePointsName('" + gamePointsName.Replace("'", "\\'") + ":');");
        }
        public async void HideGamePoints()
        {
            await ExecuteScript("hideGamePoints();");
        }
        public async void ShowGamePoints()
        {
            await ExecuteScript("showGamePoints();");
        }
        //Game Achievements
        public async void SetGameAchievements(int gameEarnedAchievements, int gameTotalAchievements)
        {
            await ExecuteScript("setGameAchievements(" + gameEarnedAchievements + ", " + gameTotalAchievements + ");");
        }
        public async void SetGameAchievementsName(string gameAchievementsName)
        {
            await ExecuteScript("setGameAchievementsName('" + gameAchievementsName.Replace("'", "\\'") + ":');");
        }
        public async void HideGameAchievements()
        {
            await ExecuteScript("hideGameAchievements();");
        }
        public async void ShowGameAchievements()
        {
            await ExecuteScript("showGameAchievements();");
        }
        //Game True Points
        public async void SetGameTruePoints(int gameEarnedTruePoints, int gameTotalTruePoints)
        {
            await ExecuteScript("setGameTruePoints(" + gameEarnedTruePoints + ", " + gameTotalTruePoints + ");");
        }
        public async void SetGameTruePointsName(string gameTruePointsName)
        {
            await ExecuteScript("setGameTruePointsName('" + gameTruePointsName.Replace("'", "\\'") + ":');");
        }
        public async void HideGameTruePoints()
        {
            await ExecuteScript("hideGameTruePoints();");
        }
        public async void ShowGameTruePoints()
        {
            await ExecuteScript("showGameTruePoints();");
        }
        //Completed
        public async void SetCompletedName(string completedName)
        {
            await ExecuteScript("setCompletedName('" + completedName.Replace("'", "\\'") + ":');");
        }
        public async void SetCompletedValue(int completed)
        {
            await ExecuteScript("setCompletedValue(" + completed + ");");
        }
        public async void ShowCompleted()
        {
            await ExecuteScript("showCompleted();");
        }
        public async void HideCompleted()
        {
            await ExecuteScript("hideCompleted();");
        }
        //Fonts
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
        public async void SetFontSize(int size)
        {
            await ExecuteScript("setFontSize(" + size + ");");
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
            this.chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.StatsWindow))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatsLayoutWindow));
            this.SuspendLayout();
            // 
            // StatsLayoutWindow
            // 
            this.ClientSize = new Size(284, 261);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StatsLayoutWindow";
            this.ResumeLayout(false);

        }
    }
}