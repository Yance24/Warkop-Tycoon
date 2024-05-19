using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
    public class Ingredients{
        public Sprite icon;
        public string name;
    }

public class IngredientsDatabase : MonoBehaviour
{
    public static IngredientsDatabase Instance{get; private set;}

    [SerializeField]
    private List<Ingredients> ingredientList;

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }

    public List<Ingredients> GetIngredients{
        get{return ingredientList;}
    }
}
