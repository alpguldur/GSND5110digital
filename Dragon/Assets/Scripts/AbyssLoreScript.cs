using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbyssLoreScript : MonoBehaviour
{

    public Text Lore_EvilDwayne;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Lore_EvilDwayne.gameObject.SetActive(true);
            Start();
        }

    }
    // Use this for initialization
    void Start()
    {
        Invoke("DisableText", 15f);
    }

    // Update is called once per frame
    void DisableText()
    {
        Lore_EvilDwayne.gameObject.SetActive(false);
    }
}
