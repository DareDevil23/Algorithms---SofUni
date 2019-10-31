using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _1.CableNetwork
{
    class Program
    {
        private static HashSet<int> connectedNodes = new HashSet<int>();
        private static List<Edge>[] graph;
        private static int currentBudget;

        static void Main(string[] args)
        {
            int totalBudget = int.Parse(Console.ReadLine().Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries)[1]);
            currentBudget = totalBudget;
            int nodesCount = int.Parse(Console.ReadLine().Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries)[1]);
            int edgesCount = int.Parse(Console.ReadLine().Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries)[1]);

            graph = new List<Edge>[nodesCount];
            for (int i = 0; i < nodesCount; i++)
            {
                graph[i] = new List<Edge>();
            }

            for (int i = 0; i < edgesCount; i++)
            {
                string[] infoTokens = Console.ReadLine().Split(' ');

                int firstNode = int.Parse(infoTokens[0]);
                int secondNode = int.Parse(infoTokens[1]);
                int cost = int.Parse(infoTokens[2]);

                if (infoTokens.Length > 3)
                {
                    connectedNodes.Add(firstNode);
                    connectedNodes.Add(secondNode);
                }

                Edge edge = new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Cost = cost
                };

                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);
            }

            Prim();

            Console.WriteLine("Budget used: " + (totalBudget - currentBudget));
        }

        private static void Prim()
        {
            var queue = new OrderedBag<Edge>(Comparer<Edge>.Create((a, b) => a.Cost - b.Cost));

            queue.AddMany(connectedNodes.SelectMany(cn => graph[cn]));

            while (queue.Count > 0)
            {
                Edge minCostEdge = queue.RemoveFirst();
                int first = minCostEdge.First;
                int second = minCostEdge.Second;
                int cost = minCostEdge.Cost;

                int notThreeNode = -1;

                if (connectedNodes.Contains(first) && !connectedNodes.Contains(second))
                {
                    notThreeNode = second;
                }

                if (connectedNodes.Contains(second) && !connectedNodes.Contains(first))
                {
                    notThreeNode = first;
                }

                if (notThreeNode == -1)
                {
                    continue;
                }

                if (currentBudget < cost)
                {
                    break;
                }

                currentBudget -= cost;

                connectedNodes.Add(notThreeNode);
                queue.AddMany(graph[notThreeNode]);
            }
        }
    }

    class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Cost { get; set; }
    }
}
