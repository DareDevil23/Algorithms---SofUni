namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {
        public static void Main(string[] args)
        {
            var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
            var targetSum = 923;

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            coins = coins.OrderByDescending(c => c).ToList();

            int currentSum = 0;

            int coinIndex = 0;
            Dictionary<int, int> coinsCount = new Dictionary<int, int>();

            while (currentSum != targetSum && coinIndex < coins.Count)
            {
                int currentCoin = coins[coinIndex];
                int remainingSum = targetSum - currentSum;

                int numberOfCoinsToTake = remainingSum / currentCoin;

                if (numberOfCoinsToTake != 0 && !coinsCount.ContainsKey(currentCoin))
                {
                    coinsCount.Add(currentCoin, numberOfCoinsToTake);
                }

                currentSum += currentCoin * numberOfCoinsToTake;
                
                coinIndex++;
            }

            if (currentSum < targetSum)
            {
                throw new InvalidOperationException("Can't reach target sum.");
            }

            return coinsCount;
        }
    }
}