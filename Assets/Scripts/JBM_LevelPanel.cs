using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBM_LevelPanel : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);//Desactive the panel
    }

    public void DificulttyButton()
    {
        panel.SetActive(true);//Active the panel
    }
}
