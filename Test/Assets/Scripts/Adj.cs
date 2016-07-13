using UnityEngine;
using System;
using System.Collections.Generic;

public class Adj {
	
	// -----------------------------------------------------------------------------------------------
	int numberOfNodes;
	int numberOfPokemon;

	int[] pokemonNodeIndex;
	public int[] distance;

	public LinkedList<int>[] adjList;

	const int maxn = 100;
	const int inf = 10000000;

	// -----------------------------------------------------------------------------------------------

	public Adj(int numNodes, int numPokemon, int[] pokemonIndex){
		numberOfNodes = numNodes;
		numberOfPokemon = numPokemon;
		pokemonNodeIndex = pokemonIndex;
		distance = new int[numNodes];

		adjList = new LinkedList<int>[numberOfNodes];

		for(int i = 0; i < adjList.Length; i++){
			adjList[i] = new LinkedList<int>();
		}
	}

	public void printGraph(){
		int i = 0;

		foreach (LinkedList<int> list in adjList)
		{
			Debug.Log("adjList[" + i + "] -> ");

			foreach (int edge in list)
			{
				Debug.Log(edge + " ");
			}

			i++;
		}
	}

	public void printPokemonDistance(){
		for(int i = 0; i < pokemonNodeIndex.Length; i++){
			Console.Write(distance[pokemonNodeIndex[i]] + " ");
		}

		Console.WriteLine();
	}

	public void printDistance(){
		for(int i = 0; i < distance.Length; i++){
			Console.Write(distance[i] + " " );
		}

		Console.WriteLine();
	}

	private void breadthFirstSearch(int startNode){
		bool[] visited = new bool[numberOfNodes];

		for(int i = 0; i < numberOfNodes; i++){
			visited[i] = false;
			distance[i] = inf;
		}

		Queue<int> ord = new Queue<int>();

		ord.Enqueue(startNode);
		visited[startNode] = true;
		distance[startNode] = 0;

		while(ord.Count != 0){
			int front = ord.Dequeue();

			foreach(int node in adjList[front]){

				//Console.WriteLine("Debug: " + node);

				if(visited[node] == false){
					distance[node] = distance[front] + 1;
					ord.Enqueue(node);
					visited[node] = true;

					/*for(int i = 0; i < numberOfPokemon; i++){
						if(node == pokemonNodeIndex[i]){
							distanceToPokemon[node] = distance[front] + 1;
						}
					}*/
				}
			}
		}
	}

	private int coolExponentiation(int Base, int exponent) {
		//Returns an int
		if (exponent <= 0) {
			return 0;
		}
		else {
			int value = 1;
			for (int i = 0; i < exponent; i++) {
				value = value * Base;
			}
			return value;
		}
	}

	private int heuristic(int startNode) {
		//Gives us the value of the heuristic given the current adjacency list and a certain start node. Returns an int.
		int value = 0;	
		for (int i = 0; i < pokemonNodeIndex.Length; i++){
			value = value + coolExponentiation(3,8 - distance[pokemonNodeIndex[i]]);
		}
		return value;
	}

	public int bestMove(int currentPosition) {
		// Running to find the best move
		int bestHeuristic = 0;
		int bestMove = 0; //Node to go to!
		foreach (int node in adjList[currentPosition]) {
			breadthFirstSearch(node);
			int nextHeuristic = heuristic(node);
			if (nextHeuristic > bestHeuristic) {
				bestHeuristic = nextHeuristic;
				bestMove = node;
			}
		}
		return bestMove;
	}

}
