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
        List<Ingredient> ingredientsDatabase = IngredientsDatabase.Instance.GetIngredients;
        foreach(Ingredient ingredients in ingredientsDatabase){
            IngredientsStorage.Instance.StoredIngredients.Add(new StoredIngredient{ingredient = ingredients, amount = 10});
        }
    }

    private void loadUnlockedMenu(){

    }
}
