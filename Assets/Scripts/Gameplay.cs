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
            for(int i = 0; i < Game.current.flowers.Count; i++) {
                GameObject currentFlower = Game.current.flowers[i];
                flowerGrowth flowerScript = currentFlower.GetComponent<flowerGrowth>();
                Instantiate(currentFlower, new Vector2(flowerScript.potIndex.transform.position.x, flowerScript.potIndex.transform.position.y + 2), flowerScript.potIndex.transform.rotation);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
