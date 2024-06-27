using System;
using UnityEngine;

public class Ingredient : MonoBehaviour{
    [Serializable]
    public enum type{coffee,tea,none}
    public Sprite ingredientIcon;
    public string ingredientName;
    public type ingredientType;
    public int price;
}
