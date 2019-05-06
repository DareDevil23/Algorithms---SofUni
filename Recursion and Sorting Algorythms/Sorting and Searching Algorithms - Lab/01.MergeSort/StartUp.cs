using System;
using System.Linq;

namespace _01.MergeSort
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

            int[] numbers = inputLine.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            MergeSort<int>.Sort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
            
        }
    }
}
