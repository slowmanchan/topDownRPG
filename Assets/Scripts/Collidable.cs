using UnityEngine;

public class Collidable : MonoBehaviour
{
  public ContactFilter2D filter;
  private BoxCollider2D boxCollider;
  private Collider2D[] hits = new Collider2D[10];

  // virtual makes these inheritable
  protected virtual void Start()
  {
    boxCollider = GetComponent<BoxCollider2D>();
  }

  protected virtual void Update()
  {
    boxCollider.OverlapCollider(filter, hits);
    for (int i = 0; i < hits.Length; i++)
    {
      if (hits[i] == null)
        continue;

      OnCollide(hits[i]);

      // We need to clean up the array to reset our hits
      hits[i] = null;
    }
  }

  protected virtual void OnCollide(Collider2D coll)
  {
    Debug.Log(coll.name);
  }
}
