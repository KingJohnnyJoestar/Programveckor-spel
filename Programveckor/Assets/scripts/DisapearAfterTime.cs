using UnityEngine;

public class DisapearAfterTime : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float timeUntilGone;
    float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeUntilGone)
        {
            Destroy(gameObject);
        }
    }
}
