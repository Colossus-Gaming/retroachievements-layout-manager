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
            _chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString("<html></html>"));
            // 
            // chromiumWebBrowser
            // 
            _chromiumWebBrowser.ActivateBrowserOnCreation = false;
            _chromiumWebBrowser.Location = new System.Drawing.Point(240, 0);
            _chromiumWebBrowser.Name = "chromiumWebBrowser";
            _chromiumWebBrowser.Size = new System.Drawing.Size(1920, 1080);
            _chromiumWebBrowser.TabIndex = 1;
            _chromiumWebBrowser.Dock = DockStyle.None;
            _chromiumWebBrowser.RequestHandler = new CustomRequestHandler();
        }


    }
}
