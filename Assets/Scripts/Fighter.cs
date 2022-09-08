using UnityEngine;

public class Fighter : MonoBehaviour
{
  public int hitpoint;
  public int maxHitpoint;
  public float pushRecoverySpeed = 0.2f;

  // Immunity
  protected float immuneTime = 1.0f;
  protected float lastImmune;

  protected Vector3 pushDirection;

  // all fighters can take dmg and die
  protected virtual void ReceiveDamage(Damage dmg)
  {
    if (Time.time - lastImmune > immuneTime)
    {
      lastImmune = Time.time;
      hitpoint -= dmg.damageAmount;
      pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

      GameManager.instance.ShowText(dmg.damageAmount.ToString(), 15, Color.red, transform.position, Vector3.zero, 0.5f);
      if (hitpoint <= 0)
      {
        hitpoint = 0;
        Death();
      }
    }
  }

  protected virtual void Death()
  {

  }
}
