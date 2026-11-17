using UnityEngine;

public class groundscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Slime playerscript;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Slime player = collision.gameObject.GetComponentInParent<Slime>();
        if (player != null)
        {
            player.touchGrass();
        }
    }
}
