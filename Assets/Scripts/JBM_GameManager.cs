using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JBM_GameManager : MonoBehaviour
{
    [SerializeField] float playerCheckDelay = 0.5f;
    [SerializeField] float playerCheckDistance = 10f;
    [SerializeField] float fallTheshold = 3;

    [SerializeField] Transform player;

    private float playerMaxHeigh = 0;

    private JBM_Score_UI scoreUIScript;

    private void Start()
    {
        scoreUIScript = GameObject.Find("UI").GetComponent<JBM_Score_UI>();

        StartCoroutine(CheckPlayerDistance());
    }

    IEnumerator CheckPlayerDistance()
    { 
        //Cada vez que el personaje llega al theshold el juego se reinicia la escena
        while (Application.isPlaying)
        {
            
            if (player.transform.position.y < playerMaxHeigh - fallTheshold)
            { 
                if(scoreUIScript.playerMaxHeigh > JBM_DataPersistance.PlayerStats.scoreRecord)
                {
                    scoreUIScript.UpdateScore();
                }
              
                yield return SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
            }


                playerMaxHeigh = player.transform.position.y;

            yield return new WaitForSeconds(playerCheckDelay);
        }

    }


}
