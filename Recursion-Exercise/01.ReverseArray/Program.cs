using System;
using System.Linq;

namespace _01.ReverseArray
{
    public class Program
    {
        private static int[] array;

        public static void Main()
        {
            array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            PrintReversed(array.Length - 1);
        }

        private static void PrintReversed(int index)
        {
            if (index < 0)
            {
                return;
            }

            string output = index == 0 
                ? array[index] + Environment.NewLine 
                : array[index] + " ";

            Console.Write(output);

            PrintReversed(index - 1);
        }
    }
}
