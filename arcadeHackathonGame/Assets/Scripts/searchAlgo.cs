using System;
using System.Collections.Generic;

public class Test
{
	int numberOfNodes;
	int numberOfPokemon;
	LinkedList<int>[] adjList;
	const int maxn = 100; //This gives us a sufficiently large list to store stuffs.

	void breadthFirstSearch(int startNode){ // ---------------------------------------------------------
			bool[] visited = new bool[numberOfNodes]; // records which nodes have already been visited (we do not want to visit a node more than once)
			int[] distance = new int[numberOfNodes]; // the shortest distance away from the starting node for each of the nodes
		
			for(int k = 0; k < numberOfNodes; k++){ // clears any existing garbage data in the arrays + intializes the distance array
				visited[k] = false;
				distance[k] = 0;
			}
		
			Queue<int> orderOfVisits = new Queue<int>(); // queue will record which nodes we are going to visit and in which order
		
			orderOfVisits.Enqueue(startNode); // 
			visited[startNode] = true;     // some more initializations
			distance[startNode] = 0;       //
		
			while(orderOfVisits.Count != 0){ // the loop will continue to run until every node has been visited
				int front = orderOfVisits.Dequeue(); // removes the first element (which is a node index) of the queue and stores in variable
		
				foreach (int node in adjList[front]) {
					if(visited[node] == false){ // if the node hasn't been visited, then update the distance
						distance[node] = distance[front] + 1; // <- done here
						orderOfVisits.Enqueue(node); // we then want to check the nodes that are connected to the node we just checked, so add em to the queue.
		
						for(int j = 0; j < numberOfPokemon; j++){ // loop through all the pokemon locations and check if any of them match
							if(node == pokemonNodeIndex[j]){ // if one does match, store the shortest distance to that pokemon in a different location
								distanceToPokemon[node] = distance[front] + 1; // <- here
							}
						}
					}
				}
			}
		}

	public static void Main()
	{	// Helper Functions
		
		adjList = new LinkedList<int>[maxn]; //Initialise stuff!

		for(int i = 0; i < adjList.Length; i++){ 
			adjList[i] = new LinkedList<int>();
		}
		
		// My graph has 5 nodes (0-4) and 4 edges: (0,1),(0,2),(2,3),(1,2)
		
		numberOfNodes = 10;
		numberOfPokemon = 2;

		int[] pokemonNodeIndex = new int[numberOfPokemon]; // records where the pokemon are on the graph
		int[] distanceToPokemon = new int[numberOfPokemon]; // will be filled with the shortest distance to each pokemon

		pokemonNodeIndex[0]=3;
		pokemonNodeIndex[1]=9;
		
		adjList = new LinkedList<int>[10]; //Initialise stuff!
		
		for(int i = 0; i < adjList.Length; i++){ //Initialise even more stuff!
			adjList[i] = new LinkedList<int>();
		}
		
		adjList[0].AddFirst(1); //Put your edges in!
		adjList[0].AddFirst(4);
		adjList[1].AddFirst(0);
		adjList[1].AddFirst(2);
		adjList[1].AddFirst(3);
		adjList[1].AddFirst(4);
		adjList[1].AddFirst(5);
		adjList[2].AddFirst(1);
		adjList[2].AddFirst(3);
		adjList[3].AddFirst(1);
		adjList[3].AddFirst(5);
		adjList[3].AddFirst(2);
		adjList[3].AddFirst(6);
		adjList[4].AddFirst(0);
		adjList[4].AddFirst(1);
		adjList[4].AddFirst(5);
		adjList[4].AddFirst(8);
		adjList[5].AddFirst(1);
		adjList[5].AddFirst(3);
		adjList[5].AddFirst(4);
		adjList[5].AddFirst(6);
		adjList[5].AddFirst(7);
		adjList[5].AddFirst(8);
		adjList[6].AddFirst(3);
		adjList[6].AddFirst(5);
		adjList[6].AddFirst(7);
		adjList[7].AddFirst(5);
		adjList[7].AddFirst(6);
		adjList[7].AddFirst(8);
		adjList[7].AddFirst(9);
		adjList[8].AddFirst(4);
		adjList[8].AddFirst(5);
		adjList[8].AddFirst(7);
		adjList[8].AddFirst(9);
		adjList[9].AddFirst(8);
		adjList[9].AddFirst(7);

		Console.WriteLine("Test Case Loaded");

		int j = 0;

	    foreach (LinkedList<int> list in adjList)
	    {
	        Console.Write("adjList[" + j + "] -> ");

	        foreach (int edge in list)
	        {
	            Console.Write(edge + " ");
	        }

	        ++j;
	        Console.WriteLine();
    	}
    	
    	//Actually run stuff!
    	breadthFirstSearch(0);
    	Console.Write(distanceToPokemon[0] + "," + distanceToPokemon[1]);
    	
	}
}