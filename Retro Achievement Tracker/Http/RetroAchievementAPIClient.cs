using Newtonsoft.Json;
using Retro_Achievement_Tracker.Models;
using System;
using System.Collections.Generic;
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

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("RA backend responding with errors: " + httpResponseMessage.StatusCode);
            }
            return JsonConvert.DeserializeObject<UserSummary>(await httpResponseMessage.Content.ReadAsStringAsync());
        }
        public async Task<GameInfo> GetGameInfoAndProgress(long gameId)
        {
            HttpResponseMessage httpResponseMessage = await client.GetAsync(string.Format(Constants.RETRO_ACHIEVEMENTS_URL + Constants.RETRO_ACHIEVEMENTS_API_GET_GAME, UserName, ApiKey, UserName, gameId));

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("RA backend responding with errors: " + httpResponseMessage.StatusCode);
            }
            return JsonConvert.DeserializeObject<GameInfo>(await httpResponseMessage.Content.ReadAsStringAsync());
        }
        public async Task<List<GameInfo>> GetRecentlyPlayedGames()
        {
            HttpResponseMessage httpResponseMessage = await client.GetAsync(string.Format(Constants.RETRO_ACHIEVEMENTS_URL + Constants.RETRO_ACHIEVEMENTS_API_GET_RECENTLY_PLAYED, UserName, ApiKey, UserName));

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("RA backend responding with errors: " + httpResponseMessage.StatusCode);
            }
            return JsonConvert.DeserializeObject<List<GameInfo>>(await httpResponseMessage.Content.ReadAsStringAsync());
        }
        public async Task<UserRankAndScore> GetRankAndScore()
        {
            HttpResponseMessage httpResponseMessage = await client.GetAsync(string.Format(Constants.RETRO_ACHIEVEMENTS_URL + Constants.RETRO_ACHIEVEMENTS_API_GET_RANK_AND_SCORE, UserName, ApiKey, UserName));

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("RA backend responding with errors: " + httpResponseMessage.StatusCode);
            }
            return JsonConvert.DeserializeObject<UserRankAndScore>(await httpResponseMessage.Content.ReadAsStringAsync());
        }
    }
}
