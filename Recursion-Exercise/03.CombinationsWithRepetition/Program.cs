using System;
using System.Collections.Generic;

namespace _03.CombinationsWithRepetition
{   
    public class Program
    {
        private static readonly List<string> combinations = new List<string>();
        private static int[] combination;
        private static int combinationLength;
        
        private static int elementsCount;
       
        public static void Main()
        {
            elementsCount = int.Parse(Console.ReadLine());
            combinationLength = int.Parse(Console.ReadLine());

            combination = new int[combinationLength];

            GenerateCombinations(0);

            PrintCombinations();
        }

        private static void GenerateCombinations(int index)
        {

            if (index == combination.Length)
            {
                bool hasDuplicate = false;
                for (int i = 0; i < combination.Length - 1; i++)
                {
                    if (combination[i] > combination[i + 1])
                    {
                        hasDuplicate = true;  
                    }
                }

                if (!hasDuplicate)
                {
                    combinations.Add(string.Join(" ", combination));
                }
                
                return;
            }

            for (int i = 1; i <= elementsCount; i++)
            {
                combination[index] = i;
                GenerateCombinations(index + 1);
            }
        }

        private static void PrintCombinations()
        {
            foreach (var combo in combinations)
            {               
                Console.WriteLine(combo);
            }
        }
    }
}
