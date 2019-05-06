using System;
using System.Linq;

namespace _02.QuickSort
{
    class StartUp
    {
        static void Main()
        {
            string inputLine = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(inputLine))
            {
                return;
            }

            int[] numbers = inputLine
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            QuickSort.Sort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
