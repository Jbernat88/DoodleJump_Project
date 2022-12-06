using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JBM_SceneManagment : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("JBM_mainMenu");
        Time.timeScale = 1;
    }

    public void Game()
    {
        SceneManager.LoadScene("JBM_Game");
    }
}
