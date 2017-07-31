using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerSelect : MonoBehaviour {
    
    private List<GameObject> children;

	// Use this for initialization
	void Start () {
        children = new List<GameObject>();

		foreach(Transform child in transform) {
            children.Add(child.gameObject);
        }
        
        children[Random.Range(0, children.Count)].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
