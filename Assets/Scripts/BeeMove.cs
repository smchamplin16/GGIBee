using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BeeMove : MonoBehaviour {

	public Vector3 mousePos;
	public float speed;
	//public GameObject cam;
	//public GameObject background;
	//Renderer backgroundRenderer;
	//public int workerNum;
	//public List<GameObject> workerArr;
    Vector2 forwardVect;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		mousePos = new Vector3 (0, 0);
        rb = GetComponent<Rigidbody2D>();
		//backgroundRenderer = background.GetComponent<SpriteRenderer>();
		//workerArr = new List<GameObject> ();
		//workerNum = 0;
	}

	// Update is called once per frame
	void Update () {
        //mousePos = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f)) - transform.position;
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f)) - transform.position;
		transform.Translate (mousePos * Time.deltaTime * speed, Space.World);
		//transform.position = new Vector2(Mathf.Clamp(transform.position.x, -backgroundRenderer.bounds.extents.x, backgroundRenderer.bounds.extents.x), Mathf.Clamp(transform.position.y, -backgroundRenderer.bounds.extents.y, backgroundRenderer.bounds.extents.y));
		//cam.transform.Translate (mousePos * Time.deltaTime, Space.World);
		transform.rotation = Quaternion.LookRotation (transform.forward, mousePos);
	}

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Background") {
            foreach (ContactPoint2D contact in col.contacts) {
                rb.AddForce((contact.point - (Vector2)transform.position) * 100);
            }
        }
    }
}