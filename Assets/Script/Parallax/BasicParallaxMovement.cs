using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicParallaxMovement : MonoBehaviour
{
    public GameObject mainCamera;
    public bool inverseMovement = false;
    public float offsetMultiplier;

    private Vector2 cameraStartPosition;
    private Vector2 objectStartPosition;

    // Start is called before the first frame update
    void Start()
    {
        cameraStartPosition = mainCamera.transform.position;
        objectStartPosition = transform.position;
    }

    void FixedUpdate(){
        if(mainCamera){
            Vector2 cameraOffset = new Vector2(mainCamera.transform.position.x - cameraStartPosition.x, mainCamera.transform.position.y - cameraStartPosition.y) * offsetMultiplier;
            if(inverseMovement){
                transform.position = new Vector2(objectStartPosition.x - cameraOffset.x, objectStartPosition.y - cameraOffset.y);
            }else{
                transform.position = new Vector2(objectStartPosition.x + cameraOffset.x, objectStartPosition.y + cameraOffset.y);
            }
        }
    }
}
