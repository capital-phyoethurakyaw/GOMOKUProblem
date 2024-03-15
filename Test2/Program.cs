using System;


namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Gomoku!");

            Console.Write("Enter the size of the board (row and columns are same): ");
            string[] input = Console.ReadLine().Split(' ');
            int size = int.Parse(input[0]);

            Console.WriteLine("Enter the board configuration (0 for black, 1 for white, -1 for empty):");
            int[,] initialBoard = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                string[] rowValues = Console.ReadLine().Split(' ');
                for (int j = 0; j < size; j++)
                {
                    initialBoard[i, j] = int.Parse(rowValues[j]);
                }
            }

            Console.Write("Enter the player turn (0 for black, 1 for white): ");
            int playerTurn = int.Parse(Console.ReadLine());

            GomokuGame game = new GomokuGame(size, initialBoard, playerTurn);

            string nextMove = game.CheckNextMove();
            Console.WriteLine("Next move: " + nextMove );

            // Wait for user input to prevent closing the window immediately
            Console.ReadLine();
        }
    }
}
