using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollScreen : MonoBehaviour {

    public float dragSpeed = 1;
    private Vector3 dragOrigin;
    Renderer backgroundRenderer;
    public bool camDrag = true;
    public bool camUp = true;
    public bool camDown = true;
    public bool camRight = true;
    public bool camLeft = true;

    float left;
    float right;
    float top;
    float bottom;

    float maxX; // right edge
    float maxY; // top edge
    float minX; // left edge
    float minY; // bottom edge

    // Use this for initialization
    void Start () {
        backgroundRenderer = GetComponent<SpriteRenderer>();

        left = -5f;
        right = Screen.width + 5f;
        top = Screen.height + 5f;
        bottom = -5f;
    }
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(backgroundRenderer.bounds.center);

        maxX = Camera.main.WorldToScreenPoint(backgroundRenderer.bounds.max).x;
        maxY = Camera.main.WorldToScreenPoint(backgroundRenderer.bounds.max).y;
        minX = Camera.main.WorldToScreenPoint(backgroundRenderer.bounds.min).x;
        minY = Camera.main.WorldToScreenPoint(backgroundRenderer.bounds.min).y;

        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        if (maxX > right && minX < left && maxY > top && minY < bottom) {
            camDrag = true;
        } else {
            if (maxX <= right) {
                camRight = false;
            } else {
                camRight = true;
            }
            if (maxY <= top) {
                camUp = false;
            } else {
                camUp = true;
            }
            if (minX >= left) {
                camLeft = false;
            } else {
                camLeft = true;
            }
            if (minY >= bottom) {
                camDown = false;
            } else {
                camDown = true;
            }
        }
        
        //else if (mousePosition.x > right) {
            //camDrag = true;
        //}

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

            if (!camUp) {
                if(move.y < 0f) {
                    move = new Vector3(move.x, 0, 0);
                }
                
            }
            if (!camDown) {
                if(move.y > 0f) {
                    move = new Vector3(move.x, 0, 0);
                }
            }

            if (!camLeft) {
                if(move.x > 0f) {
                    move = new Vector3(0, move.y, 0);
                }
            }
            if (!camRight) {
                if(move.x < 0f) {
                    move = new Vector3(0, move.y, 0);
                }
            }
            
            transform.Translate(move, Space.World);

        }
	}
}
