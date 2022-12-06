using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JBM_SceneManagment : MonoBehaviour
{
    public AudioSource button;
    public void MainMenu()
    {
        SceneManager.LoadScene("JBM_mainMenu");
        Time.timeScale = 1;

        button.Play();
    }

    public void Game()
    {
        SceneManager.LoadScene("JBM_Game");

        button.Play();
    }
}
