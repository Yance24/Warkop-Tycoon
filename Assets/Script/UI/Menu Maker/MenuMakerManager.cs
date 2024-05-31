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
    }

    public void backButton(){
        if(serverUI.activeSelf) displayMakerUI();
        else noDisplay();
    }

    public void nampanButton(){
        displayServerUI();
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

    private void noDisplay(){
        makerUI.SetActive(false);
        serverUI.SetActive(false);
        background.SetActive(false);
        NotaDataManager.Instance.SelectedNota = false;
        RightGroupButton = false;
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
