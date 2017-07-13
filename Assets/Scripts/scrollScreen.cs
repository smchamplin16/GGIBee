using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollScreen : MonoBehaviour {

    public float dragSpeed = 2;
    private Vector3 dragOrigin;

    public bool camDrag = true;

    public float outerLeft = -10f;
    public float outerRight = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        float left = Screen.width * 0.2f;
        float right = Screen.width - left;

        if(mousePosition.x < left) {
            camDrag = true;
        } else if (mousePosition.x > right) {
            camDrag = true;
        }

        if (camDrag) {
            if (Input.GetMouseButtonDown(0)) {
                dragOrigin = Input.mousePosition;
                return;
            }

            if (!Input.GetMouseButton(0)) {
                return;
            }

            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);

            transform.Translate(move, Space.World);

        }
	}
}
