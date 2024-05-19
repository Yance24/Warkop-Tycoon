using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMouseRaycast : MonoBehaviour
{
    private LayerMask layerMask;
    private IInteractableObject lastObject;

    void Start(){
        // layerMask = LayerMask.GetMask("");
    }
    // Update is called once per frame
    void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject()) return;
        
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition,Vector2.zero);

        if(lastObject != null){
            lastObject.onExit();
            lastObject = null;
        }
        if(hit.collider != null){
            IInteractableObject interactableObject = hit.collider.GetComponent<IInteractableObject>();
            if(interactableObject == null) return;

            if(Input.GetMouseButtonDown(0))
                interactableObject.onClick();
            else
                interactableObject.onEnter();
            
            lastObject = interactableObject;
        }
    }
}
