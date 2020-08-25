using CefSharp;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Forms
{
    public partial class NotificationLayoutWindow : Form
    {
        private static readonly string CALLER_ID = "NotificationWindow";
        public Action<string> LogCallback { get; internal set; }
        public Achievement MostRecentAchievement { get; set; }
        private bool HasMasteredGame;
        private Task NotificationsTask;
        private readonly ObservableCollection<NotificationRequest> NotificationRequests;
        private Stopwatch stopwatch;

        private CancellationTokenSource tokenSource2 = new CancellationTokenSource();

        public NotificationLayoutWindow()
        {
            InitializeComponent();

            NotificationRequests = new ObservableCollection<NotificationRequest>();
            NotificationRequests.CollectionChanged += NotificationRequests_CollectionChanged;

            stopwatch = new Stopwatch();

            SetupNotificationsTask();
        }

        private void NotificationRequests_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add && NotificationRequests.Count > 0 && !stopwatch.IsRunning && NotificationsTask.Status != TaskStatus.Running)
            {
                SetupNotificationsTask();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.chromiumWebBrowser.LoadHtml(Resources.DefaultNotificationWindow);
            this.chromiumWebBrowser.FrameLoadEnd += PromptUserInput;
        }

        private void SetupNotificationsTask()
        {
            NotificationsTask = Task.Factory.StartNew(async () =>
            {
                long delayInMilli = 0;

                while (NotificationRequests.Count > 0 || stopwatch.IsRunning)
                {
                    if (tokenSource2.Token.IsCancellationRequested)
                    {
                        EnableUserInput();
                        tokenSource2.Token.ThrowIfCancellationRequested();
                    }

                    DisableUserInput();

                    if (!stopwatch.IsRunning)
                    {
                        if (!this.IsDisposed)
                        {
                            if (NotificationRequests.Count > 0)
                            {
                                NotificationRequest notificationRequest = NotificationRequestDequeue();

                                if (tokenSource2.Token.IsCancellationRequested)
                                {
                                    EnableUserInput();
                                    tokenSource2.Token.ThrowIfCancellationRequested();
                                }

                                if (notificationRequest != null)
                                {
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
                        }
                    }
                    else
                    {
                        if (stopwatch.ElapsedMilliseconds > delayInMilli)
                        {
                            stopwatch.Stop();
                            delayInMilli = 0;
                        }
                        else
                        {
                            await Task.Delay(100);
                        }
                    }
                }
                EnableUserInput();
            }, tokenSource2.Token);
        }

        private void DisableUserInput()
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
                tokenSource2.Cancel();
            }
        }

        private NotificationRequest NotificationRequestDequeue()
        {
            try
            {
                NotificationRequest notificationRequest = NotificationRequests[0];

                NotificationRequests.Remove(notificationRequest);

                return notificationRequest;
            }
            catch
            {
                return null;
            }
        }

        private void EnableUserInput()
        {
            if (!this.IsDisposed)
            {
                Invoke((MethodInvoker)delegate
                {
                    this.showRecentAchievementButton.Enabled = true;
                    this.showGameMasteryButton.Enabled = true;
                    this.replayAchievementButton.Enabled = true;
                    this.replayGameMasteryButton.Enabled = HasMasteredGame;
                });
            }
        }

        public void EnqueueAchievementNotification(Achievement achievement)
        {
            NotificationRequest notificationRequest = new NotificationRequest
            {
                Achievement = achievement
            };

            NotificationRequests.Add(notificationRequest);
            StartNotificationTask();
        }

        public void EnqueueMasteryNotification(GameSummary currentGame, GameAchievementSummary currentAchievementSummary)
        {
            NotificationRequest notificationRequest = new NotificationRequest
            {
                GameSummary = currentGame,
                GameAchievementSummary = currentAchievementSummary
            };

            NotificationRequests.Add(notificationRequest);
            StartNotificationTask();
        }

        private void StartNotificationTask()
        {
            if (NotificationsTask.Status != TaskStatus.Running)
            {
                SetupNotificationsTask();
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

                    LogCallback(CALLER_ID +"[achievementNotification] Sending: [" + script + "]");

                    try
                    {
                        chromiumWebBrowser.ExecuteScriptAsync(script, TimeSpan.FromSeconds(2));
                    }
                    catch (Exception ex)
                    {
                        LogCallback(CALLER_ID +"[achievementNotification]" + ex.Message);
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

                    LogCallback(CALLER_ID +"[masteryNotification] Sending: [" + script + "]");

                    try
                    {
                        chromiumWebBrowser.ExecuteScriptAsync(script, TimeSpan.FromSeconds(2));
                    }
                    catch (Exception ex)
                    {
                        LogCallback(CALLER_ID +"[masteryNotification]" + ex.Message);
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

                LogCallback(CALLER_ID +"[promptUser] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(2));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID +"[promptUser]" + ex.Message);
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
