using UnityEngine;

public class EnemyHitbox : Collidable
{
  // Damage
  public int damage;
  public float pushForce;

  protected override void OnCollide(Collider2D coll)
  {
    if (coll.tag == "Fighter" && coll.name == "Player")
    {
      // Create new damage object
      Damage dmg = new Damage
      {
        damageAmount = damage,
        origin = transform.position,
        pushForce = pushForce
      };

      // call the colliders ReceiveDamage function 
      coll.SendMessage("ReceiveDamage", dmg);
    }
  }
}
