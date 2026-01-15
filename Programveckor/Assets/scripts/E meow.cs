using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Emeow : InteractableObject
{
    public AudioSource source;

    public List<AudioClip> sounds;

    //private float random;
    private bool IsMeowing = false;
    float timmer;
    private void FixedUpdate()
    {
        timmer -= Time.fixedDeltaTime;
    }
    public override void Interact()
    {
        Debug.Log("meow " + timmer);
        if (timmer < 0)
        {
            int random = GetRandom();
            PlayRandomSound(random);
        }
        else {
            return;
        } 
    }
    private int GetRandom()
    {
        int random = Random.Range(0, sounds.Count);
        return (random);
    }
    private void PlayRandomSound(int random)
    {
        source.PlayOneShot(sounds[random]);
        timmer = sounds[random].length;
    }
}

