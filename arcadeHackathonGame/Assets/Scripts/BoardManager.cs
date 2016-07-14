using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {

	public GameObject[] edgeObjects;     //
	public GameObject[] nodeObjects;     //
	public GameObject[] pokemonObjects;  // import from Unity
	public GameObject startNodeObject;   //
	public GameObject playerObject;      //

	public Dictionary<GameObject, int> objectToIndex = new Dictionary<GameObject, int>(); // map from GameObject to int
	public Dictionary<int, GameObject> indexToObject = new Dictionary<int, GameObject>(); // and vise-versa

	public int playerPositionIndex; // access and change in GameManager when making a move
	public Adj graph;
	private int[] pokemonIndex;

	public bool gameContinue = true;

	public bool playerTurn = true;
	public bool studentTurn = false;

	void Awake(){

		initialize();

	}

	void Update(){

		if (graph.win (playerPositionIndex) == true && gameContinue == true) {
			gameContinue = false;

			if (Application.loadedLevelName == "level(4-2)") {
				Invoke ("LoadEnding", 1f);
			} else {
				Invoke ("LoadSuccess", 1f);
			}

		}

		if (gameContinue == false) {
			return;
		}

		if (graph.gameOver (playerPositionIndex) == true && gameContinue == true) {
			gameContinue = false;
			Invoke ("LoadFail", 1f);
		}

		if (playerTurn == true) {
			return;
		} else {
			if (studentTurn == true) {
				int nextMove = graph.bestMove (playerPositionIndex);

				StartCoroutine (MoveOverSpeed (playerObject, indexToObject[nextMove].transform.position, 5f));

				playerPositionIndex = nextMove;
			}
		}
	}

	private void LoadEnding(){
		Application.LoadLevel ("levelSuccessEnding");
	}

	private void LoadFail(){
		Application.LoadLevel("levelFail");
	}

	private void LoadSuccess(){
		Application.LoadLevel("levelSuccess");
	}

	public IEnumerator MoveOverSpeed (GameObject objectToMove, Vector3 end, float speed){
		// speed should be 1 unit per second

		studentTurn = false;

		while (objectToMove.transform.position != end)
		{
			objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
			yield return new WaitForEndOfFrame ();
		}

		playerTurn = true;

	}

	public IEnumerator MoveOverSeconds (GameObject objectToMove, Vector3 end, float seconds)
	{
		float elapsedTime = 0;
		Vector3 startingPos = objectToMove.transform.position;
		while (elapsedTime < seconds)
		{
			objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		objectToMove.transform.position = end;

		playerTurn = true;
	}

	public void initialize(){ 

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

		playerObject.transform.position = startNodeObject.transform.position;

		graph = new Adj (nodeObjects.Length, pokemonObjects.Length, pokemonIndex);

		boardSetup ();

		//graph.printGraph ();
	}

	private void boardSetup(){ // creation of the adjList

		for (int i = 0; i < edgeObjects.Length; i++) {
			GameObject[] links = new GameObject[2];
			links = closestNode (edgeObjects [i]);

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

	public GameObject[] closestNode(GameObject edge) {
		GameObject[] endNodes = new GameObject[2]; // We're going to put our results here.
		Vector3 endpoint1 = endPoints(edge)[0];
		Vector3 endpoint2 = endPoints(edge)[1];

		// Find the closest node to one endpoint
		float minDistance1 = 10000.0f; //Something sufficiently large
		GameObject closestNode1 = null;
		foreach (GameObject node in nodeObjects) {
			if (Vector3.Distance(endpoint1, node.transform.position) < minDistance1) { //Check if it's closer
				minDistance1 = Vector3.Distance(endpoint1, node.transform.localPosition);
				closestNode1 = node;
			}
		}

		endNodes[0] = closestNode1;

		//Find the closest node to the second endpoint
		float minDistance2 = 10000.0f;
		GameObject closestNode2 = null;
		foreach (GameObject node in nodeObjects) {
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