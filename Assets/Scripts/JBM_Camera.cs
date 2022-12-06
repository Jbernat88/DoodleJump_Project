using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBM_Camera : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");//follow the player
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(0f, player.transform.position.y, -10f);
    }
}