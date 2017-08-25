using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetButton : MonoBehaviour {
    private GameObject bee;
    private GameObject flowerManager;

	// Use this for initialization
	void Start () {
        flowerManager = GameObject.Find("FlowerManager");
        GetComponent<Button>().onClick.AddListener(() => TaskOnClick());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick() {
        flowerManager.GetComponent<flowerManager>().resetTime = true;
    }
}
