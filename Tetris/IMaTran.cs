using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris
{
    interface IMaTran
    {
        int Get_hang(); // Trả về số hàng của ma trận
        int Get_cot(); // Trả về số cột của ma trận
        int GetMT(int i, int j); // Trả về giá trị của matran[i,j]
    }
}
