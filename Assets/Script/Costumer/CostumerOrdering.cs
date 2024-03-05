using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CostumerOrdering : BaseNpcBehavior
{
    protected GameObject counter;
    protected CounterData counterData;
    protected bool counterReached;

    protected override void setup()
    {
        base.setup();
        counter = GameObject.FindGameObjectWithTag("Counter");
        counterData = counter.GetComponent<CounterData>();
    }

    public override void execute()
    {
        base.execute();
        counterReached = false;
        // counterData.npcLines.Add(transform.gameObject);
        if(counterData.getCurrentLine(gameObject) == -1)
            counterData.npcLines.Add(Costumer.findCostumerGroup(gameObject));

        StartCoroutine(waitInLine());
    }

    protected IEnumerator waitInLine(){
        while(!counterReached || !movement.IsReached){
            checkCounter();
            setFlipSprite();
            yield return new WaitForFixedUpdate();
        }
        StartCoroutine(ordering());
        yield break;
    }    

    protected void checkCounter(){
        if(counterData.getCurrentLine(gameObject) == 0) counterReached = true;
        
        if(counterData.isFacingLeft)
            movement.setTarget(new Vector2(counter.transform.position.x - (counterData.lineLength * counterData.getCurrentLine(gameObject) + counterData.groupSpread * counterData.getGroupIndex(gameObject)),transform.position.y));
        else
            movement.setTarget(new Vector2(counter.transform.position.x + (counterData.lineLength * counterData.getCurrentLine(gameObject) + counterData.groupSpread * counterData.getGroupIndex(gameObject)),transform.position.y));
        
    }

    protected void setFlipSprite(){
        if(!movement.IsMoving) {
            movement.setFlipX(!counterData.isFacingLeft);
        }
    }


    protected IEnumerator ordering(){
        Debug.Log("Ordering....");
        yield return new WaitForSeconds(5);
        finish();
        yield break;
    }

    protected override void finish()
    {
        counterData.removeLines(gameObject);
        base.finish();
    }
}
