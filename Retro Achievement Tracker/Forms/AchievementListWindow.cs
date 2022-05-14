using CefSharp;
using CefSharp.Web;
using Newtonsoft.Json;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Forms
{
    public partial class AchievementListWindow : Form
    {
        public AchievementListWindow()
        {
            ClientSize = new Size(0, 0);

            Name = "RA Tracker - Achievement List";
            Text = "RA Tracker - Achievement List";

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));

            Shown += AchievementListWindow_Shown;
            FormClosed += AchievementListWindow_FormClosed;

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
        public void AssignJavaScriptVariables()
        {
            ExecuteScript(
                "allAchievements = document.getElementsByClassName(\"achievement\");");
        }
        public void AddAchievement(Achievement achievement, int xCoord, int yCoord)
        {
            ExecuteScript("addAchievement(\"" + xCoord + "px\"," + "\"" + yCoord + "px\"," + JsonConvert.SerializeObject(achievement) + ");");

        }
        public void SetWindowBackgroundColor(string value)
        {
            ExecuteScript(
                "container.style.backgroundColor = \"" + value + "\";");
        }
        public void UnlockAchievement(Achievement achievement)
        {
            ExecuteScript("$(\"#achievement-" + achievement.Id + "-locked-image\").toggle(\"pulsate\");" +
                "$(\"#achievement-" + achievement.Id + "\").tooltip(\"option\", \"content\", \"" + (achievement.Title + "<br/><br/>" + achievement.Points + "pts<br/><br/>" + achievement.Description + "<br/><br/>" + achievement.DateEarned.Value.ToLocalTime().ToString()) + "\");");
        }
        public void StartScrolling(int timeout)
        {
            ExecuteScript("setTimeout(function() { startScrolling(); }, " + (timeout + 1000) + "); ");
        }
        public void SetAchievementPositions(Dictionary<Achievement, ValueTuple<int, int, int>> achievementAndCoordinates)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Achievement achievement in achievementAndCoordinates.Keys)
            {
                ValueTuple<int, int, int> value;

                achievementAndCoordinates.TryGetValue(achievement, out value);

                stringBuilder.Append("setTimeout(function() { " +
                    "$(\"#achievement-" + achievement.Id + "\")");
                stringBuilder.Append("" +
                    "   .animate(" +
                    "       {" +
                    "           left: '" + value.Item1 + "px', " +
                    "           top: '" + value.Item2 + "px' " +
                    "       }, 1000, 'easeInOutQuint'" +
                    "   ); " +
                    "}, " + value.Item3 + ");");
            }

            ExecuteScript(stringBuilder.ToString());
        }
        public void ClearAchievements(Dictionary<int, int> idsToTimeouts)
        {
            StringBuilder stringBuilder = new StringBuilder("stopScrolling();" +
                "document.getElementById(\"container\").scrollTo(" +
                "{" +
                " top: 0," +
                " left: 0," +
                " behavior: 'smooth'" +
                "});");

            foreach (int id in idsToTimeouts.Keys)
            {

                idsToTimeouts.TryGetValue(id, out int value);

                stringBuilder.Append("setTimeout(function() { " +
                    "   var achievement" + id + "OffsetTop = document.getElementById(\"achievement-" + id + "\").offsetTop;" +
                    "   var achievement" + id + "OffsetTopNew = achievement" + id + "OffsetTop + 1048;" +
                    "   $(\"#achievement-" + id + "\").animate( { top: `${ achievement" + id + "OffsetTopNew }px` }, 800, 'easeInOutQuint'); " +
                    "}, " + value + ");");
            }

            ExecuteScript(stringBuilder.ToString());
        }
        public void CleanCanvas()
        {
            ExecuteScript("document.getElementById(\"achievement-list\").innerHTML = \"\";");
        }
        protected async void ExecuteScript(string script)
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
            this.BackColor = Color.Magenta;
            Controls.Remove(chromiumWebBrowser);

            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.AchievementListWindow))
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "chromiumWebBrowser",
                Size = new Size(748, 614),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };

            chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                Invoke((MethodInvoker)delegate
                {
                    ClientSize = new Size(748, 614);

                    AchievementListController.Instance.SetAllSettings();
                });
            });

            Controls.Add(chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;
    }
}
