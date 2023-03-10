namespace StreamerBotForms
{
    partial class MainForm
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
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.btnLaunchManagement = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboVoteUser = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnVote2 = new System.Windows.Forms.Button();
            this.btnVote1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboSubmitUser = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(12, 213);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(776, 225);
            this.listBoxLog.TabIndex = 1;
            // 
            // btnLaunchManagement
            // 
            this.btnLaunchManagement.BackColor = System.Drawing.Color.Red;
            this.btnLaunchManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunchManagement.Location = new System.Drawing.Point(167, 137);
            this.btnLaunchManagement.Name = "btnLaunchManagement";
            this.btnLaunchManagement.Size = new System.Drawing.Size(75, 34);
            this.btnLaunchManagement.TabIndex = 19;
            this.btnLaunchManagement.Text = "Launch Mgmt";
            this.btnLaunchManagement.UseVisualStyleBackColor = false;
            this.btnLaunchManagement.Click += new System.EventHandler(this.btnLaunchManagement_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox3.Controls.Add(this.cboVoteUser);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.btnVote2);
            this.groupBox3.Controls.Add(this.btnVote1);
            this.groupBox3.Location = new System.Drawing.Point(136, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(148, 100);
            this.groupBox3.TabIndex = 21;
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
            this.btnVote1.UseVisualStyleBackColor = true;
            this.btnVote1.Click += new System.EventHandler(this.btnVote1_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 195);
            this.groupBox1.TabIndex = 20;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLaunchManagement);
            this.Controls.Add(this.listBoxLog);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Button btnLaunchManagement;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboVoteUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnVote2;
        private System.Windows.Forms.Button btnVote1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboSubmitUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
    }
}

