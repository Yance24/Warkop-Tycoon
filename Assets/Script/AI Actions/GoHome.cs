using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : BaseNpcAction
{
    private List<BaseObjectsMovement> movement = new List<BaseObjectsMovement>();
    public override void execute()
    {
        base.execute();
        StartCoroutine(ActionProcess());
    }

    private void setupObjectMovement(){
        foreach(GameObject objectRef in objectsRef){
            movement.Add(objectRef.GetComponent<BaseObjectsMovement>());
        }
    }

    private void setTarget(){
        foreach(BaseObjectsMovement movementObject in movement){
            movementObject.setTarget(CostumerExit.Instance.transform);
        }
    }

    private bool hasReached(){
        foreach(BaseObjectsMovement movementObject in movement){
            if(!movementObject.IsReached) return false;
        }
        return true;
    }

    IEnumerator ActionProcess(){
        yield return null;

        setupObjectMovement();
        setTarget();
        while(!hasReached()){
            yield return new WaitForFixedUpdate();
        }

        // Destroy(((CostumerGroupManager) actionsDataList.getData("Group Manager")).gameObject);
        BaseCostumerSpawner.Instance.removeCostumer(((CostumerGroupManager) actionsDataList.getData("Group Manager")).gameObject);
        finish();
        yield break;
    }
}
