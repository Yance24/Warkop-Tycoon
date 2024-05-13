using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNpcAction : MonoBehaviour
{
    protected ActionsDataList actionsDataList;
    protected List<GameObject> objectsRef;
    protected bool isRunning = false;
    protected bool isFinished = false;
    protected bool isFailed = false;
    public bool isChained = false;

    public bool IsFinished{
        get{return isFinished;}
    }

    public bool IsFailed{
        get{return isFailed;}
    }

    public bool IsRunning{
        get{return isRunning;}
    }

    public void setup(List<GameObject> objsRef){
        objectsRef = objsRef;
        actionsDataList = transform.parent.GetComponent<ActionsDataList>();
    }

    public void setup(GameObject objRef){
        objectsRef.Clear();
        objectsRef.Add(objRef);
        actionsDataList = transform.parent.GetComponent<ActionsDataList>();
    }

    public virtual void execute(){
        isFinished = false;
        isRunning = true;
    }

    protected virtual void finish(){
        isFinished = true;
        isRunning = false;
        isFailed = false;
    }

    protected virtual void failed(){
        isFinished = true;
        isRunning = false;
        isFailed =true;
    }
}