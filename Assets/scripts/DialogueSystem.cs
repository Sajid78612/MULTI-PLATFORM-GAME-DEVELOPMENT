using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour
{
    //simple dialogue system
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject box;
    
    private int num = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(5);
        }

        if (Input.GetKeyDown(KeyCode.Return) && num == 1) {
            text1.SetActive(false);
            text2.SetActive(true);
            num++;
        }

        else if (Input.GetKeyDown(KeyCode.Return) && num == 2) {
            text2.SetActive(false);
            text3.SetActive(true);
            num++;
        }

        else if (Input.GetKeyDown(KeyCode.Return) && num == 3) {
            text3.SetActive(false);
            text4.SetActive(true);
            num++;
        }

        else if (Input.GetKeyDown(KeyCode.Return) && num == 4) {
            text4.SetActive(false);
            text5.SetActive(true);
            num++;
        }
    }
}
