using System.Collections.Generic;

namespace SBEX.FNSC.Helpers
{

    public class SBUser
    {
        public string id { get; set; }
        public string userName { get; set; }
        public string display { get; set; }
        public int role { get; set; }
        public bool isSubscribed { get; set; }
    }

    public class Arguments
    {
        public bool IsMod = false, DoublesAllowed = false, IsCoinFlip = false, Random = false;
        public string Command= "", User= "", UserId= "", Theme= "", RawInput = "",YouTubeApiKey = "", ExportPath= "", OBSScene= "",
             MainBrowserSource= "", CountdownSource= "", VoteLeftSource= "", VoteRightSource= "", HtmlPath= "",
             RoundSource= "", InfoSource= "", CoinFlipSource = "", DiscordWebhookUrl;
        public int NoOfSongs = 0, NoOfSongsPerPerson = 0, ChampionshipNo = 0, VotingDuration=0;
        public List<string> Parameters;
        public string LogValues()
        {
            int i = 0;
            string logMessage = $"[SC] - Arguments:" +
                $"\n\rBASICS:" +
                $"\n\rUser: {User}" +
                $"\n\rUserId: {UserId}" +
                $"\n\rIsMod: {IsMod}" +
                $"\n\rExportPath: {ExportPath}" +
                $"\n\rHtmlPath: {HtmlPath}" +
                $"\n\rYouTubeApiKey: {YouTubeApiKey}" +
                $"\n\rINPUT:" +
                $"\n\rDoublesAllowed: {DoublesAllowed}" +
                $"\n\rIsCoinFlip: {IsCoinFlip}" +
                $"\n\rRandom: {Random}" +
                $"\n\rCommand: {Command}" +
                $"\n\rRawInput: {RawInput}" +
                $"\n\rTheme: {Theme}" +
                $"\n\rNoOfSongs: {NoOfSongs}" +
                $"\n\rNoOfSongsPerPerson: {NoOfSongsPerPerson}" +
                $"\n\rChampionshipNo: {ChampionshipNo}" +
                $"\n\rOBS:" +
                $"\n\rOBSScene: {OBSScene}" +
                $"\n\rMainBrowserSource: {MainBrowserSource}" +
                $"\n\rCountdownSource: {CountdownSource}" +
                $"\n\rVoteLeftSource: {VoteLeftSource}" +
                $"\n\rVoteRightSource: {VoteRightSource}" +

                $"\n\rRoundSource: {RoundSource}" +
                $"\n\rInfoSource: {InfoSource}" +
                $"\n\rCoinFlipSource: {CoinFlipSource}" +
          
           $"\n\rPARAMS:";
            if(Parameters != null)
                foreach (string param in Parameters)
                {
                    logMessage += $"\n\rparam{i}: {param}";
                }
            logMessage += $"\n\r[SC] - END Arguments";
            return logMessage;
        }
    }
    public static class ArgumentHelper
    {
        

        public static Arguments ParseArgs(Dictionary<string, object> args)
        {
            Arguments parsedArgs = new Arguments();
            if (args.ContainsKey("isModerator"))
                parsedArgs.IsMod = args.ContainsKey("isModerator") && bool.Parse(args["isModerator"].ToString());

            if (args.ContainsKey("rawInput"))
                parsedArgs.RawInput = args["rawInput"].ToString();
            if (args.ContainsKey("youTubeApiKey"))
                parsedArgs.YouTubeApiKey = args["youTubeApiKey"].ToString();
            if (args.ContainsKey("webhookUrl"))
                parsedArgs.DiscordWebhookUrl = args["webhookUrl"].ToString();
            if (args.ContainsKey("exportPath"))
                parsedArgs.ExportPath = args["exportPath"].ToString();
            if (args.ContainsKey("htmlPath"))
                parsedArgs.HtmlPath = args["htmlPath"].ToString();
            
            if (args.ContainsKey("command"))
                parsedArgs.Command = args["command"].ToString();

            if (args.ContainsKey("oBSScene"))
                parsedArgs.OBSScene = args["oBSScene"].ToString();
            if (args.ContainsKey("mainBrowserSource"))
                parsedArgs.MainBrowserSource = args["mainBrowserSource"].ToString();
            if (args.ContainsKey("countdownSource"))
                parsedArgs.CountdownSource = args["countdownSource"].ToString();
            if (args.ContainsKey("voteLeftSource"))
                parsedArgs.VoteLeftSource = args["voteLeftSource"].ToString();
            if (args.ContainsKey("voteRightSource"))
                parsedArgs.VoteRightSource = args["voteRightSource"].ToString();
            if (args.ContainsKey("roundSource"))
                parsedArgs.RoundSource = args["roundSource"].ToString();
            if (args.ContainsKey("infoSource"))
                parsedArgs.InfoSource = args["infoSource"].ToString();
            if (args.ContainsKey("coinFlipSource"))
                parsedArgs.CoinFlipSource = args["coinFlipSource"].ToString();
            if (args.ContainsKey("theme"))
                parsedArgs.Theme = args["theme"].ToString();
            
            if (args.ContainsKey("isCoinFlip"))
                parsedArgs.IsCoinFlip = bool.Parse(args["isCoinFlip"].ToString());
            if (args.ContainsKey("random"))
                parsedArgs.Random = bool.Parse(args["random"].ToString());
            if (args.ContainsKey("allowDoubles"))
                parsedArgs.DoublesAllowed = bool.Parse(args["allowDoubles"].ToString());
            if (args.ContainsKey("no"))
                parsedArgs.ChampionshipNo= int.Parse(args["no"].ToString());
            if (args.ContainsKey("duration"))
                parsedArgs.VotingDuration= int.Parse(args["duration"].ToString());
            if (args.ContainsKey("noOfSongs"))
                parsedArgs.NoOfSongs= int.Parse(args["noOfSongs"].ToString());
            if (args.ContainsKey("noOfSongsPerPerson"))
                parsedArgs.NoOfSongsPerPerson= int.Parse(args["noOfSongsPerPerson"].ToString());
            if (args.ContainsKey("allowDoubles"))
                parsedArgs.ChampionshipNo= int.Parse(args["no"].ToString());
            
            if (args.ContainsKey("user"))
                parsedArgs.User = (args.ContainsKey("user")) ? args["user"].ToString() : "";
            
            if (args.ContainsKey("userId"))
                parsedArgs.UserId = (args.ContainsKey("userId")) ? args["userId"].ToString() : parsedArgs.User;
            parsedArgs.Parameters = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                if (args.ContainsKey("input" + i))
                {
                    parsedArgs.Parameters.Add(args["input" + i].ToString());
                }
            }
            if (!string.IsNullOrEmpty(parsedArgs.RawInput))
            {
                string[] commandparts = parsedArgs.RawInput.Split('&');
                foreach (string part in commandparts)
                {
                    string[] subparts = part.Split('=');
                    if (part.Contains("songs="))
                        parsedArgs.NoOfSongs = int.Parse(subparts[1]);
                    else if (part.Contains("perperson="))
                        parsedArgs.NoOfSongsPerPerson = int.Parse(subparts[1]);
                    else if (part.Contains("Theme="))
                        parsedArgs.Theme = subparts[1];
                    else if (part.Contains("no="))
                        parsedArgs.ChampionshipNo = int.Parse(subparts[1]);
                    else if (part.Contains("allowDoubles"))
                        parsedArgs.DoublesAllowed = true;
                    else if (part.Contains("random"))
                        parsedArgs.Random = true;

                }
            }
            return parsedArgs;
        }
    }
}
