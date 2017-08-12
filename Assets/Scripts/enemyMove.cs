using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Background") {
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 180);
        }
    }
}
