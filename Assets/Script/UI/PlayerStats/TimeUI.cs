using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    public TextMeshProUGUI textUI;

    void OnEnable(){
        DayCycle.TimeChange += refreshUI;
        refreshUI();
    }

    void OnDisable(){
        DayCycle.TimeChange -= refreshUI;
    }

    void refreshUI(){
        textUI.text = DayCycle.CurrentTime;
    }
}
