using System;

namespace _03.RecursiveDrawing
{
    public class Program
    {
        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());

            RecursiveDrawing(length);
        }

        private static void RecursiveDrawing(int stringLength)
        {
            if (stringLength == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', stringLength));

            RecursiveDrawing(stringLength - 1);

            Console.WriteLine(new string('#', stringLength));
        }
    }
}
