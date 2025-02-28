using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoTo : PlayerNpcAction
{
    public Transform target;
    public bool waitForArrival = true;

    private List<BaseObjectsMovement> movements = new List<BaseObjectsMovement>();

    public override void execute()
    {
        base.execute();
        StartCoroutine(ActionProcess());
    }

    protected virtual void setupTarget(){
        //override target
    }

    private void setupObjectMovement(){
        foreach(GameObject objects in objectsRef){
            movements.Add(objects.GetComponent<BaseObjectsMovement>());
        }
    }

    private void gotoTarget(){
        foreach(BaseObjectsMovement movement in movements){
            movement.setTarget(target);
        }
    }

    private bool hasReachedSeats(){
        foreach(BaseObjectsMovement movement in movements){
            if(!movement.IsReached) return false;
        }
        return true;
    }

    IEnumerator ActionProcess(){
        yield return null;
        setupTarget();
        if(target == null){
            failed();
            yield break;
        }
        setupObjectMovement();
        gotoTarget();
        while(!hasReachedSeats() && waitForArrival){
            yield return new WaitForFixedUpdate();
        }
        finish();
        yield return new WaitForSeconds(0);
    }
}
