﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public static int lives = 3;

    public void PlayGame()
    {
        SceneManager.LoadScene("03_ShallowsLevel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
