using Newtonsoft.Json;
using Retro_Achievement_Tracker.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Retro_Achievement_Tracker
{
    class RetroAchievementAPIClient
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string UserName;
        private readonly string ApiKey;

        public RetroAchievementAPIClient(string username, string apiKey)
        {
            UserName = username;
            ApiKey = apiKey;
        }
        public async Task<UserSummary> GetUserSummary()
        {
            HttpResponseMessage httpResponseMessage = await client.GetAsync(string.Format(Constants.RETRO_ACHIEVEMENTS_URL + Constants.RETRO_ACHIEVEMENTS_API_GET_USER, UserName, ApiKey, UserName));

            return JsonConvert.DeserializeObject<UserSummary>(await httpResponseMessage.Content.ReadAsStringAsync());
        }
        public async Task<GameInfo> GetGameInfo(int gameId)
        {
            HttpResponseMessage httpResponseMessage = await client.GetAsync(string.Format(Constants.RETRO_ACHIEVEMENTS_URL + Constants.RETRO_ACHIEVEMENTS_API_GET_GAME, UserName, ApiKey, UserName, gameId));

            return JsonConvert.DeserializeObject<GameInfo>(await httpResponseMessage.Content.ReadAsStringAsync());
        }
        public async Task<string> GetNewsFeed()
        {
            HttpResponseMessage httpResponseMessage = await client.GetAsync(Constants.RETRO_ACHIEVEMENTS_URL + "/rss-news");

            return await httpResponseMessage.Content.ReadAsStringAsync();
        }
        public async Task<string> GetNewAchievementsFeed()
        {
            HttpResponseMessage httpResponseMessage = await client.GetAsync(Constants.RETRO_ACHIEVEMENTS_URL + "/rss-newachievements");

            return await httpResponseMessage.Content.ReadAsStringAsync();
        }
        public async Task<string> GetForumActivityFeed()
        {
            HttpResponseMessage httpResponseMessage = await client.GetAsync(Constants.RETRO_ACHIEVEMENTS_URL + "/rss-forum");

            return await httpResponseMessage.Content.ReadAsStringAsync();
        }
        public async Task<string> GetFriendActivityFeed()
        {
            HttpResponseMessage httpResponseMessage = await client.GetAsync(Constants.RETRO_ACHIEVEMENTS_URL + "/rss-activity?u=" + UserName);

            return await httpResponseMessage.Content.ReadAsStringAsync();
        }
    }
}
