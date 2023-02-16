using CefSharp;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Forms;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    public partial class GameInfoWindow : DisplayForm
    {
        public GameInfoWindow() : base()
        {
            Name = "RA Tracker - Game Info";
            Text = "RA Tracker - Game Info";
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            SetupBrowser();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            GameInfoController.Instance.IsOpen = false;
        }

        public override async void AssignJavaScriptVariables()
        {
           await ExecuteScript(
                "titleName = document.getElementById(\"title-name\");" +
                "titleValue = document.getElementById(\"title-value\");" +
                "consoleName = document.getElementById(\"console-name\");" +
                "consoleValue = document.getElementById(\"console-value\");" +
                "developerName = document.getElementById(\"developer-name\");" +
                "developerValue = document.getElementById(\"developer-value\");" +
                "publisherName = document.getElementById(\"publisher-name\");" +
                "publisherValue = document.getElementById(\"publisher-value\");" +
                "genreName = document.getElementById(\"genre-name\");" +
                "genreValue = document.getElementById(\"genre-value\");" +
                "releaseDateName = document.getElementById(\"release-date-name\");" +
                "releaseDateValue = document.getElementById(\"release-date-value\");" +
                "allElements = document.getElementsByClassName(\"has-font\");" +
                "allNames = document.getElementsByClassName(\"name\");" +
                "allValues = document.getElementsByClassName(\"value\");");
        }
        //Title
        public void SetTitleName(string value)
        {
            ExecutionScripts.Enqueue("titleName.innerHTML = \"" + value + ":\";" +
                "textFit(titleName, { alignVert: true, multiLine: true, reProcess: true });");
        }
        public void SetTitleValue(string value)
        {
            if (value != null)
            {

                if (value.Contains(", The"))
                {
                    value = "The " + value.Substring(0, value.IndexOf(", The")) + value.Substring(value.IndexOf(", The") + 5, value.Length - value.IndexOf(", The") - 5);
                }

                if (value.Contains(":"))
                {
                    value = value.Substring(0, value.IndexOf(":")) + ":<br>" + value.Substring(value.IndexOf(":") + 1, value.Length - value.IndexOf(":") - 1);
                }

                ExecutionScripts.Enqueue("titleValue.innerHTML = \"" + value + "\";" +
                "textFit(titleValue, { alignVert: true, multiLine: true, reProcess: true });");
            }
        }
        public void SetTitleVisibility(bool isVisible)
        {
            ExecutionScripts.Enqueue(isVisible ? "$(\"#title\").fadeIn();" : "$(\"#title\").fadeOut();");
        }

        //Console
        public void SetConsoleName(string value)
        {
            ExecutionScripts.Enqueue("consoleName.innerHTML = \"" + value + ":\";" +
                "textFit(consoleName, { alignVert: true, multiLine: true, reProcess: true });");
        }
        public void SetConsoleValue(string value)
        {
            if (value != null)
            {
                ExecutionScripts.Enqueue("consoleValue.innerHTML = \"" + value + "\";" +
                "textFit(consoleValue, { alignVert: true, multiLine: true, reProcess: true });");
            }
        }
        public void SetConsoleVisibility(bool isVisible)
        {
            ExecutionScripts.Enqueue(isVisible ? "$(\"#console\").fadeIn();" : "$(\"#console\").fadeOut();");
        }

        //Developer
        public void SetDeveloperName(string value)
        {
            ExecutionScripts.Enqueue("developerName.innerHTML = \"" + value + ":\";" +
                "textFit(developerName, { alignVert: true, multiLine: true, reProcess: true });");
        }
        public void SetDeveloperValue(string value)
        {
            if (value != null)
            {
                ExecutionScripts.Enqueue("developerValue.innerHTML = \"" + value + "\";" +
                "textFit(developerValue, { alignVert: true, multiLine: true, reProcess: true });");
            }
        }
        public void SetDeveloperVisibility(bool isVisible)
        {
            ExecutionScripts.Enqueue(isVisible ? "$(\"#developer\").fadeIn();" : "$(\"#developer\").fadeOut();");
        }

        //Publisher
        public void SetPublisherName(string value)
        {
            ExecutionScripts.Enqueue("publisherName.innerHTML = \"" + value + ":\";" +
                "textFit(publisherName, { alignVert: true, multiLine: true, reProcess: true });");
        }
        public void SetPublisherValue(string value)
        {
            if (value != null)
            {
                ExecutionScripts.Enqueue("publisherValue.innerHTML = \"" + value + "\";" +
                "textFit(publisherValue, { alignVert: true, multiLine: true, reProcess: true });");
            }
        }
        public void SetPublisherVisibility(bool isVisible)
        {
            ExecutionScripts.Enqueue(isVisible ? "$(\"#publisher\").fadeIn();" : "$(\"#publisher\").fadeOut();");
        }

        //Genre
        public void SetGenreName(string value)
        {
            ExecutionScripts.Enqueue("genreName.innerHTML = \"" + value + ":\";" +
                "textFit(genreName, { alignVert: true, multiLine: true, reProcess: true });");
        }
        public void SetGenreValue(string value)
        {
            if (value != null)
            {
                ExecutionScripts.Enqueue("genreValue.innerHTML = \"" + value + "\";" +
                "textFit(genreValue, { alignVert: true, multiLine: true, reProcess: true });");
            }
        }
        public void SetGenreVisibility(bool isVisible)
        {
            ExecutionScripts.Enqueue(isVisible ? "$(\"#genre\").fadeIn();" : "$(\"#genre\").fadeOut();");
        }

        //Release Date
        public void SetReleaseDateName(string value)
        {
            ExecutionScripts.Enqueue("releaseDateName.innerHTML = \"" + value + ":\";" +
                "textFit(releaseDateName, { alignVert: true, multiLine: true, reProcess: true });");
        }
        public void SetReleaseDateValue(string value)
        {
            if (value != null)
            {
                ExecutionScripts.Enqueue("releaseDateValue.innerHTML = \"" + value + "\";" +
                "textFit(releaseDateValue, { alignVert: true, multiLine: true, reProcess: true });");
            }
        }
        public void SetReleaseDateVisibility(bool isVisible)
        {
            ExecutionScripts.Enqueue(isVisible ? "$(\"#release-date\").fadeIn();" : "$(\"#release-date\").fadeOut();");
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
                "   textFit(allNames[i], { alignVert: true, multiLine: true, reProcess: true });" +
                "}");
            ExecutionScripts.Enqueue(
                "for (var i = 0; i < allValues.length; i++) { " +
                "   textFit(allValues[i], { alignVert: true, multiLine: true, reProcess: true });" +
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
                "   textFit(allNames[i], { alignVert: true, multiLine: true, reProcess: true });" +
                "}");
        }

        public void SetValueFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecutionScripts.Enqueue(
                "for (var i = 0; i < allValues.length; i++) { " +
                "   allValues[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allValues[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allValues[i], { alignVert: true, multiLine: true, reProcess: true });" +
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
        public void SetClientSize()
        {
            Invoke(new Action(() => {
                ClientSize = new Size(1190, 645);
            }));
        }
        public override void SetupBrowser()
        {
            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser()
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "gameInfoBrowser",
                Size = new Size(1376, 778),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };

            chromiumWebBrowser.LoadingStateChanged += new EventHandler<LoadingStateChangedEventArgs>((sender, loadingStateChangedEventArgs) =>
            {
                if (!loadingStateChangedEventArgs.IsLoading)
                {

                    GameInfoController.Instance.IsOpen = true;

                    GameInfoController.Instance.UpdateGameInfo();
                }
            });

            chromiumWebBrowser.LoadHtml(Resources.game_info_window);

            Controls.Add(chromiumWebBrowser);
        }
    }
}