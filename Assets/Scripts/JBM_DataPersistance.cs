using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBM_DataPersistance : MonoBehaviour
{

    public static JBM_DataPersistance PlayerStats;

    public float scoreRecord;

    void Awake()
    {
        // Si la instancia no existe
        if (PlayerStats == null)
        {
            // Configuramos la instancia
            PlayerStats = this;

            // Nos aseguramos de que no sea destruida con el cambio de escena
            DontDestroyOnLoad(PlayerStats);
        }
        else
        {
            // Como ya existe una instancia, destruimos la copia
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        scoreRecord = PlayerPrefs.GetFloat("Record");
    
    }

    // Update is called once per frame
    public void SaveStats()
    {
        PlayerPrefs.SetFloat("Record", scoreRecord);
    }
}
