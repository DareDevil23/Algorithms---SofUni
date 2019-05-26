
namespace _1.CableNetwork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Edge
    {
        public int FirstNode { get; set; }

        public int SecondNode { get; set; }

        public int Cost { get; set; }
    }

    class Program
    {
        static Dictionary<int, List<Edge>> graph;
        static HashSet<int> spanningThree;

        static int totalBudget = 0;
        static int usedBudget = 0;

        static void Main(string[] args)
        {
            totalBudget = int.Parse(Console.ReadLine().Split(' ')[1]);
            int nodesCount = int.Parse(Console.ReadLine().Split(' ')[1]);
            int edgesCount = int.Parse(Console.ReadLine().Split(' ')[1]);

            graph = new Dictionary<int, List<Edge>>();
            spanningThree = new HashSet<int>();

            FillGraph(edgesCount);

            Prim();

            Console.WriteLine($"Budget used: {usedBudget}");
        }

        private static void FillGraph(int edgesCount)
        {
            for (int i = 0; i < edgesCount; i++)
            {
                var edgeTokens = Console.ReadLine().Split(' ');

                var edge = new Edge
                {
                    FirstNode = int.Parse(edgeTokens[0]),
                    SecondNode = int.Parse(edgeTokens[1]),
                    Cost = int.Parse(edgeTokens[2])
                };

                if (!graph.ContainsKey(edge.FirstNode))
                {
                    graph.Add(edge.FirstNode, new List<Edge>());
                }

                graph[edge.FirstNode].Add(edge);

                if (!graph.ContainsKey(edge.SecondNode))
                {
                    graph.Add(edge.SecondNode, new List<Edge>());
                }

                graph[edge.SecondNode].Add(edge);

                //edgeTokens = 7 8 4  =>  (firstNode, secondNode, Cost)
                //edgeTokens = 0 8 5 connected => add 0 and 8 in spanningThree (because the nodes are connected)
                if (edgeTokens.Length > 3)
                {
                    spanningThree.Add(edge.FirstNode);
                    spanningThree.Add(edge.SecondNode);
                }
            }
            
        }

        static void Prim()
        {
            var queue = new OrderedBag<Edge>(Comparer<Edge>.Create((e1,e2) => e1.Cost - e2.Cost));

            queue.AddMany(spanningThree.SelectMany(n => graph[n]));     // Adding all graph edges in queue

            while (queue.Any())
            {
                var minEdge = queue.RemoveFirst();

                var notThreeNode = -1;

                //if spanningThree contains firstNode and does not contain second Node
                if (spanningThree.Contains(minEdge.FirstNode)
                    && !spanningThree.Contains(minEdge.SecondNode))
                {
                    notThreeNode = minEdge.SecondNode;
                }

                if (!spanningThree.Contains(minEdge.FirstNode)
                    && spanningThree.Contains(minEdge.SecondNode))
                {
                    notThreeNode = minEdge.FirstNode;
                }

                if (notThreeNode == -1)
                {
                    continue;
                }

                if (totalBudget >= minEdge.Cost)
                {
                    totalBudget -= minEdge.Cost;
                    usedBudget += minEdge.Cost;
                }
                else
                {
                    break;
                }

                spanningThree.Add(notThreeNode);      //adding to the network

                queue.AddMany(graph[notThreeNode]);   //adding to queue all new node edges
            }
        }
    }
}
