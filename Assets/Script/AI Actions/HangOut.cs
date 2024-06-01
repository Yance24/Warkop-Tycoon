using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HangOut : BaseNpcAction
{
    public int averageTime;
    public int deviationTime;

    private int currentTime;

    public override void execute()
    {
        base.execute();
        StartCoroutine(ActionProcess());
    }

    private void getWaitingTime(){
        int random = Random.Range(1,deviationTime + 1);
        random -= deviationTime;
        currentTime = averageTime + random;
    }

    IEnumerator ActionProcess(){
        yield return null;
        getWaitingTime();
        while(currentTime > 0){
            currentTime--;
            yield return new WaitForSeconds(1);
        }
        finish();
    }
}
