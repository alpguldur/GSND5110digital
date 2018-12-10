using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionScript : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("01_IntroScene");
    }

    public void Descend()
    {
        SceneManager.LoadScene("03_ShallowsLevel");
    }

    public void Abyss()
    {
        SceneManager.LoadScene("04_AbyssLevel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
