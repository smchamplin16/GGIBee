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
    public bool allPollenActivatedMode;
    public int polIndex;

    // Use this for initialization

    void Start () {
        gotFlower = false;
        polIndex = 0;
        Bee = GameObject.FindGameObjectWithTag("Bee");
        children = new List<GameObject>();
        allColors = new List<string>();

        foreach (Transform child in transform) {
            children.Add(child.gameObject);
            allColors.AddRange(child.GetComponent<pollenSelect>().currentChild.GetComponent<pollenGet>().colorsNeeded);
            if (!allPollenActivatedMode) {
                child.GetComponent<pollenSelect>().currentChild.GetComponent<Animator>().enabled = false;
            }
        }
        if (!allPollenActivatedMode) {
            children[0].GetComponent<pollenSelect>().currentChild.GetComponent<Animator>().enabled = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (gotFlower) {
            //currentPollen = children[currentPolIndex].GetComponent<pollenSelect>();

            if (allPollenActivatedMode) {
                if (allColors.Contains(currentFlowerColor)) {
                    currentPollen = children.Find(x => x.GetComponent<pollenSelect>().currentChild.GetComponent<pollenGet>().colorsNeeded.Contains(currentFlowerColor)).GetComponent<pollenSelect>();
                    allColors.Remove(currentFlowerColor);
                    PollenActivate(currentPollen);
                }
                else {
                    Debug.Log("lose");
                }
            } else {
                if (children[polIndex].GetComponent<pollenSelect>().currentChild.GetComponent<pollenGet>().colorsNeeded.Contains(currentFlowerColor)) {
                    PollenActivate(children[polIndex].GetComponent<pollenSelect>());
                } else {
                    Debug.Log("lose");
                }
            }
            gotFlower = false;
        }
	}

    void PollenActivate(pollenSelect pol) {
        if (pol.currentChild.GetComponent<pollenGet>().colorsNeeded.Count == 2) {
            pol.currentChild.GetComponent<pollenGet>().colorsNeeded.Remove(currentFlowerColor);
            pol.currentChild.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            pol.currentChild.transform.GetChild(0).parent = null;
            pol.currentChild.SetActive(false);
            pol.currentChild = pol.children.Find(x => x.GetComponent<pollenGet>().color == pol.currentChild.GetComponent<pollenGet>().colorsNeeded[0]);
            pol.currentChild.SetActive(true);
        }
        else if (pol.currentChild.GetComponent<pollenGet>().colorsNeeded.Count == 1) {
            pol.currentChild.GetComponent<pollenGet>().collect = true;
            if (!allPollenActivatedMode) {
                polIndex++;
            }
        }
    }
}
