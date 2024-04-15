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

    void Start(){
        currentZoom = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if(scroll > 0f){
            currentZoom -= zoomSensitivity;
            if(currentZoom < minZoom) currentZoom = minZoom;
        }else if(scroll < 0f){
            currentZoom += zoomSensitivity;
            if(currentZoom > maxZoom) currentZoom = maxZoom;
        }
    }

    void FixedUpdate(){
        Camera.main.orthographicSize = currentZoom;
    }
}
