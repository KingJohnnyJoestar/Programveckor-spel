using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraCode : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Transform player;
    public float maxXDistance;
    public float maxYDistance;
    [SerializeField] List<Color32> dimensionColors = new List<Color32>();
    public float minHeight;
    private void Awake()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color32(70, 255, 70, 255);
        Gizmos.DrawLine(new Vector2(-1000, minHeight), new Vector2(1000, minHeight));
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x + maxXDistance < player.position.x)
        {
            transform.position = new Vector3(player.position.x - maxXDistance, transform.position.y, transform.position.z);
        }
        else if (transform.position.x - maxXDistance > player.position.x)
        {
            transform.position = new Vector3(player.position.x + maxXDistance, transform.position.y, transform.position.z);
        }


        if (transform.position.y + maxYDistance < player.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.position.y - maxYDistance, transform.position.z);
        }
        else if (transform.position.y - maxYDistance > player.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.position.y + maxYDistance, transform.position.z);
        }
        if (transform.position.y < minHeight)
        {
            transform.position = new Vector3(transform.position.x, minHeight, transform.position.z);
        }
    }
    public void SwitchDimension(int newDimension)
    {
        GetComponent<Camera>().backgroundColor = dimensionColors[newDimension];
    }
}
