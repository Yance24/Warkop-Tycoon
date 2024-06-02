using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngredientShopItemManager : MonoBehaviour
{
    public TextMeshProUGUI nameUI;
    public TextMeshProUGUI hargaUI;
    public TextMeshProUGUI amountUI;

    private Ingredient ingredientRef;
    private int amount;
    private int harga;

    public int Amount{
        get{return amount;}
        set{
            amount = value;
            amountUI.text = ""+amount;
        }
    }

    public int TotalPrice{
        get{return harga * amount;}
    }

    public Ingredient IngredientRef{
        get{return ingredientRef;}
    }

    public void setup(Ingredient ingredient){
        ingredientRef = ingredient;
        harga = ingredientRef.price;
        nameUI.text = ingredientRef.name;
        hargaUI.text = ""+harga;
        Amount = 0;
    }

    public Ingredient getRef(){
        return ingredientRef;
    }

    public void plusButton(){
        Amount++;
        IngredientShopManager.Instance.refreshTotalPrice();
    }

    public void minButton(){
        Amount--;
        IngredientShopManager.Instance.refreshTotalPrice();
    }

    
}
