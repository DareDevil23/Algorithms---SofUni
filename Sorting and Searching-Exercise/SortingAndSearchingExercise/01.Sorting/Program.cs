using System;
using System.Linq;

namespace _01.Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(inputLine))
            {
                return;
            }

            int[] numbers = inputLine.Split(' ').Select(int.Parse).ToArray();

            InsertionSort.Sort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

    }

}
