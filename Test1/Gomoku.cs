using System;
using System.Collections.Generic;

class Gomoku
{
    const int Size = 15;
    const int WinLength = 5;
    const int Empty = 0;
    const int Player1 = 1;
    const int Player2 = 2;

    int[,] board = new int[Size, Size];
    int currentPlayer;

    public Gomoku()
    {
        currentPlayer = Player1;
    }

    public void MakeMove(int x, int y)
    {
        if (board[x, y] != Empty)
        {
            throw new ArgumentException("Invalid move");
        }

        board[x, y] = currentPlayer;
        currentPlayer = 3 - currentPlayer;
    }

    public int EvaluateBoard()
    {
        int score = 0;

        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if (board[i, j] == Empty) continue;

                int player = board[i, j];

                // Check horizontal line
                int count = 1;
                for (int k = 1; k < WinLength; k++)
                {
                    if (i + k < Size && board[i + k, j] == player)
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (count == WinLength) return player;

                // Check vertical line
                count = 1;
                for (int k = 1; k < WinLength; k++)
                {
                    if (j + k < Size && board[i, j + k] == player)
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (count == WinLength) return player;

                // Check diagonal line (top-left to bottom-right)
                count = 1;
                for (int k = 1; k < WinLength; k++)
                {
                    if (i + k < Size && j + k < Size && board[i + k, j + k] == player)
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (count == WinLength) return player;

                // Check diagonal line (top-right to bottom-left)
                count = 1;
                for (int k = 1; k < WinLength; k++)
                {
                    if (i + k < Size && j - k >= 0 && board[i + k, j - k] == player)
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (count == WinLength) return player;
            }
        }

        return 0;
    }

    public (int x, int y) Minimax(int depth, int alpha, int beta)
    {
        if (depth == 0 || EvaluateBoard() != 0)
        {
            return (0, 0);
        }

        int bestScore = int.MinValue;
        int bestX = 0;
        int bestY = 0;

        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if (board[i, j] != Empty) continue;

                board[i, j] = currentPlayer;
                int score = MaxValue(depth - 1, alpha, beta);
                board[i, j] = Empty;

                if (score > bestScore)
                {
                    bestScore = score;
                    bestX = i;
                    bestY = j;
                }

                alpha = Math.Max(alpha, bestScore);
                if (beta <= alpha)
                {
                    break;
                }
            }
        }

        return (bestX, bestY);
    }

    int MaxValue(int depth, int alpha, int beta)
    {
        if (depth == 0 || EvaluateBoard() != 0)
        {
            return EvaluateBoard();
        }

        int bestScore = int.MinValue;

        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if (board[i, j] != Empty) continue;

                board[i, j] = currentPlayer;
                int score = MinValue(depth - 1, alpha, beta);
                board[i, j] = Empty;

                bestScore = Math.Max(bestScore, score);
                alpha = Math.Max(alpha, bestScore);
                if (beta <= alpha)
                {
                    break;
                }
            }
        }

        return bestScore;
    }

    int MinValue(int depth, int alpha, int beta)
    {
        if (depth == 0 || EvaluateBoard() != 0)
        {
            return EvaluateBoard();
        }

        int bestScore = int.MaxValue;

        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if (board[i, j] != Empty) continue;

                board[i, j] = 3 - currentPlayer;
                int score = MaxValue(depth - 1, alpha, beta);
                board[i, j] = Empty;

                bestScore = Math.Min(bestScore, score);
                beta = Math.Min(beta, bestScore);
                if (beta <= alpha)
                {
                    break;
                }
            }
        }

        return bestScore;
    }

    public (int x, int y) BestMove()
    {
        int bestScore = int.MinValue;
        int bestX = 0;
        int bestY = 0;

        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if (board[i, j] != Empty) continue;

                board[i, j] = currentPlayer;
                int score = Minimax(4, int.MinValue, int.MaxValue).Item1;
                board[i, j] = Empty;

                if (score > bestScore)
                {
                    bestScore = score;
                    bestX = i;
                    bestY = j;
                }
            }
        }

        return (bestX, bestY);
    }
}