using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class SearchWinPlayer : IPlayer
    {
        Random rnd;
        int counter;

        int[] rows;
        int[] columns;
        int d1;
        int d2;

        public SearchWinPlayer()
        {
            int seed = (int)DateTime.Now.Millisecond * GetHashCode();
            rnd = new Random(seed);

            counter = 0;
        }

        public void Update(Board board, out int x, out int y)
        {
            x = -1;
            y = -1;

            //se è il primo lancio, disegno nell'angolo
            if (counter == 0)
            {
                if (board.mBoard[0, 0] == 0)
                {
                    x = 0;
                    y = 0;
                    counter++;
                    return;
                }
                else if (board.mBoard[1, 1] == 0)
                {
                    x = 1;
                    y = 1;
                    counter++;
                    return;
                }
            }
            else if (SearchWon(board) == 0)
            {
                //sfrutto le opportunità di vittoria

                //opero sulle righe
                for (int i = 0; i < board.mBoard.GetLength(0); i++)
                {
                    //se c'è possibilità di vittoria
                    if (rows[i] == -1)
                    {
                        for (int j = 0; j < board.mBoard.GetLength(1); j++)
                        {
                            //vinco
                            if (board.mBoard[i, j] == 0)
                            {
                                x = i;
                                y = j;
                                return;
                            }
                        }
                    }
                }

                //opero sulle colonne
                for (int i = 0; i < board.mBoard.GetLength(0); i++)
                {
                    //se c'è possibilità di vittoria
                    if (columns[i] == -1)
                    {
                        for (int j = 0; j < board.mBoard.GetLength(1); j++)
                        {
                            //vinco
                            if (board.mBoard[j, i] == 0)
                            {
                                x = j;
                                y = i;
                                return;
                            }
                        }
                    }
                }

                //opero sulle diagonali

                //
                if (d1 == -1)
                {
                    for (int i = 0; i < board.mBoard.GetLength(1); i++)
                    {
                        if (board.mBoard[i, i] == 0)
                        {
                            x = i;
                            y = i;
                            return;
                        }
                    }
                }

                //
                if (d2 == -1)
                {
                    for (int i = 0; i < board.mBoard.GetLength(1); i++)
                    {
                        if (board.mBoard[i, board.mBoard.GetLength(1) - (i + 1)] == 0)
                        {
                            x = i;
                            y = board.mBoard.GetLength(1) - (i + 1);
                            return;
                        }
                    }
                }

                //cerco di non perdere

                //opero sulle righe
                for (int i = 0; i < board.mBoard.GetLength(0); i++)
                {
                    //se c'è possibilità di impedire la vittoria all'aversario
                    if (rows[i] == 1)
                    {
                        for (int j = 0; j < board.mBoard.GetLength(1); j++)
                        {
                            //provo a salvarmi
                            if (board.mBoard[i, j] == 0)
                            {
                                x = i;
                                y = j;
                                return;
                            }
                        }
                    }
                }

                //opero sulle colonne
                for (int i = 0; i < board.mBoard.GetLength(0); i++)
                {
                    //se c'è possibilità di impedire la vittoria all'aversario
                    if (columns[i] == 1)
                    {
                        for (int j = 0; j < board.mBoard.GetLength(1); j++)
                        {
                            //provo a salvarmi
                            if (board.mBoard[j, i] == 0)
                            {
                                x = j;
                                y = i;
                                return;
                            }
                        }
                    }
                }

                //opero sulle diagonali

                //
                if (d1 == 1)
                {
                    for (int i = 0; i < board.mBoard.GetLength(1); i++)
                    {
                        if (board.mBoard[i, i] == 0)
                        {
                            x = i;
                            y = i;
                            return;
                        }
                    }
                }

                //
                if (d2 == 1)
                {
                    for (int i = 0; i < board.mBoard.GetLength(1); i++)
                    {
                        if (board.mBoard[i, board.mBoard.GetLength(1) - (i + 1)] == 0)
                        {
                            x = i;
                            y = board.mBoard.GetLength(1) - (i + 1);
                            return;
                        }
                    }
                }
            }

            int temp = rnd.Next(0, board.mBoard.GetLength(0));

            //cerco di dare priorità agli angoli
            //if (board.mBoard[board.mBoard.GetLength(0) - 1, board.mBoard.GetLength(0) - 1] == 0 && temp == 0)
            //{
            //    x = board.mBoard.GetLength(0) - 1;
            //    y = board.mBoard.GetLength(0) - 1;
            //    return;
            //}
            //if (board.mBoard[0, board.mBoard.GetLength(0) - 1] == 0 && temp == 1)
            //{
            //    x = 0;
            //    y = board.mBoard.GetLength(0) - 1;
            //    return;
            //}
            //if (board.mBoard[board.mBoard.GetLength(0) - 1, 0] == 0 && temp == 2)
            //{
            //    x = board.mBoard.GetLength(0) - 1;
            //    y = 0;
            //    return;
            //}

            //versione fallata
            if (board.mBoard[board.mBoard.GetLength(0) - 1, board.mBoard.GetLength(0) - 1] == 0)
            {
                x = board.mBoard.GetLength(0) - 1;
                y = board.mBoard.GetLength(0) - 1;
                return;
            }
            if (board.mBoard[0, board.mBoard.GetLength(0) - 1] == 0)
            {
                x = 0;
                y = board.mBoard.GetLength(0) - 1;
                return;
            }
            if (board.mBoard[board.mBoard.GetLength(0) - 1, 0] == 0)
            {
                x = board.mBoard.GetLength(0) - 1;
                y = 0;
                return;
            }


            if (x < 0 || y < 0)
            {
                x = rnd.Next(0, board.mBoard.GetLength(0));
                y = rnd.Next(0, board.mBoard.GetLength(1));
            }
        }

        int SearchWon(Board board)
        {
            /*int[] *//*rows = new int[board.mBoard.GetLength(0)];*/

            //inizializzo per un primo giro
            if (rows == null)
                rows = new int[board.mBoard.GetLength(0)];
            if (columns == null)
                columns = new int[board.mBoard.GetLength(1)];

            //pulisco le matrici
            for (int i = 0; i < 3; i++)
            {
                rows[i] = 0;
                columns[i] = 0;
            }
            //if (d1 == null)
            //    d1 = 0;
            //if (d2 == null)
            //    d2 = 0;


            //Controlliamo le righe
            for (int i = 0; i < board.mBoard.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < board.mBoard.GetLength(1); j++)
                {
                    sum += board.mBoard[i, j];
                }

                //se la somma è 2 significa che ho 2 dei miei segni e un posto vuoto
                if (sum == 2)
                    rows[i] = 1;
                //se la somma è -2 significa che ho 2 dei segni avversari e un posto vuoto 
                else if (sum == -2)
                    rows[i] = -1;
                else
                    rows[i] = 0;
            }


            //controlliamo le colonne
            for (int j = 0; j < board.mBoard.GetLength(0); j++)
            {
                int sum = 0;
                for (int i = 0; i < board.mBoard.GetLength(1); i++)
                {
                    sum += board.mBoard[i, j];
                }

                //se la somma è 2 significa che ho 2 dei miei segni e un posto vuoto
                if (sum == 2)
                    columns[j] = 1;
                //se la somma è -2 significa che ho 2 dei segni avversari e un posto vuoto 
                else if (sum == -2)
                    columns[j] = -1;
                else
                    columns[j] = 0;
            }

            //controlliamo le diagonali
            d1 = 0;
            d2 = 0;

            int sumd1 = 0;
            int sumd2 = 0;
            for (int i = 0; i < board.mBoard.GetLength(0); i++)
            {
                sumd1 += board.mBoard[i, i];
                sumd2 += board.mBoard[i, board.mBoard.GetLength(0) - (i + 1)];
            }

            if (sumd1 == 2)
                d1 = 1;
            if (sumd1 == -2)
                d1 = -1;
            if (sumd2 == 2)
                d2 = 1;
            if (sumd2 == -2)
                d2 = -1;

            return 0;
        }
    }
}
