using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTutorialText : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Add text appearing code here
        }
    }
}
