using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTutorialScript : MonoBehaviour {

    public Text EnemyTutorialText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EnemyTutorialText.gameObject.SetActive(true);
            Start();
        }
    }
    // Use this for initialization
    private void Start () {
        Invoke("DisableText", 9f);
    }

	void DisableText()
    {
        EnemyTutorialText.gameObject.SetActive(false);
    }
}
