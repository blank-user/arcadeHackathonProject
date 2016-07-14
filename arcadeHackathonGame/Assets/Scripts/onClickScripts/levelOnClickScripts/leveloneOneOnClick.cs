using UnityEngine;
using System.Collections;

public class leveloneOneOnClick : MonoBehaviour {
	public void OnClick() {
		Invoke("Load", 0.5f);
	}

	private void Load() {
		Application.LoadLevel("level(1-1)");
	}
}
