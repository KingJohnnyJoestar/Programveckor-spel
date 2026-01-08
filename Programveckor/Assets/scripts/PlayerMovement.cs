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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            rb.AddForce(new Vector2(-movementSpeed,0));
        }
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            rb.AddForce(new Vector2(movementSpeed, 0));
        }
        if ((Keyboard.current.zKey.wasPressedThisFrame || Keyboard.current.spaceKey.wasPressedThisFrame) && touchingGround()) // start off jump
        {
            jumptimer = maxJumpFrames;
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
