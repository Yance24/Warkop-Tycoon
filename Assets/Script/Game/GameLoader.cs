using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public static GameLoader Instance{private set; get;}
    public GameDataObject gameDataObj;

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }

    void Start(){
        loadMoney();
        loadTime();
        loadIngredients();
        loadUnlockedMenu();
    }

    private void loadMoney(){
        PlayerMoney.Money = gameDataObj.gameData.playerMoney;
    }

    private void loadTime(){
        DateTracker.CurrentDate = gameDataObj.gameData.date;
    }

    private void loadIngredients(){
        IngredientsStorage.Instance.StoredIngredients = gameDataObj.gameData.storedIngredients;
    }

    private void loadUnlockedMenu(){
        MenuAvailable.Instance.UnlockedMenu = gameDataObj.gameData.unlockedMenu;
    }
}
