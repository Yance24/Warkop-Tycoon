
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BaseCostumerSpawner : MonoBehaviour
{
    public static BaseCostumerSpawner Instance{get; private set;}
    // public float groupSpread;
    public List<GameObject> costumer;

    public float chanceSpawn;

    private List<GameObject> spawnedCostumer = new List<GameObject>();

    Coroutine spawnerProcess;

    public bool isNoCostumer(){
        return spawnedCostumer.Count <= 0;
    }

    void Awake(){
        if(!Instance) Instance = this;
        else Destroy(gameObject);
    }

    void Start(){
        spawnerProcess = StartCoroutine(spawner());
    }

    void OnEnable(){
        DayCycle.TimeChange += checkDayEnd;
    }

    void OnDisable(){
        DayCycle.TimeChange -= checkDayEnd;
    }

    void checkDayEnd(){
        if(DayCycle.IsDayEnd){
            StopCoroutine(spawnerProcess);
        }
    }

    IEnumerator spawner(){
        yield return null;
        while(true){
            if(Random.value < chanceSpawn){
                spawnCostumer();
            }
            yield return new WaitForSeconds(1);
        }
    }

    protected void spawnCostumer(){
        GameObject pickedCostumer = Instantiate(costumer[Random.Range(0,costumer.Count)]);
        pickedCostumer.transform.position = transform.position;
        spawnedCostumer.Add(pickedCostumer);
    }

    public void removeCostumer(GameObject costumer){
        if(spawnedCostumer.Remove(costumer)) Destroy(costumer);
    }
}