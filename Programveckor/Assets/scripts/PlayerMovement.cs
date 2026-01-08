using UnityEngine;

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
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(movementSpeed,0));
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(-movementSpeed, 0));
        }
        if ((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Space)) && touchingGround()) // start off jump
        {
            jumptimer = maxJumpFrames;
        }
        if ((Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Space)) && jumptimer > 0)
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
