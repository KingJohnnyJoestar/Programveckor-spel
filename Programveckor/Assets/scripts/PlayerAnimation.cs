using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] int lastDirection;
    PlayerMovement movement;
    Animator anim;
    [SerializeField] string runLeft;
    [SerializeField] string idleLeft;
    [SerializeField] string jumpLeft;
    [SerializeField] string fallLeft;
    float jumpTimer;
    [SerializeField] float jumpAnimationTime;
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpTimer += Time.deltaTime;
        int currentDirection = movement.GetDirection();
        if (currentDirection != 0)
        {
            lastDirection = currentDirection;
        }
        if (lastDirection == -1)
        {
            if (DimensionChanger.dimension == 2)
            {
                transform.rotation = new Quaternion(180, 0, 0, 0);
            }
            else
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
        else
        {
            if (DimensionChanger.dimension == 2)
            {
                transform.rotation = new Quaternion(0, 0, 180, 0);
            }
            else
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
        }
        if (movement.touchingGround())
        {
            if (currentDirection == 0)
            {
                anim.Play(idleLeft);
            }
            else
            {
                anim.Play(runLeft);
            }
        }
        else
        {
            //if (jumpTimer > jumpAnimationTime)
            //{
            //    anim.Play(fallLeft);
            //}
        }
    }
    public void startJump()
    {
        anim.Play(jumpLeft);
        jumpTimer = 0;
    }

}
