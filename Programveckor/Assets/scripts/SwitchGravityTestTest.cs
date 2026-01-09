using UnityEngine;

public class SwitchGravityTestTest : InteractableObject
{
    public GameObject player;
    public override void Interact()
    {
        player.GetComponent<Rigidbody2D>().gravityScale = -player.GetComponent<Rigidbody2D>().gravityScale;
    }
}
