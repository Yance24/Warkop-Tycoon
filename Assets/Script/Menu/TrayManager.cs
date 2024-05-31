using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayedMenu{
    public List<MenuParameter> createdMenus;
    public NotaDataBuffer notaData;

    public TrayedMenu(List<MenuParameter> createdMenus, NotaDataBuffer notaData){
        this.createdMenus = createdMenus;
        this.notaData = notaData;
    }
}

public class TrayManager : MonoBehaviour
{
    public int maximumTrayedMenu;

    public static TrayManager Instance{get; private set;}

    private List<TrayedMenu> trayedMenus = new List<TrayedMenu>();

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }

    public bool addTrayedMenu(TrayedMenu trayedMenu){
        if(trayedMenus.Count >= maximumTrayedMenu) return false;
        trayedMenus.Add(trayedMenu);
        return true;
    }


}
