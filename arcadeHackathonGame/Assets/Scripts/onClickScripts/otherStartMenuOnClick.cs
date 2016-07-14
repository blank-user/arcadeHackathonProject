using UnityEngine;
using System.Collections;

public class otherStartMenuOnClick : MonoBehaviour {
	public void OnClick() {
		Invoke("Load", 0.5f);
	}

	private void Load() {
		Application.LoadLevel("otherStartMenu");
	}
}
