using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotaMenuItemHandler : MonoBehaviour
{
    [SerializeField]
    private Image image;

    [SerializeField]
    private TextMeshProUGUI text;

    public void setSprite(Sprite sprite){
        if(sprite) image.sprite = sprite;
    }

    public void setText(string name){
        text.text = name;
    }
}
