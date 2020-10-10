using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Retro_Achievement_Tracker
{
    class HFC_EssentialsClient
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
        private readonly string UserName;
        private readonly string ApiKey;

        public HFC_EssentialsClient(string username, string apiKey)
        {
            this.UserName = username;
            this.ApiKey = apiKey;
        }

        public async Task<GameProgress> GetGameProgress(string gameId)
        {
            jsonSerializerSettings.CheckAdditionalContent = false;

            HttpResponseMessage httpResponseMessage = await client.GetAsync("https://ra.hfc-essentials.com/game_progress.php?user=" + UserName + "&key=" + ApiKey + "&game=" + gameId + "&mode=json");

            return JsonConvert.DeserializeObject<GameProgress>(await httpResponseMessage.Content.ReadAsStringAsync(), jsonSerializerSettings);
        }

        public async Task<UserSummary> GetUserSummary()
        {
            jsonSerializerSettings.CheckAdditionalContent = false;

            HttpResponseMessage httpResponseMessage = await client.GetAsync("https://ra.hfc-essentials.com/user_summary.php?user=" + UserName + "&key=" + ApiKey + "&member=" + UserName + "&results=1&mode=json");

            return JsonConvert.DeserializeObject<UserSummary>(await httpResponseMessage.Content.ReadAsStringAsync(), jsonSerializerSettings);
        }
    }
}
