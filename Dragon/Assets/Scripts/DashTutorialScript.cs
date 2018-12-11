using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashTutorialScript : MonoBehaviour
{
    public Text DashTutorialText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DashTutorialText.gameObject.SetActive(true);
            Start();
            
        }
    }
    private void Start()
    {
        Invoke("DisableText", 8f);
    }

    void DisableText()
    {
        DashTutorialText.gameObject.SetActive(false);
    }
}