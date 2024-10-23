using Newtonsoft.Json;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Forms
{
    public partial class AchievementListWindow : Form
    {
        public AchievementListWindow()
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

            webView21.NavigateToString(Resources.achievement_list_window);
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            AchievementListController.Instance.IsOpen = false;
        }
        public void AssignJavaScriptVariables()
        {
            webView21.ExecuteScriptAsync("assignJavaScriptVariables();");
        }
        public void SetWindowBackgroundColor(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setWindowBackgroundColor(\"{0}\");", value));
        }
        public void AddAchievement(Achievement achievement, int xCoord, int yCoord)
        {
            webView21.ExecuteScriptAsync($"addAchievement({JsonConvert.SerializeObject(achievement)}, \"" + xCoord + "px\", \"" + (yCoord < AchievementListController.Instance.WindowSizeY ? yCoord + AchievementListController.Instance.WindowSizeY : yCoord) + "px\");");
        }
        public void UnlockAchievement(Achievement achievement)
        {
            webView21.ExecuteScriptAsync($"unlockAchievement({JsonConvert.SerializeObject(achievement)});");
        }
        public void StartScrolling()
        {
            webView21.ExecuteScriptAsync("startScrolling();");
        }
        public void StopScrolling()
        {
            webView21.ExecuteScriptAsync("stopScrolling();");
        }
        public void SetAchievementPosition(Achievement achievement, int xCoord, int yCoord)
        {
            webView21.ExecuteScriptAsync(string.Format("setAchievementPosition(\"{0}\", \"{1}\", \"{2}\");", achievement.Id.ToString(), xCoord + "px", yCoord + "px"));
        }
        public void ClearAchievements(Dictionary<int, int> idsToTimeouts)
        {
            webView21.ExecuteScriptAsync("scrollToTop();");

            foreach (int id in idsToTimeouts.Keys)
            {
                idsToTimeouts.TryGetValue(id, out int value);

                webView21.ExecuteScriptAsync(string.Format("setAchievementOutDelayed(\"{0}\", \"{1}\");", id.ToString(), value.ToString()));
            }
        }
        public void WipeOldAchievements()
        {
            webView21.ExecuteScriptAsync("wipeOldAchievements();");
        }
        public void SetClientSize()
        {
            webView21.ExecuteScriptAsync(string.Format("setWindowSize({0}, {1});", AchievementListController.Instance.WindowSizeX, AchievementListController.Instance.WindowSizeY));
            Invoke(new Action(() =>
            {
                ClientSize = new Size(AchievementListController.Instance.WindowSizeX, AchievementListController.Instance.WindowSizeY);
            }));
        }

        private void NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                AchievementListController.Instance.IsOpen = true;

                AchievementListController.Instance.SetAllSettings();
                AchievementListController.Instance.UpdateAchievementList();
            }
        }
    }
}
