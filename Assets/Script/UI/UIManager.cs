using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance{get;private set;}

    void Awake(){
        if(!Instance)Instance = this;
        else Destroy(gameObject);
    }

    [Serializable]
    private class UIData{
        public string name;
        public GameObject uiObject;
    }

    [SerializeField]
    private List<UIData> uiObjects = new List<UIData>();

    public GameObject getUI(string name){
        UIData uiData = uiObjects.Find(item => item.name == name);
        if(uiData != null) return uiData.uiObject;
        else return null;
    }
}
