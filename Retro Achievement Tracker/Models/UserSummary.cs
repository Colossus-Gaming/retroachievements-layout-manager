namespace Retro_Achievement_Tracker
{
    using Newtonsoft.Json;
    using Retro_Achievement_Tracker.Models;
    using System;
    using System.Collections.Generic;

    [JsonConverter(typeof(UserSummaryConverter))]
    public partial class UserSummary : IEquatable<UserSummary>, ICloneable
    {
        public string UserName { get; set; }
        public int LastGameID { get; set; }
        public int TotalPoints { get; set; }
        public int TotalTruePoints { get; set; }
        public int Rank { get; set; }
        public string Motto { get; set; }
        public string UserPic { get; set; }
        public List<Achievement> Achievements { get; set; }
        
        public string RetroRatio
        {
            get
            {
                return ((float)TotalTruePoints / TotalPoints).ToString("0.00");
            }
        }
        public bool Equals(UserSummary other)
        {
            return other != null 
                && LastGameID == other.LastGameID
                && TotalPoints == other.TotalPoints
                && TotalTruePoints == other.TotalTruePoints
                && Rank == other.Rank;
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }    
}