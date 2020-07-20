using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawn : MonoBehaviour
{
    //public Transform respawnpoint;

      void OnTriggerEnter(Collider c)
      {     
        if(c.GetComponent<Collider>().name =="MainPlayer")
        {
          //c.transform.position = respawnpoint.transform.position;
          //c.GetComponent<PlayerSystem>().reset();
          Scene scene = SceneManager.GetActiveScene(); 
          SceneManager.LoadScene(scene.name);
        }

      }
}
