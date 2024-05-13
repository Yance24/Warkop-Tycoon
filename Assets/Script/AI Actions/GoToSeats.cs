using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToSeats : BaseNpcAction
{
    private List<CostumerMovement> objectMovement = new List<CostumerMovement>();

    public override void execute(){
        base.execute();
        StartCoroutine(ActionProcess());
    }

    private void setupObjectMovement(){
        foreach(GameObject gameObject in objectsRef){
            objectMovement.Add(gameObject.GetComponent<CostumerMovement>());
        }
    }

    private void goesToSeats(){
        for(int i = 0; i < objectsRef.Count; i++){
            objectMovement[i].setTarget(objectsRef[i].GetComponent<CostumerData>().originalSeat);
        }
    }

    private bool hasReachedSeats(){
        foreach(CostumerMovement costumerMovement in objectMovement){
            if(!costumerMovement.IsReached) return false;
        }
        return true;
    }

    IEnumerator ActionProcess(){
        yield return null;
        //goes to seat
        if(objectMovement.Count == 0)setupObjectMovement();

        goesToSeats();
        while(!hasReachedSeats())
            yield return new WaitForFixedUpdate();
        
        Debug.Log("Has Reached");
        finish();
        yield break;
    }
}
