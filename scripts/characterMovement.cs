using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class characterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;
    private float speed = 6f;
    private float horizontal;
    private bool Attack;
    public bool m_FacingRight = true;
    private float jumpForce = 12;
    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    bool isAttack;
    


    private void Awake(){
        rb = GetComponent<Rigidbody2D>();         
    }

    void Update(){
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer); 
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(horizontal));
        if (horizontal > 0 && !m_FacingRight)
			{
				Flip();
			}
			else if (horizontal < 0 && m_FacingRight)
			{
				Flip();
			}
        
        if (isAttack){
            animator.SetBool("isAttack", true);
        } else if(!isAttack){
            animator.SetBool("isAttack", false);
        }

        if(isGrounded){
            animator.SetBool("isGround", false);
        } else if(!isGrounded){
            animator.SetBool("isGround", true);
        }
    }

    public void OnLanding(){
        animator.SetBool("isGround", false);
    }
    public void OnAttack(){
        animator.SetBool("isAttack", false);
    }



    public void Move(InputAction.CallbackContext ctx){
        horizontal = ctx.ReadValue<Vector2>().x;
    }
    public void jump(){
        if (isGrounded)
		{
            animator.SetBool("isGround", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}
    }
    public void attack(InputAction.CallbackContext ctx){
        if(ctx.performed){
            isAttack = true;
        } else if(ctx.canceled){
            isAttack = false;
        }
    }

    void Flip(){
        m_FacingRight = !m_FacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
    }
}
