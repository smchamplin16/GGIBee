using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pollenSelect : MonoBehaviour {

    public List<GameObject> children;
    public GameObject currentChild;

    // Use this for initialization
    void Awake () {
        children = new List<GameObject>();

        foreach (Transform child in transform) {
            children.Add(child.gameObject);
        }

        if(currentChild == null) {
            currentChild = children[Random.Range(0, children.Count)];
        }

        currentChild.SetActive(true);
    }


    // Update is called once per frame
    void Update() {

    }
}
