using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumerGroup
{
    public List<GameObject> costumer = new List<GameObject>();
    public SeatsData seatsData;

    public void debug(){
        Debug.Log(costumer.Count);
        Debug.Log(seatsData);
    }
}
