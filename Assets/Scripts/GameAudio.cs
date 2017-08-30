using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAudio : MonoBehaviour {

    private static GameAudio instance = null;
    public static GameAudio Instance {
        get { return instance; }
    }
    public bool audioOn;

	// Use this for initialization
	void Awake () {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            audioOn = true;
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if(!audioOn && !AudioListener.pause) {
            AudioListener.pause = true;
        } else if (audioOn && AudioListener.pause) {
            AudioListener.pause = false;
        }
	}
}
