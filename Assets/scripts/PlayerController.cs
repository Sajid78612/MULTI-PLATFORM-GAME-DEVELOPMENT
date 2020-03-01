using UnityEngine ;
using System.Collections ;

public class PlayerController : MonoBehaviour {
  public float speed;
  public static int lives = 3;
  public GameObject mainCam;
  public GameObject  FirstPerson;
  
  public bool isFirst = false;
  public bool isTopDown = true;

  void Update ()
  {
    transform.Translate(speed*Input.GetAxis("Horizontal")*Time.deltaTime,0f,speed*Input.GetAxis("Vertical")*Time.deltaTime);

    //print(lives);
   if(Input.GetKeyDown("c"))
   {
     FirstPerson.SetActive(!isFirst);
     mainCam.SetActive(!isTopDown);
     isFirst = !isFirst;
     isTopDown = !isTopDown;
   }

  }

}
