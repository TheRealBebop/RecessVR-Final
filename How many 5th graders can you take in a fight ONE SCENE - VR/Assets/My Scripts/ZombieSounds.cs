using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSounds : MonoBehaviour
{

    [SerializeField] AudioClip[] zombieSounds;
    [SerializeField] AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayZombieSounds()
    {
        AudioClip clip = zombieSounds[UnityEngine.Random.Range(0, zombieSounds.Length)];
        source.PlayOneShot(clip);
    }
}
