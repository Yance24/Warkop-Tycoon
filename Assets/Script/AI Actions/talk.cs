using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talk : BaseNpcAction
{
    public int talkerIndex;
    public string text;
    public float lifeSpan;

    private CostumerBubbleChat costumerBubbleChat;

    public override void execute()
    {
        base.execute();
        StartCoroutine(ActionProcess());
    }

    private bool getCostumerBubbleChat(){
        costumerBubbleChat = objectsRef[talkerIndex].GetComponent<CostumerBubbleChat>();
        return costumerBubbleChat;
    }

    IEnumerator ActionProcess(){
        yield return null;
        if(!getCostumerBubbleChat()){
            failed();
            yield break;
        }

        costumerBubbleChat.setText(text);
        yield return new WaitForSeconds(lifeSpan);
        costumerBubbleChat.clearText();
        finish();
    }
}
