using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CostumerEnjoyMeal : BaseNpcBehavior
{
    public GameObject seat;
    protected FacilityData seatData;

    protected override void setup()
    {
        base.setup();
        // seat = null;
        // seatData = null;
    }

    public override void execute()
    {
        base.execute();
        seatData = seat.GetComponent<FacilityData>();
        Debug.Log("seat : "+seat);
        StartCoroutine(takeSeat());
    }

    protected IEnumerator takeSeat(){
        // while(!seat){
        //     getSeat();
        //     if(!seat) yield return new WaitForSeconds(1);
        // }

        movement.setTarget(seat.transform.position);

        while(!movement.IsReached){
            yield return new WaitForFixedUpdate();
        }

        setFlipSprite();
        StartCoroutine(enjoyMeal());
        yield break;
    }

    protected void setFlipSprite(){
        movement.setFlipX(seatData.isFacingLeft);
    }

    // protected void getSeat(){    
    //     GameObject[] seats = GameObject.FindGameObjectsWithTag("Seats");
    //     foreach(GameObject data in seats){
    //         seatData = data.GetComponent<FacilityData>();
    //         if(seatData.isAvailable){
    //             seat = data;
    //             seatData.isAvailable = false;
    //             break;
    //         }
    //     }
    // }


    protected IEnumerator enjoyMeal(){
        Debug.Log("enjoying Meal...");
        yield return new WaitForSeconds(5);
        finish();
        yield break;
    }

    protected override void finish()
    {
        base.finish();
    }

    public void finishSeat(){
        // seat = null;
        // seatData.isAvailable = true;
        // seatData = null;
        Costumer.findCostumerGroup(gameObject).seatsData.isAvailable = true;
    }

}
