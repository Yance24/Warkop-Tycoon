using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMeshRendererOrder : MonoBehaviour
{
    public int orderLayer;

    private MeshRenderer meshRenderer;

    void Start(){
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.sortingOrder = orderLayer;
    }
}
