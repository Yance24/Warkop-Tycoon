using UnityEngine;
using UnityEngine.UI;

public class HoverOutlineImg : MonoBehaviour
{
    private Image image;
    public Material outlineMaterial;
    private Material defaultMaterial;

    void Start()
    {
        image = GetComponent<Image>();
        defaultMaterial = image.material;

    }

    void OnMouseEnter()
    {

        image.material = outlineMaterial;
    }

    void OnMouseExit()
    {
        image.material = defaultMaterial;
    }
}
