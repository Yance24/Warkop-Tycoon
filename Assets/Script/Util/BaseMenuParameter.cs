using System;
using UnityEngine;

public class BaseMenuParameter : MonoBehaviour
{
    [Serializable]
    public enum temp{
        Hot, Cold, Both
    }

    [SerializeField]
    private int sweet;

    [SerializeField]
    private int bitter;

    [SerializeField]
    private temp temperature;
    
    public int Sweet{
        get{return sweet;}
    }
    public int Bitter{
        get{return bitter;}
    }
    public temp Temp{
        get{return temperature;}
    }
}
