using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour {

    // Use this for initialization
    void Start () {
        GetComponent<Button>().onClick.AddListener(() => TaskOnClick());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick() { // go to level select
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
