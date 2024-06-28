// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Rendering;
// using UnityEngine.Rendering.Universal;

// public class GlobalLightController : MonoBehaviour
// {
//     private Light2D light2D;
//     private Volume volume;

//     private float currentWeight = 0;
//     private float multiplier;

//     void Start(){
//         light2D = GetComponent<Light2D>();
//         volume = GetComponent<Volume>();
//         Debug.Log(volume);
//         Debug.Log(currentWeight);
//         multiplier = 1 / (22 - 17) / 6;

//     }

//     void OnEnable(){
//         DayCycle.TimeChange += UpdateLight;
//     }

//     void OnDisable(){
//         DayCycle.TimeChange -= UpdateLight;
//     }

//     void UpdateLight(){
//         //update light here
//         if(DayCycle.CurrentHourTime >= 17){
//             currentWeight += multiplier;
//             if(currentWeight > 1){
//                 currentWeight = 1;
//             }
//         }else{
//             currentWeight = 0;
//         }
//         // get hour time
//         // int hour = DayCycle.CurrentHourTime;
//         volume.weight = currentWeight;
//     }
// }
