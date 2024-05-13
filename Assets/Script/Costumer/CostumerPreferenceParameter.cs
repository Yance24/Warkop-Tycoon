using System;
using UnityEngine;

public class CostumerPreferenceParameter : BaseMenuParameter
{
    //parameter for picking menu based on their preference
    [SerializeField]
    [Range(0f,1f)]
    private float sweetTolerance;

    [SerializeField]
    [Range(0f,1f)]
    private float bitterTolerance;

    [SerializeField]
    private int spendExcpectation;

    [SerializeField]
    private int maxSpend;

    public int SpendExcpectation{
        get{return spendExcpectation;}
    }

    public int MaxSpend{
        get{return maxSpend;}
    }
}
