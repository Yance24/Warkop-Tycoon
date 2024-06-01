using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoTo : PlayerNpcAction
{
    public Transform target;

    private List<BaseObjectsMovement> movements = new List<BaseObjectsMovement>();

    public override void execute()
    {
        base.execute();
        StartCoroutine(ActionProcess());
    }

    // private void setupTarget(){
    //     if(data != null) target = data;
    // }

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
        // setupTarget();
        setupObjectMovement();
        gotoTarget();
        while(!hasReachedSeats()){
            yield return new WaitForFixedUpdate();
        }
        finish();
        yield return new WaitForSeconds(0);
    }
}
