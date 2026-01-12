using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] int health;
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            die();
        }
    }
    public virtual void die()
    {
        Destroy(gameObject);
    }
}
