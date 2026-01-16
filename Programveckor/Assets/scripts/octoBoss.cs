using System.Collections.Generic;
using UnityEngine;

public class octoBoss : ResetPosition
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int maxhp;
    public int hp;
    Rigidbody2D rb;
    float timer;
    public int nextAttack;
    float goToXPos;
    GameObject player;
    public float fallAttackTimer;
    public float preFallSpeed;
    public float fallSpeed;
    public GameObject tentacle;
    public float timeBetweenTentacles;
    float tentacleTimer;
    public Vector2 tentacleSpawnPosition;
    int leftOrRight = 1;
    public int tentacles;
    int tentaclesSpawned;
    public float tentacleSpeed;
    public List<int> attacksUntilDamage;
    int damageSpawnTimer;
    Vector2 spawnPos;
    void Start()
    {
        ResetPos();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        spawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (nextAttack == 0 && timer > fallAttackTimer)
        {
            if(transform.position.y < -5)
            {
                nextAttack = 1;
                rb.linearVelocity = new Vector2(0, 0);
                resetAttack();
                //tentacleTimer = 3;
                goToXPos = 0;
                tentacleTimer = 2;
            }
            else if (goToXPos == 0)
            {
                goToXPos = player.transform.position.x;
                if (goToXPos > transform.position.x)
                {
                    rb.linearVelocityX = preFallSpeed;
                }
                else
                {
                    rb.linearVelocityX = -preFallSpeed;
                }
            }else if(goToXPos > transform.position.x == rb.linearVelocityX < 0)
            {
                rb.linearVelocity = new Vector2(0, -fallSpeed);
            }
        }else if (nextAttack == 1)
        {
            tentacleTimer += Time.deltaTime;
            if (tentacleTimer > timeBetweenTentacles)
            {
                GameObject t = Instantiate(tentacle, new Vector2(tentacleSpawnPosition.x * leftOrRight, tentacleSpawnPosition.y), Quaternion.identity);
                t.GetComponent<Rigidbody2D>().linearVelocityY = tentacleSpeed;
                if (leftOrRight != 1)
                {
                    t.transform.rotation = Quaternion.Euler(0,180,0);
                }
                leftOrRight = -leftOrRight;
                tentacleTimer = 0;
                tentaclesSpawned++;
            }
            if (tentaclesSpawned > tentacles)
            {
                tentaclesSpawned = 0;
                nextAttack = 0;
                resetAttack();
            }
        }

    }
    public override void ResetPos()
    {
        base.ResetPos();
        hp = maxhp;
        nextAttack = 0;
    }
    void resetAttack()
    {
        timer = 0;
        damageSpawnTimer++;
        transform.position = spawnPos;
        rb.linearVelocity = new Vector2(0, 0);
    }
}
