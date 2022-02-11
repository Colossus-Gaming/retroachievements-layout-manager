using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro_Achievement_Tracker.Models
{
    [JsonConverter(typeof(GameInfoAndProgressConverter))]
    public partial class GameInfoAndProgress
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long ConsoleId { get; set; }
        public string ImageIcon { get; set; }
        public string ImageTitle { get; set; }
        public string ImageIngame { get; set; }
        public string ImageBoxArt { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public string Genre { get; set; }
        public string Released { get; set; }
        public string ConsoleName { get; set; }
        public int AchievementsEarned { get; set; }
        public int AchievementsPossible { get; set; }
        public int PointsEarned { get; set; }
        public int PointsPossible { get; set; }
        public int RetroRatio { get; set; }
        public List<Achievement> Achievements { get; set; }
        public int GameTruePointsPossible
        {
            get
            {
                if (Achievements != null)
                {
                    return Achievements.Sum(x => x.TrueRatio);
                }
                return 0;
            }
        }
        public int GameTruePointsEarned
        {
            get
            {
                if (Achievements != null)
                {
                    return Achievements.FindAll(x => x.HardcoreAchieved).Sum(x => x.TrueRatio);
                }
                return 0;
            }
        }
    }
}
