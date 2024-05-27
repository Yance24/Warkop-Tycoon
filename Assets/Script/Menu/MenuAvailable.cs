using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuAvailable : MonoBehaviour
{
    public static MenuAvailable Instance {get;private set;}
    [SerializeField]
    private List<GameObject> menuPrefab = new List<GameObject>();

    public List<MenuParameter> menuParameters = new List<MenuParameter>();
    // private List<IngredientsToCraft>

    public List<GameObject> getMenuPrefab(){
        return menuPrefab;
    }

    public void addAvailableMenu(GameObject menu){
        menuPrefab.Add(menu);
        setupMenuParamaters();
    }

    private void setupMenuParamaters(){
        menuParameters.Clear();
        foreach(GameObject menu in menuPrefab){
            menuParameters.Add(menu.GetComponent<MenuParameter>());
        }
    }

    // public List<IngredientsToCraft> getIngredientsToCrafts(){
    //     List<IngredientsToCraft> ingredientsToCrafts = new List<IngredientsToCraft>();
    //     foreach(GameObject menu in menuPrefab){
    //         ingredientsToCrafts.Add(menu.GetComponent<IngredientsToCraft>());
    //     }
    //     return ingredientsToCrafts;
    // }

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }

    void Start(){
        setupMenuParamaters();
    }
}