using UnityEngine;

public class CostumerData : MonoBehaviour
{
    public Transform originalSeat;
    public BaseAiProcessManager hangoutAi;
    public Material outlineMaterial;

    private Material defaultMaterial;
    private SpriteRenderer spriteRenderer;

    public SpriteRenderer SpriteRenderer{
        get{return spriteRenderer;}
    }

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMaterial = spriteRenderer.material;
    }

    public void setOutlineMaterial(bool set){
        if(set) spriteRenderer.material = outlineMaterial;
        else spriteRenderer.material = defaultMaterial;
    }
}
