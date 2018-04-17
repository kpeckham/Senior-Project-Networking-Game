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


public class PathGenerator : MonoBehaviour {
	public List<Text> pathWeights;
	private Text pathWeight;
	public int source;
	public int destination;
	public int[] distances;
	// TODO connect nodes and edges to view
	// TODO add source/destination logic for allowing paths to be tapped
	// TODO add instruction pop-up
	// TODO add source/destination information on-screen
	// TODO figure out scoring

	// Use this for initialization
	void Start () {
		// TODO Figure out how to call Begin elsewhere and call it with a different level
		Begin ();
	}

	void Begin (int level = 1) {
		int[,] graph = new int[14,14];


		System.Random rand = new System.Random ();
		int[][] edgeArray = new int[][] {new int[] {1,13},new int[] {1,3}, new int[] {13,2}, new int[] {3,4}, 
			new int[] {4,2}, new int[] {4,5}, new int[] {6,5}, new int[] {6,7},
			new int[] {5,9}, new int[] {9,10}, new int[] {9,8}, new int[] {8,12},
			new int[] {11,12}, new int[] {9,11}, new int[] {8,7}, new int[] {13,6}};
		
		foreach (int[] edge in edgeArray) {
			int edgeNum = rand.Next (1, level + 5);
			graph[edge[0], edge[1]] = edgeNum;
			graph[edge[1], edge[0]] = edgeNum;
			pathWeight.text = Convert.ToString(edgeNum);
			pathWeights.Add(pathWeight);
		}
		int[] officeArray = { 0, 2, 7, 10, 12 };
		List<int> postOfficeOptions = new List<int>(officeArray);

		int sourceIndex = rand.Next (0, 5);
		source = postOfficeOptions [sourceIndex];

		distances = DijkstraAlgo (graph, source, graph.Length);

		postOfficeOptions.RemoveAt (sourceIndex);

		int destinationIndex = rand.Next (0, 4);
		destination = postOfficeOptions [destinationIndex];
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
	void Update () {
		
	}

}