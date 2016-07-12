using UnityEngine;
using System.Collections;
using System;

public class closestNode : MonoBehaviour {

	public Vector3[] endpoints(GameObject edge) {
		// Input: An edge
		// Output: Returns the endpoints of the edge as a list of Vector3's
		float rotation = edge.transform.eulerAngles.z; //This is how much the edge is rotated (wrt to the )
		float centerX = edge.transform.localPosition.x;
		float centerY = edge.transform.localPosition.y;
		float scaleX = edge.transform.localScale.x; //I'm not sure which one is height (I'm guessing y) and which one is length (I'm guessing x)
		float scaleY = edge.transform.localScale.y;

		if (scaleX > scaleY) { //If the length is the longest one
			float newX1 = centerX + scaleX * Math.Cos(rotation) / 2;
			float newY1 = centerY + scaleX * Math.Sin(rotation) / 2;
			float newX2 = centerX - scaleX * Math.Cos(rotation) / 2;
			float newY2 = centerY - scaleX * Math.Sin(rotation) / 2;			
		}

		if (scaleY > scaleX) { //If the width is the longest one though I think this might never happen?
			float newX1 = centerX + scaleY * Math.Sin(rotation) / 2;
			float newY1 = centerY - scaleY * Math.Cos(rotation) / 2;
			float newX2 = centerX - scaleY * Math.Sin(rotation) / 2;
			float newY2 = centerY + scaleY * Math.Cos(rotation) / 2;
		}

		Vector3[] endpointList;
		Vector3 firstEndPoint = new Vector3(newX1, newY1, float 0.0); //We're going to put our results here. // Are you meant to go "float 0.0" or just "0.0" ?
		Vector3 secondEndPoint = new Vector3(newX2, newY2, float 0.0); 
		return endpointList;
	}

	public GameObject[] closestNode(GameObject edge, GameObject[] nodeList) {
		// Input: An edge
		// Output: Two nodes in a list
		GameObject[] endNodes = new GameObject[2]; //We're going to put our results here.
		Vector3 endpoint1 = endpoints(GameObject edge)[0];
		Vector3 endpoint2 = endpoints(GameObject edge)[1];

		// Find the closest node to one endpoint
		float minDistance1 = 10000.0; //Something sufficiently large
		GameObject closestNode1;
		foreach (node in nodeList) {
			if (Vector3.distance(endpoint1, node.transform.position) < minDistance1) { //Check if it's closer
				minDistance1 = Vector3.distance(endpoint1, node.transform.localPosition);
				closestNode1 = node;
			}
		}

		endNodes[0] = closestNode1;

		//Find the closest node to the second endpoint
		float minDistance2 = 10000.0;
		GameObject closestNode2;
		foreach (node in nodeList) {
			if (Vector3.distance(endpoint1, node.transform.position) < minDistance2) {
				minDistance2 = Vector3.distance(endpoint2, node.transform.localPosition);
				closestNode2 = node;
			}
		}

		endNodes[1] = closestNode2;

		// Return the endNodes
		return endNodes;
	}

	public GameObject[] main() {
		// Input: ???
		// Output: ???
		GameObject[] nodeList = ; // From Unity
		GameObject[] edgeList = ; // From Unity
		GameObject[] resultYouWant = closestNode(edge, nodeList); //I guess iterate this over all the edges to make your adjacency list? -------------------------------
		return resultYouWant;
	}
}