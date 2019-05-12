
namespace _01.Fibonacci
{
    using System;

    class Program
    {
        private static long[] memo;

        static void Main()
        {
            bool hasParsed = int.TryParse(Console.ReadLine()?.Trim(), out int n);

            while (!hasParsed)
            {
                hasParsed = int.TryParse(Console.ReadLine()?.Trim(), out n);
            }

            memo = new long[n - 2];

            long result = GetFibonacci(n);

            Console.WriteLine(result);
        }

        private static long GetFibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            if (memo[n - 3] != 0)
            {
                return memo[n - 3];                
            }
            else
            {
                return memo[n - 3] = GetFibonacci(n - 1) + GetFibonacci(n - 2);
            }

        }
    }
}
