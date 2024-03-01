using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumerGoHome : BaseNpcBehavior
{
    protected GameObject entranceDoor;

    protected override void setup()
    {
        base.setup();
        entranceDoor = GameObject.FindGameObjectWithTag("EntranceDoor");
    }

    public override void execute()
    {
        base.execute();
        StartCoroutine(toExit());
    }

    protected IEnumerator toExit(){
        movement.setTarget(entranceDoor.transform.position);
        while(!movement.IsReached) yield return new WaitForEndOfFrame();
        finish();
        yield break;
    }

    protected override void finish()
    {
        base.finish();
        entranceDoor.GetComponent<BaseCostumerSpawner>().removeCostumer(gameObject);
    }
}
