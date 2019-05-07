using System;

namespace _06.CombinationsWithRepetition
{
    class Program
    {
        private static string[] elements;
        private static int combinationLength;
        private static string[] combination;

        static void Main()
        {
            elements = Console.ReadLine()?.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            combinationLength = int.Parse(Console.ReadLine());
            combination = new string[combinationLength];

            Combinate(0, 0);
        }

        private static void Combinate(int index, int start)
        {
            if (index >= combination.Length)
            {
                Console.WriteLine(string.Join(" ", combination));
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                combination[index] = elements[i];

                Combinate(index + 1, i);
            }
        }
    }
}
