using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDestroy : MonoBehaviour {

    public GameObject[] flowersForDestruction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject f in flowersForDestruction) {
            if (!f.GetComponent<mazeFlower>().used) {
                return;
            }
        }

        Destroy(this);
	}
}
