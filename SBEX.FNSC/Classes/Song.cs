using Newtonsoft.Json;
using System;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace SBEX.FNSC.Classes
{
    [Serializable]
    public class Song
    {
        public string Name { get; set; }

        public string Artist { get; set; }
        [NonSerialized]
        public string Code;

        public string User { get; set; }
        [NonSerialized]
        public string UserId;
        [NonSerialized]
        public int FinalPosition;
        [NonSerialized]
        public DateTime SubmissionTime;
        [XmlIgnore]
        [ScriptIgnore]
        public int StartTime { get; set; }

        public string FormattedSubmissionTime { get { return SubmissionTime.ToString("HH:mm:ss"); } }
        public string Export()
        {
            string export = "{";
            export += "\"Artist\":\"" + Artist + "\",";
            export += "\"Title\":\"" + Name + "\",";
            export += "\"URL\":\"" + FullUrl + "\",";
            export += "\"User\":\"" + User + "\"";
            export += "}";
            return export;
        }

        public string DiscordExport()
        {
            string export = "";
            export += Name + "\n";
            export += "by: " + Artist + "\n";
            export += "(Link: " + FullUrl + ")\n";
            export += "Submitted by: " + User + "\n";
            return export;
        }
        [XmlIgnore]
        [ScriptIgnore]
        public string DisplayText
        {
            get
            {
                return $"{Artist} - {Name} - submitted by {User}";
            }
        }
        public string FullUrl
        {
            get
            {
                return "https://www.youtube.com/watch?v=" + Code + "&t="+StartTime;
            }
        }
        public string Serialize()
        {
            string output = JsonConvert.SerializeObject(this);
            return output;
        }

    }
}
