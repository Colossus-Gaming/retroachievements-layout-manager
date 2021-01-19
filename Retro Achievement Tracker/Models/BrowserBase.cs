using CefSharp.Web;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Models
{
    public class BrowserBase
    {
        public CefSharp.WinForms.ChromiumWebBrowser WebBrowser { get; }
        private CefSharp.WinForms.ChromiumWebBrowser _chromiumWebBrowser;

        public BrowserBase()
        {
            SetupBrowser();
        }

        private void SetupBrowser()
        {
            this._chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString("<html></html>"));
            // 
            // chromiumWebBrowser
            // 
            this._chromiumWebBrowser.ActivateBrowserOnCreation = false;
            this._chromiumWebBrowser.Location = new System.Drawing.Point(240, 0);
            this._chromiumWebBrowser.Name = "chromiumWebBrowser";
            this._chromiumWebBrowser.Size = new System.Drawing.Size(1920, 1080);
            this._chromiumWebBrowser.TabIndex = 1;
            this._chromiumWebBrowser.Dock = DockStyle.None;
            this._chromiumWebBrowser.RequestHandler = new CustomRequestHandler();
        }


    }
}
