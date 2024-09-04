using Newtonsoft.Json;

namespace Retro_Achievement_Tracker.Models
{
    [JsonConverter(typeof(UserRankAndScoreConverter))]
    public partial class UserRankAndScore
    {
        public int Rank { get; set; }
        public int Score { get; set; }
    }
}
