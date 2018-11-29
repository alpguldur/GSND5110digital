using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virtueScript : MonoBehaviour {

    public AudioClip virtueSoundEffect;
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
            while (soundPlayed == false)
            {
                source.Play();
                soundPlayed = true;
            }
        }
    }
}
