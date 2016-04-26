using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Board
    {
        public int WIDTH { get { return 3; } }
        public int HEIGHT { get { return 3; } }

        public const int CROSS = 1;
        public const int CIRCLE = -1;
        public const int EMPTY = 0;

        int[,] mboard;
        public int[,] mBoard { get { return mboard; } }

        public enum GameState { CIRCLEWIN, CROSSWIN, DRAW, INGAME}

        GameState actualState;
        public GameState ActualState { get { return actualState; } }

        public Board()
        {
            mboard = new int[WIDTH, HEIGHT];
            for (int i = 0; i < WIDTH; i++)
                for (int j = 0; j < HEIGHT; j++)
                    mboard[i, j] = EMPTY;
            actualState = GameState.INGAME;
        }

        public bool Action(int x, int y, int player)
        {
            if (actualState != GameState.INGAME)
                return false;
            if (mboard[x, y] != EMPTY)
                return false;
            if (player != CROSS && player != CIRCLE)
                return false;
            mboard[x, y] = player;
            CheckState();
            return true;
        }

        public void CheckState()
        {
            switch(GameWon())
            {
                case CIRCLE:
                    actualState = GameState.CIRCLEWIN;
                    break;
                case CROSS:
                    actualState = GameState.CROSSWIN;
                    break;
                case EMPTY:
                default:
                    break;
            }
            if (actualState == GameState.INGAME)
            {
                if (BoardIsFull())
                    actualState = GameState.DRAW;
            }
        }

        bool BoardIsFull()
        {
            for (int i = 0; i < WIDTH; i++)
                for (int j = 0; j < HEIGHT; j++)
                {
                    if(mboard[i,j] == EMPTY)
                    {
                        return false;
                    }
                }
            return true;
        }

        int GameWon()
        {
            //Controlliamo le righe
            for (int i = 0; i < WIDTH; i++)
            {
                int sum = 0;
                for (int j = 0; j < HEIGHT; j++)
                {
                    sum += mboard[i, j];
                }
                if (sum == 3)
                    return CROSS;
                if (sum == -3)
                    return CIRCLE;
            }

            for (int j = 0; j < WIDTH; j++)
            {
                int sum = 0;
                for (int i = 0; i < HEIGHT; i++)
                {
                    sum += mboard[i, j];
                }
                if (sum == 3)
                    return CROSS;
                if (sum == -3)
                    return CIRCLE;
            }

            int sumd1 = 0;
            int sumd2 = 0;
            for (int i = 0; i < WIDTH; i++)
            {
                sumd1 += mboard[i, i];
                sumd2 += mboard[i, WIDTH - (i + 1)];
            }
            if (sumd1 == 3 || sumd2 == 3)
                return CROSS;
            if (sumd1 == -3 || sumd2 == -3)
                return CIRCLE;

            return EMPTY;
        }
    }
}
