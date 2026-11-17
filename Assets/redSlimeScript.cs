using System.Security.Cryptography;
using Unity.InferenceEngine;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Timeline;
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
    public Collider2D redSlimeCollider;
    public float redHealth =2;
    public bool IsTouchingRedSlime = false;
    public groundscript groundscript;
    public redSlimeScript redSlimeScripts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        slimeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Slime>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        redSlimeCollider = gameObject.GetComponent<Collider2D>();
        groundscript = GameObject.FindAnyObjectByType<groundscript>().GetComponent<groundscript>();


    }

    // Update is called once per frame
    void Update()
    {

                if(redSlimeCollider.IsTouching(playerCollider))
            {
                 groundscript.IsPlayerOnGround(true);

                                    

            
        
        slimeScript.health -= 9;
        playerRb.linearVelocity += new Vector2(-5, playerPosition.position.y - transform.position.y);
            }
        else
        {
            int i =0;
        
                foreach(GameObject _gameObject in GameObject.FindGameObjectsWithTag("RedSlime")){
        redSlimeScripts = _gameObject.GetComponent<redSlimeScript>();
        i += 1;
        

            if (redSlimeScripts.check())
            {
                groundscript.IsPlayerOnGround(true);

            }
                else
                {
                    if(i==GameObject.FindGameObjectsWithTag("RedSlime").Length){
                        groundscript.IsPlayerOnGround(true);
                    }
                }
            }
        }
        
    }
    void FixedUpdate()
{
    // Directly checks if the external searchZone is touching the player
    if (searchZone.IsTouching(playerCollider))
    {
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

        }

    }
    public void damage()
    {
        redHealth -= 1;
        if (redHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public bool check()
    {
        if (redSlimeCollider.IsTouching(playerCollider))
        {
            IsTouchingRedSlime = true;
        }
        else
        {
            IsTouchingRedSlime = false;
        }
        return IsTouchingRedSlime;
    }
}
