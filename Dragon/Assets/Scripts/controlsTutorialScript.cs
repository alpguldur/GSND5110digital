using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlsTutorialScript : MonoBehaviour {

    public Text TutorialText, CoinTutorialText, enemyTutorialText;

    void Awake()
    {
        TutorialText.gameObject.SetActive(true);
    }

    private void Start()
    {
        Invoke("DisableText", 6f);
    }

    void DisableText()
    {
        TutorialText.gameObject.SetActive(false);
    }
}
