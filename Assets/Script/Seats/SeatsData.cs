using System.Collections.Generic;
using UnityEngine;

public class SeatsData : FacilityData
{
    public List<GameObject> chairs;
    
    protected CostumerGroupManager occupiedBy;
    public bool IsOccupied{
        get{return occupiedBy;}
    }
    // public List<GameObject> GetOccupiedBy{
    //     get{return occupiedBy;}
    // }

    private bool isOrdering = false;
    public bool IsOrdering{
        get{return isOrdering;}
        set{isOrdering = value;}
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