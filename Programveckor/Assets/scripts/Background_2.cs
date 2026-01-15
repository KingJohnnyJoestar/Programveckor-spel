using UnityEngine;

public class Background_2 : MonoBehaviour
{
    public Camera mainCamera;
    public Vector3 offset = new Vector3(0, 0, 11); // Adjust Z to keep background behind

    void LateUpdate()
    {
        // Keep background aligned with camera
        transform.position = mainCamera.transform.position + offset;
    }
}