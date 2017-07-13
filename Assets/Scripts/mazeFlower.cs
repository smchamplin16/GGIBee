using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazeFlower : MonoBehaviour {

    public Sprite bud;
    Collider2D flowerCollider;
    public bool used;

    // Use this for initialization
    void Start () {
        flowerCollider = GetComponent<Collider2D>();
        used = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Bee" && !used) {
            flowerCollider.enabled = false;
            GetComponent<SpriteRenderer>().sprite = bud;
            used = true;

            GameObject[] flowerArr = Camera.main.GetComponent<MazeManager>().flowers;

            foreach (GameObject f in flowerArr) {
                if (!f.GetComponent<mazeFlower>().used) {
                    return;
                }
            }

            Camera.main.GetComponent<MazeManager>().win = true; // win if all flowers are used
        }
    }
}
