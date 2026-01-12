using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DimensionChanger : InteractableObject
{
    public static int dimension; // eftersom dimension är public static så kan man komma åt den var som hellst med DimiensionChanger.dimension
    [SerializeField] List<GameObject> dimensions;
    public override void Interact()
    {

        dimension++;
        if (dimension > 3)
        {
            dimension = 1;
        }
        GravityChange[] gravityObjects = FindObjectsOfType<GravityChange>();
        foreach (GravityChange g in gravityObjects)
        {
            g.ChangeDimension(dimension);
        }
        GameObject.FindWithTag("MainCamera").GetComponent<CameraCode>().SwitchDimension(dimension);
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().respawnPos = transform.position;
        for (int i = 1; i < dimensions.Count; i++)
        {
            dimensions[i].SetActive(i == dimension);
        }
    }
}
