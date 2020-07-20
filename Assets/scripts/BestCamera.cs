using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestCamera : MonoBehaviour
{
    //variables for camera third person
    float rotationSpeed = 1;
    public Transform Target, Player;
    public float mouseX, mouseY;

    public Transform Obstruction;
    //float zoomSpeed = 2f;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        if(!pausemenu.isGamePaused && !summary.isSumPaused) { 
            CamControl();
        }
    }
    

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);


        }
        else
        {
            Target.rotation = Quaternion.Euler(0, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }
}
