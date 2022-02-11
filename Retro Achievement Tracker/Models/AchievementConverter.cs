using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Retro_Achievement_Tracker.Models
{
    class AchievementConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Achievement Achievement = new Achievement();
            JObject item = JObject.Load(reader);

            if (existingValue != null)
            {
                Achievement = (Achievement)existingValue;
            }

            JToken ID = item["ID"];
            JToken GameID = item["GameID"];
            JToken GameTitle = item["GameTitle"];
            JToken Title = item["Title"];
            JToken Description = item["Description"];
            JToken Points = item["Points"];
            JToken TrueRatio = item["TrueRatio"];
            JToken HardcoreAchieved = item["HardcoreAchieved"];
            JToken DateAwarded = item["DateAwarded"];
            JToken DateEarnedHardcore = item["DateEarnedHardcore"];
            JToken BadgeName = item["BadgeName"];
            JToken DisplayOrder = item["DisplayOrder"];

            if (ID != null)
            {
                Achievement.Id = int.Parse(ID.ToString());
            }
            if (GameID != null)
            {
                Achievement.GameId = int.Parse(GameID.ToString());
            }
            if (GameTitle != null)
            {
                Achievement.GameTitle = GameTitle.ToString();
            }
            if (Description != null)
            {
                Achievement.Description = Description.ToString();
            }
            if (Title != null)
            {
                Achievement.Title = Title.ToString();
            }
            if (Points != null)
            {
                Achievement.Points = int.Parse(Points.ToString());
            }
            if (TrueRatio != null)
            {
                Achievement.TrueRatio = int.Parse(TrueRatio.ToString());
            }

            if (DateAwarded != null && !string.IsNullOrEmpty(DateAwarded.ToString()))
            {
                Achievement.DateEarned = DateTime.Parse(DateAwarded.ToString());
            }
            if (DateEarnedHardcore != null && !string.IsNullOrEmpty(DateEarnedHardcore.ToString()))
            {
                Achievement.DateEarned = DateTime.Parse(DateEarnedHardcore.ToString());
            }
            if (BadgeName != null)
            {
                Achievement.BadgeNumber = Convert.ToString(BadgeName);
            }
            if (DisplayOrder != null)
            {
                Achievement.DisplayOrder = int.Parse(DisplayOrder.ToString());
            }

            Achievement.HardcoreAchieved = Achievement.DateEarned.HasValue || (HardcoreAchieved != null && "1".Equals(HardcoreAchieved.ToString()));

            return Achievement;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

        }
    }
}
