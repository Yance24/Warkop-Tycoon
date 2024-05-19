using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngredientsMenuItem : MonoBehaviour
{
    public TextMeshProUGUI textNumberUI;

    // private 

    // [SerializeField]
    // private string ingredientsRefName;
    // private IngredientsStorage.StoredIngredients storedIngredientsRef;

    // void Start(){
    //     getIngredientsRef();
    // }

    // void OnEnable(){
    //     if(!isThereIngredient()) gameObject.SetActive(false);
    // }

    // void getIngredientsRef(){
    //     Debug.Log("Test");
    //     storedIngredientsRef = IngredientsStorage.Instance.getIngredients(ingredientsRefName);
    // }

    // bool isThereIngredient(){
    //     return storedIngredientsRef.amount > 0 ;
    // }
}
