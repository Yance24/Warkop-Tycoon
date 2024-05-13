using System;
using System.Collections.Generic;
using UnityEngine;

public class ActionsDataList : MonoBehaviour
{
    [Serializable]
    private class ActionData{
        public string dataName;
        public GameObject data;
    }

    [SerializeField]
    private List<ActionData> actionDataList = new List<ActionData>();

    public GameObject getData(string name){
        ActionData actionData = actionDataList.Find(item => item.dataName == name);
        if(actionData != null) return actionData.data;
        else return null;
    }

    public void setData(string name, GameObject data){
        ActionData actionData = actionDataList.Find(item => item.dataName == name);
        if(actionData == null) actionDataList.Add(new ActionData{dataName = name, data = data});
        else actionData.data = data;
    }
    
}
