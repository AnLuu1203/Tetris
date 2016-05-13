using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris
{
    class KhoiGach : MaTran, IDiChuyen
    {
        private int toadoX; //Tọa độ X của khối gạch
        private int toadoY; //Tọa độ Y của khối gạch
        private int key; //khóa, kiểu của khối gạch

        //Constructor
        public KhoiGach(KeyCode key)
            : base(key.Gethang(), key.Getcot())
        {
            toadoX = 3;

            this.key = key.GetKey();
            switch (this.key)
            {
                case 1:
                    Build_1();
                    toadoY = 2;
                    break;
                case 2:
                    Build_2();
                    toadoY = 2;
                    break;
                case 3:
                    Build_3();
                    toadoY = 2;
                    break;
                case 4:
                    Build_4();
                    toadoY = 2;
                    break;
                case 5:
                    Build_5();
                    toadoY = 2;
                    break;
                case 6:
                    Build_6();
                    toadoY = 2;
                    break;
                case 7:
                    Build_7();
                    toadoY = 3;
                    break;
            }
        }

        public int Get_toadoX()
        {
            return toadoX;
        }
        public int Get_toadoY()
        {
            return toadoY;
        }
        public int Get_type()
        {
            return this.key;
        }

        //Kiem tra khoi gach
        public bool testInside(int i, int j, GameBoard board)
        {
            if (i >= 0 && i < board.Get_hang() && j >= 0 && j < board.Get_cot())
                return true;
            else return false;
        }
        public bool testLeft(int i, int j, GameBoard board)
        {
            if (testInside(i, j, board))
            {
                if (j > 0 && board.GetMT(i, j - 1) == 0)
                    return true;
            }
            return false;
        }
        public bool testRight(int i, int j, GameBoard board)
        {
            if (testInside(i, j, board))
            {
                if (j < board.Get_cot() - 1 && board.GetMT(i, j + 1) == 0)
                    return true;
            }
            return false;
        }
        public bool testDown(int i, int j, GameBoard board)
        {

            if (testInside(i, j, board))
            {
                if (i < board.Get_hang() - 1 && board.GetMT(i + 1, j) == 0)
                    return true;
            }
            return false;
        }

        //Di chuyển khối gạch sang trái
        public void SangTrai(GameBoard board)
        {
            for (int i = 0; i < this.hang; i++)
            {
                for (int j = 0; j < this.cot; j++)
                    if (this.matran[i, j] != 0)
                        if (!testLeft(i + this.toadoY, j + this.toadoX, board))
                            return;
            }
            this.toadoX--;
        }
        //Di chuyển khối gạch sang phải
        public void SangPhai(GameBoard board)
        {
            for (int i = 0; i < this.hang; i++)
            {
                for (int j = 0; j < this.cot; j++)
                    if (this.matran[i, j] != 0)
                        if (!testRight(i + this.toadoY, j + this.toadoX, board))
                            return;
            }
            this.toadoX++;
        }
        //Di chuyển khối gạch rơi xuống
        public bool RoiXuong(GameBoard board)
        {
            for (int i = 0; i < this.hang; i++)
            {
                for (int j = 0; j < this.cot; j++)
                    if (this.matran[i, j] != 0)
                        if (!testDown(i + this.toadoY, j + this.toadoX, board))
                            return false;
            }
            toadoY++;
            return true;
        }
        //Xoay khối gạch
        public void Xoay(GameBoard board)
        {
            int h = this.cot;
            int c = this.hang;
            int[,] result = new int[h, c];

            for (int i = this.hang - 1; i >= 0; i--)
                for (int j = this.cot - 1; j >= 0; j--)
                    result[j, this.hang - 1 - i] = this.matran[i, j];

            if (this.key == 7)
            {
                if (h == 4 && c == 1)
                    this.toadoX++;
                else
                    this.toadoX--;
            }

            //Kiem tra dieu kien
            while (this.toadoX + c > board.Get_cot())
                this.toadoX--;
            while (this.toadoX < 0)
                this.toadoX++;

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (!testInside(i + this.toadoY, j + this.toadoX, board) || board.GetMT(i + this.toadoY, j + toadoX) != 0)
                        return;
                }
            }

            this.matran = result;
            this.hang = h;
            this.cot = c;
        }
        
        //xây dựng khối gạch
        private void Build_1()
        {
            matran[0, 0] = key; matran[0, 1] = key; matran[0, 2] = key;
            matran[1, 0] = 0; matran[1, 1] = key; matran[1, 2] = 0;
            this.hang = 2; this.cot = 3;
        }
        private void Build_2()
        {
            matran[0, 0] = 0; matran[0, 1] = key; matran[0, 2] = key;
            matran[1, 0] = key; matran[1, 1] = key; matran[1, 2] = 0;
            this.hang = 2; this.cot = 3;
        }
        private void Build_3()
        {
            matran[0, 0] = key; matran[0, 1] = key; matran[0, 2] = 0;
            matran[1, 0] = 0; matran[1, 1] = key; matran[1, 2] = key;
            this.hang = 2; this.cot = 3;
        }
        private void Build_4()
        {
            matran[0, 0] = key; matran[0, 1] = 0; matran[0, 2] = 0;
            matran[1, 0] = key; matran[1, 1] = key; matran[1, 2] = key;
            this.hang = 2; this.cot = 3;
        }
        private void Build_5()
        {
            matran[0, 0] = 0; matran[0, 1] = 0; matran[0, 2] = key;
            matran[1, 0] = key; matran[1, 1] = key; matran[1, 2] = key;
            this.hang = 2; this.cot = 3;
        }
        private void Build_6()
        {
            matran[0, 0] = key; matran[0, 1] = key;
            matran[1, 0] = key; matran[1, 1] = key;
            this.hang = 2; this.cot = 2;
        }
        private void Build_7()
        {
            matran[0, 0] = key; matran[0, 1] = key; matran[0, 2] = key; matran[0, 3] = key;
            this.hang = 1; this.cot = 4;
        }

    }
}
