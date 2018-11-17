using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {

    public Image healthBar;

    // Use this for initialization
    void Start ()
    {
        healthBar = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        healthBar.fillAmount = PlayerController.Health / PlayerController.maxHealth;
    }
}
