using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CupDataManager : MonoBehaviour
{
    private List<GameObject> storedIngredientRef;

    public void addIngredients(GameObject gameObject){
        storedIngredientRef.Add(gameObject);
    }

    

}
