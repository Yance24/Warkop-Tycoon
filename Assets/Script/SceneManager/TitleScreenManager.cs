using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public void newGameButton(){
        SceneManager.LoadScene("GamePlay");
    }

    public void exitButton(){
        Application.Quit();
    }
}
