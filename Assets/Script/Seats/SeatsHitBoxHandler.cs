using Unity.VisualScripting;
using UnityEngine;

public class SeatsHitBoxHandler : MonoBehaviour, IInteractableObject
{
    private SeatsData data;

    void Start(){
        data = GetComponent<SeatsData>();
    }
    
    public void onClick()
    {
        if(data.IsOrdering && !NotaDataManager.Instance.isMaxed()){
            data.IsOrdering = false;
        }
    }
}
