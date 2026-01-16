using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winTeleporter : InteractableObject 
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float timer;
    public float timeBetweenSpriteChanges;
    SpriteRenderer sr;
    public List<Sprite> sprites;
    public int winScene;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenSpriteChanges)
        {
            sr.sprite = sprites[Random.Range(0, sprites.Count)];
            timer = 0;
        }

    }
    public override void Interact()
    {
        SceneManager.LoadScene(winScene);
    }
}
