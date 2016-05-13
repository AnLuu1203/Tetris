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
    public partial class FormHelpAndCredits : Form
    {
        private bool isHelp;

        public FormHelpAndCredits(bool isHelp)
        {
            this.isHelp = isHelp;
            InitializeComponent();
            this.CenterToParent();
        }

        private void FormHelp_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Bitmap bmp;
            if (isHelp)
            {
                bmp = new Bitmap("Image/BackGround/BGHelp.jpg");
            }
            else
            {
                bmp = new Bitmap("Image/BackGround/BGCredit.jpg");
            }

            g.DrawImage(bmp, 0, 0, this.Size.Width - 10, this.Size.Height - 20);
        }
    }
}
