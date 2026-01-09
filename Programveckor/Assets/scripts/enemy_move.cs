using UnityEngine;

public class enemy_move : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 1;
    public float PlayerAlertDistance = 5; 
    public GameObject Enemy;
    public GameObject Player;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
       
    {
        // Chase script
        float Distance = Vector2.Distance(Enemy.transform.position, Player.transform.position); // Measures player distance with the enemy


        if (Distance < PlayerAlertDistance) //Trigers when close to the enemy
        {
            Enemy.transform.position = Vector2.MoveTowards(Enemy.transform.position, Player.transform.position, speed);
        }
    }
}
