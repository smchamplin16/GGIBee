using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollScreen : MonoBehaviour {

    public float dragSpeed = 2;
    private Vector3 dragOrigin;
    Renderer backgroundRenderer;
    public bool camDrag = true;
    public bool camUp = true;
    public bool camDown = true;
    public bool camRight = true;
    public bool camLeft = true;

    float maxX; // right edge
    float maxY; // top edge
    float minX; // left edge
    float minY; // bottom edge

    // Use this for initialization
    void Start () {
        backgroundRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(backgroundRenderer.bounds.center);

        maxX = Camera.main.WorldToScreenPoint(backgroundRenderer.bounds.max).x;//Camera.main.WorldToScreenPoint(transform.position).x + backgroundRenderer.bounds.extents.x;
        maxY = Camera.main.WorldToScreenPoint(backgroundRenderer.bounds.max).y;//transform.position.y + backgroundRenderer.bounds.extents.y;
        minX = Camera.main.WorldToScreenPoint(backgroundRenderer.bounds.min).x;//transform.position.x - backgroundRenderer.bounds.extents.x;
        minY = Camera.main.WorldToScreenPoint(backgroundRenderer.bounds.min).y;//transform.position.y - backgroundRenderer.bounds.extents.y;

        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        float left = 0.2f;
        float right = Screen.width - 0.2f;
        float top = Screen.height - 0.2f;
        float bottom = 0.2f;

        if (maxX > right && minX < left && maxY > top && minY < bottom) {
            camDrag = true;
        } else {
            if (maxX <= right) {
                camRight = false;
            }
            if (maxY <= top) {
                camUp = false;
            }
            if (minX >= left) {
                camLeft = false;
            }
            if (minY >= bottom) {
                camDown = false;
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

            if (!camUp || !camDown) {
                move = new Vector3(pos.x * dragSpeed, 0, 0);
            }

            if (!camLeft || !camRight) {
                move = new Vector3(0, pos.y * dragSpeed, 0);
            }
            
            transform.Translate(move, Space.World);

        }
	}
}
