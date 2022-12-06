using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JBM_SceneManagment : MonoBehaviour
{
    private int difficultyMode;
    public AudioSource button;

    //Scene Flow
    public void MainMenu()
    {
        SceneManager.LoadScene("JBM_mainMenu");
        Time.timeScale = 1;

        button.Play();
    }

    public void Medium()
    {
        SceneManager.LoadScene("JBM_Game");

        button.Play();
    }

    public void Easy()
    {
        SceneManager.LoadScene("JBM_Easy");

        button.Play();
    }

    public void Difficulty()
    {
        SceneManager.LoadScene("JBM_Hard");

        button.Play();
    }
}
