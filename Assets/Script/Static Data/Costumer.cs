using System.Collections.Generic;
using UnityEngine;

public static class Costumer
{
    public static List<GameObject> spawnedCostumer = new List<GameObject>();

    public static bool noCostumer(){
        return spawnedCostumer.Count == 0;
    }
}
