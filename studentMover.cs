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