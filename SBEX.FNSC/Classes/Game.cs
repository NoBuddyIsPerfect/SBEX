using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace SBEX.FNSC.Classes
{


    [Serializable]
    public partial class Game
    {
        public Game()
        {
            Rounds = new List<Round>();
            Songs = new ThreadedBindingList<Song>();
            created = DateTime.Now;
        }
        [NonSerialized]
        public Match CurrentMatchup;
        [NonSerialized]
        public Round CurrentRound;

        public List<Round> Rounds { get; set; }

        public ThreadedBindingList<Song> Songs { get; set; }

        public int NoOfSongs { get; set; }
        public int ChampionshipNo { get; set; }

        public int NoOfSongsPerPerson { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool Random { get; set; }
        [NonSerialized] 
        public bool SubmissionsOpen;
        public bool AllowDoubles { get; set; }
        public string Theme { get; set; }

        public TimeSpan MaxSongLength { get; set; }
        [JsonIgnore]
        public string FileName { get { return "Championship_" + ChampionshipNo + ".txt"; } }
        [JsonIgnore]
        public string FullPath { get { return "C:\\temp\\" + FileName; } }
        public Song Winner { get; set; }
        [NonSerialized]
        public bool VotesOpen;

        [NonSerialized]
        public string ExportResult;
        public string Export()
        {
            string export = "{";
            export += "\"NoOfSongs\":\"" + NoOfSongs + "\",";
            export += "\"NoOfSongsPerPerson\":\"" + NoOfSongsPerPerson + "\",";
            export += "\"Start\":\"" + Start.ToString("dd.MM.yyyy HH:mm") + "\",";
            export += "\"End\":\"" + End.ToString("dd.MM.yyyy HH:mm") + "\",";
            export += "\"Theme\":\"" + Theme + "\",";
            export += "\"Random\":\"" + Random + "\",";
            export += "\"Winner\":" + Winner?.Export() + ",";
            export += "\"Rounds\":{";
            foreach (Round round in Rounds)
                export += round.Export();
            export += "},";
            export += "\"Songs\":{";
            foreach (Song song in Songs)
                export += song.Export() + ",";
            export = export.TrimEnd(',');
            export += "}";
            export += "}";
            return export;
        }

        public string Serialize()
        {
            string output = JsonConvert.SerializeObject(this);
            return output;
        }

        public string DiscordExport()
        {
            string export = "**Theme Championship " + ChampionshipNo + ":**\n";
            export += "*" + Theme + "*\n\r";
            export += "**Winner:**" + "\n";
            export += Winner?.DiscordExport() + "\n\r";
            export += "Submitted songs:\n";
            ExportResult = export;
            foreach (Song song in Songs)
                export += song.DiscordExport() + "\n\r";
            export += "Entire championship result:\n";
            export += JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(FullPath, export);
            return export;
        }
    }



}
