using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    //all pause functionality found in this script
    public static bool isGamePaused = false;

    public GameObject pauseMenuUI;

    public int level;

    // Update is called once per frame
    void Update() //checking every frame if esc is pressed to pause
    {
        level = SceneManager.GetActiveScene().buildIndex;
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if(isGamePaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume() { //resuming game
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause() { //pausing screen
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadMenu() { //load not functional
        Time.timeScale = 1f;
        isGamePaused = false;
        SceneManager.LoadScene("MainMenu");

    }

    public void QuitGame() { //exit game
        Application.Quit();
    }

    public void Save() { //Save system
        SaveSystem.SavePlayer(this);
    }

    public void restart() { //restart current scene
        Time.timeScale = 1f;
        isGamePaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}
