using UnityEngine;
using UnityEngine.InputSystem;

public class Emeow : MonoBehaviour
{
    public AudioSource source;

    public AudioClip sound1;  
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;

    private float random;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            random = GetRandom();
            PlayRandomSound(random);
        }
    }

    private float GetRandom()
    {
        random = Random.Range(1, 5);
        return (random);
    }
    private void PlayRandomSound(float random)
    {
        if (random == 1)
        {
            source.PlayOneShot(sound1);
        }
        if (random == 2)
        {
            source.PlayOneShot(sound2);
        }
        if (random == 3)
        {
            source.PlayOneShot(sound3);
        }
        if (random == 4)
        {
            source.PlayOneShot(sound4);
        }
    }
}

