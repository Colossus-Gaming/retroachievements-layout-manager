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
    public partial class GameInfoWindow : Form
    {
        public GameInfoWindow()
        {
            Name = "RA Tracker - Game Info";
            Text = "RA Tracker - Game Info";

            ClientSize = new Size(0, 0);

            Shown += GameInfoWindow_Shown;
            FormClosed += GameInfoWindow_FormClosed;

            SetupBrowser();
        }

        private void GameInfoWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            GameInfoController.IsOpen = false;
        }

        private void GameInfoWindow_Shown(object sender, EventArgs e)
        {
            GameInfoController.IsOpen = true;
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
        public void AssignJavaScriptVariables()
        {
            ExecuteScript(
                "container = document.getElementById(\"container\");" +
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
        public void SetWindowBackgroundColor(string value)
        {
            ExecuteScript(
                "container.style.backgroundColor = \"" + value + "\";");
        }
        //Title
        public void SetTitleName(string value)
        {
            ExecuteScript("titleName.innerHTML = \"" + value + ":\";" +
                "textFit(titleName, { alignVert: true });");
        }
        public void SetTitleValue(string value)
        {
            if (value != null)
            {

                if (value.Contains(", The"))
                {
                    value = "The " + value.Substring(0, value.IndexOf(", The")) + value.Substring(value.IndexOf(", The") + 5, value.Length - value.IndexOf(", The") - 5);
                }

                ExecuteScript("titleValue.innerHTML = \"" + value + "\";" +
                "textFit(titleValue, { alignVert: true });");
            }
        }
        public void SetTitleVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#title\").fadeIn();" : "$(\"#title\").fadeOut();");
        }

        //Console
        public void SetConsoleName(string value)
        {
            ExecuteScript("consoleName.innerHTML = \"" + value + ":\";" +
                "textFit(consoleName, { alignVert: true });");
        }
        public void SetConsoleValue(string value)
        {
            if (value != null)
            {
                ExecuteScript("consoleValue.innerHTML = \"" + value + "\";" +
                "textFit(consoleValue, { alignVert: true });");
            }
        }
        public void SetConsoleVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#console\").fadeIn();" : "$(\"#console\").fadeOut();");
        }

        //Developer
        public void SetDeveloperName(string value)
        {
            ExecuteScript("developerName.innerHTML = \"" + value + ":\";" +
                "textFit(developerName, { alignVert: true });");
        }
        public void SetDeveloperValue(string value)
        {
            if (value != null)
            {
                ExecuteScript("developerValue.innerHTML = \"" + value + "\";" +
                "textFit(developerValue, { alignVert: true });");
            }
        }
        public void SetDeveloperVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#developer\").fadeIn();" : "$(\"#developer\").fadeOut();");
        }

        //Publisher
        public void SetPublisherName(string value)
        {
            ExecuteScript("publisherName.innerHTML = \"" + value + ":\";" +
                "textFit(publisherName, { alignVert: true });");
        }
        public void SetPublisherValue(string value)
        {
            if (value != null)
            {
                ExecuteScript("publisherValue.innerHTML = \"" + value + "\";" +
                "textFit(publisherValue, { alignVert: true });");
            }
        }
        public void SetPublisherVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#publisher\").fadeIn();" : "$(\"#publisher\").fadeOut();");
        }

        //Genre
        public void SetGenreName(string value)
        {
            ExecuteScript("genreName.innerHTML = \"" + value + ":\";" +
                "textFit(genreName, { alignVert: true });");
        }
        public void SetGenreValue(string value)
        {
            if (value != null)
            {
                ExecuteScript("genreValue.innerHTML = \"" + value + "\";" +
                "textFit(genreValue, { alignVert: true });");
            }
        }
        public void SetGenreVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#genre\").fadeIn();" : "$(\"#genre\").fadeOut();");
        }

        //Release Date
        public void SetReleaseDateName(string value)
        {
            ExecuteScript("releaseDateName.innerHTML = \"" + value + ":\";" +
                "textFit(releaseDateName, { alignVert: true });");
        }
        public void SetReleaseDateValue(string value)
        {
            if (value != null)
            {
                ExecuteScript("releaseDateValue.innerHTML = \"" + value + "\";" +
                "textFit(releaseDateValue, { alignVert: true });");
            }
        }
        public void SetReleaseDateVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#release-date\").fadeIn();" : "$(\"#release-date\").fadeOut();");
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
            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.GameInfoWindow))
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
                    ClientSize = new Size(1020, 426);
                });

                GameInfoController.Instance.SetAllSettings();
            });
            Controls.Add(chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameInfoWindow));
            this.SuspendLayout();
            // 
            // GameInfoWindow
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameInfoWindow";
            this.ResumeLayout(false);

        }
    }
}