using CefSharp;
using CefSharp.Web;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Forms
{
    public partial class GameStatsWindow : Form
    {
        public GameStatsWindow()
        {
            ClientSize = new Size(0, 0);

            Name = "RA Tracker - Game Stats";
            Text = "RA Tracker - Game Stats";

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));

            Shown += GameStatsWindow_Shown;
            FormClosed += GameStatsWindow_FormClosed;

            SetupBrowser();
        }
        private void GameStatsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            GameStatsController.IsOpen = false;
        }

        private void GameStatsWindow_Shown(object sender, EventArgs e)
        {
            GameStatsController.IsOpen = true;
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
        public void AssignJavaScriptVariables()
        {

            ExecuteScript(
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
                "   textFit(allNames[i], { alignVert: true, reProcess: true });" +
                "}");
            ExecuteScript(
                "for (var i = 0; i < allValues.length; i++) { " +
                "   textFit(allValues[i], { alignVert: true, reProcess: true });" +
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
                "   textFit(allNames[i], { alignVert: true, reProcess: true });" +
                "}");
        }

        public void SetValueFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                "for (var i = 0; i < allValues.length; i++) { " +
                "   allValues[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allValues[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allValues[i], { alignVert: true, reProcess: true });" +
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

        //Game Ratio
        public void SetGameRatioName(string value)
        {
            ExecuteScript("gameRatioName.innerHTML = \"" + value + ":\";" +
                "textFit(gameRatioName, { alignVert: true, reProcess: true });");
        }
        public void SetGameRatioValue(string value)
        {
            ExecuteScript("gameRatioValue.innerHTML = \"" + value + "\";" +
                "textFit(gameRatioValue, { alignVert: true, reProcess: true });");
        }
        public void SetGameRatioVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#game-ratio\").fadeIn();" : "$(\"#game-ratio\").fadeOut();");
        }
        //Game Points
        public void SetGamePointsName(string value)
        {
            ExecuteScript("gamePointsName.innerHTML = \"" + value + ":\";" +
                "textFit(gamePointsName, { alignVert: true, reProcess: true });");
        }
        public void SetGamePointsValue(string value)
        {
            ExecuteScript("gamePointsValue.innerHTML = \"" + value + "\";" +
                "textFit(gamePointsValue, { alignVert: true, reProcess: true });");
        }
        public void SetGamePointsVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#game-points\").fadeIn();" : "$(\"#game-points\").fadeOut();");
        }
        //Game Achievements
        public void SetGameAchievementsName(string value)
        {
            ExecuteScript("gameAchievementsName.innerHTML = \"" + value + ":\";" +
                "textFit(gameAchievementsName, { alignVert: true, reProcess: true });");
        }
        public void SetGameAchievementsValue(string value)
        {
            ExecuteScript("gameAchievementsValue.innerHTML = \"" + value + "\";" +
                "textFit(gameAchievementsValue, { alignVert: true, reProcess: true });");
        }
        public void SetGameAchievementsVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#game-achievements\").fadeIn();" : "$(\"#game-achievements\").fadeOut();");
        }
        //Game True Points
        public void SetGameTruePointsName(string value)
        {
            ExecuteScript("gameTruePointsName.innerHTML = \"" + value + ":\";" +
                "textFit(gameTruePointsName, { alignVert: true, reProcess: true });");
        }
        public void SetGameTruePointsValue(string value)
        {
            ExecuteScript("gameTruePointsValue.innerHTML = \"" + value + "\";" +
                "textFit(gameTruePointsValue, { alignVert: true, reProcess: true });");
        }
        public void SetGameTruePointsVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#game-true-points\").fadeIn();" : "$(\"#game-true-points\").fadeOut();");
        }
        //Completed
        public void SetCompletedName(string value)
        {
            ExecuteScript("completedName.innerHTML = \"" + value + ":\";" +
                "textFit(completedName, { alignVert: true, reProcess: true });");
        }
        public void SetCompletedValue(string value)
        {
            ExecuteScript("completedValue.innerHTML = \"" + value + "\";" +
                "textFit(completedValue, { alignVert: true, reProcess: true });");

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
            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.GameStatsWindow))
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
                    ClientSize = new Size(805, 350);
                });

                GameStatsController.Instance.SetAllSettings();
            });

            chromiumWebBrowser.LoadHtml(Resources.GameStatsWindow);

            Controls.Add(chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;
    }
}
