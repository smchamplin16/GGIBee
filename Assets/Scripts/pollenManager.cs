using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pollenManager : MonoBehaviour {

    private List<GameObject> children; // all pollen selectors
    public List<string> allColors;
    private pollenSelect currentPollen;
    public GameObject Bee;
    public bool gotFlower;
    public string currentFlowerColor; // color of flower bee has most recently collected
    private bool rainbowMode;
    //public bool allPollenActivatedMode;
    public int polIndex;
    public MazeManager mazeManage;
    private flowerManager flowManage;

    // Use this for initialization

    void Awake() {
        flowManage = GameObject.Find("FlowerManager").GetComponent<flowerManager>();
        flowManage.enabled = false;
    }

    void Start () {
        gotFlower = false;
        polIndex = 0;
        Bee = GameObject.FindGameObjectWithTag("Bee");
        children = new List<GameObject>();
        allColors = new List<string>();
        mazeManage = Camera.main.GetComponent<MazeManager>();
        flowManage = GameObject.Find("FlowerManager").GetComponent<flowerManager>();

        foreach (Transform child in transform) {
            children.Add(child.gameObject);
            allColors.AddRange(child.GetComponent<pollenSelect>().currentChild.GetComponent<pollenGet>().colorsNeeded);
        }

        children[0].transform.GetChild(0).gameObject.SetActive(true);
        flowManage.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (gotFlower) {
            if (currentFlowerColor == "rainbow") {
                rainbowMode = true;
                PollenActivate(children[polIndex].GetComponent<pollenSelect>());
            } else if (children[polIndex].transform.GetChild(0).GetComponent<pollenGet>().colorsNeeded.Contains(currentFlowerColor)) {
                PollenActivate(children[polIndex].GetComponent<pollenSelect>());
            } else {
                mazeManage.lose = true; // lose condition
            }
            gotFlower = false;
        }
	}

    void PollenActivate(pollenSelect pol) {
        GameObject child = pol.gameObject.transform.GetChild(0).gameObject;
        if (rainbowMode || child.GetComponent<pollenGet>().colorsNeeded.Count == 1) {
            child.GetComponent<pollenGet>().collect = true;
            polIndex++;
            if (polIndex < children.Count) {
                children[polIndex].transform.GetChild(0).gameObject.SetActive(true);

                flowManage.colors = children[polIndex].transform.GetChild(0).GetComponent<pollenGet>().colorsNeeded;
            } else {
                mazeManage.win = true; // win condition
            }
        } else if (child.GetComponent<pollenGet>().colorsNeeded.Count == 2) {
            child.GetComponent<pollenGet>().colorsNeeded.Remove(currentFlowerColor);
            flowManage.colors.Remove(currentFlowerColor);
            child.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            pol.gameObject.transform.GetChild(0).transform.GetChild(0).parent = null;
            Destroy(pol.gameObject.transform.GetChild(0).gameObject);
            pol.currentChild = pol.children.Find(x => x.GetComponent<pollenGet>().color == child.GetComponent<pollenGet>().colorsNeeded[0]);
            GameObject newPol = GameObject.Instantiate(pol.currentChild, pol.transform);
            newPol.SetActive(true);
        }
    }
}
