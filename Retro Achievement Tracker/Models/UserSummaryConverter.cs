namespace Retro_Achievement_Tracker
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;

    public class UserSummaryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject item = JObject.Load(reader);
            UserSummary UserSummary = new UserSummary();

            if (existingValue != null)
            {
                UserSummary = (UserSummary)existingValue;
            }

            JToken RecentAchievements = item["RecentAchievements"];
            JToken Awarded = item["Awarded"];
            JToken LastGameID = item["LastGameID"];
            JToken Status = item["Status"];
            JToken UserPic = item["UserPic"];
            JToken Motto = item["Motto"];
            JToken TotalPoints = item["TotalPoints"];
            JToken TotalTruePoints = item["TotalTruePoints"];
            JToken Rank = item["Rank"];
            JToken RecentlyPlayed = item["RecentlyPlayed"];

            if (RecentAchievements != null)
            {
                if (RecentAchievements.Type == JTokenType.Object)
                {
                    UserSummary.RecentAchievements = new List<Achievement>();

                    foreach (JToken jobject in RecentAchievements.Children<JToken>())
                    {
                        foreach (JToken jobjectJr in jobject.Children<JToken>())
                        {
                            foreach (JToken jobjectIII in jobjectJr.Children<JToken>())
                            {
                                foreach (JToken jobjectIV in jobjectIII.Children<JToken>())
                                {
                                    UserSummary.RecentAchievements.Add(jobjectIV.ToObject<Achievement>());
                                }
                            }
                        }
                    }
                }
            }

            if (Awarded != null)
            {
                if (Awarded.Type == JTokenType.Object)
                {
                    UserSummary.GameAchievementSummaries = new List<GameAchievementSummary>();

                    foreach (JToken jobject in Awarded.Children<JToken>())
                    {
                        foreach (JToken jobjectJr in jobject.Children<JToken>())
                        {
                            UserSummary.GameAchievementSummaries.Add(jobjectJr.ToObject<GameAchievementSummary>());
                        }
                    }
                }
            }

            if (RecentlyPlayed != null)
            {
                if (RecentlyPlayed.Type == JTokenType.Array)
                {
                    List<GameSummary> gameSummaries = RecentlyPlayed.ToObject<List<GameSummary>>();

                    UserSummary.GameSummaries = gameSummaries.FindAll(gameSummary => gameSummary.ConsoleID != 0);
                }
            }

            if (LastGameID != null)
            {
                if (LastGameID.Type == JTokenType.String)
                {
                    UserSummary.LastGameID = Convert.ToInt32(LastGameID);
                }
            }

            if (Status != null)
            {
                if (Status.Type == JTokenType.String)
                {
                    UserSummary.Status = Status.ToString();
                }
            }

            if (UserPic != null)
            {
                if (UserPic.Type == JTokenType.String)
                {
                    UserSummary.UserPic = UserPic.ToString();
                }
            }

            if (Motto != null)
            {
                if (Motto.Type == JTokenType.String)
                {
                    UserSummary.Motto = Motto.ToString();
                }
            }

            if (TotalPoints != null)
            {
                if (TotalPoints.Type == JTokenType.String)
                {
                    UserSummary.TotalPoints = Convert.ToInt32(TotalPoints);
                }
            }

            if (TotalTruePoints != null)
            {
                if (TotalTruePoints.Type == JTokenType.String)
                {
                    UserSummary.TotalTruePoints = Convert.ToInt32(TotalTruePoints);
                }
            }

            if (Rank != null)
            {
                if (Rank.Type == JTokenType.String)
                {
                    UserSummary.Rank = Convert.ToInt32(Rank);
                }
            }

            return UserSummary;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

        }
    }
}