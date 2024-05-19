using UnityEngine;

public interface IInteractableObject
{
    void onClick(){
        // Debug.Log("object clicked!");
    }

    void onEnter(){
        // Debug.Log("object hovered!");
    }

    void onExit(){
        // Debug.Log("object not hovered!");
    }
}
