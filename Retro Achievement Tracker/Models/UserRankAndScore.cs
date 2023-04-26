using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro_Achievement_Tracker.Models
{
    [JsonConverter(typeof(UserRankAndScoreConverter))]
    public partial class UserRankAndScore
    {
        public int Rank { get; set; }
        public int Score { get; set; }
    }
}
