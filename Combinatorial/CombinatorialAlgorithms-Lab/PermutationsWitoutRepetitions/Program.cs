using System;
using System.Linq;

namespace PermutationsWitoutRepetitions
{
    class Program
    {
        private static string[] elements;
        private static string[] permutationVector;
        private static bool[] used;

        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine()?.Trim();

            while(string.IsNullOrEmpty(inputLine))
            {
                inputLine = Console.ReadLine()?.Trim();
            }

            elements = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            permutationVector = new string[elements.Length];
            used = new bool[elements.Length];

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index == elements.Length)
            {
                Console.WriteLine(string.Join(" ", permutationVector));
                return;
            }

            for (int i = 0; i < elements.Length ; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    permutationVector[index] = elements[i];
                    Permute(index + 1);
                    used[i] = false;
                }
  
            }            
        }

    }
}
