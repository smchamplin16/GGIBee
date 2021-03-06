﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pollenGet : MonoBehaviour {

    public string color;
    public List<string> colorsNeeded;
    public bool collect;
    private GameObject hive;
    private bool particleActivate; // to activate particle system

	// Use this for initialization
	void Start () {
        hive = GameObject.FindGameObjectWithTag("Hive");
        particleActivate = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (collect) {
            gameObject.transform.Translate((hive.transform.position - transform.position) * Time.deltaTime, Space.World);
            colorsNeeded = new List<string>();
            if (particleActivate) {
                transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                transform.GetChild(0).parent = null;
                particleActivate = false;
            }
        }
        
        if (Vector2.Distance(transform.position, hive.transform.position) <= 0.1) {
            Destroy(transform.parent.gameObject);
        }
    }
}
