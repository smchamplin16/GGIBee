using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pollenManager : MonoBehaviour {

    private List<GameObject> children;
    public List<string> allColors;
    private pollenSelect currentPollen;
    public GameObject Bee;
    public bool gotFlower;
    public string currentFlowerColor;

    // Use this for initialization

    void Start () {
        gotFlower = false;
        Bee = GameObject.FindGameObjectWithTag("Bee");
        children = new List<GameObject>();
        allColors = new List<string>();

        foreach (Transform child in transform) {
            children.Add(child.gameObject);
            Debug.Log(child.GetComponent<pollenSelect>().currentChild.GetComponent<pollenGet>().colorsNeeded);
            allColors.AddRange(child.GetComponent<pollenSelect>().currentChild.GetComponent<pollenGet>().colorsNeeded);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (gotFlower) {
            //currentPollen = children[currentPolIndex].GetComponent<pollenSelect>();
            if (allColors.Contains(currentFlowerColor)) {
                currentPollen = children.Find(x => x.GetComponent<pollenSelect>().currentChild.GetComponent<pollenGet>().colorsNeeded.Contains(currentFlowerColor)).GetComponent<pollenSelect>();
                allColors.Remove(currentFlowerColor);
                if(currentPollen.currentChild.GetComponent<pollenGet>().colorsNeeded.Count == 2) {
                    currentPollen.currentChild.GetComponent<pollenGet>().colorsNeeded.Remove(currentFlowerColor);
                    currentPollen.currentChild.GetComponent<ParticleSystem>().Play();
                    currentPollen.currentChild.SetActive(false);
                    currentPollen.currentChild = currentPollen.children.Find(x => x.GetComponent<pollenGet>().color == currentPollen.currentChild.GetComponent<pollenGet>().colorsNeeded[0]);
                    currentPollen.currentChild.SetActive(true); // NEED WHITE POLLEN
                } else if (currentPollen.currentChild.GetComponent<pollenGet>().colorsNeeded.Count == 1) {
                    currentPollen.currentChild.GetComponent<pollenGet>().collect = true;
                }

                gotFlower = false;
            } else {
                Debug.Log("lose");
                gotFlower = false;
            }
        }
        
	}
}
