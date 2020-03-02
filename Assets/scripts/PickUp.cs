using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject myWeapon;
    public GameObject weaponOnGround;
    // Start is called before the first frame update
    void Start()
    {
        myWeapon.SetActive(false);
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {   
            myWeapon.SetActive(true);
            Destroy(this.gameObject);      
        }
    }

}
