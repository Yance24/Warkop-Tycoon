using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLightController : MonoBehaviour
{
    private Light2D light2D;

    void Start(){
        light2D = GetComponent<Light2D>();
    }

    void OnEnable(){
        DayCycle.TimeChange += UpdateLight;
    }

    void OnDisable(){
        DayCycle.TimeChange -= UpdateLight;
    }

    void UpdateLight(){
        //update light here

        // get hour time
        // int hour = DayCycle.CurrentHourTime;
    }
}
