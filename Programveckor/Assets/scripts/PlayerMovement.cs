using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    public float movementSpeed = 25;
    public float maxSpeed = 8;
    public float jumpSpeed = 40;
    int jumptimer = 0;
    public int maxJumpFrames = 15;

    public float stopSpeed = 0.4f;
    int moveX = 0;
    public float raycastDistance;
    BoxCollider2D boxColl;
    [SerializeField] LayerMask ground;

    void Start()
    {
        boxColl = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            moveX = -1;
        }
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            moveX = 1;
        }
        else
        {
            moveX = 0;
        }


        if ((Keyboard.current.zKey.wasPressedThisFrame || Keyboard.current.spaceKey.wasPressedThisFrame) && touchingGround()) // start off jump
        {
            //rb.linearVelocity = new Vector2(rb.linearVelocityX, 0);
            jumptimer = maxJumpFrames;
            Debug.Log("new jump");
        }


    }
    private void FixedUpdate()
    {

        rb.AddForce(new Vector2(movementSpeed * moveX, 0));
        if (moveX == 0)
        {
            //rb.linearVelocityX = rb.linearVelocityX / 2;
            if (rb.linearVelocityX > stopSpeed)
            {
                rb.linearVelocityX -= stopSpeed;
            }
            else if (rb.linearVelocityX < -stopSpeed)
            {
                rb.linearVelocityX += stopSpeed;
            }
            else
            {
                rb.linearVelocityX = 0;
            }
        }

        if (rb.linearVelocityX > maxSpeed)
        {
            rb.linearVelocityX = maxSpeed;
        }
        else if (rb.linearVelocityX < -maxSpeed)
        {
            rb.linearVelocityX = -maxSpeed;
        }


        if ((Keyboard.current.zKey.isPressed || Keyboard.current.spaceKey.isPressed) && jumptimer > 0)
        {
            if (rb.gravityScale > 0)
            {
                rb.AddForce(new Vector2(0, jumpSpeed));

            }
            else
            {
                rb.AddForce(new Vector2(0, -jumpSpeed));
            }
        }
        else
        {
            jumptimer = 0;
        }
        if (jumptimer > 0)
        {
            jumptimer--;
        }
    }
    bool touchingGround()
    {
        Vector2 direction = Vector2.down;
        if(rb.gravityScale < 0)
        {
            direction = Vector2.up;
        }
        return Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0f, direction, 0.1f, ground);
        //return Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, ground);
        return true;
    }
}
