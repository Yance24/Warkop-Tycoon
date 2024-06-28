using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(fileName = "GameDataObject", menuName = "ScriptableObjects/GameDataObject", order = 1)]
public class GameDataObject : ScriptableObject{
    public GameData gameData = new GameData();
}


[Serializable]
public class GameData
{
    public int playerMoney;
    public DateTracker.Date date;
    public List<StoredIngredient> storedIngredients;
    public List<GameObject> unlockedMenu;
    public int playerReputation;

}

public static class GameDataUtil{
    public static void CopyValues(GameData source, GameDataObject destination)
    {
        if (source == null || destination == null)
        {
            Debug.LogError("Source or destination is null");
            return;
        }

        FieldInfo[] fields = typeof(GameData).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {
            field.SetValue(destination.gameData, field.GetValue(source));
        }

        // destination.gameData = source;
    }

    public static void update(GameDataObject gameDataObj){
        gameDataObj.gameData.playerMoney = PlayerMoney.Money;
        gameDataObj.gameData.date = DateTracker.CurrentDate;
        gameDataObj.gameData.storedIngredients = IngredientsStorage.Instance.StoredIngredients;
        gameDataObj.gameData.unlockedMenu = MenuAvailable.Instance.UnlockedMenu;
        gameDataObj.gameData.playerReputation = ReputationSystem.Instance.CurrentReputation;
    }
}