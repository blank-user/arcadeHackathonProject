using System;
using System.Collections.Generic;

public class Test
{
	public static void Main()
	{	// Helper Functions
		
		// My graph has 5 nodes (0-4) and 4 edges: (0,1),(0,2),(2,3),(1,2)
		LinkedList<int>[] adjList;
		
		adjList = new LinkedList<int>[10]; //Initialise stuff!
		
		for(int i = 0; i < adjList.Length; i++){ //Initialise even more stuff!
			adjList[i] = new LinkedList<int>();
		}
		
		adjList[0].AddFirst(1); //Put your edges in!
		adjList[0].AddFirst(2);
		adjList[1].AddFirst(0);
		adjList[1].AddFirst(2);
		adjList[2].AddFirst(0);
		adjList[2].AddFirst(1);
		adjList[2].AddFirst(3);
		adjList[3].AddFirst(2);
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
	}
}