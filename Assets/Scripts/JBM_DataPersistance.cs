using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBM_DataPersistance : MonoBehaviour
{

    public static JBM_DataPersistance PlayerStats;

    public float scoreRecord;

    void Awake()
    {
        //If the instance does not exist
        if (PlayerStats == null)
        {
            //We configure the instance
            PlayerStats = this;

            //We make sure that it is not destroyed with the change of scene
            DontDestroyOnLoad(PlayerStats);
        }
        else
        {
            //Since an instance already exists, we destroy the copy
            Destroy(this);
        }
    }

    //Start is called before the first frame update
    void Start()
    {
        scoreRecord = PlayerPrefs.GetFloat("Record");  
    }

    //Update is called once per frame
    public void SaveStats()
    {
        PlayerPrefs.SetFloat("Record", scoreRecord);
    }
}
