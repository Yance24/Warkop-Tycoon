// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Rendering;

// public class BasicCostumerAI : BaseNpcAI
// {
//     private CostumerOrdering costumerOrdering;
//     private CostumerEnjoyMeal costumerEnjoyMeal;
//     private CostumerGoHome costumerGoHome;

//     private BaseNpcBehavior currentAction;

//     void Awake()
//     {
//         costumerOrdering = GetComponent<CostumerOrdering>();
//         costumerEnjoyMeal = GetComponent<CostumerEnjoyMeal>();
//         costumerGoHome = GetComponent<CostumerGoHome>();
//         Invoke("pickAction",0.1f);
//     }

//     public override void pickAction(){
//         currentAction = null;
//         if(!costumerOrdering.IsFinished) currentAction = costumerOrdering;
//         else if(!costumerEnjoyMeal.IsFinished) currentAction = costumerEnjoyMeal;
//         else{
//             costumerEnjoyMeal.finishSeat();
//             currentAction = costumerGoHome;
//         }

//         if(currentAction){
//             currentAction.execute();
//             StartCoroutine(checkFinished());
//         }
//     }

//     IEnumerator checkFinished(){
//         while(!currentAction.IsFinished) yield return new WaitForFixedUpdate();
//         pickAction();
//         yield break;
//     }

//     private void consider(){

//     }
// }
