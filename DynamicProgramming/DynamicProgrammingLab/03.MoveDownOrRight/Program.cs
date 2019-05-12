
namespace _03.MoveDownOrRight
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static int[,] matrix;
        private static int matrixRows;
        private static int matrixCols;

        static void Main()
        {
            matrixRows = int.Parse(Console.ReadLine());
            matrixCols = int.Parse(Console.ReadLine());

            matrix = new int[matrixRows, matrixCols];

            ReadMatrixValues();
            FindTheMaxSum();
            PrintThePathForTheBestSum();
        }

        private static void PrintThePathForTheBestSum()
        {
            int currentRow = matrixRows - 1;
            int currentCol = matrixCols - 1;

            List<string> cells = new List<string>
            {
                $"[{currentRow}, {currentCol}]"
            };

            while (currentRow > 0 && currentCol > 0)
            {
                int leftCellValue = matrix[currentRow, currentCol - 1];
                int upperCellValue = matrix[currentRow - 1, currentCol];

                if ( leftCellValue >= upperCellValue)
                {
                    cells.Add($"[{currentRow}, {--currentCol}]");
                }
                else
                {
                    cells.Add($"[{--currentRow}, {currentCol}]");
                }

                if (currentRow == 0 && currentCol > 0)
                {
                    while(currentCol > 1)
                        cells.Add($"[{currentRow}, {--currentCol}]");
                    
                    continue;
                }
                if (currentCol == 0 && currentRow > 0)
                {
                    while(currentRow > 1)
                        cells.Add($"[{--currentRow}, {currentCol}]");                  
                }
            }

            cells.Add("[0, 0]");
            cells.Reverse();
            Console.WriteLine(string.Join(" ", cells));
        }

        private static void ReadMatrixValues()
        {
            for (int row = 0; row < matrixRows; row++)
            {
                int[] rowValues = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                for (int col = 0; col < matrixCols; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }
        }

        private static void FindTheMaxSum()
        {
            //write the sum of first row to the last cell of the row
            for (int col = 1; col < matrixRows; col++)
            {
                matrix[0, col] = matrix[0, col - 1] + matrix[0, col];
            }

            //write the sum of first col to last cell of the column
            for (int row = 1; row < matrixCols; row++)
            {
                matrix[row, 0] = matrix[row - 1, 0] + matrix[row, 0];
            }

            //write the sum of all elements in the last cell of the matrix
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] += Math.Max(matrix[i, j - 1], matrix[i - 1, j]);
                }
            }
        }
    }
}
