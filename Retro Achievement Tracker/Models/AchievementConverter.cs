using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

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
            JToken AchievementID = item["AchievementID"];
            JToken GameID = item["GameID"];
            JToken Title = item["Title"];
            JToken Description = item["Description"];
            JToken Points = item["Points"];
            JToken TrueRatio = item["TrueRatio"];
            JToken Date = item["Date"];
            JToken DateEarned = item["DateEarnedHardcore"];
            JToken BadgeName = item["BadgeName"];
            JToken DisplayOrder = item["DisplayOrder"];

            if (ID != null)
            {
                Achievement.Id = int.Parse(ID.ToString());
            }
            if (AchievementID != null)
            {
                Achievement.Id = int.Parse(AchievementID.ToString());
            }
            if (GameID != null)
            {
                Achievement.GameId = int.Parse(GameID.ToString());
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
            if (Date != null && !string.IsNullOrEmpty(Date.ToString()))
            {
                Achievement.DateEarned = DateTime.Parse(Date.ToString());
            }
            if (DateEarned != null && !string.IsNullOrEmpty(DateEarned.ToString()))
            {
                Achievement.DateEarned = DateTime.Parse(DateEarned.ToString());
            }
            if (BadgeName != null)
            {
                Achievement.BadgeUri = Constants.RETRO_ACHIEVEMENTS_MEDIA_URL + "/Badge/" + Convert.ToString(BadgeName) + ".png";
            }
            if (DisplayOrder != null)
            {
                Achievement.DisplayOrder = int.Parse(DisplayOrder.ToString());
            }

            return Achievement;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject jo = new JObject();
            Type type = value.GetType();

            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (prop.CanRead)
                {
                    object propVal = prop.GetValue(value, null);
                    if (propVal != null && !propVal.GetType().Name.Equals("List`1"))
                    {
                        if (propVal.GetType().Name.Equals("DateTime"))
                        {
                            jo.Add(char.ToLowerInvariant(prop.Name[0]) + prop.Name.Substring(1), JToken.FromObject(((DateTime)propVal).ToString(), serializer));
                        } else
                        {
                            jo.Add(char.ToLowerInvariant(prop.Name[0]) + prop.Name.Substring(1), JToken.FromObject(propVal, serializer));
                        }
                    }
                }
            }
            jo.WriteTo(writer);
        }
    }
}
