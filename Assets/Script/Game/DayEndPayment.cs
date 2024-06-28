using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayEndPayment : MonoBehaviour
{
    public static DayEndPayment Instance{private set; get;}
    public int price;

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }

    public void execute(){
        PlayerMoney.Money -= price;
        if(PlayerMoney.Money < 0){
            GameOverUI.Instance.gameOverSequence();
        }
    }
}
