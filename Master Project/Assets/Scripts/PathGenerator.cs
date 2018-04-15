using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using System.Linq;
using System.Text;
using System.Diagnostics;

//Dijkstra's algorithm borrowed from this website
//http://www.csharpstar.com/dijkstra-algorithm-csharp/

public class PathGenerator : MonoBehaviour
{
    public List<Text> pathWeights;
    public int source;
    public int destination;
    public int[] distances;
    // TODO connect nodes and edges to view
    // TODO add source/destination logic for allowing paths to be tapped
    // TODO add instruction pop-up
    // TODO add source/destination information on-screen
    // TODO figure out scoring

    // Use this for initialization
    void Start()
    {
        // TODO Figure out how to call Begin elsewhere and call it with a different level
        Begin();
    }

    void Begin(int level = 1)
    {
        int[,] graph = new int[14, 14];

        System.Random rand = new System.Random();

        List<Tuple<int, int>> edgeList = {{0,1},{1,13},{1,3},{13,2},{3,4},{4,2},
            {4,5},{6,5},{6,7},{5,9},{9,10},{9,8},{8,12},{11,12},{9,11},{8,7},{13,6}};

        foreach (Tuple<int, int> edge in edgeList)
        {
            int edgeNum = rand.Next(1, level + 5);
            graph[edge.Item1][edge.Item2] = edgeNum;
            graph[edge.Item2][edge.Item1] = edgeNum;
            pathWeights.Add(Convert.ToString(edgeNum));
        }

        List<int> postOfficeOptions = { 0, 2, 7, 10, 12 };

        int sourceIndex = rand.Next(0, 5);
        source = postOfficeOptions[sourceIndex];

        distances = DijkstraAlgo(graph, source, graph.Length);

        postOfficeOptions.RemoveAt(sourceIndex);

        int destinationIndex = rand.Next(0, 4);
        destination = postOfficeOptions[destinationIndex];
    }

    public static int[] DijkstraAlgo(int[,] graph, int source, int verticesCount)
    {
        int[] distances = new int[verticesCount];
        bool[] shortestPathTreeSet = new bool[verticesCount];

        for (int i = 0; i < verticesCount; ++i)
        {
            distances[i] = int.MaxValue;
            shortestPathTreeSet[i] = false;
        }

        distances[source] = 0;

        for (int count = 0; count < verticesCount - 1; ++count)
        {
            int u = MinimumDistance(distances, shortestPathTreeSet, verticesCount);
            shortestPathTreeSet[u] = true;

            for (int v = 0; v < verticesCount; ++v)
                if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distances[u] != int.MaxValue && distances[u] + graph[u, v] < distances[v])
                    distances[v] = distances[u] + graph[u, v];
        }

        return distances;
    }

    private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
    {
        int min = int.MaxValue;
        int minIndex = 0;

        for (int v = 0; v < verticesCount; ++v)
        {
            if (shortestPathTreeSet[v] == false && distance[v] <= min)
            {
                min = distance[v];
                minIndex = v;
            }
        }

        return minIndex;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
