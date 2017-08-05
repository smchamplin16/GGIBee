using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class flowerManager : MonoBehaviour {

    public GameObject[] pollens;
    public List<string> colors;
    public List<GameObject> flowers;
    public bool timerMode;
    public float timeLeft;
    public float time;
    public GameObject timer;

	// Use this for initialization
	void Awake () {
        timeLeft = time;
        flowers = new List<GameObject>();

        foreach(Transform child in transform) {
            flowers.Add(child.gameObject);
        }
	}

    void Start() {
        if (timerMode) {
            timer.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = ((int)timeLeft).ToString();
            foreach(GameObject f in flowers) {
                f.GetComponent<flowerSelect>().randomize = true;
            }
        } else {
            pollens = GameObject.FindGameObjectsWithTag("Pollen");
            colors = new List<string>();

            foreach (GameObject pol in pollens) {
                colors.AddRange(pol.GetComponent<pollenGet>().colorsNeeded);
            }


            foreach (string col in colors) {
                GameObject flow = flowers[Random.Range(0, flowers.Count)];
                flowerSelect flowSelect = flow.GetComponent<flowerSelect>();
                flowSelect.currentChild = flowSelect.children.Find(x => x.GetComponent<flowerGet>().color == col);
                flowSelect.randomize = false;
                flowers.Remove(flow);
            }
        }

        foreach (GameObject f in flowers) {
            f.GetComponent<flowerSelect>().randomize = true;
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (timerMode) { 
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0) {
                timeLeft = time;
                foreach(GameObject f in flowers) {
                    f.GetComponent<flowerSelect>().flowerReset();
                }
            }
            timer.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = ((int)timeLeft).ToString();
        }
	}
}
