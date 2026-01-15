using System.Collections.Generic;
using UnityEngine;

public class Background_2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Transform cameraObject;
    private void Start()
    {
        transform.position = new Vector3(cameraObject.position.x, cameraObject.position.y, transform.position.z);
        Debug.Log(transform.position);
    }
    private void Update()
    {
        transform.position = new Vector3(cameraObject.position.x, cameraObject.position.y, transform.position.z);
    }
}
