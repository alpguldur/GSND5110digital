using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class coinScript : MonoBehaviour {

    public AudioClip coinSoundEffect;
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
            while(soundPlayed == false)
            {
                source.Play();
                soundPlayed = true;
            }
        }
    }
}