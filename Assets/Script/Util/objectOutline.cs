using UnityEngine;

public class HoverOutline : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Material outlineMaterial;
    private Material defaultMaterial;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMaterial = spriteRenderer.material;
    }

    void OnMouseEnter()
    {
        spriteRenderer.material = outlineMaterial;
    }

    void OnMouseExit()
    {
        spriteRenderer.material = defaultMaterial;
    }
}
