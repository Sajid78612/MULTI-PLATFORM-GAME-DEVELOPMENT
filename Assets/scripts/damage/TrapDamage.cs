using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapDamage : MonoBehaviour
{
    private int damage = 10;
    private int scoreToLose = 50;
    private bool isDead = false;
    //public Transform respawnpoint;

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {   
            var dmg = other.GetComponentInParent<PlayerSystem>();
            if (dmg != null) {
                isDead = dmg.TakeDamage(damage, scoreToLose);
                print(isDead);
            }
            if (isDead) {
                //other.transform.position = respawnpoint.transform.position;
                //other.GetComponent<PlayerSystem>().reset();
                Scene scene = SceneManager.GetActiveScene(); 
                SceneManager.LoadScene(scene.name);
            }
        }
    }
}
