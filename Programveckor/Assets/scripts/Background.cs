using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Background : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Transform cameraObject;
    //[SerializeField] Transform staticBackground;
    List<List<GameObject>>backgroundObjects = new List<List<GameObject>>();
    [SerializeField] List<GameObject> backgroundPrefabs;
    [SerializeField] List<float> prefabYposition;
    [SerializeField] float backgroundObjectSpeed;
    [SerializeField] float distance;
    [SerializeField] int dimension;
    private void Start()
    {
        for(int i = 0; i < backgroundObjects.Count; i++)
        {
            for (int i2 = backgroundObjects[i].Count; i2 > 0; i2++)
            {
                Destroy(backgroundObjects[i][i2]);
            }
        }
        backgroundObjects = new List<List<GameObject>>();
        int a = 0;
        foreach(GameObject prefab in backgroundPrefabs)
        {
            float xposition = -distance + prefab.GetComponent<SpriteRenderer>().size.x * prefab.transform.localScale.x / 2;
            backgroundObjects.Add(new List<GameObject>());
            while (xposition + (prefab.GetComponent<SpriteRenderer>().size.x * prefab.transform.localScale.x / 2) < distance)
            {
                backgroundObjects[backgroundObjects.Count - 1].Add(Instantiate(prefab, new Vector2(xposition, prefabYposition[a]), Quaternion.identity, transform));
                Debug.Log(transform.localPosition.y + " spawn pos y  " + prefabYposition[a]);
                xposition += prefab.GetComponent<SpriteRenderer>().size.x * prefab.transform.localScale.x;
            }
            a++;
        }
        transform.position = new Vector3(cameraObject.position.x, cameraObject.position.y, 0.1f);
        Debug.Log(transform.position);
        //moveMaxXPos = cameraObject.GetComponent<Camera>().orthographicSize * 2;
        //moveMinXPos = -cameraObject.GetComponent<Camera>().orthographicSize * 2;
    }
    private void Update()
    {
        float xMovement = (transform.position.x - cameraObject.position.x) * backgroundObjectSpeed;
        transform.position = new Vector3(cameraObject.position.x, cameraObject.position.y, transform.position.z);

        foreach (List<GameObject> backgroundList in backgroundObjects)
        {
            if (backgroundList.Count > 0)
            {
                foreach (GameObject backgroundObj in backgroundList)
                {
                    backgroundObj.transform.localPosition = new Vector2(backgroundObj.transform.localPosition.x + xMovement, backgroundObj.transform.localPosition.y);
                }
                if (xMovement > 0)
                {
                    //Debug.Log(EdgeBackgroundObject(backgroundList, true).transform.localPosition.x + " > " + backgroundList[0].GetComponent<SpriteRenderer>().size.x * backgroundList[0].transform.localScale.x + moveMaxXPos + "   " + (EdgeBackgroundObject(backgroundList, true).transform.localPosition.x > backgroundList[0].GetComponent<SpriteRenderer>().size.x * backgroundList[0].transform.localScale.x + moveMaxXPos));

                    if (EdgeBackgroundObject(backgroundList, true).transform.localPosition.x > distance)
                    {
                        Debug.Log("flytta object  " + EdgeBackgroundObject(backgroundList, xMovement > 0).transform.localPosition.x + "-->" + -distance);
                        EdgeBackgroundObject(backgroundList, true).transform.localPosition = new Vector2(-distance, backgroundList[0].transform.localPosition.y);
                    }
                }
                else if (xMovement < 0)
                {
                    //Debug.Log(EdgeBackgroundObject(backgroundList, false).transform.localPosition.x + " < " + backgroundList[0].GetComponent<SpriteRenderer>().size.x * -backgroundList[0].transform.localScale.x + moveMinXPos + "   " + (EdgeBackgroundObject(backgroundList, false).transform.localPosition.x < backgroundList[0].GetComponent<SpriteRenderer>().size.x * backgroundList[0].transform.localScale.x + moveMinXPos));

                    if (EdgeBackgroundObject(backgroundList, false).transform.localPosition.x < -distance)
                    {
                        Debug.Log("flytta object  " + EdgeBackgroundObject(backgroundList, xMovement > 0).transform.localPosition.x + "-->" + distance);
                        EdgeBackgroundObject(backgroundList, false).transform.localPosition = new Vector2(distance, backgroundList[0].transform.localPosition.y);
                    }
                }
            }
        }
    }
    GameObject EdgeBackgroundObject(List<GameObject> objects, bool highestXValue)
    {
        GameObject currentObject = objects[0];
        foreach(GameObject obj in objects)
        {
            if (highestXValue)
            {
                if (obj.transform.position.x > currentObject.transform.position.x)
                {
                    currentObject = obj;
                }
            }
            else
            {
                if (obj.transform.position.x < currentObject.transform.position.x)
                {
                    currentObject = obj;
                }
            }
        }
        return currentObject;
    }
}
