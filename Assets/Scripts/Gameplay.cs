using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour {

    private bool newGame = true;

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

	// Use this for initialization
	void Start () {
        if (newGame) {
            Game.current = new Game();
            newGame = false;
            SaveLoad.Save();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
