using System;

namespace _04.VariationsWithRepetition
{
    class Program
    {
        private static string[] elements;
        private static int variationLength;
        private static string[] vector;

        static void Main()
        {
            elements = Console.ReadLine()?
                .Trim()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            variationLength = int.Parse(Console.ReadLine());
            vector = new string[variationLength];

            GenerateVariation(0);
        }

        private static void GenerateVariation(int index)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                vector[index] = elements[i];
                GenerateVariation(index + 1);
            }
        }
    }
}
