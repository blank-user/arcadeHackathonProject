using UnityEngine;
using System.Collections;

public class leveltwoOneOnClick : MonoBehaviour {
	public void OnClick() {
		Invoke("Load", 0.5f);
	}

	private void Load() {
		Application.LoadLevel("level(2-1)");
	}
}
