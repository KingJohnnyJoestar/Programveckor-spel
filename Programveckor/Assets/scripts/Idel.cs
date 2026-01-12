using UnityEngine;

public class Idel : MonoBehaviour
{
    [Header("Float Settings")]
    public float floatAmplitude = 0.5f; // Hur högt/lågt spöket rör sig
    public float floatSpeed = 1f;        // Hur snabbt det rör sig

    private Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = startPosition + new Vector3(0f, yOffset, 0f);
    }
}
