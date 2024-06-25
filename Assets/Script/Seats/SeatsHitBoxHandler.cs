using Unity.VisualScripting;
using UnityEngine;

public class SeatsHitBoxHandler : MonoBehaviour, IInteractableObject
{
    private SeatsData data;
    [SerializeField]
    private Material outlineMaterial;
    private Material defaultMaterial;
    private SpriteRenderer spriteRenderer;

    void Start(){
        data = GetComponent<SeatsData>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMaterial = spriteRenderer.material;
    }
    
    public void onClick()
    {
        if(data.IsOrdering && !NotaDataManager.Instance.isMaxed()){
            data.IsOrdering = false;
            spriteRenderer.material = defaultMaterial;
            data.getOccupiedBy().SetCostumerOutline(false);
        }
    }

    public void onEnter(){
        if(data.IsOrdering){
            spriteRenderer.material = outlineMaterial;
            data.getOccupiedBy().SetCostumerOutline(true);
        }
    }
    public void onExit(){
        if(data.IsOrdering){
            spriteRenderer.material = defaultMaterial;
            data.getOccupiedBy().SetCostumerOutline(false);
        }
    }
}
