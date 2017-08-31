﻿using System.Collections;
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
    public bool resetTime;

    // Use this for initialization
    void Awake() {
        resetTime = false;
        timeLeft = time;
        flowers = new List<GameObject>();

        foreach (Transform child in transform) {
            flowers.Add(child.gameObject);
        }

        foreach (GameObject f in flowers) {
            f.GetComponent<flowerSelect>().randomize = true;
        }
    }

    void Start() {
        pollens = GameObject.FindGameObjectsWithTag("Pollen");
        colors = new List<string>();
        if (timerMode) {
            foreach (GameObject f in flowers) {
                f.GetComponent<flowerSelect>().randomize = true;
            }
            timer.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = (timeLeft - 1).ToString();
            colors.AddRange(pollens[0].GetComponent<pollenGet>().colorsNeeded);
            flowerSelect randFlower = flowers[Random.Range(0, flowers.Count)].GetComponent<flowerSelect>();
            randFlower.randomize = false;
            string randColor = colors[Random.Range(0, colors.Count)];
            randFlower.currentChild = randFlower.GetComponent<flowerSelect>().children.Find(x => x.GetComponent<flowerGet>().color == randColor);
            
        } else {
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

            foreach (GameObject f in flowers) {
                f.GetComponent<flowerSelect>().randomize = true;
            }
        }

        

    }
	
	// Update is called once per frame
	void Update () {
        if (timerMode) {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0 || resetTime) {
                timeLeft = time;
                foreach (GameObject f in flowers) {
                    f.GetComponent<flowerSelect>().randomize = true;
                }
                flowerSelect randFlower = flowers[Random.Range(0, flowers.Count)].GetComponent<flowerSelect>();
                randFlower.randomize = false;
                string randColor = colors[Random.Range(0, colors.Count)];
                randFlower.currentChild = randFlower.GetComponent<flowerSelect>().children.Find(x => x.GetComponent<flowerGet>().color == randColor);
                foreach (GameObject f in flowers) {
                    f.GetComponent<flowerSelect>().flowerReset();
                }
                resetTime = false;
            }
            if(timeLeft != time) {
                timer.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = ((int)timeLeft).ToString();
            }
            
        }
	}
}
