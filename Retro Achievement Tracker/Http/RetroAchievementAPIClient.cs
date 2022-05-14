using Newtonsoft.Json;
using Retro_Achievement_Tracker.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Retro_Achievement_Tracker
{
    class RetroAchievementAPIClient
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
        private readonly string UserName;
        private readonly string ApiKey;

        public RetroAchievementAPIClient(string username, string apiKey)
        {
            UserName = username;
            ApiKey = apiKey;
        }
        public async Task<UserSummary> GetUserSummary()
        {
            HttpResponseMessage httpResponseMessage = await client.GetAsync("https://retroachievements.org/API/API_GetUserSummary.php?z=" + UserName + "&y=" + ApiKey + "&u=" + UserName + "&g=1&a=1000");

            return JsonConvert.DeserializeObject<UserSummary>(await httpResponseMessage.Content.ReadAsStringAsync(), jsonSerializerSettings);
        }
        public async Task<GameInfo> GetGameInfo(int gameId)
        {
            HttpResponseMessage httpResponseMessage = await client.GetAsync("https://retroachievements.org/API/API_GetGameInfoAndUserProgress.php?z=" + UserName + "&y=" + ApiKey + "&u=" + UserName + "&g=" + gameId);

            return JsonConvert.DeserializeObject<GameInfo>(await httpResponseMessage.Content.ReadAsStringAsync(), jsonSerializerSettings);
        }
        public async Task<List<GameCompleted>> GetCompletedGames()
        {
            HttpResponseMessage httpResponseMessage = await client.GetAsync("https://retroachievements.org/API/API_GetUserCompletedGames.php?z=" + UserName + "&y=" + ApiKey + "&u=" + UserName);

            return JsonConvert.DeserializeObject<List<GameCompleted>>(await httpResponseMessage.Content.ReadAsStringAsync(), jsonSerializerSettings);
        }
        public async Task<string> GetNewsFeed()
        {
            HttpResponseMessage httpResponseMessage = await client.GetAsync("https://retroachievements.org/rss-news");

            return await httpResponseMessage.Content.ReadAsStringAsync();
        }
        public async Task<string> GetNewAchievementsFeed()
        {
            HttpResponseMessage httpResponseMessage = await client.GetAsync("https://retroachievements.org/rss-newachievements");

            return await httpResponseMessage.Content.ReadAsStringAsync();
        }
        public async Task<string> GetForumActivityFeed()
        {
            HttpResponseMessage httpResponseMessage = await client.GetAsync("https://retroachievements.org/rss-forum");

            return await httpResponseMessage.Content.ReadAsStringAsync();
        }
        public async Task<string> GetFriendActivityFeed()
        {
            HttpResponseMessage httpResponseMessage = await client.GetAsync("https://retroachievements.org/rss-activity?u=" + UserName);

            return await httpResponseMessage.Content.ReadAsStringAsync();
        }
    }
}
