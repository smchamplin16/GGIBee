using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerGet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D() {
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Animator>().enabled = true;
    }
}
