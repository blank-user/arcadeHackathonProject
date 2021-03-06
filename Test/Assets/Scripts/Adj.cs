﻿using UnityEngine;
using System;
using System.Collections.Generic;

public class Adj {
	
	// -----------------------------------------------------------------------------------------------
	int numberOfNodes;

	int[] pokemonNodeIndex;
	public int[] distance;

	public LinkedList<int>[] adjList;

	const int maxn = 100;
	const int inf = 10000000;

	// -----------------------------------------------------------------------------------------------

	public Adj(int numNodes, int numPokemon, int[] pokemonIndex){
		numberOfNodes = numNodes;
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
			Debug.Log(distance[pokemonNodeIndex[i]] + " ");
		}
	}

	public void printDistance(){
		for(int i = 0; i < distance.Length; i++){
			Debug.Log(distance[i] + " " );
		}
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
				}
			}
		}
	}

	private int coolExponentiation(int x, int pow){

		if (pow < 0) {
			return 0;
		}

		int ret = 1;
		while (pow != 0){
			if ((pow & 1) == 1) {
				ret *= x;
			}
			x *= x;
			pow >>= 1;
		}
		return ret;
	}

	private int heuristic() { // ------------------- I THINK THIS FUNCTION IS OK...
		//Gives us the value of the heuristic given the current adjacency list and a certain start node. Returns an int.

		const int inf = 1000000000;
			
		int value = 0;
		for (int i = 0; i < pokemonNodeIndex.Length; i++){

			if(distance[pokemonNodeIndex[i]] == 0){
				value = inf;
				break;
			}
			value = value + coolExponentiation(3,8 - distance[pokemonNodeIndex[i]]); // ok... the closer the pokemon, the larger this value
		} // goes to 8 and then becomes negative??? ... i guess we just ignore those cases.
		return value;
	}

	public bool win(int currentPosition){
		breadthFirstSearch (currentPosition);

		int min = inf;

		for(int i = 0; i < pokemonNodeIndex.Length; i++){
			if (distance [pokemonNodeIndex [i]] < inf) {
				min = pokemonNodeIndex [i];
			}
		}

		if (min == inf) {
			return true;
		} else {
			return false;
		}
	}

	public bool gameOver(int currentPosition){
		
		for (int i = 0; i < pokemonNodeIndex.Length; i++) {
			if (currentPosition == pokemonNodeIndex [i]) {
				return true;
			}
		}
		return false;
	}

	public int bestMove(int currentPosition) {
		// Running to find the best move
		int bestHeuristic = 0;
		int bestMove = 0; //Node to go to!
		foreach (int node in adjList[currentPosition]) {
			breadthFirstSearch(node);

			//printDistance();

			int nextHeuristic = heuristic();

			Debug.Log ("Node: " + node.ToString() + " and value: " + nextHeuristic.ToString());

			if (nextHeuristic > bestHeuristic) {
				bestHeuristic = nextHeuristic;
				bestMove = node;
			}
		}
		return bestMove;
	}

}
