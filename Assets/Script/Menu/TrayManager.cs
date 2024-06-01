using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayedMenu{
    public List<MenuParameter> createdMenus = new List<MenuParameter>();
    public NotaDataBuffer notaData;

    public TrayedMenu(List<MenuParameter> createdMenus, NotaDataBuffer notaData){
        foreach(MenuParameter createdMenu in createdMenus){
            this.createdMenus.Add(createdMenu);
        }
        this.notaData = notaData;
    }
}

public class TrayedMenuWrap : MonoBehaviour{
    public TrayedMenu tray;
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

    public TrayedMenu pullTray(){
        if(trayedMenus.Count <= 0) return null;
        TrayedMenu trayedMenu = trayedMenus[0];
        trayedMenus.RemoveAt(0);
        return trayedMenu;
    }
}
