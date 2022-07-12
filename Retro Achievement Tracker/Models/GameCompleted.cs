using Newtonsoft.Json;

namespace Retro_Achievement_Tracker.Models
{
    [JsonConverter(typeof(GameCompletedConverter))]
    public partial class GameCompleted
    {
        public int AchievementsEarned { get; set; }
        public int AchievementsPossible { get; set; }
        public bool HardcoreMode { get; set; }
    }
}
