using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class potNumber : MonoBehaviour {

    public int potIndex;
    public GameObject flowerToPlant;
    public bool hasFlower;

	// Use this for initialization
	void Start () {
        if (hasFlower) {
            Instantiate(flowerToPlant, new Vector2(transform.position.x, transform.position.y + 2), transform.rotation);
        }
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnMouseDown() { // plant flower in clicked pot
        if (!hasFlower) {
            flowerToPlant = Instantiate(flowerToPlant, new Vector2(transform.position.x, transform.position.y + 2), transform.rotation);
            flowerToPlant.GetComponent<flowerGrowth>().potIndex = gameObject;
            hasFlower = true;
            Game.current.flowers.Add(flowerToPlant);
            SaveLoad.Save();
        }
    }
}
