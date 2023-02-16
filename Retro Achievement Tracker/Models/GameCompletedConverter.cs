using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

namespace Retro_Achievement_Tracker.Models
{
    class GameCompletedConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject item = JObject.Load(reader);
            GameCompleted GameCompleted = new GameCompleted();

            if (existingValue != null)
            {
                GameCompleted = (GameCompleted)existingValue;
            }

            JToken NumAwarded = item["NumAwarded"];
            JToken MaxPossible = item["MaxPossible"];
            JToken HardcoreMode = item["HardcoreMode"];

            if (NumAwarded != null)
            {
                if (NumAwarded.Type == JTokenType.String)
                {
                    GameCompleted.AchievementsEarned = Convert.ToInt32(NumAwarded);
                }
            }


            if (MaxPossible != null)
            {
                if (MaxPossible.Type == JTokenType.String)
                {
                    GameCompleted.AchievementsPossible = Convert.ToInt32(MaxPossible);
                }
            }

            if (HardcoreMode != null)
            {
                if (HardcoreMode.Type == JTokenType.String)
                {
                    GameCompleted.HardcoreMode = HardcoreMode.ToString() == "1";
                }
            }

            return GameCompleted;
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
                        jo.Add(char.ToLowerInvariant(prop.Name[0]) + prop.Name.Substring(1), JToken.FromObject(propVal, serializer));
                    }
                }
            }
            jo.WriteTo(writer);
        }
    }
}