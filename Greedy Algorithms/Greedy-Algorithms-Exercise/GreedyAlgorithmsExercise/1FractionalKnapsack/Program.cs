namespace _1FractionalKnapsack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine().Split(' ')[1]);
            int itemsCount = int.Parse(Console.ReadLine().Split(' ')[1]);

            IList<Item> items = new List<Item>();

            for (int i = 0; i < itemsCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(new []{ "->" }, StringSplitOptions.RemoveEmptyEntries);
                double price = double.Parse(tokens[0]);
                int weigth = int.Parse(tokens[1]);

                items.Add(new Item { Price = price, Weigth = weigth });
            }

            List<Item> sortedItems = items.OrderByDescending(i => i.Price / i.Weigth).ToList();

            int itemIndex = 0;

            double totalPriceTaken = 0f;
            while(capacity > 0 && itemIndex < sortedItems.Count)
            {
                Item currentItem = sortedItems[itemIndex];

                int weightCanTake = Math.Min(capacity, currentItem.Weigth);

                double quantityToTake = (double)weightCanTake / currentItem.Weigth;

                string percentsString = quantityToTake == 1
                    ? 100.ToString()
                    : (quantityToTake * 100).ToString("0.00");

                Console.WriteLine(
                    $"Take {percentsString}% of item with price {currentItem.Price:F2} and weight {currentItem.Weigth:F2}");

                totalPriceTaken += quantityToTake * currentItem.Price;
                
                capacity -= weightCanTake;

                if (weightCanTake != currentItem.Weigth)
                {
                    currentItem.Weigth -= weightCanTake;
                    continue;
                }

                itemIndex++;
            }

            Console.WriteLine($"Total price: {totalPriceTaken:F2}");
        }
    }

    class Item
    {
        public double Price { get; set; }

        public int Weigth { get; set; }
    }
}
