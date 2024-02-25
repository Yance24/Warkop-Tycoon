using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCostumerSpawner : MonoBehaviour
{
    public GameObject costumer;
    void Start(){
        StartCoroutine(spawnCostumer());
    }

    IEnumerator spawnCostumer(){
        GameObject obj = Instantiate(costumer);
        obj.transform.position = transform.position;
        yield return new WaitForSeconds(4);
        obj = Instantiate(costumer);
        obj.transform.position = transform.position;
        yield return new WaitForSeconds(3);
        obj = Instantiate(costumer);
        obj.transform.position = transform.position;

        while(true){
            yield return new WaitForSeconds(Random.Range(10,20));
            obj = Instantiate(costumer);
            obj.transform.position = transform.position;
        }
    }
}
