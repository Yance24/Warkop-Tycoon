using System.Collections.Generic;
using UnityEngine;

public class CostumerGroupManager : MonoBehaviour
{
    public List<GameObject> costumerObjects;
    public BaseAiProcessManager AiHandler;

    void Start(){
        AiHandler.setup(costumerObjects);
        // Debug.Log("Ai Handler Setup Complete");
        // Debug.Log("Ai Handler Executing...");
        AiHandler.execute();
    }
}
