using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeManager : MonoBehaviour {

    public GameObject[] flowers;
    public bool win;
    private bool hasWon;
    private bool hasLost;
    public GameObject winScreen;
    public bool lose;
    public GameObject loseScreen;
    public AudioClip winSound;
    public AudioClip loseSound;
    private AudioSource source;
    private GameObject bee;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        win = false;
        lose = false;
        hasWon = false;
        bee = GameObject.FindGameObjectWithTag("Bee");
	}
	
	// Update is called once per frame
	void Update () {
        if (win && !hasLost) {
            hasWon = true;
            if (!winScreen.activeSelf) {
                source.PlayOneShot(winSound);
                winScreen.SetActive(true);
                bee.GetComponent<BeeMove>().enabled = false;
                //StartCoroutine("WaitAndReset");
            }
        }

        if(lose && !hasWon) {
            hasLost = true;
            if (!loseScreen.activeSelf) {
                loseScreen.SetActive(true);
                bee.GetComponent<BeeMove>().enabled = false;
            }
        }
	}

    IEnumerator WaitAndReset() {
        bee.GetComponent<BeeMove>().enabled = false;
        yield return new WaitForSeconds(3);
        if (lose) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } /*else if (win) {
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1) {
                SceneManager.LoadScene("level_selectv2");
            } else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }*/
    }
}
