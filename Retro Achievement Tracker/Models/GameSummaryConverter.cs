namespace Retro_Achievement_Tracker
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;

    public class GameSummaryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject item = JObject.Load(reader);
            GameSummary GameSummary = new GameSummary();

            if (existingValue != null)
            {
                GameSummary = (GameSummary)existingValue;
            }

            JToken GameID = item["GameID"];
            JToken ConsoleID = item["ConsoleID"];
            JToken ConsoleName = item["ConsoleName"];
            JToken Title = item["Title"];
            JToken ImageIcon = item["ImageIcon"];
            JToken LastPlayed = item["LastPlayed"];

            if (GameID != null)
            {
                GameSummary.GameID = Convert.ToInt32(GameID);
            }

            if (ConsoleID != null)
            {
                GameSummary.ConsoleID = Convert.ToInt32(ConsoleID);
            }

            if (ImageIcon != null)
            {
                GameSummary.ImageIcon = ImageIcon.ToString();
            }

            if (Title != null)
            {
                GameSummary.Title = Title.ToString();
            }

            if (LastPlayed != null && !string.IsNullOrEmpty(LastPlayed.ToString()))
            {
                GameSummary.LastPlayed = DateTime.Parse(LastPlayed.ToString());
            }

            return GameSummary;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

        }
    }
}