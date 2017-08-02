using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Gameplay : MonoBehaviour {

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

	// Use this for initialization
	void Start () {
        if (!File.Exists(Application.persistentDataPath + "/savegame.gd")) {
            Game.current = new Game();
            SaveLoad.Save();
        } else {
            SaveLoad.Load();
            Game.current = SaveLoad.saveGame;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
