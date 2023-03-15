using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SBEX.FNSC.Classes
{
    [Serializable]
    public class Round
    {
        public Round()
        {
            Matches = new List<Match>();
            FinishedMatches = new List<Match>();
        }

        public int RoundNumber { get; set; }
        [NonSerialized]
        public List<Match> Matches;
        public List<Match> FinishedMatches { get; set; }

        public string Export()
        {
            string export = "{";
            export += "\"Matches\":{";
            foreach (Match match in Matches)
                export += match.Export() + ",";
            export = export.TrimEnd(',');
            export += "},";
            export += "\"FinishedMatches\":{";
            foreach (Match match in FinishedMatches)
                export += match.Export() + ",";
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
    }

}
