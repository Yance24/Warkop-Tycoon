using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MenuMakerManager : MonoBehaviour
{
    public GameObject makerUI;
    public GameObject serverUI;

    public static MenuMakerManager Instance{get; private set;}

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
    }

    private void displayServerUI(){
        serverUI.SetActive(true);
        makerUI.SetActive(false);
    }

    private void noDisplay(){
        makerUI.SetActive(false);
        serverUI.SetActive(false);
    }
}
