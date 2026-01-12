using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Emeow : InteractableObject
{
    public AudioSource source;

    public List<AudioClip> sounds;
    //public AudioClip sound1;  
    //public AudioClip sound2;
    //public AudioClip sound3;
    //public AudioClip sound4;

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
        //if (random == 1)
        //{
        //    source.PlayOneShot(sound1);
        //}
        //if (random == 2)
        //{

        //    source.PlayOneShot(sound2);
        //}
        //if (random == 3)
        //{
        //    source.PlayOneShot(sound3);
        //}
        //if (random == 4)
        //{
        //    source.PlayOneShot(sound4);
        //}
    }
}

