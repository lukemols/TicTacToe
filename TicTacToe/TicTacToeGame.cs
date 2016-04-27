using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToeGame
    {
        IPlayer p1;
        IPlayer p2;

        Board board;

        bool viewMatch;
        int gamesToPlay;

        static int played = 0;
        static int[] matches = new int[3];

        const int DRAWINDEX = 0;
        const int CIRCLEINDEX = 1;
        const int CROSSINDEX = 2;


        public TicTacToeGame(IPlayer p1, IPlayer p2, int boardSize, int loop, bool viewMatch)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.viewMatch = viewMatch;
            gamesToPlay = loop;
            board = new Board(boardSize);
        }

        public void Play()
        {
            for (int index = 0; index < gamesToPlay; index++)
            {
                Board board = new Board();
                
                //Turno del player 1
                bool p1turn = true;
                int step = 1;

                do
                {
                    int x, y, p; //x e y sono le coordinate della griglia, p è il tipo del giocatore

                    if (p1turn)
                    {
                        p = Board.CIRCLE;
                        p1.Update(board, out x, out y); //Fai prendere la decisione al giocatore 1
                    }
                    else
                    {
                        p = Board.CROSS;
                        p2.Update(board, out x, out y);//Fai prendere la decisione al giocatore 2
                    }
                    if (board.Action(x, y, p)) //Se la mossa è valida
                    {
                        p1turn = !p1turn; //turno all'altro player
                        if (viewMatch)
                        {
                            Console.WriteLine("Partita numero " + index + ", step " + step);
                            DrawBoard(board); //disegna la board
                            Console.ReadLine(); //attendi input utente
                            step++;
                        }
                    }
                }
                while (board.ActualState == Board.GameState.INGAME);

                played++;
                ShowWinner(board, index);

                if (viewMatch)
                {
                    Console.WriteLine("Premi E per terminare il programma o un tasto qualunque per iniziare una nuova partita");
                    string userChoice = Console.ReadLine();
                    if (userChoice == "E")
                        return;
                }
            }
        }

        void DrawBoard(Board board)
        {
            int[,] gameBoard = board.mBoard;
            Console.WriteLine("-----------");
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    string s = " ";
                    if (gameBoard[i, j] == Board.CIRCLE)
                        s = "O";
                    else if (gameBoard[i, j] == Board.CROSS)
                        s = "X";

                    Console.Write("|" + s);
                }

                Console.WriteLine("|\n--------");
            }
        }

        void ShowWinner(Board board, int index)
        {
            if (board.ActualState == Board.GameState.DRAW)
            {
                Console.WriteLine("La partita " + index + " è terminata in pareggio!");
                matches[DRAWINDEX]++;
            }
            else if (board.ActualState == Board.GameState.CIRCLEWIN)
            {
                Console.WriteLine("La partita " + index + " è terminata con la vittoria dei cerchi!");
                matches[CIRCLEINDEX]++;
            }
            else if (board.ActualState == Board.GameState.CROSSWIN)
            {
                Console.WriteLine("La partita " + index + " è terminata con la vittoria delle croci!");
                matches[CROSSINDEX]++;
            }
        }

        public void ShowResults()
        {
            string str = "Sono state effettuate " + played + " partite. Ecco i risultati:" + Environment.NewLine +
                "Vittorie cerchi: " + matches[CIRCLEINDEX] + " (" + ((float)(matches[CIRCLEINDEX]) / played * 100) + "%)" + Environment.NewLine +
            "Vittorie croci: " + matches[CROSSINDEX] + " (" + ((float)(matches[CROSSINDEX]) / played * 100) + "%)" + Environment.NewLine +
            "Pareggi: " + matches[DRAWINDEX] + " (" + ((float)(matches[DRAWINDEX]) / played * 100) + "%)" + Environment.NewLine;
            Console.WriteLine(str);
            Console.WriteLine("Premi un tasto qualsiasi per uscire");
            Console.ReadLine();
        }

    }
}
