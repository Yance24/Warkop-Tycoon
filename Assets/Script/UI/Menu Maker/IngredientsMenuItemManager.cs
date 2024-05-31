using System;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsMenuItemManager : MonoBehaviour
{
    public static IngredientsMenuItemManager Instance{get; private set;}

    // [SerializeField]
    // private List<IngredientsMenuItem> ingredientItemUI;

    // [SerializeField]
    // private RectTransform targetDrag;

    [Serializable]
    class IngredientsReferecence{
        public GameObject uiObject;
        public string name;
    }

    [SerializeField]
    private List<IngredientsReferecence> ingredientsReferecences;

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }
    
    //can be optimized later on
    void OnEnable(){
        foreach(IngredientsReferecence ingredients in ingredientsReferecences){
            StoredIngredient storedIngredientRef = IngredientsStorage.Instance.getIngredients(ingredients.name);
            if(storedIngredientRef.amount > 0){
                ingredients.uiObject.SetActive(true);
                IngredientItemDataManager dataManager = ingredients.uiObject.GetComponent<IngredientItemDataManager>();
                dataManager.Ingredient = storedIngredientRef;
                // dataManager.TargetDrag = targetDrag;
                
            }else{
                ingredients.uiObject.SetActive(false);
            }
        }
    }

    public void refreshIngredientsUi(){
        foreach(IngredientsReferecence ingredients in ingredientsReferecences){
            StoredIngredient storedIngredientRef = IngredientsStorage.Instance.getIngredients(ingredients.name);
            if(storedIngredientRef.amount > 0){
                ingredients.uiObject.SetActive(true);
                IngredientItemDataManager dataManager = ingredients.uiObject.GetComponent<IngredientItemDataManager>();
                dataManager.Ingredient = storedIngredientRef;
                // dataManager.TargetDrag = targetDrag;
                
            }else{
                ingredients.uiObject.SetActive(false);
            }
        }
    }
}
