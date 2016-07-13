using UnityEngine;
using System.Collections;

public class studentController : MonoBehaviour {

	public GameObject startNodeObject;
	public GameObject endNodeObject;

	// Makes student move along the edge!
	public void moveStudent(int startNode, int endNode) {
		//Input: two ints of the nodes that we are moving along
		//Output: None. See Student avatar move from one node to the other.
		GameObject startNodeObject = getNode(startNode);
		GameObject endNodeObject = getNode(endNode);

		Vector3 startNodePosition = startNodeObject.transform.position;
		Vector3 endNodePosition = endNodeObject.transform.position;
		Vector3 displacementVector = endNodePosition - startNodePosition;

		float distance = displacementVector.magnitude;

		float translation = distance * Time.deltaTime // Moves the whole thing in 1 second.
		Vector3 newVector = translation * displacementVector;
		transform.Translate(newVector); 
	}
}