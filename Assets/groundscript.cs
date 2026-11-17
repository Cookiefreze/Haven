using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class groundscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Slime playerscript;
    public Collider2D playerCollider;
    public TilemapCollider2D tilemapCollider2D;
    public redSlimeScript redSlimeScript;
    public Collider2D slimeCollider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void IsPlayerOnGround(bool ifRedSlimeTouch)
    {
                if (tilemapCollider2D.IsTouching(playerCollider) || ifRedSlimeTouch)
        {
                        playerscript.touchGrass();

        }
        else
        {
                        playerscript.notTouchingGrass();

        }
    }
}
