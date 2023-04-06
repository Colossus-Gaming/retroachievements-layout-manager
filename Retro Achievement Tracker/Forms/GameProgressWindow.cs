using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Forms
{
    public partial class GameProgressWindow : Form
    {
        public GameProgressWindow()
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

            webView21.NavigateToString(Resources.game_progress_window);
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            GameProgressController.Instance.IsOpen = false;
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
        public void SetGameRatioName(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setGameRatioName(\"{0}\");", string.IsNullOrEmpty(value.Trim()) ? string.Empty : value.Trim() + ":"));
        }
        public void SetGameRatioValue(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setGameRatioValue(\"{0}\");", value));
        }
        public void SetGameRatioVisibility(bool isVisible)
        {
            webView21.ExecuteScriptAsync(string.Format("setGameRatioVisibility(\"{0}\");", isVisible.ToString()));
        }
        //Points
        public void SetGamePointsName(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setGamePointsName(\"{0}\");", string.IsNullOrEmpty(value.Trim()) ? string.Empty : value.Trim() + ":"));
        }
        public void SetGamePointsValue(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setGamePointsValue(\"{0}\");", value));
        }
        public void SetGamePointsVisibility(bool isVisible)
        {
            webView21.ExecuteScriptAsync(string.Format("setGamePointsVisibility(\"{0}\");", isVisible.ToString()));
        }
        //True Points
        public void SetGameTruePointsName(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setGameTruePointsName(\"{0}\");", string.IsNullOrEmpty(value.Trim()) ? string.Empty : value.Trim() + ":"));
        }
        public void SetGameTruePointsValue(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setGameTruePointsValue(\"{0}\");", value));
        }
        public void SetGameTruePointsVisibility(bool isVisible)
        {
            webView21.ExecuteScriptAsync(string.Format("setGameTruePointsVisibility(\"{0}\");", isVisible.ToString()));
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
        //Game Achievements
        public void SetGameAchievementsName(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setGameAchievementsName(\"{0}\");", string.IsNullOrEmpty(value.Trim()) ? string.Empty : value.Trim() + ":"));
        }
        public void SetGameAchievementsValue(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setGameAchievementsValue(\"{0}\");", value));
        }
        public void SetGameAchievementsVisibility(bool isVisible)
        {
            webView21.ExecuteScriptAsync(string.Format("setGameAchievementsVisibility(\"{0}\");", isVisible.ToString()));
        }
        //Completed
        public void SetCompletedName(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setCompletedName(\"{0}\");", string.IsNullOrEmpty(value.Trim()) ? string.Empty : value.Trim() + ":"));
        }
        public void SetCompletedValue(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setCompletedValue(\"{0}\");", value));
        }
        public void SetCompletedVisibility(bool isVisible)
        {
            webView21.ExecuteScriptAsync(string.Format("setCompletedVisibility(\"{0}\");", isVisible.ToString()));
        }
        public void SetClientSize()
        {
            Invoke(new Action(() => {
                ClientSize = new Size(805, 350);
            }));
        }
        private void NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            GameProgressController.Instance.IsOpen = true;
            GameProgressController.Instance.UpdateGameProgress();
        }
    }
}
