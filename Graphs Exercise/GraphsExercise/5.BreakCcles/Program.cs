
namespace _5.BreakCycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static SortedDictionary<char, List<char>> graph;

        static void Main(string[] args)
        {
            graph = new SortedDictionary<char, List<char>>();

            ReadGraphFromConsole();

            List<string> removedConnectionsBetweenNodes = new List<string>();

            foreach (var item in graph)
            {
                var startNode = item.Key;
                
                foreach (char endNode in graph[startNode].OrderBy(e => e))
                {
                    graph[startNode].Remove(endNode);  //1 -> 2 5 4  -> from input edges are not directed, thats why we have to remove twice         
                    graph[endNode].Remove(startNode);  //2-> 1 3 

                    if (HasPathBetweenNodes(startNode, endNode))
                    {
                        removedConnectionsBetweenNodes.Add($"{startNode} - {endNode}");
                    }
                    else   ////if there is no another path between nodes we need to add back start and endNode
                    {
                        graph[startNode].Add(endNode); 
                        graph[endNode].Add(startNode); 
                    }
                }
            }

            Console.WriteLine($"Edges to remove: {removedConnectionsBetweenNodes.Count}");
            removedConnectionsBetweenNodes.ForEach(Console.WriteLine);
        }

        private static void ReadGraphFromConsole()
        {
            //1 -> 2 5 4    -> node 1 is connected with nodes 2, 5 and 4
            //2-> 1 3

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    break;
                }

                string[] edgeTokens = inputLine.Split(' ');

                char node = edgeTokens[0].First();
                string[] otherNodes = edgeTokens.Skip(2).ToArray();

                if (!graph.ContainsKey(node))
                {
                    graph[node] = new List<char>();
                }

                graph[node].AddRange(otherNodes.Select(otherNode => otherNode.First()));
            }
        }

        static bool HasPathBetweenNodes(char startNode, char endNode)
        {
            Queue<char> queue = new Queue<char>();

            HashSet<char> visitedNodes = new HashSet<char>();

            queue.Enqueue(startNode);
            visitedNodes.Add(startNode);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                foreach (var childNode in graph[node]) //graph[node] gives us the collection with nodes connected to node
                {
                    if (!visitedNodes.Contains(childNode))
                    {
                        visitedNodes.Add(childNode);
                        queue.Enqueue(childNode);

                        if (childNode == endNode)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
