using System.Collections;
using UnityEngine;

public class LinearAiProcessManager : BaseAiProcessManager
{
    private BaseNpcAction currentAction;
    IEnumerator runningProcess;

    public override void pickAction()
    {
        if(currentAction) currentAction.resetValue();
        if(actionList.Count == 0){
            // Debug.Log("there is no action inside the Ai handler");
            return;
        }
        if(index < actionList.Count){
            currentAction = actionList[index];
            // Debug.Log("currentAction : "+currentAction.IsFinished);
            index++;
        }else currentAction = null;
    }

    public override void execute()
    {
        base.execute();
        runningProcess = AiProcess();
        StartCoroutine(runningProcess);
    }

    IEnumerator AiProcess(){
        pickAction();
        if(!currentAction){
            Debug.Log("Caroutine stopped");
            yield break;
        }
        do{
            if(currentAction.IsFinished){
                if(currentAction.IsFailed){
                    do{
                        pickAction();
                    }while(currentAction && !currentAction.isChained);
                }else pickAction();

            }else if(!currentAction.IsRunning){
                // Debug.Log("Running : "+currentAction);
                currentAction.setup(objectsRef);
                currentAction.execute();
            }
            yield return new WaitForFixedUpdate();
        }while(currentAction != null);
        isFinished = true;
    }
}
