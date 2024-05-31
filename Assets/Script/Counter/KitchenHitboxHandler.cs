using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenHitboxHandler : MonoBehaviour, IInteractableObject
{
    public void onClick(){
        PlayerInputManager.Instance.addInputBuffer(new InputBuffer("Create Menu",null));
    }
}
