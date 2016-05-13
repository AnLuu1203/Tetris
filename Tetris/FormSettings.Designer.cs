namespace Tetris
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.btnMusic = new System.Windows.Forms.Button();
            this.btnSound = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMusic
            // 
            this.btnMusic.BackColor = System.Drawing.Color.Transparent;
            this.btnMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMusic.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnMusic.FlatAppearance.BorderSize = 0;
            this.btnMusic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMusic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMusic.ForeColor = System.Drawing.Color.Transparent;
            this.btnMusic.Location = new System.Drawing.Point(41, 135);
            this.btnMusic.Name = "btnMusic";
            this.btnMusic.Size = new System.Drawing.Size(36, 28);
            this.btnMusic.TabIndex = 0;
            this.btnMusic.UseVisualStyleBackColor = false;
            this.btnMusic.Click += new System.EventHandler(this.btnMusic_Click);
            this.btnMusic.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMusic_Paint);
            // 
            // btnSound
            // 
            this.btnSound.BackColor = System.Drawing.Color.Transparent;
            this.btnSound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSound.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSound.FlatAppearance.BorderSize = 0;
            this.btnSound.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSound.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSound.ForeColor = System.Drawing.Color.Transparent;
            this.btnSound.Location = new System.Drawing.Point(41, 185);
            this.btnSound.Name = "btnSound";
            this.btnSound.Size = new System.Drawing.Size(36, 28);
            this.btnSound.TabIndex = 1;
            this.btnSound.UseVisualStyleBackColor = false;
            this.btnSound.Click += new System.EventHandler(this.btnSound_Click);
            this.btnSound.Paint += new System.Windows.Forms.PaintEventHandler(this.btnSound_Paint);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Location = new System.Drawing.Point(41, 257);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(36, 28);
            this.btnReset.TabIndex = 2;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.Paint += new System.Windows.Forms.PaintEventHandler(this.btnReset_Paint);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(286, 338);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSound);
            this.Controls.Add(this.btnMusic);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMusic;
        private System.Windows.Forms.Button btnSound;
        private System.Windows.Forms.Button btnReset;
    }
}