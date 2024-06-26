using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delay : BaseNpcAction
{
    public float delaySeconds;

    public override void execute()
    {
        base.execute();
        StartCoroutine(ActionProcess());
    }

    IEnumerator ActionProcess(){
        yield return null;
        yield return new WaitForSeconds(delaySeconds);
        finish();
    }
}
