using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnpoint;


      void OnTriggerEnter(Collider c)
      {
          PlayerController.lives -= 1;
        if(c.GetComponent<Collider>().name =="MainPlayer")
        {

          player.transform.position = respawnpoint.transform.position;


        }
      }
}
