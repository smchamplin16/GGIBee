using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class flowerGrowth : MonoBehaviour {

    public Sprite bloomed;
    public bool hasStem;
    public GameObject potIndex;
    private DateTime plantTime;
    private Game gameScript;

    void Awake() {
        plantTime = DateTime.Now; // this might run again after opening save file
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(DateTime.Now.CompareTo(plantTime.AddDays(1)) > 0) {

        }
	}
}
