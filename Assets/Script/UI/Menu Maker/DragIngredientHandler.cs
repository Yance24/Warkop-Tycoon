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
        if(cupDataManager.addIngredients(dataManager.Ingredient)) dataManager.Ingredient.amount--;
        IngredientsMenuItemManager.Instance.refreshIngredientsUi();
    }
}
