using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveLoadManager
{
    private static string saveFilePath = Path.Combine(Application.persistentDataPath,"save00.json");

    public static void saveGame(GameData data){
        string json = JsonUtility.ToJson(data);
        string encryptionJson = EncryptionUtility.EncryptString(json);
        File.WriteAllText(saveFilePath,encryptionJson);
    }

    public static GameData loadGame(){
        if(File.Exists(saveFilePath)){
            string encryptionJson = File.ReadAllText(saveFilePath);
            string json = EncryptionUtility.DecryptString(encryptionJson);
            return JsonUtility.FromJson<GameData>(json);
        }
        return null;
    }

    public static bool checkLoadGame(){
        return File.Exists(saveFilePath);
    }
}
