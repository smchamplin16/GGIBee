using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pollenManager : MonoBehaviour {

    private int currentPolIndex;
    private List<GameObject> children;

    // Use this for initialization
    void Start () {
        currentPolIndex = 0;
        children = new List<GameObject>();

        foreach (Transform child in transform) {
            children.Add(child.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
