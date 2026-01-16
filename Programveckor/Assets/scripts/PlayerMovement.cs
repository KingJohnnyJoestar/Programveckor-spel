using System;
using System.Collections.Generic;
using System.Xml;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    public float movementSpeed = 25;
    public float waterSpeed;
    public float maxSpeed = 8;
    public float waterMaxSpeed;
    public float jumpSpeed = 40;
    int jumptimer = 0;
    public int minJumpFrames;
    public int maxJumpFrames = 15;

    public float stopSpeed = 0.4f;
    int moveX = 0;
    BoxCollider2D boxColl;
    [SerializeField] LayerMask ground;
    //[SerializeField] int gameOverScene;
    public Vector2 respawnPos;
    PlayerAnimation anim;
    int lastDirection;
    void Start()
    {
        Debug.Log(transform.position);
        boxColl = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<PlayerAnimation>();
        respawnPos = transform.position;
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
            anim.startJump();
        }


    }
    private void FixedUpdate()
    {
        if (moveX != 0)
        {
            lastDirection = moveX;
            if (DimensionChanger.dimension == 3)
            {
                rb.AddForce(new Vector2(waterSpeed * moveX, 0));
            }
            else
            {
                rb.AddForce(new Vector2(movementSpeed * moveX, 0));
            }
        }
        else
        {
            if (lastDirection == -1)
            {
                if (rb.linearVelocityX >= 0)
                {
                    rb.linearVelocityX = 0;
                    lastDirection = 0;
                }
            }
            else
            {
                if (rb.linearVelocityX <= 0)
                {
                    rb.linearVelocityX = 0;
                    lastDirection = 0;
                }
            }
            if (lastDirection != 0)
            {
                if (DimensionChanger.dimension == 3)
                {
                    rb.AddForce(new Vector2(waterSpeed * -lastDirection, 0));
                }
                else
                {
                    rb.AddForce(new Vector2(movementSpeed * -lastDirection, 0));
                }
            }
            ////rb.linearVelocityX = rb.linearVelocityX / 2;
            //if (rb.linearVelocityX > stopSpeed)
            //{
            //    rb.linearVelocityX -= stopSpeed;
            //}
            //else if (rb.linearVelocityX < -stopSpeed)
            //{
            //    rb.linearVelocityX += stopSpeed;
            //}
            //else
            //{
            //    rb.linearVelocityX = 0;
            //}
        }
        float currentMaxSpeed = maxSpeed;
        if (DimensionChanger.dimension == 3)
        {
            currentMaxSpeed = waterMaxSpeed;
        }
        if (rb.linearVelocityX > currentMaxSpeed)
        {
            rb.linearVelocityX = currentMaxSpeed;
        }
        else if (rb.linearVelocityX < -currentMaxSpeed)
        {
            rb.linearVelocityX = -currentMaxSpeed;
        }
        

        if (((Keyboard.current.zKey.isPressed || Keyboard.current.spaceKey.isPressed) && jumptimer > 0) || jumptimer > maxJumpFrames - minJumpFrames)
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
    public bool touchingGround()
    {
        Vector2 direction = Vector2.down;
        if(rb.gravityScale < 0)
        {
            direction = Vector2.up;
        }
        return Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0f, direction, 0.1f, ground);
    }
    public void die()
    {
        GetComponent<PickUpObject>().Reset();
        rb.linearVelocityX = 0;
        rb.linearVelocityY = 0;
        //if (rb.gravityScale < 0)
        //{
        //    rb.gravityScale = -rb.gravityScale;
        //}
        transform.position = respawnPos;
        Debug.Log("die");

        ResetPosition[] resetObjects = FindObjectsOfType<ResetPosition>();
        foreach (ResetPosition resetobj in resetObjects)
        {
            resetobj.ResetPos();
        }
        //SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(gameOverScene));
    }
    public int GetDirection()
    {
        return moveX;
    }
}
