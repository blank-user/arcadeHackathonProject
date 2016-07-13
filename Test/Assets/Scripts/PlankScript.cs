using UnityEngine;
using System.Collections;

public class PlankScript : MonoBehaviour {

	private BoardManager boardScript;

	void Awake(){
		boardScript = GameObject.Find ("BoardManager").GetComponent<BoardManager> ();
	}

	void OnMouseDown(){
		gameObject.SetActive (false);
	}

}
