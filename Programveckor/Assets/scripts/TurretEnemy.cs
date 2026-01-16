using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float maxXposition;
    [SerializeField] float minXposition;
    Rigidbody2D rb;
    Transform player;
    [SerializeField] float speed;
    [SerializeField] float maxSpeed;
    [SerializeField] float timeBetweenShots;
    float timer;
    [SerializeField] GameObject projectile;
    public float projectileSpeed;
    public bool seePlayer;
    public Vector2 seePlayerAreaBottomLeft;
    public Vector2 seePlayerAreaTopRight;
    public bool seePlayerWhenClose;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color32(255, 30, 30, 255);
        float extraX = 0;
        float extraY = 0;
        if (seePlayerWhenClose)
        {
            extraX = transform.position.x;
            extraY = transform.position.y;
        }
        Gizmos.DrawLine(seePlayerAreaBottomLeft + new Vector2(extraX, extraY), seePlayerAreaTopRight + new Vector2(extraX, extraY));
       Gizmos.DrawLine(new Vector3(seePlayerAreaBottomLeft.x, seePlayerAreaTopRight.y) + new Vector3(extraX, extraY), new Vector3(seePlayerAreaTopRight.x, seePlayerAreaBottomLeft.y) + new Vector3(extraX, extraY));

        Gizmos.DrawLine(new Vector3(seePlayerAreaBottomLeft.x, seePlayerAreaBottomLeft.y) + new Vector3(extraX, extraY), new Vector3(seePlayerAreaTopRight.x, seePlayerAreaBottomLeft.y) + new Vector3(extraX, extraY));
        Gizmos.DrawLine(new Vector3(seePlayerAreaBottomLeft.x, seePlayerAreaTopRight.y) + new Vector3(extraX, extraY), new Vector3(seePlayerAreaTopRight.x, seePlayerAreaTopRight.y) + new Vector3(extraX, extraY));

        Gizmos.DrawLine(new Vector3(seePlayerAreaBottomLeft.x, seePlayerAreaTopRight.y) + new Vector3(extraX, extraY), new Vector3(seePlayerAreaBottomLeft.x, seePlayerAreaBottomLeft.y) + new Vector3(extraX, extraY));
        Gizmos.DrawLine(new Vector3(seePlayerAreaTopRight.x, seePlayerAreaTopRight.y) + new Vector3(extraX, extraY), new Vector3(seePlayerAreaTopRight.x, seePlayerAreaBottomLeft.y) + new Vector3(extraX, extraY));
    }

    // Update is called once per frame
    void Update()
    {
        if (seePlayerWhenClose)
        {
            seePlayer = player.transform.position.x > seePlayerAreaBottomLeft.x + transform.position.x && player.transform.position.y > seePlayerAreaBottomLeft.y + transform.position.y && player.transform.position.x < seePlayerAreaTopRight.x + transform.position.x && player.transform.position.y < seePlayerAreaTopRight.y + transform.position.y;
        }
        else
        {
            seePlayer = player.transform.position.x > seePlayerAreaBottomLeft.x && player.transform.position.y > seePlayerAreaBottomLeft.y && player.transform.position.x < seePlayerAreaTopRight.x && player.transform.position.y < seePlayerAreaTopRight.y;
        }
        if (seePlayer && gameObject.layer != 6)
        {
            if (DimensionChanger.dimension == 3)
            {
                timer += Time.deltaTime;
            }
            timer += Time.deltaTime;
            if (timer > timeBetweenShots)
            {
                timer = 0;
                Vector2 movementDirection = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized * projectileSpeed;
                GameObject p = Instantiate(projectile, transform.position, Quaternion.identity);
                p.GetComponent<Rigidbody2D>().linearVelocity = movementDirection;
                float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
                p.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            }
        }
    }
    private void FixedUpdate()
    {
        if (seePlayer && DimensionChanger.dimension != 3 && speed != 0)
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
}
