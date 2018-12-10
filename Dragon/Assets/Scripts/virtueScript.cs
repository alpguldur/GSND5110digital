using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class virtueScript : MonoBehaviour {

    public AudioClip virtueSoundEffect;
    private AudioSource source;
    private bool soundPlayed = false;
    public Text FoundStrengthVirtue;

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
        FoundStrengthVirtue.gameObject.SetActive(true);
            Start();
        }
    }

    private void Start()
    {
        Invoke("DisableText", 9f);
    }

    void DisableText()
        {
            FoundStrengthVirtue.gameObject.SetActive(false);
        }
}
