using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CupDataManager : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    public int maxIngredientSlot;
    private List<StoredIngredient> addedIngredient = new List<StoredIngredient>();

    void OnEnable(){
        refreshSlotUI();
    }

    public bool addIngredients(StoredIngredient ingredient){
        if(addedIngredient.Count >= maxIngredientSlot) return false;
        addedIngredient.Add(ingredient);
        refreshSlotUI();
        return true;

        // foreach(StoredIngredient storedIngredient in addedIngredient){
        //     Debug.Log("Stored Ingredients: "+storedIngredient.ingredient.name);
        // }
    }

    public void brewButton(){
        List<string> ingredientsToCraft = new List<string>();
        foreach(StoredIngredient storedIng in addedIngredient){
            ingredientsToCraft.Add(storedIng.ingredient.name);
        }
        
        GameObject craftedMenu = tryCraft(ingredientsToCraft);
        if(craftedMenu != null){
            // Debug.Log(craftedMenu.name+" Have been crafted!!");
            if(MenuMakerManager.Instance.addMenu(craftedMenu.GetComponent<MenuParameter>())){
                addedIngredient.Clear();    
            }else{
                Debug.Log("Tray Full!!!");
            }
            refreshSlotUI();
        }else{
            Debug.Log("There is no menu to be crafted");
        }
    }

    private GameObject tryCraft(List<string> ingredients){
        // try to craft from available menu
        List<GameObject> menuData = MenuAvailable.Instance.getMenuPrefab();
        foreach(GameObject menuPrefab in menuData){
            List<string> neededIngredients = menuPrefab.GetComponent<IngredientsToCraft>().Ingredients;
            // Debug.Log("Getting available menu : "+menuPrefab.name);
            // Debug.Log("Needed Ingredient:");
            // foreach(string ingredient in neededIngredients){
            //     Debug.Log(ingredient);
            // }
            // Debug.Log("inserted ingredient:");
            // foreach(string ingredient in ingredients){
            //     Debug.Log(ingredient);
            // }

            if(neededIngredients.SequenceEqual(ingredients)){
                return menuPrefab;
            }
        }

        //try to craft from menu database
        menuData = MenuDatabase.Instance.getMenuPrefab();
        foreach(GameObject menuPrefab in menuData){
            List<string> neededIngredients = menuPrefab.GetComponent<IngredientsToCraft>().Ingredients;
            if(neededIngredients.SequenceEqual(ingredients)){
                MenuAvailable.Instance.addAvailableMenu(menuPrefab);
                return menuPrefab;
            }
        }
        
        return null;
    }

    public void resetButton(){
        foreach(StoredIngredient storedIngredient in addedIngredient){
                storedIngredient.amount++;
            }
        addedIngredient.Clear();
        IngredientsMenuItemManager.Instance.refreshIngredientsUi();
        refreshSlotUI();
    }

    private void refreshSlotUI(){
        if(textUI != null){
            // Debug.Log(addedIngredient.Count+"/"+maxIngredientSlot);
            textUI.text = addedIngredient.Count+"/"+maxIngredientSlot;
        }
    }
}
