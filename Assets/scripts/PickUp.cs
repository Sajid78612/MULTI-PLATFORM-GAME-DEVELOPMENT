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

    public void onTriggerEnter(Collider col) {
        print("hello");
        PlayerController player = col.GetComponent<PlayerController>();
        if(player != null) {
            myWeapon.SetActive(true);
            weaponOnGround.SetActive(false);
        }
    }

}
