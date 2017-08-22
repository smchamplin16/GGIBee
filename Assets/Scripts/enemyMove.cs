using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour {

    public float speed;
    private float startAngle;

	// Use this for initialization
	void Start () {
        startAngle = transform.eulerAngles.z;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Background") {
            transform.eulerAngles = new Vector3(0, 0, startAngle + 180);
            startAngle = transform.eulerAngles.z;
        } else if (col.gameObject.tag == "Bee") {
            Camera.main.GetComponent<MazeManager>().lose = true;
        }
    }
}
