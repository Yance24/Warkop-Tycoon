using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public GameData gameData;

    void Start(){
        loadMoney();
        loadTime();
        loadIngredients();
        loadUnlockedMenu();
    }

    private void loadMoney(){
        PlayerMoney.Money = gameData.playerMoney;
    }

    private void loadTime(){
        DateTracker.Instance.CurrentDate = gameData.date;
    }

    private void loadIngredients(){
        IngredientsStorage.Instance.StoredIngredients = gameData.storedIngredients;
    }

    private void loadUnlockedMenu(){
        MenuAvailable.Instance.UnlockedMenu = gameData.unlockedMenu;
    }
}
