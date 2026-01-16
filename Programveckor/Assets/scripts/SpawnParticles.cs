using System.Collections.Generic;
using UnityEngine;

public class SpawnParticles : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<GameObject> particles;
    public float maxXspeed;
    public float maxYspeed;
    public float minYSpeed;
    public int particlesSpawned;
    void Start()
    {
        for (int i = 0; i < particlesSpawned; i++)
        {
            Instantiate(particles[Random.Range(0, particles.Count)], transform.position, Quaternion.identity).GetComponent<Rigidbody2D>().linearVelocity = new Vector2(Random.Range(-maxXspeed, maxXspeed), Random.Range(minYSpeed, maxYspeed));
        }
    }
}
