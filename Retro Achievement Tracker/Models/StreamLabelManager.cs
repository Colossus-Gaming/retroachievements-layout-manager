using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Retro_Achievement_Tracker.Models
{
    public sealed class StreamLabelManager
    {
        private static readonly StreamLabelManager instance = new StreamLabelManager();
        private Stopwatch StreamLabelsStopwatch;
        private Task StreamLabelsTask;
        private readonly ConcurrentQueue<Tuple<Task, bool>> StreamLabelsRequests;
        private StreamLabelManager()
        {
            StreamLabelsRequests = new ConcurrentQueue<Tuple<Task, bool>>();
            StreamLabelsStopwatch = new Stopwatch();
            StreamLabelsTask = Task.Factory.StartNew(() => { });
        }
        public static StreamLabelManager Instance
        {
            get
            {
                return instance;
            }
        }
        private Tuple<Task, bool> StreamLabelDequeue()
        {
            StreamLabelsRequests.TryDequeue(out Tuple<Task, bool> task);

            return task;
        }
        public void RunNotifications()
        {
            if (StreamLabelsRequests.Count > 0 && !StreamLabelsStopwatch.IsRunning)
            {
                StreamLabelsTask = Task.Factory.StartNew(RunStreamLabelsTask, System.Threading.CancellationToken.None);
            }
        }
        private async void RunStreamLabelsTask()
        {
            StreamLabelsStopwatch = Stopwatch.StartNew();

            while (StreamLabelsStopwatch.IsRunning)
            {
                Tuple<Task, bool> notificationRequest = StreamLabelDequeue();

                notificationRequest.Item1.Start();

                if (notificationRequest.Item2)
                {
                    await Task.Delay(1000);
                }

                if (StreamLabelsRequests.Count == 0)
                {
                    StreamLabelsStopwatch.Stop();
                }
            }
        }
        public void EnqueueFocus(Achievement currentlyViewingAchievement)
        {
            WriteFocusStreamLabels(currentlyViewingAchievement);
        }
        public void ClearFocus()
        {
            ClearFocusStreamLabels();
        }
        public void EnqueueAlert(Achievement currentlyViewingAchievement)
        {
            WriteAlertsStreamLabels(currentlyViewingAchievement);
        }
        public void EnqueueAlert(GameInfo gameInfo)
        {
            WriteAlertsStreamLabels(gameInfo);
        }
        public void EnqueueUserInfo(UserSummary userSummary)
        {
            WriteUserInfoStreamLabels(userSummary);
        }
        public void EnqueueGameInfo(GameInfo gameInfo)
        {
            WriteGameInfoStreamLabels(gameInfo);
        }
        public void EnqueueRecentUnlocks(GameInfo gameInfo)
        {
            WriteLastFiveStreamLabels(gameInfo);
        }
        private void WriteFocusStreamLabels(Achievement currentlyViewingAchievement)
        {
            if (currentlyViewingAchievement != null)
            {
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/title.txt", currentlyViewingAchievement.Title);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/description.txt", currentlyViewingAchievement.Description);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/points.txt", currentlyViewingAchievement.Points.ToString());

                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/data.json", JsonConvert.SerializeObject(currentlyViewingAchievement));
            }
            else
            {
                ClearFocusStreamLabels();
            }
        }

        private void ClearFocusStreamLabels()
        {
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/title.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/description.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/points.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/data.json", "{}");
        }

        private void WriteLastFiveStreamLabels(GameInfo gameInfo)
        {
            if (gameInfo != null && gameInfo.Achievements != null && gameInfo.Achievements.Count > 0)
            {
                int max = Math.Min(5, gameInfo.Achievements.Count);

                for (int i = 0; i < max; i++)
                {
                    if (gameInfo.Achievements[i].DateEarned.HasValue)
                    {
                        File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-title.txt", gameInfo.Achievements[i].Title);
                        File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-description.txt", gameInfo.Achievements[i].Description);
                        File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-points.txt", gameInfo.Achievements[i].Points.ToString());
                        File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-data.json", JsonConvert.SerializeObject(gameInfo));
                    }
                    else
                    {
                        File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-title.txt", string.Empty);
                        File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-description.txt", string.Empty);
                        File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-points.txt", string.Empty);
                        File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-data.json", "{}");
                    }
                }
            }
        }

        private void WriteUserInfoStreamLabels(UserSummary userSummary)
        {
            if (userSummary != null)
            {
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/user-info/rank.txt", userSummary.Rank == 0 ? "No Rank" : userSummary.Rank.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/user-info/ratio.txt", userSummary.RetroRatio);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/user-info/points.txt", userSummary.TotalPoints.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/user-info/true-points.txt", userSummary.TotalTruePoints.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/user-info/data.json", JsonConvert.SerializeObject(userSummary));
            }
        }
        private void WriteGameInfoStreamLabels(GameInfo gameInfo)
        {
            if (gameInfo != null)
            {
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/title.txt", gameInfo.Title);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/console.txt", gameInfo.ConsoleName);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/developer.txt", gameInfo.Developer);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/publisher.txt", gameInfo.Publisher);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/genre.txt", gameInfo.Genre);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/released.txt", gameInfo.Released);

                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/ratio.txt", gameInfo.GameTruePointsPossible == 0 ? "0" : (Convert.ToDecimal(gameInfo.GameTruePointsPossible) / Convert.ToDecimal(gameInfo.GamePointsPossible)).ToString("0.00"));
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/points.txt", gameInfo.GamePointsPossible == 0 ? "0 / 0" : gameInfo.GamePointsEarned.ToString() + " / " + gameInfo.GamePointsPossible.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/true-points.txt", gameInfo.GameTruePointsPossible == 0 ? "0 / 0" : gameInfo.GameTruePointsEarned.ToString() + " / " + gameInfo.GameTruePointsPossible.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/achievements.txt", gameInfo.AchievementsEarned + " / " + (gameInfo.Achievements == null ? 0 : gameInfo.Achievements.Count));
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/completed.txt", (gameInfo.Achievements == null || gameInfo.Achievements.Count == 0 ? 0 : Convert.ToInt32(Convert.ToDecimal(gameInfo.Achievements.Count(achievement => achievement.DateEarned.HasValue)) / Convert.ToDecimal(gameInfo.Achievements == null ? 0 : gameInfo.Achievements.Count) * 100)) + " %");
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/data.json", JsonConvert.SerializeObject(gameInfo));
            }
        }
        private void WriteAlertsStreamLabels(Achievement achievement)
        {
            if (achievement != null)
            {
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/alerts/title.txt", achievement.Title);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/alerts/description.txt", achievement.Description);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/alerts/points.txt", achievement.Points.ToString());

                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/alerts/data.json", JsonConvert.SerializeObject(achievement));
            }
            else
            {
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/alerts/data.json", "{}");
            }
        }
        private void WriteAlertsStreamLabels(GameInfo gameInfo)
        {
            if (gameInfo != null)
            {
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/alerts/data.json", JsonConvert.SerializeObject(gameInfo));
            }
            else
            {
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/alerts/data.json", "{}");
            }
        }
        public void ClearAllStreamLabels()
        {
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/title.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/description.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/points.txt", string.Empty);

            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/data.json", "{}");

            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/alerts/data.json", "{}");

            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/title.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/console.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/developer.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/publisher.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/genre.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/released.txt", string.Empty);

            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/ratio.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/points.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/true-points.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/achievements.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/completed.txt", string.Empty);

            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/data.json", "{}");

            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/user-info/rank.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/user-info/awards.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/user-info/ratio.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/user-info/points.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/user-info/true-points.txt", string.Empty);

            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/user-info/data.json", "{}");

            for (int i = 0; i < 5; i++)
            {
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-title.txt", string.Empty);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-description.txt", string.Empty);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-points.txt", string.Empty);

                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-data.json", "{}");
            }
        }
    }
}
