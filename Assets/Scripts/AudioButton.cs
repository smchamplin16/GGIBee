using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour {

    public GameObject gameAudio;
    private GameAudio audioScript;
    public GameObject currentText;
    public GameObject offText;
    public GameObject onText;

	// Use this for initialization
	void Start () {
        gameAudio = GameObject.FindGameObjectWithTag("GameAudio");
        audioScript = gameAudio.GetComponent<GameAudio>();
        GetComponent<Button>().onClick.AddListener(() => TaskOnClick());
        if (audioScript.audioOn) {
            onText.SetActive(true);
        }
        else if (!audioScript.audioOn) {
            offText.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {

    }

    void TaskOnClick() {
        if (audioScript.audioOn) {
            audioScript.audioOn = false;
            onText.SetActive(false);
            offText.SetActive(true);
        } else {
            audioScript.audioOn = true;
            offText.SetActive(false);
            onText.SetActive(true);
        }
    }
}
