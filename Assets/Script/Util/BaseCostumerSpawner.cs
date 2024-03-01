using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCostumerSpawner : MonoBehaviour
{
    public GameObject costumer;
    // private List<GameObject> spawnedCostumer;

    // public List<GameObject> SpawnedCostumer{
    //     get{
    //         return spawnedCostumer;
    //     }
    // }

    void Start(){
        // spawnedCostumer = new List<GameObject>();
        StartCoroutine(spawner());
    }

    IEnumerator spawner(){
        spawnCostumer(costumer);
        yield return new WaitForSeconds(4);
        spawnCostumer(costumer);
        yield return new WaitForSeconds(3);

        while(!InGameTime.closingTime){
            spawnCostumer(costumer);
            yield return new WaitForSeconds(Random.Range(10,20));
        }
    }

    void spawnCostumer(GameObject costumer){
        GameObject obj = Instantiate(costumer);
        obj.transform.position = transform.position;
        Costumer.spawnedCostumer.Add(obj);
    }

    public void removeCostumer(GameObject costumer){
        if(Costumer.spawnedCostumer.Remove(costumer)) Destroy(costumer);
    }
}