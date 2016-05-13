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
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void FormStart_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap("temp.bmp");

            Graphics g = e.Graphics;

            g.DrawImage(bmp, 0, 0, 300, 300);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            //this.Close();
            
            
            FormTetris form = new FormTetris();

            form.Show();

            FormTetris.formstart = this;

            this.Visible = false;
        }
    }
}
