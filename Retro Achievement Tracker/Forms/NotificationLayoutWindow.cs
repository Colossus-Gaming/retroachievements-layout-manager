using CefSharp;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Forms
{
    public partial class NotificationLayoutWindow : Form
    {
        public Action<string> LogCallback { get; internal set; }
        public Achievement MostRecentAchievement { get; set; }
        private bool HasMasteredGame;
        private Task NotificationsTask;
        private readonly ConcurrentQueue<NotificationRequest> NotificationRequests;

        public NotificationLayoutWindow()
        {
            InitializeComponent();
            NotificationRequests = new ConcurrentQueue<NotificationRequest>();
            SetupNotificationsTask();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.chromiumWebBrowser.LoadHtml(Resources.DefaultNotificationWindow);
            this.chromiumWebBrowser.FrameLoadEnd += PromptUserInput;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        private void SetupNotificationsTask()
        {
            NotificationsTask = new Task(() =>
            {
                Stopwatch stopwatch = new Stopwatch();
                long delayInMilli = 0;

                while (GetNotificationRequestsCount() > 0 || stopwatch.IsRunning)
                {
                    DisableUserInput();

                    if (!stopwatch.IsRunning)
                    {
                        if (!this.IsDisposed)
                        {
                            NotificationRequest notificationRequest = NotificationRequestDequeue();

                            if (notificationRequest.Achievement != null)
                            {
                                SendAchievementNotification(notificationRequest.Achievement);
                                stopwatch = Stopwatch.StartNew();
                                delayInMilli = 7000;
                            }
                            else if (notificationRequest.GameAchievementSummary != null && notificationRequest.GameSummary != null)
                            {
                                SendMasteryNotification(notificationRequest.GameSummary, notificationRequest.GameAchievementSummary);
                                stopwatch = Stopwatch.StartNew();
                                delayInMilli = 11000;
                            }
                        }
                    }
                    else
                    {
                        if (stopwatch.ElapsedMilliseconds > delayInMilli)
                        {
                            stopwatch.Stop();
                            delayInMilli = 0;
                        }
                    }
                }
                EnableUserInput();
            });
        }

        private void DisableUserInput()
        {
            if (!this.IsDisposed)
            {
                try
                {
                    Invoke((MethodInvoker)delegate
                {
                    this.showRecentAchievementButton.Enabled = false;
                    this.showGameMasteryButton.Enabled = false;
                    this.replayAchievementButton.Enabled = false;
                    this.replayGameMasteryButton.Enabled = false;
                });
                }
                catch
                {
                }
            }
        }

        private int GetNotificationRequestsCount()
        {
            try
            {
                int i = 0;

                Invoke((MethodInvoker)delegate
                {
                    i = NotificationRequests.Count;
                });

                return i;
            } catch
            {
                return 0;
            }
        }

        private NotificationRequest NotificationRequestDequeue()
        {
            NotificationRequest notificationRequest = null;

            Invoke((MethodInvoker)delegate
            {
                if (!NotificationRequests.TryDequeue(out notificationRequest))
                {
                    LogCallback("Error dequeueing notification!");
                }
            });

            return notificationRequest;
        }

        private void EnableUserInput()
        {
            Invoke((MethodInvoker)delegate
            {
                this.showRecentAchievementButton.Enabled = true;
                this.showGameMasteryButton.Enabled = true;
                this.replayAchievementButton.Enabled = true;
                this.replayGameMasteryButton.Enabled = HasMasteredGame;
            });
        }

        public void EnqueueAchievementNotification(Achievement achievement)
        {
            NotificationRequest notificationRequest = new NotificationRequest
            {
                Achievement = achievement
            };

            NotificationRequests.Enqueue(notificationRequest);
            StartNotificationTask();
        }

        public void EnqueueMasteryNotification(GameSummary currentGame, GameAchievementSummary currentAchievementSummary)
        {
            NotificationRequest notificationRequest = new NotificationRequest
            {
                GameSummary = currentGame,
                GameAchievementSummary = currentAchievementSummary
            };

            NotificationRequests.Enqueue(notificationRequest);
            StartNotificationTask();
        }

        private void StartNotificationTask()
        {
            if (NotificationsTask.Status != TaskStatus.Running)
            {
                SetupNotificationsTask();
                NotificationsTask.Start();
            }
        }

        private void SendAchievementNotification(Achievement achievement)
        {
            Invoke((MethodInvoker)delegate
            {
                if (this.Visible && achievement != null)
                {
                    string script = "achievementNotification(\"" + achievement.Title + "\"," +
                                       "\"https://retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\",\"" +
                                       achievement.Description + "\",\"" + achievement.Points + "\");";

                    LogCallback("[achievementNotification] Sending: [" + script + "]");

                    try
                    {
                        chromiumWebBrowser.ExecuteScriptAsync(script, TimeSpan.FromSeconds(2));
                    }
                    catch (Exception ex)
                    {
                        LogCallback("[achievementNotification]" + ex.Message);
                    }
                }
            });
        }

        private void SendMasteryNotification(GameSummary currentGame, GameAchievementSummary currentAchievementSummary)
        {
            Invoke((MethodInvoker)delegate
            {
                if (this.Visible)
                {
                    string script = "masteryNotification(\"" + currentGame.Title + "\"," +
                                                "\"https://retroachievements.org" + currentGame.ImageIcon + "\"," +
                                                "\"" + currentAchievementSummary.NumPossibleAchievements + "\"," +
                                                "\"" + currentAchievementSummary.PossibleScore + "\");";

                    LogCallback("[masteryNotification] Sending: [" + script + "]");

                    try
                    {
                        chromiumWebBrowser.ExecuteScriptAsync(script, TimeSpan.FromSeconds(2));
                    }
                    catch (Exception ex)
                    {
                        LogCallback("[masteryNotification]" + ex.Message);
                    }
                }
            });
        }

        private void ShowAchievementNotification(object sender, EventArgs eventArgs)
        {
            this.EnqueueAchievementNotification(
                new Achievement()
                {
                    Title = "Thrilling!!!!",
                    Description = "Color every bit of Dinosaur 2. [Must color white if leaving white]",
                    BadgeNumber = "49987",
                    Points = 1
                });
        }

        private void ReplayRecentAchievement(object sender, EventArgs eventArgs)
        {
            this.EnqueueAchievementNotification(MostRecentAchievement);
        }

        private void ShowGameMasteryNotification(object sender, EventArgs eventArgs)
        {
            this.EnqueueMasteryNotification(new GameSummary()
            {
                Title = "Color a Dinosaur",
                ImageIcon = "/Images/011853.png"
            },
                new GameAchievementSummary()
                {
                    NumPossibleAchievements = 19,
                    PossibleScore = 19
                });
        }

        private async void PromptUserInput(object sender, EventArgs eventArgs)
        {
            if (this.Visible)
            {
                string script = "promptUser();";

                LogCallback("[promptUser] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(2));
                }
                catch (Exception ex)
                {
                    LogCallback("[promptUser]" + ex.Message);
                }
            }
        }

        public void SetHasMasteredGame(bool mastered)
        {
            HasMasteredGame = mastered;
        }

        public partial class NotificationRequest
        {
            public Achievement Achievement { get; set; }
            public GameSummary GameSummary { get; set; }
            public GameAchievementSummary GameAchievementSummary { get; set; }
        }
    }
}
