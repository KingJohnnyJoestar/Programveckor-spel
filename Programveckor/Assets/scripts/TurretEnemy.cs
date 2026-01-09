using UnityEngine;
using UnityEngine.EventSystems;

public class TurretEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float maxXposition;
    [SerializeField] float minXposition;
    Rigidbody2D rb;
    [SerializeField] Transform player;
    [SerializeField] float speed;
    [SerializeField] float maxSpeed;
    [SerializeField] float timeBetweenShots;
    float timer;
    [SerializeField] GameObject projectile;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenShots)
        {
            timer = 0;
            Vector2 movementDirection = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;
            GameObject p = Instantiate(projectile, transform.position, Quaternion.identity);
            p.GetComponent<Rigidbody2D>().linearVelocity = movementDirection;
            float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
            p.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
    }
    private void FixedUpdate()
    {
        if (player.position.x > transform.position.x && transform.position.x < maxXposition)
        {
            rb.AddForce(new Vector2(speed, 0));
            if (rb.linearVelocityX > maxSpeed)
            {
                rb.linearVelocityX = maxSpeed;
            }
        }
        else if (player.position.x < transform.position.x && transform.position.x > minXposition)
        {
            rb.AddForce(new Vector2(-speed, 0));
            if (rb.linearVelocityX < -maxSpeed)
            {
                rb.linearVelocityX = -maxSpeed;
            }
        }
        else
        {
            rb.linearVelocityX = 0;
        }

    }
}
