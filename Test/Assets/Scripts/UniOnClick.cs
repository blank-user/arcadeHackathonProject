using UnityEngine;
using System;

public class UniOnClick : MonoBehaviour {
    public void OnClick() {
        Invoke("Load", 0.5f);
    }
 
    private void Load() {
        Application.LoadLevel("uniSelect");
    }
}