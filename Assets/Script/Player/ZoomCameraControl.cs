using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCameraControl : MonoBehaviour
{
    public float zoomSensitivity;
    public float maxZoom;
    public float minZoom;
    private float currentZoom;
    private Vector2 mousePosition;
    private ScreenEdges screenEdges;
    private BorderObject border;

    void Start(){
        currentZoom = Camera.main.orthographicSize;
        screenEdges = new ScreenEdges();
        border = GetComponent<BorderObject>();
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        mousePosition = Input.mousePosition;
        if(
            mousePosition.x < Screen.width &&
            mousePosition.x > 0 &&
            mousePosition.y < Screen.height &&
            mousePosition.y > 0
        )
        if(scroll > 0f){
            currentZoom -= zoomSensitivity;
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(currentZoom < minZoom) currentZoom = minZoom;
            Camera.main.orthographicSize = currentZoom;
            shiftCamera();
            if(border) checkBorder();
        }else if(scroll < 0f){
            currentZoom += zoomSensitivity;
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(currentZoom > maxZoom) currentZoom = maxZoom;
            Camera.main.orthographicSize = currentZoom;
            shiftCamera();
            if(border) checkBorder();
        }
    }

    private void shiftCamera(){
        Vector2 mousePositionAfterZoom = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 offset = new Vector3(
            transform.position.x - (mousePositionAfterZoom.x - mousePosition.x),
            transform.position.y - (mousePositionAfterZoom.y - mousePosition.y),
            -10
        );
        transform.position = offset;
    }

    private void checkBorder(){
        float positionX = transform.position.x;
        float positionY = transform.position.y;
        if(border.leftBorder && screenEdges.Left < border.leftBorder.position.x){
            positionX = border.leftBorder.position.x + screenEdges.Width / 2;
        }else
        
        if(border.rightBorder && screenEdges.Right > border.rightBorder.position.x){
            positionX = border.rightBorder.position.x - screenEdges.Width / 2;
            
        }

        if(border.botBorder && screenEdges.Bot < border.botBorder.position.y){
            positionY = border.botBorder.position.y + screenEdges.Height / 2;
        }else

        if(border.topBorder && screenEdges.Top > border.topBorder.position.y){
            positionY = border.topBorder.position.y - screenEdges.Height / 2;
        }

        transform.position = new Vector3(positionX,positionY,-10);
    }
}
