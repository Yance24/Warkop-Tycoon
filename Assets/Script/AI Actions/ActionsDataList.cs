using System;
using System.Collections.Generic;
using UnityEngine;

public class ActionsDataList : MonoBehaviour
{
    [Serializable]
    private class ActionData{
        public string dataName;
        public object data;
    }

    [SerializeField]
    private List<ActionData> actionDataList = new List<ActionData>();

    public object getData(string name){
        ActionData actionData = actionDataList.Find(item => item.dataName == name);
        if(actionData != null) return actionData.data;
        else return null;
    }

    public void setData(string name, object data){
        ActionData actionData = actionDataList.Find(item => item.dataName == name);
        if(actionData == null) actionDataList.Add(new ActionData{dataName = name, data = data});
        else actionData.data = data;
    }
    
}
