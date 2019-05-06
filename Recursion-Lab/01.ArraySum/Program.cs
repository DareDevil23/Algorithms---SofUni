using System;
using System.Linq;

namespace _01.ArraySum
{
    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int sum = RecursiveSum(numbers, 0);

            Console.WriteLine(sum);
        }

        private static int RecursiveSum(int[] numbers, int index)
        {
            if (index == numbers.Length - 1)
            {
                return numbers[index];
            }

            return numbers[index] + RecursiveSum(numbers, index + 1);
        }
    }
}
