using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DateUI : MonoBehaviour
{
    public TextMeshProUGUI yearText;
    public TextMeshProUGUI monthText;
    public TextMeshProUGUI weekText;

    void Start(){
        updateUi();
    }

    void OnEnable(){
        DateTracker.DateChange += updateUi;
    }

    void OnDisable(){
        DateTracker.DateChange -= updateUi;
    }


    private void updateUi(){
        yearText.text = ""+DateTracker.CurrentDate.year;
        monthText.text = ""+DateTracker.CurrentDate.month;
        weekText.text = ""+DateTracker.CurrentDate.week;
    }
}
