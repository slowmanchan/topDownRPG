using UnityEngine;

public class Collectable : Collidable
{
  // protected is private to a class but visible to children
  protected bool collected;

  protected override void OnCollide(Collider2D coll)
  {
    if (coll.name == "Player")
      OnCollect();
  }

  protected virtual void OnCollect()
  {
    collected = true;
  }
}
