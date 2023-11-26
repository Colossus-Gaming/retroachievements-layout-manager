using Newtonsoft.Json;
using Retro_Achievement_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;

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

            client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
            {
                NoCache = true
            };
        }
        public async Task<GameInfo> GetGameInfoExtended(long gameId)
        {
            HttpResponseMessage httpResponseMessage = await client.GetAsync(string.Format(Constants.RETRO_ACHIEVEMENTS_URL + Constants.RETRO_ACHIEVEMENTS_API_GET_GAME_EXTENDED, UserName, ApiKey, gameId));

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                MessageBox.Show($"GetGameInfoExtended {httpResponseMessage.StatusCode}");
                throw new Exception("RA backend responding with errors: " + httpResponseMessage.StatusCode);
            }
            return JsonConvert.DeserializeObject<GameInfo>(await httpResponseMessage.Content.ReadAsStringAsync());
        }
    }
}
