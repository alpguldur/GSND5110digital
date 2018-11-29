using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seaweedScript : MonoBehaviour {

    public AudioClip seaweedSoundEffect;
    private AudioSource source;
    private bool soundPlayed = false;
    
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && PlayerController.Health != 100)
        {
            while (soundPlayed == false)
            {
                source.Play();
                soundPlayed = true;
            }
        }
    }
}