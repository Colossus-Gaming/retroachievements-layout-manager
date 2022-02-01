using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Retro_Achievement_Tracker
{
    [JsonConverter(typeof(GameProgressConverter))]
    public partial class GameProgress
    {
        private List<Achievement> _achievements;
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
        public List<Achievement> Achievements
        {
            get
            {
                if (_achievements == null)
                {
                    _achievements = new List<Achievement>();
                }
                return _achievements;
            }
            set
            {
                _achievements = value;
            }
        }
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
                if (Achievements != null)
                {
                    string total = Achievements
                    .Sum(achievement => achievement.Points)
                    .ToString();

                    return total == "0" ? "1" : total;
                }
                return "1";
            }
        }
        public string TruePointsPossible
        {
            set
            {

            }
            get
            {
                if (Achievements != null)
                {
                    string total = Achievements
                    .Sum(achievement => achievement.TrueRatio)
                    .ToString();

                    return total == "0" ? "1" : total;
                }
                return "1";
            }
        }
        public string PointsEarned
        {
            set
            {

            }
            get
            {
                if (Achievements != null)
                {
                    string total = Achievements
                        .Where(achievement => achievement.DateEarned.HasValue)
                        .Sum(achievement => achievement.Points)
                        .ToString();

                    return total == "0" ? "1" : total;
                }
                return "1";
            }
        }
        public string TruePointsEarned
        {
            set
            {

            }
            get
            {
                if (Achievements != null)
                {
                    string total = Achievements
                    .Where(achievement => achievement.DateEarned.HasValue)
                    .Sum(achievement => achievement.TrueRatio)
                    .ToString();

                    return total == "0" ? "1" : total;
                }
                return "1";
            }
        }
    }
}
