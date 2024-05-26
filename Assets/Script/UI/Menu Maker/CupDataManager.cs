using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CupDataManager : MonoBehaviour
{
    private List<GameObject> storedIngredientRef;

    public void addIngredients(GameObject gameObject){
        storedIngredientRef.Add(gameObject);
    }

    public void brewButton(){
        List<Ingredient> ingredientsToCraft = new List<Ingredient>();
        foreach(GameObject gameObject in storedIngredientRef){
            ingredientsToCraft.Add(gameObject.GetComponent<IngredientItemDataManager>().Ingredient.ingredient);
        }
        
    }

    public void resetButton(){

    }
}
