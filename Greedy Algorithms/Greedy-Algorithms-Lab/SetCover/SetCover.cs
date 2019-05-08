namespace SetCover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SetCover
    {
        public static void Main(string[] args)
        {
            var universe = new[] { 1, 3, 5, 7, 9, 11, 20, 30, 40 };
            var sets = new[]
            {
                new[] { 20 },
                new[] { 1, 5, 20, 30 },
                new[] { 3, 7, 20, 30, 40 },
                new[] { 9, 30 },
                new[] { 11, 20, 30, 40 },
                new[] { 3, 7, 40 }
            };

            var selectedSets = ChooseSets(sets.ToList(), universe.ToList());
            Console.WriteLine($"Sets to take ({selectedSets.Count}):");
            foreach (var set in selectedSets)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            HashSet<int[]> setsHash = new HashSet<int[]>(sets);
            HashSet<int> universeHash = new HashSet<int>(universe);

            List<int[]> resultSets = new List<int[]>();

            while (universeHash.Any())
            {
                int[] currentSet = setsHash
                    .OrderByDescending(s => s.Count(el => universeHash.Contains(el)))
                    .First();

                resultSets.Add(currentSet);

                foreach (var element in currentSet)
                {
                    if (universeHash.Contains(element))
                    {
                        universeHash.Remove(element);
                    }
                }
            }

            return resultSets;
        }
    }
}
