using UnityEngine;

[CreateAssetMenu(fileName = "GameDataObject", menuName = "ScriptableObjects/GameDataObject", order = 1)]
public class GameDataObject : ScriptableObject{
    public GameData gameData = new GameData();
}