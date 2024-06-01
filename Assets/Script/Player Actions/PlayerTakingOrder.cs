// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerTakingOrder : PlayerNpcAction
// {
//     private PlayerMovement movement;
//     private Transform targetSeat;

//     public override void execute()
//     {
//         base.execute();
//         StartCoroutine(ActionProcess());
//     }

//     public override void setup(GameObject objRef, Transform data)
//     {
//         base.setup(objRef, data);
//         targetSeat = data;
//     }

//     private bool setupPlayerMovement(){
//         movement = objectsRef[0].GetComponent<PlayerMovement>();
//         if(movement) movement.setTarget(targetSeat.position);
//         return movement;
//     }

//     IEnumerator ActionProcess(){
//         setupPlayerMovement();
//         if(!movement) {
//             failed();
//             yield break;
//         }
        
//         //check if player have reached the targeted seats
//         while(!movement.IsReached){
//             yield return new WaitForFixedUpdate();
//         }

//         //player taking orders


//         yield break;
//     }
// }
