using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BeeMove : MonoBehaviour {

	public Vector3 mousePos;
	public float speed;
    Vector2 forwardVect;
    Rigidbody2D rb;
    public string flowerColor;
    public pollenManager polManage;
    private AudioSource source;
    public AudioClip flowerGet;
    public AudioClip wallHit;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        polManage = GameObject.FindGameObjectWithTag("PollenManager").GetComponent<pollenManager>();
		mousePos = new Vector3 (0, 0);
        rb = GetComponent<Rigidbody2D>();

	}

	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButton(0)) {
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f)) - transform.position;
            transform.Translate(mousePos * Time.deltaTime * speed, Space.World);
            transform.rotation = Quaternion.LookRotation(transform.forward, mousePos);
        }
	}

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Background") {
            foreach (ContactPoint2D contact in col.contacts) {
                rb.AddForce(((Vector2)transform.position - contact.point) * 30, ForceMode2D.Impulse);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Flower") {
            source.PlayOneShot(flowerGet);
            flowerColor = other.gameObject.GetComponent<flowerGet>().color;
            polManage.gotFlower = true;
            polManage.currentFlowerColor = flowerColor;
        }
    }
}