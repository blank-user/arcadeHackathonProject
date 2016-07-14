using UnityEngine;
using System;

public class HighSchoolOnClick : MonoBehaviour {
    public void OnClick() {
        Invoke("Load", 0.5f);
    }
 
    private void Load() {
        Application.LoadLevel("highschoolSelect");
    }
}