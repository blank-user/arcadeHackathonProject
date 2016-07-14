using UnityEngine;
using System.Collections;

public class studentMover : MonoBehaviour {
	// Makes student move along the edge!

	private BoardManager boardScript;

	void Awake() {
		boardScript = GameObject.Find("BoardManager").GetComponent<BoardManager>();
	}

	public void moveStudent(int startNode, int endNode) {
		//Input: two ints of the nodes that we are moving along
		//Output: None. See Student avatar move from one node to the other.
		GameObject startNodeObject = boardScript.nodeObjects[startNode];
		GameObject endNodeObject = boardScript.nodeObjects[endNode];

		Vector3 startNodePosition = startNodeObject.transform.position;
		Vector3 endNodePosition = endNodeObject.transform.position;
		Vector3 displacementVector = endNodePosition - startNodePosition;

		float distance = displacementVector.magnitude;

		while (boardScript.playerObject.transform.position != endNodePosition) {
			float translation = distance * Time.deltaTime; // Moves the whole thing in 1 second.
			boardScript.playerObject.transform.position = Vector3.MoveTowards(boardScript.playerObject.transform.position, endNodePosition, translation); 			
		}
	}
}