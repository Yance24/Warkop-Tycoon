using System;
using UnityEngine;

public class CostumerPreferenceParameter : BaseMenuParameter
{
    //parameter for picking menu based on their preference
    [SerializeField]
    [Range(0f,1f)]
    private float sweetTolerance;

    public int SweetTolerance{
        get{return (int) (sweetTolerance * 100);}
    }

    [SerializeField]
    [Range(0f,1f)]
    private float bitterTolerance;

    public int BitterTolerance{
        get{return (int) (bitterTolerance * 100);}
    }

    [SerializeField]
    private int spendExcpectation;
    [SerializeField]
    [Range(0f, 1f)]
    private float spendTolerance;

    [SerializeField]
    private int maxSpend;

    public int SpendExcpectation{
        get{return spendExcpectation;}
    }

    public float SpendTolerance{
        get{return spendTolerance / 100f;}
    }

    public int MaxSpend{
        get{return maxSpend;}
    }
}
