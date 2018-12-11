using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public AudioClip checkpointSoundEffect;
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
                Destroy(this.GetComponent("SpriteRenderer"));
            }
        }
    }
}
