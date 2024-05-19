using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngridientsMenuItem : MonoBehaviour
{
    [SerializeField]
    private string ingredientsRefName;

    private IngredientsStorage.StoredIngredients storedIngredientsRef;

    void OnEnable(){
        getIngredientsRef();
    }

    void getIngredientsRef(){
        storedIngredientsRef = IngredientsStorage.Instance.getIngredients(ingredientsRefName);
    }
}
