using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTransformScale : MonoBehaviour
{
    public Vector2 scale;
    public bool isRectTransform;
    public bool isSameSize;

    void Start(){
        if(isRectTransform){
            RectTransform rectTransform = GetComponent<RectTransform>();
            Vector2 originalScale = rectTransform.localScale;
            rectTransform.localScale = WorldTransform.convertToLocalScale(scale,transform.parent);

            if(isSameSize){ 
                float scaleX = originalScale.x / rectTransform.localScale.x;
                float scaleY = originalScale.y / rectTransform.localScale.y;

                Vector2 newSizeDelta = new Vector2(rectTransform.sizeDelta.x * scaleX,rectTransform.sizeDelta.y * scaleY);
                rectTransform.sizeDelta = newSizeDelta;
            }
        }
        else
            transform.localScale = WorldTransform.convertToLocalScale(scale,transform.parent);
    }
}
