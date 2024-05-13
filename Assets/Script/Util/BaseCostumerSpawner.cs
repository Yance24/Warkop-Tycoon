
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BaseCostumerSpawner : MonoBehaviour
{
    // public float groupSpread;
    public GameObject costumer;

    void Start(){
        StartCoroutine(spawner());
    }

    IEnumerator spawner(){
        spawnCostumer();
        // yield return new WaitForSeconds(4);
        // spawnCostumer();
        // yield return new WaitForSeconds(3);

        // while(!InGameTime.closingTime){
        //     spawnCostumer();
        //     yield return new WaitForSeconds(Random.Range(10,21));
        // }
        yield break;
    }

    // protected CostumerGroup setupCostumerGroup(){
    //     SeatsData seatsData = getSeat();
    //     if(seatsData){
    //         CostumerGroup costumerGroup = new CostumerGroup();
    //         costumerGroup.seatsData = seatsData;
    //         for(int i = 0; i < seatsData.chairs.Count; i++){
    //             if(Random.Range(1,3) == 2 || i == 0) costumerGroup.costumer.Add(costumer);
    //         }
    //         return costumerGroup;
    //     }else return null;
    // }

    // protected SeatsData getSeat(){    
    //     GameObject[] seats = GameObject.FindGameObjectsWithTag("Seats");
    //     foreach(GameObject data in seats){
    //         SeatsData seatData = data.GetComponent<SeatsData>();
    //         if(seatData.isAvailable){
    //             seatData.isAvailable = false;
    //             return seatData;
    //         }
    //     }
    //     return null;
    // }

    protected void spawnCostumer(){
        //old spawn uses seats data to act as the maximum spawned costumer

        // SeatsData seatsData = getSeat();

        // if(seatsData){
        //     CostumerGroup costumerGroup = new CostumerGroup{seatsData = seatsData};
        //     for(int i = 0; i < seatsData.chairs.Count; i++){
        //         if(Random.Range(1,3) == 2 || i == 0){
        //             GameObject costumer = Instantiate(this.costumer);
        //             costumer.transform.position = new Vector2(transform.position.x - groupSpread * i,transform.position.y);
        //             costumer.GetComponent<CostumerEnjoyMeal>().seat = seatsData.chairs[i];
        //             costumerGroup.costumer.Add(costumer.GetInstanceID());
        //         }
        //     }
        //     Costumer.spawnedCostumer.Add(costumerGroup);
        // }

        // CostumerGroup costumerGroup = new CostumerGroup();
        // for(int i = 0; i < 4; i++){
        //     if(Random.Range(1,3) == 2 || i == 0){
        //         GameObject costumer = Instantiate(this.costumer);
        //         costumer.transform.position = new Vector2(transform.position.x - groupSpread * costumerGroup.costumer.Count,transform.position.y);
        //         costumerGroup.costumer.Add(costumer.GetInstanceID());
        //     }
        // }

        // if(costumerGroup.costumer.Count > 0) Costumer.spawnedCostumer.Add(costumerGroup);
        GameObject costumer = Instantiate(this.costumer);
        costumer.transform.position = transform.position;
    }

    public void removeCostumer(GameObject costumer){
        // if(Costumer.spawnedCostumer.Remove(costumer)) Destroy(costumer);
    }
}