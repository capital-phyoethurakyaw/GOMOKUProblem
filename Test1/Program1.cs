using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Test1
{
    class Program1
    {
       
            static void Main1(string[] args)
            {
                Console.WriteLine("Welcome to Gomoku!");

                Console.Write("Enter the size of the board (row and columns are same): ");
                int size = int.Parse(Console.ReadLine());

                GomokuGame game = new GomokuGame(size);
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
        //static void Main(string[] args)
        //{
        //    //string Matrix = "";
        //    //string Mover = "0";
        //    //string[] _NxN = System.Console.ReadLine().Trim().Split(' ');
        //    //Matrix = _NxN[0];
        //    //Mover = _NxN[1] == "0" ? "0" : "1";

        //    //string[] arr = new string[8] ;


        //    // Read input values as strings

        //    //    string[] stArrayData = System.Console.ReadLine().Trim().Split(' ');
        //    //string input1 = stArrayData.First();
        //    //string input2 = stArrayData.Last();



        //    //    // Parse input strings to integers
        //    //    int a = int.Parse(input1);
        //    //    int b = int.Parse(input2);

        //    //    // Check if inputs are within the given range
        //    //    if (a < 1 || a > 1000 || b < 1 || b > 1000)
        //    //    {
        //    //        Console.WriteLine("Inputs must be in the range of 1 to 1000.");
        //    //    Console.ReadLine();
        //    //    return;
        //    //    }

        //    //    // Calculate the sum
        //    //    int sum = a + b;

        //    //    // Print the sum
        //    //    Console.WriteLine(sum);
        //    //Console.ReadLine();
        //    //    Console.Write("Enter the first positive integer: ");
        //    //    int num1 = Convert.ToInt32(Console.ReadLine());

        //    //    Console.Write("Enter the second positive integer: ");
        //    //    int num2 = Convert.ToInt32(Console.ReadLine());

        //    //    int sum = num1 + num2;
        //    //    Console.WriteLine("The sum of " + num1 + " and " + num2 + " is: " + sum);
        //    //Console.ReadLine();

        //    // Gomoku gomoku = new Gomoku();

        //    //var line1 = System.Console.ReadLine().Trim();
        //    //var N = int.Parse(line1);
        //    //for (var i = 0; i < N+1; i++)
        //    //{
        //    //    string[] stArrayData = System.Console.ReadLine().Trim().Split(' ');
        //    //    try
        //    //    {
        //    //        System.Console.WriteLine("hello = {0} , world = {1}", stArrayData[0], stArrayData[1]);
        //    //    }
        //    //    catch
        //    //    {

        //    //    }
        //    //}
        //}


    }
}
