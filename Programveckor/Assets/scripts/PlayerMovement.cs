using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    public float movementSpeed;
    public float maxSpeed;
    public float jumpSpeed;
    int jumptimer = 0;
    public int maxJumpFrames;

    public float stopSpeed;
    int moveX = 0;

    void Start()
    {
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
            rb.AddForce(new Vector2(0, jumpSpeed));
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
        return true; // temporär kod
    }
}
