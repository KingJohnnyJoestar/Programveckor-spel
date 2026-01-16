using UnityEngine;

public class Bomb : Item
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool active;
    public GameObject explosion;
    public override void Drop()
    {
        base.Drop();
        active = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (active && collision.gameObject.tag != "Player")
        {
            explode();
        }
    }
    public void explode()
    {
        //döda fiender
        Instantiate(explosion, transform.position, Quaternion.identity);
        //GetComponent<ResetPosition>().ResetPosition();
        gameObject.SetActive(false);
        active = false;
    }
}
