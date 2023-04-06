using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    public partial class FocusWindow : Form
    {
        public FocusWindow()
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

            webView21.CoreWebView2.SetVirtualHostNameToFolderMapping("appassets.tracker", @"images", CoreWebView2HostResourceAccessKind.DenyCors);
            webView21.NavigateToString(Resources.focus_window);
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            FocusController.Instance.IsOpen = false;
        }
        public void AssignJavaScriptVariables()
        {
            webView21.ExecuteScriptAsync("assignJavaScriptVariables();");
        }
        public void SetWindowBackgroundColor(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setWindowBackgroundColor(\"{0}\");", value));
        }
        public void SetBorderBackgroundColor(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setBorderBackgroundColor(\"{0}\");", value));
        }
        public void SetSimpleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);

            webView21.ExecuteScriptAsync(string.Format("setSimpleFontFamily(\"{0}\", \"{1}\");", value.Name.Replace(":", "\\:"), (lineSpacing == 0 ? 1 : lineSpacing).ToString()));
        }
        public void SetSimpleFontColor(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setSimpleFontColor(\"{0}\");", value));
            SetLineColor(value);
        }
        public void SetSimpleFontOutline(string fontOutline, string borderOutline)
        {
            webView21.ExecuteScriptAsync(string.Format("setSimpleFontOutline(\"{0}\");", fontOutline));
            SetLineOutline(borderOutline);
        }
        public void SetTitleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);

            webView21.ExecuteScriptAsync(string.Format("setTitleFontFamily(\"{0}\", \"{1}\");", value.Name.Replace(":", "\\:"), (lineSpacing == 0 ? 1 : lineSpacing).ToString()));
        }
        public void SetTitleColor(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setTitleColor(\"{0}\");", value));
        }
        public void SetTitleOutline(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setTitleOutlineColor(\"{0}\");", value));
        }
        public void SetDescriptionFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);

            webView21.ExecuteScriptAsync(string.Format("setDescriptionFontFamily(\"{0}\", \"{1}\");", value.Name.Replace(":", "\\:"), (lineSpacing == 0 ? 1 : lineSpacing).ToString()));
        }
        public void SetDescriptionColor(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setDescriptionColor(\"{0}\");", value));
        }
        public void SetDescriptionOutline(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setDescriptionOutlineColor(\"{0}\");", value));
        }
        public void SetPointsFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);

            webView21.ExecuteScriptAsync(string.Format("setPointsFontFamily(\"{0}\", \"{1}\");", value.Name.Replace(":", "\\:"), (lineSpacing == 0 ? 1 : lineSpacing).ToString()));
        }
        public void SetPointsColor(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setPointsColor(\"{0}\");", value));
        }
        public void SetPointsOutline(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setPointsOutlineColor(\"{0}\");", value));
        }
        public void SetLineColor(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setLineColor(\"{0}\");", value));
        }
        public void SetLineOutline(string borderOutline)
        {
            webView21.ExecuteScriptAsync(string.Format("setLineOutlineColor(\"{0}\");", borderOutline));
        }
        public void EnableBorder()
        {
            webView21.ExecuteScriptAsync("enableBorder();");
        }
        public void DisableBorder()
        {
            webView21.ExecuteScriptAsync("disableBorder();");
        }
        public async void SetFocus(Achievement achievement)
        {
            if (achievement != null)
            {
                await webView21.ExecuteScriptAsync("fadeOutFocus();");

                await Task.Delay(200);

                await webView21.ExecuteScriptAsync($"addAchievement({JsonConvert.SerializeObject(achievement)});");

                await Task.Delay(200);

                await webView21.ExecuteScriptAsync("fadeInFocus();");
                await webView21.ExecuteScriptAsync("fadeInAchievementDescription();");
            }
            else
            {
                HideFocus();
            }
        }
        public async void SetFocus(GameInfo gameInfo)
        {
            await webView21.ExecuteScriptAsync("fadeOutFocus();");

            await Task.Delay(200);

            await webView21.ExecuteScriptAsync($"addGameInfo({JsonConvert.SerializeObject(gameInfo)});");

            await Task.Delay(200);

            await webView21.ExecuteScriptAsync("fadeInFocus();");
            await webView21.ExecuteScriptAsync("fadeInMasteryDescription();");
        }
        public void HideFocus()
        {
            webView21.ExecuteScriptAsync("hideFocus();");
        }
        public void SetClientSize()
        {
            Invoke(new Action(() =>
            {
                ClientSize = new Size(700, 165);
            }));
        }
        private void NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            FocusController.Instance.IsOpen = true;
            FocusController.Instance.UpdateFocus();
        }
    }
}