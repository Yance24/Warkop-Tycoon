using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CostumerBubbleChat : MonoBehaviour
{
    public GameObject bubbleTextObj;

    private SpriteRenderer costumerSpriteRenderer;
    private Vector2 bubbleTextCoor;
    private TextMeshPro textObj;

    void Start(){
        costumerSpriteRenderer = GetComponent<SpriteRenderer>();
        bubbleTextCoor = bubbleTextObj.transform.localPosition;
        textObj = bubbleTextObj.transform.Find("Text").GetComponent<TextMeshPro>();
        bubbleTextObj.SetActive(false);
    }

    public void setText(string text){
        bubbleTextObj.SetActive(true);
        if(costumerSpriteRenderer.flipX)
            bubbleTextObj.transform.localPosition = new Vector2(bubbleTextCoor.x * -1,bubbleTextCoor.y);
        else
            bubbleTextObj.transform.localPosition = bubbleTextCoor;
        
        textObj.text = text;
    }

    public void clearText(){
        bubbleTextObj.SetActive(false);
    }
}
