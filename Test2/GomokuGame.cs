using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    using System;

    class GomokuGame
    {
        private int[,] board;
        private int size;
        private int currentPlayer;

        public GomokuGame(int size, int[,] initialBoard, int playerTurn)
        {
            this.size = size;
            board = new int[size, size];
            currentPlayer = playerTurn;
            InitializeBoard(initialBoard);
        }

        private void InitializeBoard(int[,] initialBoard)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    board[row, col] = initialBoard[row, col];
                }
            }
        }
        public string CheckNextMove()
        {
            List<string> suitablePlaces = new List<string>();
            List<string> suitablePlacesOppo = new List<string>();

            // Check for available moves
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (board[row, col] == -1)
                    {
                        // Simulate the current player's move
                        board[row, col] = currentPlayer;

                        // Check if the current player wins after this move
                        if (CheckWin(row, col, 0))
                        {
                            board[row, col] = -1; // Revert the change
                            return " You(" + currentPlayer + ") WIN at " + (row + 1).ToString() + "," + (col + 1).ToString();
                        }
                        //else
                        //    board[row, col] = -1;
                        // Check if the opponent wins after this move

                        //int nextPlayer = (currentPlayer == 0) ? 1 : 0;
                        //bool opponentWins = false;
                        //for (int r = 0; r < size; r++)
                        //{
                        //    for (int c = 0; c < size; c++)
                        //    {
                        //        if (board[r, c] == -1)
                        //        {
                                 
                        //            board[r, c] = nextPlayer;
                        //            if (CheckWin(r, c,0))
                        //            {
                        //                opponentWins = true;
                        //                suitablePlacesOppo.Add((row + 1).ToString() + "," + (col + 1).ToString());
                        //              //  return " You Lose";
                        //                break;
                        //            }
                        //            board[r, c] = -1; // Revert the change
                        //        }
                        //    }
                        //    if (opponentWins)
                        //        break;
                        //}

                        //// If the opponent doesn't win, this move is suitable
                        //if (!opponentWins)
                            suitablePlaces.Add((row + 1).ToString() + "," + (col + 1).ToString());

                        // Revert the move
                        board[row, col] = -1;
                    }
                }
            }
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (board[row, col] == -1)
                    { 
                        int nextPlayer = (currentPlayer == 0) ? 1 : 0;
                        board[row, col] = nextPlayer; 
                        if (CheckWin(row, col, 0))
                        {
                            suitablePlacesOppo.Add((row + 1).ToString() + "," + (col + 1).ToString());
                            board[row, col] = -1; // Revert the change
                            //return " You(" + currentPlayer + ") LOSE at " + (row + 1).ToString() + "," + (col + 1).ToString();
                        }
                 

                   
               


                        board[row, col] = -1;
                    }
                }
            }
            if (suitablePlacesOppo.Count == 1)
            {
                return "Suggested next place " + suitablePlacesOppo[0];
            }
            else if (suitablePlacesOppo.Count > 1)
            {
                return "LOSE";
            } 
            else
            //else if (suitablePlaces.Count() > 0 )// // If there are suitable places, return their coordinates
            //{
                return suitablePlaces[0];//string.Join("/", suitablePlaces);
            //}
            //else
            //{
            //    // If no suitable places, return "Lose"
            //    return "Lose";
            //}
        }
        public string CheckNextMove1()
        {
            int nextPlayer = (currentPlayer == 0) ? 1 : 0;
            List<string> suitablePlaces = new List<string>();
            List<string> suitablePlacesNormal = new List<string>();
            // bool IsDraw = true;
            // Check for available moves
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (board[row, col] == -1)
                    {
                        // Simulate the next move
                        board[row, col] = nextPlayer;

                        // Check if the current player wins after this move
                        if (CheckWin(row, col, currentPlayer))
                        {
                         
                           // return "Win";
                            suitablePlaces.Add((row+1).ToString() + "," + (col+1).ToString());
                            
                           goto win;
                        }
                        else
                        {
                            // IsDraw = true;
                            suitablePlacesNormal.Add((row + 1).ToString() + "," + (col + 1).ToString());
                        }
                        // Revert the move
                        board[row, col] = -1;
                    }
                }
            }
            win:
            // If there are suitable places, return their coordinates
            if (suitablePlaces.Count > 0 )
            {
                return string.Join("/", suitablePlaces).Split('/')[0] + " Win ";
            }
            else if (suitablePlacesNormal.Count > 0)
            {
                return string.Join("/", suitablePlacesNormal).Split('/')[0] + " Suggested ";
            }
            else
            {
                // If no suitable places, return "Lose"
                return  "Next or Current Random place" ;
            }
        }

        private bool CheckWin(int row, int col, int currentPlayer)
        {
           
            int symbol = board[row, col];

            // Check horizontally
            int count = 0;
            for (int c = 0; c < size; c++)
            {
                if (board[row, c] == symbol)
                {
                    count++;
                    if (count >= 5  ) return true;
                }
                else
                {
                    count = 0;
                }
            }

            // Check vertically
            count = 0;
            for (int r = 0; r < size; r++)
            {
                if (board[r, col] == symbol)
                {
                    count++;
                    if (count >= 5  ) return true;
                }
                else
                {
                    count = 0;
                }
            }

            // Check diagonally (top-left to bottom-right)
            count = 0;
            for (int r = row, c = col; r >= 0 && c >= 0; r--, c--)
            {
                if (board[r, c] == symbol)
                {
                    count++;
                    if (count >= 5  ) return true;
                }
                else
                {
                    count = 0;
                }
            }
            for (int r = row + 1, c = col + 1; r < size && c < size; r++, c++)
            {
                if (board[r, c] == symbol)
                {
                    count++;
                    if (count >= 5  ) return true;
                }
                else
                {
                    count = 0;
                }
            }

            // Check diagonally (top-right to bottom-left)
            count = 0;
            for (int r = row, c = col; r >= 0 && c < size; r--, c++)
            {
                if (board[r, c] == symbol)
                {
                    count++;
                    if (count >= 5 ) return true;
                }
                else
                {
                    count = 0;
                }
            }
            for (int r = row + 1, c = col - 1; r < size && c >= 0; r++, c--)
            {
                if (board[r, c] == symbol)
                {
                    count++;
                    if (count >= 5  ) return true;
                }
                else
                {
                    count = 0;
                }
            }

            return false;
        }
    }




}
