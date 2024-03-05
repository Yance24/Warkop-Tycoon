using System.Collections.Generic;
using UnityEngine;

public static class Costumer
{
    public static List<CostumerGroup> spawnedCostumer = new List<CostumerGroup>();

    public static bool noCostumer(){
        return spawnedCostumer.Count == 0;
    }

    public static bool removeCostumer(GameObject costumer){
        for(int i = 0; i < spawnedCostumer.Count; i++){
            if(spawnedCostumer[i].removeCostumer(costumer)){
                if(spawnedCostumer[i].costumer.Count == 0) {
                    spawnedCostumer.RemoveAt(i);
                }
                return true;
            }
        }
        return false;
    }

    public static CostumerGroup findCostumerGroup(GameObject costumer){
        foreach(CostumerGroup costumerGroup in spawnedCostumer){
            if(costumerGroup.findCostumer(costumer)) return costumerGroup;
        }
        return null;
    }

    public static int findCostumerGroupIndex(GameObject costumer){
        for(int i = 0; i < spawnedCostumer.Count; i++){
            if(spawnedCostumer[i].findCostumer(costumer)) return i;
        }
        return -1;
    }

    public static int findCostumerIndex(GameObject costumer){
        for(int i = 0; i < spawnedCostumer.Count; i++){
            int index = spawnedCostumer[i].getCostumerIndex(costumer);
            if(index != -1) return index;
        }
        return -1;
    }
}
