namespace _03.BinarySearch
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Enumerable.Range(33, 10).ToArray();

            int index = BinarySearch.IndexOf(numbers, 36);

            Console.WriteLine(index);
        }
    }
}
