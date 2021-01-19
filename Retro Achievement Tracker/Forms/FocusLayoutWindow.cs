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
    public partial class FocusLayoutWindow : Form
    {
        public FocusLayoutWindow()
        {
            this.ClientSize = new Size(1040, 260);
            SetupBrowser();
            this.Name = "RA Tracker - Focus";
            this.Text = "RA Tracker - Focus";
        }

        public async void SetFocus(Achievement achievement)
        {
            await ExecuteScript("setFocus(\"" + achievement.Title.Replace("\"", "\\\"") + "\"," +
                           "\"https://retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\"," +
                           "\"" + achievement.Description.Replace("\"", "\\\"") + "\"," +
                           "\"" + achievement.Points + "\");");
        }

        public async void HideFocus()
        {
            await ExecuteScript("hideFocus();");
        }
        public async void SetFontColor(string hexCode)
        {
            await ExecuteScript("setFontColor(\"" + hexCode + "\");");
        }

        public async void SetFontFamily(string fontName)
        {
            await ExecuteScript("setFontFamily(\"" + fontName + "\");");
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
            this.chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.FocusWindow))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FocusLayoutWindow));
            this.SuspendLayout();
            // 
            // FocusLayoutWindow
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FocusLayoutWindow";
            this.ResumeLayout(false);

        }
    }
}