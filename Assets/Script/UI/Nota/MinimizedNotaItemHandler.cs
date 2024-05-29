using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimizedNotaItemHandler : MonoBehaviour
{
    public int index;

    public void OnClick(){
        if(MenuMakerManager.Instance.isMenuMakerActive()) NotaDataManager.Instance.selectNota(index);
        else NotaDataManager.Instance.showMenu(index);
    }
}
