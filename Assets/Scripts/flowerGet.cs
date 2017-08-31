using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerGet : MonoBehaviour {

    public string color;
    public bool newlyInstantiated;
    public Sprite startSprite;
    private Collider2D coll;
    public bool touched;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Bee") {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Animator>().enabled = true;
        }
    }
}
