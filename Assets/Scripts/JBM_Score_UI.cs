using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JBM_Score_UI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] TMPro.TMP_Text score;
    public GameObject panel;

    public bool isPaused;

    public float playerMaxHeigh = -1000f;
    public float newRecord;

    [SerializeField] TMPro.TMP_Text record;

    public AudioSource button;

    void Start()
    {
        panel.SetActive(false);//el pasue esta desactivado
        isPaused = false;
    }
    private void Update()
    {
        record.text = $"{JBM_DataPersistance.PlayerStats.scoreRecord:F2} m";

        if (playerMaxHeigh < player.transform.position.y)//El Score depende de la altura del Player.
        {
            playerMaxHeigh = player.transform.position.y;
            score.text = $"{playerMaxHeigh:F2} m";

        }
    }

    public void UpdateScore()
    {
        JBM_DataPersistance.PlayerStats.scoreRecord = playerMaxHeigh;
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

        button.Play();
    }
}

