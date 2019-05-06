using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07.FindAllPathsInLabyrinth
{
    public class Program
    {
        private static char[,] labyrinth;
        private static List<char> path = new List<char>();

        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            labyrinth = new char[rows,cols];

            InitilizeLabyrinth();

            FindPaths(0, 0, 'S');
        }

        private static void FindPaths(int row, int col, char direction)
        {
            if (!IsInBounds(row, col))
                return;

            path.Add(direction);
         
            if (IsExit(row, col))
            {
                PrintPath();
            }
            else if (!IsVisited(row,col) && IsFree(row, col))
            {
                MarkCell(row, col);

                FindPaths(row, col + 1, 'R');
                FindPaths(row + 1, col, 'D');
                FindPaths(row, col - 1, 'L');
                FindPaths(row - 1, col, 'U');

                UnmarkCell(row, col);
            }

            path.RemoveAt(path.Count - 1);
        }

        private static void UnmarkCell(int row, int col)
        {
            labyrinth[row, col] = '-';
        }

        private static void MarkCell(int row, int col)
        {
            labyrinth[row, col] = '#';
        }

        private static bool IsVisited(int row, int col)
        {
            return labyrinth[row, col] == '#';
        }

        private static bool IsFree(int row, int col)
        {
            return labyrinth[row, col] == '-';
        }

        private static void PrintPath()
        {
            Console.WriteLine(string.Join("", path.Skip(1)));
        }

        private static bool IsExit(int row, int col)
        {
            return labyrinth[row, col] == 'e';
        }

        private static bool IsInBounds(int row, int col)
        {
            return
                row >= 0 
                && row < labyrinth.GetLength(0)                         
                && col >= 0 
                && col < labyrinth.GetLength(1);
        }

        private static void InitilizeLabyrinth()
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                char[] inputLine = Console.ReadLine().ToCharArray();
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    labyrinth[i, j] = inputLine[j];
                }
            }
        }
    }
}
