using System.Collections.Generic;
using UnityEngine;

public static class Costumer
{
    public static List<CostumerGroup> spawnedCostumer = new List<CostumerGroup>();

    public static bool noCostumer(){
        return spawnedCostumer.Count == 0;
    }

    public static bool removeCostumer(GameObject costumer){
        foreach(CostumerGroup costumerGroup in spawnedCostumer){
            if(costumerGroup.costumer.Remove(costumer)) return true;
        }
        return false;
    }
}
