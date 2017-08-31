﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pollenSelect : MonoBehaviour {

    public List<GameObject> children;
    public GameObject currentChild;

    // Use this for initialization
    void Awake () {
        if(currentChild == null) {
            currentChild = children[Random.Range(0, children.Count)];
        }

        Instantiate(currentChild, this.transform);
    }


    // Update is called once per frame
    void Update() {

    }
}
