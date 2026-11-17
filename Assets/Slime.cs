using System;
using Unity.AppUI.UI;
using Unity.InferenceEngine.Tokenization;
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
        animator.SetFloat("VelocityY", rb.linearVelocityY);

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
               rb.MoveRotation(Mathf.MoveTowardsAngle(
            rb.rotation,
            0f,
            rotationSpeed * Time.fixedDeltaTime));


        

        rb.linearVelocityX = _moveDirection * moveSpeed;
        if(rb.linearVelocityX < 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x,-180,transform.rotation.z);
        }
        else if(rb.linearVelocityX > 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x,0,transform.rotation.z);

        }
  
        

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
    public void notTouchingGrass()
    {
        animator.SetBool("IsTouchGround",false);
            //         float Direction = move.action.ReadValue<Vector2>().x;
            // Debug.Log(Direction);
            // if(Direction >= 0)
            // {
            //     transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y,transform.rotation.z+Direction*Time.deltaTime*10);
            // }
            // else
            // {
            // transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y,transform.rotation.z-Direction*Time.deltaTime*10);

            // }

 
            
        
    }


}
