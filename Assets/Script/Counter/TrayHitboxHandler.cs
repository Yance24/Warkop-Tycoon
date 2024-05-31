using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayHitboxHandler : MonoBehaviour, IInteractableObject
{
    public void onClick(){
        PlayerInputManager.Instance.addInputBuffer(new InputBuffer("Serve Drink",null));
    }
}
