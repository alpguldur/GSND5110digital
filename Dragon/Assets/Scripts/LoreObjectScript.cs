using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoreObjectScript : MonoBehaviour {
    public Text FoundKkwaengariLore;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                FoundKkwaengariLore.gameObject.SetActive(true);
                Start();
            }
        }
    }
    private void Start()
    {
        Invoke("DisableText", 10.5f);
    }

    void DisableText()
    {
        FoundKkwaengariLore.gameObject.SetActive(false);
    }
}
