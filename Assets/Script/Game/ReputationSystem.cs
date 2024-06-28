using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReputationSystem : MonoBehaviour
{
    public static ReputationSystem Instance{private set; get;}

    public int maxReputation;
    private int currentReputation = 0;

    public static Action RepChange;

    public int CurrentReputation{
        get{return currentReputation;}
        set{
            currentReputation = value;
            if(currentReputation > maxReputation){
                currentReputation = maxReputation;
            }else if(currentReputation <= 0){
                GameOverUI.Instance.gameOverSequence();
            }
            RepChange?.Invoke();
        }
    }

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }
    
}
