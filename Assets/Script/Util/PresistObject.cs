using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresistObject : MonoBehaviour
{
    void Awake(){
        DontDestroyOnLoad(gameObject);
    }
}
