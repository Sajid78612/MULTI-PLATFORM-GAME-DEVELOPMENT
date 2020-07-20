using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicWeapon : MonoBehaviour
{
    //variables
    public PlayerSystem ps;
    public int damage;
    public int maxClipSize = 8;
    private int ammoRemaining = 0;
    float maxRange = 300f;
    public AudioSource sound;

    public bool playerControlled = true;

    public Text ammoRemainingLabel;
    public Text ammoLabel;

    public Transform shootPoint;

    public GameObject impactEffectPrefab;

    Color OrigColor;

    // Start is called before the first frame update
    void Start()
    {
        OrigColor = ammoRemainingLabel.color;
        ammoRemaining = maxClipSize;
        UpdateUI();
    }

    void UpdateUI() { //update ui every frame
        if(ammoRemainingLabel != null) {
            ammoRemainingLabel.text = ammoRemaining.ToString();
        }
        if(ammoRemainingLabel.text == "0") {
            ammoRemainingLabel.color = Color.red;
            ammoLabel.color = Color.red;
        }
        else {
            ammoRemainingLabel.color = OrigColor;
            ammoLabel.color = OrigColor;
        }
    }

    void Fire() {//fire method for shooting gun using raycast
        ammoRemaining -= 1;
        UpdateUI();

        RaycastHit hitInfo;

        var ray = new Ray(shootPoint.position, shootPoint.forward);
        bool hit = Physics.Raycast(ray, out hitInfo, maxRange);

        if(hit) {
            var impactEffect = Instantiate(impactEffectPrefab);
            impactEffect.transform.position = hitInfo.point;

            var direction = Vector3.Reflect(shootPoint.forward, hitInfo.normal);

            impactEffect.transform.forward = direction;

            Destroy(impactEffect, 4);

            var damage = hitInfo.collider.GetComponentInParent<damageTaken>();

            if (damage != null) {
                damage.TakeDamage(20);
            }
        }
    }

    /*
    void Reload() {
        ammoRemaining = maxClipSize;
        UpdateUI();
    }
    */

    // Update is called once per frame
    void Update() //update every frame to see if shot has been fired
    {
        if (!playerControlled) {
            return;
        }

        if(Input.GetButtonDown("Fire1")) {
            if(ammoRemaining > 0 && !pausemenu.isGamePaused && !summary.isSumPaused) {
                sound.Play();
                ps.gunShoot(25);
                Fire();
            }
        }

        /*
        if(Input.GetKeyDown("r")) {
            if(ammoRemaining != 8) {
                Reload();
            }
        }
        */
    }
}
