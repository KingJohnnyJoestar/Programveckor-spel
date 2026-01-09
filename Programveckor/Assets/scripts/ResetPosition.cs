using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public Vector2 startPosition;
    //public bool willReset = true;
    public bool deleteOnReset;
    private void Start()
    {
        startPosition = transform.position;
    }
    public void Reset()
    {
        if (deleteOnReset)
        {
            Destroy(gameObject);
        }
        transform.position = startPosition;
    }
}
