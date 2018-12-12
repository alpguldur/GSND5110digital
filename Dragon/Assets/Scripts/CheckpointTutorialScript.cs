using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointTutorialScript : MonoBehaviour {
    public Text FirstCheckpoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FirstCheckpoint.gameObject.SetActive(true);
            Start();
        }
    }
    private void Start()
    {
        Invoke("DisableText", 10f);
    }

    void DisableText()
    {
        FirstCheckpoint.gameObject.SetActive(false);
    }
}
