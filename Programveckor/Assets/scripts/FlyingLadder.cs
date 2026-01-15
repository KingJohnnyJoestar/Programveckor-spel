using System.Collections.Generic;
using UnityEngine;

public class FlyingLadder : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool touchingPlayer;
    Rigidbody2D playerRB;
    public List<Vector2> moveToPositions;
    Vector2 startMovingPosition;
    Vector2 currentMoveToposition;
    int moveToPositionIndex;
    Rigidbody2D rb;
    public float speed;
    void Start()
    {
        playerRB = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        if (moveToPositions.Count > 0)
        {
            startMoving(0);
        }
    }
    private void FixedUpdate()
    {
        if (touchingPlayer)
        {
            if(playerRB.linearVelocityY > 0)
            {
                playerRB.linearVelocityY = 0;
            }
        }
        if (moveToPositions.Count > 1)
        {
            if ((transform.position.x >= currentMoveToposition.x != startMovingPosition.x > currentMoveToposition.x) && (transform.position.y >= currentMoveToposition.y != startMovingPosition.y > currentMoveToposition.y))
            {
                moveToPositionIndex++;
                if (moveToPositionIndex >= moveToPositions.Count)
                {
                    moveToPositionIndex = 0;
                }
                startMoving(moveToPositionIndex);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("touching player");
            touchingPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("stopped touching player");
            touchingPlayer = false;
        }
    }
    void startMoving(int witchPosition)
    {
        startMovingPosition = transform.position;
        currentMoveToposition = moveToPositions[witchPosition];
        rb.linearVelocity = (currentMoveToposition - new Vector2(transform.position.x, transform.position.y)).normalized * speed;
        Debug.Log("changed direction " + rb.linearVelocity);
    }
}
