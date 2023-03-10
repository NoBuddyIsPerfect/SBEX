using Newtonsoft.Json;
using SBEX.FNSC.Extensions;
using SBEX.FNSC.Helpers;
using SBEX.FNSC.Platforms;
using Streamer.bot.Plugin.Interface;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Web;
using System.Windows.Forms;

namespace SBEX.FNSC.Classes
{

	public partial class Game
	{
		private DateTime created;
		[NonSerialized]
		public IInlineInvokeProxy CPH;
		[NonSerialized]
			public string OBSScene,
				  MainBrowserSource, CountdownSource, VoteLeftSource, VoteRightSource,
				  RoundSource, InfoSource, CoinFlipSource, GameExportPath, HtmlPath, YtApiKey;
		#region ADMIN
		public bool ModifyGame(Arguments args, bool updateRandom, bool updateDouble)
		{
			if (args.NoOfSongs > 0 && this.NoOfSongs != args.NoOfSongs)
				this.NoOfSongs = args.NoOfSongs;
			if (args.NoOfSongsPerPerson > 0 && this.NoOfSongsPerPerson != args.NoOfSongsPerPerson)
				this.NoOfSongsPerPerson = args.NoOfSongsPerPerson;
			if (updateDouble && this.AllowDoubles != args.DoublesAllowed)
				this.AllowDoubles = args.DoublesAllowed;
			if (args.ChampionshipNo > 0 && this.ChampionshipNo != args.ChampionshipNo)
				this.ChampionshipNo = args.ChampionshipNo;
			if (!string.IsNullOrEmpty(args.Theme) && this.Theme != args.Theme)
				this.Theme = args.Theme;
			if (updateRandom && this.Random != args.Random)
				this.Random = args.Random;
			return true;

			
			
		}
		public bool ModifyGame(int noOfSongs=0, int noOfSongsPerPerson=0,int championshipNo=0,string theme = "",bool doublesAllowed = false, bool random=false, bool updateRandom=false, bool updateDouble=false)
		{
			if (noOfSongs > 0 && this.NoOfSongs != noOfSongs)
				this.NoOfSongs = noOfSongs;
			if (noOfSongsPerPerson > 0 && this.NoOfSongsPerPerson != noOfSongsPerPerson)
				this.NoOfSongsPerPerson = noOfSongsPerPerson;
			if (updateDouble && this.AllowDoubles != doublesAllowed)
				this.AllowDoubles = doublesAllowed;
			if (championshipNo > 0 && this.ChampionshipNo != championshipNo)
				this.ChampionshipNo = championshipNo;
			if (!string.IsNullOrEmpty(theme) && this.Theme != theme)
				this.Theme = theme;
			if (updateRandom && this.Random != random)
				this.Random = random;
			return true;

			
			
		}
		public bool SetWinner(string winner, bool isCoinFlip)
		{
			if (this == null || this.CurrentMatchup == null)
				return false;
			if (this.CurrentMatchup.Winner != null && MessageBox.Show($"Do you want to overwrite the current winner ({this.CurrentMatchup.Winner.Name})?", "Winner chosen already", MessageBoxButtons.YesNo) == DialogResult.No)
				return false;
				
			if (winner == "1")
			{
				this.CurrentMatchup.Winner = this.CurrentMatchup.Song1;
				//CPH?.SendMessage("Song No. " + winner + " has been set as the winner of the coinflip!", true);
			}
			else
			{
				this.CurrentMatchup.Winner = this.CurrentMatchup.Song2;
				//CPH?.SendMessage("Song No. " + winner + " has been set as the winner of the coinflip!", true);
			}

			if (!this.CurrentRound.FinishedMatches.Any(m => m.Position == this.CurrentMatchup.Position))
				this.CurrentRound.FinishedMatches.Add(this.CurrentMatchup);
			Log("[SC] - Manual winner: " + this.CurrentMatchup.Winner.Serialize());
			//this.CurrentMatchup = null;
			CPH?.SendMessage("\"" + this.CurrentMatchup.Winner.Name + " by " + this.CurrentMatchup.Winner.Artist + "\" is the winner" + ((!isCoinFlip) ? "!" : " of the coinflip!"), true);
			return true;

		}

		public bool OpenSubmissions()
		{
			CPH?.SendMessage("Submissions are open!", true);
			this.SubmissionsOpen = true;
			return true;
		}

		public bool CloseSubmissions()
		{
			CPH?.SendMessage("Submissions are closed!", true);
			this.SubmissionsOpen = false;
			StartGame();

			return true;
		}
		public bool StartGame()
		{
			this.Start = DateTime.Now;
			Round round1 = new Round();
			round1.RoundNumber = 1;
			CPH?.LogInfo("Starting this: " + this.NoOfSongs);
			if (this.Random)
				this.Songs.Shuffle();
			int counter = 1;
			for (int i = 1; i <= this.NoOfSongs / 2; i++)
			{
				if (this.Songs[i] == null)
					break;
				Match matchup = new Match();
				matchup.Song1 = this.Songs[counter - 1];
				matchup.Song2 = this.Songs[counter];
				matchup.Position = i;
				round1.Matches.Add(matchup);
				counter++;
				counter++;
			}
			round1.Matches.Shuffle();
			this.Rounds.Add(round1);
			this.CurrentRound = round1;
			string text = "Submissions are now closed\n\rThe championship is about to start!\n\rSongs " + this.Songs.Count + "/" + this.NoOfSongs + "";
			CPH?.ObsSetGdiText(OBSScene, InfoSource, text);
			//CPH?.SendMessage("A new game has started", true);
			return true;
		}
		[JsonIgnore]
		public int votingTime = 0;
		public bool NextMatch()
		{
			Log("[SC] - Starting nextMatch - CurrentMatchCount: " + this.CurrentRound.Matches.Count + "; FinishedCount: " + this.CurrentRound.FinishedMatches.Count);

			var prevMatchup = this.CurrentMatchup;
			if (prevMatchup != null && prevMatchup.Winner == null)
			{
				CPH?.SendMessage("No winner selected", true);
				return false;
			}
			Log("[SC] - Starting move to next Match - CurrentMatchCount: " + this.CurrentRound.Matches.Count);
			if (prevMatchup != null)
			{
				var existing = this.CurrentRound.Matches.FirstOrDefault(m => m.Position == prevMatchup.Position);
				if (existing != null)
					this.CurrentRound.Matches.Remove(existing);
			}
			Log("[SC] - CurrentMatchCount after removing: " + this.CurrentRound.Matches.Count);
			CPH?.ObsSetSourceVisibility(OBSScene, InfoSource, false);
			if (this.CurrentRound.Matches.Count == 0)
			{
				if (this.CurrentRound.FinishedMatches.Count == 1)
				{
					this.CurrentMatchup = null;
					this.Winner = this.CurrentRound.FinishedMatches[0].Winner;
					ShowResult();
					return true;
				}
				Round existingRound = this.Rounds.FirstOrDefault(r => r.RoundNumber == this.CurrentRound.RoundNumber);
				if (existingRound != null)
					this.Rounds.Remove(existingRound);
				this.Rounds.Add(this.CurrentRound);
				// CPH?.SendMessage("Preparing round", true);
				Round round = new Round();
				int currentRoundNo = 0;
				for (int i = 0; i < this.Rounds.Count; i++)
					if (this.Rounds[i].RoundNumber > currentRoundNo)
						currentRoundNo = this.Rounds[i].RoundNumber;
				round.RoundNumber = currentRoundNo + 1;
				if (this.Random)
					this.Rounds.Find(r => r.RoundNumber == currentRoundNo).FinishedMatches.Shuffle();
				int counter = 1;
				for (int i = 1; i <= this.Rounds.Find(r => r.RoundNumber == currentRoundNo).FinishedMatches.Count / 2; i++)
				{
					Match matchup = new Match();
					matchup.Song1 = this.Rounds.Find(r => r.RoundNumber == currentRoundNo).FinishedMatches[counter - 1].Winner;
					matchup.Song2 = this.Rounds.Find(r => r.RoundNumber == currentRoundNo).FinishedMatches[counter].Winner;
					matchup.Position = i;
					round.Matches.Add(matchup);
					counter++;
					counter++;
				}
				this.Rounds.Add(round);
				this.CurrentRound = round;
			}
			if (this.CurrentRound.Matches.Any())
				this.CurrentMatchup = this.CurrentRound.Matches.OrderBy(m => m.Position).ToArray()[0];

			string title = "Qualifier";
			string headerText = "Round\n\r" + this.CurrentRound.RoundNumber + "\n\rBattle\n\r" + this.CurrentMatchup.Position + "/" + (this.CurrentRound.Matches.Count + this.CurrentRound.FinishedMatches.Count);
			if ((this.CurrentRound.Matches.Count + this.CurrentRound.FinishedMatches.Count) == 4)
				headerText = "Quarterfinal";
			else if ((this.CurrentRound.Matches.Count + this.CurrentRound.FinishedMatches.Count) == 2)
				headerText = "Semifinal";
			else if ((this.CurrentRound.Matches.Count + this.CurrentRound.FinishedMatches.Count) == 1)
				headerText = "Final";
			//Log("[SC] - HeaderText: " + headerText);

			CPH?.ObsSetGdiText(OBSScene, RoundSource, headerText);
			// CPH?.SendMessage(headerText, true);
			//CPH?.SendMessage("No of matches remaining: " + this.CurrentRound.Matches.Count, true);
			//CPH?.SendMessage("Code1: " + this.CurrentMatchup.Song1.Code, true);
			//CPH?.SendMessage("Code2: " + this.CurrentMatchup.Song2.Code, true);
			CPH?.ObsSetSourceVisibility(OBSScene, MainBrowserSource, false);
			string html = "<table height=\"100%\"><tr><td width=\"45%\" vertical-align=\"center\"><iframe width=\"864\" height=\"486\" src=\"https://www.youtube.com/embed/<song1>\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture\" allowfullscreen></iframe></td><td width=\"10%\"></td><td width=\"45%\"><iframe width=\"864\" height=\"486\" src=\"https://www.youtube.com/embed/<song2>\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture\" allowfullscreen></iframe></td></tr></table>";
			int additionalStartTime = 0;
            if (votingTime > 0)
				switch (this.CurrentRound.RoundNumber)
				{
					case 2:
						additionalStartTime = votingTime/2;
						break;
					case 3:

						additionalStartTime = votingTime;
						break;
					case 4:
						additionalStartTime = Convert.ToInt32(votingTime*1.5);
						break;
					case 5:
						additionalStartTime = votingTime*2;
						break;
					case 6:
						additionalStartTime = Convert.ToInt32(votingTime*2.5);
						break;
				}
			
			html = html.Replace("<song1>", this.CurrentMatchup.Song1.Code + ((this.CurrentMatchup.Song1.StartTime > 0) ? "?start=" + (this.CurrentMatchup.Song1.StartTime+additionalStartTime) : ""));
			html = html.Replace("<song2>", this.CurrentMatchup.Song2.Code + ((this.CurrentMatchup.Song2.StartTime > 0) ? "?start=" + (this.CurrentMatchup.Song2.StartTime + additionalStartTime) : ""));
			//html = html.Replace("<user1>", this.CurrentMatchup.Song1.User);
			//html = html.Replace("<user2>", this.CurrentMatchup.Song2.User);
			File.WriteAllText(HtmlPath, html);
			Log(html);
			Thread.Sleep(1000);
			CPH?.ObsSetSourceVisibility(OBSScene, MainBrowserSource, true);
			CPH?.ObsSetGdiText(OBSScene, VoteLeftSource, "0");
			CPH?.ObsSetGdiText(OBSScene, VoteRightSource, "0");
			CPH?.ObsSetSourceVisibility(OBSScene, VoteLeftSource, true);
			CPH?.ObsSetSourceVisibility(OBSScene, VoteRightSource, true);
			CPH?.ObsSetSourceVisibility(OBSScene, RoundSource, true);
			return true;

		}
		private System.Timers.Timer aTimer;
		public bool OpenVoting(int seconds = 0)
		{

			votingTime = seconds;
			CPH?.ObsSetGdiText(OBSScene, VoteLeftSource, "0");
			CPH?.ObsSetGdiText(OBSScene, VoteRightSource, "0");
			if (seconds > 0)
			{
				aTimer = new System.Timers.Timer();
				aTimer.Elapsed += (object source, ElapsedEventArgs e) =>
				{
					Log("[SC] - VOTING TIMER ELAPSED!");
					
					if (this.CurrentMatchup == null || this.CurrentMatchup.CanBeVoted == false)
					{
						aTimer.Stop();
						return;
					}
					this.CurrentMatchup.CanBeVoted = false;
					this.VotesOpen = false;
                    CPH?.SendMessage("Voting is closed", true); //, the winner is " + this.CurrentMatchup.Winner.Code, true);
                    
					CPH?.ObsSetSourceVisibility(OBSScene, CountdownSource, false);
					if (this.CurrentMatchup.Votes1 == this.CurrentMatchup.Votes2)
					{
						CPH?.SendMessage("It's a tie!", true);
						
						
						
					}
					if (this.CurrentMatchup.Votes1 != this.CurrentMatchup.Votes2)
					{
						if (this.CurrentMatchup.Votes1 > this.CurrentMatchup.Votes2)
						{
							this.CurrentMatchup.Winner = this.CurrentMatchup.Song1;
						}
						else if (this.CurrentMatchup.Votes1 < this.CurrentMatchup.Votes2)
						{
							this.CurrentMatchup.Winner = this.CurrentMatchup.Song2;
						}
						if (!this.CurrentRound.FinishedMatches.Any(m => m.Position == this.CurrentMatchup.Position))
							this.CurrentRound.FinishedMatches.Add(this.CurrentMatchup);

						Log("[SC] - Automatic vote closing winner: " + this.CurrentMatchup.Winner.Serialize());
					}
                    aTimer.Stop();
                };
				aTimer.Interval = seconds * 1000;
				aTimer.Enabled = true;
				aTimer.Start();
				CPH?.ObsSetSourceVisibility(OBSScene, CountdownSource, true);

			}


			this.VotesOpen = true;
			this.CurrentMatchup.CanBeVoted = true;
			this.CurrentMatchup.Winner = null;
			this.CurrentMatchup.Votes1 = this.CurrentMatchup.Votes2 = 0;
			this.CurrentMatchup.Voted.Clear();
			if (this.CurrentRound.FinishedMatches.Any(m => m.Position == this.CurrentMatchup.Position))
				this.CurrentRound.FinishedMatches.Remove(this.CurrentMatchup);
			CPH?.SendMessage("Voting is open", true);

			return true;
		}

		public bool CloseVoting()
		{
			if (this == null || this.CurrentMatchup == null || !this.CurrentMatchup.CanBeVoted)
				return false;
			this.CurrentMatchup.CanBeVoted = false;
			this.VotesOpen = false;
			Log($"[SC] - Closing Voting OBSScene={OBSScene}, CountdownSource={CountdownSource}");
			CPH?.ObsSetSourceVisibility(OBSScene, CountdownSource, false);
			if (aTimer.Enabled)
				aTimer.Stop();
			CPH?.SendMessage("Voting is closed", true);
			if (this.CurrentMatchup.Votes1 == this.CurrentMatchup.Votes2)
			{
				CPH?.SendMessage("It's a tie!", true);
				return true;
			}
			else if (this.CurrentMatchup.Votes1 > this.CurrentMatchup.Votes2)
			{
				this.CurrentMatchup.Winner = this.CurrentMatchup.Song1;
			}
			else
			{
				this.CurrentMatchup.Winner = this.CurrentMatchup.Song2;
			}

			if (!this.CurrentRound.FinishedMatches.Any(m => m.Position == this.CurrentMatchup.Position))
				this.CurrentRound.FinishedMatches.Add(this.CurrentMatchup);
			Log("[SC] - Manual close voting winner: " + this.CurrentMatchup.Winner.Serialize());

			return true;
		}
		public void MainExport()
		{

			if (string.IsNullOrEmpty(GameExportPath))
				return;
			File.WriteAllText(GameExportPath + "\\" + this.Start.ToString("dd-MM-yyyy_HH-mm") + ".json", this.Export());
			CPH?.SendMessage("game exported", true);

		}
		public void DCExport()
		{
			this.DiscordExport();
			Discord.SendFile(this.ExportResult, this.FileName, this.FullPath);
			CPH?.SendMessage("game exported to Discord", true);
		}
		public void Log(string message)
		{
			//File.AppendAllText($"SongChampionship-{created.ToString("u").Replace(":","_")}.log", $"{DateTime.Now.ToString("u")} - { message}\n");

			CPH?.LogDebug("[SC] - "+ message);
		}

		public bool Reset()
		{
			Log("[SC] - OBSScene: " + OBSScene);
			Log("[SC] - RoundSource: " + RoundSource);
			Log("[SC] - MainBrowserSource: " + MainBrowserSource);
			Log("[SC] - VoteLeftSource: " + VoteLeftSource);
			Log("[SC] - VoteRightSource: " + VoteRightSource);
			Log("[SC] - CountdownSource: " + CountdownSource);
			Log("[SC] - InfoSource: " + InfoSource);
			CPH?.ObsSetSourceVisibility(OBSScene, RoundSource, false);
			CPH?.ObsSetSourceVisibility(OBSScene, MainBrowserSource, false);
			CPH?.ObsSetSourceVisibility(OBSScene, VoteLeftSource, false);
			CPH?.ObsSetSourceVisibility(OBSScene, VoteRightSource, false);
			CPH?.ObsSetSourceVisibility(OBSScene, CountdownSource, false);
			CPH?.ObsSetSourceVisibility(OBSScene, InfoSource, false);
			
			CPH?.SetGlobalVar("currentChampionship", "");
			Log("[SC] - Reset done!");
			return true;
		}

		public bool ShowResult()
		{
			if (this.Winner != null)
			{
				CPH?.ObsSetSourceVisibility(OBSScene, RoundSource, false);
				CPH?.ObsSetSourceVisibility(OBSScene, MainBrowserSource, false);
				CPH?.ObsSetSourceVisibility(OBSScene, VoteLeftSource, false);
				CPH?.ObsSetSourceVisibility(OBSScene, VoteRightSource, false);
				CPH?.ObsSetSourceVisibility(OBSScene, CountdownSource, false);
				string html = "<table height=\"100%\" width=\"100%\" align=\"center\" style=\"font-family:Aquire;color:#f15a29;font-size:50\"><tr><td align=\"center\"><h1>YOUR WINNER</h1></td></tr><tr><td align=\"center\"><iframe width=\"864\" height=\"486\" src=\"https://www.youtube.com/embed/<song1>\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture\" allowfullscreen></iframe></td></tr><tr><td align=\"center\"><h1><title> by<br><artist></h1></td></tr><tr><td align=\"center\"><h1>Submitted by<br><user></h1></td></tr></table>";
				html = html.Replace("<song1>", this.Winner.Code+"?start=0");
				html = html.Replace("<user>", this.Winner.User);
				html = html.Replace("<title>", this.Winner.Name.Substring(0, ((this.Winner.Name.Length > 45) ? 45 : this.Winner.Name.Length - 1)));
				html = html.Replace("<artist>", this.Winner.Artist);
				File.WriteAllText(HtmlPath, html);
				Thread.Sleep(1000);
				CPH?.ObsSetSourceVisibility(OBSScene, MainBrowserSource, true);
				this.End = DateTime.Now;
				DCExport();
				MainExport();

				// CPH?.SendMessage(JsonSerializer.Serialize(game), true);
			}
			return true;
		}


		public Game LoadGame(string saveName)
		{
            if (string.IsNullOrEmpty(GameExportPath))
                return null;
            //                    File.WriteAllText(args["exportPath"].ToString() + "\\" + game.Start.ToString("dd-MM-yyyy_HH-mm") + ".json", JsonConvert.SerializeObject(game));
            string filename = saveName;
			Game loadedGame = JsonConvert.DeserializeObject<Game>(File.ReadAllText(GameExportPath + "\\" + filename + ".json"));
			if (loadedGame == null)
			{
				CPH?.SendMessage("Load game failed");
			}
			else
			{
				CPH?.SendMessage("Load game success");
			}
			return loadedGame;

		}
		public void SaveGame(string saveName)
		{
			string filename = saveName;

			File.WriteAllText(GameExportPath + "\\" + filename + ".json", JsonConvert.SerializeObject(this));
			CPH?.SendMessage($"game saved as {filename}");


		}

        public string LogValues()
        {
            int i = 0;
			string logMessage = $"[SC] - Arguments:" +
				$"\n\rBASICS:" +
				$"\n\rHtmlPath: {HtmlPath}" +
				$"\n\rYouTubeApiKey: {YtApiKey}" +
				$"\n\rINPUT:" +
				$"\n\rDoublesAllowed: {AllowDoubles}" +
				$"\n\rRandom: {Random}" +
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
				$"\n\rCoinFlipSource: {CoinFlipSource}";
                
            logMessage += $"\n\r[SC] - END Arguments";
            return logMessage;
        }
        #endregion

        #region Chat
        public bool Submit(string url, string username, string userid)
		{

			Log($"Starting submission of {url} by {username}({userid})");

			if (Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out Uri uri) && uri != null && this.SubmissionsOpen)
			{
				Log($"URL created and submissions open");

				string code = "";
				string startTime = "";
				NameValueCollection param = HttpUtility.ParseQueryString(uri.Query);
				if (param.Count > 0)
				{
					code = param.Get("v") ?? "";

					startTime = param.Get("t") ?? "";

				}
				if (string.IsNullOrEmpty(code))
					code = uri.Segments[1];
				if (string.IsNullOrEmpty(startTime) && uri.Segments.Length > 2)
					startTime = uri.Segments[2];
				Log("code = " + code);
				Log("startTime = " + startTime);
				if (url.ToLower().StartsWith("remove ") || url.ToLower().StartsWith("rem "))
					Remove(userid, code);
				else
				{
					try
					{
						if (this.Songs.FirstOrDefault(s => s.Code == code) != null && !this.AllowDoubles)
						{
							CPH?.SendMessage("Sorry, @" + username + ", that song has already been added", true);
							return true;
						}

						if (this.Songs.Count(s => s.User == username) == this.NoOfSongsPerPerson)
						{
							CPH?.SendMessage("Sorry @" + username + ", you have submitted " + this.NoOfSongsPerPerson + "already!", true);
							return true;
						}
						Log("blocks checked");
						
						YouTube.GetYTVideoDetails(code, YtApiKey, out string desc, out string channel, out TimeSpan length);
						Song song = new Song();
						song.Code = code;
						song.User = username;
						song.UserId = userid;
						song.SubmissionTime = DateTime.Now;
						Log("song initialized");
						if (int.TryParse(startTime.TrimEnd('s'), out int time))
						{
							song.StartTime = time;
						}
						if (string.IsNullOrEmpty(desc) || string.IsNullOrEmpty(channel))
                        {
                            CPH?.SendWhisper(username, "Sorry, I could not retrieve your song from YT!", true);
                            return false;
                        }
                        song.Name = Regex.Replace(desc, @"\p{Cs}", "");
						
						song.Artist = channel;
                        if (MaxSongLength.TotalMilliseconds > 0 && MaxSongLength < length)
						{
                            CPH?.SendWhisper(username,"Sorry, Your song could not be added because it is too long!",true);
							return false;
                        }
						this.Songs.Add(song);
						string text = "Theme for championship no " + this.ChampionshipNo + ":\n\r\n" + this.Theme + "\n\r\n\rSubmissions are open\n\r\nSongs: " + this.Songs.Count + "/" + this.NoOfSongs + "\n\r\nSongs/person: " + this.NoOfSongsPerPerson;
						CPH?.ObsSetGdiText(OBSScene, InfoSource, text);
						CPH?.SendWhisper(username, "Your song (" + desc + ") has been added!", true);

						if (this.Songs.Count == this.NoOfSongs)
						{
							CPH?.SendMessage("Submissions are closed!", true);
							this.SubmissionsOpen = false;
							StartGame();

						}
					}
					catch (Exception ex)
					{
						CPH?.SendWhisper(username, "Sorry, Your song could not be added! Please try again!", true);
						CPH?.LogWarn(ex.Message);
						CPH?.LogWarn(ex.StackTrace);
					}
				}

			}
			else
			{
				Log($"Submissions closed or url not created");
			}
			return true;
		}



		public bool Remove(string username, string code = "")
		{
			Log("Starting submission");
			Song song = null;
			if (!string.IsNullOrEmpty(code))
			{
				song = this.Songs.FirstOrDefault(s => s.Code == code);
			}
			if (song == null && !string.IsNullOrEmpty(username))
			{
				song = this.Songs.FirstOrDefault(s => s.User == username);
			}
			if (song != null)
			{
				this.Songs.Remove(song);
				CPH?.SendWhisper(username, $"Your song ({song.Name}) has been removed!", true);
				if (Songs.Count < NoOfSongs)
				{
					string text = "Theme for championship no " + this.ChampionshipNo + ":\n\r\n" + this.Theme + "\n\r\n\rSubmissions are open\n\r\nSongs: " + this.Songs.Count() + "/" + this.NoOfSongs + "\n\r\nSongs/person: " + this.NoOfSongsPerPerson;
					CPH?.ObsSetGdiText(OBSScene, InfoSource, text);
                    this.SubmissionsOpen = true;
					this.Rounds.Clear();
					this.CurrentRound = null; 
					this.CurrentMatchup = null;

                }
			}
			else { CPH?.SendWhisper(username, $"You have not submitted a song yet!", true); }

			return true;

		}


		public bool Vote(string user, string userId, string voteString)
		{
			//MessageBox.Show($"user:{user},userid:{userId},string:{voteString}");
			if (int.TryParse(voteString, out int vote))
			{
				//foreach(KeyValuePair<string,object> kvp in args)
				//CPH?.SendMessage(kvp.Key+"="+kvp.Value.ToString(), true);
				//if (args.ContainsKey("__source") && args["__source"].ToString() == "WebsocketClientMessage")
				//    user = new Twitch().GetUserName(userId);
				//if (string.IsNullOrEmpty(userId))
				//{
				//    userId = Twitch.GetUserId(user, CPH);
				//}else if(string.IsNullOrEmpty(user))
				//{
				//    user = Twitch.GetUserName(userId, CPH);
				////}
				//MessageBox.Show($"CurrentMatchup set: " + (this.CurrentMatchup != null));
				//MessageBox.Show($"Votes open: {this.VotesOpen}");
				if (this.CurrentMatchup != null && this.CurrentMatchup.CanBeVoted && !this.CurrentMatchup.Voted.Contains(userId))
				{
					if (vote == 1)
					{
						this.CurrentMatchup.Votes1++;
						CPH?.ObsSetGdiText(OBSScene, VoteLeftSource, this.CurrentMatchup.Votes1.ToString());
					}
					else if (vote == 2)
					{
						this.CurrentMatchup.Votes2++;
						CPH?.ObsSetGdiText(OBSScene, VoteRightSource, this.CurrentMatchup.Votes2.ToString());
					}

					this.CurrentMatchup.Voted.Add(userId);
					if (string.IsNullOrEmpty(user))
						CPH?.SendMessage("Vote counted, @" + userId, true);
					else
						CPH?.SendWhisper(user, "Vote counted, @" + user, true);
					Log($"[SC] - Parsed vote {vote} by {user}({userId})");
				}
			}
			else
			{
				Log($"[SC] - Couldn't parse votestring {voteString} by {user}({userId})");
                CPH?.SendWhisper(user, $"Couldn't parse your vote ({voteString}), @" + user, true);
                return false;
			}
			return true;

		}

		#endregion
	}
}
