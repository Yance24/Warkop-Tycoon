using System.Collections.Generic;
using UnityEngine;

public class MenuMakerManager : MonoBehaviour
{
    public GameObject makerUI;
    public GameObject serverUI;
    public GameObject rightGroupButton;
    public GameObject background;

    public List<GameObject> traySlot;

    public static MenuMakerManager Instance{get; private set;}
    private List<MenuParameter> craftedMenu = new List<MenuParameter>();

    public List<MenuParameter> CraftedMenu{
        get{return craftedMenu;}
    }

    public bool addMenu(MenuParameter menu){
        if(craftedMenu.Count < traySlot.Count){
            craftedMenu.Add(menu);
            return true;
        }
        else return false;
    }

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }

    public void createMenu(){
        displayMakerUI();
        MainStatsUIManager.Instance.display(false);
    }

    public void backButton(){
        if(serverUI.activeSelf) displayMakerUI();
        else noDisplay();
    }

    public void nampanButton(){
        displayServerUI();
    }

    public void serveButton(){
        if(TrayManager.Instance.addTrayedMenu(new TrayedMenu(craftedMenu, NotaDataManager.Instance.BufferedNota))){
            craftedMenu.Clear();
            noDisplay();
            // NotaDataManager.Instance.NotaBuffers.Remove(NotaDataManager.Instance.BufferedNota);
            // NotaDataManager.Instance.refreshUI();
            NotaDataManager.Instance.removeNota(NotaDataManager.Instance.BufferedNota);
        }else{
            Debug.Log("trayed menu is full!");
        }
    }

    private void displayMakerUI(){
        makerUI.SetActive(true);
        serverUI.SetActive(false);
        background.SetActive(true);
    }

    private void displayServerUI(){
        serverUI.SetActive(true);
        makerUI.SetActive(false);
        background.SetActive(true);
    }

    public void noDisplay(){
        makerUI.SetActive(false);
        serverUI.SetActive(false);
        background.SetActive(false);
        NotaDataManager.Instance.SelectedNota = false;
        RightGroupButton = false;
        MainStatsUIManager.Instance.display(true);
    }

    public bool isMenuMakerActive(){
        return makerUI.activeSelf || serverUI.activeSelf;
    }

    public bool RightGroupButton{
        set{
            rightGroupButton.SetActive(value);
        }
    }
}
