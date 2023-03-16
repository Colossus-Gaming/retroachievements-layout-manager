namespace Retro_Achievement_Tracker
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

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
            JToken LastGameID = item["LastGameID"];
            JToken Motto = item["Motto"];
            JToken UserPic = item["UserPic"];
            JToken Rank = item["Rank"];
            JToken TotalPoints = item["TotalPoints"];
            JToken TotalTruePoints = item["TotalTruePoints"];
            JToken LastActivity = item["LastActivity"];

            if (RecentAchievements != null)
            {
                UserSummary.Achievements = new List<Achievement>();

                foreach (JToken jobject in RecentAchievements.Children<JToken>())
                {
                    foreach (JToken jobjectJr in jobject.Children<JToken>())
                    {
                        foreach (JToken jobjectIII in jobjectJr.Children<JToken>())
                        {
                            foreach (JToken jobjectIV in jobjectIII.Children<JToken>())
                            {
                                UserSummary.Achievements.Add(jobjectIV.ToObject<Achievement>());
                            }
                        }
                    }
                }

            }

            if (LastActivity != null)
            {
                UserSummary.UserName = LastActivity.SelectToken("User").ToString();
            }

            if (LastGameID != null)
            {
                UserSummary.LastGameID = Convert.ToInt32(LastGameID);
            }

            if (UserPic != null)
            {
                UserSummary.UserPic = UserPic.ToString();
            }

            if (Motto != null)
            {
                UserSummary.Motto = Motto.ToString();
            }

            if (TotalPoints != null)
            {
                UserSummary.TotalPoints = Convert.ToInt32(TotalPoints);
            }

            if (TotalTruePoints != null)
            {
                UserSummary.TotalTruePoints = Convert.ToInt32(TotalTruePoints);
            }

            if (Rank != null)
            {
                try
                {
                    UserSummary.Rank = Convert.ToInt32(Rank);
                }
                catch (Exception) { }
            }

            return UserSummary;
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