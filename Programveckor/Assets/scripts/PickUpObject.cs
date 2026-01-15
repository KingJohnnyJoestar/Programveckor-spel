using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject carryItem;
    public float heightAbovePlayer;
    bool cantDrop;
    public Vector2 throwVelocity;
    public float throwUpVelocity;
    BoxCollider2D coll;
    public float boxCollXSize;
    void Start()
    {
        coll = transform.GetChild(0).GetComponent<BoxCollider2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame || Keyboard.current.cKey.wasPressedThisFrame)
        {
            if (carryItem != null && !cantDrop)
            {
                Debug.Log("drop " + carryItem.name);
                carryItem.GetComponent<Item>().Drop();
                float upVelocity = throwVelocity.y;
                if (GetComponent<PlayerMovement>().GetDirection() == 0)
                {
                    upVelocity = throwUpVelocity;
                }
                carryItem.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(throwVelocity.x * GetComponent<PlayerMovement>().GetDirection(), upVelocity);
                drop();
            }
        }
        if (carryItem != null)
        {
            if ((DimensionChanger.dimension == 2) == (coll.offset == new Vector2(0, 0.5f)))
            {
                if (DimensionChanger.dimension == 2)
                {
                    coll.offset = new Vector2(0, -0.5f);
                }
                else
                {
                    coll.offset = new Vector2(0, 0.5f);
                }
            }
            Vector2 itemPosition = transform.position;
            if (GetComponent<Rigidbody2D>().gravityScale > 0)
            {
                itemPosition.y += heightAbovePlayer;
            }
            else
            {
                itemPosition.y -= heightAbovePlayer;
            }
            carryItem.transform.position = itemPosition;
        }
        cantDrop = false;
    }
    public void PickUp(GameObject item)
    {
        carryItem = item;
        cantDrop = true;
        coll.size = new Vector2(boxCollXSize,2);
        if (DimensionChanger.dimension == 2)
        {
            coll.offset = new Vector2(0, -0.5f);
        }
        else
        {
            coll.offset = new Vector2(0, 0.5f);
        }
    }
    public void drop()
    {
        carryItem = null;
        coll.size = new Vector2(boxCollXSize, 1);
        coll.offset = new Vector2(0, 0);
    }
    public void Reset()
    {
        
        if (carryItem != null)
        {
            carryItem.GetComponent<Item>().Reset();
            drop();
        }
    }
}
