using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterData : FacilityData
{
    public float lineLength;
    public List<GameObject> npcLines;

    public int getIndex(GameObject npc){
        for(int i = 0; i < npcLines.Count; i++){
            if(npc == npcLines[i]) return i;
        }
        return 0;
    }

    public int NumberOfLines{
        get{return npcLines.Count;}
    }
}
