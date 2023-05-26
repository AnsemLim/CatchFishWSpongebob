namespace CatchFishGame
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.lblHighScore = new System.Windows.Forms.Label();
            this.radioButtonOn = new System.Windows.Forms.RadioButton();
            this.radioButtonOff = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnLearderBoard = new System.Windows.Forms.Button();
            this.txtPlayer = new System.Windows.Forms.TextBox();
            this.playerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gamedbDataSet = new CatchFishGame.gamedbDataSet();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblReminded = new System.Windows.Forms.Label();
            this.playerTableAdapter = new CatchFishGame.gamedbDataSetTableAdapters.PlayerTableAdapter();
            this.tableAdapterManager = new CatchFishGame.gamedbDataSetTableAdapters.TableAdapterManager();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gamedbDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblTitle.Location = new System.Drawing.Point(247, 33);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(445, 147);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Catch Fish With SpongeBob";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoadHighScoreMove);
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnChange.Location = new System.Drawing.Point(343, 482);
            this.btnChange.Margin = new System.Windows.Forms.Padding(0);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(279, 59);
            this.btnChange.TabIndex = 1;
            this.btnChange.Text = "Change BG";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.ChangeBackGroundEvent);
            this.btnChange.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoadHighScoreMove);
            // 
            // lblHighScore
            // 
            this.lblHighScore.BackColor = System.Drawing.Color.Transparent;
            this.lblHighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighScore.Location = new System.Drawing.Point(257, 177);
            this.lblHighScore.Name = "lblHighScore";
            this.lblHighScore.Size = new System.Drawing.Size(435, 60);
            this.lblHighScore.TabIndex = 6;
            this.lblHighScore.Text = "High Score 0";
            this.lblHighScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHighScore.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoadHighScoreMove);
            // 
            // radioButtonOn
            // 
            this.radioButtonOn.AutoSize = true;
            this.radioButtonOn.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonOn.Checked = true;
            this.radioButtonOn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonOn.ForeColor = System.Drawing.Color.Green;
            this.radioButtonOn.Location = new System.Drawing.Point(54, 11);
            this.radioButtonOn.Name = "radioButtonOn";
            this.radioButtonOn.Size = new System.Drawing.Size(80, 41);
            this.radioButtonOn.TabIndex = 8;
            this.radioButtonOn.TabStop = true;
            this.radioButtonOn.Text = "On";
            this.radioButtonOn.UseVisualStyleBackColor = false;
            this.radioButtonOn.CheckedChanged += new System.EventHandler(this.SoundOnEvent);
            this.radioButtonOn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoadHighScoreMove);
            // 
            // radioButtonOff
            // 
            this.radioButtonOff.AutoSize = true;
            this.radioButtonOff.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonOff.ForeColor = System.Drawing.Color.Firebrick;
            this.radioButtonOff.Location = new System.Drawing.Point(140, 11);
            this.radioButtonOff.Name = "radioButtonOff";
            this.radioButtonOff.Size = new System.Drawing.Size(81, 41);
            this.radioButtonOff.TabIndex = 9;
            this.radioButtonOff.Text = "Off";
            this.radioButtonOff.UseVisualStyleBackColor = false;
            this.radioButtonOff.CheckedChanged += new System.EventHandler(this.SoundOffEvent);
            this.radioButtonOff.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoadHighScoreMove);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.radioButtonOff);
            this.panel1.Controls.Add(this.radioButtonOn);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Location = new System.Drawing.Point(677, 482);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 61);
            this.panel1.TabIndex = 11;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoadHighScoreMove);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Image = global::CatchFishGame.Properties.Resources.audio;
            this.pictureBox6.Location = new System.Drawing.Point(14, 11);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(31, 34);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 7;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoadHighScoreMove);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Image = global::CatchFishGame.Properties.Resources.startbtn;
            this.btnStart.Location = new System.Drawing.Point(362, 338);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(237, 129);
            this.btnStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnStart.TabIndex = 0;
            this.btnStart.TabStop = false;
            this.btnStart.Click += new System.EventHandler(this.LoadGameWindowEvent);
            this.btnStart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoadHighScoreMove);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::CatchFishGame.Properties.Resources.patrick;
            this.pictureBox3.Location = new System.Drawing.Point(614, 345);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(176, 122);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoadHighScoreMove);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::CatchFishGame.Properties.Resources.spongebob;
            this.pictureBox4.Location = new System.Drawing.Point(177, 330);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(165, 137);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoadHighScoreMove);
            // 
            // btnExit
            // 
            this.btnExit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExit.BackColor = System.Drawing.Color.Crimson;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExit.Location = new System.Drawing.Point(776, 9);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(156, 59);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.Color.SkyBlue;
            this.btnInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnInfo.Location = new System.Drawing.Point(776, 86);
            this.btnInfo.Margin = new System.Windows.Forms.Padding(0);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(156, 59);
            this.btnInfo.TabIndex = 13;
            this.btnInfo.Text = "Info";
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnLearderBoard
            // 
            this.btnLearderBoard.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnLearderBoard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLearderBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLearderBoard.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnLearderBoard.Location = new System.Drawing.Point(9, 472);
            this.btnLearderBoard.Margin = new System.Windows.Forms.Padding(0);
            this.btnLearderBoard.Name = "btnLearderBoard";
            this.btnLearderBoard.Size = new System.Drawing.Size(221, 82);
            this.btnLearderBoard.TabIndex = 14;
            this.btnLearderBoard.Text = "Leader Board";
            this.btnLearderBoard.UseVisualStyleBackColor = false;
            this.btnLearderBoard.Click += new System.EventHandler(this.btnLearderBoard_Click);
            // 
            // txtPlayer
            // 
            this.txtPlayer.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.playerBindingSource, "PlayerName", true));
            this.txtPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlayer.Location = new System.Drawing.Point(324, 240);
            this.txtPlayer.MaxLength = 20;
            this.txtPlayer.Name = "txtPlayer";
            this.txtPlayer.Size = new System.Drawing.Size(298, 44);
            this.txtPlayer.TabIndex = 15;
            this.txtPlayer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // playerBindingSource
            // 
            this.playerBindingSource.DataMember = "Player";
            this.playerBindingSource.DataSource = this.gamedbDataSet;
            // 
            // gamedbDataSet
            // 
            this.gamedbDataSet.DataSetName = "gamedbDataSet";
            this.gamedbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblReminded
            // 
            this.lblReminded.BackColor = System.Drawing.Color.Transparent;
            this.lblReminded.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReminded.ForeColor = System.Drawing.Color.Firebrick;
            this.lblReminded.Location = new System.Drawing.Point(264, 287);
            this.lblReminded.Name = "lblReminded";
            this.lblReminded.Size = new System.Drawing.Size(428, 31);
            this.lblReminded.TabIndex = 16;
            this.lblReminded.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerTableAdapter
            // 
            this.playerTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.PlayerTableAdapter = this.playerTableAdapter;
            this.tableAdapterManager.UpdateOrder = CatchFishGame.gamedbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(944, 561);
            this.Controls.Add(this.lblReminded);
            this.Controls.Add(this.txtPlayer);
            this.Controls.Add(this.btnLearderBoard);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.lblHighScore);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.lblTitle);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CatchFishGame";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gamedbDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Label lblHighScore;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.RadioButton radioButtonOn;
        private System.Windows.Forms.RadioButton radioButtonOff;
        private System.Windows.Forms.PictureBox btnStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnLearderBoard;
        private System.Windows.Forms.TextBox txtPlayer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblReminded;
        private gamedbDataSet gamedbDataSet;
        private System.Windows.Forms.BindingSource playerBindingSource;
        private gamedbDataSetTableAdapters.PlayerTableAdapter playerTableAdapter;
        private gamedbDataSetTableAdapters.TableAdapterManager tableAdapterManager;
    }
}

