using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseUI;

    void Start()
    {
        pauseUI.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            pauseUI.SetActive(true);
            // Time.timeScale = 0f;
        }
    }

    public void resumeButton(){
        pauseUI.SetActive(false);
        // Time.timeScale = 1f;
    }

    public void mainMenuButton(){
        SceneManager.LoadScene("TitleScreen");
    }
}
