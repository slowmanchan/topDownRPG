
using UnityEngine;

public abstract class Mover : Fighter
{
  protected BoxCollider2D boxCollider;
  protected Vector3 moveDelta;
  protected RaycastHit2D hit;
  protected float ySpeed = 0.75f;
  protected float xSpeed = 1.0f;
  protected virtual void Start()
  {
    // Get boxcollider from player so that we can use it in oour script
    boxCollider = GetComponent<BoxCollider2D>();
  }

  protected virtual void UpdateMotor(Vector3 input)
  {
    // Reset MoveDelta
    moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

    // swap sprite direction, whether going right or left
    if (moveDelta.x > 0)
      // saves memory, could also use new Vector3(1,1,1);
      transform.localScale = Vector3.one;
    else if (moveDelta.x < 0)
      transform.localScale = new Vector3(-1, 1, 1);


    // push toon if attacked
    moveDelta += pushDirection;

    // reduce  push force
    pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);
    // this will move the character. 
    // Note: we mulitply by deltaTime for differing device speeds
    // if we didnt, faster devices with better framerates would actually move quicker.
    // make sure we can move in this direction by casting a box there first, If the box is null, we are free to move.

    hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
    if (hit.collider == null)
    {
      transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
    }

    hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
    if (hit.collider == null)
    {
      transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
    }

  }

}
