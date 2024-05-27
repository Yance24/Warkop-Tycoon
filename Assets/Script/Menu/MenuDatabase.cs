using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDatabase : MonoBehaviour
{
    public static MenuDatabase Instance{get; private set;}

    [SerializeField]
    private List<GameObject> menuPrefab;

    public List<GameObject> getMenuPrefab(){
        return menuPrefab;
    }

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }

    // public GameObject tryCraftMenu(List<Ingredient> ingredients){
    //     foreach(GameObject gameObject in menuPrefab){
    //         if(gameObject.GetComponent<IngredientsToCraft>().ingredients == ingredients){
    //             return gameObject;
    //         }
    //     }
    //     return null;
    // }
}
