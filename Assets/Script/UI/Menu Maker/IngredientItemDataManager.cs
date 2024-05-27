using TMPro;
using UnityEngine;

public class IngredientItemDataManager : MonoBehaviour
{
    public TextMeshProUGUI textNumberUI;
    private StoredIngredient storedIngredientRef;

    private RectTransform targetDrag;

    public StoredIngredient Ingredient{
        set{
            storedIngredientRef = value;
            textNumberUI.text = ""+storedIngredientRef.amount;
        }
        get{
            return storedIngredientRef;
        }
    }

    public RectTransform TargetDrag{
        set{
            targetDrag = value;
        }
        get{
            return targetDrag;
        }
    }

    public void refreshText(){
        textNumberUI.text = ""+storedIngredientRef.amount;
    }
}
