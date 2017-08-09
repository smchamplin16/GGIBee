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
    public AudioClip winSound;
    public AudioClip loseSound;
    private AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        flowers = GameObject.FindGameObjectsWithTag("Flower");
        win = false;
        lose = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (win) {
            if (!winScreen.activeSelf) {
                source.PlayOneShot(winSound);
                winScreen.SetActive(true);
                StartCoroutine("WaitAndReset");
            }
        }

        if(lose) {
            if (!loseScreen.activeSelf) {
                loseScreen.SetActive(true);
                StartCoroutine("WaitAndReset");
            }
        }
	}

    IEnumerator WaitAndReset() {
        yield return new WaitForSeconds(3);
        if (lose) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else if (win) {
            SceneManager.LoadScene("level_selectv2");
        }
    }
}
