/*
Psuedo-code!

\\ lookAheadFactor = how much we try to calculate ahead <------------- We don't even need this if we're going to be greedy!
adjList = something that looks like this [[<3,w>,<2,w>],[<2,w>],[<0,w>,<1,w>],[<0,w>]] for the edges (0,3), (0,2), (1,2)
sIndex = starting student node number
pIndex = array of pokemon node number e.g. [3,2,7]

----------------------------------------------------------------------------------------------------

function possibleMoves(node): <----- Lol wait isn't this redundant?!!
	//Input an int for the node, output an array of possible nodes to travel to
	possibleMoves = []
	for i in range(len(adjList)):
		if <j,w> in adjList[i]:
			possibleMoves.append(i)
	return possibleMoves

----------------------------------------------------------------------------------------------------

function shortestPath(node1, node2, adjList, pIndex):
	// Input two ints for the nodes, an adjacency list and an array of pokemon nodes. Output an int of the length of the shortest path.
	checkedNodes = []
	shortestPathLength = 1
	queue = []
	found = False
	while found == False:
		for node in queue:
			if node == node2:
				found = True
			else:
				checkedNodes.append(node)
		// At this point the whole list should have been run through. We need to make a new queue
		shortestPathLength = shortestPathLength + 1
		checkedNodes = checkedNodes + queue
		nextQueue = []
		for node in queue:
			for neighbour in adjList[node]:
				if neighbour not in queue AND not in checkedNodes:
					queue.append(neighbour)
	return shortestPathLength

####################################################################################################

// you can find the shortest distance to every pokemon using this algorithm:

####################################################################################################

int numberOfNodes;
int numberOfPokemon;

int pokemonNodeIndex[numberOfPokemon]; // records where the pokemon are on the graph
int distanceToPokemon[numberOfPokemon]; // will be filled with the shortest distance to each pokemon

vector<vector<int>> adjacencyList; 

void breadthFirstSearch(int startNode){ // ---------------------------------------------------------
	bool visited[numberOfNodes]; // records which nodes have already been visited (we do not want to visit a node more than once)
	int distance[numberOfNodes]; // the shortest distance away from the starting node for each of the nodes

	for(int i = 0; i < numberOfNodes; i++){ // clears any existing garbage data in the arrays + intializes the distance array
		visited[i] = false;
		distance[i] = INF;
	}

	queue<int> orderOfVisits; // queue will record which nodes we are going to visit and in which order

	orderOfVisits.push(startNode); // 
	visited[startNode] = true;     // some more initializations
	distance[startNode] = 0;       //

	while(!queue.empty()){ // the loop will continue to run until every node has been visited
		
		int front = orderOfVisits.front(); // removes the first element (which is a node index) of the queue and stores in variable
		orderOfVisits.pop();               //

		for(auto i = adjacencyList[front].begin(); i < adjacencyList[front].end(); i++){ // loops through the vector of a vector
			
			if(visited[*i] == false){ // if the node hasn't been visited, then update the distance

				distance[*i] = distance[front] + 1; // <- done here
				queue.push(*i); // we then want to check the nodes that are connected to the node we just checked

				for(int j = 0; j < numberOfPokemon; j++){ // loop through all the pokemon locations and check if any of them match

					if(*i == pokemonNodeIndex[j]){ // if one does match, store the shortest distance to that pokemon in a different location

						distanceToPokemon[*i] = distance[front] + 1; // <- here
					}

				}

			}

		}
		
	}

}

####################################################################################################




function heuristic(adjList, sIndex, pIndex):
	// Input an adjacency list, a student node and an array of pokemon nodes. Output an int.
	int value = 0
	for node in pIndex:
		value = value + 2**(10-shortestPath(node, sIndex))
	return value

function bestMove(adjList, sIndex, pIndex):
	// Input an adjacency list, a student node and an array of pokemon nodes. Output a int that signifies the best move.
	bestHeuristic = 0
	bestNode = 0
	for node in adjList[sIndex]:
		if heuristic(adjList, node, pIndex) > bestHeuristic:
			bestHeuristic = heuristic(adjList, node, pIndex) 
			bestNode = node
	return bestNode

*/

//Real C# Code Here

int numberOfNodes;
int numberOfPokemon;
const int maxn = 100; //This gives us a sufficiently large list to store stuffs.

int[] pokemonNodeIndex = new int[numberOfPokemon]; // records where the pokemon are on the graph
int[] distanceToPokemon = new int[numberOfPokemon]; // will be filled with the shortest distance to each pokemon
		
LinkedList<int>[] adjList = new LinkedList<int>[maxn]; //Initialise stuff!

for(int i = 0; i < adjList.Length; i++){ //Initialise even more stuff!
	adjList[i] = new LinkedList<int>();
}

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

	while(queue.Count != 0){ // the loop will continue to run until every node has been visited
		int front = orderOfVisits.Dequeue(); // removes the first element (which is a node index) of the queue and stores in variable

		foreach (int node in adjList[front]) {
			if(visited[node] == false){ // if the node hasn't been visited, then update the distance
				distance[node] = distance[front] + 1; // <- done here
				queue.Enqueue(node); // we then want to check the nodes that are connected to the node we just checked, so add em to the queue.

				for(int j = 0; j < numberOfPokemon; j++){ // loop through all the pokemon locations and check if any of them match
					if(node == pokemonNodeIndex[j]){ // if one does match, store the shortest distance to that pokemon in a different location
						distanceToPokemon[node] = distance[front] + 1; // <- here
					}
				}
			}
		}
	}
}