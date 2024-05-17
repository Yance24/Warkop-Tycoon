using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NotaMenuWriter : MonoBehaviour
{
    public GameObject menuItemPrefab;
    [SerializeField]
    private float margin;
    private List<MenuParameter> menuList;
    private List<GameObject> menuItemList = new List<GameObject>();

    void OnEnable(){
        menuList = NotaDataManager.Instance.BufferedNota.menu;
        foreach(MenuParameter menu in menuList){
            GameObject menuItem = Instantiate(menuItemPrefab);
            NotaMenuItemHandler menuItemHandler = menuItem.GetComponent<NotaMenuItemHandler>();
            RectTransform menuItemTransform = menuItem.GetComponent<RectTransform>();
            menuItemHandler.setSprite(menu.Icon);
            menuItemHandler.setText(menu.Name);
            menuItemTransform.SetParent(transform,false);
            menuItemTransform.anchoredPosition = new Vector3(0,-44 - (menuItemTransform.sizeDelta.y + margin) * menuItemList.Count,0);
            // Debug.Log("height : "+menuItemTransform.sizeDelta.y);
            // Debug.Log("menuItemList : "+menuItemList.Count);
            // Debug.Log("calc : "+(-44 - (menuItemTransform.sizeDelta.y + margin) * menuItemList.Count));
            menuItemList.Add(menuItem);
        }
    }

    void OnDisable(){
        foreach(GameObject item in menuItemList){
            Destroy(item);
        }
        menuItemList.Clear();
    }
}
