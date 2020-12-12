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
    public partial class GameInfoLayoutWindow : Form
    {
        public GameInfoLayoutWindow()
        {
            this.ClientSize = new Size(1366, 700);
            SetupBrowser();
            this.Name = "RA Tracker - Game Info";
            this.Text = "RA Tracker - Game Info";
        }
        //Title
        public async void SetTitleName(string titleName)
        {
            await ExecuteScript("setTitleName('" + titleName.Replace("'", "\\'") + ":');");
        }
        public async void SetTitleValue(string titleValue)
        {
            await ExecuteScript("setTitleValue('" + titleValue.Replace("'", "\\'") + "');");
        }
        public async void ShowTitle()
        {
            await ExecuteScript("showTitle();");
        }
        public async void HideTitle()
        {
            await ExecuteScript("hideTitle();");
        }

        //Console
        public async void SetConsoleName(string consoleName)
        {
            await ExecuteScript("setConsoleName('" + consoleName.Replace("'", "\\'") + ":');");
        }
        public async void SetConsoleValue(string consoleValue)
        {
            await ExecuteScript("setConsoleValue('" + consoleValue.Replace("'", "\\'") + "');");
        }
        public async void ShowConsole()
        {
            await ExecuteScript("showConsole();");
        }
        public async void HideConsole()
        {
            await ExecuteScript("hideConsole();");
        }

        //Developer
        public async void SetDeveloperName(string developerName)
        {
            await ExecuteScript("setDeveloperName('" + developerName.Replace("'", "\\'") + ":');");
        }
        public async void SetDeveloperValue(string developerValue)
        {
            await ExecuteScript("setDeveloperValue('" + developerValue.Replace("'", "\\'") + "');");
        }
        public async void ShowDeveloper()
        {
            await ExecuteScript("showDeveloper();");
        }
        public async void HideDeveloper()
        {
            await ExecuteScript("hideDeveloper();");
        }

        //Publisher
        public async void SetPublisherName(string publisherName)
        {
            await ExecuteScript("setPublisherName('" + publisherName.Replace("'", "\\'") + ":');");
        }
        public async void SetPublisherValue(string publisherValue)
        {
            await ExecuteScript("setPublisherValue('" + publisherValue.Replace("'", "\\'") + "');");
        }
        public async void ShowPublisher()
        {
            await ExecuteScript("showPublisher();");
        }
        public async void HidePublisher()
        {
            await ExecuteScript("hidePublisher();");
        }

        //Genre
        public async void SetGenreName(string genreName)
        {
            await ExecuteScript("setGenreName('" + genreName.Replace("'", "\\'") + ":');");
        }        
        public async void SetGenreValue(string genreValue)
        {
            await ExecuteScript("setGenreValue('" + genreValue.Replace("'", "\\'") + "');");
        }        
        public async void ShowGenre()
        {
            await ExecuteScript("showGenre();");
        }
        public async void HideGenre()
        {
            await ExecuteScript("hideGenre();");
        }

        //Release Date
        public async void SetReleaseDateName(string releaseDateName)
        {
            await ExecuteScript("setReleaseDateName('" + releaseDateName.Replace("'", "\\'") + ":');");
        }
        public async void SetReleaseDateValue(string releaseDateValue)
        {
            await ExecuteScript("setReleaseDateValue('" + releaseDateValue.Replace("'", "\\'") + "');");
        }
        public async void ShowReleaseDate()
        {
            await ExecuteScript("showReleaseDate();");
        }
        public async void HideReleaseDate()
        {
            await ExecuteScript("hideReleaseDate();");
        }

        //Box Art
        public async void SetBoxArt(string boxArtLink)
        {
            await ExecuteScript("setBoxArt('" + boxArtLink + "');");
        }
        public async void ShowBoxArt()
        {
            await ExecuteScript("showBoxArt();");
        }
        public async void HideBoxArt()
        {
            await ExecuteScript("hideBoxArt();");
        }

        //Fonts
        public async void SetFontFamily(string fontName)
        {
            await ExecuteScript("setFontFamily(\"" + fontName.Replace("'", "\\'") + "\");");
        }
        public async void SetFontColor(string hexCode)
        {
            await ExecuteScript("setFontColor(\"" + hexCode + "\");");
        }
        public async void SetFontOutline(string hexCode, int size)
        {
            await ExecuteScript("setFontOutline(\"" + hexCode + " " + size + "px\");");
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
            this.chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.GameInfo))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameInfoLayoutWindow));
            this.SuspendLayout();
            // 
            // GameInfoLayoutWindow
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameInfoLayoutWindow";
            this.ResumeLayout(false);

        }
    }
}