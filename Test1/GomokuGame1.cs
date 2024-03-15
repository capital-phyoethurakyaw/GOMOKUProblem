using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class GomokuGame1
    {

        private char[,] board;
        private int size;
        private char currentPlayer;

        public GomokuGame1(int size)
        {
            this.size = size;
            board = new char[size, size];
            //currentPlayer = 'B'; // Black starts the game
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    board[row, col] = ' ';
                }
            }
        }

        public void PrintBoard()
        {
            // Console.WriteLine("  " + string.Join(" ", new string[size].Replace('\0', '-')));
            for (int row = 0; row < size; row++)
            {
                Console.Write(row + 1 + "|");
                for (int col = 0; col < size; col++)
                {
                    Console.Write(board[row, col] + "|");
                }
                Console.WriteLine();
                // Console.WriteLine("  " + string.Join(" ", new string[size].Replace('\0', '-')));
            }
            ///    Console.WriteLine("  " + string.Join(" ", new string[size].Replace('\0', '-')));
            Console.WriteLine("  " + string.Join(" ", new string[size]).Replace('\0', ' ') + "  COLUMNS");
        }

        public bool MakeMove(int row, int col)
        {
            if (row < 0 || row >= size || col < 0 || col >= size || board[row, col] != ' ')
            {
                return false;
            }

            board[row, col] = currentPlayer;
            return true;
        }

        public bool CheckWin(int row, int col)
        {
            char symbol = board[row, col];

            // Check horizontally
            int count = 0;
            for (int c = 0; c < size; c++)
            {
                if (board[row, c] == symbol)
                {
                    count++;
                    if (count >= 5) return true;
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
                    if (count >= 5) return true;
                }
                else
                {
                    count = 0;
                }
            }

            // Check diagonally (top-left to bottom-right)
            count = 0;
            for (int r = row, c = col; r < size && c < size; r++, c++)
            {
                if (board[r, c] == symbol)
                {
                    count++;
                    if (count >= 5) return true;
                }
                else
                {
                    count = 0;
                }
            }

            // Check diagonally (top-right to bottom-left)
            count = 0;
            for (int r = row, c = col; r < size && c >= 0; r++, c--)
            {
                if (board[r, c] == symbol)
                {
                    count++;
                    if (count >= 5) return true;
                }
                else
                {
                    count = 0;
                }
            }

            return false;
        }

        public void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == 'B') ? 'W' : 'B';
        }

        public char GetCurrentPlayer()
        {
            return currentPlayer;
        }
    }
}
