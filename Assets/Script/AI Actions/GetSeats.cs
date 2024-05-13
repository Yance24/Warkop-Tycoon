using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GetSeats : BaseNpcAction
{
    public int averageWaitingInSeconds;
    public int watingTimeDeviation;
    // public CostumerGroupManager passSeatsData;

    private SeatsData targetSeat;
    private int maxWaitingTime;

    public override void execute(){
        base.execute();
        StartCoroutine(ActionProcess());
    }

    private void setupWaitingTime(){
        maxWaitingTime = Random.Range(averageWaitingInSeconds - watingTimeDeviation, averageWaitingInSeconds + watingTimeDeviation);
    }

    private bool getSeats(){
        GameObject[] seats = GameObject.FindGameObjectsWithTag("Seats");
        SeatsData seatRef = null;
        foreach(GameObject data in seats){
            SeatsData seatData = data.GetComponent<SeatsData>();
            if(seatData.isAvailable && !seatData.IsOccupied && seatData.chairs.Count >= objectsRef.Count){
                if(!seatRef || seatRef.chairs.Count > seatData.chairs.Count){
                    seatRef = seatData;
                    actionsDataList.setData("currentSeat",data);
                }
            }
        }
        if(seatRef){
            targetSeat = seatRef;
            targetSeat.setOccupied(objectsRef);
            return true;
        }else return false;
    }

    private bool setupTargetSeats(){
        for(int i = 0; i < objectsRef.Count; i++){
            Transform targetChair = targetSeat.chairs[i].transform;
            objectsRef[i].GetComponent<CostumerData>().originalSeat = targetChair;
        }
        return false;
    }


    IEnumerator ActionProcess(){
        yield return null;
        // Getting targeted Seats
        int currentWaitingTime = 0;
        setupWaitingTime();
        while(!getSeats()){
            if(currentWaitingTime++ >= maxWaitingTime){
                failed();
                yield break;
            }
            yield return new WaitForSeconds(1);
        }
        if(setupTargetSeats()){
            failed();
            yield break;
        }
        finish();
        yield break;
    }
}
