using System.Collections.Generic;
using UnityEngine;

public class SeatsData : FacilityData
{
    public List<GameObject> chairs;

    public GameObject servedDrinks;
    
    protected CostumerGroupManager occupiedBy;
    public bool IsOccupied{
        get{return occupiedBy;}
    }
    // public List<GameObject> GetOccupiedBy{
    //     get{return occupiedBy;}
    // }

    private bool isOrdering = false;
    private bool isServed = false;
    public bool IsOrdering{
        get{return isOrdering;}
        set{isOrdering = value;}
    }

    public bool IsServed{
        get{return isServed;}
        set{
            isServed = value;
            setServedDrink();
        }
    }

    void Start(){
        IsOrdering = false;
        IsServed = false;
    }

    private void setServedDrink(){
        servedDrinks.SetActive(isServed);
    }

    public void setOccupied(CostumerGroupManager occupiedBy){
        this.occupiedBy = occupiedBy;
    }
    
    public CostumerGroupManager getOccupiedBy(){
        return occupiedBy;
    }

    public void clearOccupied(){
        occupiedBy = null;
    }
}