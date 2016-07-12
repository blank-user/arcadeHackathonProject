using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

class adj{
	LinkedList<int>[] adjList;

	public adj(int nodes){
		adjList = new LinkedList<int>[nodes];

		for (int i = 0; i < adjList.Length; i++) {
			adjList [i] = new LinkedList<int> ();
		}
	}

}


public class BoardManager : MonoBehaviour {

	const int maxn = 100;

	public GameObject[] planks;
	public GameObject[] balls;
	public GameObject player;
	public GameObject[] candy;

	adj graph = new adj(maxn); //
	Dictionary<GameObject, KeyValuePair<int, int>> connections = new Dictionary<GameObject, KeyValuePair<int, int>>();
	Dictionary<int, GameObject> map = new Dictionary<int, GameObject>();

	void Start () {
		for (int i = 0; i < balls.Length; i++) {
			map.Add (i, balls [i]);
		}
	}

	void searchConnections(){
		for (int i = 0; i < planks.Length; i++) {
			//Vector3 pos = planks [i].transform.position;
			//Vector3 rot = planks [i].transform.rotation.eulerAngles;
			//Vector3 sca = planks [i].transform.localScale;
		}

	}

	// Update is called once per frame
	void Update () {
	
	}
}
