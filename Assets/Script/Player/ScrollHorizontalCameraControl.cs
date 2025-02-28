// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ScrollHorizontalCameraControl : MonoBehaviour
// {
//     public float cameraSpeed;
//     public float cameraAccel;
//     public float cameraDecel;
//     public float cameraHorizontalPan;
//     public float cameraVerticalInputOffset;
//     public Transform leftBorder;
//     public Transform rightBorder;
    
//     private bool isActive = true;

//     public bool IsActive{
//         get{return isActive;}
//         set{isActive = value;}
//     }

//     private ScreenEdges screenEdges;
//     private Vector2 mousePosition;
//     private Vector2 moveDirection;
//     private Vector2 bufferDirection;
//     private float currentAcceleration;

//     public float CurrentSpeed{
//         get{return currentAcceleration;}
//     }

//     public Vector2 BufferDirection{
//         get{return bufferDirection;}
//     }
    
//     // Start is called before the first frame update
//     void Start()
//     {
//         screenEdges = new ScreenEdges();
//     }

//     private void getScreenEdges(){
//         screenEdges.left = 0 + cameraHorizontalPan * Screen.width;
//         screenEdges.right = Screen.width - cameraHorizontalPan * Screen.width;
//         screenEdges.bottom = 0 + cameraVerticalInputOffset * Screen.height;
//         screenEdges.top = Screen.height - cameraVerticalInputOffset * Screen.height;
//     }


//     void FixedUpdate(){
//         if(isActive){
//             getScreenEdges();
//             checkInput();
//             processAcceleration();
//             checkBorder();
//             executeMovement();
//         }
//     }

//     private void checkInput(){
//         if(mousePosition.y >= 0 && mousePosition.x >= 0 && mousePosition.x <= Screen.width && mousePosition.y <= Screen.height)
//         if(mousePosition.y >= screenEdges.bottom && mousePosition.y <= screenEdges.top){
//             if(mousePosition.x >= screenEdges.right) moveDirection.x = 1;

//             else if(mousePosition.x <= screenEdges.left) moveDirection.x = -1;

//             else moveDirection = Vector2.zero;
//         }else moveDirection = Vector2.zero;
//         else moveDirection = Vector2.zero;

//         if(moveDirection != Vector2.zero) bufferDirection = moveDirection;
//     }

//     private void processAcceleration(){
//         if(moveDirection != Vector2.zero) currentAcceleration += cameraAccel;
//         else currentAcceleration -= cameraDecel;
//         currentAcceleration = Mathf.Clamp(currentAcceleration,0,cameraSpeed);
//     }

//     private void checkBorder(){
//         if(leftBorder && bufferDirection.x <= 0 && screenEdges.worldLeft <= leftBorder.position.x) currentAcceleration = 0;
//         if(rightBorder && bufferDirection.x >= 0 && screenEdges.worldRight >= rightBorder.position.x) currentAcceleration = 0;
//     }

//     private void executeMovement(){
//         transform.Translate(bufferDirection * currentAcceleration * Time.deltaTime);        
//     }


//     // Update is called once per frame
//     void Update()
//     {
//         getMousePosition();
//     }

//     private void getMousePosition(){
//         mousePosition = Input.mousePosition;
//     }
// }
