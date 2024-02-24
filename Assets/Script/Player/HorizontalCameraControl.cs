using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalCameraControl : MonoBehaviour
{
    public float cameraSpeed;
    public float cameraAccel;
    public float cameraDecel;
    public float cameraHorizontalPan;
    public float cameraVerticalInputOffset;
    public Transform leftBorder;
    public Transform rightBorder;

    class ScreenEdges{
        public float top;
        public float bottom;
        public float right;
        public float left;

        public float worldLeft{
            get{return Camera.main.ScreenToWorldPoint(new Vector2(0,0)).x;}
        }

        public float worldRight{
            get{return Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,0)).x;}
        }

        public void showScreenSize(){
            Debug.Log("top = "+top);
            Debug.Log("bottom = "+bottom);
            Debug.Log("left = "+left);
            Debug.Log("right = "+right);
        }
    }
    private ScreenEdges screenEdges;
    private Vector2 mousePosition;
    private Vector2 moveDirection;
    private Vector2 bufferDirection;
    private float currentAcceleration;

    public float CurrentSpeed{
        get{return currentAcceleration;}
    }

    public Vector2 BufferDirection{
        get{return bufferDirection;}
    }
    
    // Start is called before the first frame update
    void Start()
    {
        screenEdges = new ScreenEdges();
        getScreenEdges();
    }

    private void getScreenEdges(){
        screenEdges.left = 0 + cameraHorizontalPan * Screen.width;
        screenEdges.right = Screen.width - cameraHorizontalPan * Screen.width;
        screenEdges.bottom = 0 + cameraVerticalInputOffset * Screen.height;
        screenEdges.top = Screen.height - cameraVerticalInputOffset * Screen.height;
    }


    void FixedUpdate(){
        checkInput();
        processAcceleration();
        checkBorder();
        executeMovement();
    }

    private void checkInput(){
        if(mousePosition.y >= screenEdges.bottom && mousePosition.y <= screenEdges.top){
            if(mousePosition.x >= screenEdges.right) moveDirection.x = 1;

            else if(mousePosition.x <= screenEdges.left) moveDirection.x = -1;

            else moveDirection = Vector2.zero;
        }else moveDirection = Vector2.zero;

        if(moveDirection != Vector2.zero) bufferDirection = moveDirection;
    }

    private void processAcceleration(){
        if(moveDirection != Vector2.zero) currentAcceleration += cameraAccel;
        else currentAcceleration -= cameraDecel;
        currentAcceleration = Mathf.Clamp(currentAcceleration,0,cameraSpeed);
    }

    private void checkBorder(){
        if(leftBorder && bufferDirection.x <= 0 && screenEdges.worldLeft <= leftBorder.position.x) currentAcceleration = 0;
        if(rightBorder && bufferDirection.x >= 0 && screenEdges.worldRight >= rightBorder.position.x) currentAcceleration = 0;
    }

    private void executeMovement(){
        transform.Translate(bufferDirection * currentAcceleration * Time.deltaTime);        
    }


    // Update is called once per frame
    void Update()
    {
        getMousePosition();
    }

    private void getMousePosition(){
        mousePosition = Input.mousePosition;
    }
}
