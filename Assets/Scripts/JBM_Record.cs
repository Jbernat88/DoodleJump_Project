using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JBM_Record : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text record;
   
    // Update is called once per frame
    void Update()
    {
        // what appears in the text     
        record.text = $"{JBM_DataPersistance.PlayerStats.scoreRecord:F2} m";
    }
}
