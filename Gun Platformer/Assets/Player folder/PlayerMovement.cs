using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float acceleration = 50f;     // Force when pressing a direction
    [SerializeField] float deceleration = 30f;     // Force when no input, slows down
    [SerializeField] float maxSpeedX = 10f;
    [SerializeField] float maxSpeedY = 10f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] ContactFilter2D groundFilter;

    Rigidbody2D rb;
    Animator ani;
    Collider2D bodyColl;
    Collider2D feetColl;
    ParticleSystem dust;

    Vector2 moveInput;
    bool shouldJump;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        dust = GetComponentInChildren<ParticleSystem>();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump()
    {
        if (isGrounded)
            shouldJump = true;
    }


    // Update is called once per frame
    void Update()
    {
        //Mirror the sprite if moving left
        //if (moveInput.x != 0)
        //{
        //    transform.localScale = new Vector2(Mathf.Sign(moveInput.x), transform.localScale.y);
        //}

    }
    void FixedUpdate()
    {
        //Ground check
        isGrounded = rb.IsTouching(groundFilter);

        //Jump function
        if (isGrounded && shouldJump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            shouldJump = false;
            //dust.Play(); //Play particle effect
        }

        //Horizontal movement
        if (moveInput.x != 0)
        {
            //Accelerate
            rb.AddForce(new Vector2(moveInput.x * acceleration, 0f), ForceMode2D.Force);
        }
        else if (isGrounded)
        {
            //Decelerate
            rb.AddForce(new Vector2(-rb.linearVelocity.x * deceleration, 0f), ForceMode2D.Force);
        }

        // Clamp max horizontal velocity
        if (Mathf.Abs(rb.linearVelocity.x) > maxSpeedX)
        {
            rb.linearVelocity = new Vector2(Mathf.Sign(rb.linearVelocity.x) * maxSpeedX, rb.linearVelocity.y);
        }

        if (Mathf.Abs(rb.linearVelocity.y) > maxSpeedY)
        {  
                rb.linearVelocity = new Vector2(rb.linearVelocityX, Mathf.Sign(rb.linearVelocity.y) * maxSpeedY);
        }
        }
}
