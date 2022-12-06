using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBM_PlatformSpawnerManager : MonoBehaviour
{
    [SerializeField] float playerCheckDelay = 0.5f;
    [SerializeField] float playerCheckDistance = 10f;
    [SerializeField] float spawnerMovment = 30f;
    [SerializeField] JBM_PlatformSpawner[] spawners; //Spawners List
    [SerializeField] Transform player;

    private void Start()
    {
        StartCoroutine(CheckPlayerDistance());
    }

    IEnumerator CheckPlayerDistance()
    {
        while (Application.isPlaying)
        {
           for (int i = 0; i < spawners.Length; i++) //Infinite loop that takes the platforms in the scene and moves them randomly.
            {
                if (spawners[i].transform.position.y < player.position.y && (spawners[i].transform.position - player.position).sqrMagnitude > playerCheckDistance * playerCheckDistance)//It activates when the player is above it.                   
                {
                    spawners[i].transform.position += Vector3.up * spawnerMovment;//Move the platform
                    spawners[i].RandomizePlatforms();//Call the platform spawner function to continue randomizing
                }
           }

            yield return new WaitForSeconds(playerCheckDelay);
        }
    }
}
