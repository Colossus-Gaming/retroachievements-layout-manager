using CefSharp;
using CefSharp.Web;
using Newtonsoft.Json;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Forms
{
    public partial class AchievementListWindow : Form
    {
        private TaskController TaskController;
        public AchievementListWindow()
        {
            ClientSize = new Size(0, 0);

            Name = "RA Tracker - Achievement List";
            Text = "RA Tracker - Achievement List";

            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainPage));
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));

            Shown += AchievementListWindow_Shown;
            FormClosed += AchievementListWindow_FormClosed;

            TaskController = new TaskController();

            SetupBrowser();
        }

        private void AchievementListWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            AchievementListController.Instance.IsOpen = false;
        }

        private void AchievementListWindow_Shown(object sender, EventArgs e)
        {
            AchievementListController.Instance.IsOpen = true;
        }
        public async void AssignJavaScriptVariables()
        {
            await TaskController.Enqueue(() => ExecuteScript("allAchievements = document.getElementsByClassName(\"achievement\");"));
        }
        public async void AddAchievement(Achievement achievement, int xCoord, int yCoord)
        {
            await TaskController.Enqueue(() => ExecuteScript("addAchievement(\"" + xCoord + "px\"," + "\"" + yCoord + "px\"," + JsonConvert.SerializeObject(achievement) + ");"));
        }
        public async void SetWindowBackgroundColor(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript("container.style.backgroundColor = \"" + value + "\";"));
        }
        public async void UnlockAchievement(Achievement achievement)
        {
            await TaskController.Enqueue(() => ExecuteScript("$(\"#achievement-" + achievement.Id + "-locked-image\").toggle(\"pulsate\");" +
                "$(\"#achievement-" + achievement.Id + "\").tooltip(\"option\", \"content\", \"" + (achievement.Title + "<br/><br/>" + achievement.Points + "pts<br/><br/>" + achievement.Description + "<br/><br/>" + achievement.DateEarned.Value.ToLocalTime().ToString()) + "\");"));
        }
        public async void StartScrolling()
        {
            await TaskController.Enqueue(() => ExecuteScript("startScrolling();"));
        }
        public async void SetAchievementPosition(Achievement achievement, int xCoord, int yCoord)
        {

            await TaskController.Enqueue(() => ExecuteScript("$(\"#achievement-" + achievement.Id + "\")" +
                ".animate(" +
                "   {" +
                "       left: '" + xCoord + "px', " +
                "       top: '" + yCoord + "px' " +
                "   }, 1000, 'easeInOutQuint'" +
                ");"));
        }
        public void ClearAchievements(Dictionary<int, int> idsToTimeouts)
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

            TaskController.Enqueue(() => ExecuteScript(stringBuilder.ToString()));
            TaskController.Enqueue(() => Task.Delay(2000));
            TaskController.Enqueue(() => ExecuteScript("document.getElementById(\"achievement-list\").innerHTML = \"\";"));
        }
        protected async Task ExecuteScript(string script)
        {
            if (chromiumWebBrowser != null)
            {
                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
        public void SetupBrowser()
        {
            Controls.Remove(chromiumWebBrowser);

            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.AchievementListWindow))
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "chromiumWebBrowser",
                Size = new Size(748, 611),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };

            chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                Invoke((MethodInvoker)delegate
                {
                    ClientSize = new Size(748, 611);

                    AchievementListController.Instance.SetAllSettings();
                });
            });

            Controls.Add(chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;
    }
}
