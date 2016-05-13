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
    public partial class FormMenuPause : Form
    {
        public FormMenuPause()
        {
            InitializeComponent();
        }

        static public FormGameBoard formGameBoard = null;

        private void btnContinue_Click(object sender, EventArgs e)
        {
            formGameBoard.ContinueGame();
            this.Close();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            formGameBoard.StartGame();
            this.Close();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            FormMainMenu formMainMenu = FormGameBoard.formMainMenu;

            this.Close();
            formGameBoard.Close();
        }

        private bool Alt_F4 = false;

        private void FormMenuPause_KeyDown(object sender, KeyEventArgs e)
        {
            if (Alt_F4 = (e.KeyCode.Equals(Keys.F4) && e.Alt == true))
            {
                formGameBoard.Close();
                this.Close();
            }

            if (e.KeyCode == Keys.Space)
            {
                formGameBoard.ContinueGame();
                this.Close();
            }
        }

        private void FormMenuPause_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Bitmap bmp = new Bitmap("Image/BackGround/BGPause.jpg");

            g.DrawImage(bmp, 0, 0, this.Size.Width, this.Size.Height);
        }

        private void btnContinue_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Bitmap bmp = new Bitmap("Image/Button/btnContinue.png");

            g.DrawImage(bmp, -3, 0, btnContinue.Size.Width + 6, btnContinue.Size.Height);
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
