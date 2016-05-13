namespace Tetris
{
    partial class FormGameBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGameBoard));
            this.pbGameBoard = new System.Windows.Forms.PictureBox();
            this.pbNextBlock = new System.Windows.Forms.PictureBox();
            this.MyTimer = new System.Windows.Forms.Timer(this.components);
            this.lblScore = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblCombo = new System.Windows.Forms.Label();
            this.TimerNotice = new System.Windows.Forms.Timer(this.components);
            this.lblLevelUp = new System.Windows.Forms.Label();
            this.wmpSoundScore = new AxWMPLib.AxWindowsMediaPlayer();
            this.wmpSoundLevelUp = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNextBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmpSoundScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmpSoundLevelUp)).BeginInit();
            this.SuspendLayout();
            // 
            // pbGameBoard
            // 
            this.pbGameBoard.BackColor = System.Drawing.Color.Black;
            this.pbGameBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbGameBoard.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbGameBoard.Location = new System.Drawing.Point(12, 62);
            this.pbGameBoard.Name = "pbGameBoard";
            this.pbGameBoard.Size = new System.Drawing.Size(226, 446);
            this.pbGameBoard.TabIndex = 1;
            this.pbGameBoard.TabStop = false;
            this.pbGameBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pbGameBoard_Paint);
            // 
            // pbNextBlock
            // 
            this.pbNextBlock.BackColor = System.Drawing.Color.Black;
            this.pbNextBlock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbNextBlock.Location = new System.Drawing.Point(271, 104);
            this.pbNextBlock.Name = "pbNextBlock";
            this.pbNextBlock.Size = new System.Drawing.Size(104, 108);
            this.pbNextBlock.TabIndex = 3;
            this.pbNextBlock.TabStop = false;
            this.pbNextBlock.Paint += new System.Windows.Forms.PaintEventHandler(this.pbNextBlock_Paint);
            // 
            // MyTimer
            // 
            this.MyTimer.Tick += new System.EventHandler(this.MyTimer_Tick);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(325, 357);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(21, 24);
            this.lblScore.TabIndex = 4;
            this.lblScore.Text = "0";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.ForeColor = System.Drawing.Color.White;
            this.lblLevel.Location = new System.Drawing.Point(302, 438);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(21, 24);
            this.lblLevel.TabIndex = 5;
            this.lblLevel.Text = "0";
            // 
            // lblCombo
            // 
            this.lblCombo.AutoSize = true;
            this.lblCombo.BackColor = System.Drawing.Color.Black;
            this.lblCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCombo.ForeColor = System.Drawing.Color.White;
            this.lblCombo.Location = new System.Drawing.Point(96, 144);
            this.lblCombo.Name = "lblCombo";
            this.lblCombo.Size = new System.Drawing.Size(57, 17);
            this.lblCombo.TabIndex = 6;
            this.lblCombo.Text = "Combo";
            this.lblCombo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimerNotice
            // 
            this.TimerNotice.Interval = 1000;
            this.TimerNotice.Tick += new System.EventHandler(this.TimerNotice_Tick);
            // 
            // lblLevelUp
            // 
            this.lblLevelUp.AutoSize = true;
            this.lblLevelUp.BackColor = System.Drawing.Color.Black;
            this.lblLevelUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevelUp.ForeColor = System.Drawing.Color.White;
            this.lblLevelUp.Location = new System.Drawing.Point(63, 104);
            this.lblLevelUp.Name = "lblLevelUp";
            this.lblLevelUp.Size = new System.Drawing.Size(130, 26);
            this.lblLevelUp.TabIndex = 7;
            this.lblLevelUp.Text = "LEVEL UP!!";
            // 
            // wmpSoundScore
            // 
            this.wmpSoundScore.Enabled = true;
            this.wmpSoundScore.Location = new System.Drawing.Point(378, 485);
            this.wmpSoundScore.Name = "wmpSoundScore";
            this.wmpSoundScore.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmpSoundScore.OcxState")));
            this.wmpSoundScore.Size = new System.Drawing.Size(35, 23);
            this.wmpSoundScore.TabIndex = 8;
            // 
            // wmpSoundLevelUp
            // 
            this.wmpSoundLevelUp.Enabled = true;
            this.wmpSoundLevelUp.Location = new System.Drawing.Point(311, 485);
            this.wmpSoundLevelUp.Name = "wmpSoundLevelUp";
            this.wmpSoundLevelUp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmpSoundLevelUp.OcxState")));
            this.wmpSoundLevelUp.Size = new System.Drawing.Size(35, 23);
            this.wmpSoundLevelUp.TabIndex = 9;
            // 
            // FormGameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(425, 520);
            this.ControlBox = false;
            this.Controls.Add(this.wmpSoundLevelUp);
            this.Controls.Add(this.wmpSoundScore);
            this.Controls.Add(this.lblLevelUp);
            this.Controls.Add(this.lblCombo);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.pbNextBlock);
            this.Controls.Add(this.pbGameBoard);
            this.MaximizeBox = false;
            this.Name = "FormGameBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tetris";
            this.Deactivate += new System.EventHandler(this.FormGameBoard_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGameBoard_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormGameBoard_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbGameBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNextBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmpSoundScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmpSoundLevelUp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGameBoard;
        private System.Windows.Forms.PictureBox pbNextBlock;
        private System.Windows.Forms.Timer MyTimer;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblCombo;
        private System.Windows.Forms.Timer TimerNotice;
        private System.Windows.Forms.Label lblLevelUp;
        private AxWMPLib.AxWindowsMediaPlayer wmpSoundScore;
        private AxWMPLib.AxWindowsMediaPlayer wmpSoundLevelUp;
    }
}