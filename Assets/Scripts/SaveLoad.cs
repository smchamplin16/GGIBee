using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad    {
    public static Game saveGame = new Game();

    public static void Save() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savegame.gd");
        bf.Serialize(file, SaveLoad.saveGame);
        file.Close();
    }

    public static void Load() {
        if(File.Exists(Application.persistentDataPath + "/savegame.gd")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savegame.gd", FileMode.Open);
            SaveLoad.saveGame = (Game)bf.Deserialize(file);
            file.Close();
        }
    }
}