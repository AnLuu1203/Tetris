using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tetris
{
    public partial class FormGameOver : Form
    {
        public FormGameOver(bool isHighScore,uint score)
        {
            InitializeComponent();
            lblHighScore.Text = "New High Score\n" + score.ToString();
            if (!isHighScore)
                lblHighScore.Hide();

        }

        static public FormGameBoard formGameBoard = null;
        //static public FormMedia formMP = null;

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            formGameBoard.StartGame();
            this.Close();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            formGameBoard.Close();
            this.Close();
        }

        private void FormGameOver_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4) && e.Alt == true)
            {
                formGameBoard.Close();
                this.Close();
            }
        }

        private void FormGameOver_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Bitmap bmp = new Bitmap("Image/BackGround/BGGameOver.jpg");

            g.DrawImage(bmp, 0, 0, this.Size.Width, this.Size.Height);
        }

        private void btnNewGame_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Bitmap bmp = new Bitmap("Image/Button/btnNewGame.png");

            g.DrawImage(bmp, -3, 0, btnNewGame.Size.Width + 6, btnNewGame.Size.Height);
        }

        private void btnMainMenu_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Bitmap bmp = new Bitmap("Image/Button/btnMainMenu.png");

            g.DrawImage(bmp, -3, 0, btnMainMenu.Size.Width + 6, btnMainMenu.Size.Height);
        }
    }
}
