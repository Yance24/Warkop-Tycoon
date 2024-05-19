using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngredientNumberUI : MonoBehaviour
{
    public TextMeshProUGUI textNumberUI;
    private int ingredientAmount;

    public int setAmount{
        set{
            ingredientAmount = value;
            textNumberUI.text = ""+value;
        }
        get{
            return ingredientAmount;
        }
    }    
}
