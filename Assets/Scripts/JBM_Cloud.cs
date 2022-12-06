using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBM_Cloud : MonoBehaviour
{
    private JBM_PlatformSpawner platformSpawnerScript;

    private void Start()
    {
       platformSpawnerScript = GameObject.Find("PlatformSpawner").GetComponent<JBM_PlatformSpawner>();
    }

    private void Update()
    {
        if (platformSpawnerScript.reactivePlatform)
        {
            gameObject.SetActive(true);
            platformSpawnerScript.reactivePlatform = false;
        }
    }
 
}
