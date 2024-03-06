using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CounterData : FacilityData
{
    public float lineLength;
    public float groupSpread;
    public List<CostumerGroup> npcLines = new List<CostumerGroup>();

    // public int getIndex(GameObject npc){
    //     for(int i = 0; i < npcLines.Count; i++){
    //         if(npc == npcLines[i]) return i;
    //     }
    //     return 0;
    // }

    public int getCurrentLine(GameObject costumer){
        for(int i = 0; i < npcLines.Count; i++){
            if(npcLines[i].findCostumer(costumer)) return i;
        }
        return -1;
    }

    public int getGroupIndex(GameObject costumer){
        foreach(CostumerGroup costumerGroup in npcLines){
            int index = costumerGroup.getCostumerIndex(costumer);
            if(index != -1) return index;
        }
        return -1;
    }

    public void removeLines(GameObject costumer){
        for(int i = 0; i < npcLines.Count; i++){
            if(npcLines[i].findCostumer(costumer)){
                npcLines.RemoveAt(i);
                return;
            }
        }
    }

    public int NumberOfLines{
        get{return npcLines.Count;}
    }
}
