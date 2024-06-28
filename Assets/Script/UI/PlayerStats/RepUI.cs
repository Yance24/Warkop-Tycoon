using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RepUI : MonoBehaviour
{
    public TextMeshProUGUI text;

    void OnEnable(){
        ReputationSystem.RepChange += refreshUI;
        refreshUI();
    }

    void OnDisable(){
        ReputationSystem.RepChange -= refreshUI;
    }

    private void refreshUI(){
        text.text = ""+ReputationSystem.Instance.CurrentReputation;
    }
}
