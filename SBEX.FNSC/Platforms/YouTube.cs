using Newtonsoft.Json;
using SBEX.Common.Platforms;
using System;
using System.Net.Http;
using System.Xml;

namespace SBEX.FNSC.Platforms
{
    public static class YouTube
    {
        public static string GetYTVideoDetails(string code, string ytApiKey, out string desc, out string channel, out TimeSpan length)
        {
            desc = "NO TITLE";
            channel = "NO CHANNEL";
            length = new TimeSpan(0);
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
                string url = "https://www.googleapis.com/youtube/v3/videos?id=" + code + "&part=contentDetails&part=snippet&key=" + ytApiKey;
                var content = client.GetStringAsync(url).Result;
                

                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(content);
                if (myDeserializedClass.items[0] != null)
                {
                    desc = myDeserializedClass.items[0].snippet.title;
                    channel = myDeserializedClass.items[0].snippet.channelTitle;
                    length = XmlConvert.ToTimeSpan(myDeserializedClass.items[0].contentDetails.duration);

                    //if (span.Minutes > 9)
                    //{
                    //    CPH?.SendMessage("Sorry, @" + User + ", that song is too long! (>5 min)", true);
                    //    return true;
                    //}
                    //else if (span.Minutes < 2)
                    //{
                    //    CPH?.SendMessage("Sorry, @" + User + ", that song is too short! (<2 min)", true);
                    //    return true;
                    //}
                }
                return url;
            }
        }
    }
}
