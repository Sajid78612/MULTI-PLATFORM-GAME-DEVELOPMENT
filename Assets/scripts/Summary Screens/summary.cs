using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class summary : MonoBehaviour
{
    //generated the summary page
    public TextMeshProUGUI Text;
    public static bool isSumPaused = false;
    public GameObject summaryMenuUI;

    public int level;

    public string timer;

    public float seconds, minutes;

    public float start_time;

    public float mytime;

    public void Start() {
        start_time = Time.time;
    }

    // Update is called once per frame
    void Update() {
        int Tolevel = SceneManager.GetActiveScene().buildIndex;
        if(Tolevel == 1) {
            level = 4;
        }
        else {
            level = Tolevel;
        }
        
        if(isSumPaused) {
            pause();        
        } 
        else {
            
            mytime = Time.time - start_time;
            minutes = (int)(mytime/60f);
            seconds = (int)(mytime % 60f);
            timer = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }

    public void moveOn() {
        summaryMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;  
        isSumPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Floor1");
    }

    public void pause() {
        summaryMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isSumPaused = true;
        Text = FindObjectOfType<TextMeshProUGUI>();
        Text.text = timer;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Save() {
        SaveSystem.SavePlayer(this);
    }

    public void Retry() {  
        summaryMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isSumPaused = false;
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
    public void menu() {
        Time.timeScale = 1f;
        summaryMenuUI.SetActive(false);
        isSumPaused = false;
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame() {
        Application.Quit();
    }
}
