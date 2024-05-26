using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IngredientsDatabase : MonoBehaviour
{
    public static IngredientsDatabase Instance{get; private set;}

    [SerializeField]
    private List<GameObject> ingredientData;

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }

    public List<Ingredient> GetIngredients{
        get{
            List<Ingredient> ingredientList = new List<Ingredient>();
            foreach(GameObject ingredientObj in ingredientData){
                ingredientList.Add(ingredientObj.GetComponent<Ingredient>());
            }
            return ingredientList;
        }
    }
}
