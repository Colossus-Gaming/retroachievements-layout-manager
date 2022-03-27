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
        public void AddAchievement(Achievement achievement, int size)
        {
            string badgeLink = achievement.DateEarned.HasValue ? "\"https://retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\"" : "\"https://s3-eu-west-1.amazonaws.com/i.retroachievements.org/Badge/" + achievement.BadgeNumber + "_lock.png\"";
            ExecuteScript("addAchievement(\"" + achievement.Title.Replace("\"", "\\\"") + "\"," +
                                       "" + badgeLink + "," +
                                       "\"" + achievement.Description.Replace("\"", "\\\"") + "\"," +
                                       "\"" + achievement.Points + "\"," +
                                       "\"" + achievement.DateEarned.ToString() + "\", " +
                                       "\"" + achievement.Id + "\"," +
                                       "\"" + size + "px\");");

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

        public void UnlockAchievement(Achievement newAchievement)
        {
            ExecuteScript("document.getElementById(\"achievement-" + newAchievement.Id + "-image\").src = \"https://retroachievements.org/Badge/" + newAchievement.BadgeNumber + ".png\"");
        }
        public async Task<ValueTuple<int, int>> GetAchievementPosition(int id)
        {
            int currX = 0;
            int currY = 0;

            try
            {
                JavascriptResponse javascriptResponse = await chromiumWebBrowser.EvaluateScriptAsync("document.getElementById(\"achievement-" + id + "\").offsetLeft", TimeSpan.FromSeconds(5));

                currX = int.Parse(javascriptResponse.Result.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            try
            {
                JavascriptResponse javascriptResponse = await chromiumWebBrowser.EvaluateScriptAsync("document.getElementById(\"achievement-" + id + "\").offsetTop", TimeSpan.FromSeconds(5));

                currY = int.Parse(javascriptResponse.Result.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return (currX, currY);
        }
        public async void SetAchievementPosition(int id, int nextX, int nextY)
        {
            await GetAchievementPosition(id).ContinueWith(result =>
            {
                ExecuteScript("document.getElementById(\"achievement-" + id + "\")" +
                ".animate([ { left: '" + result.Result.Item1 + "px', top: '" + result.Result.Item2 + "px' }, { left: '" + nextX + "px', top: '" + nextY + "px' } ], { interations: 1, duration: 300, fill: \"forwards\", easing: \"ease-in\" });");
            });
        }
        public async void ClearAchievement(int id)
        {
            await GetAchievementPosition(id).ContinueWith(result =>
            {
                ExecuteScript("document.getElementById(\"achievement-" + id + "\")" +
                ".animate([ { left: '" + result.Result.Item1 + "px', top: '" + result.Result.Item2 + "px' }, { left: '" + result.Result.Item1 + "px', top: '1500px' } ], { interations: 1, duration: 500, fill: \"forwards\", easing: \"ease-in\" });" +
                "document.getElementById(\"achievement-" + id + "\")" +
                ".classList.add(\"achievement-delete\");");
            });
        }
        public void ClearList()
        {
            ExecuteScript("var allDeleteAchievements = document.getElementsByClassName(\"achievement-delete\");" +
                "while (allDeleteAchievements.length > 0) {  allDeleteAchievements[allDeleteAchievements.length - 1].remove(); allDeleteAchievements = document.getElementsByClassName(\"achievement-delete\"); }");
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
