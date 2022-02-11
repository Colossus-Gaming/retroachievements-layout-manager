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
        public async Task<GameInfoAndProgress> GetUserProgress(int gameId)
        {
            HttpResponseMessage httpResponseMessage = await client.GetAsync("https://retroachievements.org/API/API_GetGameInfoAndUserProgress.php?z=" + UserName + "&y=" + ApiKey + "&u=" + UserName + "&g=" + gameId);

            return JsonConvert.DeserializeObject<GameInfoAndProgress>(await httpResponseMessage.Content.ReadAsStringAsync(), jsonSerializerSettings);
        }
        public async Task<List<GameCompleted>> GetCompletedGames()
        {
            HttpResponseMessage httpResponseMessage = await client.GetAsync("https://retroachievements.org/API/API_GetUserCompletedGames.php?z=" + UserName + "&y=" + ApiKey + "&u=" + UserName);

            return JsonConvert.DeserializeObject<List<GameCompleted>>(await httpResponseMessage.Content.ReadAsStringAsync(), jsonSerializerSettings);
        }
    }
}
