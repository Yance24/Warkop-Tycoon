using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragIngredientHandler : DragUIHandler
{
    private IngredientItemDataManager dataManager;
    private CupDataManager cupDataManager;

    protected override void setupDrag()
    {
        base.setupDrag();
        dataManager = GetComponent<IngredientItemDataManager>();
        cupDataManager = targetDrag.GetComponent<CupDataManager>();
    }
    protected override void execute()
    {
        base.execute();
        // Debug.Log("Adding ingredients...");
        if(cupDataManager.addIngredients(dataManager.Ingredient)) dataManager.Ingredient.amount--;
        // else Debug.Log("Add ingredients not successfull");
        IngredientsMenuItemManager.Instance.refreshIngredientsUi();
    }
}
