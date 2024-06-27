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

    public List<MenuParameter> GetMenuList{
        get{
            List<MenuParameter> menuList = new List<MenuParameter>();
            foreach(GameObject menu in menuPrefab){
                menuList.Add(menu.GetComponent<MenuParameter>());
            }
            return menuList;
        }
    }

    public GameObject getMenu(string name){
        return GetMenuList.Find(component => component.Name == name).gameObject;
    }
}
