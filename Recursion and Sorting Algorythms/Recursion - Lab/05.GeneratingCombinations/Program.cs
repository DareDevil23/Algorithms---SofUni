using System;
using System.Linq;

namespace _05.GeneratingCombinations
{
    public class Program
    {
        public static void Main()
        {
            int[] numberSet = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int vectorLength = int.Parse(Console.ReadLine());

            int[] vector = new int[vectorLength];

            GenerateCombinations(numberSet, vector, 0, 0);
        }

        private static void GenerateCombinations(int[] numberSet, int[] vector, int index, int border)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }

            for (int i = border; i < numberSet.Length; i++)
            {
                vector[index] = numberSet[i];
                GenerateCombinations(numberSet, vector, index + 1, i + 1);
            }
        }
    }
}
