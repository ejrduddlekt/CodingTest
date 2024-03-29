﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Test4
{
    /*
	 * [클래스 설계 역량 평가]
	 * 
	 * 테트리스 줄 없애기
	 *  - 테트리스에서처럼 완성된 줄을 없애는 기능을 구현하면 됩니다.
	 *  - 없어진 줄 윗 부분의 블록들은 한줄씩 내려와야 합니다.
	 *  - 완성된 줄이 여러 개라면 모두 처리되어야 합니다.
	 *  - TetrisState 클래스를 구현하세요.
	 */
    class Program
    {
        //static void Main(string[] args)
        //{
        //    TetrisState tetris = CreateTestTetris();

        //    PrintTetris(tetris);

        //    tetris.CheckCompleteLine();

        //    PrintTetris(tetris);
        //}

        #region Stub
        static void PrintTetris(TetrisState tetris)
        {
            for (int y = TetrisState.TETRIS_SIZE_Y - 1; y >= 0; y--)
            {
                Console.Write("|");

                for (int x = 0; x < TetrisState.TETRIS_SIZE_X; x++)
                {
                    if (tetris.Get(x, y))
                    {
                        Console.Write("M");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine("|");
            }

            Console.WriteLine(new String('-', TetrisState.TETRIS_SIZE_X + 2));
            Console.WriteLine();
            Console.WriteLine();
        }

        static TetrisState CreateTestTetris()
        {
            TetrisState tetris = new TetrisState();
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                int x = r.Next(0, TetrisState.TETRIS_SIZE_X);
                int y = r.Next(0, TetrisState.TETRIS_SIZE_Y);

                tetris.Set(x, y);
            }

            for (int i = 0; i < 5; i++)
            {
                int y = r.Next(0, TetrisState.TETRIS_SIZE_Y);

                for (int x = 0; x < TetrisState.TETRIS_SIZE_X; x++)
                {
                    tetris.Set(x, y);
                }
            }

            return tetris;
        }
        #endregion
    }

    class TetrisState
    {
        public const int TETRIS_SIZE_X = 10;        // 테트리스 폭
        public const int TETRIS_SIZE_Y = 20;        // 테트리스 높이. Y값이 작을수록 낮은 곳. 가장 높은 위치는 Y=19입니다.

        public bool[,] tetrisBlock = new bool[20, 10];

        public bool Get(int x, int y)
        {
            // X, Y 위치에 블록이 있으면 true 리턴
            if (tetrisBlock[y, x])
                return true;
            else
                return false;
        }

        public void Set(int x, int y)
        {
            // X, Y 위치에 블록을 배치
            tetrisBlock[y, x] = true;
        }

        public void CheckCompleteLine()
        {
            bool[,] bools = new bool[20, 10];
            // 완성된 줄을 없애고 윗 부분의 블록들을 한줄씩 없애는 기능을 구현
            for (int y = 0; y < TetrisState.TETRIS_SIZE_Y; y++)
                checkLineX(y);
        }

        public void checkLineX(int CheckLineY)
        {
            bool checkLine = true;

            for (int x = 0; x < TetrisState.TETRIS_SIZE_X; x++)
                checkLine = checkLine && tetrisBlock[CheckLineY, x];
            
            if (checkLine)
                removeLine(CheckLineY);
        }

        public void removeLine(int removeLineY)
        {
            for(int y = removeLineY; y < TETRIS_SIZE_Y - 1; y++)
            {
                for(int x = 0; x < TETRIS_SIZE_X; x++)
                    tetrisBlock[y, x] = tetrisBlock[y + 1, x];
            }

            for (int x = 0; x < TETRIS_SIZE_X; x++)
                tetrisBlock[TETRIS_SIZE_Y-1, x] = false;

            checkLineX(removeLineY);
        }
    }
}

#region for문 횟수를 줄일 시
/* 
 public void CheckCompleteLine()
        {
            bool[,] bools = new bool[20,10];
            int checkCount = 0;
            // 완성된 줄을 없애고 윗 부분의 블록들을 한줄씩 없애는 기능을 구현
            for (int y = 0; y < TetrisState.TETRIS_SIZE_Y; y++)
            {
                bool checkLine = true;
                bool[] xLine = new bool[10];
                for (int x = 0; x < TetrisState.TETRIS_SIZE_X; x++)
                {
                    xLine[x] = tetrisBlock[y, x];
                    checkLine = checkLine && tetrisBlock[y, x];
                }

                if (checkLine)
                    checkCount++;
                else
                {
                    for(int x = 0; x < TetrisState.TETRIS_SIZE_X; x++)
                    {
                        bools[y - checkCount, x] = xLine[x];
                    }
                }
            }
            tetrisBlock = bools;
        }
 */
#endregion