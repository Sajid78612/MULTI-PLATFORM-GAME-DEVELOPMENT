using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public PlayableDirector director;
    private float timer = 28f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(director.state != PlayState.Playing || timer <= 0) {
            print("wow");
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(1);
        }
    }
}
