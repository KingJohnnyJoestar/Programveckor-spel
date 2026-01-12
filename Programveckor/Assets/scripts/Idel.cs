using UnityEngine;

public class Idel : MonoBehaviour
{
    public float floatAmplitude = 0.3f;
    public float floatSpeed = 2f;

    private float lastYOffset;

    void LateUpdate()
    {
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        float delta = yOffset - lastYOffset;

        transform.position += new Vector3(0f, delta, 0f);

        lastYOffset = yOffset;
    }
}
