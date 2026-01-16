using Unity.VisualScripting;
using UnityEngine;

public class enemy_move : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Enemy; // Put on enemy 
    public GameObject Player; // Put on the player

    // Enemy speed & chasse distance (Non changebal)
    public float speed = 1; //                   Speed - Recomended 0.05
    public float EnemyrAlertDistance = 5; //     Enemy minmum distance to player to start a chase
    public float EnemyChasseMaxDistance = 10; // Enemy minmum distances to discontinue an active chase
    
    // Enemy data (Can't be changed)
    private Vector3 EnemySpawnPosition;
    private float Distance;
    private bool ActiveAtack; 

    void Start()
    {
        EnemySpawnPosition = Enemy.transform.position;
    }
    
    
    // Update is called once per frame
    void Update()
    
    {
        
        
        
        // Data to make atack calulation
        Distance = GetDistance(); 
        ActiveAtack = GetAtackValidationCalculation();

        if (ActiveAtack == true)
        {
            
            Chasse();
        }
        else
        {
            if (EnemySpawnPosition == Enemy.transform.position)
            {
                
                return;
            }
            else
            {
                
                ReturninToSpawn();
            }
            
        }
    }
    private void Chasse() // Moves enemy towards player.
    {
        
        Enemy.transform.position = Vector2.MoveTowards(Enemy.transform.position, Player.transform.position, speed);
        return;
    }
    private void ReturninToSpawn() // Return enemy to starting postion
    {
        Enemy.transform.position = Vector2.MoveTowards(Enemy.transform.position, EnemySpawnPosition, speed);
        return;
    }
    private float GetDistance() // Mesures player & Enemy distance in X & Y
    {
        float Distance = Vector2.Distance(Enemy.transform.position, Player.transform.position);
        return Distance;
    }
    private bool GetAtackValidationCalculation()
    {
        if (ActiveAtack == true)
        {
            if (Distance <= EnemyChasseMaxDistance)
            {
                return true;
            }
        }
        
        if (ActiveAtack == false)
        {
            if (Distance <= EnemyrAlertDistance)
            {
                return true;
            }
        }
        return false;
    }
}