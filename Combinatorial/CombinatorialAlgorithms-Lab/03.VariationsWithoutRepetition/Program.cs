using System;

namespace _03.VariationsWithoutRepetition
{
    class Program
    {
        private static string[] elements;
        private static string[] vector;
        private static int variationLength;
        private static bool[] used;

        static void Main()
        {
            elements = Console.ReadLine()?
                .Trim()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);          

            variationLength = int.Parse(Console.ReadLine());
            vector = new string[variationLength];
            used = new bool[elements.Length];

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
                if (!used[i])
                {
                    used[i] = true;
                    vector[index] = elements[i];
                    GenerateVariation(index + 1);
                    used[i] = false;
                }
               
            }
        }
    }
}
