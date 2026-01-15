using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DimensionChanger : InteractableObject
{
    public static int dimension = 1; // eftersom dimension är public static så kan man komma åt den var som hellst med DimiensionChanger.dimension
    [SerializeField] List<GameObject> dimensions;
    public Vector2 teleportPosition;
    public int becomeSpecifikDimension;
    GameObject player;
    GameObject camera;
    [SerializeField] int startDimension;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        camera = GameObject.FindWithTag("MainCamera");
        if (startDimension != 0)
        {
            dimension = startDimension - 1;
            Interact();
        }
    }
    public override void Interact()
    {
        if (teleportPosition != new Vector2(0, 0))
        {
            player.transform.position = teleportPosition;
            dimension = becomeSpecifikDimension;
            player.GetComponent<PlayerMovement>().respawnPos = teleportPosition;
        }
        else
        {
            dimension++;
            if (dimension > 3)
            {
                dimension = 1;
            }
            player.GetComponent<PlayerMovement>().respawnPos = transform.position;
        }
        GravityChange[] gravityObjects = FindObjectsOfType<GravityChange>();
        foreach (GravityChange g in gravityObjects)
        {
            g.ChangeDimension(dimension);
        }
        ChangeSprite[] spriteObjects = FindObjectsOfType<ChangeSprite>();
        foreach (ChangeSprite s in spriteObjects)
        {
            s.changeSprite();
        }
        camera.GetComponent<CameraCode>().SwitchDimension(dimension);
        for (int i = 1; i < dimensions.Count; i++)
        {
            dimensions[i].GetComponent<Dimension>().ChangeDimension(i == dimension);
        }
    }
}
