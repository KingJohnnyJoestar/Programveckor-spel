using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject interactUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interactUI.activeSelf)
        {
            Debug.Log("can interact");
            if(Keyboard.current.eKey.wasPressedThisFrame || Keyboard.current.xKey.wasPressedThisFrame)
            {
                Debug.Log("interact");
                Interact();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
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
    public virtual void Interact()
    {

    }
}
