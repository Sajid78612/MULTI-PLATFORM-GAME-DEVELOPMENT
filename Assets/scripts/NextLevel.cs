using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
     public summary s;
     void OnTriggerEnter(Collider c)
      {     
        if(c.GetComponent<Collider>().name =="MainPlayer")
        {
          //c.transform.position = respawnpoint.transform.position;
          //c.GetComponent<PlayerSystem>().reset();
          summary.isSumPaused = true;
          //SceneManager.LoadScene("Floor1");
        }

      }
}
