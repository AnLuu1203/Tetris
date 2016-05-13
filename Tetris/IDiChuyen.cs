using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris
{
    interface IDiChuyen
    {
        void SangTrai(GameBoard board); //Di chuyển sang trái
        void SangPhai(GameBoard board); //Di chuyển sang phải
        void Xoay(GameBoard board); // Xoay 90 độ bên phải
        bool RoiXuong(GameBoard board); //Rơi xuống 
    }
}
