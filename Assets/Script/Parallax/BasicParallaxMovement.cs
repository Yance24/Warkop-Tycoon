using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicParallaxMovement : MonoBehaviour
{
    public GameObject mainCamera;
    public bool inverseMovement = false;
    public float speedMultiplier;

    private HorizontalCameraControl cameraController;

    // Start is called before the first frame update
    void Start()
    {
        cameraController = mainCamera.GetComponent<HorizontalCameraControl>();
    }

    void FixedUpdate(){
        if(cameraController){
            if(!inverseMovement) transform.Translate(cameraController.BufferDirection * cameraController.CurrentSpeed * speedMultiplier * Time.fixedDeltaTime);
            else transform.Translate(cameraController.BufferDirection * (cameraController.CurrentSpeed * -1) * speedMultiplier * Time.fixedDeltaTime);
        }
    }
}
