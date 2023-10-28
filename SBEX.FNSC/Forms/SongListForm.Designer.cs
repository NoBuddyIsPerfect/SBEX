namespace SBEX.FNSC.Forms
{
    partial class SongListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtSaveGame = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numVotesSeconds = new System.Windows.Forms.NumericUpDown();
            this.btnOpenVoting60 = new System.Windows.Forms.Button();
            this.btnCoinflip = new System.Windows.Forms.Button();
            this.btnExportDC = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnCloseVoting = new System.Windows.Forms.Button();
            this.btnOpenVoting = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboVoteUser = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnVote2 = new System.Windows.Forms.Button();
            this.btnVote1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numPlayingTime = new System.Windows.Forms.NumericUpDown();
            this.cboSongsPerPerson = new System.Windows.Forms.ComboBox();
            this.cboNoOfSongs = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSCNo = new System.Windows.Forms.TextBox();
            this.chkRandom = new System.Windows.Forms.CheckBox();
            this.chkDoubles = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTheme = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSetup = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboSubmitUser = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSubmissionTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArtist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFinalPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisplayText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVotesSeconds)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayingTime)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox5.Controls.Add(this.txtSaveGame);
            this.groupBox5.Controls.Add(this.btnLoad);
            this.groupBox5.Controls.Add(this.btnSave);
            this.groupBox5.Location = new System.Drawing.Point(481, 366);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(99, 100);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Saving";
            // 
            // txtSaveGame
            // 
            this.txtSaveGame.Location = new System.Drawing.Point(6, 15);
            this.txtSaveGame.Name = "txtSaveGame";
            this.txtSaveGame.Size = new System.Drawing.Size(75, 20);
            this.txtSaveGame.TabIndex = 1;
            this.txtSaveGame.Text = "savegame";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(6, 68);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 39);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.numVotesSeconds);
            this.groupBox4.Controls.Add(this.btnOpenVoting60);
            this.groupBox4.Controls.Add(this.btnCoinflip);
            this.groupBox4.Controls.Add(this.btnExportDC);
            this.groupBox4.Controls.Add(this.btnExport);
            this.groupBox4.Controls.Add(this.btnCloseVoting);
            this.groupBox4.Controls.Add(this.btnOpenVoting);
            this.groupBox4.Controls.Add(this.btnNext);
            this.groupBox4.Location = new System.Drawing.Point(327, 246);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(253, 114);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "General";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label9.Location = new System.Drawing.Point(224, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "sec";
            // 
            // numVotesSeconds
            // 
            this.numVotesSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numVotesSeconds.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numVotesSeconds.Location = new System.Drawing.Point(180, 18);
            this.numVotesSeconds.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numVotesSeconds.Name = "numVotesSeconds";
            this.numVotesSeconds.Size = new System.Drawing.Size(38, 18);
            this.numVotesSeconds.TabIndex = 8;
            this.toolTip1.SetToolTip(this.numVotesSeconds, "Number of seconds to keep voting open for");
            this.numVotesSeconds.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // btnOpenVoting60
            // 
            this.btnOpenVoting60.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.btnOpenVoting60.Location = new System.Drawing.Point(87, 16);
            this.btnOpenVoting60.Name = "btnOpenVoting60";
            this.btnOpenVoting60.Size = new System.Drawing.Size(91, 22);
            this.btnOpenVoting60.TabIndex = 7;
            this.btnOpenVoting60.Text = "Open votes for";
            this.toolTip1.SetToolTip(this.btnOpenVoting60, "Open voting and close it after X seconds");
            this.btnOpenVoting60.UseVisualStyleBackColor = true;
            this.btnOpenVoting60.Click += new System.EventHandler(this.btnOpenVoting60_Click);
            // 
            // btnCoinflip
            // 
            this.btnCoinflip.Location = new System.Drawing.Point(87, 44);
            this.btnCoinflip.Name = "btnCoinflip";
            this.btnCoinflip.Size = new System.Drawing.Size(156, 23);
            this.btnCoinflip.TabIndex = 3;
            this.btnCoinflip.Text = "Coinflip";
            this.btnCoinflip.UseVisualStyleBackColor = true;
            this.btnCoinflip.Click += new System.EventHandler(this.btnCoinflip_Click);
            // 
            // btnExportDC
            // 
            this.btnExportDC.Location = new System.Drawing.Point(168, 73);
            this.btnExportDC.Name = "btnExportDC";
            this.btnExportDC.Size = new System.Drawing.Size(75, 34);
            this.btnExportDC.TabIndex = 6;
            this.btnExportDC.Text = "Export DC";
            this.toolTip1.SetToolTip(this.btnExportDC, "Export the current chamionship to Discord");
            this.btnExportDC.UseVisualStyleBackColor = true;
            this.btnExportDC.Click += new System.EventHandler(this.btnExportDC_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(87, 73);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 34);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.toolTip1.SetToolTip(this.btnExport, "Export the current chamionship to the file system");
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCloseVoting
            // 
            this.btnCloseVoting.Location = new System.Drawing.Point(6, 44);
            this.btnCloseVoting.Name = "btnCloseVoting";
            this.btnCloseVoting.Size = new System.Drawing.Size(75, 23);
            this.btnCloseVoting.TabIndex = 2;
            this.btnCloseVoting.Text = "Close votes";
            this.toolTip1.SetToolTip(this.btnCloseVoting, "Close voting manually");
            this.btnCloseVoting.UseVisualStyleBackColor = true;
            this.btnCloseVoting.Click += new System.EventHandler(this.btnCloseVoting_Click);
            // 
            // btnOpenVoting
            // 
            this.btnOpenVoting.Location = new System.Drawing.Point(6, 16);
            this.btnOpenVoting.Name = "btnOpenVoting";
            this.btnOpenVoting.Size = new System.Drawing.Size(75, 22);
            this.btnOpenVoting.TabIndex = 1;
            this.btnOpenVoting.Text = "Open votes";
            this.toolTip1.SetToolTip(this.btnOpenVoting, "Open voting until closed manually");
            this.btnOpenVoting.UseVisualStyleBackColor = true;
            this.btnOpenVoting.Click += new System.EventHandler(this.btnOpenVoting_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(6, 74);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 34);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Next battle";
            this.toolTip1.SetToolTip(this.btnNext, "Continue to the next battle");
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox3.Controls.Add(this.cboVoteUser);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.btnVote2);
            this.groupBox3.Controls.Add(this.btnVote1);
            this.groupBox3.Location = new System.Drawing.Point(327, 366);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(148, 100);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Voting";
            // 
            // cboVoteUser
            // 
            this.cboVoteUser.DisplayMember = "display";
            this.cboVoteUser.FormattingEnabled = true;
            this.cboVoteUser.Location = new System.Drawing.Point(6, 37);
            this.cboVoteUser.Name = "cboVoteUser";
            this.cboVoteUser.Size = new System.Drawing.Size(132, 21);
            this.cboVoteUser.TabIndex = 22;
            this.toolTip1.SetToolTip(this.cboVoteUser, "User to vote as");
            this.cboVoteUser.ValueMember = "id";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "User";
            // 
            // btnVote2
            // 
            this.btnVote2.Location = new System.Drawing.Point(75, 64);
            this.btnVote2.Name = "btnVote2";
            this.btnVote2.Size = new System.Drawing.Size(63, 23);
            this.btnVote2.TabIndex = 3;
            this.btnVote2.Text = "Vote 2";
            this.toolTip1.SetToolTip(this.btnVote2, "Send a vote as the above user for Song No 2");
            this.btnVote2.UseVisualStyleBackColor = true;
            this.btnVote2.Click += new System.EventHandler(this.btnVote2_Click);
            // 
            // btnVote1
            // 
            this.btnVote1.Location = new System.Drawing.Point(6, 64);
            this.btnVote1.Name = "btnVote1";
            this.btnVote1.Size = new System.Drawing.Size(63, 23);
            this.btnVote1.TabIndex = 2;
            this.btnVote1.Text = "Vote 1";
            this.toolTip1.SetToolTip(this.btnVote1, "Send a vote as the above user for Song No 1");
            this.btnVote1.UseVisualStyleBackColor = true;
            this.btnVote1.Click += new System.EventHandler(this.btnVote1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.numPlayingTime);
            this.groupBox2.Controls.Add(this.cboSongsPerPerson);
            this.groupBox2.Controls.Add(this.cboNoOfSongs);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnModify);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtSCNo);
            this.groupBox2.Controls.Add(this.chkRandom);
            this.groupBox2.Controls.Add(this.chkDoubles);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtTheme);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnSetup);
            this.groupBox2.Location = new System.Drawing.Point(136, 247);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 219);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "GameSetup";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 167);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Initial secs";
            // 
            // numPlayingTime
            // 
            this.numPlayingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.numPlayingTime.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPlayingTime.Location = new System.Drawing.Point(69, 165);
            this.numPlayingTime.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numPlayingTime.Name = "numPlayingTime";
            this.numPlayingTime.Size = new System.Drawing.Size(105, 20);
            this.numPlayingTime.TabIndex = 21;
            this.toolTip1.SetToolTip(this.numPlayingTime, "Amount of seconds every song will be played before voting is opeened");
            this.numPlayingTime.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // cboSongsPerPerson
            // 
            this.cboSongsPerPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSongsPerPerson.FormattingEnabled = true;
            this.cboSongsPerPerson.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cboSongsPerPerson.Location = new System.Drawing.Point(69, 42);
            this.cboSongsPerPerson.Name = "cboSongsPerPerson";
            this.cboSongsPerPerson.Size = new System.Drawing.Size(105, 21);
            this.cboSongsPerPerson.TabIndex = 20;
            this.toolTip1.SetToolTip(this.cboSongsPerPerson, "Number of songs each viewer can submit");
            // 
            // cboNoOfSongs
            // 
            this.cboNoOfSongs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNoOfSongs.FormattingEnabled = true;
            this.cboNoOfSongs.Items.AddRange(new object[] {
            "2",
            "4",
            "8",
            "16",
            "32",
            "64",
            "128"});
            this.cboNoOfSongs.Location = new System.Drawing.Point(69, 16);
            this.cboNoOfSongs.Name = "cboNoOfSongs";
            this.cboNoOfSongs.Size = new System.Drawing.Size(105, 21);
            this.cboNoOfSongs.TabIndex = 19;
            this.toolTip1.SetToolTip(this.cboNoOfSongs, "Number of songs in the chamionship");
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Red;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(99, 119);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 34);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset Game";
            this.toolTip1.SetToolTip(this.btnReset, "RESET AND DELETE THE CURRENT GAME! ");
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(90, 191);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(84, 23);
            this.btnModify.TabIndex = 8;
            this.btnModify.Text = "Modify SC";
            this.toolTip1.SetToolTip(this.btnModify, "Modify the current chamionship to use the above parameters");
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "SC No";
            // 
            // txtSCNo
            // 
            this.txtSCNo.Location = new System.Drawing.Point(69, 93);
            this.txtSCNo.Name = "txtSCNo";
            this.txtSCNo.Size = new System.Drawing.Size(105, 20);
            this.txtSCNo.TabIndex = 4;
            this.txtSCNo.Text = "1";
            this.toolTip1.SetToolTip(this.txtSCNo, "Number of the chamionship (used in Discord message)");
            // 
            // chkRandom
            // 
            this.chkRandom.AutoSize = true;
            this.chkRandom.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRandom.Checked = true;
            this.chkRandom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRandom.Location = new System.Drawing.Point(6, 142);
            this.chkRandom.Name = "chkRandom";
            this.chkRandom.Size = new System.Drawing.Size(78, 17);
            this.chkRandom.TabIndex = 6;
            this.chkRandom.Text = "Random    ";
            this.toolTip1.SetToolTip(this.chkRandom, "Should songs and matched be randomized or played in order of submission submissio" +
        "n?");
            this.chkRandom.UseVisualStyleBackColor = true;
            // 
            // chkDoubles
            // 
            this.chkDoubles.AutoSize = true;
            this.chkDoubles.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDoubles.Location = new System.Drawing.Point(6, 119);
            this.chkDoubles.Name = "chkDoubles";
            this.chkDoubles.Size = new System.Drawing.Size(77, 17);
            this.chkDoubles.TabIndex = 5;
            this.chkDoubles.Text = "Doubles    ";
            this.toolTip1.SetToolTip(this.chkDoubles, "Can the same YT URL be submitted twice?");
            this.chkDoubles.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Theme";
            // 
            // txtTheme
            // 
            this.txtTheme.Location = new System.Drawing.Point(69, 67);
            this.txtTheme.Name = "txtTheme";
            this.txtTheme.Size = new System.Drawing.Size(105, 20);
            this.txtTheme.TabIndex = 3;
            this.txtTheme.Text = "Open submissions";
            this.toolTip1.SetToolTip(this.txtTheme, "Theme of the chamionship");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Songs/PP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "NoOfSong";
            // 
            // btnSetup
            // 
            this.btnSetup.Location = new System.Drawing.Point(9, 191);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(76, 23);
            this.btnSetup.TabIndex = 7;
            this.btnSetup.Text = "Setup SC";
            this.toolTip1.SetToolTip(this.btnSetup, "Setup a new championship with the above parameters");
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox1.Controls.Add(this.cboSubmitUser);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTime);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Location = new System.Drawing.Point(12, 247);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 219);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Submission";
            // 
            // cboSubmitUser
            // 
            this.cboSubmitUser.DisplayMember = "display";
            this.cboSubmitUser.FormattingEnabled = true;
            this.cboSubmitUser.Location = new System.Drawing.Point(6, 31);
            this.cboSubmitUser.Name = "cboSubmitUser";
            this.cboSubmitUser.Size = new System.Drawing.Size(100, 21);
            this.cboSubmitUser.TabIndex = 23;
            this.toolTip1.SetToolTip(this.cboSubmitUser, "User to submit as");
            this.cboSubmitUser.ValueMember = "id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "time";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(6, 110);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(100, 20);
            this.txtTime.TabIndex = 2;
            this.txtTime.Text = "0";
            this.toolTip1.SetToolTip(this.txtTime, "Manual start time (if not included in URL)");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Code";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(6, 71);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtCode, "Code or URL to YT video");
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "User";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(19, 136);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSubmissionTime,
            this.colUser,
            this.colArtist,
            this.colFinalPosition,
            this.colStartTime,
            this.colUserId,
            this.colName,
            this.colCode,
            this.colDisplayText,
            this.colURL});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(600, 240);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // colSubmissionTime
            // 
            this.colSubmissionTime.DataPropertyName = "FormattedSubmissionTime";
            this.colSubmissionTime.HeaderText = "Added";
            this.colSubmissionTime.Name = "colSubmissionTime";
            this.colSubmissionTime.ReadOnly = true;
            // 
            // colUser
            // 
            this.colUser.DataPropertyName = "User";
            this.colUser.HeaderText = "User";
            this.colUser.Name = "colUser";
            this.colUser.ReadOnly = true;
            // 
            // colArtist
            // 
            this.colArtist.DataPropertyName = "Artist";
            this.colArtist.HeaderText = "Artist";
            this.colArtist.Name = "colArtist";
            this.colArtist.ReadOnly = true;
            // 
            // colFinalPosition
            // 
            this.colFinalPosition.DataPropertyName = "FinalPosition";
            this.colFinalPosition.HeaderText = "FinalPosition";
            this.colFinalPosition.Name = "colFinalPosition";
            this.colFinalPosition.ReadOnly = true;
            this.colFinalPosition.Visible = false;
            // 
            // colStartTime
            // 
            this.colStartTime.DataPropertyName = "StartTime";
            this.colStartTime.HeaderText = "StartTime";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.ReadOnly = true;
            // 
            // colUserId
            // 
            this.colUserId.DataPropertyName = "UserId";
            this.colUserId.HeaderText = "UserId";
            this.colUserId.Name = "colUserId";
            this.colUserId.ReadOnly = true;
            this.colUserId.Visible = false;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.HeaderText = "Code";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.Visible = false;
            // 
            // colDisplayText
            // 
            this.colDisplayText.DataPropertyName = "DisplayText";
            this.colDisplayText.HeaderText = "DisplayText";
            this.colDisplayText.Name = "colDisplayText";
            this.colDisplayText.ReadOnly = true;
            this.colDisplayText.Visible = false;
            // 
            // colURL
            // 
            this.colURL.DataPropertyName = "FullUrl";
            this.colURL.HeaderText = "URL";
            this.colURL.Name = "colURL";
            this.colURL.ReadOnly = true;
            // 
            // SongListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 478);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(616, 466);
            this.Name = "SongListForm";
            this.Text = "Song Championship Management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SongListForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SongListForm_FormClosed);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVotesSeconds)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayingTime)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtSaveGame;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnExportDC;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnCloseVoting;
        private System.Windows.Forms.Button btnOpenVoting;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnVote2;
        private System.Windows.Forms.Button btnVote1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkRandom;
        private System.Windows.Forms.CheckBox chkDoubles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTheme;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCoinflip;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSCNo;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cboVoteUser;
        private System.Windows.Forms.ComboBox cboSubmitUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubmissionTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArtist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFinalPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisplayText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colURL;
        private System.Windows.Forms.Button btnOpenVoting60;
        private System.Windows.Forms.ComboBox cboSongsPerPerson;
        private System.Windows.Forms.ComboBox cboNoOfSongs;
        private System.Windows.Forms.NumericUpDown numVotesSeconds;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numPlayingTime;
    }
}