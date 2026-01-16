using UnityEngine;

public class DamageEnemies : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyHealth>())
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(damage);
        }else if (collision.GetComponent<octoBoss>())
        {
            collision.GetComponent<octoBoss>().damage();
        }
    }
}
