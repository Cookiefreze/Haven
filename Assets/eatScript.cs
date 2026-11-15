using UnityEngine;

public class eatScript : MonoBehaviour

{
    public float attackRange = 1.5f;
    private redSlimeScript target;

    public void attack()
    {
        Collider2D[] nearbyColliders = Physics2D.OverlapCircleAll(
            transform.position,
            attackRange);

        foreach (Collider2D nearbyCollider in nearbyColliders)
        {
            redSlimeScript redSlime =
                nearbyCollider.GetComponentInParent<redSlimeScript>();
            if (redSlime != null)
            {
                redSlime.damage();
                return;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        redSlimeScript redSlime = collision.gameObject.GetComponent<redSlimeScript>();
        if (redSlime != null)
        {
            target = redSlime;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<redSlimeScript>() == target)
        {
            target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
