using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragCameraControl : MonoBehaviour
{
    public float sensitivity;
    // ScrollHorizontalCameraControl scrollHorizontal;
    private bool isDragged = false;
    private Vector2 startDragged;
    private Vector2 startCameraPosition;
    private ScreenEdges screenEdges;
    private BorderObject border;
    // public Transform leftBorder;
    // public Transform rightBorder;
    
    void Start()
    {
        // scrollHorizontal = GetComponent<ScrollHorizontalCameraControl>();
        border = GetComponent<BorderObject>();
        screenEdges = new ScreenEdges();
        // screenEdges.showEdgeCoordinates();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(1)){
            // if(scrollHorizontal){
            //     scrollHorizontal.IsActive = false;
            //     CancelInvoke("activeScrollHorizontal");
            // }
            // Debug.Log("Mouse Down");
            startDragged = getMousePosition();
            startCameraPosition = transform.position;
            isDragged = true;
        }

        if(Input.GetMouseButtonUp(1)){
            // if(scrollHorizontal){
            //     Invoke("activeScrollHorizontal",1f);
            // }
            // Debug.Log("Mouse up");
            isDragged = false;
        }
    }

    void FixedUpdate(){
        if(isDragged) processDrag();
        if(border) checkBorder();
    }

    private void processDrag(){
        Vector2 offset = new Vector2(
            convertDragToWorldX(getMousePosition().x - startDragged.x),
            convertDragToWorldY(getMousePosition().y - startDragged.y))
            * sensitivity;
        
        // float position = startCameraPosition.x - offset;
        transform.position = new Vector3(startCameraPosition.x - offset.x, startCameraPosition.y - offset.y,-10);
    }

    private void checkBorder(){
        float positionX = transform.position.x;
        float positionY = transform.position.y;

        if(border.leftBorder && screenEdges.Left < border.leftBorder.position.x){
            positionX = border.leftBorder.position.x + screenEdges.Width / 2;
            startDragged.x = getMousePosition().x;
            startCameraPosition.x = positionX;
        }else
        
        if(border.rightBorder && screenEdges.Right > border.rightBorder.position.x){
            positionX = border.rightBorder.position.x - screenEdges.Width / 2;
            startDragged.x = getMousePosition().x;
            startCameraPosition.x = positionX;
        }

        if(border.botBorder && screenEdges.Bot < border.botBorder.position.y){
            positionY = border.botBorder.position.y + screenEdges.Height / 2;
            startDragged.y = getMousePosition().y;
            startCameraPosition.y = positionY;
        }else

        if(border.topBorder && screenEdges.Top > border.topBorder.position.y){
            positionY = border.topBorder.position.y - screenEdges.Height / 2;
            startDragged.y = getMousePosition().y;
            startCameraPosition.y = positionY;
        }

        transform.position = new Vector3(positionX,positionY,-10);

        // if(screenEdges.Left < border.leftBorder.position.x && offset > 0){
        //     position = border.leftBorder.position.x + (screenEdges.Width) / 2 - 0.1f;
        //     transform.position = new Vector3(position, startCameraPosition.y,-10);
        //     startDragged = getMousePosition();
        //     startCameraPosition = transform.position;
        //     return;
        // } 
        // else if(screenEdges.Right > border.rightBorder.position.x && offset < 0){
        //     position = border.rightBorder.position.x - (screenEdges.Width) / 2 + 0.1f;
        //     transform.position = new Vector3(position, startCameraPosition.y,-10);
        //     startDragged = getMousePosition();
        //     startCameraPosition = transform.position;
        //     return;
        // }
    }

    private float convertDragToWorldX(float offset){
        return offset * screenEdges.Width / Screen.width;
    }
    private float convertDragToWorldY(float offset){
        return offset * screenEdges.Height / Screen.height;
    }

    private Vector2 getMousePosition(){
        return Input.mousePosition;
    }

    // private void activeScrollHorizontal(){
    //     scrollHorizontal.IsActive = true;
    // }
}
