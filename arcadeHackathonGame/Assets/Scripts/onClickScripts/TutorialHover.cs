using UnityEngine;
using System;

public class TutorialHover : MonoBehaviour {

	void Awake(){
		gameObject.SetActive (false);
	}

	public void showTutorial(){
		gameObject.SetActive (true);
	}

	public void hideTutorial(){
		gameObject.SetActive (false);
	}

}