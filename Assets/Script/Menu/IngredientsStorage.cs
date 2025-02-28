using System;
using System.Collections.Generic;
using UnityEngine;

    [Serializable]
    public class StoredIngredient{
        public Ingredient ingredient;
        public int amount;
    }
public class IngredientsStorage : MonoBehaviour
{
    public static IngredientsStorage Instance{get; private set;}

    

    [SerializeField]
    private List<StoredIngredient> storedIngredients = new List<StoredIngredient>();

    public List<StoredIngredient> StoredIngredients{
        get{return storedIngredients;}
        set{storedIngredients = value;}
    }

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }

    void Start(){
        init();
    }

    void init(){
        //init all ingredients
        // setupStoredIngredients();
    }

    void setupStoredIngredients(){
        List<Ingredient> ingredientsDatabase = IngredientsDatabase.Instance.GetIngredientList;
        foreach(Ingredient ingredients in ingredientsDatabase){
            storedIngredients.Add(new StoredIngredient{ingredient = ingredients, amount = 5});
        }
    }

    public StoredIngredient getIngredients(string name){
        return storedIngredients.Find(obj => obj.ingredient.ingredientName == name);
    }

    public void addIngredient(Ingredient ingredient, int amount){
        StoredIngredient storedIngredient = storedIngredients.Find(Component => Component.ingredient == ingredient);
        if(storedIngredient != null){
            storedIngredient.amount += amount;
        }else{
            storedIngredients.Add(new StoredIngredient{ingredient = ingredient, amount = amount});
        }
    }
}
