using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeManager : MonoBehaviour {

    public GameObject[] flowers;
    public bool win;
    public GameObject winScreen;
    public bool lose;
    public GameObject loseScreen;

	// Use this for initialization
	void Start () {
        flowers = GameObject.FindGameObjectsWithTag("Flower");
        win = false;
        lose = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (win) {
            if (!winScreen.activeSelf) {
                winScreen.SetActive(true);
            }
        }

        if(lose) {
            if (!loseScreen.activeSelf) {
                loseScreen.SetActive(true);
                StartCoroutine("WaitAndReload");
            }
        }
	}

    IEnumerator WaitAndReload() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
