using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public GameData newGameData;
    public GameData gameData;
    
    public void newGameButton(){
        setNewGameData();
        SaveLoadManager.saveGame(gameData);
        SceneManager.LoadScene("GamePlay");
    }

    private void setNewGameData(){
        GameDataUtil.CopyValues(newGameData,gameData);        
    }

    public void loadGame(){
        GameData loadData = SaveLoadManager.loadGame();
        GameDataUtil.CopyValues(loadData,gameData);
        SceneManager.LoadScene("GamePlay");
    }

    public void exitButton(){
        Application.Quit();
    }
}
