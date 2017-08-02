using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pollenGet : MonoBehaviour {

    public string color;
    public List<string> colorsNeeded;
    public bool collect;
    private GameObject hive;

	// Use this for initialization
	void Start () {
        hive = GameObject.FindGameObjectWithTag("Hive");
	}
	
	// Update is called once per frame
	void Update () {
        if (collect) {
            gameObject.transform.Translate((hive.transform.position - transform.position) * Time.deltaTime, Space.World);
            colorsNeeded = new List<string>();
            transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        }
	}
}
