using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerSelect : MonoBehaviour {
    
    public List<GameObject> children;
    public GameObject currentChild;
    public bool randomize;

    void Awake() {
        children = new List<GameObject>();

        foreach (Transform child in transform) {
            children.Add(child.gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        if (randomize) {
            float x = Random.value;
            if(x < .01) {
                currentChild = children[children.Count -1];
            } else {
                currentChild = children[Random.Range(0, children.Count - 1)];
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
        if (!currentChild.activeSelf) {
            currentChild.SetActive(true);
        }
	}

    public void flowerReset() {
        currentChild.GetComponent<SpriteRenderer>().sprite = currentChild.GetComponent<flowerGet>().startSprite;
        currentChild.GetComponent<Animator>().enabled = false;
        currentChild.GetComponent<CircleCollider2D>().enabled = true;
        currentChild.SetActive(false);
        float x = Random.value;
        if (x < .01) {
            currentChild = children[children.Count-1];
        } else {
            currentChild = children[Random.Range(0, children.Count)];
        }
    }
}
