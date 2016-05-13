using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.IO;

namespace Tetris
{
    public partial class FormMainMenu : Form
    {
        static public bool isMusic;

        public FormMainMenu()
        {

            InitializeComponent();
            ReadStatusSound();
            wmpMusic.Hide();
            //Nhạc
            if (isMusic == false)
                PauseMusic();
            else PlayMusic();
        }

        //Chạy nhạc
        public void PlayMusic()
        {
            wmpMusic.Ctlcontrols.play();
        }
        //Dừng nhạc
        public void PauseMusic()
        {
            wmpMusic.Ctlcontrols.pause();
        }

        private void ReadStatusSound()
        {
            FileStream stream = new FileStream("file/StatusSound.txt", FileMode.Open);
            StreamReader reader = new StreamReader(stream, Encoding.ASCII);

            string buf = "";

            Matrix.ReadItem(reader, ref buf);

            FormMainMenu.isMusic = bool.Parse(buf); ;
            

            Matrix.ReadItem(reader, ref buf);
            //if (Int32.Parse(buf) == 0)
            FormGameBoard.isSound = bool.Parse(buf); ;
            //else FormGameBoard.isSound = true;

            reader.Close(); stream.Close();
        }
        private void WriteStatusSound()
        {
            FileStream stream = new FileStream("file/StatusSound.txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(stream, Encoding.ASCII);

            writer.Write(FormMainMenu.isMusic); writer.Write(",");
            writer.Write(FormGameBoard.isSound); writer.WriteLine(",");

            writer.Close(); stream.Close();
        }

        
        private void btnPlay_Click(object sender, EventArgs e)
        {
            FormGameBoard.formMainMenu = this;
            this.Hide();
            FormGameBoard formGameBoard = new FormGameBoard();
            formGameBoard.Show();
        }

        private void FormMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ret = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo);

            if (ret == DialogResult.No)
                e.Cancel = true;
            else
                this.WriteStatusSound();
        }

        private void FormMainMenu_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Bitmap bmp = new Bitmap("Image/BackGround/BGTetris.bmp");

            g.DrawImage(bmp, 0, 0, 425, 520);
        }

        private void btnPlay_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Bitmap bmp = new Bitmap("Image/Button/btnPlay.png");

            g.DrawImage(bmp, 0, 0, btnPlay.Size.Width , btnPlay.Size.Height);
        }

        private void btnSettings_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Bitmap bmp = new Bitmap("Image/Button/btnSettings.png");

            g.DrawImage(bmp, 0, 0, btnSettings.Size.Width, btnSettings.Size.Height);
        }

        private void btnHelp_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Bitmap bmp = new Bitmap("Image/Button/btnHelp.png");

            g.DrawImage(bmp, 0, 0, btnHelp.Size.Width, btnHelp.Size.Height);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            using (FormHelpAndCredits formHelp = new FormHelpAndCredits(true))
            {
                formHelp.ShowDialog(this);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (FormSettings formSettings = new FormSettings(this))
            {
                formSettings.ShowDialog(this);
            }
        }

        private void btnCredits_Click(object sender, EventArgs e)
        {
            using (FormHelpAndCredits formHelp = new FormHelpAndCredits(false))
            {
                formHelp.ShowDialog(this);
            }

        }

        private void btnCredits_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Bitmap bmp = new Bitmap("Image/Button/btnCredits.png");

            g.DrawImage(bmp, 0, 0, btnCredits.Size.Width, btnCredits.Size.Height);
        }

        //Nếu nhạc hết, tiếp tục chạy lại
        private void wmpMusic_StatusChange(object sender, EventArgs e)
        {
            if (wmpMusic.status.Contains("Stop"))
            {
                wmpMusic.Ctlcontrols.play();
            }
        }

        private void FormMainMenu_Activated(object sender, EventArgs e)
        {
            FileStream stream = new FileStream("file/BestScore.txt", FileMode.Open);
            StreamReader reader = new StreamReader(stream, Encoding.ASCII);

            string buf="";
            Matrix.ReadItem(reader, ref buf);

            int s = Int32.Parse(buf);

            lblBestScore.Text = "Best Score: " + s.ToString();
            lblBestScore.Refresh();

            reader.Close(); stream.Close();
        }
    }
}
