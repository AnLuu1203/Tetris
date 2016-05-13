using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris
{
    interface IMove
    {
        void Left(GameBoard board); //Di chuyển sang trái
        void Right(GameBoard board); //Di chuyển sang phải
        void Rolate(GameBoard board); // Xoay 90 độ bên phải
        bool Down(GameBoard board); //Rơi xuống 
    }
}
