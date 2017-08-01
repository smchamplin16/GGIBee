using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pollenSelect : MonoBehaviour {

    private List<GameObject> children;
    private GameObject currentChild;
    public int polOrder;

    // Use this for initialization
    void Start () {
        children = new List<GameObject>();

        foreach (Transform child in transform) {
            children.Add(child.gameObject);
        }

        currentChild = children[Random.Range(0, children.Count)];
        currentChild.SetActive(true);


    }


    // Update is called once per frame
    void Update() {

    }
}
