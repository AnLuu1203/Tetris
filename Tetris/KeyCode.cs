using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris
{
    class KeyCode
    {
        //Class tạo ra random số từ 1-->7

        private int key;
        private int hang;
        private int cot;

        //Constructor
        public KeyCode()
        {
            //Random key từ 1-->7
            Random random = new Random();
            key = random.Next(1, 8);
            switch (key)
            {
                case 1:
                    this.hang = 2;
                    this.cot = 3;
                    break;
                case 2:
                    this.hang = 2;
                    this.cot = 3;
                    break;
                case 3:
                    this.hang = 2;
                    this.cot = 3;
                    break;
                case 4:
                    this.hang = 2;
                    this.cot = 3;
                    break;
                case 5:
                    this.hang = 2;
                    this.cot = 3;
                    break;
                case 6:
                    this.hang = 2;
                    this.cot = 2;
                    break;
                case 7:
                    this.hang = 1;
                    this.cot = 4;
                    break;
            }
        }

        public int GetKey()
        {
            return key;
        }
        public int Gethang()
        {
            return hang;
        }
        public int Getcot()
        {
            return cot;
        }

    }
}
