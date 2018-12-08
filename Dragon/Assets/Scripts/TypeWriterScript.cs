using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterScript : MonoBehaviour {

    Text imugiText;
    string imugiStory;
    public Button DescendButton;

    void Awake()
    {
        DescendButton.gameObject.SetActive(false);
        imugiText = GetComponent<Text>();
        imugiStory = imugiText.text;
        imugiText.text = "";
        // TODO: add optional delay when to start
        StartCoroutine("PlayText");
    }

    IEnumerator PlayText()
    {
        foreach (char c in imugiStory)
        {
            imugiText.text += c;
            yield return new WaitForSeconds(0.04f);
            
        }
        // after interating through entire text
        // show the descend button
        DescendButton.gameObject.SetActive(true);
    }

       
}
        