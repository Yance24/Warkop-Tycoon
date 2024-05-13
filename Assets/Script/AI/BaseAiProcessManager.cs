using System.Collections.Generic;
using UnityEngine;

public class BaseAiProcessManager : MonoBehaviour
{
    protected List<BaseNpcAction> actionList = new List<BaseNpcAction>();
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

    public virtual void pickAction(){
        
    }

    public virtual void execute(){
        
    }

    public virtual void setup(List<GameObject> objRef){
        objectsRef = objRef;
    }

    public virtual void setup(GameObject objRef){
        objectsRef.Clear();
        objectsRef.Add(objRef);
    }

    void Awake(){
        foreach(Transform child in transform){
            actionList.Add(child.GetComponent<BaseNpcAction>());
        }
    }
}
