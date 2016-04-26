using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class RandomPlayer : IPlayer
    {
        Random rnd;

        public RandomPlayer()
        {
            int seed = (int)DateTime.Now.Millisecond * GetHashCode();
            rnd = new Random(seed);
        }

        public void Update(Board board, out int x, out int y)
        {
            x = rnd.Next(0, board.mBoard.GetLength(0));
            y = rnd.Next(0, board.mBoard.GetLength(1));
        }
    }
}
