using Retro_Achievement_Tracker.Controllers;
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

            webView21.NavigateToString(Resources.game_info_window);
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            GameInfoController.Instance.IsOpen = false;
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
            webView21.ExecuteScriptAsync(string.Format("setNameFontColor(\"{0}\");", value));
        }
        public void SetValueColor(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setValueFontColor(\"{0}\");", value));
        }
        public void SetNameOutline(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setNameFontOutline(\"{0}\");", value));
        }
        public void SetValueOutline(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setValueFontOutline(\"{0}\");", value));
        }
        //Title
        public void SetTitleName(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setTitleName(\"{0}\");", string.IsNullOrEmpty(value.Trim()) ? string.Empty : value.Trim() + ":"));
        }
        public void SetTitleValue(string value)
        {
            if (value.Contains(", The"))
            {
                value = "The " + value.Substring(0, value.IndexOf(", The")) + value.Substring(value.IndexOf(", The") + 5, value.Length - value.IndexOf(", The") - 5);
            }

            if (value.Contains(":"))
            {
                value = value.Substring(0, value.IndexOf(":")) + ":<br>" + value.Substring(value.IndexOf(":") + 1, value.Length - value.IndexOf(":") - 1);
            }

            webView21.ExecuteScriptAsync(string.Format("setTitleValue(\"{0}\");", value));
        }
        public void SetTitleVisibility(bool isVisible)
        {
            webView21.ExecuteScriptAsync(string.Format("setTitleVisibility(\"{0}\");", isVisible.ToString()));
        }

        //Console
        public void SetConsoleName(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setConsoleName(\"{0}\");", string.IsNullOrEmpty(value.Trim()) ? string.Empty : value.Trim() + ":"));
        }
        public void SetConsoleValue(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setConsoleValue(\"{0}\");", value));
        }
        public void SetConsoleVisibility(bool isVisible)
        {
            webView21.ExecuteScriptAsync(string.Format("setConsoleVisibility(\"{0}\");", isVisible.ToString()));
        }

        //Developer
        public void SetDeveloperName(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setDeveloperName(\"{0}\");", string.IsNullOrEmpty(value.Trim()) ? string.Empty : value.Trim() + ":"));
        }
        public void SetDeveloperValue(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setDeveloperValue(\"{0}\");", value));
        }
        public void SetDeveloperVisibility(bool isVisible)
        {
            webView21.ExecuteScriptAsync(string.Format("setDeveloperVisibility(\"{0}\");", isVisible.ToString()));
        }

        //Publisher
        public void SetPublisherName(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setPublisherName(\"{0}\");", string.IsNullOrEmpty(value.Trim()) ? string.Empty : value.Trim() + ":"));
        }
        public void SetPublisherValue(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setPublisherValue(\"{0}\");", value));
        }
        public void SetPublisherVisibility(bool isVisible)
        {
            webView21.ExecuteScriptAsync(string.Format("setPublisherVisibility(\"{0}\");", isVisible.ToString()));
        }

        //Genre
        public void SetGenreName(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setGenreName(\"{0}\");", string.IsNullOrEmpty(value.Trim()) ? string.Empty : value.Trim() + ":"));
        }
        public void SetGenreValue(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setGenreValue(\"{0}\");", value));
        }
        public void SetGenreVisibility(bool isVisible)
        {
            webView21.ExecuteScriptAsync(string.Format("setGenreVisibility(\"{0}\");", isVisible.ToString()));
        }

        //Release Date
        public void SetReleaseDateName(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setReleaseDateName(\"{0}\");", string.IsNullOrEmpty(value.Trim()) ? string.Empty : value.Trim() + ":"));
        }
        public void SetReleaseDateValue(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setReleaseDateValue(\"{0}\");", value));
        }
        public void SetReleaseDateVisibility(bool isVisible)
        {
            webView21.ExecuteScriptAsync(string.Format("setReleaseDateVisibility(\"{0}\");", isVisible.ToString()));
        }

        public void SetClientSize()
        {
            Invoke(new Action(() =>
            {
                ClientSize = new Size(1190, 645);
            }));
        }
        private void NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            GameInfoController.Instance.IsOpen = true;

            GameInfoController.Instance.UpdateGameInfo();
        }
    }
}