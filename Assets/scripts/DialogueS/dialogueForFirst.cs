using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueForFirst : MonoBehaviour
{
    public GameObject box;
    
    private int num = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            Destroy(box);
        }
    }
}
