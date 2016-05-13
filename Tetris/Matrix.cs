using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Tetris
{
    abstract class Matrix:IMatrix
    {
        protected byte[,] matrix; //ma trận
        protected int row; //số hàng
        protected int col; // số cột
        //Contructor
        public Matrix(int r, int c)
        {
            this.row = r;
            this.col = c;
            matrix = new byte[r, c];

            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                    matrix[i, j] = 0;
        }
        public Matrix(int r, int c, byte[,] A)
        {
            this.row = r;
            this.col = c;
            matrix = A;
        }
       

        //Trả về số hang của ma trận
        public int Get_row()
        {
            return row;
        }
        //Trả về số cột của ma trận
        public int Get_col()
        {
            return col;
        }
        //Trả về giá trị của matran[i,j]
        public byte Get_matrix(int i, int j)
        {
            return matrix[i, j];
        }
        //Save Matrix
        public virtual void SaveMatrix(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Append);
            StreamWriter writer = new StreamWriter(stream,Encoding.ASCII);

            writer.Write(this.row); writer.Write(",");
            writer.Write(this.col); writer.WriteLine();

            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.col; j++)
                {
                    writer.Write(matrix[i, j]);
                    writer.Write(",");
                }
                writer.WriteLine();
            }
            writer.Close();
            stream.Close();
        }
        static public void ReadItem(StreamReader reader, ref String buf)
        {
            char ch = '\0';
            //thiết lập chuỗi nhập ₫ược lúc ₫ầu là rỗng
            buf = "";
            while (reader.EndOfStream != true)
            {//lặp ₫ọc bỏ các dấu ngăn
                ch = (char)reader.Read(); //₫ọc 1 ký tự
                if (ch != ',' && ch != '\r' && ch != '\n')
                    break; //nếu là ký tự bình thường thì dừng
            }
            buf += ch.ToString();
            //lặp ₫ọc các ký tự của chuỗi dữ liệu
            while (reader.EndOfStream != true)
            {
                ch = (char)reader.Read(); //₫ọc 1 ký tự
                if (ch == ',' || ch == '\r' || ch == '\n')
                    return; //nếu là dấu ngăn thì dừng
                buf += ch.ToString(); //chứa ký tự vào bộ ₫ệm
            }
        }
        public virtual bool LoadMatrix(FileStream stream, StreamReader reader)
        {
            string buf = "";

            ReadItem(reader, ref buf); row = Int32.Parse(buf); //þ.c s. hàng
            ReadItem(reader, ref buf); col = Int32.Parse(buf); //þ.c s. c.t

            matrix = new byte[row, col];
            //þ.c t.ng ph.n t. ma tr.n
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                {
                    ReadItem(reader, ref buf);
                    matrix[i, j] = byte.Parse(buf); //þ.c s. th.c
                }
            //5. þóng các þ.i tý.ng þý.c dùng l.i
            reader.Close(); stream.Close();
            return true;
        }
    }
}
