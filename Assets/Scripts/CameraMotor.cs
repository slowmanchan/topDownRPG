
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
  public Transform lookAt;
  public float boundX = 0.15f;
  public float boundY = 0.05f;

  // Called after FixedUpdate and Update
  // We want the camera to move after the player has moved
  // To prevent jankiness
  private void LateUpdate()
  {
    Vector3 delta = Vector3.zero;

    // Check if we are in the bounds on the X axis
    // we get the delta (this is the diff between player and camera position)
    // remember the middle of the x axis is 0 
    // if delta is bigger then our bound or less then our negative bound
    // (we have to check each side -1 --- 0 ---- 1)
    // our player could be left of center or right
    // we then have to check which side of center we are on 
    // we minus if we our on the left (denoted by if the camera is less then the player position)
    float deltaX = lookAt.position.x - transform.position.x;
    if (deltaX > boundX || deltaX < -boundX)
    {
      if (transform.position.x < lookAt.position.x)
      {
        delta.x = deltaX - boundX;
      }
      else
      {
        delta.x = deltaX + boundX;
      }
    }

    // Check if we are in the bounds on the Y axis
    float deltaY = lookAt.position.y - transform.position.y;
    if (deltaY > boundY || deltaY < -boundY)
    {
      if (transform.position.y < lookAt.position.y)
      {
        delta.y = deltaY - boundY;
      }
      else
      {
        delta.y = deltaY + boundY;
      }
    }

    transform.position += new Vector3(delta.x, delta.y, 0);
  }

}
