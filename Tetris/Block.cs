using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Tetris
{
    class Block : Matrix, IMove
    {
        private int pointX; //Tọa độ X của khối gạch
        private int pointY; //Tọa độ Y của khối gạch
        private byte type; //khóa, kiểu của khối gạch

        //Constructor
        public Block(TypeBlock key)
            : base(key.GetRow(), key.GetCol())
        {
            pointX = 3;

            this.type = key.GetType();
            switch (this.type)
            {
                case 1:
                    Build_1();
                    pointY = 2;
                    break;
                case 2:
                    Build_2();
                    pointY = 2;
                    break;
                case 3:
                    Build_3();
                    pointY = 2;
                    break;
                case 4:
                    Build_4();
                    pointY = 2;
                    break;
                case 5:
                    Build_5();
                    pointY = 2;
                    break;
                case 6:
                    Build_6();
                    pointY = 2;
                    break;
                case 7:
                    Build_7();
                    pointY = 3;
                    break;
            }
        }

        public int Get_pointX()
        {
            return pointX;
        }
        public int Get_pointY()
        {
            return pointY;
        }
        public int Get_type()
        {
            return this.type;
        }

        //Kiem tra khoi gach
        public bool testInside(int i, int j, GameBoard board)
        {
            if (i >= 0 && i < board.Get_row() && j >= 0 && j < board.Get_col())
                return true;
            else return false;
        }
        public bool testLeft(int i, int j, GameBoard board)
        {
            if (testInside(i, j, board))
            {
                if (j > 0 && board.Get_matrix(i, j - 1) == 0)
                    return true;
            }
            return false;
        }
        public bool testRight(int i, int j, GameBoard board)
        {
            if (testInside(i, j, board))
            {
                if (j < board.Get_col() - 1 && board.Get_matrix(i, j + 1) == 0)
                    return true;
            }
            return false;
        }
        public bool testDown(int i, int j, GameBoard board)
        {

            if (testInside(i, j, board))
            {
                if (i < board.Get_row() - 1 && board.Get_matrix(i + 1, j) == 0)
                    return true;
            }
            return false;
        }

        //Di chuyển khối gạch sang trái
        public void Left(GameBoard board)
        {
            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.col; j++)
                    if (this.matrix[i, j] != 0)
                        if (!testLeft(i + this.pointY, j + this.pointX, board))
                            return;
            }
            this.pointX--;
        }
        //Di chuyển khối gạch sang phải
        public void Right(GameBoard board)
        {
            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.col; j++)
                    if (this.matrix[i, j] != 0)
                        if (!testRight(i + this.pointY, j + this.pointX, board))
                            return;
            }
            this.pointX++;
        }
        //Di chuyển khối gạch rơi xuống
        public bool Down(GameBoard board)
        {
            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.col; j++)
                    if (this.matrix[i, j] != 0)
                        if (!testDown(i + this.pointY, j + this.pointX, board))
                            return false;
            }
            pointY++;
            return true;
        }
        //Xoay khối gạch
        public void Rolate(GameBoard board)
        {
            int h = this.col;
            int c = this.row;
            byte[,] result = new byte[h, c];

            for (int i = this.row - 1; i >= 0; i--)
                for (int j = this.col - 1; j >= 0; j--)
                    result[j, this.row - 1 - i] = this.matrix[i, j];

            if (this.type == 7)
            {
                if (h == 4 && c == 1)
                    this.pointX++;
                else
                    this.pointX--;
            }

            //Kiem tra dieu kien
            while (this.pointX + c > board.Get_col())
                this.pointX--;
            while (this.pointX < 0)
                this.pointX++;

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (!testInside(i + this.pointY, j + this.pointX, board) || board.Get_matrix(i + this.pointY, j + pointX) != 0)
                        return;
                }
            }

            this.matrix = result;
            this.row = h;
            this.col = c;
        }
        
        //xây dựng khối gạch
        private void Build_1()
        {
            matrix[0, 0] = type; matrix[0, 1] = type; matrix[0, 2] = type;
            matrix[1, 0] = 0; matrix[1, 1] = type; matrix[1, 2] = 0;
            this.row = 2; this.col = 3;
        }
        private void Build_2()
        {
            matrix[0, 0] = 0; matrix[0, 1] = type; matrix[0, 2] = type;
            matrix[1, 0] = type; matrix[1, 1] = type; matrix[1, 2] = 0;
            this.row = 2; this.col = 3;
        }
        private void Build_3()
        {
            matrix[0, 0] = type; matrix[0, 1] = type; matrix[0, 2] = 0;
            matrix[1, 0] = 0; matrix[1, 1] = type; matrix[1, 2] = type;
            this.row = 2; this.col = 3;
        }
        private void Build_4()
        {
            matrix[0, 0] = type; matrix[0, 1] = 0; matrix[0, 2] = 0;
            matrix[1, 0] = type; matrix[1, 1] = type; matrix[1, 2] = type;
            this.row = 2; this.col = 3;
        }
        private void Build_5()
        {
            matrix[0, 0] = 0; matrix[0, 1] = 0; matrix[0, 2] = type;
            matrix[1, 0] = type; matrix[1, 1] = type; matrix[1, 2] = type;
            this.row = 2; this.col = 3;
        }
        private void Build_6()
        {
            matrix[0, 0] = type; matrix[0, 1] = type;
            matrix[1, 0] = type; matrix[1, 1] = type;
            this.row = 2; this.col = 2;
        }
        private void Build_7()
        {
            matrix[0, 0] = type; matrix[0, 1] = type; matrix[0, 2] = type; matrix[0, 3] = type;
            this.row = 1; this.col = 4;
        }

        public override void SaveMatrix(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Create);
            StreamWriter writer = new StreamWriter(stream, Encoding.ASCII);

            writer.Write(type); writer.WriteLine(","); // Ghi type
            writer.Write(this.pointX); writer.Write(","); // Ghi tọa độ X 
            writer.Write(this.pointY); writer.WriteLine(","); // Ghi tọa độ Y

            writer.Close();
            stream.Close();
            base.SaveMatrix(fileName);
        }
        public override bool LoadMatrix(FileStream stream, StreamReader reader)
        {
            string buf = "";
            // Đọc type
            ReadItem(reader, ref buf);
            this.type = byte.Parse(buf);
            
            // Đọc Tọa độ
            ReadItem(reader, ref buf);
            this.pointX = Int32.Parse(buf);
            ReadItem(reader, ref buf);
            this.pointY = Int32.Parse(buf);

            return base.LoadMatrix(stream, reader);
        }

    }
}
