﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game {
    public static Game current;
    public List<GameObject> flowers;

    public Game() {
        flowers = new List<GameObject>();
    }
}
