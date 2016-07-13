using UnityEngine;
using System.Collections;

public class PlankScript : MonoBehaviour {

	private BoardManager boardScript;

	void Awake(){
		boardScript = GameObject.Find ("BoardManager").GetComponent<BoardManager> ();
	}

	void OnMouseDown(){

		if (boardScript.playerTurn == true && boardScript.gameContinue == true) {
			gameObject.SetActive (false);
			GameObject[] closeNodes = new GameObject[2];
			closeNodes = boardScript.closestNode (gameObject);

			int index1 = boardScript.objectToIndex [closeNodes [0]];
			int index2 = boardScript.objectToIndex [closeNodes [1]];

			boardScript.graph.adjList [index1].Remove (index2);
			boardScript.graph.adjList [index2].Remove (index1);

			//boardScript.graph.printGraph ();

			boardScript.playerTurn = false;
		}
	}

}
