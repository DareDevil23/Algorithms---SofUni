using System;

namespace _02.NestedLoops
{
    public class Program
    {
        private static int digitsCount;
        private static int[] vector;

        public static void Main()
        {
            digitsCount = int.Parse(Console.ReadLine());
            vector = new int[digitsCount];

            GenerateNumbers(0);
        }

        private static void GenerateNumbers(int index)
        {
            if (index == vector.Length)
            {
                PrintVector();
                return;
            }

            for (int i = 1; i <= digitsCount; i++)
            {
                vector[index] = i;
                GenerateNumbers(index + 1);
            }
        }

        private static void PrintVector()
        {
            Console.WriteLine(string.Join(" ", vector));
        }
    }
}
