using System.Collections;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public int secondsCycle;
    public int minutesCycle;
    public int hoursCycle;

    private int percentage;

    // Start is called before the first frame update
    void Start()
    {
        InGameTime.resetTime();
        StartCoroutine(trackTime());
    }

    IEnumerator trackTime(){
        while(checkEndCycle()){
            yield return new WaitForSeconds(1);
            InGameTime.Seconds++;
            setPercentage();
            // Debug.Log(InGameTime.getTime());
        }
        Debug.Log("EndCycle!!");
        InGameTime.closingTime = true;
        StartCoroutine(handleEndCycle());
    }

    bool checkEndCycle(){
        if(
            InGameTime.Hours >= hoursCycle &&
            InGameTime.Minutes >= minutesCycle &&
            InGameTime.Seconds >= secondsCycle 
        )return false;
        return true;
    }

    void setPercentage(){
        int currentTotalTime = (InGameTime.Hours * 3600) + (InGameTime.Minutes * 60) + InGameTime.Seconds;
        int cycleTotalTime = (hoursCycle * 3600) + (minutesCycle * 60) + secondsCycle;
        percentage = 100 * currentTotalTime / cycleTotalTime;
    }

    
    IEnumerator handleEndCycle(){
        while(!Costumer.noCostumer()){
            yield return new WaitForSeconds(1);
        }
        // Debug.Log("Closing!!");
        yield break;
    }
}