using UnityEngine;
public class Enemy : Mover
{
  // Experience
  public int xpValue = 1;

  // Logic
  public float triggerLength;
  public float chaseLength;
  private bool chasing;
  private bool collidingWithPlayer;
  private Transform playerTransform;
  private Vector3 startingPosition;

  // Hitbox
  private BoxCollider2D hitbox;
  public ContactFilter2D filter;
  private Collider2D[] hits = new Collider2D[10];

  protected override void Start()
  {

    base.Start();
    xSpeed = 0.45f;
    ySpeed = 0.45f;
    playerTransform = GameManager.instance.player.transform;
    startingPosition = transform.position;
    hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
  }

  private void FixedUpdate()
  {
    // Is the player in range?
    if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)
    {
      if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLength)
        chasing = true;

      if (chasing)
      {
        if (!collidingWithPlayer)
        {
          UpdateMotor((playerTransform.position - transform.position).normalized);
        }
      }
      else
      {
        UpdateMotor(startingPosition - transform.position);
      }
    }
    else
    {
      UpdateMotor(startingPosition - transform.position);
      chasing = false;
    }

    // Check for overlaps
    collidingWithPlayer = false;
    boxCollider.OverlapCollider(filter, hits);
    for (int i = 0; i < hits.Length; i++)
    {
      if (hits[i] == null)
        continue;

      if (hits[i].tag == "Fighter" && hits[i].name == "Player")
      {
        collidingWithPlayer = true;
      }
      // We need to clean up the array to reset our hits
      hits[i] = null;
    }
  }

  protected override void Death()
  {
    Destroy(gameObject);
    GameManager.instance.experience += xpValue;
    GameManager.instance.ShowText("+" + xpValue + " xp", 30, Color.magenta, transform.position, Vector3.up * 40, 1.0f);
  }
}
