using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class Slime : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float rotationSpeed = 180f;
    private float _moveDirection;
    public InputActionReference jump;
    public Animator animator;

    public InputActionReference move;
    public InputActionReference eat;
    public float jumpPower = 10f;
    public float health = 100;
    public eatScript eatScript;

    public int jumpT =  1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    
    {
        if (eat.action.WasPressedThisFrame())
        {
            animator.SetTrigger("eat");
            eatScript.attack();

        }

        _moveDirection = move.action.ReadValue<Vector2>().x;
        if(jump.action.WasPressedThisFrame() && jumpT != 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpPower);
            jumpT -= 1;
             setJumpState();

        }   
         }

    private void FixedUpdate()
    {
        animator.SetBool("IsTouchGround", false);

        rb.linearVelocityX = _moveDirection * moveSpeed;
        if(rb.linearVelocityX < 0)
        {
            transform.rotation = Quaternion.Euler(0,-180,0);
        }
        else if(rb.linearVelocityX > 0)
        {
            transform.rotation = Quaternion.Euler(0,0,0);

        }
        rb.MoveRotation(Mathf.MoveTowardsAngle(
            rb.rotation,
            0f,
            rotationSpeed * Time.fixedDeltaTime));
        
            animator.SetFloat("VelocityY", rb.linearVelocityY);

        if(health == 0)
            {
                animator.SetBool("IsDead", true);
                Time.timeScale = 0f;


            }

        

        
        else
        {
            animator.SetFloat("speed",Mathf.Abs(rb.linearVelocityX));

        }


    }
    public void setJumpState(){
        animator.SetTrigger("IsJumping");
    }
    public void touchGrass()
    {
        jumpT = 1;
        animator.SetBool("IsTouchGround", true);
    }

}