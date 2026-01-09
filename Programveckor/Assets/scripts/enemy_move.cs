using UnityEngine;

public class enemy_move : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    public GameObject Enemy;
    public GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enemy.transform.position = Vector2.MoveTowards(Enemy.transform.position, Player.transform.position, speed);
    }
    private void OnCollisionEnter(Collision Player)
    {
        
    }
}
