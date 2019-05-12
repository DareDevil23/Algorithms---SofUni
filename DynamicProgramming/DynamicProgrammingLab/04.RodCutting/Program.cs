
namespace _04.RodCutting
{
    using System;
    using System.Linq;

    class Program
    {
        private static int[] price;
        private static int[] bestPrice;
        private static int[] bestCombo;

        static void Main()
        {
            price = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int desiredLength = int.Parse(Console.ReadLine());

            bestPrice = new int[price.Length];
            bestCombo = new int[desiredLength + 1];

            var maxPrice = CutRod(desiredLength);
            Console.WriteLine(maxPrice);           
            GetTheParts(desiredLength);    
        }

        private static void GetTheParts(int n)
        {
            while (n - bestCombo[n] != 0)
            {
                Console.Write(bestCombo[n] + " ");
                n -= bestCombo[n];
            }

            Console.WriteLine(bestCombo[n]);
        }

        private static int CutRod(int n)
        {
            if (bestPrice[n] != 0)
            {
                return bestPrice[n];
            }
            if (n == 0)
            {
                return 0;
            }

            int max = 0;
            int wholePart = n;

            for (int i = 1; i <= n; i++)
            {
                int currentMax = Math.Max(price[i], price[i] + CutRod(n - i));
                if (currentMax > max)
                {
                    max = currentMax;
                    wholePart = i;
                }
            }

            bestCombo[n] = wholePart;
            bestPrice[n] = max;

            return max;
        }
    }
}
