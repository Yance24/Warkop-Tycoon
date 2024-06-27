using System;
using System.Collections;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public static DayCycle Instance{get;private set;}
    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }
    public int openTime;
    public int closeTime;
    public int timeConvert;

    private static int currentHourTime;
    private static int currentMinuteTime;
    public static event Action TimeChange;
    public static bool IsDayEnd;

    public static string CurrentTime{
        get{
            string hourText;
            if(currentHourTime < 10) hourText = "0"+currentHourTime;
            else hourText = ""+currentHourTime;

            string minuteText;
            if(currentMinuteTime < 10) minuteText = "0"+currentMinuteTime;
            else minuteText = ""+currentMinuteTime;

            return hourText +" : "+ minuteText;
        }
    }

    public static int CurrentHourTime{
        get{return currentHourTime;}
    }

    void Start(){
        restartDay();
    }

    public void restartDay(){
        currentHourTime = openTime;
        currentMinuteTime = 0;
        StartCoroutine(countTime());
        TimeChange?.Invoke();
        IsDayEnd = false;
    }

    IEnumerator countTime(){
        yield return null;
        while(currentHourTime < closeTime){
            yield return new WaitForSeconds(timeConvert);
            currentMinuteTime += 10;
            if(currentMinuteTime >= 60){
                currentMinuteTime = 0;
                currentHourTime++;
            }
            TimeChange?.Invoke();
        }
        IsDayEnd = true;
        TimeChange?.Invoke();

        while(!BaseCostumerSpawner.Instance.isNoCostumer()){
            yield return new WaitForFixedUpdate();
        }
        endDaySequence();
    }

    void endDaySequence(){
        ShopUIManager.Instance.displayIngredientShop();
    }
}