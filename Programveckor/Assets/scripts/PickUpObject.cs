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
    void Start()
    {
        
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
            if ((DimensionChanger.dimension == 2) == (GetComponent<BoxCollider2D>().offset == new Vector2(0, 0.5f)))
            {
                if (DimensionChanger.dimension == 2)
                {
                    GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.5f);
                }
                else
                {
                    GetComponent<BoxCollider2D>().offset = new Vector2(0, 0.5f);
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
        GetComponent<BoxCollider2D>().size = new Vector2(1,2);
        if (DimensionChanger.dimension == 2)
        {
            GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.5f);
        }
        else
        {
            GetComponent<BoxCollider2D>().offset = new Vector2(0, 0.5f);
        }
    }
    public void drop()
    {
        carryItem = null;
        GetComponent<BoxCollider2D>().size = new Vector2(1, 1);
        GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);
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
