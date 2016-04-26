using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class RandomPlayer : IPlayer
    {
        public void Update(Board board, out int x, out int y)
        {
            x = 0;
            y = 0;
        }
    }
}
