using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DimensionChanger : InteractableObject
{
    public static int dimension = 1; // eftersom dimension är public static så kan man komma åt den var som hellst med DimiensionChanger.dimension
    [SerializeField] List<GameObject> dimensions;
    public Vector2 teleportOffset;
    public GameObject teleportObject;
    public int becomeSpecifikDimension;
    GameObject player;
    protected GameObject camera;
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
        player.GetComponent<PlayerMovement>().respawnPos = player.transform.position;
    }
    public override void Interact()
    {
        if (becomeSpecifikDimension != 0)
        {
            dimension = becomeSpecifikDimension;
        }
        else
        {
            dimension++;
            if (dimension > 3)
            {
                dimension = 1;
            }
        }
        if (teleportObject != null)
        {
            Vector2 teleportPosition = teleportObject.transform.position + new Vector3(teleportOffset.x, teleportOffset.y);
            player.transform.position = teleportPosition;
            player.GetComponent<PlayerMovement>().respawnPos = teleportPosition;
        }
        else
        {
            player.GetComponent<PlayerMovement>().respawnPos = transform.position;
        }
        DimensionChange[] dimensionObjects = FindObjectsOfType<DimensionChange>();
        foreach (DimensionChange d in dimensionObjects)
        {
            d.dimensionChange();
        }
        //GravityChange[] gravityObjects = FindObjectsOfType<GravityChange>();
        //foreach (GravityChange g in gravityObjects)
        //{
        //    g.ChangeDimension(dimension);
        //}
        //ChangeSprite[] spriteObjects = FindObjectsOfType<ChangeSprite>();
        //foreach (ChangeSprite s in spriteObjects)
        //{
        //    s.changeSprite();
        //}
        if (dimensions.Count > 0)
        {
            for (int i = 1; i < dimensions.Count; i++)
            {
                dimensions[i].GetComponent<Dimension>().ChangeDimension(i == dimension);
            }
            camera.GetComponent<CameraCode>().SwitchDimension(dimension);
        }
    }
}
