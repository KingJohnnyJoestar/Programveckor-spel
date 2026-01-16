using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Item : MonoBehaviour
{    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject interactUI;
    PickUpObject player;
    bool caried;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PickUpObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (caried && GetComponent<Collider>() != null)
        {
            ////interactUI.SetActive(false);
            //BoxCollider2D[] coliders = GetComponents<BoxCollider2D>();
            //for (int i = 0; i < coliders.Length; i++)
            //{
            //    coliders[i].enabled = false;
            //}
            //collider.enabled = false;
        }
        if (interactUI.activeSelf)
        {

            if (Keyboard.current.cKey.wasPressedThisFrame || Keyboard.current.qKey.wasPressedThisFrame)
            {
                Debug.Log("pick up");
                player.PickUp(gameObject);
                PickUp();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interactUI.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interactUI.SetActive(false);
        }
    }
    public virtual void PickUp()
    {
        caried = true;
        ChangeColidersEnebled(false);
    }
    public virtual void Drop()
    {
        caried = false;
        ChangeColidersEnebled(true);
    }
    void ChangeColidersEnebled(bool enebled)
    {
        //BoxCollider2D[] coliders = GetComponents<BoxCollider2D>();
        //for (int i = 0; i < coliders.Length; i++)
        //{
        //    coliders[i].enabled = enebled;
        //}
        if (!enebled)
        {
            gameObject.layer = 3;
        }
        else
        {
            gameObject.layer = 0;
        }
    }
    public void Reset()
    {
        ChangeColidersEnebled(true);
    }
    //public virtual void carry(Vector2 position)
    //{
    //    transform.position = position;
    //}
}
