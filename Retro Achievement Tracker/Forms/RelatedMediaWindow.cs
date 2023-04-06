using Microsoft.Web.WebView2.Core;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Forms
{
    public partial class RelatedMediaWindow : Form
    {
        public RelatedMediaWindow()
        {
            InitializeComponent();
        }
        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);

            await InitializeAsync();
        }
        private async Task InitializeAsync()
        {
            await webView21.EnsureCoreWebView2Async(null);

            webView21.CoreWebView2.SetVirtualHostNameToFolderMapping("appassets.tracker", RelatedMediaController.Instance.LaunchBoxFilePath.Replace("\\", "/"), CoreWebView2HostResourceAccessKind.DenyCors);
            webView21.NavigateToString(Resources.related_media_window);
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            RelatedMediaController.Instance.IsOpen = false;
        }
        public void AssignJavaScriptVariables()
        {
            webView21.ExecuteScriptAsync("assignJavaScriptVariables();");
        }
        public void SetWindowBackgroundColor(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setWindowBackgroundColor(\"{0}\");", value));
        }
        public void SetImage(string imageUri)
        {
            webView21.ExecuteScriptAsync($"setImage(\"{imageUri}\");");
        }
        public void HideImage()
        {
            webView21.ExecuteScriptAsync("hideImage();");
        }
        public void ShowImage()
        {
            webView21.ExecuteScriptAsync("showImage();");
        }
        public void SetClientSize()
        {
            Invoke(new Action(() =>
            {
                ClientSize = new Size(640, 480);
            }));
        }
        private void NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                RelatedMediaController.Instance.IsOpen = true;
                RelatedMediaController.Instance.SetAllSettings();
            }
        }
    }
}
