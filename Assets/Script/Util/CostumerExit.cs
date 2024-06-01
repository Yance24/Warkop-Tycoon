using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CostumerExit : MonoBehaviour
{
    public static CostumerExit Instance{get; private set;}

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }
}
