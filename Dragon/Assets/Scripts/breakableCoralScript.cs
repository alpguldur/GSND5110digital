using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakableCoralScript : MonoBehaviour {

    public AudioClip breakableCoralSoundEffect;
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
            if (PlayerController.isDashing == true)
            {
                source.Play();
            }
        }
    }
}
