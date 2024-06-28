using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance{private set; get;}
    public GameObject gameOverUI;

    void Awake(){
        if(!Instance)Instance = this;
        else Destroy(gameObject);
    }

    void Start(){
        gameOverUI.SetActive(false);
    }

    public void gameOverSequence(){
        BaseCostumerSpawner.Instance.stopSpawner();
        DayCycle.Instance.stopTime();
        // MenuMakerManager.Instance.noDisplay();
        // NotaDataManager.Instance.noDisplay();
        
        gameOverUI.SetActive(true);
    }

    public void clickToContinue(){
        SaveLoadManager.removeSave();
        SceneManager.LoadScene("TitleScreen");
    }
}
