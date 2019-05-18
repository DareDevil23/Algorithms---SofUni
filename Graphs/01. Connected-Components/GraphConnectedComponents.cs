using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    static List<int>[] graph;
    static bool[] visited;

    public static void Main()
    {
        graph = ReadGraph();
        FindGraphConnectedComponents();
    }

    private static List<int>[] ReadGraph()
    {
        int n = int.Parse(Console.ReadLine());
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
        }
        return graph;
    }

    private static void FindGraphConnectedComponents()
    {
        visited = new bool[graph.Length];

        for (int startNode = 0; startNode < graph.Count(); startNode++)
        {
            if (!visited[startNode])
            {
                Console.Write("Connected component:");
                Dfs(startNode);
                Console.WriteLine();
            }
        }
    }

    private static void Dfs(int vertex)
    {
        if (!visited[vertex])
        {
            visited[vertex] = true;
            foreach (var child in graph[vertex])
            {
                Dfs(child);
            }

            Console.Write(" " + vertex);
        }
    }
}