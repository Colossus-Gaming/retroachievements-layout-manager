namespace Retro_Achievement_Tracker
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Retro_Achievement_Tracker.Models;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class GameInfoConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject item = JObject.Load(reader);
            GameInfo GameInfo = new GameInfo();

            if (existingValue != null)
            {
                GameInfo = (GameInfo)existingValue;
            }

            JToken ID = item["ID"];
            JToken Title = item["Title"];
            JToken ConsoleID = item["ConsoleID"];
            JToken ImageIcon = item["ImageIcon"];
            JToken ImageTitle = item["ImageTitle"];
            JToken ImageIngame = item["ImageIngame"];
            JToken ImageBoxArt = item["ImageBoxArt"];
            JToken Publisher = item["Publisher"];
            JToken Developer = item["Developer"];
            JToken Genre = item["Genre"];
            JToken Released = item["Released"];
            JToken Achievements = item["Achievements"];

            if (Released != null)
            {
                GameInfo.Released = Released.ToString();
            }

            if (Genre != null)
            {
                GameInfo.Genre = Genre.ToString();
            }

            if (Developer != null)
            {
                GameInfo.Developer = Developer.ToString();
            }
            if (Publisher != null)
            {
                GameInfo.Publisher = Publisher.ToString();
            }

            if (ImageBoxArt != null)
            {
                GameInfo.ImageBoxArt = Constants.RETRO_ACHIEVEMENTS_MEDIA_URL + ImageBoxArt.ToString();
            }

            if (ImageIngame != null)
            {
                GameInfo.ImageIngame = Constants.RETRO_ACHIEVEMENTS_MEDIA_URL + ImageIngame.ToString();
            }

            if (ImageTitle != null)
            {
                GameInfo.ImageTitle = Constants.RETRO_ACHIEVEMENTS_MEDIA_URL + ImageTitle.ToString();
            }

            if (ImageIcon != null)
            {
                GameInfo.BadgeUri = Constants.RETRO_ACHIEVEMENTS_MEDIA_URL + ImageIcon.ToString();
            }

            if (Title != null)
            {
                GameInfo.Title = Title.ToString();
            }

            if (ConsoleID != null)
            {
                GameInfo.ConsoleId = Convert.ToInt32(ConsoleID);
            }

            if (ID != null)
            {
                GameInfo.Id = Convert.ToInt32(ID);
            }

            if (Achievements != null)
            {
                GameInfo.Achievements = new List<Achievement>();

                foreach (JToken jobject in Achievements.Children<JToken>())
                {
                    foreach (JToken jobjectJr in jobject.Children<JToken>())
                    {
                        GameInfo.Achievements.Add(jobjectJr.ToObject<Achievement>());
                    }
                }
            }

            return GameInfo;
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