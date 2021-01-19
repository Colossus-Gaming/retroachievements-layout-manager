using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Retro_Achievement_Tracker.Models
{
    class ConsoleListConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            ConsoleList ConsoleList = new ConsoleList();
            JObject item = JObject.Load(reader);

            if (existingValue != null)
            {
                ConsoleList = (ConsoleList)existingValue;
            }

            JToken Console = item["console"];

            if (JTokenType.Array == Console.Type)
            {
                ConsoleList.Consoles = new Dictionary<string, string>();

                Console.ToArray()[0].ToList().ForEach((JToken jToken) =>
                {
                    ConsoleList.Consoles.Add(jToken["ID"].ToString(), jToken["Name"].ToString());
                });
            }
            return ConsoleList;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

        }
    }
}
