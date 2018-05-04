using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

using System.Linq;
using System.Text;
using System.Diagnostics;

//Dijkstra's algorithm borrowed from this website
//http://www.csharpstar.com/dijkstra-algorithm-csharp/


public class PathGenerator2 : MonoBehaviour {
		

	public List<Text> pathWeights;
	public List<Image> pathObjects1;
	private int source;
	private int destination;
	public Text sourceText;
	public Text destText;
	private int[] distances;
	private Dictionary<int, string> officeColors = new Dictionary<int, string>();
	private int[,] graph = new int[14,14];
	
	private int[][] edgeArray = new int[][] {new int[] {1,13},new int[] {1,3}, new int[] {13,2}, new int[] {3,4}, 
			new int[] {4,2}, new int[] {4,5}, new int[] {6,5}, new int[] {6,7},
			new int[] {5,9}, new int[] {9,10}, new int[] {9,8}, new int[] {8,12},
			new int[] {11,12}, new int[] {9,11}, new int[] {8,7}, new int[] {13,6}, new int[] {0,1}};

	// TODO connect nodes and edges to view
	// TODO add source/destination logic for allowing paths to be tapped
	// TODO add instruction pop-up
	// TODO add source/destination information on-screen
	// TODO figure out scoring

	// Use this for initialization
	void Start () {
		// TODO Figure out how to call Begin elsewhere and call it with a different level
		// for the later levels, just pass the level number into begin (Begin(2) and Begin(3))
		Begin (3);
	}

	void Begin (int level = 1) {
		// UnityEngine.Debug.Log(pathObjects1.Count);
		// UnityEngine.Debug.Log(pathObjects1[0]);
			
		Screen.orientation = ScreenOrientation.LandscapeLeft;

		officeColors.Add(0, "Blue");
		officeColors.Add(2, "Red");
		officeColors.Add(7, "Green");
		officeColors.Add(10, "Brown");
		officeColors.Add(12, "Orange");


		System.Random rand = new System.Random ();
		
		
		for(int i = 0; i < edgeArray.Length; i++) {
			int[] edge = edgeArray[i];
			int edgeNum = rand.Next (1, level + 5);
			graph[edge[0], edge[1]] = edgeNum;
			graph[edge[1], edge[0]] = edgeNum;
			pathWeights[i].text = Convert.ToString(edgeNum);
		}
		int[] officeArray = { 0, 2, 7, 10, 12 };
		List<int> postOfficeOptions = new List<int>(officeArray);

		int sourceIndex = rand.Next (0, 5);
		source = postOfficeOptions [sourceIndex];

	
		postOfficeOptions.RemoveAt (sourceIndex);

		int destinationIndex = rand.Next (0, 4);
		destination = postOfficeOptions [destinationIndex];

		sourceText.text = "Start: " + officeColors[source];
		destText.text = "End: " + officeColors[destination];

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

			for (int v = 0; v < verticesCount; ++v) {
				if (Convert.ToBoolean(graph[u, v]) && !shortestPathTreeSet[v] && distances[u] != int.MaxValue && distances[u] + graph[u, v] < distances[v]) {
					distances[v] = distances[u] + graph[u, v];
				}
			}
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

	public void changeMenuScene(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}

	public void checkScore()
	{
		// UnityEngine.Debug.Log(pathObjects1.Count);
		
		distances = DijkstraAlgo (graph, source, graph.GetLength(0));
		int distance = 0;
		for (int i = 0; i < pathObjects1.Count; i++)
		{
			// UnityEngine.Debug.Log("wop");
			// UnityEngine.Debug.Log(pathObjects1[i].isActiveAndEnabled);
			if (pathObjects1[i].isActiveAndEnabled) 
			{
				distance += Int32.Parse (pathWeights [i].text);
				// UnityEngine.Debug.Log(distance);
			}
		}

		if (distance == distances [destination]) {
			UnityEngine.Debug.Log("Success");
			changeMenuScene ("DijkstraGameOver3-4");
		} 
		else 
		{
			UnityEngine.Debug.Log("Failure");
			// pop-up box with some info and try again/quit options
			// clear all paths clicked and try again
		}
			
	}
		
	// Update is called once per frame
	void Update () {
		
	}

}