using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionScript : MonoBehaviour
{
    public void Return()
    {
        SceneManager.LoadScene("00_TitleScreen");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("01_IntroScene");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("02_LevelSelect");
    }

    public void Descend()
    {
        SceneManager.LoadScene("03_ShallowsLevel");
    }

    public void Abyss()
    {
        SceneManager.LoadScene("04_AbyssLevel");
    }

    public void Credits()
    {
        SceneManager.LoadScene("05_CreditsScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
