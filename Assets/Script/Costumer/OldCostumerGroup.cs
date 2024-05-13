using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldCostumerGroup
{
    public List<int> costumer = new List<int>();
    public SeatsData seatsData;

    public bool findCostumer(GameObject targetCostumer){
        foreach(int costumerId in costumer){
            if(costumerId == targetCostumer.GetInstanceID()) return true;
        }
        return false;
    }

    public int getCostumerIndex(GameObject targetCostumer){
        for(int i = 0; i < costumer.Count; i++){
            if(costumer[i] == targetCostumer.GetInstanceID()) return i;
        }
        return -1;
    }

    public void addCostumer(GameObject targetCostumer){
        costumer.Add(targetCostumer.GetInstanceID());
    }

    public bool removeCostumer(GameObject targetCostumer){
        return costumer.Remove(targetCostumer.GetInstanceID());
    }
}
