using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Tetris
{
    class Score
    {
        private uint score;
        private byte level;
        private uint time;
        private byte combo;

        public Score()
        {
            score = 0;
            level = 1;
            combo = 1;
            time = 400;
        }

        public void Set_Combo(byte x)
        {
            combo = x;
        }
        public void IncreaseScore()
        {
            score += 5 * (uint)(combo - 1) + 10*(uint)combo + ((uint)level - 1)*5 ;
            IncreaseLevel();
        }
        public void IncreaseLevel()
        {
            if (score >= 980)
            {
                level = 8;
                time = 50;
                return;
            }
            if (score >= 780)
            {
                level = 7;
                time = 100;
                return;
            }

            if (score >= 600)
            {
                level = 6;
                time = 150;
                return;
            }
            if (score >= 440)
            {
                level = 5;
                time = 200;
                return;
            }
            if (score >= 300)
            {
                level = 4;
                time = 250;
                return;
            }
            if (score >= 180)
            {
                level = 3;
                time = 300;
                return;
            }
            if (score >= 80)
            {
                level = 2;
                time = 350;
                return;
            }
        }

        public uint Get_Score()
        {
            return score;
        }
        public byte Get_Level()
        {
            return level;
        }
        public uint Get_Time()
        {
            return time;
        }

        public void SaveScore(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Create);
            StreamWriter writer = new StreamWriter(stream, Encoding.ASCII);

            writer.Write(this.score); writer.WriteLine(",");

            writer.Close();
            stream.Close();
        }
        public void LoadScore(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Open);
            StreamReader reader = new StreamReader(stream, Encoding.ASCII);

            string buf = "";
            Matrix.ReadItem(reader, ref buf);

            score = UInt32.Parse(buf);
            IncreaseLevel();

            reader.Close();
            stream.Close();

        }

    }
}
