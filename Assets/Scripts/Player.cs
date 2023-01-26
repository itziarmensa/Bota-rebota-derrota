using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 500f;
    private Animator animator;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        float moveY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, moveY * moveSpeed);

        if(moveX != 0)
        {
            animator.SetTrigger("PlayerRun");

        }else if(moveY != 0){

            animator.SetTrigger("PlayerJump");
        }
    }
}

