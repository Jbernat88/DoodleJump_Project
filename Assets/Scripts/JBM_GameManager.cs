using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JBM_GameManager : MonoBehaviour
{
    [SerializeField] float playerCheckDelay = 0.5f;
    [SerializeField] float playerCheckDistance = 10f;
    [SerializeField] float fallTheshold = 3; //Fall margin

    [SerializeField] Transform player;

    private float playerMaxHeigh = 0;

    private JBM_Score_UI scoreUIScript;

    private void Start()
    {
        //Call the script "JBM_Score_UI"
        scoreUIScript = GameObject.Find("UI").GetComponent<JBM_Score_UI>();

        StartCoroutine(CheckPlayerDistance());
    }

    IEnumerator CheckPlayerDistance()
    {
        //Every time the character reaches theshold the game restarts the scene
        while (Application.isPlaying)
        {
            
            if (player.transform.position.y < playerMaxHeigh - fallTheshold)
            { 
                if(scoreUIScript.playerMaxHeigh > JBM_DataPersistance.PlayerStats.scoreRecord)
                {
                    scoreUIScript.UpdateScore();
                }

                //Reloads the scene I'm in
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);                                                                    
            }
                playerMaxHeigh = player.transform.position.y;

            yield return new WaitForSeconds(playerCheckDelay);
        }
    }
}
