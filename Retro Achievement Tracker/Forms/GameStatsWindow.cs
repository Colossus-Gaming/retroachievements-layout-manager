using CefSharp;
using CefSharp.Web;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Forms
{
    public partial class GameStatsWindow : Form
    {
        private TaskController TaskController;
        public GameStatsWindow()
        {
            ClientSize = new Size(0, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            Name = "RA Tracker - Game Stats";
            Text = "RA Tracker - Game Stats";

            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainWindow));
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));

            Shown += GameStatsWindow_Shown;
            FormClosed += GameStatsWindow_FormClosed;

            TaskController = new TaskController();

            SetupBrowser();
        }
        private void GameStatsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            GameProgressController.Instance.IsOpen = false;
        }

        private void GameStatsWindow_Shown(object sender, EventArgs e)
        {
            GameProgressController.Instance.IsOpen = true;
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
        public async void AssignJavaScriptVariables()
        {

            await TaskController.Enqueue(() => ExecuteScript(
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
                "allValues = document.getElementsByClassName(\"value\");"));
        }
        public async void SetWindowBackgroundColor(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript("container.style.backgroundColor = \"" + value + "\";"));
        }
        public async void SetSimpleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            await TaskController.Enqueue(() => ExecuteScript(
                "for (var i = 0; i < allElements.length; i++) { " +
                "   allElements[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allElements[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "}"));
            await TaskController.Enqueue(() => ExecuteScript(
                "for (var i = 0; i < allNames.length; i++) { " +
                "   textFit(allNames[i], { alignVert: true, reProcess: true });" +
                "}"));
            await TaskController.Enqueue(() => ExecuteScript(
                "for (var i = 0; i < allValues.length; i++) { " +
                "   textFit(allValues[i], { alignVert: true, reProcess: true });" +
                "}"));
        }
        public async void SetSimpleFontColor(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript("for (var i = 0; i < allElements.length; i++) { allElements[i].style.color = \"" + value + "\"; }"));
        }

        public async void SetSimpleFontOutline(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript("for (var i = 0; i < allElements.length; i++) { allElements[i].style.webkitTextStroke = \"" + value + "\"; }"));
        }

        public async void SetNameFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            await TaskController.Enqueue(() => ExecuteScript(
                "for (var i = 0; i < allNames.length; i++) { " +
                "   allNames[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allNames[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allNames[i], { alignVert: true, reProcess: true });" +
                "}"));
        }

        public async void SetValueFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            await TaskController.Enqueue(() => ExecuteScript(
                "for (var i = 0; i < allValues.length; i++) { " +
                "   allValues[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allValues[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allValues[i], { alignVert: true, reProcess: true });" +
                "}"));
        }

        public async void SetNameColor(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript("for (var i = 0; i < allNames.length; i++) { allNames[i].style.color = \"" + value + "\"; }"));
        }

        public async void SetValueColor(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript("for (var i = 0; i < allValues.length; i++) { allValues[i].style.color = \"" + value + "\"; }"));
        }

        public async void SetNameOutline(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript("for (var i = 0; i < allNames.length; i++) { allNames[i].style.webkitTextStroke = \"" + value + "\"; }"));
        }

        public async void SetValueOutline(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript("for (var i = 0; i < allValues.length; i++) { allValues[i].style.webkitTextStroke = \"" + value + "\"; }"));
        }

        //Game Ratio
        public async void SetGameRatioName(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript("gameRatioName.innerHTML = \"" + value + ":\";" +
                "textFit(gameRatioName, { alignVert: true, reProcess: true });"));
        }
        public async void SetGameRatioValue(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript("gameRatioValue.innerHTML = \"" + value + "\";" +
                "textFit(gameRatioValue, { alignVert: true, reProcess: true });"));
        }
        public async void SetGameRatioVisibility(bool isVisible)
        {
            await TaskController.Enqueue(() => ExecuteScript(isVisible ? "$(\"#game-ratio\").fadeIn();" : "$(\"#game-ratio\").fadeOut();"));
        }
        //Game Points
        public async void SetGamePointsName(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript("gamePointsName.innerHTML = \"" + value + ":\";" +
                "textFit(gamePointsName, { alignVert: true, reProcess: true });"));
        }
        public async void SetGamePointsValue(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript("gamePointsValue.innerHTML = \"" + value + "\";" +
                "textFit(gamePointsValue, { alignVert: true, reProcess: true });"));
        }
        public async void SetGamePointsVisibility(bool isVisible)
        {
            await TaskController.Enqueue(() => ExecuteScript(isVisible ? "$(\"#game-points\").fadeIn();" : "$(\"#game-points\").fadeOut();"));
        }
        //Game Achievements
        public async void SetGameAchievementsName(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript("gameAchievementsName.innerHTML = \"" + value + ":\";" +
                "textFit(gameAchievementsName, { alignVert: true, reProcess: true });"));
        }
        public async void SetGameAchievementsValue(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript("gameAchievementsValue.innerHTML = \"" + value + "\";" +
                "textFit(gameAchievementsValue, { alignVert: true, reProcess: true });"));
        }
        public async void SetGameAchievementsVisibility(bool isVisible)
        {
            await TaskController.Enqueue(() => ExecuteScript(isVisible ? "$(\"#game-achievements\").fadeIn();" : "$(\"#game-achievements\").fadeOut();"));
        }
        //Game True Points
        public async void SetGameTruePointsName(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript("gameTruePointsName.innerHTML = \"" + value + ":\";" +
                "textFit(gameTruePointsName, { alignVert: true, reProcess: true });"));
        }
        public async void SetGameTruePointsValue(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript("gameTruePointsValue.innerHTML = \"" + value + "\";" +
                "textFit(gameTruePointsValue, { alignVert: true, reProcess: true });"));
        }
        public async void SetGameTruePointsVisibility(bool isVisible)
        {
            await TaskController.Enqueue(() => ExecuteScript(isVisible ? "$(\"#game-true-points\").fadeIn();" : "$(\"#game-true-points\").fadeOut();"));
        }
        //Completed
        public async void SetCompletedName(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript("completedName.innerHTML = \"" + value + ":\";" +
                "textFit(completedName, { alignVert: true, reProcess: true });"));
        }
        public async void SetCompletedValue(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript("completedValue.innerHTML = \"" + value + "\";" +
                "textFit(completedValue, { alignVert: true, reProcess: true });"));

        }
        public async void SetCompletedVisibility(bool isVisible)
        {
            await TaskController.Enqueue(() => ExecuteScript(isVisible ? "$(\"#game-completed\").fadeIn();" : "$(\"#game-completed\").fadeOut();"));
        }
        protected async Task ExecuteScript(string script)
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

                GameProgressController.Instance.IsOpen = true;
                GameProgressController.Instance.SetAllSettings();
            });

            Controls.Add(chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;
    }
}
