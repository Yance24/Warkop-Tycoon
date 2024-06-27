using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameData : ScriptableObject
{
    public int playerMoney;
    public DateTracker.Date date;
    public List<StoredIngredient> storedIngredients;
    public List<GameObject> unlockedMenu;

}

public static class GameDataUtil{
    public static void CopyValues(GameData source, GameData destination)
    {
        if (source == null || destination == null)
        {
            Debug.LogError("Source or destination is null");
            return;
        }

        FieldInfo[] fields = typeof(GameData).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {
            field.SetValue(destination, field.GetValue(source));
        }
    }

    public static void update(GameData data){
        data.playerMoney = PlayerMoney.Money;
        data.date = DateTracker.Instance.CurrentDate;
        data.storedIngredients = IngredientsStorage.Instance.StoredIngredients;
        data.unlockedMenu = MenuAvailable.Instance.UnlockedMenu;
    }
}