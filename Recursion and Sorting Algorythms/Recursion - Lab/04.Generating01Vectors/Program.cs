using System;

namespace _04.Generating01Vectors
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] vector = new int[n];

            Generate01Vectors(vector, 0);
        }

        private static void Generate01Vectors(int[] vector, int index)
        {
            if (index == vector.Length)
            {
                PrintVector(vector);
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                Generate01Vectors(vector, index + 1);
            }

        }

        private static void PrintVector(int[] vector)
        {
            Console.WriteLine(string.Join("", vector));
        }
    }
}
