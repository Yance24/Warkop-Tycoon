using System;
using UnityEngine;

public class DateTracker : MonoBehaviour
{
    public static DateTracker Instance{get; private set;}

    [Serializable]
    public class Date{
        public int week;
        public int month;
        public int year;
    }
    [SerializeField]
    private Date currentDate = new Date();

    public Date CurrentDate{
        get{return currentDate;}
        set{currentDate = value;}
    }

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }

    public void nextWeek(){
        currentDate.week += 1;

        if(currentDate.week > 4){

            currentDate.week = 1;
            currentDate.month += 1;

            if(currentDate.month > 12){
                currentDate.month = 1;
                currentDate.year += 1;
            }
        }
    }
}
