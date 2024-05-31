using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateMinimizedNota : MonoBehaviour
{
    public GameObject menuItemPrefab;
    public float startMargin;
    public float objectMargin;
    private List<GameObject> notaList = new List<GameObject>();

    void OnEnable(){
        int numberOfNota = NotaDataManager.Instance.NotaBuffers.Count;
        for(int i = 0; i < numberOfNota; i++){
            GameObject menuItem = Instantiate(menuItemPrefab);
            menuItem.GetComponent<MinimizedNotaItemHandler>().index = i;
            menuItem.transform.SetParent(transform,false);
            RectTransform menuItemTransform = menuItem.GetComponent<RectTransform>();
            menuItemTransform.anchoredPosition = new Vector2(startMargin + (menuItemTransform.sizeDelta.x + objectMargin) * i,0);
            notaList.Add(menuItem);
        }
    }

    public void refreshUI(){
        OnEnable();
    }

    void OnDisable(){
        foreach(GameObject nota in notaList){
            Destroy(nota);
        }
        notaList.Clear();
    }

}
