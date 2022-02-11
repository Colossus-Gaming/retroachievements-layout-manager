using System;
using System.IO;
using System.Linq;

namespace Retro_Achievement_Tracker.Models
{
    public sealed class StreamLabelManager
    {
        private static StreamLabelManager instance = new StreamLabelManager();
        private StreamLabelManager()
        {

        }
        public static StreamLabelManager Instance
        {
            get
            {
                return instance;
            }
        }
        public void WriteFocusStreamLabels(Achievement currentlyViewingAchievement)
        {
            if (currentlyViewingAchievement != null)
            {
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/title.txt", currentlyViewingAchievement.Title);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/description.txt", currentlyViewingAchievement.Description);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/points.txt", currentlyViewingAchievement.Points.ToString());
            }
            else
            {
                ClearFocusStreamLabels();
            }
        }

        public void ClearFocusStreamLabels()
        {
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/title.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/description.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/points.txt", string.Empty);
        }

        public void WriteLastFiveStreamLabels(UserSummary userSummary)
        {
            if (userSummary != null && userSummary.Achievements != null && userSummary.Achievements.Count > 0)
            {
                for (int i = 0; i < userSummary.Achievements.Count; i++)
                {
                    if (userSummary.Achievements[i].HardcoreAchieved)
                    {
                        File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-title.txt", userSummary.Achievements[i].Title);
                        File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-description.txt", userSummary.Achievements[i].Description);
                        File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-points.txt", userSummary.Achievements[i].Points.ToString());
                    }
                    else
                    {
                        File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-title.txt", string.Empty);
                        File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-description.txt", string.Empty);
                        File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-points.txt", string.Empty);
                    }
                }
            }
        }

        public void WriteStatsStreamLabels(UserSummary userSummary, GameInfoAndProgress gameInfoAndProgress)
        {
            if (userSummary != null)
            {
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/rank.txt", userSummary.Rank.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/awards.txt", userSummary.Awards.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/ratio.txt", userSummary.RetroRatio);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/points.txt", userSummary.TotalPoints.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/true-points.txt", userSummary.TotalTruePoints.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/game-ratio.txt", gameInfoAndProgress.GameTruePointsPossible == 0 ? "0" : (Convert.ToDecimal(gameInfoAndProgress.GameTruePointsPossible) / Convert.ToDecimal(userSummary.GamePointsPossible)).ToString("0.00"));
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/game-points.txt", userSummary.GamePointsEarned == 0 ? "0 / 0" : userSummary.GamePointsEarned.ToString() + "/" + userSummary.GamePointsPossible.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/game-true-points.txt", gameInfoAndProgress.GameTruePointsEarned == 0 ? "0 / 0" : gameInfoAndProgress.GameTruePointsEarned.ToString() + "/" + gameInfoAndProgress.GameTruePointsPossible.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/game-achievements.txt", userSummary.Achievements.Count(achievement => achievement.HardcoreAchieved).ToString() + "/" + userSummary.Achievements.Count);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/completed.txt", (userSummary.Achievements.Count == 0 ? 0 : Convert.ToInt32(Convert.ToDecimal(userSummary.Achievements.Count(achievement => achievement.HardcoreAchieved)) / Convert.ToDecimal(userSummary.Achievements.Count) * 200)) + " %");
            }
        }
        public void WriteGameInfoStreamLabels(GameInfoAndProgress gameInfo)
        {
            if (gameInfo != null)
            {
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/title.txt", gameInfo.Title);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/console.txt", gameInfo.ConsoleName);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/developer.txt", gameInfo.Developer);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/publisher.txt", gameInfo.Publisher);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/genre.txt", gameInfo.Genre);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/release-date.txt", gameInfo.Released);
            }
        }

        public void ClearAllStreamLabels()
        {
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/title.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/description.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/points.txt", string.Empty);

            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/title.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/console.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/developer.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/publisher.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/genre.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/release-date.txt", string.Empty);

            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/rank.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/awards.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/ratio.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/points.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/true-points.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/game-ratio.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/game-points.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/game-true-points.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/game-achievements.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/completed.txt", string.Empty);

            for (int i = 0; i < 5; i++)
            {
                    File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-title.txt", string.Empty);
                    File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-description.txt", string.Empty);
                    File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-points.txt", string.Empty);
            }
        }
    }
}
