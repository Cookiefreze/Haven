using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class redSlimeScript : MonoBehaviour
{
    public Collider2D searchZone;
    public Rigidbody2D rb;
    public Transform playerPosition;
    public Collider2D playerCollider;
    public Slime slimeScript;
    public float speed = 3;
    public Rigidbody2D playerRb;
    public float redHealth =2;
    public ScoreScript scoreScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
{
    // Directly checks if the external searchZone is touching the player
    if (searchZone.IsTouching(playerCollider))
    {
        slimeScript.touchGrass();
        if (playerPosition.position.x > transform.position.x)
        {
            rb.linearVelocityX = 1 * speed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            rb.linearVelocityX = -1 * speed;
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
    if(playerPosition.position.y > transform.position.y + 5)
            {
                
            }
    }

                

        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == playerCollider)
        {
            
        
        slimeScript.health -= 9;
        playerRb.linearVelocity += new Vector2(-5, playerPosition.position.y - transform.position.y);
        }

    }
    public void damage()
    {
        redHealth -= 1;
        if (redHealth <= 0)
        {
            if (scoreScript == null)
            {
                scoreScript = FindFirstObjectByType<ScoreScript>();
            }

            if (scoreScript != null)
            {
                scoreScript.AddScore(1);
            }

            Destroy(gameObject);
        }
    }
}
