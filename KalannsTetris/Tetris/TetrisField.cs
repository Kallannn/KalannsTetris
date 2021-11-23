using System;
using System.Collections.Generic;
using System.Text;

namespace KalannsTetris.Tetris
{
    static public class TetrisField
    {
        static public int[,] field { get; set; }
        static public void NewField()
        {
            field = new int[20, 10];
        }
        static public void SetField(int[,] data)
        {
            field = data;
        }
    }
}
