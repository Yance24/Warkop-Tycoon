using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;

public class RandomPointGenerator : MonoBehaviour
{
    public GameObject testPoint;
    private GameObject instantiatedPoint;

    public void execute(){
        StartCoroutine(ActionProcess());
    }

    // Temporary
    void Start(){
        execute();
    }

    public void spawnPoint(){
        if(testPoint){
            instantiatedPoint = Instantiate(testPoint,transform);
            instantiatedPoint.transform.localScale = WorldTransform.convertToLocalScale(new Vector2(0.5f,0.5f),transform);
        }else{
            instantiatedPoint = Instantiate(new GameObject(),transform);
        }

        float randX = Random.Range(-0.5f,0.5f);
        float randY = Random.Range(-0.5f,0.5f);

        instantiatedPoint.transform.localPosition = new Vector2(randX,randY);
    }

    public void removePoint(){
        Destroy(instantiatedPoint);
        instantiatedPoint = null;
    }

    IEnumerator ActionProcess(){
        yield return null;
        while(true){
            spawnPoint();
            yield return new WaitForSeconds(2);
            removePoint();
            yield return new WaitForSeconds(1);
        }
    }
}
