using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Background : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Transform cameraObject;
    [SerializeField] Transform staticBackground;
    [SerializeField] List<GameObject> backgroundObjects;
    [SerializeField] float backgroundObjectSpeed; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = (transform.position.x - cameraObject.position.x) * -backgroundObjectSpeed;
        transform.position = new Vector3(cameraObject.position.x, cameraObject.position.y, 0.1f);
        foreach (GameObject backgroundObj in backgroundObjects)
        {
            backgroundObj.transform.localPosition = new Vector2(backgroundObj.transform.localPosition.x + xMovement, backgroundObj.transform.localPosition.y);
        }
        //staticBackground.position = player.position;

    }
}
