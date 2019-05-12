namespace _02.LongestIncreasingSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static int[] len;
        private static int[] prev;
        private readonly static Stack<int> subSeq = new Stack<int>();

        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Trim()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            len = new int[numbers.Length];
            prev = new int[numbers.Length];

            FindSequenceLengths(numbers);

            PrintFirstLongestIncreasingSequence(numbers);

        }

        private static void PrintFirstLongestIncreasingSequence(int[] numbers)
        {
            int index = len.ToList().IndexOf(len.Max());

            while (index >= 0)
            {
                subSeq.Push(numbers[index]);
                index = prev[index];
            }

            Console.WriteLine(string.Join(" ", subSeq));
        }

        private static void FindSequenceLengths(int[] numbers)
        {
            for (int currentNumIndex = 0; currentNumIndex < numbers.Length; currentNumIndex++)
            {
                len[currentNumIndex] = 1;
                prev[currentNumIndex] = -1;

                int currentNum = numbers[currentNumIndex];

                for (int previousNumIndex = 0; previousNumIndex < currentNumIndex; previousNumIndex++)
                {
                    int previousNum = numbers[previousNumIndex];

                    if (previousNum < currentNum && len[previousNumIndex] + 1 > len[currentNumIndex])
                    {
                        len[currentNumIndex] = len[previousNumIndex] + 1;
                        prev[currentNumIndex] = previousNumIndex;
                    }
                }

            }

        }
    }
}
