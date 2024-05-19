using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class IngredientsStorage : MonoBehaviour
{
    public static IngredientsStorage Instance{get; private set;}

    [Serializable]
    public class StoredIngredients{
        public Ingredients ingredients;
        public int amount;
    }

    [SerializeField]
    private List<StoredIngredients> storedIngredients = new List<StoredIngredients>();    

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }

    void Start(){
        init();
    }

    void init(){
        //init all ingredients
        setupStoredIngredients();
    }

    void setupStoredIngredients(){
        List<Ingredients> ingredientsDatabase = IngredientsDatabase.Instance.GetIngredients;
        foreach(Ingredients ingredients in ingredientsDatabase){
            storedIngredients.Add(new StoredIngredients{ingredients = ingredients, amount = 5});
        }
    }

    public StoredIngredients getIngredients(string name){
        return storedIngredients.Find(obj => obj.ingredients.name == name);
    }
}
