using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potNumber : MonoBehaviour {

    public int potIndex;
    public GameObject flowerToPlant;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown() { // plant flower in clicked pot
        Debug.Log("pot clicked");
        Instantiate(flowerToPlant,transform);
    }
}
