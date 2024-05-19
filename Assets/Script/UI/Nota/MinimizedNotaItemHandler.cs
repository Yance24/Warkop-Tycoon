using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimizedNotaItemHandler : MonoBehaviour
{
    public int index;

    public void OnClick(){
        NotaDataManager.Instance.showMenu(index);
    }
}
