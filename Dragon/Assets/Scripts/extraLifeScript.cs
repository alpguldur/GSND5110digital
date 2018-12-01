using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extraLifeScript : MonoBehaviour {

    public AudioClip extraLifeSoundEffect;
    public static AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public static void playExtraLifeSoundEffect()
    {
        source.Play();
    }
}
