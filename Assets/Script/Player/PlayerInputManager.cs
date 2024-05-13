using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [Serializable]
    public class ActionHandler{
        public GameObject action;
        public string actionType;
    }
    [SerializeField]
    private List<ActionHandler> actionHandlers = new List<ActionHandler>();
    private List<InputBuffer> inputBufferList = new List<InputBuffer>();
    private PlayerNpcAction currentAction;
    private Transform currentData;
    private Coroutine currentProcessing;
    public void addInputBuffer(InputBuffer inputBuffer){
        inputBufferList.Add(inputBuffer);
    }

    void Start(){
        startBufferProcessing();
    }

    public void startBufferProcessing(){
        currentProcessing = StartCoroutine(bufferProcessing());
    }

    public void stopBufferProcessing(){
        StopCoroutine(currentProcessing);
    }

    private void pullInputBuffer(){
        InputBuffer currentBuffer = inputBufferList[0];
        int index = actionHandlers.FindIndex(item => item.actionType == currentBuffer.inputType);
        currentAction = actionHandlers[index].action.GetComponent<PlayerNpcAction>();
        currentData = currentBuffer.data;
        inputBufferList.Remove(currentBuffer);
    }

    IEnumerator bufferProcessing(){
        yield return null;
        while(true){
            if(inputBufferList.Count > 0 && !currentAction){
                pullInputBuffer();
                currentAction.setup(gameObject,currentData);
                currentAction.execute();
            }
            if(currentAction && currentAction.IsFinished) currentAction = null;
            yield return new WaitForFixedUpdate();
        }
    }
}
