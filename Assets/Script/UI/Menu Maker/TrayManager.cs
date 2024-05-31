using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrayManager : MonoBehaviour
{
    public static TrayManager Instance{get; private set;}

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }

    void OnEnable(){
        refreshUI();
    }

    public void refreshUI(){
        clearTray();
        List<MenuParameter> craftedMenu = MenuMakerManager.Instance.CraftedMenu;
        List<GameObject> uiSlot = MenuMakerManager.Instance.traySlot;
        for(int i = 0; i < craftedMenu.Count; i++){
            uiSlot[i].SetActive(true);
            uiSlot[i].GetComponent<TrayCupHandler>().setCup(craftedMenu[i],i);
        }

    }

    void clearTray(){
        List<GameObject> uiSlot = MenuMakerManager.Instance.traySlot;
        foreach(GameObject slot in uiSlot){
            slot.SetActive(false);
        }
    }
}
