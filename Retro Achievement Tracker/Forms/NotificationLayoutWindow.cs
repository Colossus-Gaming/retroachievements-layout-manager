using CefSharp;
using CefSharp.Web;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Forms
{
    public partial class NotificationLayoutWindow : Form
    {
        private Task NotificationsTask;
        private readonly List<NotificationRequest> NotificationRequests;
        private Stopwatch stopwatch;
        private readonly CancellationTokenSource tokenSource2 = new CancellationTokenSource();

        public NotificationLayoutWindow(Action<string, string, int> writeAlertStreamLabels)
        {
            this.ClientSize = new Size(1200, 600);
            SetupBrowser();
            this.Name = "RA Tracker - Notifications";
            this.Text = "RA Tracker - Notifications";

            NotificationRequests = new List<NotificationRequest>();

            stopwatch = new Stopwatch();

            RunNotificationTask();
            this.writeAlertStreamLabels = writeAlertStreamLabels;
        }

        public void FireNotifications()
        {
            if (NotificationRequests.Count > 0 && !stopwatch.IsRunning && NotificationsTask.Status != TaskStatus.Running)
            {
                RunNotificationTask();
            }
        }

        private void RunNotificationTask()
        {
            NotificationsTask = Task.Factory.StartNew(async () =>
            {
                long delayInMilli = 0;

                while (NotificationRequests.Count > 0 || stopwatch.IsRunning)
                {
                    if (tokenSource2.Token.IsCancellationRequested)
                    {
                        tokenSource2.Token.ThrowIfCancellationRequested();
                    }

                    if (!stopwatch.IsRunning)
                    {
                        if (!this.IsDisposed)
                        {
                            if (NotificationRequests.Count > 0)
                            {
                                NotificationRequest notificationRequest = NotificationRequestDequeue();

                                if (tokenSource2.Token.IsCancellationRequested)
                                {
                                    tokenSource2.Token.ThrowIfCancellationRequested();
                                }

                                if (notificationRequest != null)
                                {
                                    if (notificationRequest.Achievement != null)
                                    {
                                        SendAchievementNotification(notificationRequest.Achievement);

                                        if (Settings.Default.stream_labels_notifications)
                                        {
                                            this.writeAlertStreamLabels(notificationRequest.Achievement.Title, notificationRequest.Achievement.Description, notificationRequest.Achievement.Points);
                                        }

                                        stopwatch = Stopwatch.StartNew();

                                        SetAchievementIn(notificationRequest.CustomIn);
                                        SetAchievementOut(notificationRequest.CustomOut);

                                        delayInMilli = notificationRequest.Duration;
                                    }
                                    else if (notificationRequest.GameSummary != null && notificationRequest.GameAchievementSummary != null)
                                    {
                                        SendMasteryNotification(notificationRequest.GameSummary, notificationRequest.GameAchievementSummary);

                                        if (Settings.Default.stream_labels_notifications)
                                        {
                                            this.writeAlertStreamLabels(notificationRequest.GameSummary.Title, MakeMasteryDescription(notificationRequest.GameAchievementSummary), 0);
                                        }

                                        stopwatch = Stopwatch.StartNew();

                                        SetMasteryIn(notificationRequest.CustomIn);
                                        SetMasteryOut(notificationRequest.CustomOut);

                                        delayInMilli = notificationRequest.Duration;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (stopwatch.ElapsedMilliseconds > delayInMilli)
                        {
                            HideNotifications();
                            if (Settings.Default.stream_labels_notifications)
                            {
                                this.writeAlertStreamLabels("", "", 0);
                            }
                            stopwatch.Stop();
                            delayInMilli = 0;
                        }
                        else
                        {
                            await Task.Delay(100);
                        }
                    }
                }
            }, tokenSource2.Token);
        }

        private string MakeMasteryDescription(GameAchievementSummary gameAchievementSummary)
        {
            return "Cheevos: " + gameAchievementSummary.NumPossibleAchievements + "/" + gameAchievementSummary.NumPossibleAchievements
                + Environment.NewLine
                + "Points: " + gameAchievementSummary.PossibleScore + "/" + gameAchievementSummary.PossibleScore;
        }

        private NotificationRequest NotificationRequestDequeue()
        {
            NotificationRequest notificationRequest = NotificationRequests[0];

            NotificationRequests.Remove(notificationRequest);

            return notificationRequest;
        }

        public void EnqueueAchievementNotification(Achievement achievement, int duration, int intro, int outro)
        {
            NotificationRequest notificationRequest = new NotificationRequest
            {
                Achievement = achievement,
                Duration = duration,
                CustomIn = intro,
                CustomOut = outro
            };

            NotificationRequests.Add(notificationRequest);
        }

        public void EnqueueMasteryNotification(GameSummary gameSummary, GameAchievementSummary gameAchievementSummary, int duration, int intro, int outro)
        {
            NotificationRequest notificationRequest = new NotificationRequest
            {
                GameSummary = gameSummary,
                GameAchievementSummary = gameAchievementSummary,
                Duration = duration,
                CustomIn = intro,
                CustomOut = outro
            };
            NotificationRequests.Add(notificationRequest);
        }

        public async void SendAchievementNotification(Achievement achievement)
        {
            await ExecuteScript("achievementNotification(\"" + achievement.Title.Replace("\"", "\\\"") + "\"," +
                                       "\"https://retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\",\"" +
                                       achievement.Description.Replace("\"", "\\\"") + "\",\"" + achievement.Points + "\");");
        }

        public async void SendMasteryNotification(GameSummary gameSummary, GameAchievementSummary gameAchievementSummary)
        {
            await ExecuteScript("masteryNotification(\"" + gameSummary.Title.Replace("\"", "\\\"") + "\"," +
                                                "\"https://retroachievements.org" + gameSummary.ImageIcon + "\"," +
                                                "\"" + gameAchievementSummary.NumPossibleAchievements + "\"," +
                                                "\"" + gameAchievementSummary.PossibleScore + "\");");
        }

        public async void PromptUserInput()
        {
            await ExecuteScript("promptUser();");
        }

        public async void EnableAchievementEdit()
        {
            await ExecuteScript("enableEditModeAchievement();");
        }

        public async void DisableAchievementEdit()
        {
            await ExecuteScript("disableEditModeAchievement();");
        }

        public async void EnableMasteryEdit()
        {
            await ExecuteScript("enableEditModeMastery();");
        }

        public async void DisableMasteryEdit()
        {
            await ExecuteScript("disableEditModeMastery();");
        }

        public async void SetAchievementLeft(int x)
        {
            await ExecuteScript("setAchievementLeft(\"" + x + "px\");");
        }

        public async void SetAchievementTop(int y)
        {
            await ExecuteScript("setAchievementTop(\"" + y + "px\");");
        }

        public async void SetMasteryLeft(int x)
        {
            await ExecuteScript("setMasteryLeft(\"" + x + "px\");");
        }

        public async void SetMasteryTop(int y)
        {
            await ExecuteScript("setMasteryTop(\"" + y + "px\");");
        }

        public async void SetAchievementWidth(int width)
        {
            await ExecuteScript("setAchievementWidth(\"" + width + "px\");");
        }

        public async void SetMasteryWidth(int width)
        {
            await ExecuteScript("setMasteryWidth(\"" + width + "px\");");
        }

        public async void SetAchievementIn(int intro)
        {
            await ExecuteScript("setAchievementIn(" + intro + ");");
        }

        public async void SetAchievementOut(int outro)
        {
            await ExecuteScript("setAchievementOut(" + outro + ");");
        }
        public async void SetMasteryIn(int intro)
        {
            await ExecuteScript("setMasteryIn(" + intro + ");");
        }

        public async void SetMasteryOut(int outro)
        {
            await ExecuteScript("setMasteryOut(" + outro + ");");
        }
        public async void SetAchievementInAnimation(string animation)
        {
            await ExecuteScript("setAnimationAchievementIn(\"" + animation + "\");");
        }
        public async void SetAchievementOutAnimation(string animation)
        {
            await ExecuteScript("setAnimationAchievementOut(\"" + animation + "\");");
        }
        public async void SetMasteryInAnimation(string animation)
        {
            await ExecuteScript("setAnimationMasteryIn(\"" + animation + "\");");
        }
        public async void SetMasteryOutAnimation(string animation)
        {
            await ExecuteScript("setAnimationMasteryOut(\"" + animation + "\");");
        }
        public async void HideNotifications()
        {
            await ExecuteScript("hideNotifications();");
        }
        public async void SetFontColor(string hexCode)
        {
            await ExecuteScript("setFontColor(\"" + hexCode + "\");");
        }

        public async void SetFontFamily(string fontName)
        {
            await ExecuteScript("setFontFamily(\"" + fontName + "\");");
        }

        public async void SetFontOutline(string hexCode, int size)
        {
            await ExecuteScript("setFontOutline(\"" + hexCode + " " + size + "px\");");
        }
        public async void SetBackgroundColor(string hexCode)
        {
            await ExecuteScript("setBackgroundColor(\"" + hexCode + "\");");
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

        public void SetupBrowser()
        {
            this.chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.NotificationWindow))
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
        private Action<string, string, int> writeAlertStreamLabels;

        public class NotificationRequest
        {
            public Achievement Achievement { get; set; }
            public GameSummary GameSummary { get; set; }
            public GameAchievementSummary GameAchievementSummary { get; set; }
            public int Duration { get; set; }
            public int CustomIn { get; set; }
            public int CustomOut { get; set; }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationLayoutWindow));
            this.SuspendLayout();
            // 
            // NotificationLayoutWindow
            // 
            this.ClientSize = new Size(284, 261);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NotificationLayoutWindow";
            this.ResumeLayout(false);

        }
    }
}
