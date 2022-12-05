using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score_UI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] TMPro.TMP_Text score;
    public GameObject panel;

    public bool isPaused;


    private float playerMaxHeigh = -1000;

    void Start()
    {
        panel.SetActive(false);//el pasue esta desactivado
        isPaused = false;

    }
    private void Update()
    {
        if (playerMaxHeigh < player.transform.position.y)//El Score depende de la altura del Player.
        {
            playerMaxHeigh = player.transform.position.y;
            score.text = $"{playerMaxHeigh:F2} m";
        }
    }

    public void PauseGame()
    {
        panel.SetActive(!panel.activeInHierarchy); //activa o desaciva el paenl.

        if (isPaused == false) //pause
        {
            Time.timeScale = 0;
            isPaused = true;
        }
        else //despause
        {
            Time.timeScale = 1;
            isPaused = false;
        }
    }
}

