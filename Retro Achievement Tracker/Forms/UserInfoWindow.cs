using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    public partial class UserInfoWindow : Form
    {
        public UserInfoWindow()
        {
            InitializeComponent();
        }
        private void NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            UserInfoController.Instance.IsOpen = true;
            UserInfoController.Instance.UpdateUserInfo();
        }
        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);

            await InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await webView21.EnsureCoreWebView2Async(null);

            webView21.NavigateToString(Resources.user_info_window);
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            UserInfoController.Instance.IsOpen = false;
        }
        public void AssignJavaScriptVariables()
        {
            webView21.ExecuteScriptAsync("assignJavaScriptVariables();");
        }
        public void SetWindowBackgroundColor(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setWindowBackgroundColor(\"{0}\");", value));
        }
        public void SetSimpleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);

            webView21.ExecuteScriptAsync(string.Format("setSimpleFontFamily(\"{0}\", \"{1}\");", value.Name.Replace(":", "\\:"), (lineSpacing == 0 ? 1 : lineSpacing).ToString()));
        }
        public void SetSimpleFontColor(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setSimpleFontColor(\"{0}\");", value));
        }
        public void SetSimpleFontOutline(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setSimpleFontOutline(\"{0}\");", value));
        }
        public void SetNameFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);

            webView21.ExecuteScriptAsync(string.Format("setNameFontFamily(\"{0}\", \"{1}\");", value.Name.Replace(":", "\\:"), (lineSpacing == 0 ? 1 : lineSpacing).ToString()));
        }
        public void SetValueFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);

            webView21.ExecuteScriptAsync(string.Format("setValueFontFamily(\"{0}\", \"{1}\");", value.Name.Replace(":", "\\:"), (lineSpacing == 0 ? 1 : lineSpacing).ToString()));
        }
        public void SetNameColor(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setNameColor(\"{0}\");", value));
        }
        public void SetValueColor(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setValueColor(\"{0}\");", value));
        }
        public void SetNameOutline(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setNameOutlineColor(\"{0}\");", value));
        }
        public void SetValueOutline(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setValueOutlineColor(\"{0}\");", value));
        }
        public void SetRankName(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setRankName(\"{0}\");", string.IsNullOrEmpty(value.Trim()) ? string.Empty : value.Trim() + ":"));
        }
        public void SetRankValue(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setRankValue(\"{0}\");", value));
        }
        public void SetRankVisibility(bool isVisible)
        {
            webView21.ExecuteScriptAsync(string.Format("setRankVisibility(\"{0}\");", isVisible.ToString()));
        }
        //Points
        public void SetPointsName(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setPointsName(\"{0}\");", string.IsNullOrEmpty(value.Trim()) ? string.Empty : value.Trim() + ":"));
        }
        public void SetPointsValue(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setPointsValue(\"{0}\");", value));
        }
        public void SetPointsVisibility(bool isVisible)
        {
            webView21.ExecuteScriptAsync(string.Format("setPointsVisibility(\"{0}\");", isVisible.ToString()));
        }
        //True Points
        public void SetTruePointsName(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setTruePointsName(\"{0}\");", string.IsNullOrEmpty(value.Trim()) ? string.Empty : value.Trim() + ":"));
        }
        public void SetTruePointsValue(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setTruePointsValue(\"{0}\");", value));
        }
        public void SetTruePointsVisibility(bool isVisible)
        {
            webView21.ExecuteScriptAsync(string.Format("setTruePointsVisibility(\"{0}\");", isVisible.ToString()));
        }
        //Ratio
        public void SetRatioName(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setRatioName(\"{0}\");", string.IsNullOrEmpty(value.Trim()) ? string.Empty : value.Trim() + ":"));
        }
        public void SetRatioValue(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setRatioValue(\"{0}\");", value));
        }
        public void SetRatioVisibility(bool isVisible)
        {
            webView21.ExecuteScriptAsync(string.Format("setRatioVisibility(\"{0}\");", isVisible.ToString()));
        }
        public void SetClientSize()
        {
            Invoke(new Action(() =>
            {
                ClientSize = new Size(805, 290);
            }));
        }
    }
}