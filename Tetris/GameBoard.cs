using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Tetris
{
    class GameBoard:Matrix
    {
        //Thông số game board
        const int MAX_ROW = 24;
        const int MAX_COL = 10;

        //Constructor
        public GameBoard()
            : base(MAX_ROW, MAX_COL)
        {
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    this.matrix[i, j] = 0;
        }

        //Kiểm tra xem hàng r có ăn điểm không 
        public bool TestRowScore(int r)
        {
            if (r >= MAX_ROW)
                return false;

            for (int j = 0; j < this.col; j++)
                if (this.matrix[r, j] == 0)
                    return false;
            return true;
        }

        //Cập nhập Game Board khi ăn điểm
        public void RefreshGameBoard(int r)
        {
            for (int i = r; i > 0; i--)
                for (int j = 0; j < this.col; j++)
                    this.matrix[i, j] = this.matrix[i - 1, j];
        }

        //Gán khối gạch vào Game Board khi khối gạch rơi xuống
        public void AssignBlock(Block block)
        {
            for (int i = 0; i < block.Get_row(); i++)
            {
                for (int j = 0; j < block.Get_col(); j++)
                    if (block.Get_matrix(i, j) != 0)
                        this.matrix[block.Get_pointY() + i, block.Get_pointX() + j] = block.Get_matrix(i,j);
            }
        }

        public bool isGameOver()
        {
            for (int j = 0; j < this.col; j++)
                if (this.matrix[3, j] != 0)
                    return true;
            return false;
        }

        public override void SaveMatrix(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Create);
            StreamWriter writer = new StreamWriter(stream, Encoding.ASCII);

            if (this.isGameOver())
                writer.WriteLine("0,");
            else writer.WriteLine("1,");

            writer.Close();
            stream.Close();

            base.SaveMatrix(fileName);
        }
        public override bool LoadMatrix(FileStream stream, StreamReader reader)
        {            
            byte k; string buf = "";
            ReadItem(reader,ref buf); k = byte.Parse(buf);

            if (k == 0)
            {
                stream.Close();
                reader.Close();
                return false;
            }

            return base.LoadMatrix(stream, reader);
        }
    }
}
