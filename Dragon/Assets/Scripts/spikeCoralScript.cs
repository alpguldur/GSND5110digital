using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeCoralScript : MonoBehaviour {

    public AudioClip spikeCoralSoundEffect;
    private AudioSource source;
    private bool soundPlayed = false;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            source.Play();
        }
    }
}
