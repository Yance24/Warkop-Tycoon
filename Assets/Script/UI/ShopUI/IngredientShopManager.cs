using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class IngredientShopManager : MonoBehaviour
{
    public static IngredientShopManager Instance{get; private set;}

    public List<IngredientShopItemManager> shopItems;
    public TextMeshProUGUI totalPriceUI;

    private int totalPrice;
    NumberFormatInfo nfi = new NumberFormatInfo();

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }

    void Start(){
        nfi.NumberGroupSeparator = ".";
        List<Ingredient> ingredientDatabase = IngredientsDatabase.Instance.GetIngredientList;
        for(int i = 0; i < shopItems.Count; i++){
            shopItems[i].setup(ingredientDatabase[i]);
        }
        refreshTotalPrice();
    }

    public void buyButton(){
        if(totalPrice <= PlayerMoney.Money){
            Debug.Log("Managed To Buy!");
            PlayerMoney.Money -= totalPrice;
            foreach(IngredientShopItemManager item in shopItems){
                IngredientsStorage.Instance.addIngredient(item.IngredientRef,item.Amount);
            }
            ShopUIManager.Instance.noDisplay();
            DayCycle.Instance.restartDay();
        }else{
            Debug.Log("Not Enough Money");
        }
    }

    public void refreshTotalPrice(){
        totalPrice = 0;
        foreach(IngredientShopItemManager shopItem in shopItems){
            totalPrice += shopItem.TotalPrice;
        }

        totalPriceUI.text = totalPrice.ToString("N0",nfi);
    }
}
