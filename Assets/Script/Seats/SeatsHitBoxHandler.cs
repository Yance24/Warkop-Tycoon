using System.Collections.Generic;
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
            setOutlineMaterial(data.getOccupiedBy().costumerObjects,true);
            setOutlineMaterial(data.chairs,true);
        }
    }

    public void onEnter(){
        if(data.IsOrdering){
            spriteRenderer.material = outlineMaterial;
            setOutlineMaterial(data.getOccupiedBy().costumerObjects,true);
            setOutlineMaterial(data.chairs,true);
        }
    }
    public void onExit(){
        if(data.IsOrdering){
            spriteRenderer.material = defaultMaterial;
            setOutlineMaterial(data.getOccupiedBy().costumerObjects,false);
            setOutlineMaterial(data.chairs,false);
        }
    }

    public void setOutlineMaterial(List<GameObject> gameObjects,bool set){
        foreach(GameObject obj in gameObjects){
            obj.GetComponent<SpriteRenderer>().material = set? outlineMaterial : defaultMaterial ;
        }
    }
}
