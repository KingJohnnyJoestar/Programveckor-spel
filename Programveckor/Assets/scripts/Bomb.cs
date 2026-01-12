using UnityEngine;

public class Bomb : Item
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool active;
    GameObject explosion;
    public override void Drop()
    {
        base.Drop();
        active = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (active && collision.gameObject.tag != "Player")
        {
            //döda fiender
            //Instantiate(explosion);
            GetComponent<ResetPosition>().Reset();
            active = false;
        }
    }
}
