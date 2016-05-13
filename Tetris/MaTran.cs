using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris
{
    abstract class MaTran:IMaTran
    {
        protected int[,] matran; //ma trận
        protected int hang; //số hàng
        protected int cot; // số cột
       
        //Contructor
        public MaTran(int hang, int cot)
        {
            this.hang = hang;
            this.cot = cot;
            matran = new int[hang, cot];

            for (int i = 0; i < hang; i++)
                for (int j = 0; j < cot; j++)
                    matran[i, j] = 0;
        }
       

        //Trả về số hang của ma trận
        public int Get_hang()
        {
            return hang;
        }
        //Trả về số cột của ma trận
        public int Get_cot()
        {
            return cot;
        }
        //Trả về giá trị của matran[i,j]
        public int GetMT(int i, int j)
        {
            return matran[i, j];
        }
    }
}
