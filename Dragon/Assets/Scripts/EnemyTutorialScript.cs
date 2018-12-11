using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTutorialScript : MonoBehaviour {

    public Text EnemyTutorialText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TutorialEnemy"))
        {

            EnemyTutorialText.gameObject.SetActive(true);
            Start();
        }
    }
    // Use this for initialization
    void Start () {
        Invoke("DisableText", 9f);
    }
	
	// Update is called once per frame
	void Update () {
        EnemyTutorialText.gameObject.SetActive(false);
    }
}
