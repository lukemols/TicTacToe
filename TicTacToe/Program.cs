using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        const int RANDOMPLAYERINDEX = 1;
        const int BORDERRATIONALPLAYERINDEX = 2;
        const int nGames = 200000;

        static int p1id = BORDERRATIONALPLAYERINDEX;
        static int p2id = RANDOMPLAYERINDEX;

        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto in Tic Tac Toe.\n" +
                "Premi 1 se vuoi vedere la partita, 2 se vuoi lanciare random e vedere i risultati finali\n" +
                "altrimenti un tasto qualsiasi per uscire.");

            string s = Console.ReadLine();
            bool viewMatch = true;
            if (s == "1")
                viewMatch = true;
            else if (s == "2")
                viewMatch = false;
            else
                return;


            IPlayer p1, p2;
            ConfigPlayers(out p1, out p2);
            TicTacToeGame tttGame = new TicTacToeGame(p1, p2, 3, nGames, viewMatch);
            tttGame.Play();
            tttGame.ShowResults();
        }

        static void ConfigPlayers(out IPlayer p1, out IPlayer p2)
        {
            switch(p1id)
            {
                case BORDERRATIONALPLAYERINDEX:
                    p1 = new BorderRationalPlayer(1, Board.CIRCLE);
                    break;
                case RANDOMPLAYERINDEX:
                default:
                    p1 = new RandomPlayer();
                    break;
            }
            switch (p2id)
            {
                case BORDERRATIONALPLAYERINDEX:
                    p2 = new BorderRationalPlayer(2, Board.CROSS);
                    break;
                case RANDOMPLAYERINDEX:
                default:
                    p2 = new RandomPlayer();
                    break;
            }
        }
    }
}
