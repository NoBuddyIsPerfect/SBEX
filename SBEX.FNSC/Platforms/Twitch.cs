using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Streamer.bot.Plugin.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SBEX.Common.Platforms
{
    public static class  Twitch
    {

        static RestClient twitchRestClient = new RestClient();

        public static string GetUserName(string id, IInlineInvokeProxy CPH)
        {
            string urlAttachment = id;
            string token = CPH?.TwitchOAuthToken;// TwitchAccessToken().Result;
            RestRequest request = new RestRequest("helix/users?id=" + urlAttachment, Method.GET);




            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Client-Id", CPH?.TwitchClientId??"gcq217zi692u0dszhvjfttroy2ozvo");
            twitchRestClient.BaseUrl = new Uri("https://api.twitch.tv");
            //  request.Parameters.Add(new Parameter() { Name = "id", Value = "734510516" });
            RestResponse resp = (RestResponse)twitchRestClient.Execute(request);
            JToken playerObj = ((JObject)JsonConvert.DeserializeObject(resp.Content))?.GetValue("data");
            JObject inner = playerObj[0]?.Value<JObject>();
            IJEnumerable<JToken> t = inner?.Values();
            string name = t.Select(p => p.Value<string>()).ToList()[1];

            //System.Windows.Forms.MessageBox.Show(name);
            return name;
        }
        public static string GetUserId(string name, IInlineInvokeProxy CPH)
        {
            string urlAttachment = name;
            string token = TwitchAccessToken().Result;
            RestRequest request = new RestRequest("helix/users?login=" + urlAttachment, Method.GET);


            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Client-Id", CPH?.TwitchClientId??"gcq217zi692u0dszhvjfttroy2ozvo");
            twitchRestClient.BaseUrl = new Uri("https://api.twitch.tv");
            //  request.Parameters.Add(new Parameter() { Name = "id", Value = "734510516" });
            RestResponse resp = (RestResponse)twitchRestClient.Execute(request);
            JToken playerObj = ((JObject)JsonConvert.DeserializeObject(resp.Content))?.GetValue("data");
            string id = "";
            if (playerObj != null && playerObj.Count() > 0)
            {
                JObject inner = playerObj[0]?.Value<JObject>();
                IJEnumerable<JToken> t = inner?.Values();
                id = t.Select(p => p.Value<string>()).ToList()[0];
            }return id;
        }

        public static async Task<string> TwitchAccessToken()
        {
            string url = "oauth2/token?" +
                $"client_id=gcq217zi692u0dszhvjfttroy2ozvo&" +
                $"client_secret=q31gxrkj1ina5c1jvs59m5vxufumml&" +
                "grant_type=client_credentials&" +
                "scope=user:read:email";


            RestRequest request = new RestRequest(url, Method.POST);
            request.AddHeader("Accept", "application/json");
            twitchRestClient.BaseUrl = new Uri("https://id.twitch.tv");
            RestResponse resp = (RestResponse)twitchRestClient.Execute(request);
            if (resp == null || resp.ResponseStatus == ResponseStatus.Error)//!resp.IsSuccessful)
            {
                return null;
            }
            JObject obj = JsonConvert.DeserializeObject<JObject>(resp.Content);
            string accessToken = obj?.GetValue("access_token")?.Value<string>();
            if (!string.IsNullOrEmpty(accessToken))
            {
                return accessToken;
            }
            return "";
        }
    }
}
