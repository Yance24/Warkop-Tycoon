using System;
using UnityEngine;

public class MenuParameter : BaseMenuParameter
{
    [SerializeField]
    private int price;

    [SerializeField]
    private string menuName;

    [Serializable]
    public enum MenuType{
        Brew,Food,Other
    }
    [SerializeField]
    private MenuType menuType;

    public int Price{
        get{return price;}
    }

    public string Name{
        get{return menuName;}
    }

    public MenuType Type{
        get{return menuType;}
    }
}
