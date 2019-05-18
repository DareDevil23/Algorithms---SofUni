using System;
using System.Collections.Generic;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;
    private Dictionary<string, int> predecessorCount;

    private HashSet<string> visited = new HashSet<string>();
    private HashSet<string> cycleNodes = new HashSet<string>();

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;

        predecessorCount = new Dictionary<string, int>();

        foreach (KeyValuePair<string, List<string>> node in graph)
        {
            if (!predecessorCount.ContainsKey(node.Key))
            {
                predecessorCount[node.Key] = 0;
            }

            foreach (string child in node.Value)
            {
                if (!predecessorCount.ContainsKey(child))
                {
                    predecessorCount[child] = 0;
                }

                predecessorCount[child]++;
            }
        }
    }

    //public ICollection<string> TopSort()
    //{
    //    List<string> sorted = new List<string>();

    //    while (true)
    //    {
    //        string nodeToRemove = predecessorCount.Keys
    //            .Where(x => predecessorCount[x] == 0)
    //            .FirstOrDefault();

    //        if (nodeToRemove == null)
    //        {
    //            break;
    //        }

    //        List<string> nodesToDecrementSourceCount = graph[nodeToRemove];

    //        foreach (string item in nodesToDecrementSourceCount)
    //        {
    //            predecessorCount[item]--;
    //        }

    //        graph.Remove(nodeToRemove);
    //        predecessorCount.Remove(nodeToRemove);
    //        sorted.Add(nodeToRemove);
    //    }

    //    if (graph.Count() > 0)
    //    {
    //        throw new InvalidOperationException();
    //    }

    //    return sorted;
    //}

    public ICollection<string> TopSort()
    {
        LinkedList<string> sorted = new LinkedList<string>();

        foreach (var node in graph.Keys)
        {
            Dfs(node, sorted);
        }

        return sorted;
    }

    private void Dfs(string node, LinkedList<string> sorted)
    {
        if (!visited.Contains(node))
        {
            visited.Add(node);
            cycleNodes.Add(node);

            foreach (var child in graph[node])
            {
                if (cycleNodes.Contains(child))
                {
                    throw new InvalidOperationException("Cycle  detected.");

                }
                Dfs(child, sorted);
            }

            cycleNodes.Remove(node);
            sorted.AddFirst(node);
        }
    }
}
