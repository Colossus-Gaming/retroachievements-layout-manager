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
        public int Rank { get; set; }
        public string Motto { get; set; }
        public string UserPic { get; set; }
        public string Status { get; set; }
        public List<GameAchievementSummary> GameAchievementSummaries { get; set; }
        public List<GameSummary> GameSummaries { get; set; }
        public List<Achievement> RecentAchievements { get; set; }
    }

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
        public string BadgeNumber { get; set; }
        public bool IsAwarded { get; set; }
        public DateTime? DateEarned { get; set; }

        public int CompareTo(Achievement other)
        {
            if (other.DateEarned.HasValue)
            {
                return this.DateEarned.HasValue ? this.DateEarned.Value.CompareTo(other.DateEarned.Value) : 1;
            }
            return this.DateEarned.HasValue ? -1 : this.Id.CompareTo(other.Id);
        }

        public bool Equals(Achievement other)
        {
            return other !=null && this.Id == other.Id;
        }
    }
}