using Unity.VisualScripting;
using UnityEngine;

public class SeatsHitBoxHandler : MonoBehaviour
{
    public PlayerInputManager player;
    private SeatsData data;

    // private bool inputBuffered;
    // public bool IsBuffered{
    //     get{return inputBuffered;}
    //     set{inputBuffered = value;}
    // }

    void Start(){
        data = GetComponent<SeatsData>();
    }
    private void OnMouseOver()
    {
        //hover
    }
    // Called when the mouse exits the GameObject
    private void OnMouseExit()
    {
        //on exit
    }

    // Called when the mouse clicks on the GameObject
    private void OnMouseDown()
    {
        //mouse click
        if(data.IsOrdering){
            data.IsOrdering = false;
        }
    }
}
