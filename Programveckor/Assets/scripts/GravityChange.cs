using UnityEngine;

public class GravityChange : MonoBehaviour
{
    static float gravityDimension1 = 1.6f;
    static float gravityDimension2 = -1.6f;
    static float gravityDimension3 = 1.1f;
    public void ChangeDimension(int newDimension)
    {
        if (newDimension == 1)
        {
            GetComponent<Rigidbody2D>().gravityScale = gravityDimension1;
        }
        else if (newDimension == 2)
        {
            GetComponent<Rigidbody2D>().gravityScale = gravityDimension2;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = gravityDimension3;
        }
    }
}
