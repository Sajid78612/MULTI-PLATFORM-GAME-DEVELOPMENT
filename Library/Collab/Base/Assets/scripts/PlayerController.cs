using UnityEngine ;
using System.Collections ;

public class PlayerController : MonoBehaviour {
  public float Speed;
  public static int lives = 3;
  public GameObject mainCam;
  public GameObject  FirstPerson;
  
  public bool isFirst = true;
  public bool isTopDown = false;

  public Transform camTransform;
  public Vector3 MoveVector;
  void Update ()
  {
   if(Input.GetKeyDown("c"))
   {
     FirstPerson.SetActive(!isFirst);
     mainCam.SetActive(!isTopDown);
     isFirst = !isFirst;
     isTopDown = !isTopDown;
   }
   if(isFirst) {
     MoveVector = PoolInput();
     MoveVector = RotateWithView();
     PlayerMovement();
   }
   else {
     MoveVector = PoolInput();
     PlayerMovement();
   }
  }
  Vector3 PoolInput()
  {
    Vector3 dir = Vector3.zero;
    dir.x = Input.GetAxis("Horizontal");
    dir.z = Input.GetAxis("Vertical");

    if(dir.magnitude > 1) dir.Normalize();
    return dir;
  }
  void PlayerMovement()
  {
    Vector3 playerMovement = MoveVector * Speed * Time.deltaTime;
    transform.Translate(playerMovement, Space.Self);
  }

  Vector3 RotateWithView() {
    if(camTransform != null) {
      Vector3 dir = camTransform.TransformDirection(MoveVector);
      dir.Set(dir.x, 0, dir.z);
      return dir.normalized * MoveVector.magnitude;
    }
    return MoveVector;
  }
}
