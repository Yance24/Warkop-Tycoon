using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    void Start(){
        loadMoney();
        loadTime();
        loadIngredients();
        loadUnlockedMenu();
    }

    private void loadMoney(){
        PlayerMoney.Money = 10000;
    }

    private void loadTime(){
        
    }

    private void loadIngredients(){
        IngredientsStorage.Instance.StoredIngredients.Add(
            new StoredIngredient{ingredient = IngredientsDatabase.Instance.getIngredient("Coffe Powder"), amount = 10}
        );
        IngredientsStorage.Instance.StoredIngredients.Add(
            new StoredIngredient{ingredient = IngredientsDatabase.Instance.getIngredient("Sugar"), amount = 10}
        );
        IngredientsStorage.Instance.StoredIngredients.Add(
            new StoredIngredient{ingredient = IngredientsDatabase.Instance.getIngredient("Milk"), amount = 10}
        );
        // IngredientsStorage.Instance.StoredIngredients.Add(
        //     new StoredIngredient{ingredient = IngredientsDatabase.Instance.getIngredient("Tea"), amount = 10}
        // );
    }

    private void loadUnlockedMenu(){
        
    }
}
