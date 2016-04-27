using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class BorderRationalPlayer : IPlayer
    {
        Random rnd;
        int playerIndex;
        int playerSymbol;

        public BorderRationalPlayer(int index, int symbol)
        {
            int seed = (int)DateTime.Now.Millisecond * GetHashCode();
            rnd = new Random(seed);

            playerIndex = index;
            playerSymbol = symbol;
        }

        public void Update(Board board, out int x, out int y)
        {
            x = 0;
            y = 0;
            int otherPlayerSymbol = (playerSymbol == Board.CROSS) ? (Board.CIRCLE) : (Board.CROSS);

            if (playerIndex == 1 && board.BoardIsEmpty())
            {
                //Parti da un angolo a caso
                x = rnd.Next(2); y = rnd.Next(2);
                if (x == 1)
                    x = board.WIDTH - 1;
                if (y == 1)
                    y = board.HEIGHT - 1;
            }
            else if(CanDoTris(board, playerSymbol, out x, out y))
            {
            }
            else if(CanDoTris(board, otherPlayerSymbol, out x, out y))
            {
            }
            else
            {
                x = rnd.Next(board.WIDTH);
                y = rnd.Next(board.HEIGHT);
            }
        }

        bool CanDoTris(Board board, int symbol, out int x, out int y)
        {
            int[,] mboard = board.mBoard;
            int score = (symbol == Board.CROSS) ? (board.CROSSSCORE - 1) : (board.CIRCLESCORE + 1); 
            //quello sopra è un IF ELSE: Se Symbol è uguale a cross prendi cross score, altrimenti circlescore
            //Così si utilizza una funzione per capire se uno dei due giocatori può fare tris
            for (int i = 0; i < board.WIDTH; i++)
            {
                int sum = 0;
                int xk = 0, yk = 0;
                for (int j = 0; j < board.HEIGHT; j++)
                {
                    sum += mboard[i, j];
                    if(mboard[i, j] == Board.EMPTY)
                    {
                        xk = i; yk = j;
                    }
                }
                if (sum == score)
                {
                    x = xk; y = yk; return true;
                }
            }

            for (int j = 0; j < board.HEIGHT; j++)
            {
                int sum = 0;
                int xk = 0, yk = 0;
                for (int i = 0; i < board.WIDTH; i++)
                {
                    sum += mboard[i, j];
                    if (mboard[i, j] == Board.EMPTY)
                    {
                        xk = i; yk = j;
                    }
                }
                if (sum == score)
                {
                    x = xk; y = yk; return true;
                }
            }

            int sumd1 = 0;
            int sumd2 = 0;
            int xk1 = 0, xk2 = 0, yk1 = 0, yk2 = 0;
            for (int i = 0; i < board.WIDTH; i++)
            {
                sumd1 += mboard[i, i];
                sumd2 += mboard[i, board.WIDTH - (i + 1)];
                if (mboard[i, i] == Board.EMPTY)
                {
                    xk1 = i; yk1 = i;
                }
                if (mboard[i, board.WIDTH - (i + 1)] == Board.EMPTY)
                {
                    xk2 = i; yk2 = board.WIDTH - (i + 1);
                }
            }
            if (sumd1 == score)
            {
                x = xk1; y = yk1; return true;
            }
            if (sumd2 == score)
            {
                x = xk2; y = yk2; return true;
            }
            x = 0; y = 0;
            return false;
        }
        
    }
}
