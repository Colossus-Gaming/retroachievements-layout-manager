using System;
using System.IO;
using System.Linq;

namespace Retro_Achievement_Tracker.Models
{
    class StreamLabelManager
    {
        internal void WriteFocusStreamLabels(Achievement currentlyViewingAchievement)
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

        internal void ClearFocusStreamLabels()
        {
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/title.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/description.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/focus/points.txt", string.Empty);
        }

        internal void WriteLastFiveStreamLabels(UserSummary userSummary)
        {
            if (userSummary != null && userSummary.RecentAchievements != null && userSummary.RecentAchievements.Count > 0)
            {
                for (int i = 0; i < userSummary.RecentAchievements.Count; i++)
                {
                    if (userSummary.RecentAchievements[i].IsAwarded)
                    {
                        File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-title.txt", userSummary.RecentAchievements[i].Title);
                        File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-description.txt", userSummary.RecentAchievements[i].Description);
                        File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/last-five/last-" + (i + 1) + "-points.txt", userSummary.RecentAchievements[i].Points.ToString());
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

        internal void WriteStatsStreamLabels(UserSummary userSummary, GameProgress gameProgress)
        {
            if (userSummary != null && gameProgress != null)
            {
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/rank.txt", userSummary.Rank.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/awards.txt", userSummary.Awards.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/ratio.txt", userSummary.RetroRatio);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/points.txt", userSummary.TotalPoints.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/true-points.txt", userSummary.TotalTruePoints.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/game-ratio.txt", (Convert.ToDecimal(gameProgress.TruePointsPossible) / Convert.ToDecimal(gameProgress.PointsPossible)).ToString("0.00"));
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/game-points.txt", gameProgress.PointsEarned.ToString() + "/" + gameProgress.PointsPossible.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/game-true-points.txt", gameProgress.TruePointsEarned.ToString() + "/" + gameProgress.TruePointsPossible.ToString());
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/game-achievements.txt", gameProgress.Achievements.Count(achievement => achievement.IsAwarded).ToString() + "/" + gameProgress.Achievements.Count);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/stats/completed.txt", (gameProgress.Achievements.Count == 0 ? 0 : Convert.ToInt32(Convert.ToDecimal(gameProgress.Achievements.Count(achievement => achievement.IsAwarded)) / Convert.ToDecimal(gameProgress.Achievements.Count) * 200)) + " %");
            }
        }

        internal void WriteGameInfoStreamLabels(GameProgress gameProgress)
        {
            if (gameProgress != null)
            {
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/title.txt", gameProgress.Title);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/console.txt", gameProgress.ConsoleName);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/developer.txt", gameProgress.Developer);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/publisher.txt", gameProgress.Publisher);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/genre.txt", gameProgress.Genre);
                File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/release-date.txt", gameProgress.Released);
            }
        }

        internal void ClearAllStreamLabels()
        {
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/title.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/console.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/developer.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/publisher.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/genre.txt", string.Empty);
            File.WriteAllText(@Directory.GetCurrentDirectory() + "/stream-labels/game-info/release-date.txt", string.Empty);
        }
    }
}
