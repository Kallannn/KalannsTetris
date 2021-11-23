using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace KalannsTetris.Tetris
{
    public class TetrisGravity
    {
        private int timeProgression = 0;
        private Stopwatch timer = null;
        private long NextPull = 0;
        private bool breakTime = false;
        public TetrisGravity()
        {
            timer = new Stopwatch();
            timeProgression = 0;
            ScheduleNextPull();
        }
        public void PullOnTime()
        {
            StartTimerIfOff();

            if (timer.ElapsedMilliseconds >= NextPull)
            {
                if (breakTime)
                {
                    timer.Stop();
                    Thread.Sleep(500);
                    timer.Start();
                }
                PullStuffDown();
                ScheduleNextPull();
            }
        }
        private void StartTimerIfOff()
        {
            if (!timer.IsRunning)
            {
                timer.Start();
                ScheduleNextPull();
            }
        }
        private void ScheduleNextPull()
        {
            NextPull = timer.ElapsedMilliseconds + (2000 - (10 * timeProgression));
            //timeProgression++;
        }
        private void PullStuffDown()
        {
            int[,] field = new int[20, 10];
            field = TetrisField.field;

            //de baixo para cima, cada linha recebe o valor da linha superior
            for (int x = TetrisConstants.fieldHeight - 2; x > 0; x--)
            {
                for (int y = TetrisConstants.fieldWidth - 1; y >= 0; y--)
                {
                    field[x, y] = field[x - 1, y];
                }
            }
            //ultima linha recebe zeros
            for (int y = 9; y >= 0; y--)
            {
                field[TetrisConstants.fieldHeight - 1, y] = 0;
            }
            TetrisField.SetField(field);
        }
    }
}
