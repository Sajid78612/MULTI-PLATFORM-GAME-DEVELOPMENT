using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene(5);
    }

    public void LoadGame() {
        PlayerData data = SaveSystem.LoadPlayer(); 
        print(data.level);    
        SceneManager.LoadScene(data.level);
    }

    public void PlayTutorial() {
        SceneManager.LoadScene(3);
    }

    public void exit() {
        Application.Quit();
    }
}
