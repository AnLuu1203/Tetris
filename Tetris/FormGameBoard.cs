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
    public partial class FormGameBoard : Form
    {
        private GameBoard gameboard; //Game Board
        private Block curBlock; //Khối gạch hiện tại
        private Block nextBlock; //Khối gạch kế tiếp
        private Score score;
        private bool isPause; //Tạm dừng
        private bool isStart; //Bắt đầu
        static public bool isSound; //Chỉnh âm thanh trong Settings

        public FormGameBoard()
        {
            InitializeComponent();
            this.CenterToParent();
            wmpSoundScore.Hide();
            wmpSoundLevelUp.Hide();

            wmpSoundScore.URL = "Sound/Score.mp3";
            wmpSoundScore.Ctlcontrols.stop();
            wmpSoundLevelUp.URL = "Sound/LevelUp.mp3";
            wmpSoundLevelUp.Ctlcontrols.stop();

            isPause = false;
            isStart = false;

            MyTimer.Interval = 400;

            if (LoadGame() == false)
            {
                this.Focus();
                StartGame();
            }
            else
            {
                DialogResult ret = MessageBox.Show("Continue Game?", "Continue", MessageBoxButtons.YesNo);
                if (ret == DialogResult.Yes)
                {
                    isStart = true;
                    MyTimer.Start();
                }
                else
                {
                    this.Focus();
                    StartGame();
                }
            }
        }

        static public FormMainMenu formMainMenu; //đối tượng form mainmenu
        
        //Load Game từ file
        private bool LoadGame()
        {
            gameboard = new GameBoard();
            FileStream stream = new FileStream("file/gameboard.txt",FileMode.Open);
            StreamReader reader = new StreamReader(stream, Encoding.ASCII);
            
            //điều kiện
            if (gameboard.LoadMatrix(stream, reader) == false)
                return false;

            //Đọc curBlock từ file curBlock.txt
            TypeBlock key = new TypeBlock();
            curBlock = new Block(key); // Khối gạch hiện tại
            stream = new FileStream("file/curBlock.txt", FileMode.Open);
            reader = new StreamReader(stream, Encoding.ASCII);
            curBlock.LoadMatrix(stream, reader);

            //Đọc nextBlock từ file nextBlock.txt
            key = new TypeBlock();
            nextBlock = new Block(key); // Khối gạch kế tiếp
            stream = new FileStream("file/nextBlock.txt", FileMode.Open);
            reader = new StreamReader(stream, Encoding.ASCII);
            nextBlock.LoadMatrix(stream, reader);

            score = new Score();
            score.LoadScore("file/Score.txt");
            score.IncreaseLevel();
            MyTimer.Interval = (int)score.Get_Time();
            lblScore.Text = score.Get_Score().ToString(); lblScore.Refresh();
            lblLevel.Text = score.Get_Level().ToString(); lblLevel.Refresh();
            lblCombo.Hide();
            lblLevelUp.Hide();

            return true;
        }

        //Bắt đầu trò chơi
        public void StartGame()
        {
            MyTimer.Stop();

            //Tạo đối tượng
            gameboard = new GameBoard(); // Game Board
            score = new Score();

            TypeBlock key = new TypeBlock();
            curBlock = new Block(key); // Khối gạch hiện tại

            key = new TypeBlock();
            nextBlock = new Block(key); // Khối gạch kế tiếp
            


            //Cho phép các sự kiện vẽ, bàn phím hoạt động
            isStart = true;
            isPause = false;

            //Cập nhật các picture box
            pbGameBoard.Refresh();
            pbNextBlock.Refresh();
            
            lblScore.Text = "0"; lblScore.Refresh();
            lblLevel.Text = "1"; lblLevel.Refresh();
            lblCombo.Hide();
            lblLevelUp.Hide();

            MyTimer.Interval = (int)score.Get_Time();
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
            using (FormMenuPause formPause = new FormMenuPause())
            {
                FormMenuPause.formGameBoard = this;
                formPause.ShowDialog(this);
            }

            return true;
        }
        //Tiếp tục trò chơi
        public bool ContinueGame()
        {
            if (!isPause)
                return false;

            isPause = false;
            MyTimer.Start();
            return true;
        }

        //Các thông số viên gạch
        const int wSeparator = 2;// khoảng cách 2 viên gạch
        const int WCELL = 20; // độ rộng viên gạch
        const int HCELL = 20; // chiều cao viên gạch

        //Vẽ 1 viên gạch
        private void PaintBlock(int X, int Y, Bitmap bmp, Graphics g)
        {
            //Tính tọa độ x y cần vẽ
            int pointX = wSeparator + X * WCELL + wSeparator * X;
            int pointY = wSeparator + Y * HCELL + wSeparator * Y;

            //Vẽ viên gạch
            g.DrawImage(bmp, pointX, pointY, 20, 20);
        }
        //Chọn hình viên gạch từ file
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
        // Đọc và ghi điểm cao nhất
        private bool WriteBestScore(uint curScore)
        {
            string buf = "";

            FileStream stream = new FileStream("file/BestScore.txt", FileMode.Open);
            StreamReader reader = new StreamReader(stream, Encoding.ASCII);

            Matrix.ReadItem(reader, ref buf);
            uint bestScore = UInt32.Parse(buf);

            reader.Close(); stream.Close();

            if (curScore <= bestScore)
                return false;

            stream = new FileStream("file/BestScore.txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(stream, Encoding.ASCII);

            writer.WriteLine(curScore.ToString() + ",");

            writer.Close(); stream.Close();
            return true;
        }

        //Vẽ GameBoard
        private void pbGameBoard_Paint(object sender, PaintEventArgs e)
        {
            if (!isStart)
                return;

            Graphics g = e.Graphics;

            Bitmap bmp;

            //Ve gameboard
            for (int i = 4; i < gameboard.Get_row(); i++)
                for (int j = 0; j < gameboard.Get_col(); j++)
                    if (gameboard.Get_matrix(i, j) != 0)
                    {
                        //Brush brush = new SolidBrush(this.ChooseColor(gameboard.GetMT(i,j)));
                        //Paint_VienGach(j, i - 4, brush, g);
                        bmp = new Bitmap(ChooseBlock(gameboard.Get_matrix(i, j)));
                        PaintBlock(j, i - 4, bmp, g);
                    }

            //Ve Khoi gach
            for (int i = 0; i < curBlock.Get_row(); i++)
                for (int j = 0; j < curBlock.Get_col(); j++)
                    if (curBlock.Get_matrix(i, j) != 0)
                    {
                        //Brush brush = new SolidBrush(this.ChooseColor(Block.GetMT(i,j)));
                        //Paint_VienGach(j + Block.Get_toadoX(), i + Block.Get_toadoY() - 4, brush, g);
                        bmp = new Bitmap(ChooseBlock(curBlock.Get_matrix(i, j)));
                        PaintBlock(j + curBlock.Get_pointX(), i + curBlock.Get_pointY() - 4, bmp, g);
                    }
        }
        //Vẽ Next Block
        private void pbNextBlock_Paint(object sender, PaintEventArgs e)
        {
            if (!isStart)
                return;

            Graphics g = e.Graphics;

            Bitmap bmp = new Bitmap(ChooseBlock(nextBlock.Get_type()));

            for (int i = 0; i < nextBlock.Get_row(); i++)
                for (int j = 0; j < nextBlock.Get_col(); j++)
                    if (nextBlock.Get_matrix(i, j) != 0)
                    {
                        //Brush brush = new SolidBrush(this.ChooseColor(nextBlock.GetMT(i,j)));
                        //Paint_VienGach(j + nextBlock.Get_toadoX() - 3, i + nextBlock.Get_toadoY() - 1, brush, g);
                        PaintBlock(j + nextBlock.Get_pointX() - 3, i + nextBlock.Get_pointY() - 1, bmp, g);
                    }
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            //Khi khoi gach khong the roi xuong dc nua
            if (curBlock.Down(gameboard) == false)
            {
                MyTimer.Stop();

                //Gán khối gạch vào Game Board
                gameboard.AssignBlock(curBlock);
                
                //Kiem tra game over
                if (gameboard.isGameOver() == true)
                {
                    //Dừng các sự kiện vẽ, bàn phím
                    isStart = false;

                    //Thông báo Game Over
                    bool isHighScore = WriteBestScore(score.Get_Score());
                    using (FormGameOver formGO = new FormGameOver(isHighScore,score.Get_Score()))
                    {
                        FormGameOver.formGameBoard = this;
                        formGO.ShowDialog(this);
                    }
                    return;
                }
                
                //Kiểm tra ăn điểm
                byte count = 0; // Điếm combo
                for (int i = curBlock.Get_pointY(); i < curBlock.Get_pointY() + curBlock.Get_row(); i++)
                    if (gameboard.TestRowScore(i))
                    {
                        count++;
                        gameboard.RefreshGameBoard(i);
                    }
                byte curLevel = score.Get_Level();
                // Nếu có ăn điểm
                if (count > 0)
                {
                    // Âm thanh
                    if (isSound)
                        wmpSoundScore.Ctlcontrols.play();

                    // Nếu có combo
                    if (count > 1)
                    {
                        //Hiện thông báo (label) combo 
                        lblCombo.Text = "COMBO\n+" + ((count-1) * 5).ToString();
                        lblCombo.Refresh();
                        lblCombo.Show();
                        TimerNotice.Start();
                    }

                    score.Set_Combo(count); // Set combo cho score
                    score.IncreaseScore(); // Tăng điểm
                    //Kiểm tra Level Up
                    if (curLevel < score.Get_Level())
                    {
                        // Âm thanh
                        if (isSound)
                            wmpSoundLevelUp.Ctlcontrols.play();
                        // Hiện thông báo Level Up
                        lblLevelUp.Show();
                        TimerNotice.Start();
                    }
                    // Chỉnh lại thời gian (speed)
                    MyTimer.Interval = (int)score.Get_Time();
                    // Cập nhật lblScore
                    lblScore.Text = score.Get_Score().ToString();
                    lblScore.Refresh();
                    // Cập nhật lblLevel
                    lblLevel.Text = score.Get_Level().ToString();
                    lblLevel.Refresh();
                }
                
                //Cập nhật lại khối gạch
                curBlock = nextBlock;
                TypeBlock key = new TypeBlock();
                nextBlock = new Block(key);
                pbNextBlock.Refresh();
                MyTimer.Start();
            }
            pbGameBoard.Refresh();
        }

        private bool Alt_F4 = false;

        private void FormGameBoard_KeyDown(object sender, KeyEventArgs e)
        {

            if ((Alt_F4 = e.KeyCode.Equals(Keys.F4) && e.Alt == true)||e.KeyCode == Keys.Escape)
                this.PauseGame();

            if (!isStart)
                return;
            
            //bấm phím 'Space' để tạm dừng trò chơi, bấm lại phím 'Space' để tiếp tục
            if (e.KeyCode == Keys.Space)
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
                    curBlock.Right(gameboard);
                    pbGameBoard.Refresh();
                    break;
                case Keys.Left:
                    //Sang trái
                    curBlock.Left(gameboard);
                    pbGameBoard.Refresh();
                    break;
                case Keys.Up:
                    //Xoay
                    curBlock.Rolate(gameboard);
                    pbGameBoard.Refresh();
                    break;
                case Keys.Down:
                    //Rơi xuống
                    if (curBlock.Get_pointY() < 4)
                        break;
                    if (curBlock.Down(gameboard))
                        pbGameBoard.Refresh();
                   
                    break;
            }
        }

        private void FormGameBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Alt_F4)
            {
                e.Cancel = true;
                Alt_F4 = false;
                return;
            }
            // Lưu các trạng thái game
            gameboard.SaveMatrix("file/gameboard.txt");
            curBlock.SaveMatrix("file/curBlock.txt");
            nextBlock.SaveMatrix("file/nextBlock.txt");
            score.SaveScore("file/Score.txt");

            // Trở về MainMenu 
            formMainMenu.Show();
        }

        private void FormGameBoard_Deactivate(object sender, EventArgs e)
        {
            if (isStart)
                this.PauseGame();
        }

        private void TimerNotice_Tick(object sender, EventArgs e)
        {
            lblCombo.Hide();
            lblLevelUp.Hide();
            TimerNotice.Stop();
        }
    }
}
