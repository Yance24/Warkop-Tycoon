using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedUpTime : MonoBehaviour
{
    public KeyCode keyCode;
    public float timeScale;
    void Update()
    {
        if(Input.GetKey(keyCode)){
            Time.timeScale = timeScale;
        }else{
            Time.timeScale = 1;
        }
    }

    void FixedUpdate(){
    }
}