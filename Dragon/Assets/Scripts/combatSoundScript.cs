using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatSoundScript : MonoBehaviour {

    public AudioClip combatSoundEffect;
    public static AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public static void playCombatSoundEffect()
    {
        source.Play();
    }
}
