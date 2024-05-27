using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsToCraft : MonoBehaviour
{
    [SerializeField]
    private List<Ingredient> ingredients;

    public List<string> Ingredients{
        get{
            List<string> ingredientsName = new List<string>();
            foreach(Ingredient ingredient in ingredients){
                ingredientsName.Add(ingredient.name);
            }
            return ingredientsName;
        }
    }

    

}
