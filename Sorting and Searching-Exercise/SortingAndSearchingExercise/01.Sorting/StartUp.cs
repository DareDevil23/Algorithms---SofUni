namespace _01.Sorting
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            string inputLine = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(inputLine))
            {
                return;
            }

            int[] numbers = inputLine.Split(' ').Select(int.Parse).ToArray();

            QuickSort.Sort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

    }

}
