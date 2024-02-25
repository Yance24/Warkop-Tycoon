using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BasicCostumerAI : BaseNpcAI
{
    private CostumerOrdering costumerOrdering;
    private CostumerEnjoyMeal costumerEnjoyMeal;

    
    private BaseNpcBehavior currentAction;

    void Awake()
    {
        costumerOrdering = GetComponent<CostumerOrdering>();
        costumerEnjoyMeal = GetComponent<CostumerEnjoyMeal>();
        Invoke("pickAction",0.1f);
    }

    public override void pickAction(){
        currentAction = null;
        if(!costumerOrdering.IsFinished) currentAction = costumerOrdering;
        else if(!costumerEnjoyMeal.IsFinished) currentAction = costumerEnjoyMeal;

        if(currentAction){
            currentAction.execute();
            StartCoroutine(checkFinished());
        }
    }

    IEnumerator checkFinished(){
        while(!currentAction.IsFinished) yield return new WaitForFixedUpdate();
        Invoke("pickAction",0.1f);
        yield break;
    }

    private void consider(){

    }
}
