using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Retro_Achievement_Tracker
{
    [JsonConverter(typeof(GameProgressConverter))]
    public partial class GameProgress
    {
        public long Id { get; set; }

        public string Title { get; set; }
        public long ConsoleId { get; set; }
        public long ForumTopicId { get; set; }
        public long Flags { get; set; }
        public string ImageIcon { get; set; }
        public string ImageTitle { get; set; }
        public string ImageIngame { get; set; }
        public string ImageBoxArt { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public string Genre { get; set; }
        public string Released { get; set; }
        public bool IsFinal { get; set; }
        public string ConsoleName { get; set; }
        public string RichPresencePatch { get; set; }
        public long NumAchievements { get; set; }
        public string NumDistinctPlayersCasual { get; set; }
        public string NumDistinctPlayersHardcore { get; set; }
        public List<Achievement> Achievements { get; set; }
        public long NumAwardedToUser { get; set; }
        public long NumAwardedToUserHardcore { get; set; }
        public string UserCompletion { get; set; }
        public string UserCompletionHardcore { get; set; }
        public string PointsPossible
        {
            set
            {

            }
            get
            {
                return Achievements
                    .Sum(achievement => achievement.Points)
                    .ToString();
            }
        }
        public string TruePointsPossible
        {
            set
            {

            }
            get
            {
                return Achievements
                    .Sum(achievement => achievement.TrueRatio)
                    .ToString();
            }
        }
        public string PointsEarned
        {
            set
            {

            }
            get
            {
                return Achievements
                    .Where(achievement => achievement.DateEarned.HasValue)
                    .Sum(achievement => achievement.Points)
                    .ToString();
            }
        }
        public string TruePointsEarned
        {
            set
            {

            }
            get
            {
                return Achievements
                    .Where(achievement => achievement.DateEarned.HasValue)
                    .Sum(achievement => achievement.TrueRatio)
                    .ToString();
            }
        }
    }
}
