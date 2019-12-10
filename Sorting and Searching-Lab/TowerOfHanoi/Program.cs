using System;
using System.Collections.Generic;
using System.Linq;

namespace TowerOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] disks = Enumerable.Range(1, 5).Reverse().ToArray();

            Stack<int> source = new Stack<int>(disks);
            Stack<int> aux = new Stack<int>();
            Stack<int> destination = new Stack<int>();

            MoveDisk(5, source, destination, aux);

            Console.WriteLine(string.Join(Environment.NewLine, destination));
        }

        private static void MoveDisk(int disk, Stack<int> source, Stack<int> destination, Stack<int> aux)
        {
            //Recursion Bottom
            if (disk < 1)
            {
                return;
            }

            //Move all disks which are above current disk to aux
            MoveDisk(disk - 1, source, aux, destination);

            //Move current disk to destination
            destination.Push(disk);
            source.Pop();

            //Move all disks from aux to destination
            MoveDisk(disk - 1, aux, destination, source);
        }
    }
}

