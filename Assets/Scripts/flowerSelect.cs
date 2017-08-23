using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerSelect : MonoBehaviour {
    
    public List<GameObject> children;
    public GameObject currentChild;
    public bool randomize;
    private bool isInstantiated;
    private GameObject bee;
    public bool touched;

	// Use this for initialization
	void Start () {
        bee = GameObject.FindGameObjectWithTag("Bee");
        isInstantiated = false;
        if (randomize) {
            float x = Random.value;
            if(x < .01f) {
                currentChild = children[children.Count -1];
            } else {
                currentChild = children[Random.Range(0, children.Count - 1)];
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
        if (!isInstantiated) {
            Instantiate(currentChild, this.transform);
            isInstantiated = true;
        }

        if(touched && !GetComponent<Collider2D>().IsTouching(bee.GetComponent<Collider2D>())){
            transform.GetChild(0).GetComponent<Collider2D>().enabled = true;
            touched = false;
        }
    }

    public void flowerReset() {
        //currentChild.GetComponent<SpriteRenderer>().sprite = currentChild.GetComponent<flowerGet>().startSprite;
        //currentChild.GetComponent<Animator>().enabled = false;
        //currentChild.GetComponent<CircleCollider2D>().enabled = true;
        //currentChild.SetActive(false);
        Destroy(transform.GetChild(0).gameObject);
        isInstantiated = false;
        float x = Random.value;
        if (x < .01f) {
            currentChild = children[children.Count-1];
        } else {
            currentChild = children[Random.Range(0, children.Count-1)];
        }
        if (GetComponent<Collider2D>().IsTouching(bee.GetComponent<Collider2D>())){
            currentChild.GetComponent<Collider2D>().enabled = false;
            touched = true;
        }
        currentChild.GetComponent<flowerGet>().newlyInstantiated = true;
    }
}
