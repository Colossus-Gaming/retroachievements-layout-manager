namespace Retro_Achievement_Tracker
{
    using Newtonsoft.Json;
    using Retro_Achievement_Tracker.Models;
    using System;
    using System.Collections.Generic;

    [JsonConverter(typeof(UserSummaryConverter))]
    public partial class UserSummary
    {
        public int LastGameID { get; set; }
        public int TotalPoints { get; set; }
        public int TotalTruePoints { get; set; }
        public int Rank { get; set; }
        public int Awards { get; set; }
        public string Motto { get; set; }
        public string UserPic { get; set; }
        public string Status { get; set; }
        public List<GameAchievementSummary> GameAchievementSummaries { get; set; }
        public List<GameSummary> GameSummaries { get; set; }
        public List<Achievement> RecentAchievements { get; set; }
        public string RetroRatio
        {
            set
            {

            }
            get
            {
                return ((float)TotalTruePoints / (float)TotalPoints).ToString("0.00") + "%";
            }
        }
    }

    [JsonConverter(typeof(GameSummaryConverter))]
    public class GameSummary
    {
        public int GameID { get; set; }
        public int ConsoleID { get; set; }
        public string ConsoleName { get; set; }
        public string Title { get; set; }
        public string ImageIcon { get; set; }
        public DateTime? LastPlayed { get; set; }
    }


    [JsonConverter(typeof(GameAchievementSummaryConverter))]
    public class GameAchievementSummary
    {
        public int GameId { get; set; }
        public int NumPossibleAchievements { get; set; }
        public int PossibleScore { get; set; }
        public int NumAchieved { get; set; }
        public int ScoreAchieved { get; set; }
        public int NumAchievedHardcore { get; set; }
        public int ScoreAchievedHardcore { get; set; }
    }

    [JsonConverter(typeof(AchievementConverter))]
    public partial class Achievement : IEquatable<Achievement>, IComparable<Achievement>
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string GameTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public int TrueRatio { get; set; }
        public string BadgeNumber { get; set; }
        public bool IsAwarded { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime? DateEarned { get; set; }

        public int CompareTo(Achievement other)
        {
            if (other.DateEarned.HasValue)
            {
                if (DateEarned.HasValue)
                {
                    if (DateEarned.Value == other.DateEarned.Value)
                    {
                        return DisplayOrder.CompareTo(other.DisplayOrder);
                    }
                    return DateEarned.Value < other.DateEarned.Value ? -1 : 1;
                }
                return -1;
            }
            else if (DateEarned.HasValue)
            {
                return 1;
            }
            return DisplayOrder.CompareTo(other.DisplayOrder);
        }

        public bool Equals(Achievement other)
        {
            return other != null && Id == other.Id;
        }        
    }
}