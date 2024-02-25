using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BaseNpcBehavior : MonoBehaviour
{
    protected CostumerMovement movement;
    protected bool isRunning = false;
    protected bool isFinished = false;

    public bool IsFinished{
        get{return isFinished;}
    }

    void Start(){
        setup();
    }

    protected virtual void setup(){
        movement = GetComponent<CostumerMovement>();
    }

    public virtual void execute(){
        isFinished = false;
        isRunning = true;
    }

    protected virtual void finish(){
        isFinished = true;
    }
}
