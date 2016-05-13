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
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
            lblAbout.Text = "Create by:\n\nLUU THIEN AN\n" + "NGUYEN TUAN ANH\n" + "LE HAI BANG\n\n"
                + "xxx@xxx.com\n";

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
