using System;
using System.Collections.Generic;

namespace _06.EightQueens
{
    public class Program
    {
        private const int Size = 8;
        private static bool[,] board = new bool[Size, Size];

        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        private static int foundSolutions;

        public static void Main()
        {
            PutQueens(0);

            Console.WriteLine($"{foundSolutions} solutions found.");
        }

        private static void PutQueens(int row)
        {
            if (row == Size)
            {
                PrintEightQueensSolution();
                return;
            }

            for (int col = 0; col < Size; col++)
            {
                if (CanPlaceQueen(row, col))
                {
                    MarkAllAttackedPositions(row, col);
                    PutQueens(row + 1);
                    UnmarkAllAttackedPositions(row, col);
                }
            }
        }

        private static void UnmarkAllAttackedPositions(int row, int col)
        {
            attackedCols.Remove(col);
            attackedLeftDiagonals.Remove(col - row);
            attackedRightDiagonals.Remove(col + row);

            board[row, col] = false;
        }

        private static void MarkAllAttackedPositions(int row, int col)
        {
            attackedCols.Add(col);
            attackedLeftDiagonals.Add(col - row);
            attackedRightDiagonals.Add(col + row);

            board[row, col] = true;
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            var isCellOccupied = attackedCols.Contains(col) 
                                 || attackedLeftDiagonals.Contains(col - row) 
                                 || attackedRightDiagonals.Contains(col + row);

            return !isCellOccupied;
        }

        private static void PrintEightQueensSolution()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (board[i,j])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            foundSolutions++;
        }
    }
}
