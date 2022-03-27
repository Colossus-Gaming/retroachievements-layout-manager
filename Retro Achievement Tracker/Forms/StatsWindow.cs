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

            Shown += StatsWindow_Shown;
            FormClosed += StatsWindow_FormClosed;

            SetupBrowser();
        }

        private void StatsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            StatsController.IsOpen = false;
        }

        private void StatsWindow_Shown(object sender, EventArgs e)
        {
            StatsController.IsOpen = true;
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
        public void AssignJavaScriptVariables()
        {

            ExecuteScript(
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
        public void SetWindowBackgroundColor(string value)
        {
            ExecuteScript(
                "container.style.backgroundColor = \"" + value + "\";");
        }
        public void SetSimpleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                "for (var i = 0; i < allElements.length; i++) { " +
                "   allElements[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allElements[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "}");
            ExecuteScript(
                "for (var i = 0; i < allNames.length; i++) { " +
                "   textFit(allNames[i], { alignVert: true });" +
                "}");
            ExecuteScript(
                "for (var i = 0; i < allValues.length; i++) { " +
                "   textFit(allValues[i], { alignVert: true });" +
                "}");
        }
        public void SetSimpleFontColor(string value)
        {
            ExecuteScript(
                "for (var i = 0; i < allElements.length; i++) { allElements[i].style.color = \"" + value + "\"; }");
        }

        public void SetSimpleFontOutline(string value)
        {
            ExecuteScript(
               "for (var i = 0; i < allElements.length; i++) { allElements[i].style.webkitTextStroke = \"" + value + "\"; }");
        }

        public void SetNameFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                "for (var i = 0; i < allNames.length; i++) { " +
                "   allNames[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allNames[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allNames[i], { alignVert: true });" +
                "}");
        }

        public void SetValueFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                "for (var i = 0; i < allValues.length; i++) { " +
                "   allValues[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allValues[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allValues[i], { alignVert: true });" +
                "}");
        }

        public void SetNameColor(string value)
        {
            ExecuteScript(
                 "for (var i = 0; i < allNames.length; i++) { allNames[i].style.color = \"" + value + "\"; }");
        }

        public void SetValueColor(string value)
        {
            ExecuteScript(
                 "for (var i = 0; i < allValues.length; i++) { allValues[i].style.color = \"" + value + "\"; }");
        }

        public void SetNameOutline(string value)
        {
            ExecuteScript(
                  "for (var i = 0; i < allNames.length; i++) { allNames[i].style.webkitTextStroke = \"" + value + "\"; }");
        }

        public void SetValueOutline(string value)
        {
            ExecuteScript(
                  "for (var i = 0; i < allValues.length; i++) { allValues[i].style.webkitTextStroke = \"" + value + "\"; }");
        }
        public void SetRankName(string value)
        {
            ExecuteScript("rankName.innerHTML = \"" + value + ":\";" +
                "textFit(rankName, { alignVert: true });");
        }
        public void SetRankValue(string value)
        {
            ExecuteScript("rankValue.innerHTML = \"" + value + "\";" +
                "textFit(rankValue, { alignVert: true });");
        }
        public void SetRankVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#rank\").fadeIn();" : "$(\"#rank\").fadeOut();");
        }
        //Awards
        public void SetAwardsName(string value)
        {
            ExecuteScript("awardsName.innerHTML = \"" + value + ":\";" +
                "textFit(awardsName, { alignVert: true });");
        }
        public void SetAwardsValue(string value)
        {
            ExecuteScript("awardsValue.innerHTML = " + value + ";" +
                "textFit(awardsValue, { alignVert: true });");
        }
        public void SetAwardsVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#awards\").fadeIn();" : "$(\"#awards\").fadeOut();");
        }
        //Points
        public void SetPointsName(string value)
        {
            ExecuteScript("pointsName.innerHTML = \"" + value + ":\";" +
                "textFit(pointsName, { alignVert: true });");
        }
        public void SetPointsValue(string value)
        {
            ExecuteScript("pointsValue.innerHTML = \"" + value + "\";" +
                "textFit(pointsValue, { alignVert: true });");
        }
        public void SetPointsVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#points\").fadeIn();" : "$(\"#points\").fadeOut();");
        }
        //True Points
        public void SetTruePointsName(string value)
        {
            ExecuteScript("truePointsName.innerHTML = \"" + value + ":\";" +
                "textFit(truePointsName, { alignVert: true });");
        }
        public void SetTruePointsValue(string value)
        {
            ExecuteScript("truePointsValue.innerHTML = \"" + value + "\";" +
                "textFit(truePointsValue, { alignVert: true });");
        }
        public void SetTruePointsVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#true-points\").fadeIn();" : "$(\"#true-points\").fadeOut();");
        }
        //Ratio
        public void SetRatioName(string value)
        {
            ExecuteScript("ratioName.innerHTML = \"" + value + ":\";" +
                "textFit(ratioName, { alignVert: true });");
        }
        public void SetRatioValue(string value)
        {
            ExecuteScript("ratioValue.innerHTML = \"" + value + "\";" +
                "textFit(ratioValue, { alignVert: true });");
        }
        public void SetRatioVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#ratio\").fadeIn();" : "$(\"#ratio\").fadeOut();");
        }
        //Game Ratio
        public void SetGameRatioName(string value)
        {
            ExecuteScript("gameRatioName.innerHTML = \"" + value + ":\";" +
                "textFit(gameRatioName, { alignVert: true });");
        }
        public void SetGameRatioValue(string value)
        {
            ExecuteScript("gameRatioValue.innerHTML = \"" + value + "\";" +
                "textFit(gameRatioValue, { alignVert: true });");
        }
        public void SetGameRatioVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#game-ratio\").fadeIn();" : "$(\"#game-ratio\").fadeOut();");
        }
        //Game Points
        public void SetGamePointsName(string value)
        {
            ExecuteScript("gamePointsName.innerHTML = \"" + value + ":\";" +
                "textFit(gamePointsName, { alignVert: true });");
        }
        public void SetGamePointsValue(string value)
        {
            ExecuteScript("gamePointsValue.innerHTML = \"" + value + "\";" +
                "textFit(gamePointsValue, { alignVert: true });");
        }
        public void SetGamePointsVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#game-points\").fadeIn();" : "$(\"#game-points\").fadeOut();");
        }
        //Game Achievements
        public void SetGameAchievementsName(string value)
        {
            ExecuteScript("gameAchievementsName.innerHTML = \"" + value + ":\";" +
                "textFit(gameAchievementsName, { alignVert: true });");
        }
        public void SetGameAchievementsValue(string value)
        {
            ExecuteScript("gameAchievementsValue.innerHTML = \"" + value + "\";" +
                "textFit(gameAchievementsValue, { alignVert: true });");
        }
        public void SetGameAchievementsVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#game-achievements\").fadeIn();" : "$(\"#game-achievements\").fadeOut();");
        }
        //Game True Points
        public void SetGameTruePointsName(string value)
        {
            ExecuteScript("gameTruePointsName.innerHTML = \"" + value + ":\";" +
                "textFit(gameTruePointsName, { alignVert: true });");
        }
        public void SetGameTruePointsValue(string value)
        {
            ExecuteScript("gameTruePointsValue.innerHTML = \"" + value + "\";" +
                "textFit(gameTruePointsValue, { alignVert: true });");
        }
        public void SetGameTruePointsVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#game-true-points\").fadeIn();" : "$(\"#game-true-points\").fadeOut();");
        }
        //Completed
        public void SetCompletedName(string value)
        {
            ExecuteScript("completedName.innerHTML = \"" + value + ":\";" +
                "textFit(completedName, { alignVert: true });");
        }
        public void SetCompletedValue(string value)
        {
            ExecuteScript("completedValue.innerHTML = \"" + value + "\";" +
                "textFit(completedValue, { alignVert: true });");

        }
        public void SetCompletedVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#game-completed\").fadeIn();" : "$(\"#game-completed\").fadeOut();");
        }
        protected async void ExecuteScript(string script)
        {
            if (chromiumWebBrowser != null)
            {
                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
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