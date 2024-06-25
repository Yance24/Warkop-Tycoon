using UnityEngine;
using UnityEngine.EventSystems;

public class DragUIHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    protected RectTransform parentTransform;
    protected static GameObject itemClone;
    protected RectTransform rectTransform;
    [SerializeField]
    protected RectTransform targetDrag;
    protected Bounds targetBounds;
    protected Bounds currentBounds;
        

    void Start(){
        setupDrag();
    }

    protected virtual void setupDrag(){
        rectTransform = transform as RectTransform;
        parentTransform = transform.parent as RectTransform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        RectTransform targetParent = targetDrag.parent as RectTransform;
        targetBounds = RectTransformUtility.CalculateRelativeRectTransformBounds(targetParent,targetDrag);
        
        if(!itemClone){
            itemClone = Instantiate(gameObject);
            itemClone.transform.SetParent(parentTransform, false);
        }
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
            execute();
        }
        Destroy(itemClone);
    }

    protected virtual void execute(){

    }
}