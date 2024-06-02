using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIManager : MonoBehaviour
{
    public static ShopUIManager Instance{get; private set;}

    public GameObject IngredientShopUI;

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }

    public void displayIngredientShop(){
        MenuMakerManager.Instance.noDisplay();
        MainStatsUIManager.Instance.displayMoney = true;
        MainStatsUIManager.Instance.displayTime = false;
        NotaDataManager.Instance.noDisplay();
        IngredientShopUI.SetActive(true);
        
    }

    public void noDisplay(){
        IngredientShopUI.SetActive(false);
    }
}
