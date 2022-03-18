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
        public async Task AssignJavaScriptVariables()
        {
            await ExecuteScript(
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
        public async void SetWindowBackgroundColor(string value)
        {
            await ExecuteScript(
                "container.style.backgroundColor = \"" + value + "\";");
        }
        //Title
        public async void SetTitleName(string value)
        {
            await ExecuteScript("titleName.innerHTML = \"" + value + ":\";" +
                "textFit(titleName, { alignVert: true });");
        }
        public async void SetTitleValue(string value)
        {
            if (value != null)
            {

                if (value.Contains(", The"))
                {
                    value = "The " + value.Substring(0, value.IndexOf(", The")) + value.Substring(value.IndexOf(", The") + 5, value.Length - value.IndexOf(", The") - 5);
                }

                await ExecuteScript("titleValue.innerHTML = \"" + value + "\";" +
                "textFit(titleValue, { alignVert: true, alignHoriz: true });");
            }
        }
        public async void SetTitleVisibility(bool isVisible)
        {
            await ExecuteScript(isVisible ? "$(\"#title\").fadeIn();" : "$(\"#title\").fadeOut();");
        }

        //Console
        public async void SetConsoleName(string value)
        {
            await ExecuteScript("consoleName.innerHTML = \"" + value + ":\";" +
                "textFit(consoleName, { alignVert: true });");
        }
        public async void SetConsoleValue(string value)
        {
            if (value != null)
            {
                await ExecuteScript("consoleValue.innerHTML = \"" + value + "\";" +
                "textFit(consoleValue, { alignVert: true, alignHoriz: true });");
            }
        }
        public async void SetConsoleVisibility(bool isVisible)
        {
            await ExecuteScript(isVisible ? "$(\"#console\").fadeIn();" : "$(\"#console\").fadeOut();");
        }

        //Developer
        public async void SetDeveloperName(string value)
        {
            await ExecuteScript("developerName.innerHTML = \"" + value + ":\";" +
                "textFit(developerName, { alignVert: true });");
        }
        public async void SetDeveloperValue(string value)
        {
            if (value != null)
            {
                await ExecuteScript("developerValue.innerHTML = \"" + value + "\";" +
                "textFit(developerValue, { alignVert: true, alignHoriz: true });");
            }
        }
        public async void SetDeveloperVisibility(bool isVisible)
        {
            await ExecuteScript(isVisible ? "$(\"#developer\").fadeIn();" : "$(\"#developer\").fadeOut();");
        }

        //Publisher
        public async void SetPublisherName(string value)
        {
            await ExecuteScript("publisherName.innerHTML = \"" + value + ":\";" +
                "textFit(publisherName, { alignVert: true });");
        }
        public async void SetPublisherValue(string value)
        {
            if (value != null)
            {
                await ExecuteScript("publisherValue.innerHTML = \"" + value + "\";" +
                "textFit(publisherValue, { alignVert: true, alignHoriz: true });");
            }
        }
        public async void SetPublisherVisibility(bool isVisible)
        {
            await ExecuteScript(isVisible ? "$(\"#publisher\").fadeIn();" : "$(\"#publisher\").fadeOut();");
        }

        //Genre
        public async void SetGenreName(string value)
        {
            await ExecuteScript("genreName.innerHTML = \"" + value + ":\";" +
                "textFit(genreName, { alignVert: true });");
        }
        public async void SetGenreValue(string value)
        {
            if (value != null)
            {
                await ExecuteScript("genreValue.innerHTML = \"" + value + "\";" +
                "textFit(genreValue, { alignVert: true, alignHoriz: true });");
            }
        }
        public async void SetGenreVisibility(bool isVisible)
        {
            await ExecuteScript(isVisible ? "$(\"#genre\").fadeIn();" : "$(\"#genre\").fadeOut();");
        }

        //Release Date
        public async void SetReleaseDateName(string value)
        {
            await ExecuteScript("releaseDateName.innerHTML = \"" + value + ":\";" +
                "textFit(releaseDateName, { alignVert: true });");
        }
        public async void SetReleaseDateValue(string value)
        {
            if (value != null)
            {
                await ExecuteScript("releaseDateValue.innerHTML = \"" + value + "\";" +
                "textFit(releaseDateValue, { alignVert: true, alignHoriz: true });");
            }
        }
        public async void SetReleaseDateVisibility(bool isVisible)
        {
            await ExecuteScript(isVisible ? "$(\"#release-date\").fadeIn();" : "$(\"#release-date\").fadeOut();");
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
                "   textFit(allValues[i], { alignVert: true, alignHoriz: true });" +
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
                "   textFit(allValues[i], { alignVert: true, alignHoriz: true });" +
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
                    ClientSize = new Size(1020, 419);
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