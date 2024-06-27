using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI textUI;

    void OnEnable(){
        PlayerMoney.OnMoneyChange += refreshUI;
        refreshUI();
    }

    void OnDisable(){
        PlayerMoney.OnMoneyChange -= refreshUI;
    }

    public void refreshUI(){
        textUI.text = formatMoney(PlayerMoney.Money);
    }

    private string formatMoney(int money){
        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.NumberGroupSeparator = ".";

        return money.ToString("N0",nfi);
    }
}
