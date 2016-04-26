using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            int nGames = 1000;
            for (int index = 0; index < nGames; index++)
            {
                Board board = new Board();

                IPlayer p1 = new RandomPlayer();
                IPlayer p2 = new RandomPlayer();

                bool p1turn = true;

                do
                {
                    int x, y, p;
                    if (p1turn)
                    {
                        p = Board.CIRCLE;
                        p1.Update(board, out x, out y);
                    }
                    else
                    {
                        p = Board.CROSS;
                        p2.Update(board, out x, out y);
                    }
                    if (board.Action(x, y, p))
                    {
                        p1turn = !p1turn;
                        DrawBoard(board);
                    }
                }
                while (board.ActualState != Board.GameState.INGAME);

            }
        }

        static void DrawBoard(Board board)
        {
            //Console writeline..... blablabla

        }
    }
}
