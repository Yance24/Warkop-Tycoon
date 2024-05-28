using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragIngredientHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    private RectTransform parentTransform;
    private GameObject itemClone;
    private RectTransform rectTransform;
    private IngredientItemDataManager dataManager;
    private RectTransform targetDrag;
    private CupDataManager cupDataManager;
    private Bounds targetBounds;
    private Bounds currentBounds;
    
    

    void Start(){
        rectTransform = transform as RectTransform;
        parentTransform = transform.parent as RectTransform;
        dataManager = GetComponent<IngredientItemDataManager>();
        targetDrag = dataManager.TargetDrag;

        if(targetDrag == null) return;

        RectTransform targetParent = targetDrag.parent as RectTransform;
        targetBounds = RectTransformUtility.CalculateRelativeRectTransformBounds(targetParent,targetDrag);
        cupDataManager = targetDrag.GetComponent<CupDataManager>();
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemClone = Instantiate(gameObject);
        itemClone.transform.SetParent(parentTransform, false);
        RectTransform cloneTransform = itemClone.transform as RectTransform;
        cloneTransform.anchoredPosition = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(parentTransform, eventData.position, eventData.pressEventCamera, out localPoint)){
            rectTransform.anchoredPosition = localPoint;
            currentBounds = RectTransformUtility.CalculateRelativeRectTransformBounds(parentTransform,rectTransform);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = (itemClone.transform as RectTransform).anchoredPosition;
        if(currentBounds.Intersects(targetBounds)){
            dataManager.Ingredient.amount--;
            cupDataManager.addIngredients(dataManager.Ingredient);
            IngredientsMenuItemManager.Instance.refreshIngredientsUi();
        }
        Destroy(itemClone);
    }
}
