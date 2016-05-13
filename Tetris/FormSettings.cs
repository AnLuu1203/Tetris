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
    public partial class FormSettings : Form
    {
        private FormMainMenu formMainMenu;

        public FormSettings(FormMainMenu formMainMenu)
        {
            InitializeComponent();
            this.CenterToParent();
            this.formMainMenu = formMainMenu;
        }

        private void btnMusic_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Bitmap bmp;

            if (FormMainMenu.isMusic == true)
            {
                bmp = new Bitmap("Image/Button/btnMusicOn.png");
            }
            else
            {
                bmp = new Bitmap("Image/Button/btnMusicOff.png");
            }
            g.DrawImage(bmp, 0, 0, btnMusic.Size.Width, btnMusic.Size.Height);

        }

        private void btnMusic_Click(object sender, EventArgs e)
        {
            if (FormMainMenu.isMusic)
            {
                FormMainMenu.isMusic = false;
                formMainMenu.PauseMusic();
            }
            else
            {
                FormMainMenu.isMusic = true;
                formMainMenu.PlayMusic();
            }
            btnMusic.Refresh();
                
        }

        private void btnSound_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Bitmap bmp;

            if (FormGameBoard.isSound == true)
            {
                bmp = new Bitmap("Image/Button/btnSoundOn.png");
            }
            else
            {

                bmp = new Bitmap("Image/Button/btnSoundOff.png");
            }
            g.DrawImage(bmp, 0, 0, btnSound.Size.Width, btnSound.Size.Height);

        }

        private void btnSound_Click(object sender, EventArgs e)
        {
            if (FormGameBoard.isSound == true)
            {
                FormGameBoard.isSound = false;
            }
            else
                FormGameBoard.isSound = true;

            btnSound.Refresh();
        }

        private void btnReset_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Bitmap bmp = new Bitmap("Image/Button/btnReset.png");

            g.DrawImage(bmp, 0, 0, btnReset.Size.Width, btnReset.Size.Height);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Do you want to reset your Best Score?", "", MessageBoxButtons.YesNo);

            if (ret == DialogResult.No)
                return;

            FileStream stream = new FileStream("file/BestScore.txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(stream, Encoding.ASCII);

            writer.WriteLine("0,");

            writer.Close(); stream.Close();
        }
    }
}
