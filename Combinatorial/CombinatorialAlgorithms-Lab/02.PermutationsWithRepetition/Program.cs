﻿namespace _02.PermutationsWithRepetition
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static string[] elements;

        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine()?.Trim();

            while (string.IsNullOrEmpty(inputLine))
                inputLine = Console.ReadLine()?.Trim();

            elements = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index == elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            HashSet<string> swapped = new HashSet<string>();
            for (int i = index; i < elements.Length; i++)
            {
                if (!swapped.Contains(elements[i]))
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);
                    swapped.Add(elements[i]);
                }
            }
        }

        private static void Swap(int first, int second)
        {
            string temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}
