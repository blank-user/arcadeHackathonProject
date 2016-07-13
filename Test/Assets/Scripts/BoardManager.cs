using UnityEngine;
using System;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {

	public GameObject[] edgeObjects;     //
	public GameObject[] nodeObjects;     //
	public GameObject[] pokemonObjects;  // import from Unity
	public GameObject startNodeObject;   //
	public GameObject playerObject;          //
	public GameObject player;

	private Dictionary<GameObject, int> objectToIndex = new Dictionary<GameObject, int>(); // map from GameObject to int
	private Dictionary<int, GameObject> indexToObject = new Dictionary<int, GameObject>(); // and vise-versa

	public int playerPositionIndex;
	private Adj graph;
	private int[] pokemonIndex;

	void Awake(){
		initialize();
	}

	public void initialize(){ // initialization of 

		pokemonIndex = new int[pokemonObjects.Length];

		int numPokemon = 0;

		for (int indexCounter = 0; indexCounter < nodeObjects.Length; indexCounter++) {
			if (nodeObjects [indexCounter].tag == "Pokemon") {
				pokemonIndex [numPokemon] = indexCounter;
				numPokemon++;
			}
			if (nodeObjects [indexCounter].tag == "Start") {
				playerPositionIndex = indexCounter;
			}

			objectToIndex.Add (nodeObjects [indexCounter], indexCounter);
			indexToObject.Add (indexCounter, nodeObjects [indexCounter]);
		}

		player = (GameObject)Instantiate (playerObject, startNodeObject.transform.position, Quaternion.identity);

		graph = new Adj (nodeObjects.Length, pokemonObjects.Length, pokemonIndex);
		boardSetup ();

		graph.printGraph ();
	}

	private void boardSetup(){ // creation of the adjList

		for (int i = 0; i < edgeObjects.Length; i++) {
			GameObject[] links = new GameObject[2];
			links = closestNode (edgeObjects [i], nodeObjects);

			graph.adjList [objectToIndex [links [0]]].AddLast (objectToIndex [links [1]]);
			graph.adjList [objectToIndex [links [1]]].AddLast (objectToIndex [links [0]]);

		}

	}

	private Vector3[] endPoints(GameObject edge){
		float rotation = edge.transform.eulerAngles.z;
		float centerX = edge.transform.localPosition.x;
		float centerY = edge.transform.localPosition.y;
		float scaleX = edge.transform.localScale.x;

		rotation = rotation * (float)Math.PI / 180;

		BoxCollider2D col = edge.GetComponent<BoxCollider2D>();
		float sizeX = col.size.x;

		float newX1 = centerX - sizeX * scaleX * (float)Math.Cos(rotation) / 2;
		float newY1 = centerY - sizeX * scaleX * (float)Math.Sin(rotation) / 2;	

		float newX2 = centerX + sizeX * scaleX * (float)Math.Cos(rotation) / 2;
		float newY2 = centerY + sizeX * scaleX * (float)Math.Sin(rotation) / 2;

		Vector3 firstEndPoint = new Vector3(newX1, newY1, 0.0f);
		Vector3 secondEndPoint = new Vector3 (newX2, newY2, 0.0f);

		Vector3[] endPointList = new Vector3[] { firstEndPoint, secondEndPoint };

		return endPointList;
	}

	public GameObject[] closestNode(GameObject edge, GameObject[] nodeList) {
		GameObject[] endNodes = new GameObject[2]; // We're going to put our results here.
		Vector3 endpoint1 = endPoints(edge)[0];
		Vector3 endpoint2 = endPoints(edge)[1];

		// Find the closest node to one endpoint
		float minDistance1 = 10000.0f; //Something sufficiently large
		GameObject closestNode1 = null;
		foreach (GameObject node in nodeList) {
			if (Vector3.Distance(endpoint1, node.transform.position) < minDistance1) { //Check if it's closer
				minDistance1 = Vector3.Distance(endpoint1, node.transform.localPosition);
				closestNode1 = node;
			}
		}

		endNodes[0] = closestNode1;

		//Find the closest node to the second endpoint
		float minDistance2 = 10000.0f;
		GameObject closestNode2 = null;
		foreach (GameObject node in nodeList) {
			if (Vector3.Distance(endpoint2, node.transform.position) < minDistance2) {
				minDistance2 = Vector3.Distance(endpoint2, node.transform.localPosition);
				closestNode2 = node;
			}
		}

		endNodes[1] = closestNode2;

		// Return the endNodes
		return endNodes;
	}

}