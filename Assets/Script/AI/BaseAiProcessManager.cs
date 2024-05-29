using System.Collections.Generic;
using UnityEngine;

public class BaseAiProcessManager : MonoBehaviour
{
    protected List<BaseNpcAction> actionList = new List<BaseNpcAction>();
    protected List<GameObject> objectsRef = new List<GameObject>();
    protected int index = 0;
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

    public virtual void pickAction(){
        
    }

    public virtual void execute(){
        isRunning = true;
    }

    protected void resetValue(){
        isRunning = false;
        isFinished = false;
        isFailed = false;
        index = 0;
    }

    public virtual void setup(List<GameObject> objRef){
        resetValue();
        objectsRef = objRef;
    }

    public virtual void setup(GameObject objRef){
        resetValue();
        objectsRef.Clear();
        objectsRef.Add(objRef);
    }

    void Awake(){
        foreach(Transform child in transform){
            if(child.gameObject.activeSelf) actionList.Add(child.GetComponent<BaseNpcAction>());
        }
    }
}
