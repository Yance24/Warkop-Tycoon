using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager Instance{get; private set;}
    [Serializable]
    public class ActionHandler{
        public BaseAiProcessManager actionString;
        public string actionType;
    }
    [SerializeField]
    private List<ActionHandler> actionHandlers = new List<ActionHandler>();
    private List<InputBuffer> inputBufferList = new List<InputBuffer>();
    private BaseAiProcessManager currentProcess;
    private Transform currentData;
    private Coroutine currentProcessing;
    public void addInputBuffer(InputBuffer inputBuffer){
        inputBufferList.Add(inputBuffer);
    }

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
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
        currentProcess = actionHandlers[index].actionString;
        currentData = currentBuffer.data;
        inputBufferList.Remove(currentBuffer);
    }

    IEnumerator bufferProcessing(){
        yield return null;
        while(true){
            if(inputBufferList.Count > 0 && !currentProcess){
                pullInputBuffer();
                // Debug.Log("Current Buffer: "+currentProcess.name);
                currentProcess.setup(gameObject);
                currentProcess.execute();
                // Debug.Log("inputBuffer List: ");
                foreach(InputBuffer inputBuffer in inputBufferList){
                    Debug.Log(inputBuffer.inputType);
                }
            }
            if(currentProcess && currentProcess.IsFinished) {
                // Debug.Log(currentProcess.name +" Buffer is finished");
                currentProcess = null;
            }
            yield return new WaitForFixedUpdate();
        }
    }
}
