
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCostumerSpawner : MonoBehaviour
{
    public GameObject costumer;

    void Start(){
        StartCoroutine(spawner());
    }

    IEnumerator spawner(){
        // spawnCostumer(costumer);
        // yield return new WaitForSeconds(4);
        // spawnCostumer(costumer);
        // yield return new WaitForSeconds(3);

        // while(!InGameTime.closingTime){
        //     spawnCostumer(costumer);
        //     yield return new WaitForSeconds(Random.Range(10,20));
        // }
        spawnCostumer();
        spawnCostumer();
        spawnCostumer();
        yield break;
    }

    protected CostumerGroup setupCostumerGroup(){
        SeatsData seatsData = getSeat();
        if(seatsData){
            CostumerGroup costumerGroup = new CostumerGroup();
            costumerGroup.seatsData = seatsData;
            for(int i = 0; i < seatsData.chairs.Count; i++){
                if(Random.Range(1,3) == 2 || i == 0) costumerGroup.costumer.Add(costumer);
            }
            return costumerGroup;
        }else return null;
    }

    protected SeatsData getSeat(){    
        GameObject[] seats = GameObject.FindGameObjectsWithTag("Seats");
        foreach(GameObject data in seats){
            SeatsData seatData = data.GetComponent<SeatsData>();
            if(seatData.isAvailable){
                // seat = data;
                seatData.isAvailable = false;
                return seatData;
            }
        }
        return null;
    }

    protected void spawnCostumer(GameObject costumer){
        // GameObject obj = Instantiate(costumer);
        // obj.transform.position = transform.position;
        // Costumer.spawnedCostumer.Add(obj);
    }

    protected void spawnCostumer(List<GameObject> costumer){

    }

    protected void spawnCostumer(){
        CostumerGroup costumerGroup = setupCostumerGroup();
        for(int i = 0; i < costumerGroup.costumer.Count; i++){
            GameObject obj = Instantiate(costumerGroup.costumer[i]);
            obj.transform.position = transform.position;
            obj.GetComponent<CostumerEnjoyMeal>().seat = costumerGroup.seatsData.chairs[i];
            costumerGroup.costumer[i] = obj;
        }
        costumerGroup.debug();
        Costumer.spawnedCostumer.Add(costumerGroup);
    }

    public void removeCostumer(GameObject costumer){
        // if(Costumer.spawnedCostumer.Remove(costumer)) Destroy(costumer);
    }
}