using System;
using System.Collections.Generic;


class adj{

	// -----------------------------------------------------------------------------------------------
	int numberOfNodes;
	int numberOfPokemon;

	int[] pokemonNodeIndex;
	public int[] distance;

	public LinkedList<int>[] adjList;

	const int maxn = 100;
	const int inf = 10000000;

	// -----------------------------------------------------------------------------------------------

	public adj(int numNodes, int numPokemon, int[] pokemonIndex){
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
	        Console.Write("adjList[" + i + "] -> ");

	        foreach (int edge in list)
	        {
	            Console.Write(edge + " ");
	        }

	        i++;
	        Console.WriteLine();
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

	public void breadthFirstSearch(int startNode){
		bool[] visited = new bool[numberOfNodes];

		for(int i = 0; i < numberOfNodes; i++){
			visited[i] = false;
			distance[i] = inf; //default value - if a node can't be reached, it's distance will be very large.
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

	public bool gameEnded(int currentPosition) {
		breadthFirstSearch(currentPosition);
		bool value = true;
		foreach (pokemon in pokemonNodeIndex) {
			if (distance[pokemon] != inf) {
				value = false;
			}
		}

		return value;
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

public class testGraph{

	public static void Main(){

		int currentPosition = 0; //This comes from Unity
		int nN = 10; //This comes from Unity
		int nP = 2; //This comes from Unity
		int[] pIndex = new int[2] {3, 9}; //This comes from Unity

		adj testGraph = new adj(nN, nP, pIndex);

		testGraph.adjList[0].AddFirst(1); //This comes from Unity
		testGraph.adjList[0].AddFirst(4); // |
		testGraph.adjList[1].AddFirst(0); // |
		testGraph.adjList[1].AddFirst(2); // |
		testGraph.adjList[1].AddFirst(3); // v
		testGraph.adjList[1].AddFirst(4);
		testGraph.adjList[1].AddFirst(5);
		testGraph.adjList[2].AddFirst(1);
		testGraph.adjList[2].AddFirst(3);
		testGraph.adjList[3].AddFirst(1);
		testGraph.adjList[3].AddFirst(5);
		testGraph.adjList[3].AddFirst(2);
		testGraph.adjList[3].AddFirst(6);
		testGraph.adjList[4].AddFirst(0);
		testGraph.adjList[4].AddFirst(1);
		testGraph.adjList[4].AddFirst(5);
		testGraph.adjList[4].AddFirst(8);
		testGraph.adjList[5].AddFirst(1);
		testGraph.adjList[5].AddFirst(3);
		testGraph.adjList[5].AddFirst(4);
		testGraph.adjList[5].AddFirst(6);
		testGraph.adjList[5].AddFirst(7);
		testGraph.adjList[5].AddFirst(8);
		testGraph.adjList[6].AddFirst(3);
		testGraph.adjList[6].AddFirst(5);
		testGraph.adjList[6].AddFirst(7);
		testGraph.adjList[7].AddFirst(5);
		testGraph.adjList[7].AddFirst(6);
		testGraph.adjList[7].AddFirst(8);
		testGraph.adjList[7].AddFirst(9);
		testGraph.adjList[8].AddFirst(4);
		testGraph.adjList[8].AddFirst(5);
		testGraph.adjList[8].AddFirst(7);
		testGraph.adjList[8].AddFirst(9);
		testGraph.adjList[9].AddFirst(8);
		testGraph.adjList[9].AddFirst(7);

		Console.WriteLine("Test Cases Loaded.");

		testGraph.breadthFirstSearch(currentPosition);

		Console.WriteLine("The Best Move is: " + testGraph.bestMove(currentPosition)); // 

		Console.WriteLine("The game has ended: " + testGraph.gameEnded(currentPosition)); //Has the game ended?
	}
}