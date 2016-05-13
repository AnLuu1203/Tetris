using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris
{
    class TypeBlock
    {
        //Class tạo ra random số từ 1-->7

        private byte type;
        private int row;
        private int col;

        //Constructor
        public TypeBlock()
        {
            //Random key từ 1-->7
            Random random = new Random();
            type = (byte)random.Next(1, 8);
            CreateBlock(this.type);
        }

        public TypeBlock(byte type)
        {
            this.type = type;
            CreateBlock(type);
        }


        public byte GetType()
        {
            return type;
        }
        public int GetRow()
        {
            return row;
        }
        public int GetCol()
        {
            return col;
        }
        private void CreateBlock(int type)
        {
            switch (type)
            {
                case 1:
                    this.row = 2;
                    this.col = 3;
                    break;
                case 2:
                    this.row = 2;
                    this.col = 3;
                    break;
                case 3:
                    this.row = 2;
                    this.col = 3;
                    break;
                case 4:
                    this.row = 2;
                    this.col = 3;
                    break;
                case 5:
                    this.row = 2;
                    this.col = 3;
                    break;
                case 6:
                    this.row = 2;
                    this.col = 2;
                    break;
                case 7:
                    this.row = 1;
                    this.col = 4;
                    break;
            }
        }
    }
}
