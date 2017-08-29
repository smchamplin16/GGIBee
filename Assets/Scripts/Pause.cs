using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
        Time.timeScale = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnDisable() {
        Time.timeScale = 1;
    }
}
