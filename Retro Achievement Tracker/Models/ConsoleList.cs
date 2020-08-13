using Newtonsoft.Json;
using System.Collections.Generic;

namespace Retro_Achievement_Tracker.Models
{
    [JsonConverter(typeof(ConsoleListConverter))]
    public partial class ConsoleList
    {
        public Dictionary<string, string> Consoles { get; set; }
    }
}
