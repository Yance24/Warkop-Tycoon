using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngredientShopManager : MonoBehaviour
{
    public static IngredientShopManager Instance{get; private set;}

    public List<IngredientShopItemManager> shopItems;
    public TextMeshProUGUI totalPrice;

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }

    void Start(){
        List<Ingredient> ingredientDatabase = IngredientsDatabase.Instance.GetIngredientList;
        for(int i = 0; i < shopItems.Count; i++){
            shopItems[i].setup(ingredientDatabase[i]);
        }
    }

    public void buyButton(){
        
    }

    public void refreshTotalPrice(){
        
    }
}
