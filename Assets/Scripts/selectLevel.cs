using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class selectLevel : MonoBehaviour {

    public string sceneName;

	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(() => TaskOnClick());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick() {
        if (this.gameObject.name == "Next") {
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1) {
                SceneManager.LoadScene("level_selectv2");
            }
            else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        } else if (this.gameObject.name == "Reset") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } else {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
        Time.timeScale = 1;
    }
}
