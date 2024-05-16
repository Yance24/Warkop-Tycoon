using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuAvailable : MonoBehaviour
{
    public static MenuAvailable Instance {get;private set;}
    [SerializeField]
    public List<MenuParameter> menuItem = new List<MenuParameter>();

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }
}