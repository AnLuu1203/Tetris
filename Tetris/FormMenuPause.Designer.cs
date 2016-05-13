namespace Tetris
{
    partial class FormMenuPause
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
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnContinue
            // 
            this.btnContinue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnContinue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContinue.Location = new System.Drawing.Point(29, 98);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(80, 35);
            this.btnContinue.TabIndex = 0;
            this.btnContinue.TabStop = false;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            this.btnContinue.Paint += new System.Windows.Forms.PaintEventHandler(this.btnContinue_Paint);
            this.btnContinue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMenuPause_KeyDown);
            // 
            // btnNewGame
            // 
            this.btnNewGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewGame.Location = new System.Drawing.Point(173, 98);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(80, 35);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.TabStop = false;
            this.btnNewGame.Text = "NewGame";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            this.btnNewGame.Paint += new System.Windows.Forms.PaintEventHandler(this.btnNewGame_Paint);
            this.btnNewGame.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMenuPause_KeyDown);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMainMenu.Location = new System.Drawing.Point(102, 152);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(80, 35);
            this.btnMainMenu.TabIndex = 3;
            this.btnMainMenu.TabStop = false;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            this.btnMainMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMainMenu_Paint);
            this.btnMainMenu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMenuPause_KeyDown);
            // 
            // FormMenuPause
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(276, 253);
            this.ControlBox = false;
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnContinue);
            this.Name = "FormMenuPause";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMenuPause_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMenuPause_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnMainMenu;
    }
}