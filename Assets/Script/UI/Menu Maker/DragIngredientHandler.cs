using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragIngredientHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform parentTransform;
    // private CanvasGroup canvasGroup;
    private GameObject itemClone;
    private RectTransform rectTransform;

    void Start(){
        rectTransform = transform as RectTransform;
        parentTransform = transform.parent as RectTransform;
        // canvasGroup = GetComponent<CanvasGroup>();
        // if(canvasGroup == null){
        //     canvasGroup = gameObject.AddComponent<CanvasGroup>();
        // }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemClone = Instantiate(gameObject);
        itemClone.transform.SetParent(parentTransform, false);
        RectTransform cloneTransform = itemClone.transform as RectTransform;
        cloneTransform.anchoredPosition = rectTransform.anchoredPosition;

        // canvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(parentTransform, eventData.position, eventData.pressEventCamera, out localPoint)){
            rectTransform.anchoredPosition = localPoint;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // canvasGroup.blocksRaycasts = false;
        rectTransform.anchoredPosition = (itemClone.transform as RectTransform).anchoredPosition;
        Destroy(itemClone);
    }
}
