using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleCheckContinueAble : MonoBehaviour
{
    void OnEnable(){
        GetComponent<Button>().interactable = SaveLoadManager.checkLoadGame();
    }
}
