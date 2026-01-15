using UnityEngine;

public class Dimension : MonoBehaviour
{
    [SerializeField] GameObject disableObject;
    public void ChangeDimension(bool active)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject currentChild = transform.GetChild(i).gameObject;
            if (currentChild.GetComponent<SpriteRenderer>())
            {
                if (active)
                {
                    currentChild.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                    currentChild.layer = 0;
                }
                else
                {
                    currentChild.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 100);
                    currentChild.layer = 6;
                }
            }
        }
        if (disableObject != null)
        {
            disableObject.SetActive(active);
        }
    }
}
