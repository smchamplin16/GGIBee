using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour {

    public GameObject[] flowers;
    public bool win;
    public bool lose;

	// Use this for initialization
	void Start () {
        flowers = GameObject.FindGameObjectsWithTag("Flower");
        win = false;
        lose = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (win) {
            Debug.Log("WIN");
        }
	}
}
