﻿using UnityEngine;
using System.Collections;

public class leveloneTwoOnClick : MonoBehaviour {
	public void OnClick() {
		Invoke("Load", 0.5f);
	}

	private void Load() {
		Application.LoadLevel("level(1-2)");
	}
}