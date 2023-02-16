using CefSharp;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Forms
{
    public partial class GameProgressWindow : DisplayForm
    {
        public GameProgressWindow() : base()
        {
            Name = "RA Tracker - Game Progress";
            Text = "RA Tracker - Game Progress";
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            SetupBrowser();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            GameProgressController.Instance.IsOpen = false;
        }

        public override async void AssignJavaScriptVariables()
        {
            await ExecuteScript(
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
        public void SetSimpleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecutionScripts.Enqueue(
                "for (var i = 0; i < allElements.length; i++) { " +
                "   allElements[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allElements[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "}");
            ExecutionScripts.Enqueue(
                "for (var i = 0; i < allNames.length; i++) { " +
                "   textFit(allNames[i], { alignVert: true, reProcess: true });" +
                "}");
            ExecutionScripts.Enqueue(
                "for (var i = 0; i < allValues.length; i++) { " +
                "   textFit(allValues[i], { alignVert: true, reProcess: true });" +
                "}");
        }
        public void SetSimpleFontColor(string value)
        {
            ExecutionScripts.Enqueue("for (var i = 0; i < allElements.length; i++) { allElements[i].style.color = \"" + value + "\"; }");
        }

        public void SetSimpleFontOutline(string value)
        {
            ExecutionScripts.Enqueue("for (var i = 0; i < allElements.length; i++) { allElements[i].style.webkitTextStroke = \"" + value + "\"; }");
        }

        public void SetNameFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecutionScripts.Enqueue(
                "for (var i = 0; i < allNames.length; i++) { " +
                "   allNames[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allNames[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allNames[i], { alignVert: true, reProcess: true });" +
                "}");
        }

        public void SetValueFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecutionScripts.Enqueue(
                "for (var i = 0; i < allValues.length; i++) { " +
                "   allValues[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allValues[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allValues[i], { alignVert: true, reProcess: true });" +
                "}");
        }

        public void SetNameColor(string value)
        {
            ExecutionScripts.Enqueue("for (var i = 0; i < allNames.length; i++) { allNames[i].style.color = \"" + value + "\"; }");
        }

        public void SetValueColor(string value)
        {
            ExecutionScripts.Enqueue("for (var i = 0; i < allValues.length; i++) { allValues[i].style.color = \"" + value + "\"; }");
        }

        public void SetNameOutline(string value)
        {
            ExecutionScripts.Enqueue("for (var i = 0; i < allNames.length; i++) { allNames[i].style.webkitTextStroke = \"" + value + "\"; }");
        }

        public void SetValueOutline(string value)
        {
            ExecutionScripts.Enqueue("for (var i = 0; i < allValues.length; i++) { allValues[i].style.webkitTextStroke = \"" + value + "\"; }");
        }

        //Game Ratio
        public void SetGameRatioName(string value)
        {
            ExecutionScripts.Enqueue("gameRatioName.innerHTML = \"" + value + ":\";" +
                "textFit(gameRatioName, { alignVert: true, reProcess: true });");
        }
        public void SetGameRatioValue(string value)
        {
            ExecutionScripts.Enqueue("gameRatioValue.innerHTML = \"" + value + "\";" +
                "textFit(gameRatioValue, { alignVert: true, reProcess: true });");
        }
        public void SetGameRatioVisibility(bool isVisible)
        {
            ExecutionScripts.Enqueue(isVisible ? "$(\"#game-ratio\").fadeIn();" : "$(\"#game-ratio\").fadeOut();");
        }
        //Game Points
        public void SetGamePointsName(string value)
        {
            ExecutionScripts.Enqueue("gamePointsName.innerHTML = \"" + value + ":\";" +
                "textFit(gamePointsName, { alignVert: true, reProcess: true });");
        }
        public void SetGamePointsValue(string value)
        {
            ExecutionScripts.Enqueue("gamePointsValue.innerHTML = \"" + value + "\";" +
                "textFit(gamePointsValue, { alignVert: true, reProcess: true });");
        }
        public void SetGamePointsVisibility(bool isVisible)
        {
            ExecutionScripts.Enqueue(isVisible ? "$(\"#game-points\").fadeIn();" : "$(\"#game-points\").fadeOut();");
        }
        //Game Achievements
        public void SetGameAchievementsName(string value)
        {
            ExecutionScripts.Enqueue("gameAchievementsName.innerHTML = \"" + value + ":\";" +
                "textFit(gameAchievementsName, { alignVert: true, reProcess: true });");
        }
        public void SetGameAchievementsValue(string value)
        {
            ExecutionScripts.Enqueue("gameAchievementsValue.innerHTML = \"" + value + "\";" +
                "textFit(gameAchievementsValue, { alignVert: true, reProcess: true });");
        }
        public void SetGameAchievementsVisibility(bool isVisible)
        {
            ExecutionScripts.Enqueue(isVisible ? "$(\"#game-achievements\").fadeIn();" : "$(\"#game-achievements\").fadeOut();");
        }
        //Game True Points
        public void SetGameTruePointsName(string value)
        {
            ExecutionScripts.Enqueue("gameTruePointsName.innerHTML = \"" + value + ":\";" +
                "textFit(gameTruePointsName, { alignVert: true, reProcess: true });");
        }
        public void SetGameTruePointsValue(string value)
        {
            ExecutionScripts.Enqueue("gameTruePointsValue.innerHTML = \"" + value + "\";" +
                "textFit(gameTruePointsValue, { alignVert: true, reProcess: true });");
        }
        public void SetGameTruePointsVisibility(bool isVisible)
        {
            ExecutionScripts.Enqueue(isVisible ? "$(\"#game-true-points\").fadeIn();" : "$(\"#game-true-points\").fadeOut();");
        }
        //Completed
        public void SetCompletedName(string value)
        {
            ExecutionScripts.Enqueue("completedName.innerHTML = \"" + value + ":\";" +
                "textFit(completedName, { alignVert: true, reProcess: true });");
        }
        public void SetCompletedValue(string value)
        {
            ExecutionScripts.Enqueue("completedValue.innerHTML = \"" + value + "\";" +
                "textFit(completedValue, { alignVert: true, reProcess: true });");

        }
        public void SetCompletedVisibility(bool isVisible)
        {
            ExecutionScripts.Enqueue(isVisible ? "$(\"#game-completed\").fadeIn();" : "$(\"#game-completed\").fadeOut();");
        }
        public void SetClientSize()
        {
            Invoke(new Action(() => {
                ClientSize = new Size(805, 350);
            }));
        }
        public override void SetupBrowser()
        {
            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser()
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "gameStatsBrowser",
                Size = new Size(805, 350),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };

            chromiumWebBrowser.LoadingStateChanged += new EventHandler<LoadingStateChangedEventArgs>((sender, loadingStateChangedEventArgs) =>
            {
                if (!loadingStateChangedEventArgs.IsLoading)
                {
                    GameProgressController.Instance.IsOpen = true;

                    GameProgressController.Instance.UpdateGameProgress();
                }
            });

            chromiumWebBrowser.LoadHtml(Resources.game_progress_window);

            Controls.Add(chromiumWebBrowser);
        }
    }
}
