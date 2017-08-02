using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerManager : MonoBehaviour {

    public GameObject[] pollens;
    public List<string> colors;
    public List<GameObject> flowers;
    public bool timerMode;

	// Use this for initialization
	void Awake () {
        
        flowers = new List<GameObject>();

        foreach(Transform child in transform) {
            flowers.Add(child.gameObject);
        }
	}

    void Start() {
        pollens = GameObject.FindGameObjectsWithTag("Pollen");
        colors = new List<string>();

        foreach (GameObject pol in pollens) {
            colors.AddRange(pol.GetComponent<pollenGet>().colorsNeeded);
        }


        foreach (string col in colors) {
            Debug.Log(col);
            GameObject flow = flowers[Random.Range(0, flowers.Count)];
            Debug.Log(flow.name);
            flowerSelect flowSelect = flow.GetComponent<flowerSelect>();
            flowSelect.currentChild = flowSelect.children.Find(x => x.GetComponent<flowerGet>().color == col);
            flowSelect.randomize = false;
            flowers.Remove(flow);
        }

        foreach (GameObject f in flowers) {
            f.GetComponent<flowerSelect>().randomize = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
