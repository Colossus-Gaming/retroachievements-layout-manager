using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Retro_Achievement_Tracker.Models
{
    class UserRankAndScoreConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            UserRankAndScore UserRankAndScore = new UserRankAndScore();
            JObject item = JObject.Load(reader);

            if (existingValue != null)
            {
                UserRankAndScore = (UserRankAndScore)existingValue;
            }

            JToken Rank = item["Rank"];
            JToken Score = item["Score"];

            if (Rank != null)
            {
                UserRankAndScore.Rank = int.Parse(Rank.ToString());
            }
            if (Score != null)
            {
                UserRankAndScore.Score = int.Parse(Score.ToString());
            }

            return UserRankAndScore;
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
                        }
                        else
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
