using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	private BoardManager boardScript;
	private AIController AIScript;

	public bool playersTurn = true; // this will be accessed by plankscript to determine if click trigger can go through.

	void Awake(){
		if (instance == null) {
			instance = this;
		}else if(instance != this){
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);

		boardScript = GetComponent<BoardManager> ();
		AIScript = GetComponent<AIController> ();

		InitGame ();
	}

	void InitGame(){
		boardScript.initialize ();
	}

	void Update(){
		if (playersTurn == true) {
			return;
		} else {
			
		}

	}









}
