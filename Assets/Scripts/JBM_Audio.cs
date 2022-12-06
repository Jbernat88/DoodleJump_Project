using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBM_Audio : MonoBehaviour
{
    private void Awake()
    {
        //The music stays between scenes
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
