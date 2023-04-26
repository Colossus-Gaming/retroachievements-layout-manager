using Newtonsoft.Json;
using System;

namespace Retro_Achievement_Tracker.Models
{
    [JsonConverter(typeof(AchievementConverter))]
    public partial class Achievement : IEquatable<Achievement>, IComparable<Achievement>, ICloneable
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string GameTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public int TrueRatio { get; set; }
        public string BadgeUri { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime? DateEarned { get; set; }

        public int CompareTo(Achievement other)
        {
            if (other.DateEarned.HasValue)
            {
                if (DateEarned.HasValue)
                {
                    if (DateEarned.Value.Equals(other.DateEarned.Value))
                    {
                        if (DisplayOrder.Equals(other.DisplayOrder))
                        {
                            return Id.CompareTo(other.Id);
                        }
                        return DisplayOrder.CompareTo(other.DisplayOrder);
                    }
                    return DateEarned.Value.CompareTo(other.DateEarned.Value);
                }
                return -1;
            }
            else if (DateEarned.HasValue)
            {
                return 1;
            }
            if (DisplayOrder.Equals(other.DisplayOrder))
            {
                return Id.CompareTo(other.Id);
            }
            return other.DisplayOrder.CompareTo(DisplayOrder);
        }

        public bool Equals(Achievement other)
        {
            return other != null && Id == other.Id;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
