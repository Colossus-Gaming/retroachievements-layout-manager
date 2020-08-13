using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Retro_Achievement_Tracker
{
    [JsonConverter(typeof(GameProgressConverter))]
    public partial class GameProgress
    {
        private string _title;

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
        public String NumDistinctPlayersCasual { get; set; }
        public String NumDistinctPlayersHardcore { get; set; }
        public List<Achievement> Achievements { get; set; }
        public long NumAwardedToUser { get; set; }
        public long NumAwardedToUserHardcore { get; set; }
        public string UserCompletion { get; set; }
        public string UserCompletionHardcore { get; set; }
    }
}
