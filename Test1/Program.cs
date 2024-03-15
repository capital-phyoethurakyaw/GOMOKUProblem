using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Test1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Gomoku!");

            Console.Write("Enter the size of the board (row and columns are same): ");
            string[] Input = Console.ReadLine().Split(' ');
            int size = int.Parse(Input[0]);

            GomokuGame1 game = new GomokuGame1(size);
            game.PrintBoard();

            while (true)
            {
                Console.WriteLine("Player {0}'s turn:", game.GetCurrentPlayer());
                Console.Write("Enter row: ");
                int row = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Enter column: ");
                int col = int.Parse(Console.ReadLine()) - 1;

                if (game.MakeMove(row, col))
                {
                    game.PrintBoard();
                    if (game.CheckWin(row, col))
                    {
                        Console.WriteLine("Player {0} wins!", game.GetCurrentPlayer());
                        break;
                    }
                    game.SwitchPlayer();
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                }
            }
        }
    }
}