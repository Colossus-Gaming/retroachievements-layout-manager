using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
