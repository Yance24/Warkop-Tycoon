using System.Collections.Generic;
using UnityEngine;

public class SeatsData : FacilityData
{
    public List<GameObject> chairs;
    
    protected List<GameObject> occupiedBy = new List<GameObject>();
    public bool IsOccupied{
        get{return occupiedBy.Count > 0;}
    }
    public List<GameObject> GetOccupiedBy{
        get{return occupiedBy;}
    }

    private bool isOrdering = false;
    public bool IsOrdering{
        get{return isOrdering;}
        set{isOrdering = value;}
    }

    public void setOccupied(List<GameObject> occupiedBy){
        this.occupiedBy = occupiedBy;
    }
    
    public List<GameObject> getOccupiedBy(){
        return occupiedBy;
    }

    public void clearOccupied(){
        occupiedBy.Clear();
    }
}