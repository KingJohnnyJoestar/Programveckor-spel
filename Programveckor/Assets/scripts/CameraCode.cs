using Unity.VisualScripting;
using UnityEngine;

public class CameraCode : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Transform player;
    public float maxXDistance;
    public float maxYDistance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x + maxXDistance < player.position.x)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
        else if (transform.position.x - maxXDistance > player.position.x)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }


        if (transform.position.y + maxYDistance < player.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }
        else if (transform.position.y - maxYDistance > player.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }
    }
}
