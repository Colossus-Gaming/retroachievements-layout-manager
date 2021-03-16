using CefSharp;
using CefSharp.Web;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    public partial class LastFiveLayoutWindow : Form
    {
        public List<Achievement> CurrentAchievements;
        private Stopwatch longActionStopwatch;
        private System.Timers.Timer timer;
        private Queue<Action> actions;
        public LastFiveLayoutWindow()
        {
            this.ClientSize = new Size(585, 700);

            SetupBrowser();

            this.Name = "RA Tracker - Last Five Achievements";
            this.Text = "RA Tracker - Last Five Achievements";

            CurrentAchievements = new List<Achievement>();
            actions = new Queue<Action>();

            this.timer = new System.Timers.Timer(300);
            this.timer.Elapsed += new ElapsedEventHandler(ExecuteActions);
            this.timer.AutoReset = true;
            this.timer.Enabled = true;

            this.longActionStopwatch = new Stopwatch();
            this.longActionStopwatch.Start();
        }

        public async void SetFontColor(string hexCode)
        {
            await ExecuteScript("setFontColor(\"" + hexCode + "\");");
        }

        public async void SetFontFamily(string fontName)
        {
            await ExecuteScript("setFontFamily(\"" + fontName.Replace("'", "\\'") + "\");");
        }

        public async void SetFontOutline(string hexCode, int size)
        {
            await ExecuteScript("setFontOutline(\"" + hexCode + " " + size + "px\");");
        }

        public async void SetBackgroundColor(string hexCode)
        {
            await ExecuteScript("setBackgroundColor(\"" + hexCode + "\");");
        }
        public async void PromptUserInput()
        {
            await ExecuteScript("promptUser();");
        }
        public async void EnableBorder()
        {
            await ExecuteScript("enableBorder();");
        }
        public async void DisableBorder()
        {
            await ExecuteScript("disableBorder();");
        }
        public async void ShowPoints()
        {
            await ExecuteScript("showPoints();");
        }
        public async void HidePoints()
        {
            await ExecuteScript("hidePoints();");
        }
        private async void ClearList()
        {
            longActionStopwatch.Restart();

            CurrentAchievements = new List<Achievement>();

            await ExecuteScript("clearList();");
        }

        private async void AddAchievement(Achievement achievement)
        {
            await ExecuteScript("addToList(\"" + achievement.Title.Replace("\"", "\\\"") + "\"," +
                                       "\"https://retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\",\"" +
                                       achievement.Description.Replace("\"", "\\\"") + "\",\"" + achievement.Points + "\",\"" +
                                       achievement.DateEarned.ToString() + "\", \"" + achievement.Id + "\");");
        }

        private async void AnimateAchievement(int id, int position)
        {
            await ExecuteScript("setAnimationForAchievement(" + id + "," + position + ");");
        }

        public void AnimateAchievements()
        {
            for (int i = 0; i < CurrentAchievements.Count; i++)
            {
                int id = CurrentAchievements[i].Id;
                int position = CurrentAchievements.Count - i - 1;

                actions.Enqueue(() =>
                {
                    AnimateAchievement(id, position);
                });
            }
            while (CurrentAchievements.Count > 5)
            {
                actions.Enqueue(() =>
                {
                    RemoveAchievement(CurrentAchievements[0].Id);

                    CurrentAchievements.RemoveAt(0);
                });
            }
        }

        public async void ShowList()
        {
            longActionStopwatch.Restart();

            await ExecuteScript("showList();");
        }

        private async void RemoveAchievement(int id)
        {
            await ExecuteScript("removeAchievement(\"" + id + "\");");
        }

        public void QueueShowList()
        {
            actions.Enqueue(() =>
            {
                ShowList();
            });
        }

        public void QueueClearList()
        {
            actions.Enqueue(() =>
            {
                ClearList();
            });
        }


        public void EnqueueAchievement(Achievement achievement)
        {
            if (!CurrentAchievements.Contains(achievement))
            {
                CurrentAchievements.Add(achievement);

                actions.Enqueue(() =>
                {
                    AddAchievement(achievement);
                });
            }
        }

        private void ExecuteActions(object sender, EventArgs e)
        {
            if (longActionStopwatch.ElapsedMilliseconds > 1600)
            {
                longActionStopwatch.Stop();

                if (actions.Count > 0)
                {
                    actions.Dequeue().Invoke();
                }
            }
        }

        protected async Task ExecuteScript(string script)
        {
            if (this.Visible)
            {
                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception)
                {
                }
            }
        }

        protected void SetupBrowser()
        {
            this.chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.LastFive))
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "chromiumWebBrowser",
                Size = new Size(1366, 768),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };

            this.Controls.Add(this.chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LastFiveLayoutWindow));
            this.SuspendLayout();
            // 
            // LastFiveLayoutWindow
            // 
            this.ClientSize = new Size(284, 261);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LastFiveLayoutWindow";
            this.ResumeLayout(false);

        }
    }
}