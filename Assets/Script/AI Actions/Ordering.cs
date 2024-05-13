using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ordering : BaseNpcAction
{
    public int averageWaitingInSeconds;
    public int waitingTimeDeviation;
    public GameObject notaUI;
    public MenuAvailable menuAvailable;

    private SeatsData data;
    private List<CostumerPreferenceParameter> costumerParameter;
    private List<MenuParameter> menuParameters;


    public override void execute()
    {
        base.execute();
        StartCoroutine(ActionProcess());
    }

    private bool setupHitBoxHandler(){
        data = actionsDataList.getData("currentSeat").GetComponent<SeatsData>();
        return data;
    }

    private bool setupPickMenu(){
        foreach(GameObject costumer in objectsRef){
            costumerParameter.Add(costumer.GetComponent<CostumerPreferenceParameter>());
        }
        menuParameters = menuAvailable.menuItem;
        return true;
    }

    IEnumerator ActionProcess(){
        yield return null;

        //calling the player
        if(!setupHitBoxHandler()){
            failed();
            yield break;
        }
        data.IsOrdering = true;
        
        //wait for the player to respond
        while(data.IsOrdering){
            yield return new WaitForFixedUpdate();
        }

        //Deciding which menu to pick
        if(!setupPickMenu()){
            failed();
            yield break;
        }

        
        

        finish();
        yield break;
    }
}