using UnityEngine;

public class eatScript : MonoBehaviour

{
    public float attackRange = 1.5f;
    private Collider2D target;


    void Start()
    {
    }
    public void attack()
    {
        Collider2D[] nearbyColliders = Physics2D.OverlapCircleAll(
            transform.position,
            attackRange);

        foreach (Collider2D nearbyCollider in nearbyColliders)
        {

            redSlimeScript redSlime =
                nearbyCollider.GetComponent<redSlimeScript>();
            if (redSlime != null)
            {
                redSlime.damage();
                return;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Collider2D redSlime = collision.gameObject.GetComponent<Collider2D>();
        if (redSlime != null)
        {
            target = redSlime;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Collider2D>() == target)
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
