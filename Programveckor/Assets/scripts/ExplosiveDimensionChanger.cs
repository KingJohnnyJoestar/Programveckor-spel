using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;
public class ExplosiveDimensionChanger : DimensionChanger
{
    public AudioClip newSong;
    public GameObject explosion;
    public List<GameObject> changeColorObjects;
    public Color32 newColor;
    public override void Interact()
    {
        base.Interact();
        Destroy(gameObject);
        camera.GetComponent<AudioSource>().clip = newSong;
        camera.GetComponent<AudioSource>().Play();
        for(int i = 0; i < changeColorObjects.Count; i++)
        {
            changeColorObjects[i].GetComponent<SpriteRenderer>().color = newColor;
        }
        Instantiate(explosion, transform.position, quaternion.identity);
    }
}
