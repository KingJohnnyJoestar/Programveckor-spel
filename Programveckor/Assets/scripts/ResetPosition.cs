using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public Vector2 startPosition;
    Vector3 startRotation;
    //public bool willReset = true;
    public bool deleteOnReset;
    private void Awake()
    {
        startPosition = transform.position;
        startRotation = new Vector3(Quaternion.identity.x, Quaternion.identity.z, Quaternion.identity.z); ;
    }
    public virtual void ResetPos()
    {
        if (GetComponent<Rigidbody2D>())
        {
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().angularVelocity = 0f;
        }
        if (deleteOnReset)
        {
            Destroy(gameObject);
        }
        transform.position = startPosition;
        Quaternion.Euler(startRotation);
    }
}
