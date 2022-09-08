
using UnityEngine;

public class Player : Mover
{

  private void FixedUpdate()
  {

    // returns left: -1, none: 0, right: 1. these are set in input manager
    float x = Input.GetAxisRaw("Horizontal");
    float y = Input.GetAxisRaw("Vertical");

    UpdateMotor(new Vector3(x, y, 0));
  }
}

