using System;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsMenuItemManager : MonoBehaviour
{
    // [SerializeField]
    // private List<IngredientsMenuItem> ingredientItemUI;

    [Serializable]
    class IngredientsReferecence{
        public GameObject uiObject;
        public string name;
    }

    [SerializeField]
    private List<IngredientsReferecence> ingredientsReferecences;

    void OnEnable(){
        foreach(IngredientsReferecence ingredients in ingredientsReferecences){
            StoredIngredient storedIngredient = IngredientsStorage.Instance.getIngredients(ingredients.name);
            if(storedIngredient.amount > 0){
                ingredients.uiObject.SetActive(true);
                ingredients.uiObject.GetComponent<IngredientNumberUI>().setAmount = storedIngredient.amount;
            }else{
                ingredients.uiObject.SetActive(false);
            }
        }
    }
}
