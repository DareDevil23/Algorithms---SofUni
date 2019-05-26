namespace _3.MostReliablePath
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
        static double[] percentages;
        static int[] previous;

        static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine().Split(' ')[1]);

            string[] pathTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int startNode = int.Parse(pathTokens[1]);
            int endNode = int.Parse(pathTokens[3]);

            int edgesCount = int.Parse(Console.ReadLine().Split(' ')[1]);

            graph = new Dictionary<int, List<Edge>>();

            ReadGraph(edgesCount);

            percentages = Enumerable.Repeat<double>(-1, graph.Count).ToArray();
            percentages[startNode] = 100;

            bool[] visited = new bool[graph.Count];
            visited[startNode] = true;

            previous = new int[graph.Count];
            previous[startNode] = -1;

            //Djikstra's algorithm

            var queue = new OrderedBag<int>(Comparer<int>.Create((a, b) => (int)(percentages[b] - percentages[a])));

            queue.Add(startNode);

            while (queue.Any())
            {
                int nodeWithMaxPercentage = queue.RemoveFirst();

                if (percentages[nodeWithMaxPercentage] == -1)
                {
                    break; //reached a node with no path further
                }

                foreach (Edge edge in graph[nodeWithMaxPercentage])
                {
                    var otherNode = edge.FirstNode == nodeWithMaxPercentage
                        ? edge.SecondNode
                        : edge.FirstNode;

                    if (!visited[otherNode])
                    {
                        visited[otherNode] = true;
                        queue.Add(otherNode);
                    }

                    double newPercentage = percentages[nodeWithMaxPercentage] / 100 * edge.Cost;

                    if (percentages[otherNode] < newPercentage)
                    {
                        percentages[otherNode] = newPercentage;
                        previous[otherNode] = nodeWithMaxPercentage;

                        //have yo sort again because percentages has changed
                        queue = new OrderedBag<int>(
                            queue,
                            Comparer<int>.Create((a, b) => (int)(percentages[b] - percentages[a])));
                    }
                }

            }

            PrintMostReliablePath(endNode);
        }

        private static void PrintMostReliablePath(int endNode)
        {
            var result = new List<int>();

            int current = endNode;

            while (current != -1) // FirstNode has prevIndex -1
            {
                result.Add(current);

                current = previous[current];
            }

            result.Reverse();

            Console.WriteLine($"Most reliable path reliability: {percentages[endNode]:F2}%");
            Console.WriteLine(string.Join(" -> ", result));
        }

        private static void ReadGraph(int edgesCount)
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
            }
        }
    }
}
