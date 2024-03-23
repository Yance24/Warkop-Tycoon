using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragHorizontalCameraControl : MonoBehaviour
{
    public float sensitivity;
    ScrollHorizontalCameraControl scrollHorizontal;
    private bool isDragged = false;
    private Vector2 startDragged;
    private Vector2 startCameraPosition;
    private ScreenEdges screenEdges;
    public Transform leftBorder;
    public Transform rightBorder;
    
    void Start()
    {
        scrollHorizontal = GetComponent<ScrollHorizontalCameraControl>();
        screenEdges = new ScreenEdges();
        screenEdges.getWorldCoordinates();
        // screenEdges.showEdgeCoordinates();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("TEST");
        if(Input.GetMouseButtonDown(1)){
            Debug.Log("Button Pressed");
            if(scrollHorizontal){
                scrollHorizontal.IsActive = false;
                CancelInvoke("activeScrollHorizontal");
            }
            startDragged = getMousePosition();
            startCameraPosition = transform.position;
            isDragged = true;
        }

        if(Input.GetMouseButtonUp(1)){
            Debug.Log("Button Released");
            if(scrollHorizontal){
                Invoke("activeScrollHorizontal",1f);
            }
            isDragged = false;
        }
    }

    void FixedUpdate(){
        if(isDragged) processDrag();
    }

    private void processDrag(){
        float offset = convertDragToWorld(getMousePosition().x - startDragged.x) * sensitivity;
        float position = startCameraPosition.x - offset;

        if(screenEdges.worldLeft < leftBorder.position.x && offset > 0){
            position = leftBorder.position.x + (screenEdges.right - screenEdges.left) / 2 - 0.1f;
            transform.position = new Vector3(position, startCameraPosition.y,-10);
            startDragged = getMousePosition();
            startCameraPosition = transform.position;
            return;
        } 
        else if(screenEdges.worldRight > rightBorder.position.x && offset < 0){
            position = rightBorder.position.x - (screenEdges.right - screenEdges.left) / 2 + 0.1f;
            transform.position = new Vector3(position, startCameraPosition.y,-10);
            startDragged = getMousePosition();
            startCameraPosition = transform.position;
            return;
        }
        
        transform.position = new Vector3(position, startCameraPosition.y,-10);
    }

    private float convertDragToWorld(float offset){
        return offset * (screenEdges.right - screenEdges.left) / Screen.width;
    }

    private Vector2 getMousePosition(){
        return Input.mousePosition;
    }

    private void activeScrollHorizontal(){
        scrollHorizontal.IsActive = true;
    }
}
