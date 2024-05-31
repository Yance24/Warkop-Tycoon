using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class TrayCupHandler : MonoBehaviour
{
    public TextMeshProUGUI menuName;
    public MenuParameter menuParameter;
    public int index;

    public void setCup(MenuParameter menu, int index){
        menuParameter = menu;
        this.index = index;
        menuName.text = menuParameter.name;
    }
}
