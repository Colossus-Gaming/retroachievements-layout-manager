using CefSharp;
using Newtonsoft.Json;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Forms
{
    public partial class AchievementListWindow : DisplayForm
    {
        public AchievementListWindow() : base()
        {
            Name = "RA Tracker - Achievement List";
            Text = "RA Tracker - Achievement List";
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            SetupBrowser();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            AchievementListController.Instance.IsOpen = false;
        }

        public override async void AssignJavaScriptVariables()
        {
            await ExecuteScript("allAchievements = document.getElementsByClassName(\"achievement\");");
        }
        public async void AddAchievement(Achievement achievement, int xCoord, int yCoord)
        {
            await ExecuteScript("addAchievement(\"" + xCoord + "px\"," + "\"" + yCoord + "px\"," + JsonConvert.SerializeObject(achievement) + ");");
        }
        public async void UnlockAchievement(Achievement achievement)
        {
            await ExecuteScript("$(\"#achievement-" + achievement.Id + "-locked-image\").toggle(\"pulsate\";" +
                "$(\"#achievement-" + achievement.Id + "\").tooltip(\"option\", \"content\", \"" + achievement.Title + "<br/><br/>" + achievement.Points + "pts<br/><br/>" + achievement.Description + "<br/><br/>" + achievement.DateEarned.Value.ToLocalTime().ToString() + "\");");
        }
        public async void StartScrolling()
        {
            await ExecuteScript("startScrolling();");
        }
        public async void StopScrolling()
        {
            await ExecuteScript("stopScrolling();");
        }
        public async void SetAchievementPosition(Achievement achievement, int xCoord, int yCoord)
        {
            await ExecuteScript("$(\"#achievement-" + achievement.Id + "\")" +
                ".animate(" +
                "   {" +
                "       left: '" + xCoord + "px', " +
                "       top: '" + yCoord + "px' " +
                "   }, 1000, 'easeInOutQuint'" +
                ");");
        }
        public async void ClearAchievements(Dictionary<int, int> idsToTimeouts)
        {
            StringBuilder stringBuilder = new StringBuilder("stopScrolling();" +
                "document.getElementById(\"container\")" +
                ".scrollTo(" +
                "   {" +
                "       top: 0," +
                "       left: 0," +
                "       behavior: 'smooth'" +
                "   }" +
                ");");

            int highestValue = 0;

            foreach (int id in idsToTimeouts.Keys)
            {

                idsToTimeouts.TryGetValue(id, out int value);

                stringBuilder.Append("var achievement" + id + "OffsetTop = document.getElementById(\"achievement-" + id + "\").offsetTop;" +
                    "var achievement" + id + "OffsetTopNew = achievement" + id + "OffsetTop + 1048;" +
                    "setTimeout(function() { $(\"#achievement-" + id + "\").animate( { top: `${ achievement" + id + "OffsetTopNew }px` }, 800, 'easeInOutQuint'); }, " + value + ");");

                if (value > highestValue)
                {
                    highestValue = value;
                }
            }
            string command = stringBuilder.ToString();

            await ExecuteScript(command);
        }
        public async void WipeOldAchievements()
        {
            await ExecuteScript("document.getElementById(\"achievement-list\").innerHTML = \"\";");
        }
        public void SetClientSize()
        {
            Invoke(new Action(() => {
                ClientSize = new Size(748, 611);
            }));
        }
        public override void SetupBrowser()
        {
            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser()
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "achievementListBrowser",
                Size = new Size(748, 611),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };

            chromiumWebBrowser.LoadingStateChanged += new EventHandler<LoadingStateChangedEventArgs>((sender, loadingStateChangedEventArgs) => {
                if (!loadingStateChangedEventArgs.IsLoading)
                {
                    AchievementListController.Instance.IsOpen = true;

                    AchievementListController.Instance.SetAllSettings();
                    AchievementListController.Instance.UpdateAchievementList();
                }
            });

            chromiumWebBrowser.LoadHtml(Resources.achievement_list_window);

            Controls.Add(chromiumWebBrowser);
        }
    }
}
