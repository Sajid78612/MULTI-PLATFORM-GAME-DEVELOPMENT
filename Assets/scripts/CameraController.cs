using UnityEngine ;
using System . Collections ;
public class CameraController : MonoBehaviour {
//camera collision variables so we dont clip through objects when moving the camera
  public Transform m_Target;
  public float m_Height = 10;
  public float m_Distance = 20;
  public float m_Angle = 90;
  public GameObject player ;
  private Vector3 offset ;
  void Start () {
    HandleCamera();
    //offset = transform.position ;
  }
  void Update () {
    if (Input.GetKey(KeyCode.Q)) {
      m_Angle += 0.2f;
    }
    if (Input.GetKey(KeyCode.E)) {
      m_Angle -= 0.2f;
    }
    HandleCamera();
    //transform.position = player.transform.position + offset ;
  }

  protected virtual void HandleCamera() {
    if(!m_Target) {
      return;
    }

    Vector3 worldPosition = (Vector3.forward * -m_Distance) + (Vector3.up * m_Height);
    //Debug.DrawLine(m_Target.position, worldPosition, Color.red); 

    Vector3 rotatedVector = Quaternion.AngleAxis(m_Angle, Vector3.up) * worldPosition;

    Vector3 flatTargetPosition = m_Target.position;
    flatTargetPosition.y = 0f;
    Vector3 finalPosition = flatTargetPosition + rotatedVector;

    transform.position = finalPosition;
    transform.LookAt(flatTargetPosition); 
  }
}
