using Newtonsoft.Json;
using SBEX.FNSC.Forms;
using SBEX.FNSC.Helpers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace StreamerBotForms
{
    public partial class MainForm : Form, IMainForm
    {
        private static CPHDummy dummy;
        private static string YouTubeApiKey = System.IO.File.ReadAllText("YTApiKey.txt");
        private static string DiscordURL = System.IO.File.ReadAllText("DiscordURL.txt");
        private static string exportPath = "E:\\FNSC";
        private static string htmlPath = "E:\\SB Extensions\\SongChampionships\\championship.html";
        private static Dictionary<string, object> myargs;
        private static SongListForm form;
        public void Log(string message, bool isWhisper, string username="")
        {
            
            string logmessage = (!isWhisper) ? message : $"Whisper to {username}: {message}";
             this.Invoke(writeLogMessage, logmessage);
          //  listBoxLog.Items.Add(logmessage);
        }
        private delegate void WriteLogMessage(string logMessage);
        private WriteLogMessage writeLogMessage;
        private void WriteLogMessageMethod(string logMessage)
        {
            listBoxLog.Items.Add(DateTime.Now.ToString("T")+" - "+logMessage);
            int nItems = (int)(listBoxLog.Height / listBoxLog.ItemHeight);
            listBoxLog.TopIndex = listBoxLog.Items.Count - nItems;
        }


        string users = "[{\"id\":\"108639097\",\"userName\":\"sukaably\",\"display\":\"sukaably\",\"role\":1,\"isSubscribed\":false},{\"id\":\"19264788\",\"userName\":\"nightbot\",\"display\":\"Nightbot\",\"role\":3,\"isSubscribed\":false},{\"id\":\"541450924\",\"userName\":\"creatisbot\",\"display\":\"CreatisBot\",\"role\":1,\"isSubscribed\":false},{\"id\":\"875001024\",\"userName\":\"notabotdef9\",\"display\":\"notabotdef9\",\"role\":1,\"isSubscribed\":false},{\"id\":\"206992018\",\"userName\":\"nobuddyisperfect\",\"display\":\"NoBuddyIsPerfect\",\"role\":4,\"isSubscribed\":true}]";

        public MainForm()
        {
            InitializeComponent();
            dummy = new CPHDummy(this);
            ResetArgs();
            writeLogMessage = new WriteLogMessage(WriteLogMessageMethod);
            List<SBUser> baseUsers = JsonConvert.DeserializeObject<List<SBUser>>(users);
            List <SBUser> voteUsers = new List<SBUser>(baseUsers);
            List<SBUser> submitUsers = new List<SBUser>(baseUsers);

            cboVoteUser.DataSource = voteUsers;
            cboSubmitUser.DataSource = submitUsers;

           

        }
        System.Windows.Forms.Timer userTimer;

        private bool ExecuteDummy(Dictionary<string, object> args)
        {
            if (form == null)
            {
                dummy.LogDebug("[SC] - Initializing management screen");
                new Thread(() =>
                {
                    userTimer = new System.Windows.Forms.Timer();
                    userTimer.Interval = 60000;
                    userTimer.Tick += UserTimer_Tick;
                    userTimer.Start();
                    Arguments parsedargs = ArgumentHelper.ParseArgs(args);
                    form = SongListForm.GetInstance(dummy, parsedargs);
                    form.ShowDialog();
                    form = null;
                    userTimer.Stop();

                }).Start();
            }
            return true;
        }

        private void UserTimer_Tick(object sender, EventArgs e)
        {
            dummy.SetGlobalVar("users", users, false);
            if (form != null)
                form.UpdateUsers();
        }

        private void ResetArgs()
        {
            myargs = new Dictionary<string, object>()
            {
                {"oBSScene","[NS] Song Comp"},
                {"coinFlipSource","[SC] CoinFlip"},
                {"countdownSource","[SC] Countdown 60"},
                {"exportPath", exportPath},
                {"infoSource","[SC] Info"},
                {"mainBrowserSource","[SC] Championship"},
                {"roundSource","[SC] Round"},
                
                {"voteLeftSource","[SC] Vote left"},
                {"voteRightSource","[SC] Vote right"},
                {"youTubeApiKey", YouTubeApiKey},
                {"htmlPath", htmlPath},
                {"webhookUrl", DiscordURL },
                {"users",    users}
            };
            dummy.SetGlobalVar("users", users, false);
        }



     
     

        private void btnLaunchManagement_Click(object sender, EventArgs e)
        {
            ResetArgs();
            myargs.Add("user", "NoBuddyIsPerfect");
            myargs.Add("userId", "206992018");
            ExecuteDummy(myargs);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            string code = txtCode.Text;
            ResetArgs();

            myargs.Add("command", "youtube");
            myargs.Add("rawInput", code);
            myargs.Add("user", cboSubmitUser.Text);
            myargs.Add("userId", cboSubmitUser.SelectedValue.ToString());
            SongListForm.GetInstance()?.HandleSBCall(myargs);
        }

        private void btnVote1_Click(object sender, EventArgs e)
        {
            ResetArgs();
            myargs.Add("command", "1");
            myargs.Add("rawInput", "1");
            myargs.Add("user", cboVoteUser.Text);
            myargs.Add("userId", cboVoteUser.SelectedValue.ToString());
            SongListForm.GetInstance()?.HandleSBCall(myargs);

        }

        private void btnVote2_Click(object sender, EventArgs e)
        {
            ResetArgs();
            myargs.Add("command", "2");
            myargs.Add("rawInput", "2");
            myargs.Add("user", cboVoteUser.Text);
            myargs.Add("userId", cboVoteUser.SelectedValue.ToString());
            SongListForm.GetInstance()?.HandleSBCall(myargs);

        }
    }

    public interface IMainForm
    {
        void Log(string message, bool isWhisper, string username="");
    }
}
