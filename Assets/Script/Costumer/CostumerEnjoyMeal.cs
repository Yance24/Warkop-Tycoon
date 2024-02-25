using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CostumerEnjoyMeal : BaseNpcBehavior
{
    protected GameObject seat;
    protected FacilityData seatData;

    public override void execute()
    {
        base.execute();
        seat = null;
        StartCoroutine(takeSeat());
    }

    protected IEnumerator takeSeat(){
        while(!seat){
            getSeat();
            yield return new WaitForSeconds(1);
        }

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

    protected void getSeat(){    
        GameObject[] seats = GameObject.FindGameObjectsWithTag("Seats");
        foreach(GameObject data in seats){
            seatData = data.GetComponent<FacilityData>();
            if(seatData.isAvailable){
                seat = data;
                seatData.isAvailable = false;
                movement.setTarget(data.transform.position);
                break;
            }
        }
    }


    protected IEnumerator enjoyMeal(){
        Debug.Log("enjoying Meal...");
        yield return new WaitForSeconds(100);
        finish();
        yield break;
    }

    protected override void finish()
    {
        seatData.isAvailable = true;
        base.finish();
    }

}
