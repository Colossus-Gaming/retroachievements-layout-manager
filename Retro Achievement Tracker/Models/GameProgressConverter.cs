namespace Retro_Achievement_Tracker
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;

    public class GameProgressConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject item = JObject.Load(reader);
            GameProgress GameProgress = new GameProgress();

            if (existingValue != null)
            {
                GameProgress = (GameProgress)existingValue;
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
            JToken IsFinal = item["IsFinal"];
            JToken ConsoleName = item["ConsoleName"];
            JToken NumAchievements = item["NumAchievements"];
            JToken Achievements = item["Achievements"];

            if (Achievements != null)
            {
                if (Achievements.Type == JTokenType.Object)
                {
                    GameProgress.Achievements = new List<Achievement>();

                    foreach (JToken jobject in Achievements.Children<JToken>())
                    {
                        foreach (JToken jobjectJr in jobject.Children<JToken>())
                        {
                            GameProgress.Achievements.Add(jobjectJr.ToObject<Achievement>());
                        }
                    }
                }
            }

            if (NumAchievements != null)
            {
                if (NumAchievements.Type == JTokenType.Integer)
                {
                    GameProgress.NumAchievements = Convert.ToInt32(NumAchievements);
                }
            }

            if (ConsoleName != null)
            {
                if (ConsoleName.Type == JTokenType.String)
                {
                    GameProgress.ConsoleName = ConsoleName.ToString();
                }
            }

            if (IsFinal != null)
            {
                if (IsFinal.Type == JTokenType.Boolean)
                {
                    GameProgress.IsFinal = (bool)IsFinal;
                }
            }

            if (Released != null)
            {
                if (Released.Type == JTokenType.String)
                {
                    GameProgress.Released = Released.ToString();
                }
            }

            if (Genre != null)
            {
                if (Genre.Type == JTokenType.String)
                {
                    GameProgress.Genre = Genre.ToString();
                }
            }

            if (Developer != null)
            {
                if (Developer.Type == JTokenType.String)
                {
                    GameProgress.Developer = Developer.ToString();
                }
            }
            if (Publisher != null)
            {
                if (Publisher.Type == JTokenType.String)
                {
                    GameProgress.Publisher = Publisher.ToString();
                }
            }

            if (ImageBoxArt != null)
            {
                if (ImageBoxArt.Type == JTokenType.String)
                {
                    GameProgress.ImageBoxArt = ImageBoxArt.ToString();
                }
            }

            if (ImageIngame != null)
            {
                if (ImageIngame.Type == JTokenType.String)
                {
                    GameProgress.ImageIngame = ImageIngame.ToString(); ;
                }
            }

            if (ImageTitle != null)
            {
                if (ImageTitle.Type == JTokenType.String)
                {
                    GameProgress.ImageTitle = ImageTitle.ToString();
                }
            }

            if (ImageIcon != null)
            {
                if (ImageIcon.Type == JTokenType.String)
                {
                    GameProgress.ImageIcon = ImageIcon.ToString();
                }
            }

            if (Title != null)
            {
                if (Title.Type == JTokenType.String)
                {
                    GameProgress.Title = Title.ToString();
                }
            }

            if (ConsoleID != null)
            {
                if (ConsoleID.Type == JTokenType.Integer)
                {
                    GameProgress.ConsoleId = Convert.ToInt32(ConsoleID);
                }
            }

            if (ID != null)
            {
                if (ID.Type == JTokenType.Integer)
                {
                    GameProgress.Id = Convert.ToInt32(ID);
                }
            }

            if (GameProgress.Id != 0 && GameProgress.Achievements != null)
            {
                GameProgress.Achievements.ForEach(achievement =>
                {
                    achievement.GameId = (int)GameProgress.Id;
                    achievement.GameTitle = GameProgress.Title;
                });
            }
            return GameProgress;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

        }
    }
}