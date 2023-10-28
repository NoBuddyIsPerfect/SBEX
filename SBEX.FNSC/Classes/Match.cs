using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SBEX.FNSC.Classes
{
    [Serializable]
    public class Match
    {
        public Song Song1 { get; set; }

        public int Votes1 { get; set; }

        public Song Song2 { get; set; }

        public int Votes2 { get; set; }
        
        [JsonIgnore]
        public int VotingTime;

        public Song Winner { get; set; }
        [NonSerialized]
        public List<string> Voted = new List<string>();
        public int Position { get; set; }
        [NonSerialized]
        public bool CanBeVoted = false;
        public string Export()
        {
            string export = "{";
            export += "\"Song1\":{";
            export += Song1.Export();
            export += "},";
            export += "\"Song2\":{";
            export += Song2.Export();
            export += "},";
            export += "\"Winner\":{";
            export += Winner?.Export();
            export += "},";
            export += "\"Voters\":\"";
            foreach (string voter in Voted)
                export += voter + ",";
            export = export.TrimEnd(',');
            export += "\",";
            export += "\"Votes1\":\"" + Votes1 + "\",";
            export += "\"Votes2\":\"" + Votes2 + "\",";
            export += "\"Position\":\"" + Position + "\"";

            export += "}";
            return export;

        }
        public string Serialize()
        {
            string output = JsonConvert.SerializeObject(this);
            return output;
        }

    }

}
