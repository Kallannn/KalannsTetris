using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace KalannsTetris.Tetris
{
    static public class TetrisManager
    {
        static public void Start()
        {
            TesteGravidade();
        }
        static private void TestePintor()
        {
            int[,] str = new int[20, 10];
            str[10, 5] = 1;
            str[11, 5] = 1;
            str[11, 4] = 1;
            str[11, 6] = 1;

            //for (int x = 0; x <= 19; x++)
            //{
            //    for (int y = 0; y <= 9; y++)
            //    {
            //        str[x, y] = 1;
            //    }
            //}

            ScreenRender pintor = new ScreenRender();
            pintor.ScreenRender_ExecuteWholeProcess(str);
        }
        static private void TesteGravidade()
        {
            ScreenRender pintor = new ScreenRender();
            int[,] str = new int[20, 10];
            str[10, 5] = 1;
            str[11, 5] = 1;
            str[11, 4] = 1;
            str[11, 6] = 1;
            TetrisField.SetField(str);

            TetrisGravity grav = new TetrisGravity();
            while (true)
            {
                grav.PullOnTime();
                pintor.ScreenRender_ExecuteWholeProcess(TetrisField.field);
                Thread.Sleep(10);
            }
            
        }
    }
}
