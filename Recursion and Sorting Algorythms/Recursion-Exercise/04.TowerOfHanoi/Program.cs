using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.TowerOfHanoi
{
    class Program
    {
        private static int steps = 0;

        private static Stack<int> source;
        private static readonly Stack<int> destination = new Stack<int>();
        private static readonly Stack<int> spare = new Stack<int>();

        static void Main()
        {
            int numberOfDisks = int.Parse(Console.ReadLine());

            source = new Stack<int>(Enumerable.Range(1, numberOfDisks).Reverse());
            PrintPegs();
            MoveDisks(numberOfDisks, source, destination, spare);
        }

        private static void PrintPegs()
        {
            Console.WriteLine($"Source: {string.Join(", ", source.Reverse())}");
            Console.WriteLine($"Destination: {string.Join(", ", destination.Reverse())}");
            Console.WriteLine($"Spare: {string.Join(", ", spare.Reverse())}");
            Console.WriteLine();
        }

        private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottomDisk == 1)
            {
                steps++;
                destination.Push(source.Pop());
                Console.WriteLine($"Step #{steps}: Moved disk");
                PrintPegs();
                return;
            }
            
            MoveDisks(bottomDisk - 1, source, spare, destination);
            destination.Push(source.Pop());
            MoveDisks(bottomDisk - 1, spare, destination, source);

        }
    }
}
