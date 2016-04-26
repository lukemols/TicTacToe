using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    interface IPlayer
    {
        void Update(Board board, out int x, out int y);
    }
}
