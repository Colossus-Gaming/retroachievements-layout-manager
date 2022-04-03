using CefSharp;
using CefSharp.Web;
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

            Shown += AchievementListWindow_Shown;
            FormClosed += AchievementListWindow_FormClosed;

            SetupBrowser();
        }

        private void AchievementListWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            AchievementListController.IsOpen = false;
        }

        private void AchievementListWindow_Shown(object sender, EventArgs e)
        {
            AchievementListController.IsOpen = true;
        }
        public void AssignJavaScriptVariables()
        {
            ExecuteScript(
                "allAchievements = document.getElementsByClassName(\"achievement\");");
        }
        public void AddAchievement(Achievement achievement, int size, int xCoord, int yCoord)
        {
            ExecuteScript("addAchievement(\"" + achievement.Title.Replace("\"", "\\\"") + "\"," +
                                       "\"https://s3-eu-west-1.amazonaws.com/i.retroachievements.org/Badge/" + achievement.BadgeNumber + "_lock.png\", " +
                                       "\"https://retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\", " +
                                       "\"" + achievement.Description.Replace("\"", "\\\"") + "\"," +
                                       "\"" + achievement.Points + "\"," +
                                       "\"" + achievement.DateEarned.ToString() + "\", " +
                                       "\"" + achievement.Id + "\"," +
                                       "\"" + size + "px\"," +
                                       "\"" + xCoord + "px\"," +
                                       "\"" + yCoord + "px\"," +
                                       "'" + achievement.DateEarned.HasValue + "');");

        }
        public void SetBorderBackgroundColor(string value)
        {
            ExecuteScript(
                "achievementElement.style.backgroundColor = \"" + value + "\";" +
                "masteryElement.style.backgroundColor = \"" + value + "\";");
        }
        public void SetWindowBackgroundColor(string value)
        {
            ExecuteScript(
                "container.style.backgroundColor = \"" + value + "\";");
        }

        public void UnlockAchievement(Achievement achievement)
        {
            ExecuteScript("$(\"#achievement-" + achievement.Id + "-locked-image\").toggle(\"pulsate\");");
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
                "           }, 1000, 'easeInOutQuint'" +
                    "   ); " +
                    "}, " + value.Item3 + ");");
            }

            ExecuteScript(stringBuilder.ToString());
        }
        public void ClearAchievements(Dictionary<int, int> idsToTimeouts)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (int id in idsToTimeouts.Keys)
            {
                int value;

                idsToTimeouts.TryGetValue(id, out value);

                stringBuilder.Append("setTimeout(function() { " +
                    "   var achievement" + id + "OffsetTop = document.getElementById(\"achievement-" + id + "\").offsetTop;" +
                    "   var achievement" + id + "OffsetTopNew = achievement" + id + "OffsetTop + 1048;" +
                    "   $(\"#achievement-" + id + "\").animate( { top: `${ achievement" + id + "OffsetTopNew }px` }, 800, 'easeInOutQuint'); " +
                    "}, " + value + ");");
            }

            ExecuteScript(stringBuilder.ToString());
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
            Controls.Remove(chromiumWebBrowser);

            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.AchievementListWindow))
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "chromiumWebBrowser",
                Size = new Size(778, 778),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };

            chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                Invoke((MethodInvoker)delegate
                {
                    ClientSize = new Size(768, 768);

                    AchievementListController.Instance.SetAllSettings();
                });
            });

            Controls.Add(chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;
    }
}
