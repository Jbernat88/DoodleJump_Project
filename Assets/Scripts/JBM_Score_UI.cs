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

    public GameObject vignete;

    void Start()
    {
        vignete.SetActive(false);//The vignet is desactived at the start
        panel.SetActive(false);//The panel is desactived at the start
        isPaused = false;//The pause is desactived at the start
    }
    private void Update()
    {
        record.text = $"{JBM_DataPersistance.PlayerStats.scoreRecord:F2} m";

        if (playerMaxHeigh < player.transform.position.y)//The Score depends on the height of the Player.            
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
        panel.SetActive(!panel.activeInHierarchy); //active or desacive the paenl.

        if (isPaused == false) //pause
        {
            vignete.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
        else //break
        {
            Time.timeScale = 1;
            isPaused = false;
            vignete.SetActive(false);
        }

        button.Play();


    }
}

