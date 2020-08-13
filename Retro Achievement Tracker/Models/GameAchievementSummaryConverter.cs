namespace Retro_Achievement_Tracker
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;

    public class GameAchievementSummaryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject item = JObject.Load(reader);
            GameAchievementSummary GameSummary = new GameAchievementSummary();

            if (existingValue != null)
            {
                GameSummary = (GameAchievementSummary)existingValue;
            }

            string[] path = reader.Path.Split('.');

            GameSummary.GameId = Convert.ToInt32(path[1]);

            JToken NumPossibleAchievements = item["NumPossibleAchievements"];
            JToken PossibleScore = item["PossibleScore"];
            JToken NumAchieved = item["NumAchieved"];
            JToken ScoreAchieved = item["ScoreAchieved"];
            JToken NumAchievedHardcore = item["NumAchievedHardcore"];
            JToken ScoreAchievedHardcore = item["ScoreAchievedHardcore"];

            if (NumPossibleAchievements != null)
            {
                GameSummary.NumPossibleAchievements = Convert.ToInt32(NumPossibleAchievements);
            }
            if (PossibleScore != null)
            {
                GameSummary.PossibleScore = Convert.ToInt32(PossibleScore);
            }
            if (NumAchieved != null)
            {
                GameSummary.NumAchieved = Convert.ToInt32(NumAchieved);
            }
            if (ScoreAchieved != null)
            {
                GameSummary.ScoreAchieved = Convert.ToInt32(ScoreAchieved);
            }
            if (NumAchievedHardcore != null)
            {
                GameSummary.NumAchievedHardcore = Convert.ToInt32(NumAchievedHardcore);
            }
            if (ScoreAchievedHardcore != null)
            {
                GameSummary.ScoreAchievedHardcore = Convert.ToInt32(ScoreAchievedHardcore);
            }

            return GameSummary;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

        }
    }
}