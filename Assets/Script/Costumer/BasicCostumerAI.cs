using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BasicCostumerAI : MonoBehaviour
{
    private bool isAlreadyOrdering = false;
    private bool isAlreadySeated = false;
    private bool isAlreadyFinish = false;
    private CostumerMovement movement;

    public bool IsAlreadyOrdering{
        set{
            isAlreadyOrdering = value;
            pickAction();
        }
    }
    public bool IsAlreadySeated{
        set{
            isAlreadySeated = value;
            pickAction();
        }
    }
    public bool IsAlreadyFinish{
        set{
            isAlreadyFinish = value;
            pickAction();
        }
    }

    void Awake()
    {
        movement = GetComponent<CostumerMovement>();
        pickAction();
    }

    private void pickAction(){
        if(!isAlreadyOrdering) StartCoroutine(ordering());
        else if(!isAlreadySeated) StartCoroutine(takeSeat());
        else if(isAlreadyFinish) consider();
    }

    IEnumerator ordering(){
        yield return new WaitForFixedUpdate();
        GameObject counter = GameObject.FindGameObjectWithTag("Counter");
        CounterData counterData = counter.GetComponent<CounterData>();        
        counterData.npcLines.Add(transform.gameObject);
        // Debug.Log("Add : "+transform.gameObject);

        while(!movement.IsReached){
            checkCounter(counter,counterData);
            yield return new WaitForFixedUpdate();
        }

        // counterData.isAvailable = false;
        yield return new WaitForSeconds(5);
        // counterData.isAvailable = true;
        isAlreadyOrdering = true;
        counterData.npcLines.Remove(transform.gameObject);
        pickAction();
        yield break;
    }

    private void checkCounter(GameObject counter, CounterData data){
        if(data.getIndex(transform.gameObject) == 0) movement.setTarget(counter.transform.position,true);
        else 
            if(data.isFacingLeft)
                movement.setTarget(new Vector2(counter.transform.position.x - data.lineLength * data.getIndex(transform.gameObject),transform.position.y),false);
            else
                movement.setTarget(new Vector2(counter.transform.position.x + data.lineLength * data.getIndex(transform.gameObject),transform.position.y),false);
            

        if(!movement.IsMoving) {
            movement.setFlipX(!data.isFacingLeft);
        }

    }

    IEnumerator takeSeat(){
        GameObject[] seats = GameObject.FindGameObjectsWithTag("Seats");
        FacilityData seatData = null;
        foreach(GameObject data in seats){
            seatData = data.GetComponent<FacilityData>();
            if(seatData.isAvailable){
                seatData.isAvailable = false;
                movement.setTarget(data.transform.position,true);
                break;
            }
        }

        while(!movement.IsReached) yield return new WaitForFixedUpdate();
        movement.setFlipX(seatData.isFacingLeft);
        yield break;
    }

    private void consider(){

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
