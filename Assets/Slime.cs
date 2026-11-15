using System;
using Unity.Mathematics;
using Unity.VisualScripting;
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
    public int jumpPower;
    public float health = 100;

    public int jumpT =  1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>().x;
        if(jump.action.WasPressedThisFrame() && jumpT != 0)
        {
            rb.linearVelocityY = jumpPower;
            jumpT -= 1;
             setJumpState(true);

        }   
         }

    private void FixedUpdate()
    {
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
        if(animator.GetBool("IsJumping") != false)
        {
            animator.SetFloat("VelocityY", rb.linearVelocityY);
            if(animator.GetFloat("VelocityY") == 0 && "animation name" == "JumpImpact slime")
            {
                animator.SetBool("IsJumping", false);
            }

        if(health == 0)
            {
                animator.SetBool("IsDead", true);
                Time.timeScale = 0f;


            }

        }

        
        else
        {
            animator.SetFloat("speed",Mathf.Abs(rb.linearVelocityX));

        }


    }
    public void setJumpState(bool boolvalue){
        animator.SetBool("IsJumping", boolvalue);
    }
    public void touchGrass()
    {
        jumpT = 1;
    }

}