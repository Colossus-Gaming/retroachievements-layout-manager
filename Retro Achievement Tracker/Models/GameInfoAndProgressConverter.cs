namespace Retro_Achievement_Tracker
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Retro_Achievement_Tracker.Models;
    using System;
    using System.Collections.Generic;

    public class GameInfoAndProgressConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject item = JObject.Load(reader);
            GameInfoAndProgress GameInfoAndProgress = new GameInfoAndProgress();

            if (existingValue != null)
            {
                GameInfoAndProgress = (GameInfoAndProgress)existingValue;
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
            JToken ConsoleName = item["ConsoleName"];
            JToken Achievements = item["Achievements"];

            if (ConsoleName != null)
            {
                if (ConsoleName.Type == JTokenType.String)
                {
                    GameInfoAndProgress.ConsoleName = ConsoleName.ToString();
                }
            }


            if (Released != null)
            {
                if (Released.Type == JTokenType.String)
                {
                    GameInfoAndProgress.Released = Released.ToString();
                }
            }

            if (Genre != null)
            {
                if (Genre.Type == JTokenType.String)
                {
                    GameInfoAndProgress.Genre = Genre.ToString();
                }
            }

            if (Developer != null)
            {
                if (Developer.Type == JTokenType.String)
                {
                    GameInfoAndProgress.Developer = Developer.ToString();
                }
            }
            if (Publisher != null)
            {
                if (Publisher.Type == JTokenType.String)
                {
                    GameInfoAndProgress.Publisher = Publisher.ToString();
                }
            }

            if (ImageBoxArt != null)
            {
                if (ImageBoxArt.Type == JTokenType.String)
                {
                    GameInfoAndProgress.ImageBoxArt = ImageBoxArt.ToString();
                }
            }

            if (ImageIngame != null)
            {
                if (ImageIngame.Type == JTokenType.String)
                {
                    GameInfoAndProgress.ImageIngame = ImageIngame.ToString(); ;
                }
            }

            if (ImageTitle != null)
            {
                if (ImageTitle.Type == JTokenType.String)
                {
                    GameInfoAndProgress.ImageTitle = ImageTitle.ToString();
                }
            }

            if (ImageIcon != null)
            {
                if (ImageIcon.Type == JTokenType.String)
                {
                    GameInfoAndProgress.ImageIcon = ImageIcon.ToString();
                }
            }

            if (Title != null)
            {
                if (Title.Type == JTokenType.String)
                {
                    GameInfoAndProgress.Title = Title.ToString();
                }
            }

            if (ConsoleID != null)
            {
                if (ConsoleID.Type == JTokenType.Integer)
                {
                    GameInfoAndProgress.ConsoleId = Convert.ToInt32(ConsoleID);
                }
            }

            if (ID != null)
            {
                if (ID.Type == JTokenType.Integer)
                {
                    GameInfoAndProgress.Id = Convert.ToInt32(ID);
                }
            }
            if (ConsoleName != null)
            {
                if (ConsoleName.Type == JTokenType.String)
                {
                    GameInfoAndProgress.ConsoleName = ConsoleName.ToString();
                }
            }


            if (Released != null)
            {
                if (Released.Type == JTokenType.String)
                {
                    GameInfoAndProgress.Released = Released.ToString();
                }
            }

            if (Genre != null)
            {
                if (Genre.Type == JTokenType.String)
                {
                    GameInfoAndProgress.Genre = Genre.ToString();
                }
            }

            if (Developer != null)
            {
                if (Developer.Type == JTokenType.String)
                {
                    GameInfoAndProgress.Developer = Developer.ToString();
                }
            }
            if (Publisher != null)
            {
                if (Publisher.Type == JTokenType.String)
                {
                    GameInfoAndProgress.Publisher = Publisher.ToString();
                }
            }

            if (ImageBoxArt != null)
            {
                if (ImageBoxArt.Type == JTokenType.String)
                {
                    GameInfoAndProgress.ImageBoxArt = ImageBoxArt.ToString();
                }
            }

            if (ImageIngame != null)
            {
                if (ImageIngame.Type == JTokenType.String)
                {
                    GameInfoAndProgress.ImageIngame = ImageIngame.ToString(); ;
                }
            }

            if (ImageTitle != null)
            {
                if (ImageTitle.Type == JTokenType.String)
                {
                    GameInfoAndProgress.ImageTitle = ImageTitle.ToString();
                }
            }

            if (ImageIcon != null)
            {
                if (ImageIcon.Type == JTokenType.String)
                {
                    GameInfoAndProgress.ImageIcon = ImageIcon.ToString();
                }
            }

            if (Title != null)
            {
                if (Title.Type == JTokenType.String)
                {
                    GameInfoAndProgress.Title = Title.ToString();
                }
            }

            if (ConsoleID != null)
            {
                if (ConsoleID.Type == JTokenType.Integer)
                {
                    GameInfoAndProgress.ConsoleId = Convert.ToInt32(ConsoleID);
                }
            }

            if (ID != null)
            {
                if (ID.Type == JTokenType.Integer)
                {
                    GameInfoAndProgress.Id = Convert.ToInt32(ID);
                }
            }

            if (Achievements != null)
            {
                if (Achievements.Type == JTokenType.Object)
                {
                    GameInfoAndProgress.Achievements = new List<Achievement>();

                    foreach (JToken jobject in Achievements.Children<JToken>())
                    {
                        foreach (JToken jobjectJr in jobject.Children<JToken>())
                        {
                            GameInfoAndProgress.Achievements.Add(jobjectJr.ToObject<Achievement>());
                        }
                    }
                }
            }

            return GameInfoAndProgress;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

        }
    }
}