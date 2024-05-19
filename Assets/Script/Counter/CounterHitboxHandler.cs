using UnityEngine;

public class CounterHitboxHandler : MonoBehaviour, IInteractableObject
{
    public void onClick(){
        MenuMakerManager.Instance.createMenu();
    }
}
