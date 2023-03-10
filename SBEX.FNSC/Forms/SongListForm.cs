using Newtonsoft.Json;
using SBEX.FNSC.Classes;
using SBEX.FNSC.Helpers;
using SBEX.FNSC.Platforms;
using Streamer.bot.Plugin.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace SBEX.FNSC.Forms
{
    public partial class SongListForm : Form
    {

        private static readonly object _mutex = new object();
        private static volatile SongListForm _instance;


        private IInlineInvokeProxy CPH;
        //private Game game;
        private Game currentChampionship;
        private Arguments args;


        public static SongListForm GetInstance(IInlineInvokeProxy cph = null, Arguments args = null)
        {
            if (_instance == null)
            {
                lock (_mutex)
                {
                    if (args == null || cph == null)
                        return null;
                    if (args == null)
                        throw new ArgumentNullException("args");
                    if (cph == null)
                        throw new ArgumentNullException("cph");
                    _instance = new SongListForm(cph, args);
                    _instance.Initialize();
                }
            }

            return _instance;

        }

        public void Initialize()
        {
            try
            {
                if (string.IsNullOrEmpty(args.ExportPath))
                    btnExport.Visible = btnSave.Visible = btnLoad.Visible = false;
                if (!string.IsNullOrEmpty(args.DiscordWebhookUrl))
                    Discord.WebhookUrl = args.DiscordWebhookUrl;
                else
                    btnExportDC.Visible = false;
                Log((currentChampionship != null) ? "Game loaded" : "NoGameFound");

                if (currentChampionship == null)
                    currentChampionship = CPH?.GetGlobalVar<Game>("currentChampionship");
                if (currentChampionship != null)
                {
                    this.Text = "Song Championship Management - " + "\"" + currentChampionship.Theme + "\" (" + currentChampionship.NoOfSongs + " songs, " + currentChampionship.NoOfSongsPerPerson + " per person) - Submissions are " + (currentChampionship.SubmissionsOpen ? "open" : "closed");
                    BindChampionship();

                }
                SetupButtons();
                UpdateUsers();
            }
            catch
            {
                Log("[SC] - Error loading Game");
            }
        }

        private void BindChampionship()
        {
            txtNoOfSongs.Text = currentChampionship.NoOfSongs.ToString();
            txtSongsPP.Text = currentChampionship.NoOfSongsPerPerson.ToString();
            txtTheme.Text = currentChampionship.Theme;
            txtSCNo.Text = currentChampionship.ChampionshipNo.ToString();
            chkDoubles.Checked = currentChampionship.AllowDoubles;
            chkRandom.Checked = currentChampionship.Random;
            // dataGridView1.DataSource = currentChampionship?.Songs;
            ThreadedBindingList<Song> list = currentChampionship?.Songs;
            list.SynchronizationContext = SynchronizationContext.Current;
            dataGridView1.DataSource = list;
            list.ListChanged += Songs_ListChanged;

        }

        private void Songs_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemDeleted)
            {
                if (currentChampionship.Songs.Count < currentChampionship.NoOfSongs)
                {
                    string newtext = "Theme for championship no " + currentChampionship.ChampionshipNo + ":\n\r\n" + currentChampionship.Theme + "\n\r\n\rSubmissions are open\n\r\nSongs: " + currentChampionship.Songs.Count + "/" + currentChampionship.NoOfSongs + "\n\r\nSongs/person: " + currentChampionship.NoOfSongsPerPerson;
                    CPH?.ObsSetGdiText(args.OBSScene, args.InfoSource, newtext);
                    currentChampionship.SubmissionsOpen = true;
                    currentChampionship.Rounds.Clear();
                    currentChampionship.CurrentRound = null;
                    currentChampionship.CurrentMatchup = null;
                    SetupButtons();
                }
                if (deletedSong != null)
                {
                    CPH?.SendWhisper(deletedSong.User, $"Your song ({deletedSong.Name}) has been removed!", true);
                    deletedSong = null;
                }
            }
        }

        public SongListForm(IInlineInvokeProxy CPH, Arguments args)
        {
            this.CPH = CPH;
            this.args = args;
            InitializeComponent();



        }



        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateUsers();
        }

        private void SetupButtons()
        {
            if (currentChampionship == null)
            {
                CPH.LogDebug("[SC] - SetupButtons - No championship");
                btnLoad.Enabled =
               btnSetup.Enabled = true;
                btnSubmit.Enabled =
                    btnModify.Enabled =
                    btnReset.Enabled =
                    btnSave.Enabled =

                btnExportDC.Enabled =
                    btnExport.Enabled =
                    btnCoinflip.Enabled =
                    btnVote1.Enabled =
                    btnVote2.Enabled =
                    btnNext.Enabled =
                    btnOpenVoting.Enabled = btnOpenVoting60.Enabled = 
                    btnCloseVoting.Enabled = false;
            }
            else if (currentChampionship.SubmissionsOpen)
            {
                CPH.LogDebug("[SC] - SetupButtons - Submissions are open");
                btnSubmit.Enabled = cboSubmitUser.Items.Count > 0;
                btnModify.Enabled =
                    btnReset.Enabled =
                    btnSave.Enabled =
                    btnLoad.Enabled = true;
                btnExportDC.Enabled =
                    btnExport.Enabled =
                    btnCoinflip.Enabled =
                    btnVote1.Enabled =
                    btnVote2.Enabled =
                    btnSetup.Enabled =
                    btnNext.Enabled =
                    btnOpenVoting.Enabled = btnOpenVoting60.Enabled = 
                    btnCloseVoting.Enabled = false;
            }
            else if (currentChampionship.CurrentMatchup == null && currentChampionship.Winner == null)
            {
                CPH.LogDebug("[SC] - SetupButtons - no battle and no winner");
                btnModify.Enabled =
                btnReset.Enabled =
                btnNext.Enabled =
                btnSave.Enabled =
                btnLoad.Enabled = true;
                btnSubmit.Enabled =

                btnExportDC.Enabled =
                    btnExport.Enabled =
                    btnCoinflip.Enabled =
                    btnVote1.Enabled =
                    btnVote2.Enabled =
                    btnSetup.Enabled =
                    btnOpenVoting.Enabled = btnOpenVoting60.Enabled = 
                    btnCloseVoting.Enabled = false;

            }
            else if (currentChampionship.CurrentMatchup != null && currentChampionship.CurrentMatchup.CanBeVoted)
            {
                CPH.LogDebug("[SC] - SetupButtons - voting is open");
                btnVote1.Enabled = btnVote2.Enabled = cboVoteUser.Items.Count > 0;
                btnReset.Enabled =
                 
                btnSave.Enabled =
                btnCloseVoting.Enabled =
                btnLoad.Enabled = true;
                btnExportDC.Enabled =
                btnSubmit.Enabled =
                    btnNext.Enabled =
                    btnModify.Enabled =
                    btnExport.Enabled =
                    btnCoinflip.Enabled =
                    btnSetup.Enabled =
                    btnOpenVoting.Enabled = btnOpenVoting60.Enabled = 
                    false;

            }
            else if (currentChampionship.CurrentMatchup != null && !currentChampionship.CurrentMatchup.CanBeVoted)
            {
                CPH.LogDebug("[SC] - SetupButtons - voting is closed");
                btnCoinflip.Enabled = (currentChampionship.CurrentMatchup.Winner == null && currentChampionship.CurrentMatchup.Votes1 == currentChampionship.CurrentMatchup.Votes2);
                btnNext.Enabled = (currentChampionship.CurrentMatchup.Winner != null || currentChampionship.CurrentMatchup.Votes1 != currentChampionship.CurrentMatchup.Votes2);
                btnReset.Enabled =
                btnSave.Enabled =
                btnOpenVoting.Enabled = btnOpenVoting60.Enabled = 

                btnLoad.Enabled = true;
                btnExportDC.Enabled =
                btnVote1.Enabled =
                    btnVote2.Enabled =
                    btnSubmit.Enabled =
                    btnModify.Enabled =
                    btnExport.Enabled =

                    btnSetup.Enabled =

                    btnCloseVoting.Enabled = false;

            }
            else if (currentChampionship.Winner != null)
            {
                CPH.LogDebug("[SC] - SetupButtons - winner chosen");
                btnExportDC.Enabled =
                    btnExport.Enabled =
                btnReset.Enabled =
                btnSave.Enabled =
                btnLoad.Enabled = true;
                btnNext.Enabled =

               btnVote1.Enabled =
                btnModify.Enabled =
                btnVote2.Enabled =
                btnSubmit.Enabled =
                   btnCoinflip.Enabled =
                    btnSetup.Enabled =
                    btnOpenVoting.Enabled = btnOpenVoting60.Enabled = 
                    btnCloseVoting.Enabled = false;
            }
            //btnSubmit.Enabled = cboSubmitUser.Items.Count > 0;
            //btnVote1.Enabled = btnVote2.Enabled = cboVoteUser.Items.Count > 0;
            
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            args.ChampionshipNo = int.Parse(txtSCNo.Text);
            args.NoOfSongs = int.Parse(txtNoOfSongs.Text);
            args.NoOfSongsPerPerson = int.Parse(txtSongsPP.Text);
            args.Theme = txtTheme.Text;
            args.Random = chkRandom.Checked;
            args.DoublesAllowed = chkDoubles.Checked;
            currentChampionship = new Game();
            currentChampionship.NoOfSongs = args.NoOfSongs;
            currentChampionship.NoOfSongsPerPerson = args.NoOfSongsPerPerson;
            currentChampionship.Theme = args.Theme;
            currentChampionship.ChampionshipNo = args.ChampionshipNo;
            currentChampionship.Random = args.Random;
            currentChampionship.AllowDoubles = args.DoublesAllowed;
            currentChampionship.SubmissionsOpen = true;
            currentChampionship.GameExportPath = args.ExportPath;
            currentChampionship.HtmlPath = args.HtmlPath;
            currentChampionship.OBSScene = args.OBSScene;
            currentChampionship.MainBrowserSource = args.MainBrowserSource;
            currentChampionship.CountdownSource = args.CountdownSource;
            currentChampionship.VoteLeftSource = args.VoteLeftSource;
            currentChampionship.VoteRightSource = args.VoteRightSource;
            currentChampionship.RoundSource = args.RoundSource;
            currentChampionship.InfoSource = args.InfoSource;
            currentChampionship.CoinFlipSource = args.CoinFlipSource;
            currentChampionship.YtApiKey = args.YouTubeApiKey;
            currentChampionship.CPH = CPH;
            //CPH.LogDebug(currentChampionship.LogValues());
            CPH.SendMessage("Submissions for the theme \"" + currentChampionship.Theme + "\" are open (" + currentChampionship.NoOfSongs + " songs, " + currentChampionship.NoOfSongsPerPerson + " per person)", true);
            string text = "Theme for championship no " + currentChampionship.ChampionshipNo + ":\n\r\n" + currentChampionship.Theme + "\n\r\n\rSubmissions are open\n\r\nSongs: " + currentChampionship.Songs.Count + "/" + currentChampionship.NoOfSongs + "\n\r\nSongs/person: " + currentChampionship.NoOfSongsPerPerson;
            CPH.LogDebug("Setting text - " + args.InfoSource);
            CPH.ObsSetGdiText(args.OBSScene, args.InfoSource, text);
            CPH.LogDebug("showing source - " + args.InfoSource);
            CPH.ObsSetSourceVisibility(args.OBSScene, args.InfoSource, true);
            CPH.LogDebug("hiding battle - " + args.MainBrowserSource);
            CPH.ObsSetSourceVisibility(args.OBSScene, args.MainBrowserSource, false);
            CPH.LogDebug("binding championship");
            BindChampionship();
            CPH.LogDebug("setting up buttons");
            SetupButtons();
            CPH.LogDebug("setting up timer");
            CPH.LogDebug("setting title");
            this.Text = "Song Championship Management - " + "\"" + currentChampionship.Theme + "\" (" + currentChampionship.NoOfSongs + " songs, " + currentChampionship.NoOfSongsPerPerson + " per person) - Submissions are " + (currentChampionship.SubmissionsOpen ? "open" : "closed");
            CPH.LogDebug("done");
        }

        private void btnOpenVoting_Click(object sender, EventArgs e)
        {

            if (currentChampionship.OpenVoting(0))
                SetupButtons();
        }

        private void btnCloseVoting_Click(object sender, EventArgs e)
        {
            if (currentChampionship.CloseVoting())
                SetupButtons();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (currentChampionship.NextMatch())
                SetupButtons();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            currentChampionship.MainExport();
            SetupButtons();
        }

        private void btnExportDC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Discord.WebhookUrl))
                MessageBox.Show("WebhookUrl not set");
            currentChampionship.DCExport();
            SetupButtons();
        }

        private void btnVote1_Click(object sender, EventArgs e)
        {
            if (currentChampionship.Vote(cboVoteUser.Text, cboVoteUser.SelectedValue.ToString(), "1"))
                SetupButtons();
        }

        public bool SetWinner(Dictionary<string, object> args, string songNr)
        {
            return currentChampionship.SetWinner(songNr, args.ContainsKey("coinflip") ? true : false);
        }
        public bool HandleSBCall(Dictionary<string, object> args)
        {
            Arguments arguments = ArgumentHelper.ParseArgs(args);
            bool result = false;
            switch (arguments.Command)
            {
                case "1":
                case "2":
                    result = RegisterVote(arguments);
                    break;
                case "youtube":
                case "youtu.be":
                    result = RegisterSubmission(arguments);
                    break;
                case "next":
                    result = currentChampionship.NextMatch();
                    break;
                case "closeVoting":
                    result = currentChampionship.CloseVoting();
                    break;
                case "openVoting":
                    result = currentChampionship.OpenVoting(arguments.VotingDuration);
                    break;
                case "modifyGame":
                    result = currentChampionship.ModifyGame(arguments,true, true);
                    break;
                case "reset":
                    result = currentChampionship.Reset();
                    break;
                default:
                    return false;
            }
            SetupButtons();
            return result;
        }

        public bool RegisterVote(Arguments arguments)
        {
            return currentChampionship.Vote(arguments.User, arguments.UserId, arguments.Command);
        }
        public bool RegisterSubmission(Arguments arguments)
        {
            bool result = currentChampionship.Submit(arguments.RawInput, arguments.User, arguments.UserId);
            SetupButtons();
            return result;
        }
        private void SongListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (currentChampionship != null)
                CPH?.SetGlobalVar("currentChampionship", currentChampionship?.Serialize());
            else
                CPH?.SetGlobalVar("currentChampionship", "");
        }

        private void btnVote2_Click(object sender, EventArgs e)
        {

            if (currentChampionship.Vote(cboVoteUser.Text, cboVoteUser.SelectedValue.ToString(), "2"))
                SetupButtons();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            currentChampionship = currentChampionship.LoadGame(txtSaveGame.Text);
            SetupButtons();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            currentChampionship.SaveGame(txtSaveGame.Text);
            SetupButtons();

        }

        private void btnCoinflip_Click(object sender, EventArgs e)
        {

            CPH?.ObsSetSourceVisibility(args.OBSScene, args.CoinFlipSource, false);
            CPH?.ObsSetSourceVisibility(args.OBSScene, args.CoinFlipSource, true);
            SetupButtons();
        }

        public bool UpdateUsers()
        {
            string usersString = CPH.GetGlobalVar<string>("users", false);
            CPH.LogDebug("[SC] Users refreshed: " + usersString);

            if (!string.IsNullOrEmpty(usersString))
            {
                object v = cboVoteUser.SelectedValue;
                object s = cboSubmitUser.SelectedValue;
                List<SBUser> users = JsonConvert.DeserializeObject<List<SBUser>>(usersString);
                List<SBUser> voteUsers = new List<SBUser>(users);
                List<SBUser> submitUsers = new List<SBUser>(users);

                cboVoteUser.DataSource = voteUsers;
                cboSubmitUser.DataSource = submitUsers;
                if (v != null)
                    cboVoteUser.SelectedValue = v;
                if (s != null)
                    cboSubmitUser.SelectedValue = s;
            }
            dataGridView1.Refresh();
            SetupButtons();
            return true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (currentChampionship != null)
            {
                currentChampionship.Reset();
                currentChampionship = null;
            }
            this.Text = "Song Championship Management";
            SetupButtons();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            args.ChampionshipNo = int.Parse(txtSCNo.Text);
            args.NoOfSongs = int.Parse(txtNoOfSongs.Text);
            args.NoOfSongsPerPerson = int.Parse(txtSongsPP.Text);
            args.Theme = txtTheme.Text;
            args.Random = chkRandom.Checked;
            args.DoublesAllowed = chkDoubles.Checked;
            currentChampionship.ModifyGame(args, true, true);
            CPH?.SendMessage("Submissions are open (" + currentChampionship.NoOfSongs + " songs, " + currentChampionship.NoOfSongsPerPerson + " per person)", true);
            string text = "Theme for championship no " + currentChampionship.ChampionshipNo + ":\n\r\n" + currentChampionship.Theme + "\n\r\n\rSubmissions are open\n\r\nSongs: " + currentChampionship.Songs.Count + "/" + currentChampionship.NoOfSongs + "\n\r\nSongs/person: " + currentChampionship.NoOfSongsPerPerson;
            this.Text = "Song Championship Management - " + "\"" + currentChampionship.Theme + "\" (" + currentChampionship.NoOfSongs + " songs, " + currentChampionship.NoOfSongsPerPerson + " per person) - Submissions are " + (currentChampionship.SubmissionsOpen ? "open" : "closed");

            CPH?.ObsSetGdiText(args.OBSScene, args.InfoSource, text);
            SetupButtons();

        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSubmit_Click(null, null);
        }


        private Song deletedSong;

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            deletedSong = e.Row.DataBoundItem as Song;

        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns[colURL.Name]?.Index)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    Process.Start(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
            }
        }


        private void Log(string message)
        {
            if (currentChampionship != null)
                currentChampionship.Log(message);
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text;
            int time = int.Parse(txtTime.Text);

            if (code.StartsWith("http"))
                currentChampionship.Submit(code + (time > 0 && !code.Contains("&t=") ? $"&t={time}" : ""), cboSubmitUser.Text, cboSubmitUser.SelectedValue.ToString());
            else
            {
                currentChampionship.Submit("https://www.youtube.com/watch?v=" + code + "&t=" + time, cboSubmitUser.Text, cboSubmitUser.SelectedValue.ToString());
            }

            txtCode.Text = string.Empty;
            SetupButtons();
        }

        private void btnOpenVoting60_Click(object sender, EventArgs e)
        {

            if (currentChampionship.OpenVoting(60))
                SetupButtons();
        }
    }
}
