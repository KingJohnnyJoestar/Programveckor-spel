using UnityEngine;

public class SwitchRemoveObject : InteractableObject
{
    public GameObject removeObject;
    public override void Interact()
    {
        removeObject.SetActive(!removeObject.activeSelf);
    }
}
