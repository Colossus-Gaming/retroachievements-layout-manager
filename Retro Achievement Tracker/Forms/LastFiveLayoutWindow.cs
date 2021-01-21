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
    public partial class LastFiveLayoutWindow : Form
    {
        public LastFiveLayoutWindow()
        {
            this.ClientSize = new Size(1000, 300);
            SetupBrowser();
            this.Name = "RA Tracker - Last Five Achievements";
            this.Text = "RA Tracker - Last Five Achievements";
        }
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

        public async void SetBackgroundColor(string hexCode)
        {
            await ExecuteScript("setBackgroundColor(\"" + hexCode + "\");");
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
            this.chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.LastFive))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LastFiveLayoutWindow));
            this.SuspendLayout();
            // 
            // LastFiveLayoutWindow
            // 
            this.ClientSize = new Size(284, 261);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LastFiveLayoutWindow";
            this.ResumeLayout(false);

        }
    }
}