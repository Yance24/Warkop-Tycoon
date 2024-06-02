using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStatsUIManager : MonoBehaviour
{
    public static MainStatsUIManager Instance{get;private set;}
    public GameObject moneyUI;
    public GameObject timeUI;

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }

    void Start(){
        display(true);
    }

    public void display(bool value){
        moneyUI.SetActive(value);
        timeUI.SetActive(value);
    }

    public bool displayMoney{
        set{moneyUI.SetActive(value);}
    }

    public bool displayTime{
        set{timeUI.SetActive(value);}
    }    
}
