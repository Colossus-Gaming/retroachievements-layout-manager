using CefSharp;
using CefSharp.Web;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    public partial class StatsWindow : Form
    {
        public StatsWindow()
        {
            ClientSize = new Size(0, 0);

            Name = "RA Tracker - Stats";
            Text = "RA Tracker - Stats";
        }
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
        public async Task AssignJavaScriptVariables()
        {

            await ExecuteScript(
                "container = document.getElementById(\"container\");" +
                "rankName = document.getElementById(\"rank-name\");" +
                "rankValue = document.getElementById(\"rank-value\");" +
                "awardsName = document.getElementById(\"awards-name\");" +
                "awardsValue = document.getElementById(\"awards-value\");" +
                "ratioName = document.getElementById(\"ratio-name\");" +
                "ratioValue = document.getElementById(\"ratio-value\");" +
                "pointsName = document.getElementById(\"points-name\");" +
                "pointsValue = document.getElementById(\"points-value\");" +
                "truePointsName = document.getElementById(\"true-points-name\");" +
                "truePointsValue = document.getElementById(\"true-points-value\");" +
                "gameRatioName = document.getElementById(\"game-ratio-name\");" +
                "gameRatioValue = document.getElementById(\"game-ratio-value\");" +
                "completedName = document.getElementById(\"game-completed-name\");" +
                "completedValue = document.getElementById(\"game-completed-value\");" +
                "gameAchievementsName = document.getElementById(\"game-achievements-name\");" +
                "gameAchievementsValue = document.getElementById(\"game-achievements-value\");" +
                "gamePointsName = document.getElementById(\"game-points-name\");" +
                "gamePointsValue = document.getElementById(\"game-points-value\");" +
                "gameTruePointsName = document.getElementById(\"game-true-points-name\");" +
                "gameTruePointsValue = document.getElementById(\"game-true-points-value\");" +
                "allElements = document.getElementsByClassName(\"has-font\");" +
                "allNames = document.getElementsByClassName(\"name\");" +
                "allValues = document.getElementsByClassName(\"value\");");
        }
        public async void SetWindowBackgroundColor(string value)
        {
            await ExecuteScript(
                "container.style.backgroundColor = \"" + value + "\";");
        }
        public async Task SetSimpleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            await ExecuteScript(
                "for (var i = 0; i < allElements.length; i++) { " +
                "   allElements[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allElements[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "}");
            await ExecuteScript(
                "for (var i = 0; i < allNames.length; i++) { " +
                "   textFit(allNames[i], { alignVert: true });" +
                "}");
            await ExecuteScript(
                "for (var i = 0; i < allValues.length; i++) { " +
                "   textFit(allValues[i], { alignVert: true });" +
                "}");
        }
        public async Task SetSimpleFontColor(string value)
        {
            await ExecuteScript(
                "for (var i = 0; i < allElements.length; i++) { allElements[i].style.color = \"" + value + "\"; }");
        }

        public async Task SetSimpleFontOutline(string value)
        {
            await ExecuteScript(
               "for (var i = 0; i < allElements.length; i++) { allElements[i].style.webkitTextStroke = \"" + value + "\"; }");
        }

        public async Task SetNameFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            await ExecuteScript(
                "for (var i = 0; i < allNames.length; i++) { " +
                "   allNames[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allNames[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allNames[i], { alignVert: true });" +
                "}");
        }

        public async Task SetValueFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            await ExecuteScript(
                "for (var i = 0; i < allValues.length; i++) { " +
                "   allValues[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allValues[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allValues[i], { alignVert: true });" +
                "}");
        }

        public async Task SetNameColor(string value)
        {
            await ExecuteScript(
                 "for (var i = 0; i < allNames.length; i++) { allNames[i].style.color = \"" + value + "\"; }");
        }

        public async Task SetValueColor(string value)
        {
            await ExecuteScript(
                 "for (var i = 0; i < allValues.length; i++) { allValues[i].style.color = \"" + value + "\"; }");
        }

        public async Task SetNameOutline(string value)
        {
            await ExecuteScript(
                  "for (var i = 0; i < allNames.length; i++) { allNames[i].style.webkitTextStroke = \"" + value + "\"; }");
        }

        public async Task SetValueOutline(string value)
        {
            await ExecuteScript(
                  "for (var i = 0; i < allValues.length; i++) { allValues[i].style.webkitTextStroke = \"" + value + "\"; }");
        }
        public async void SetRankName(string value)
        {
            await ExecuteScript("rankName.innerHTML = \"" + value + ":\";" +
                "textFit(rankName, { alignVert: true });");
        }
        public async void SetRankValue(string value)
        {
            await ExecuteScript("rankValue.innerHTML = \"" + value + "\";" +
                "textFit(rankValue, { alignVert: true });");
        }
        public async void SetRankVisibility(bool isVisible)
        {
            await ExecuteScript(isVisible ? "$(\"#rank\").fadeIn();" : "$(\"#rank\").fadeOut();");
        }
        //Awards
        public async void SetAwardsName(string value)
        {
            await ExecuteScript("awardsName.innerHTML = \"" + value + ":\";" +
                "textFit(awardsName, { alignVert: true });");
        }
        public async void SetAwardsValue(string value)
        {
            await ExecuteScript("awardsValue.innerHTML = " + value + ";" +
                "textFit(awardsValue, { alignVert: true });");
        }
        public async void SetAwardsVisibility(bool isVisible)
        {
            await ExecuteScript(isVisible ? "$(\"#awards\").fadeIn();" : "$(\"#awards\").fadeOut();");
        }
        //Points
        public async void SetPointsName(string value)
        {
            await ExecuteScript("pointsName.innerHTML = \"" + value + ":\";" +
                "textFit(pointsName, { alignVert: true });");
        }
        public async void SetPointsValue(string value)
        {
            await ExecuteScript("pointsValue.innerHTML = \"" + value + "\";" +
                "textFit(pointsValue, { alignVert: true });");
        }
        public async void SetPointsVisibility(bool isVisible)
        {
            await ExecuteScript(isVisible ? "$(\"#points\").fadeIn();" : "$(\"#points\").fadeOut();");
        }
        //True Points
        public async void SetTruePointsName(string value)
        {
            await ExecuteScript("truePointsName.innerHTML = \"" + value + ":\";" +
                "textFit(truePointsName, { alignVert: true });");
        }
        public async void SetTruePointsValue(string value)
        {
            await ExecuteScript("truePointsValue.innerHTML = \"" + value + "\";" +
                "textFit(truePointsValue, { alignVert: true });");
        }
        public async void SetTruePointsVisibility(bool isVisible)
        {
            await ExecuteScript(isVisible ? "$(\"#true-points\").fadeIn();" : "$(\"#true-points\").fadeOut();");
        }
        //Ratio
        public async void SetRatioName(string value)
        {
            await ExecuteScript("ratioName.innerHTML = \"" + value + ":\";" +
                "textFit(ratioName, { alignVert: true });");
        }
        public async void SetRatioValue(string value)
        {
            await ExecuteScript("ratioValue.innerHTML = \"" + value + "\";" +
                "textFit(ratioValue, { alignVert: true });");
        }
        public async void SetRatioVisibility(bool isVisible)
        {
            await ExecuteScript(isVisible ? "$(\"#ratio\").fadeIn();" : "$(\"#ratio\").fadeOut();");
        }
        //Game Ratio
        public async void SetGameRatioName(string value)
        {
            await ExecuteScript("gameRatioName.innerHTML = \"" + value + ":\";" +
                "textFit(gameRatioName, { alignVert: true });");
        }
        public async void SetGameRatioValue(string value)
        {
            await ExecuteScript("gameRatioValue.innerHTML = \"" + value + "\";" +
                "textFit(gameRatioValue, { alignVert: true });");
        }
        public async void SetGameRatioVisibility(bool isVisible)
        {
            await ExecuteScript(isVisible ? "$(\"#game-ratio\").fadeIn();" : "$(\"#game-ratio\").fadeOut();");
        }
        //Game Points
        public async void SetGamePointsName(string value)
        {
            await ExecuteScript("gamePointsName.innerHTML = \"" + value + ":\";" +
                "textFit(gamePointsName, { alignVert: true });");
        }
        public async void SetGamePointsValue(string value)
        {
            await ExecuteScript("gamePointsValue.innerHTML = \"" + value + "\";" +
                "textFit(gamePointsValue, { alignVert: true });");
        }
        public async void SetGamePointsVisibility(bool isVisible)
        {
            await ExecuteScript(isVisible ? "$(\"#game-points\").fadeIn();" : "$(\"#game-points\").fadeOut();");
        }
        //Game Achievements
        public async void SetGameAchievementsName(string value)
        {
            await ExecuteScript("gameAchievementsName.innerHTML = \"" + value + ":\";" +
                "textFit(gameAchievementsName, { alignVert: true });");
        }
        public async void SetGameAchievementsValue(string value)
        {
            await ExecuteScript("gameAchievementsValue.innerHTML = \"" + value + "\";" +
                "textFit(gameAchievementsValue, { alignVert: true });");
        }
        public async void SetGameAchievementsVisibility(bool isVisible)
        {
            await ExecuteScript(isVisible ? "$(\"#game-achievements\").fadeIn();" : "$(\"#game-achievements\").fadeOut();");
        }
        //Game True Points
        public async void SetGameTruePointsName(string value)
        {
            await ExecuteScript("gameTruePointsName.innerHTML = \"" + value + ":\";" +
                "textFit(gameTruePointsName, { alignVert: true });");
        }
        public async void SetGameTruePointsValue(string value)
        {
            await ExecuteScript("gameTruePointsValue.innerHTML = \"" + value + "\";" +
                "textFit(gameTruePointsValue, { alignVert: true });");
        }
        public async void SetGameTruePointsVisibility(bool isVisible)
        {
            await ExecuteScript(isVisible ? "$(\"#game-true-points\").fadeIn();" : "$(\"#game-true-points\").fadeOut();");
        }
        //Completed
        public async void SetCompletedName(string value)
        {
            await ExecuteScript("completedName.innerHTML = \"" + value + ":\";" +
                "textFit(completedName, { alignVert: true });");
        }
        public async void SetCompletedValue(string value)
        {
            await ExecuteScript("completedValue.innerHTML = \"" + value + "\";" +
                "textFit(completedValue, { alignVert: true });");

        }
        public async void SetCompletedVisibility(bool isVisible)
        {
            await ExecuteScript(isVisible ? "$(\"#game-completed\").fadeIn();" : "$(\"#game-completed\").fadeOut();");
        }
        protected async Task ExecuteScript(string script)
        {
            if (chromiumWebBrowser != null)
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
        public void SetupBrowser()
        {
            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.StatsWindow))
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "chromiumWebBrowser",
                Size = new Size(1034, 778),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };

            chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                Invoke((MethodInvoker)delegate
                {
                    ClientSize = new Size(805, 735);
                });

                StatsController.Instance.SetAllSettings();
            });

            chromiumWebBrowser.LoadHtml(Resources.StatsWindow);

            Controls.Add(chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatsWindow));
            this.SuspendLayout();
            // 
            // StatsWindow
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StatsWindow";
            this.ResumeLayout(false);

        }
    }
}