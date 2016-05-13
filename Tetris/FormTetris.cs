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
    public partial class FormTetris : Form
    {
        private GameBoard gameboard; //Game Board
        private KhoiGach Block; //Khối gạch hiện tại
        private KhoiGach nextBlock; //Khối gạch kế tiếp
        private bool isPause; //Tạm dừng
        private bool isStart; //Bắt đầu
        
        //Constructor
        public FormTetris()
        {
            InitializeComponent();

            //Dịch chuyển form ra giữa màn hình
            this.CenterToScreen();
            
            isPause = false;
            isStart = false;
            
            MyTimer.Interval = 400;
        }

        //Bắt đầu trò chơi
        private void StartGame()
        {
            MyTimer.Stop();
            
            //Tạo đối tượng
            gameboard = new GameBoard(); // Game Board
            KeyCode key = new KeyCode();
            Block = new KhoiGach(key); // Khối gạch hiện tại
            key = new KeyCode();
            nextBlock = new KhoiGach(key); // Khối gạch kế tiếp

            //Cho phép các sự kiện vẽ, bàn phím hoạt động
            isStart = true;
            isPause = false;

            //Cập nhật các picture box
            pbGameBoard.Refresh();
            pbNextBlock.Refresh();
            
            //Cho thời gian chạy
            MyTimer.Start();
        }
        //Tạm dừng trò chơi
        private bool PauseGame()
        {
            if (isPause)
                return false;

            isPause = true;
            MyTimer.Stop();
            return true;
        }
        //Tiếp tục trò chơi
        private bool ContinueGame()
        {
            if (!isPause)
                return false;

            isPause = false;
            MyTimer.Start();
            return true;
        }

        //New Game
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.StartGame();
        }

        //Các thông số viên gạch
        const int wSeparator = 2;// khoảng cách 2 viên gạch
        const int WCELL = 20; // độ rộng viên gạch
        const int HCELL = 20; // chiều cao viên gạch

        //Vẽ 1 viên gạch
        private void Paint_VienGach(int X, int Y, Bitmap bmp, Graphics g)
        {
            //Tính tọa độ x y cần vẽ
            int toadoX = wSeparator + X * WCELL + wSeparator * X;
            int toadoY = wSeparator + Y * HCELL + wSeparator * Y;

            //Vẽ viên gạch
            g.DrawImage(bmp, toadoX, toadoY, 20, 20);
        }

        private Color ChooseColor(int key)
        {
            switch (key)
            {
                case 1:
                    return Color.Red;
                case 2:
                    return Color.Violet;
                case 3:
                    return Color.Yellow;
                case 4:
                    return Color.White;
                case 5:
                    return Color.Green;
                case 6:
                    return Color.Blue;
                case 7:
                    return Color.Orange;
            }
            return Color.White;
        }

        private string ChooseBlock(int type)
        {
            string fileName = "";
            switch (type)
            {
                case 1:
                    fileName = "Block1.bmp";
                    break;
                case 2:
                    fileName = "Block2.bmp";
                    break;
                case 3:
                    fileName = "Block3.bmp";
                    break;
                case 4:
                    fileName = "Block4.bmp";
                    break;
                case 5:
                    fileName = "Block5.bmp";
                    break;
                case 6:
                    fileName = "Block6.bmp";
                    break;
                case 7:
                    fileName = "Block7.bmp";
                    break;
            }
            return fileName;
        }
                   
        //Vẽ Game Board
        private void pbGameBoard_Paint(object sender, PaintEventArgs e)
        {
            if (!isStart)
                return;

            Graphics g = e.Graphics;

            Bitmap bmp;

            //Ve gameboard
            for (int i = 4; i < gameboard.Get_hang(); i++)
                for (int j = 0; j < gameboard.Get_cot(); j++)
                    if (gameboard.GetMT(i, j) != 0){
                        //Brush brush = new SolidBrush(this.ChooseColor(gameboard.GetMT(i,j)));
                        //Paint_VienGach(j, i - 4, brush, g);
                        bmp = new Bitmap(ChooseBlock(gameboard.GetMT(i,j)));
                        Paint_VienGach(j, i - 4, bmp, g);
                    }

            //Ve Khoi gach
            for (int i = 0; i < Block.Get_hang(); i++)
                for (int j = 0; j < Block.Get_cot(); j++)
                    if (Block.GetMT(i, j) != 0){
                        //Brush brush = new SolidBrush(this.ChooseColor(Block.GetMT(i,j)));
                        //Paint_VienGach(j + Block.Get_toadoX(), i + Block.Get_toadoY() - 4, brush, g);
                        bmp = new Bitmap(ChooseBlock(Block.GetMT(i,j)));
                        Paint_VienGach(j + Block.Get_toadoX(), i + Block.Get_toadoY() - 4, bmp, g);
                    }
        }

        //Vẽ Khối gạch kế tiếp
        private void pbNextBlock_Paint(object sender, PaintEventArgs e)
        {
            if (!isStart)
                return;

            Graphics g = e.Graphics;

            Bitmap bmp = new Bitmap(ChooseBlock(nextBlock.Get_type()));

            for (int i = 0; i < nextBlock.Get_hang(); i++)
                for (int j = 0; j < nextBlock.Get_cot(); j++)
                    if (nextBlock.GetMT(i, j) != 0){
                        //Brush brush = new SolidBrush(this.ChooseColor(nextBlock.GetMT(i,j)));
                        //Paint_VienGach(j + nextBlock.Get_toadoX() - 3, i + nextBlock.Get_toadoY() - 1, brush, g);
                        Paint_VienGach(j + nextBlock.Get_toadoX() - 3, i + nextBlock.Get_toadoY() - 1, bmp, g);
                    }
        }
        
        //Di chuyển, pause
        private void FormTetris_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isStart)
                return;

            //bấm phím 'P' để tạm dừng trò chơi, bấm lại phím 'P' để tiếp tục
            if (e.KeyCode == Keys.P)
            {
                if (this.PauseGame())
                    return;
                else this.ContinueGame();
            }

            // Nếu đang tạm dừng, dừng sự kiện, không cho di chuyển khối gạch
            if (isPause) return;

            //Di chuyển khối gạch
            switch (e.KeyCode)
            {
                case Keys.Right:
                    //Sang phải
                    Block.SangPhai(gameboard);
                    pbGameBoard.Refresh();
                    break;
                case Keys.Left:
                    //Sang trái
                    Block.SangTrai(gameboard);
                    pbGameBoard.Refresh();
                    break;
                case Keys.Up:
                    //Xoay
                    Block.Xoay(gameboard);
                    pbGameBoard.Refresh();
                    break;
                case Keys.Down:
                    //Rơi xuống
                    if (Block.Get_toadoY() < 4)
                        break;
                    if (Block.RoiXuong(gameboard))
                        pbGameBoard.Refresh();
                    break;
            }
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            //Khi khoi gach khong the roi xuong dc nua
            if (Block.RoiXuong(gameboard) == false)
            {
                MyTimer.Stop();

                //Kiem tra game over
                if (Block.Get_toadoY() < 4)
                {
                    //Thông báo Game Over
                    MessageBox.Show("Game Over");
                    //Dừng các sự kiện vẽ, bàn phím
                    isStart = false;
                    return;
                }

                //Gán khối gạch vào Game Board
                gameboard.GanKhoiGach(Block);
                //Kiểm tra ăn điểm
                for (int i = Block.Get_toadoY(); i < Block.Get_toadoY() + Block.Get_hang(); i++)
                    if (gameboard.KiemTraHang(i))
                        gameboard.CapnhatGameboard(i);

                //Cập nhật lại khối gạch
                Block = nextBlock;
                KeyCode key = new KeyCode();
                nextBlock = new KhoiGach(key);
                pbNextBlock.Refresh();
                MyTimer.Start();
            }
            pbGameBoard.Refresh();
        }

        private void FormTetris_Deactivate(object sender, EventArgs e)
        {
            this.PauseGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTetris_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.PauseGame();

            DialogResult ret = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo);

            if (ret == DialogResult.No)
                e.Cancel = true;

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.PauseGame();
            using (FormAbout formAbout = new FormAbout())
            {
                formAbout.ShowDialog(this);
            }
        }

    }
}
