using UnityEngine ;
using System.Collections ;

public class PlayerController : MonoBehaviour {
  //main script for player movement
  public float Speed = 3;
  public GameObject mainCam;
  public GameObject FirstPerson;
  public GameObject crosshair;

  public GameObject roofRemoval;
  
  public bool isFirst = true;
  public bool isTopDown = false;

  public Transform camTransform;
  public Vector3 MoveVector;
  void Update () //checking to see if player switches camera modes
  {
   if(Input.GetKeyDown("c") && !pausemenu.isGamePaused && !summary.isSumPaused)
   {
     FirstPerson.SetActive(!isFirst);
     mainCam.SetActive(!isTopDown);
     crosshair.SetActive(!isFirst);
     isFirst = !isFirst;
     isTopDown = !isTopDown;
     roofRemoval.SetActive(isFirst);
   }
   if(isFirst) {
     MoveVector = PoolInput();
     MoveVector = RotateWithView();
     PlayerMovement();
   }
   else {
     MoveVector = PoolInput();
     MoveVector = RotateWithView();
     PlayerMovement();
   }
  }
  Vector3 PoolInput() //player inputs
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
