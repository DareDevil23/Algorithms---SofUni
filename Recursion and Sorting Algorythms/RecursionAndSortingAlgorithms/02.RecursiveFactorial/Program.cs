using System;

namespace _02.RecursiveFactorial
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            long factorial = GetFactorial(n);

            Console.WriteLine(factorial);
        }

        private static long GetFactorial(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            return number * GetFactorial(number - 1);
        }
    }
}
