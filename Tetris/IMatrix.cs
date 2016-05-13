using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris
{
    interface IMatrix
    {
        int Get_row(); // Trả về số hàng của ma trận
        int Get_col(); // Trả về số cột của ma trận
        byte Get_matrix(int i, int j); // Trả về giá trị của matran[i,j]
    }
}
